import operator
import pytest
import heapq 
from typing import List
from collections import defaultdict

class Solution:
    def findLeastNumOfUniqueInts(self, arr: List[int], k: int) -> int:
        value_counts = defaultdict(int)
        for val in arr: 
            value_counts[val] += 1

        sorted_items =  sorted(value_counts.items(), key=operator.itemgetter(1), reverse=False)

        for index, item in enumerate(sorted_items): 
            if k >= item[1]: 
                k -= item[1]
            else: 
                return len(sorted_items) - index
        return 0




"""
Example 1:
Input: arr = [5,5,4], k = 1
Output: 1
Explanation: Remove the single 4, only 5 is left.

Example 2:
Input: arr = [4,3,1,1,3,3,2], k = 3
Output: 2
Explanation: Remove 4, 2 and either one of the two 1s or three 3s. 1 and 3 will be left.
"""        
@pytest.mark.parametrize("arr, k, expected", [
    ([5,5,4], 1, 1), 
    ([4,3,1,1,3,3,2], 3, 2), 
    ([1, 2, 3], 5, 0), 
    ([1, 2, 3, 4], 1, 3)
])
def test_findLeastNumOfUniqueInts(arr: List[int], k: int, expected: int):
    result = Solution().findLeastNumOfUniqueInts(arr, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])