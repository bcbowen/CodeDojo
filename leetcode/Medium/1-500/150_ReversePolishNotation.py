#from collections import deque
from typing import List
import pytest

class Solution:
    def evalRPN(self, tokens: List[str]) -> int:
        stack = []
        for t in tokens: 
            if len(t) > 1 and t.startswith('-'): 
                stack.append(-(int(t[1:])))
            elif t.isnumeric(): 
                stack.append(int(t))
            else: 
                subval = -1
                d2 = stack.pop()
                d1 = stack.pop() 
                match t: 
                    case '+':        
                        subval = d1 + d2
                    case '-': 
                        subval = d1 - d2
                    case '*': 
                        subval = d1 * d2
                    case '/':
                        subval = int(d1 / d2)

                stack.append(subval)
        return stack.pop()
"""
Example 1:
Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9

Example 2:
Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6

Example 3:
Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 17 + 5
= 22

TC7: 
tokens: ["4", "3", "-"]
expected: 1
"""
@pytest.mark.parametrize("tokens, expected", [
    (["4", "3", "-"], 1),
    (["2","1","+","3","*"], 9), 
    (["4","13","5","/","+"], 6), 
    (["10","6","9","3","+","-11","*","/","*","17","+","5","+"], 22)
])
def test_evalRPN(tokens: List[str], expected: int):
    result = Solution().evalRPN(tokens)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 