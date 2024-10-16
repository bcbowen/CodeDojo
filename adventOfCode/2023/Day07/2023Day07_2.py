import pytest
from collections import defaultdict
from ordered_enum import OrderedEnum
from functools import cmp_to_key
from pathlib import Path

class Hand(OrderedEnum): 
    HighCard = 1,
    OnePair = 2, 
    TwoPair = 3,
    ThreeOfAKind = 4,
    FullHouse = 5,
    FourOfAKind = 6,
    FiveOfAKind = 7 


class Bet: 
    def __init__(self, cards: str, bet: int):
        self.place = 0
        self.cards = cards
        self.bet = bet


class Game:
    card_values = { "A": 14, "K": 13, "Q": 12, "T": 10, "9": 9, "8": 8, "7" : 7, "6" : 6, "5" : 5, "4" : 4 , "3" : 3, "2" : 2, "J": 1 } 
    def __init__(self): 
        pass

    def get_input_filepath(file_name: str): 
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files 
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"
        
        input_path = private_files_base / year / day / file_name
        return input_path

    def load(self, file_name: str) -> list[Bet]: 
        input_path = Game.get_input_filepath(file_name)
        bets = []
        with open(input_path) as file: 
            text = file.read() 
            lines = text.split('\n')
            
            for line in lines: 
                fields = line.split(' ')
                bet = Bet(cards=fields[0], bet=int(fields[1]))
                bets.append(bet)
                
            file.close()
        return bets

    def play(self, file_name: str) -> int: 
        bets = self.load(file_name)
        bets = sorted(bets, key=cmp_to_key(Game.compare_bets))
        score = 0
        place = 1
        for bet in bets: 
            score += bet.bet * place
            place += 1
        return score
    
    def compare_bets(b1: Bet, b2: Bet) -> int:
        return Game.compare_hands(b1.cards, b2.cards)

    def compare_hands(c1: str, c2: str) -> int:
        h1 = Game.get_hand(c1)
        h2 = Game.get_hand(c2)

        if h1 < h2: 
            return -1
        elif h1 > h2:
            return 1
        else: 
            for i in range(len(c1)): 
                if Game.card_values[c1[i]] < Game.card_values[c2[i]]: 
                    return -1
                elif Game.card_values[c1[i]] > Game.card_values[c2[i]]:
                    return 1
        return 0
    
    def check_wildcards(cards: str, hand: Hand) -> Hand: 
        if not 'J' in cards or hand == Hand.FiveOfAKind: 
            return hand
        wildcard_count = cards.count('J')

        if hand == Hand.HighCard: 
            match wildcard_count: 
                case 1: 
                    return Hand.OnePair
                case 2: 
                    return Hand.ThreeOfAKind
                case 3: 
                    return Hand.FourOfAKind
                case 4: 
                    return Hand.FiveOfAKind
        if hand == Hand.OnePair: 
            match wildcard_count: 
                case 1: 
                    return Hand.ThreeOfAKind
                case 2: 
                    # one pair and wild card count is 2: the pair is wildcards so the best hand is 3 of a kind
                    return Hand.ThreeOfAKind
                case 3: 
                    return Hand.FiveOfAKind
        if hand == Hand.TwoPair: 
            if wildcard_count == 2: 
                return Hand.FourOfAKind
            else: 
                return Hand.FullHouse
        if hand == Hand.ThreeOfAKind: 
            # wild card count can either be 1 or 3, either way we have 3 + 1 or 1 + 3 = 4 of a kind
            return Hand.FourOfAKind
        if hand == Hand.FullHouse or hand == Hand.FourOfAKind: 
            return Hand.FiveOfAKind



    def get_hand(cards: str) -> Hand: 
        counts = defaultdict(int)
        hand = Hand.HighCard
        for card in cards: 
            counts[card] += 1
        key_len = len(counts.keys())
        values = list(counts.values())
        if key_len == 1: 
            hand = Hand.FiveOfAKind
        elif key_len == 2: 
            if values[0] in [4, 1]: 
                hand = Hand.FourOfAKind
            else: 
                hand = Hand.FullHouse
        elif 3 in values: 
            hand = Hand.ThreeOfAKind
        elif key_len == 3: 
            hand = Hand.TwoPair
        elif 2 in values: 
            hand = Hand.OnePair
        
        hand = Game.check_wildcards(cards, hand)
        return hand


def part2(): 
    file_name = "input.txt"
    game = Game(); 
    result = game.play(file_name=file_name)
    print(f"Part2: {result}")

@pytest.mark.parametrize("c1, c2, expected", [
    ("QQQQQ", "QQQQ2", 1),
    ("QQQQ2", "QQQQQ", -1),
    ("22222", "QQQQQ", -1),
    ("QQQQQ", "22222", 1),
    ("Q2222", "QQQKK", 1),
    ("QQQKK", "Q2222", -1),
    ("2222K", "K2222", -1),
    ("A2222", "AAAA2", -1),
    ("A2345", "22345", -1), 
])
def test_CompareHands(c1: str, c2: str, expected: int): 
    result = Game.compare_hands(c1, c2)
    assert(expected == result) 

@pytest.mark.parametrize("cards, expected", [
    ("QQQQQ", Hand.FiveOfAKind),
    ("Q1111", Hand.FourOfAKind),
    ("QQQQ1", Hand.FourOfAKind),
    ("QQQ22", Hand.FullHouse),
    ("22QQQ", Hand.FullHouse),
    ("2Q2Q2", Hand.FullHouse),
    ("2Q212", Hand.ThreeOfAKind),
    ("QQQ23", Hand.ThreeOfAKind),
    ("12123", Hand.TwoPair),
    ("11233", Hand.TwoPair),
    ("12344", Hand.OnePair),
    ("12134", Hand.OnePair),
    ("11234", Hand.OnePair),
    ("12345", Hand.HighCard),
])
def test_GetHand(cards: str, expected: Hand): 
    result = Game.get_hand(cards)
    assert(expected == result) 

@pytest.mark.parametrize("cards, expected", [
    ("JQQQQ", Hand.FiveOfAKind),
    ("JQQQJ", Hand.FiveOfAKind),
    ("JQJQJ", Hand.FiveOfAKind),
    ("JJQJJ", Hand.FiveOfAKind),
    ("QJ111", Hand.FourOfAKind),

    ("JQQQ1", Hand.FourOfAKind),
    ("QQJ22", Hand.FullHouse),
    ("JQ2Q2", Hand.FullHouse),
    ("JQ212", Hand.ThreeOfAKind),
    ("JQQ23", Hand.ThreeOfAKind),
    ("123J4", Hand.OnePair)
])
def test_GetHandWithWildCard(cards: str, expected: Hand): 
    result = Game.get_hand(cards)
    assert(expected == result) 

@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 5905)
])
def test_game(file_name: str, expected: int): 
    game = Game()
    result = game.play(file_name=file_name)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])
    part2()