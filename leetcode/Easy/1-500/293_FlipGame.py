import pytest
from typing import List, Tuple

class Solution:

    def generatePossibleNextMoves(self, currentState: str) -> List[str]:
        result = [] 
        def get_replacement(start, end) -> Tuple[bool, str]: 
            if currentState[start] == currentState[end] and currentState[start] == '+': 
                if start == 0: 
                    return (True, '--' + currentState[2:])
                else: 
                    return (True, currentState[0:start] + '--' + currentState[end + 1:])

            else: 
                return (False, "")

        if len(currentState) < 2: 
            return result
        for i in range(1, len(currentState)): 
            is_valid, new_string = get_replacement(i - 1, i)
            if is_valid: 
                result.append(new_string)
        return result



"""
Example 1:
Input: currentState = "++++"
Output: ["--++","+--+","++--"]

Example 2:
Input: currentState = "+"
Output: []
"""
@pytest.mark.parametrize("currentState, expected", [
    ("++++", ["--++","+--+","++--"]), 
    ("+", []), 
    ("--", [])
])
def test_generatePossibleNextMoves(currentState: str, expected: List[str]):
    result = Solution().generatePossibleNextMoves(currentState)
    assert(len(result) == len(expected))
    for state in result: 
        assert(state in expected)

if __name__ == "__main__": 
    pytest.main([__file__])