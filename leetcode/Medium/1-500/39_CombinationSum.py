import pytest

"""
Example 1:
Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.

Example 2:
Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]

Example 3:
Input: candidates = [2], target = 1
Output: []
"""

class Solution:
    def combinationSum(self, candidates: list[int], target: int) -> list[list[int]]:
        return self.backtrack([], [], candidates, target)
    
    def backtrack(self, combos: list[list[int]], combo: list[int], candidates: list[int], target): 
        total = sum(combo)
        if total > target: 
            return
        if sum(combo) == target: 
            combos.append(combo)
        
        

@pytest.mark.parametrize("candidates, target, expected", [
    ([2,3,6,7], 7, [[2,2,3],[7]]), 
    ([2,3,5], 8, [[2,2,2,2],[2,3,3],[3,5]]),
    ([2], 1, [])
])
def test_combinationSum(candidates: list[int], target: int, expected: list[list[int]]): 
    solution = Solution()
    result = solution.combinationSum(candidates, target)
    assert(result == expected)

pytest.main([__file__])