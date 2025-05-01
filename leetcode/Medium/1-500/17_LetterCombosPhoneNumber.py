import pytest
from typing import List

class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        result = []
        if not digits: 
            return result
        
        phone_keys = {
            2: ['a', 'b', 'c'], 
            3: ['d', 'e', 'f'], 
            4: ['g', 'h', 'i'], 
            5: ['j', 'k', 'l'], 
            6: ['m', 'n', 'o'], 
            7: ['p', 'q', 'r', 's'], 
            8: ['t', 'u', 'v'], 
            9: ['w', 'x', 'y', 'z'], 
        }
        def backtrack(index: int, combo: str): 
            if len(combo) == len(digits): 
                result.append(combo)
                return
            digit = int(digits[index])
            for c in phone_keys[digit]:
                backtrack(index + 1, combo + c)
        backtrack(0, "")
        return result

"""
Example 1:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Example 2:
Input: digits = ""
Output: []

Example 3:
Input: digits = "2"
Output: ["a","b","c"]
"""
@pytest.mark.parametrize("digits, expected", [
    ("23", ["ad","ae","af","bd","be","bf","cd","ce","cf"]), 
    ("", []), 
    ("2", ["a","b","c"])
])
def test_letterCombinations(digits: str, expected: List[str]):
    result = Solution().letterCombinations(digits)
    assert(len(expected) == len(result))
    for combo in result: 
        assert(combo in expected)

if __name__ == "__main__":
    pytest.main([__file__]) 