

import pytest


class Solution:
    def removeOuterParentheses(self, s: str) -> str:
        ct = 0
        output = [] 
        for c in s: 
            if c == '(' and ct > 0: 
                output.append(c)
            elif c == ')' and ct > 1: 
                output.append(c)
            
            if c == '(': 
                ct += 1
            else: 
                ct -= 1

        return ''.join(output)
        
    def removeOuterParentheses_1(self, s: str) -> str:
        ct = 0
        output = [] 
        for c in s: 
            if c == '(': 
                ct += 1
                if ct == 2:
                    output.append(c)
            else: 
                ct -= 1
                if ct == 1: 
                    output.append(c)
        return ''.join(output)
            

"""
Example 1:
Input: s = "(()())(())"
Output: "()()()"
Explanation: 
The input string is "(()())(())", with primitive decomposition "(()())" + "(())".
After removing outer parentheses of each part, this is "()()" + "()" = "()()()".

Example 2:
Input: s = "(()())(())(()(()))"
Output: "()()()()(())"
Explanation: 
The input string is "(()())(())(()(()))", with primitive decomposition "(()())" + "(())" + "(()(()))".
After removing outer parentheses of each part, this is "()()" + "()" + "()(())" = "()()()()(())".

Example 3:
Input: s = "()()"
Output: ""
Explanation: 
The input string is "()()", with primitive decomposition "()" + "()".
After removing outer parentheses of each part, this is "" + "" = "".
"""
@pytest.mark.parametrize("s, expected", [
    ("(()())(())", "()()()"),
    ("(()())(())(()(()))", "()()()()(())"),
    ("()()", "")
])
def test_removeOuterParentheses(s: str, expected: str):
    result = Solution().removeOuterParentheses(s)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 
