import pytest
from typing import List

class Solution:
    """
    An integer x.
    Record a new score of x.
    '+'.
    Record a new score that is the sum of the previous two scores.
    'D'.
    Record a new score that is the double of the previous score.
    'C'.
    Invalidate the previous score, removing it from the record.
    """
    def calPoints(self, operations: List[str]) -> int:
        scores : List[int] = [] 

        for op in operations: 

            if op == '+': 
                scores.append(scores[-1] + scores[-2])
            elif op == 'D':
                scores.append(scores[-1] * 2)
            elif op == 'C':
                scores.pop() 
            else: 
                scores.append(int(op))
            

        return sum(scores)
    

"""
Example 1:
Input: ops = ["5","2","C","D","+"]
Output: 30
Explanation:
"5" - Add 5 to the record, record is now [5].
"2" - Add 2 to the record, record is now [5, 2].
"C" - Invalidate and remove the previous score, record is now [5].
"D" - Add 2 * 5 = 10 to the record, record is now [5, 10].
"+" - Add 5 + 10 = 15 to the record, record is now [5, 10, 15].
The total sum is 5 + 10 + 15 = 30.

Example 2:
Input: ops = ["5","-2","4","C","D","9","+","+"]
Output: 27
Explanation:
"5" - Add 5 to the record, record is now [5].
"-2" - Add -2 to the record, record is now [5, -2].
"4" - Add 4 to the record, record is now [5, -2, 4].
"C" - Invalidate and remove the previous score, record is now [5, -2].
"D" - Add 2 * -2 = -4 to the record, record is now [5, -2, -4].
"9" - Add 9 to the record, record is now [5, -2, -4, 9].
"+" - Add -4 + 9 = 5 to the record, record is now [5, -2, -4, 9, 5].
"+" - Add 9 + 5 = 14 to the record, record is now [5, -2, -4, 9, 5, 14].
The total sum is 5 + -2 + -4 + 9 + 5 + 14 = 27.

Example 3:
Input: ops = ["1","C"]
Output: 0
Explanation:
"1" - Add 1 to the record, record is now [1].
"C" - Invalidate and remove the previous score, record is now [].
Since the record is empty, the total sum is 0.   
"""
@pytest.mark.parametrize("operations, expected", [
    (["5","2","C","D","+"], 30),
    (["5","-2","4","C","D","9","+","+"], 27), 
    (["1","C"], 0) 
])
def test_calPoints(operations: List[str], expected: int):
    result = Solution().calPoints(operations);
    assert(result == expected) 

if __name__ == "__main__":
    pytest.main([__file__]) 