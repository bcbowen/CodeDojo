import pytest
import heapq
from typing import List

class Solution:
    def findRelativeRanks(self, score: List[int]) -> List[str]:
        score_heap = []
        result = [str(val) for val in score]
        for index, val in enumerate(score): 
            heapq.heappush(score_heap, (- val, index))

        if score_heap: 
            _, index = heapq.heappop(score_heap)
            result[index] = "Gold Medal"

        if score_heap: 
            _, index = heapq.heappop(score_heap)
            result[index] = "Silver Medal"

        if score_heap: 
            _, index = heapq.heappop(score_heap)
            result[index] = "Bronze Medal"
        
        place = 4
        while score_heap: 
            _, index = heapq.heappop(score_heap)
            result[index] = str(place)
            place += 1

        return result

"""
Example 1:

Input: score = [5,4,3,2,1]
Output: ["Gold Medal","Silver Medal","Bronze Medal","4","5"]
Explanation: The placements are [1st, 2nd, 3rd, 4th, 5th].

Example 2:

Input: score = [10,3,8,9,4]
Output: ["Gold Medal","5","Bronze Medal","Silver Medal","4"]
Explanation: The placements are [1st, 5th, 3rd, 2nd, 4th].
"""
@pytest.mark.parametrize("score, expected", [
    ([5,4,3,2,1], ["Gold Medal","Silver Medal","Bronze Medal","4","5"]), 
    ([10,3,8,9,4], ["Gold Medal","5","Bronze Medal","Silver Medal","4"])
])
def test_findRelativeRanks(score: List[int], expected: List[str]):
    result = Solution().findRelativeRanks(score)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])