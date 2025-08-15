import pytest

class Solution:

    def validPalindrome(self, s: str) -> bool:
        def check_palindrome(s: str, can_replace: bool) -> bool: 
            i = 0
            j = len(s) - 1
            while i < j: 
                if s[i] != s[j]: 
                    if not can_replace: 
                        return False
                    if s[i + 1] == s[j]: 
                        if check_palindrome(s[i + 1: j + 1], False):
                            return True
                    if s[i] == s[j - 1]: 
                        if check_palindrome(s[i : j], False):
                            return True
                    return False  
                            
                i += 1
                j -= 1

            return True
        
        return check_palindrome(s, True)
    

"""
Example 1:
Input: s = "aba"
Output: true

Example 2:
Input: s = "abca"
Output: true
Explanation: You could delete the character 'c'.

Example 3:
Input: s = "abc"
Output: false

TC 275 "eedede": True
"""
@pytest.mark.parametrize("s, expected", [
    ("aba", True),
    ("abca", True), 
    ("abc", False), 
    ("eedede", True) 

])
def test_validPalindrome(s: str, expected: bool):
    result = Solution().validPalindrome(s)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])