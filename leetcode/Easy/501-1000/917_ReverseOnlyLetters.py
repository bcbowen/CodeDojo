import pytest

class Solution:
    def reverseOnlyLetters(self, val: str) -> str:
        letters = list(val)
        
        left = 0
        
        val_len = len(letters)
        right = val_len - 1

        while left < right:
            while left < val_len and not letters[left].isalpha(): 
                left += 1
            while right > 0 and not letters[right].isalpha():
                right -= 1
            if left < right: 
                letters[left], letters[right] = letters[right], letters[left]
            left += 1
            right -= 1
        return "".join(letters) 
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

s =
"7_28]"

Expected
"7_28]"

"""
@pytest.mark.parametrize("val, expected", [
    ("abcd", "dcba"), 
    ("abcde", "edcba"),
    ("ab-cd", "dc-ba"),
    ("a-bC-dEf-ghIj", "j-Ih-gfE-dCba"),
    ("Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!"),
    ("7_28]", "7_28]")
])
def test_reverseOnlyLetters(val: str, expected: str): 
    sol = Solution()
    result = sol.reverseOnlyLetters(val)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])