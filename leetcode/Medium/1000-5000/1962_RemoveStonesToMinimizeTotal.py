import heapq
import pytest
from typing import List

class Solution:
    def minStoneSum(self, piles: List[int], k: int) -> int:
        piles = [-pile for pile in piles]
        heapq.heapify(piles)
        for _ in range(k): 
            val = heapq.heappop(piles)
            heapq.heappush(piles, val//2)

        return -sum(piles) 

"""
Example 1:
Input: piles = [5,4,9], k = 2
Output: 12
Explanation: Steps of a possible scenario are:
- Apply the operation on pile 2. The resulting piles are [5,4,5].
- Apply the operation on pile 0. The resulting piles are [3,4,5].
The total number of stones in [3,4,5] is 12.

Example 2:
Input: piles = [4,3,6,7], k = 3
Output: 12
Explanation: Steps of a possible scenario are:
- Apply the operation on pile 2. The resulting piles are [4,3,3,7].
- Apply the operation on pile 3. The resulting piles are [4,3,3,4].
- Apply the operation on pile 0. The resulting piles are [2,3,3,4].
The total number of stones in [2,3,3,4] is 12.
"""
@pytest.mark.parametrize("piles, k, expected", [
    ([5,4,9], 2, 12), 
    ([4,3,6,7], 3, 12)
])
def test_minStoneSum(piles: List[int], k: int, expected: int):
    result = Solution().minStoneSum(piles, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])