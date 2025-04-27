import pytest

class Solution:
    def isStrobogrammatic(self, num: str) -> bool:
        matches = {'1': '1', '6': '9', '8': '8', '9': '6', '0': '0'}
        left = 0
        right = len(num) - 1

        while left <= right: 
            if not num[left] in matches: 
                return False
            elif not num[right] in matches: 
                return False
            elif matches[num[left]] != num[right]:
                return False 
            left += 1
            right -= 1    
        return True

"""
Example 1:
Input: num = "69"
Output: true

Example 2:
Input: num = "88"
Output: true

Example 3:
Input: num = "962"
Output: false
"""
@pytest.mark.parametrize("num, expected", [
    ("69", True), 
    ("88", True), 
    ("962", False)
])
def test_isStrobogrammatic(num: str, expected: bool):
    result = Solution().isStrobogrammatic(num)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])