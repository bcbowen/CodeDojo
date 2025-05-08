import pytest
from typing import List
from functools import cache

class Solution:
    
    def mostPoints(self, questions: List[List[int]]) -> int:
        @cache
        def dp(i) -> int: 
            if i >= len(questions): 
                return 0
            
            j = i + questions[i][1] + 1
            return max(questions[i][0] + dp(j), dp(i + 1))
        
        return dp(0)

"""
Example 1:
Input: questions = [[3,2],[4,3],[4,4],[2,5]]
Output: 5
Explanation: The maximum points can be earned by solving questions 0 and 3.
- Solve question 0: Earn 3 points, will be unable to solve the next 2 questions
- Unable to solve questions 1 and 2
- Solve question 3: Earn 2 points
Total points earned: 3 + 2 = 5. There is no other way to earn 5 or more points.

Example 2:
Input: questions = [[1,1],[2,2],[3,3],[4,4],[5,5]]
Output: 7
Explanation: The maximum points can be earned by solving questions 1 and 4.
- Skip question 0
- Solve question 1: Earn 2 points, will be unable to solve the next 2 questions
- Unable to solve questions 2 and 3
- Solve question 4: Earn 5 points
Total points earned: 2 + 5 = 7. There is no other way to earn 7 or more points.
"""
@pytest.mark.parametrize("questions, expected", [
    ([[3,2],[4,3],[4,4],[2,5]], 5), 
    ([[1,1],[2,2],[3,3],[4,4],[5,5]], 7)
])
def test_mostPoints(questions: List[List[int]], expected: int):
    result = Solution().mostPoints(questions)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])