import pytest

class Solution:
    def isSubsequence(self, s: str, t: str) -> bool:
        if len(s) == 0: 
            return True
        elif len(s) > len(t): 
            return False
        elif len(s) == len(t):
             return s == t
        
        si = 0 
        ti = 0

        while si < len(s) and ti < len(t): 
            if s[si] == t[ti]: 
                si += 1
                ti += 1
                if si == len(s): 
                    return True
            else: 
                ti += 1    
            
        return False

        


"""
Example 1:
Input: s = "abc", t = "ahbgdc"
Output: true

Example 2:
Input: s = "axc", t = "ahbgdc"
Output: false

"""
@pytest.mark.parametrize("test_val, val, expected", [
    ("bb", "ahbgdc", False),
    ("", "ahbgdc", True),
    ("acb", "ahbgdc", False),
    ("abc", "ahbgdc", True), 
    ("axc", "ahbgdc", False),
    ("abc", "ahxgdcahbgdc", True),
    ("abc", "shitbirdahbgdc", True)
])
def test_isSubsequence(test_val: str, val: str, expected: bool): 
    solution = Solution()
    result = solution.isSubsequence(test_val, val)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])