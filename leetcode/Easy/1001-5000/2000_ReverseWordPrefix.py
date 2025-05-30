import pytest

class Solution:
    def reversePrefix(self, word: str, ch: str) -> str:
        letters = list(word)
        left = 0
        right = 0
        while right < len(letters): 
             if letters[right] == ch: 
                  while left < right: 
                       letters[left], letters[right] = letters[right], letters[left]
                       left += 1
                       right -= 1
                  break
             right += 1
        return "".join(letters)

"""
Example 1:
Input: word = "abcdefd", ch = "d"
Output: "dcbaefd"
Explanation: The first occurrence of "d" is at index 3. 
Reverse the part of word from 0 to 3 (inclusive), the resulting string is "dcbaefd".

Example 2:
Input: word = "xyxzxe", ch = "z"
Output: "zxyxxe"
Explanation: The first and only occurrence of "z" is at index 3.
Reverse the part of word from 0 to 3 (inclusive), the resulting string is "zxyxxe".
"""
@pytest.mark.parametrize("word, ch, expected", [
     ("abcdefd", 'd', "dcbaefd"),
     ("xyxzxe", 'z', "zxyxxe")
])
def test_reversePrefix(word: str, ch: str, expected: str):
        sol = Solution()
        result = sol.reversePrefix(word, ch)
        assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 