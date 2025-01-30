import pytest

class Solution:
    def reverseOnlyLetters(self, s: str) -> str:
        pass
"""
Example 1:
Input: s = "ab-cd"
Output: "dc-ba"

Example 2:
Input: s = "a-bC-dEf-ghIj"
Output: "j-Ih-gfE-dCba"

Example 3:
Input: s = "Test1ng-Leet=code-Q!"
Output: "Qedo1ct-eeLg=ntse-T!"
"""
@pytest.mark.parametrize("val, expected", [
    ("ab-cd", "dc-ba"),
    ("a-bC-dEf-ghIj", "j-Ih-gfE-dCba"),
    ("Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!")
])
def test_reverseOnlyLetters(val: str, expected: str): 
    sol = Solution()
    result = sol.reverseOnlyLetters(val, expected)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])