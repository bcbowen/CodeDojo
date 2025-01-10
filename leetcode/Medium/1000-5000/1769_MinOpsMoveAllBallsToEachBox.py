import pytest

"""
Example 1:
Input: boxes = "110"
Output: [1,1,3]
Explanation: The answer for each box is as follows:
1) First box: you will have to move one ball from the second box to the first box in one operation.
2) Second box: you will have to move one ball from the first box to the second box in one operation.
3) Third box: you will have to move one ball from the first box to the third box in two operations, and move one ball from the second box to the third box in one operation.

Example 2:
Input: boxes = "001011"
Output: [11,8,5,4,3,4]
 

Constraints:

n == boxes.length
1 <= n <= 2000
boxes[i] is either '0' or '1'.
"""
class Solution:
    def minOperations(self, boxes: str) -> list[int]:
        on_list = [i for i, c in enumerate(boxes) if c == '1']
        result = [0] * len(boxes)
        for i in range(len(boxes)):
            for j in on_list: 
                result[i] += abs(i - j)
        return result
    
    def minOperations2(self, boxes: str) -> list[int]:
        balls_left = 0
        moves_left = 0
        balls_right = 0
        moves_right = 0
        
        result = [0] * len(boxes)

        n = len(boxes)
        for i in range(n): 
            result[i] += moves_left
            balls_left += int(boxes[i])
            moves_left += balls_left

            j = n - 1 - i
            result[j] += moves_right
            balls_right += int(boxes[j])
            moves_right += balls_right
            

        return result
        

@pytest.mark.parametrize("boxes, expected", [
    ("110", [1,1,3]),
    ("001011", [11,8,5,4,3,4])
])
def test_minOperations(boxes: str, expected: list[int]): 
    s = Solution()

    result = s.minOperations(boxes)
    assert(result == expected)

@pytest.mark.parametrize("boxes, expected", [
    ("110", [1,1,3]),
    ("001011", [11,8,5,4,3,4])
])
def test_minOperations2(boxes: str, expected: list[int]): 
    s = Solution()

    result = s.minOperations(boxes)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])