import pytest
from models.card import Card 
from typing import List

class Player: 
    def __init__(self, name: str): 
        self.name = name
        self.hand : List[Card] = []

    def __str__(self): 
        return f'Player {self.name} with {len(self.hand)} cards'

    def remove_one(self) -> Card: 
        return self.hand.pop(0)

    def add_cards(self, cards: List[Card]): 
        self.hand.extend(cards)


def test_remove_one(): 
    cards = [Card('Two', 'Hearts'), Card('Jack', 'Clubs')]
    p = Player("Fred")
    p.hand = cards 
    c = p.remove_one()
    assert(c.rank == 'Two')
    assert(c.suit == 'Hearts')
    assert(len(p.hand) == 1)

def test_add_cards(): 
    cards = [Card('Two', 'Hearts'), Card('Jack', 'Clubs')]
    p = Player("Fred")
    p.add_cards(cards)
    assert(len(p.hand) == 2)

if __name__ == "__main__": 
    pytest.main([__file__])