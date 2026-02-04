import pytest

from collections import deque

class Solution:
    def reverseByType(self, s: str) -> str:
        letters = deque() 
        chars = deque()
        result = [c for c in s]
        for i, c in enumerate(s): 
            if c.isalpha(): 
                letters.append(i)
            else: 
                chars.append(i)
        
        while len(letters) > 1:  
            result[letters[0]], result[letters[-1]] = result[letters[-1]], result[letters[0]]
            letters.popleft()
            letters.pop()

        while len(chars) > 1: 
            result[chars[0]], result[chars[-1]] = result[chars[-1]], result[chars[0]]
            chars.popleft()
            chars.pop()
            
        return "".join(result)
    
"""
Example 1:
Input: s = ")ebc#da@f("

Output: "(fad@cb#e)"

Explanation:

The letters in the string are ['e', 'b', 'c', 'd', 'a', 'f']:
Reversing them gives ['f', 'a', 'd', 'c', 'b', 'e']
s becomes ")fad#cb@e("
​​​​​​​The special characters in the string are [')', '#', '@', '(']:
Reversing them gives ['(', '@', '#', ')']
s becomes "(fad@cb#e)"

Example 2:
Input: s = "z"

Output: "z"

Explanation:

The string contains only one letter, and reversing it does not change the string. There are no special characters.

Example 3:
Input: s = "!@#$%^&*()"

Output: ")(*&^%$#@!"

Explanation:
The string contains no letters. The string contains all special characters, so reversing the special characters reverses the whole string.

TC 656
s = "#zq"
Expected
"#qz"
"""
@pytest.mark.parametrize("s, expected", [
    (")ebc#da@f(", "(fad@cb#e)"), 
    ("z", "z"), 
    ("!@#$%^&*()", ")(*&^%$#@!"), 
    ("#zq", "#qz")
])
def test_reverseByType(s: str, expected: str):
    result = Solution().reverseByType(s)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])