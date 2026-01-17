import pytest

class Solution:
    def residuePrefixes_1(self, s: str) -> int:
        return len(set(s))
    
    def residuePrefixes(self, s: str) -> int:
        chars = set() 
        result = 0
        for i, c in enumerate(s): 
            chars.add(c)
            m = (i + 1) % 3
            if m == len(chars): 
                result += 1


        return result
    

"""
Example 1:
Input: s = "abc"

Output: 2

Explanation:​​​​​​​

Prefix "a" has 1 distinct character and length modulo 3 is 1, so it is a residue.
Prefix "ab" has 2 distinct characters and length modulo 3 is 2, so it is a residue.
Prefix "abc" does not satisfy the condition. Thus, the answer is 2.

Example 2:
Input: s = "dd"

Output: 1

Explanation:

Prefix "d" has 1 distinct character and length modulo 3 is 1, so it is a residue.
Prefix "dd" has 1 distinct character but length modulo 3 is 2, so it is not a residue. Thus, the answer is 1.

Example 3:
Input: s = "bob"

Output: 2

Explanation:

Prefix "b" has 1 distinct character and length modulo 3 is 1, so it is a residue.
Prefix "bo" has 2 distinct characters and length mod 3 is 2, so it is a residue. Thus, the answer is 2.
"""
@pytest.mark.parametrize("s, expected", [
    ("abc", 2), 
    ("dd", 1), 
    ("bob", 2), 
    ("kl", 2)
])
def test_residuePrefixes(s: str, expected: int):
    result = Solution().residuePrefixes(s)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 