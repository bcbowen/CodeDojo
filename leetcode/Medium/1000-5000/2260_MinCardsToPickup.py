import pytest

class Solution:
    def minimumCardPickup(self, cards: list[int]) -> int:
        card_lookup = {}
        for i, v in enumerate(cards): 
            if not v in card_lookup: 
                card_lookup[v] = []
            card_lookup[v].append(i)
        min_dist = float('inf')
        for key in card_lookup.keys(): 
            if len(card_lookup[key]) > 1: 
                for i in range(1, len(card_lookup[key])): 
                    dist = card_lookup[key][i] - card_lookup[key][i - 1] + 1
                    min_dist = min(dist, min_dist)
        return min_dist if min_dist < float('inf') else -1 

"""
Example 1:
Input: cards = [3,4,2,3,4,7]
Output: 4
Explanation: We can pick up the cards [3,4,2,3] which contain a matching pair of cards with value 3. Note that picking up the cards [4,2,3,4] is also optimal.

Example 2:
Input: cards = [1,0,5,3]
Output: -1
Explanation: There is no way to pick up a set of consecutive cards that contain a pair of matching cards.

"""
@pytest.mark.parametrize("cards, expected", [
    ([3,4,2,3,4,7], 4), 
    ([1,0,5,3], -1)
])
def test_minimumCardPickup(cards: list[int], expected: int):
    sol = Solution() 
    result = sol.minimumCardPickup(cards)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])