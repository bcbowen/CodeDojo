import pytest

class Solution:
    def checkIfPangram(self, sentence: str) -> bool:
        letters = set()
        for c in sentence: 
            letters.add(c)

        for i in range(97, 123):
             if not chr(i) in letters: 
                  return False
        return True 
"""
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.

Example 2:
Input: sentence = "leetcode"
Output: false
"""
@pytest.mark.parametrize("sentence, expected", [
     ("thequickbrownfoxjumpsoverthelazydog", True), 
     ("leetcode", False)
])
def test_checkIfPangram(sentence: str, expected: bool):
        sol = Solution() 
        result = sol.checkIfPangram(sentence)
        assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])