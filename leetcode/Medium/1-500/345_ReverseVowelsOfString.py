import pytest

class Solution:
    def reverseVowels(self, s: str) -> str:
        vowelLocations = [] 
        vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'}
        letters = [] 
        for i, c in enumerate(s): 
            if c in vowels: 
                vowelLocations.append((i, c))
            letters.append(c)
        left = 0
        right = len(vowelLocations) - 1
        while left <= right: 
            lIndex, lChar = vowelLocations[left]
            rIndex, rChar = vowelLocations[right]
            letters[lIndex] = rChar
            letters[rIndex] = lChar
            left += 1
            right -= 1
        return "".join(letters)
        

"""
Example 1:
Input: s = "IceCreAm"
Output: "AceCreIm"
Explanation:
The vowels in s are ['I', 'e', 'e', 'A']. On reversing the vowels, s becomes "AceCreIm".

Example 2:
Input: s = "leetcode"
Output: "leotcede"
"""
@pytest.mark.parametrize("s, expected", [
    ("IceCreAm", "AceCreIm"), 
    ("leetcode", "leotcede")
])
def test_reverseVowels(s: str, expected: str):
    result = Solution().reverseVowels(s)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])