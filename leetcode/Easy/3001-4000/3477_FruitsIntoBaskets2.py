import pytest
from typing import List

class Solution:
    def numOfUnplacedFruits(self, fruits: List[int], baskets: List[int]) -> int:
        placements = [-1] * len(fruits)
        unplaced = 0
        for i in range(len(fruits)):
            placed = False 
            for j in range(len(baskets)):
                if placements[j] == -1 and baskets[j] >= fruits[i]:
                    placements[j] = fruits[i]
                    placed = True
                    break 
            if not placed: 
                unplaced += 1
        return unplaced
    
"""
Example 1:
Input: fruits = [4,2,5], baskets = [3,5,4]
Output: 1
Explanation:
fruits[0] = 4 is placed in baskets[1] = 5.
fruits[1] = 2 is placed in baskets[0] = 3.
fruits[2] = 5 cannot be placed in baskets[2] = 4.
Since one fruit type remains unplaced, we return 1.

Example 2:
Input: fruits = [3,6,1], baskets = [6,4,7]
Output: 0
Explanation:
fruits[0] = 3 is placed in baskets[0] = 6.
fruits[1] = 6 cannot be placed in baskets[1] = 4 (insufficient capacity) but can be placed in the next available basket, baskets[2] = 7.
fruits[2] = 1 is placed in baskets[1] = 4.
Since all fruits are successfully placed, we return 0.
"""
@pytest.mark.parametrize("fruits, baskets, expected", [
    ([4,2,5], [3,5,4], 1), 
    ([3,6,1], [6,4,7], 0)
])
def test_numOfUnplacedFruits(fruits: List[int], baskets: List[int], expected: int):
    result = Solution().numOfUnplacedFruits(fruits, baskets)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 
