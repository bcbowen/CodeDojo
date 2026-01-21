import pytest

class Solution:
    def kthCharacter(self, k: int) -> str:
        def get_next(c: str) -> str: 
            if c == 'z': 
                return 'a'
            return chr(ord(c) + 1)
        word = ['a']
        while len(word) < k:
            current_len = len(word)
            for i in range(current_len): 
                word.append(get_next(word[i]))
        return word[k - 1]  

"""
Example 1:

Input: k = 5

Output: "b"

Explanation:

Initially, word = "a". We need to do the operation three times:

Generated string is "b", word becomes "ab".
Generated string is "bc", word becomes "abbc".
Generated string is "bccd", word becomes "abbcbccd".
Example 2:

Input: k = 10

Output: "c"
"""
@pytest.mark.parametrize("k, expected", [
    (5, 'b'), 
    (10, 'c')
])
def test_kthCharacter(k: int, expected: str):
    result = Solution().kthCharacter(k)
    assert(result == expected) 


if __name__ == "__main__":
    pytest.main([__file__])