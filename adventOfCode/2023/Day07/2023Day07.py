import pytest
from enum import Enum

class Hand(Enum): 
    FiveOfAKind = 7, 
    FourOfAKind = 6, 
    FullHouse = 5, 
    ThreeOfAKind = 4, 
    TwoPair = 3, 
    OnePair = 2, 
    HighCard = 1

class Game: 
    def __init__(self): 
        pass

    def play(self, file_name: str) -> int: 
        pass

    def get_hand(cards: str) -> Hand: 
        counts = {}
        for card in cards: 
            if not card in counts: 
                counts[card] = 0
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

if __name__ == "__main__": 
    pytest.main([__file__])