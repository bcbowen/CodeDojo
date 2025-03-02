import pytest

class Solution:
    def mergeArrays(self, nums1: list[list[int]], nums2: list[list[int]]) -> list[list[int]]:
        result = []
        i = 0
        j = 0
        while i < len(nums1) or j < len(nums2): 
            if i < len(nums1) and j < len(nums2) and nums1[i][0] == nums2[j][0]: 
                result.append([nums1[i][0], nums1[i][1] + nums2[j][1]])
                i += 1
                j += 1
            elif i < len(nums1) and (j >= len(nums2) or nums1[i] < nums2[j]): 
                result.append(nums1[i].copy())
                i += 1
            else: 
                result.append(nums2[j].copy())
                j += 1
        return result

"""
Example 1:
Input: nums1 = [[1,2],[2,3],[4,5]], nums2 = [[1,4],[3,2],[4,1]]
Output: [[1,6],[2,3],[3,2],[4,6]]
Explanation: The resulting array contains the following:
- id = 1, the value of this id is 2 + 4 = 6.
- id = 2, the value of this id is 3.
- id = 3, the value of this id is 2.
- id = 4, the value of this id is 5 + 1 = 6.

Example 2:
Input: nums1 = [[2,4],[3,6],[5,5]], nums2 = [[1,3],[4,3]]
Output: [[1,3],[2,4],[3,6],[4,3],[5,5]]
Explanation: There are no common ids, so we just include each id with its value in the resulting list.
"""
@pytest.mark.parametrize("nums1, nums2, expected", [
    ([[1,2],[2,3],[4,5]], [[1,4],[3,2],[4,1]], [[1,6],[2,3],[3,2],[4,6]]), 
    ([[2,4],[3,6],[5,5]], [[1,3],[4,3]], [[1,3],[2,4],[3,6],[4,3],[5,5]])
])
def test_mergeArrays(nums1: list[list[int]], nums2: list[list[int]], expected: list[list[int]]):
    result = Solution().mergeArrays(nums1, nums2)
    assert(result == expected)
    

if __name__ == "__main__":
    pytest.main([__file__]) 