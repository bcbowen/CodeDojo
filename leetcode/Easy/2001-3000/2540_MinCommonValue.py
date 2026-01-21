import pytest

class Solution:
    def getCommon(self, nums1: list[int], nums2: list[int]) -> int:
        i1 = 0
        i2 = 0
        while i1 < len(nums1) and i2 < len(nums2): 
            if nums1[i1] == nums2[i2]:
                return nums1[i1]
            elif nums1[i1] < nums2[i2]:
                i1 += 1
            else: 
                i2 += 1
        return -1 


"""
Example 1:
Input: nums1 = [1,2,3], nums2 = [2,4]
Output: 2
Explanation: The smallest element common to both arrays is 2, so we return 2.

Example 2:
Input: nums1 = [1,2,3,6], nums2 = [2,3,4,5]
Output: 2
Explanation: There are two common elements in the array 2 and 3 out of which 2 is the smallest, so 2 is returned.
"""

@pytest.mark.parametrize("nums1, nums2, expected", [
    ([1,2,3], [2, 4], 2),
    ([1,3,5], [2, 4, 6], -1),
    ([2, 4, 6], [1,3,5], -1),
    ([1,2,3,6], [2,3,4,5], 2),
    ([1,3,5,6], [2,4,6], 6),
    ([1,3,5,6], [6], 6),
    ([6], [1,3,5,6], 6)
])
def test_getCommon(nums1: list[int], nums2: list[int], expected: int):
    sol = Solution()
    result = sol.getCommon(nums1, nums2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])