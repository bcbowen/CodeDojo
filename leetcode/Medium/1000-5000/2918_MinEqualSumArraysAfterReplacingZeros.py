import pytest
from typing import List

class Solution:
    def minSum(self, nums1: List[int], nums2: List[int]) -> int:
        def get_sum(nums : List[int]) -> int: 
            val = 0
            for num in nums: 
                if num == 0: 
                    val += 1
                else: 
                    val += num
            return val
        
        s1 = get_sum(nums1)
        s2 = get_sum(nums2)

        if s1 == s2: 
            return s1
        elif s1 > s2: 
            return s1 if 0 in nums2 else -1
        else: 
            return s2 if 0 in nums1 else -1



"""
Example 1:
Input: nums1 = [3,2,0,1,0], nums2 = [6,5,0]
Output: 12
Explanation: We can replace 0's in the following way:
- Replace the two 0's in nums1 with the values 2 and 4. The resulting array is nums1 = [3,2,2,1,4].
- Replace the 0 in nums2 with the value 1. The resulting array is nums2 = [6,5,1].
Both arrays have an equal sum of 12. It can be shown that it is the minimum sum we can obtain.

Example 2:
Input: nums1 = [2,0,2,0], nums2 = [1,4]
Output: -1
Explanation: It is impossible to make the sum of both arrays equal.

TC 633: 
nums1 =
[8,13,15,18,0,18,0,0,5,20,12,27,3,14,22,0]
nums2 =
[29,1,6,0,10,24,27,17,14,13,2,19,2,11]
expected = 179
"""
@pytest.mark.parametrize("nums1, nums2, expected", [
    ([3,2,0,1,0], [6,5,0], 12), 
    ([2,0,2,0], [1,4], -1), 
    ([1, 4, 0, 0],[5, 0, 0], 7), 
    ([8,13,15,18,0,18,0,0,5,20,12,27,3,14,22,0], [29,1,6,0,10,24,27,17,14,13,2,19,2,11], 179)
])
def test_minSum(nums1: List[int], nums2: List[int], expected: int):
    result = Solution().minSum(nums1, nums2)
    assert(result == expected)



if __name__ == "__main__":
    pytest.main([__file__])
