import pytest

class Solution:
    def reverseStr(self, s: str, k: int) -> str:
        sections = []
        for i in range(0, len(s), 2 * k): 
            sections.append(s[i : i + k][::-1])
            sections.append(s[i + k : i + 2 * k])
            
        return ''.join(sections)
    
"""
Example 1:
Input: s = "abcdefg", k = 2
Output: "bacdfeg"

Example 2:
Input: s = "abcd", k = 2
Output: "bacd"
"""
@pytest.mark.parametrize("s, k, expected", [
    ("abcdefg", 2, "bacdfeg"), 
    ("abcd", 2, "bacd")
])
def test_reverseStr(s: str, k: int, expected: str):
    result = Solution().reverseStr(s, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])