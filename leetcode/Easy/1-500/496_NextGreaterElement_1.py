import pytest

class Solution:
    def nextGreaterElement(self, nums1: list[int], nums2: list[int]) -> list[int]:
        stack = [] 
        next_element_map = {} 
        for i in nums2: 
            while stack and i > stack[-1]: 
                next_element_map[stack.pop()] = i
            stack.append(i)
        result = [0] * len(nums1)
        for i, v in enumerate(nums1): 
            if v in next_element_map: 
                result[i] = next_element_map[v]
            else: 
                result[i] = -1
        
        return result

"""
Example 1:
Input: nums1 = [4,1,2], nums2 = [1,3,4,2]
Output: [-1,3,-1]
Explanation: The next greater element for each value of nums1 is as follows:
- 4 is underlined in nums2 = [1,3,4,2]. There is no next greater element, so the answer is -1.
- 1 is underlined in nums2 = [1,3,4,2]. The next greater element is 3.
- 2 is underlined in nums2 = [1,3,4,2]. There is no next greater element, so the answer is -1.

Example 2:
Input: nums1 = [2,4], nums2 = [1,2,3,4]
Output: [3,-1]
Explanation: The next greater element for each value of nums1 is as follows:
- 2 is underlined in nums2 = [1,2,3,4]. The next greater element is 3.
- 4 is underlined in nums2 = [1,2,3,4]. There is no next greater element, so the answer is -1.
"""
@pytest.mark.parametrize("nums1, nums2, expected", [
    ([4,1,2], [1,3,4,2], [-1,3,-1]), 
    ([2,4], [1,2,3,4], [3,-1])
])
def test_nextGreaterElement(nums1: list[int], nums2: list[int], expected: list[int]):
    sol = Solution()
    result = sol.nextGreaterElement(nums1, nums2)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])