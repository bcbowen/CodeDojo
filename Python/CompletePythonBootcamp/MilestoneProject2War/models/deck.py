import pytest
import random
from models.card import Card

class Deck: 
    def __init__(self): 
        self.cards = [] 
        for suit in Card.suits: 
            for rank in Card.ranks: 
                self.cards.append(Card(rank, suit))
    
        self.shuffle_deck()

    def shuffle_deck(self): 
        random.shuffle(self.cards)

    def deal_one(self): 
        if len(self.cards) == 0: 
            raise Exception("No more cards!")
        return self.cards.pop()

def test_deck_init(): 
    d = Deck()
    assert(len(d.cards) == 52)


if __name__ == "__main__": 
    pytest.main([__file__])