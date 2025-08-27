import pytest
from typing import List



class Solution:
    def findShortestSubArray(self, nums: List[int]) -> int:
        # count, first, last
        counts = {} 
        max_degree = 1
        for i, num in enumerate(nums): 
            if not num in counts: 
                counts[num] = (1, i, i); 
            else: 
                count, first, _ = counts[num]
                count += 1
                counts[num] = (count, first, i)
                max_degree = max(max_degree, count)
        min_len = len(nums) + 1
        

        for num, info in counts.items(): 
            count, first, last = info
            if count == max_degree: 
                length = last - first + 1
                min_len = min(min_len, length)
        return min_len



"""
Example 1:
Input: nums = [1,2,2,3,1]
Output: 2
Explanation: 
The input array has a degree of 2 because both elements 1 and 2 appear twice.
Of the subarrays that have the same degree:
[1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
The shortest length is 2. So return 2.

Example 2:
Input: nums = [1,2,2,3,1,4,2]
Output: 6
Explanation: 
The degree is 3 because the element 2 is repeated 3 times.
So [2,2,3,1,4,2] is the shortest subarray, therefore returning 6.
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,2,3,1], 2), 
    ([2,2,3,1,4,2], 6)
])
def test_findShortestSubArray(nums: List[int], expected: int):
    result = Solution().findShortestSubArray(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])