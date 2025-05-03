import pytest
from typing import List

class Solution:
    def numsSameConsecDiff(self, n: int, k: int) -> List[int]:
        result = [] 
        
        def backtrack(s: str):
            if len(s) == n: 
                if not int(s) in result:
                    result.append(int(s))
                return
            if len(s) == 0: 
                for i in range(1, 10): 
                    backtrack(str(i))
            else: 
                i = int(s[-1])
                val = i - k
                if val >= 0: 
                    backtrack(s + str(val))
                val = i + k
                if val <= 9: 
                    backtrack(s + str(val)) 

        backtrack("")
        return result


"""
Example 1:
Input: n = 3, k = 7
Output: [181,292,707,818,929]
Explanation: Note that 070 is not a valid number, because it has leading zeroes.

Example 2:
Input: n = 2, k = 1
Output: [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]
"""
@pytest.mark.parametrize("n, k, expected", [
     (3, 7, [181,292,707,818,929]), 
     (2, 1, [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]), 
     (2, 0, [11,22,33,44,55,66,77,88,99])
])
def test_numsSameConsecDiff(n: int, k: int, expected: List[int]):
    result = Solution().numsSameConsecDiff(n, k)
    assert(len(result) == len(expected))
    for num in result: 
        assert(num in expected)
    

if __name__ == "__main__": 
    pytest.main([__file__])