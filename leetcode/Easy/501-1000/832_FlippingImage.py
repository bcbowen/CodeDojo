import pytest
from typing import List

class Solution:
    def flipAndInvertImage(self, image: List[List[int]]) -> List[List[int]]:
        result = [] 
        for row in image: 
            result.append(row[::-1])

        for row in range(len(result)):
            for col in range(len(result[row])): 
                result[row][col] = 1 if result[row][col] == 0 else 0 
        

        return result

"""
Example 1:
Input: image = [[1,1,0],[1,0,1],[0,0,0]]
Output: [[1,0,0],[0,1,0],[1,1,1]]
Explanation: First reverse each row: [[0,1,1],[1,0,1],[0,0,0]].
Then, invert the image: [[1,0,0],[0,1,0],[1,1,1]]

Example 2:
Input: image = [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
Output: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
Explanation: First reverse each row: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]].
Then invert the image: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
"""
@pytest.mark.parametrize("image, expected", [
    ([[1,1,0],[1,0,1],[0,0,0]], [[1,0,0],[0,1,0],[1,1,1]]), 
    ([[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]], [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]])
])
def test_flipAndInvertImage(image: List[List[int]], expected: List[List[int]]):
    result = Solution().flipAndInvertImage(image)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 