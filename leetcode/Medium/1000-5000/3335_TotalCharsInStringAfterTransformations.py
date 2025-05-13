import pytest

class Solution:
    def lengthAfterTransformations(self, s: str, t: int) -> int:
        letters = [0] * 27
        for c in s: 
            letters[ord(c) - 96] += 1

        for _ in range(t):
            a = letters[26]
            b = letters[26]
            for i in range(25, -1, -1):
                letters[i + 1] = letters[i]
            letters[1] = a
            letters[2] += b
            
        return sum(letters) % (10**9 + 7)

        
"""
Example 1:

Input: s = "abcyy", t = 2

Output: 7

Explanation:

First Transformation (t = 1):
'a' becomes 'b'
'b' becomes 'c'
'c' becomes 'd'
'y' becomes 'z'
'y' becomes 'z'
String after the first transformation: "bcdzz"
Second Transformation (t = 2):
'b' becomes 'c'
'c' becomes 'd'
'd' becomes 'e'
'z' becomes "ab"
'z' becomes "ab"
String after the second transformation: "cdeabab"
Final Length of the string: The string is "cdeabab", which has 7 characters.

Example 2:
Input: s = "azbk", t = 1

Output: 5

Explanation:

First Transformation (t = 1):
'a' becomes 'b'
'z' becomes "ab"
'b' becomes 'c'
'k' becomes 'l'
String after the first transformation: "babcl"
Final Length of the string: The string is "babcl", which has 5 characters.
"""
@pytest.mark.parametrize("s, t, expected", [
    ("abcyy", 2, 7), 
    ("azbk", 1, 5), 
    ("jqktcurgdvlibczdsvnsg", 7517, 79033769)
])
def test_lengthAfterTransformations(s: str, t: int, expected: int):
    result = Solution().lengthAfterTransformations(s, t)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 