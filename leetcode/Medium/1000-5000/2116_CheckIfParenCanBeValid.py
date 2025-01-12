import pytest

"""
Example 1:
Input: s = "))()))", locked = "010100"
Output: true
Explanation: locked[1] == '1' and locked[3] == '1', so we cannot change s[1] or s[3].
We change s[0] and s[4] to '(' while leaving s[2] and s[5] unchanged to make s valid.

Example 2:
Input: s = "()()", locked = "0000"
Output: true
Explanation: We do not need to make any changes because s is already valid.

Example 3:
Input: s = ")", locked = "0"
Output: false
Explanation: locked permits us to change s[0]. 
Changing s[0] to either '(' or ')' will not make s valid.
"""

class Solution:
    def canBeValid(self, s: str, locked: str) -> bool:
        if len(s) % 2 == 1: 
            return False
        if self.isValid(s): 
            return True
        unlocked = [] 
        open = []
        
        for i, c in enumerate(s): 
            if locked[i] == '0': 
                unlocked.append(i)
            elif c == '(': 
                open.append(i)
            elif len(open) > 0:
                open.pop()
            elif len(unlocked) > 0: 
                unlocked.pop()
            else: 
                return False 
        while len(open) > 0 and len(unlocked) > 0 and open[-1] < unlocked[-1]: 
            open.pop()
            unlocked.pop()

        if len(open) > 0: 
            return False
        return True

    def isValid(self, val: str): 
        parens = [] 
        for c in val: 
            if c == '(': 
                parens.append(c)
            else: 
                if len(parens) == 0: 
                    return False
                parens.pop()
        return len(parens) == 0
"""
"())(()(()(())()())(())((())(()())((())))))(((((((())(()))))("
locked =
"100011110110011011010111100111011101111110000101001101001111"

"""

@pytest.mark.parametrize("val, locked, expected", [
    ("))()))", "010100", True),
    ("()()", "0000", True),
    (")", "0", False), 
    ("())(()(()(())()())(())((())(()())((())))))(((((((())(()))))(", "100011110110011011010111100111011101111110000101001101001111", False)
])
def test_canBeValid(val : str, locked: str, expected: bool):
    solution = Solution()
    result = solution.canBeValid(val, locked)
    assert(result == expected) 

def test_troubleshooting(): 
    val = "())(()(()(())()())(())((())(()())((())))))(((((((())(()))))("
    locked = "100011110110011011010111100111011101111110000101001101001111"
    expected = False
    solution = Solution() 
    result = solution.canBeValid(val, locked) 
    assert(result == expected)

@pytest.mark.parametrize("val, expected", [
    ("(", False),
    (")", False),
    ("((", False),
    ("())", False),
    ("()(", False),
    ("()", True),
    ("(())", True),
    ("()()", True),
    ("(()(((())))())", True), 
    ("())(()(()(())()())(())((())(()())((())))))(((((((())(()))))(", False)
])
def test_isValid(val: str, expected: bool): 
    solution = Solution() 
    result = solution.isValid(val)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])