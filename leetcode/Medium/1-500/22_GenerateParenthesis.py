import pytest
from typing import List

class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        result = []
        if n == 0: 
            return result

        def is_valid(parens: str) -> bool: 
            i = 0 
            for c in parens: 
                if c == '(': 
                    i += 1
                else: 
                    i -= 1
                if i < 0: 
                    return False
            return i == 0
        
        def backtrack(opens: int, parens: str): 
            if len(parens) == 2 * n:
                if (is_valid(parens)):  
                    result.append(parens)
                return
            if opens < n: 
                backtrack(opens + 1, parens + '(')
            if opens > 0: 
                backtrack(opens - 1, parens + ')')

        backtrack(0, '')
        return result

"""
Example 1:
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:
Input: n = 1
Output: ["()"]
"""
@pytest.mark.parametrize("n, expected", [
    (3, ["((()))","(()())","(())()","()(())","()()()"]), 
    (1, ["()"])
])
def test_generateParenthesis(n: int, expected: List[str]):
    result = Solution().generateParenthesis(n)
    assert(len(result) == len(expected))
    for item in result: 
        assert(item in expected)

if __name__ == "__main__":
    pytest.main([__file__]) 