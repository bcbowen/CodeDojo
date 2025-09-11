import pytest

class Solution:
    def sortVowels(self, s: str) -> str:
        vowel_lookup = set(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'])
        letters = [c for c in s]
        indices = [] 
        vowels = [] 

        for i in range(len(letters)): 
            if letters[i] in vowel_lookup: 
                indices.append(i)
                vowels.append(ord(letters[i]))
        
        if len(indices) == 0: 
            return s
        
        vowels.sort()
        while len(vowels) > 0: 
            i = indices.pop()
            c = vowels.pop()
            letters[i] = chr(c)

        return "".join(letters)

"""
Example 1:
Input: s = "lEetcOde"
Output: "lEOtcede"
Explanation: 'E', 'O', and 'e' are the vowels in s; 'l', 't', 'c', and 'd' are all consonants. The vowels are sorted according to their ASCII values, and the consonants remain in the same places.

Example 2:
Input: s = "lYmpH"
Output: "lYmpH"
Explanation: There are no vowels in s (all characters in s are consonants), so we return "lYmpH".

"""
@pytest.mark.parametrize("s, expected", [
    ("lEetcOde", "lEOtcede"), 
    ("lYmpH", "lYmpH")
])
def test_sortVowels(s: str, expected: str):
    result = Solution().sortVowels(s)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])