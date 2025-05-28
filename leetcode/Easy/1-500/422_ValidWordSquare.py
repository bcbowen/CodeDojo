import pytest
from typing import List

class Solution:
    def validWordSquare(self, words: List[str]) -> bool:
        k = 0
        while k < len(words): 
            h = words[k]
            v = words[0][k]
            for i in range(1, len(words)): 
                if k < len(words[i]): 
                    v += words[i][k]
                else: 
                    break
            if h != v: 
                return False 
            k += 1
        return True

    
"""
Example 1:
Input: words = ["abcd","bnrt","crmy","dtye"]
Output: true
Explanation:
The 1st row and 1st column both read "abcd".
The 2nd row and 2nd column both read "bnrt".
The 3rd row and 3rd column both read "crmy".
The 4th row and 4th column both read "dtye".
Therefore, it is a valid word square.

Example 2:
Input: words = ["abcd","bnrt","crm","dt"]
Output: true
Explanation:
The 1st row and 1st column both read "abcd".
The 2nd row and 2nd column both read "bnrt".
The 3rd row and 3rd column both read "crm".
The 4th row and 4th column both read "dt".
Therefore, it is a valid word square.

Example 3:
Input: words = ["ball","area","read","lady"]
Output: false
Explanation:
The 3rd row reads "read" while the 3rd column reads "lead".
Therefore, it is NOT a valid word square.

TC 5: 
["ball","asee","let","lep"] 
True

"""
@pytest.mark.parametrize("words, expected", [
    (["abcd","bnrt","crmy","dtye"], True), 
    (["abcd","bnrt","crm","dt"], True), 
    (["ball","area","read","lady"], False), 
    (["ball","asee","let","lep"], False)
])
def test_validWordSquare(words: List[str], expected: bool):
    result = Solution().validWordSquare(words)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])