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
    card_values = { "A": 14, "K": 13, "Q": 12, "J": 11, "T": 10, "9": 9, "8": 8, "7" : 7, "6" : 6, "5" : 5, "4" : 4 , "3" : 3, "2" : 2 } 
    def __init__(self): 
        pass

    def load(self, file_name: str) -> list[Bet]: 
        path = str(Path(__file__).parent)
        data_path = path.replace("CodeDojo\\adventOfCode", "adventOfCodePrivateFiles")
        file_path = Path(data_path, file_name).resolve()
        bets = []
        with open(file_path) as file: 
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
    
    def get_hand(cards: str) -> Hand: 
        counts = defaultdict(int)
        for card in cards: 
            counts[card] += 1
        key_len = len(counts.keys())
        values = list(counts.values())
        if key_len == 1: 
            return Hand.FiveOfAKind
        if key_len == 2: 
            if values[0] in [4, 1]: 
                return Hand.FourOfAKind
            else: 
                return Hand.FullHouse
        if 3 in values: 
            return Hand.ThreeOfAKind
        if key_len == 3: 
            return Hand.TwoPair
        if 2 in values: 
            return Hand.OnePair
        return Hand.HighCard


def part1(): 
    file_name = "input.txt"
    game = Game(); 
    result = game.play(file_name=file_name)
    print(f"Part1: {result}")

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
    ("Q2222", Hand.FourOfAKind),
    ("QQQQ2", Hand.FourOfAKind),
    ("QQQ22", Hand.FullHouse),
    ("22QQQ", Hand.FullHouse),
    ("2Q2Q2", Hand.FullHouse),
    ("2Q232", Hand.ThreeOfAKind),
    ("QQQ23", Hand.ThreeOfAKind),
    ("42423", Hand.TwoPair),
    ("44233", Hand.TwoPair),
    ("52344", Hand.OnePair),
    ("52534", Hand.OnePair),
    ("55234", Hand.OnePair),
    ("62345", Hand.HighCard),
])
def test_GetHand(cards: str, expected: Hand): 
    result = Game.get_hand(cards)
    assert(expected == result) 

@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 6440)
])
def test_game(file_name: str, expected: int): 
    game = Game()
    result = game.play(file_name=file_name)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])
    part1()