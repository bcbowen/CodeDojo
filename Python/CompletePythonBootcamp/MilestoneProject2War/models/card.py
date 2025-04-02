import pytest

class Card: 

    values = {'Two': 2, 'Three': 3, 'Four': 4, 'Five': 5, 'Six': 6, 'Seven': 7, 'Eight': 8, 'Nine': 9, 'Ten': 10, 'Jack': 11, 'Queen': 12, 'King': 13, 'Ace': 14 }
    suits = ('Hearts', 'Clubs', 'Spades', 'Diamonds')
    ranks = ('Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 'Jack', 'Queen', 'King', 'Ace' )

    def __init__(self, rank: str, suit: str): 
        if rank not in Card.ranks: 
            raise Exception("Invalid Rank")
        
        if suit not in Card.suits: 
            raise Exception("Invalid Suit")
        
        self.rank = rank
        self.suit = suit
        self.value = Card.values[rank]
        

    def __str__(self): 
        return f"{self.rank} of {self.suit}"
    
@pytest.mark.parametrize("rank, suit, expected_value", [
    ("Two", "Spades", 2), 
    ("Ace", "Clubs", 14), 
])    
def test_card_init(rank: str, suit: str, expected_value: int): 
    card = Card(rank, suit)
    assert(card.rank == rank)
    assert(card.suit == suit)
    assert(card.value == expected_value)

# with pytest.raises(ValueError, match='must be 0 or None'):

@pytest.mark.parametrize("rank", [
    ("2"), 
    ("Ass"),
    ("jack"),
    ("Too")
])
def test_invalid_ranks(rank: str): 
    suit = "Hearts"
    with pytest.raises(Exception, match="Invalid Rank"): 
        _ = Card(rank, suit)

@pytest.mark.parametrize("suit", [
    ("Rocks"), 
    ("spades"),
    ("Clubbers"),
    ("HEARTS")
])
def test_invalid_suits(suit: str): 
    rank = "Two"
    with pytest.raises(Exception, match="Invalid Suit"): 
        _ = Card(rank, suit)

if __name__ == "__main__":     
    pytest.main([__file__])