import time
import pytest
#from collections import deque
from typing import List

class Solution:
    def imageSmoother(self, img: List[List[int]]) -> List[List[int]]:
        m = len(img)
        n = len(img[0])
        # N NE E SE S SW W NW
        directions = [(-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1)]
        #seen = set()
        def is_inbounds(row: int, col: int) -> bool: 
            if row < 0 or row >= m: 
                return False
            if col < 0 or col >= n: 
                return False
            return True
    
        def get_smooth(row: int, col: int) -> int: 
            total = img[row][col]
            cell_count = 1

            for d in directions: 
                next_row = row + d[0]
                next_col = col + d[1]
                if is_inbounds(next_row, next_col) : 
                    total += img[next_row][next_col]
                    cell_count += 1    
                    
            return total // cell_count

        result = [[0 for _ in img[0]] for _ in img]
        
        for i in range(m): 
            for j in range(n): 
                val = get_smooth(i, j)
                result[i][j] = val

        return result
    

"""
Example 1: 
Input: img = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[0,0,0],[0,0,0],[0,0,0]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the points (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0

Example 2:
Input: img = [[100,200,100],[200,50,200],[100,200,100]]
Output: [[137,141,137],[141,138,141],[137,141,137]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor((100+200+200+50)/4) = floor(137.5) = 137
For the points (0,1), (1,0), (1,2), (2,1): floor((200+200+50+200+100+100)/6) = floor(141.666667) = 141
For the point (1,1): floor((50+200+200+200+200+100+100+100+100)/9) = floor(138.888889) = 138

"""
@pytest.mark.parametrize("img, expected", [
     ([[1,1,1],[1,0,1],[1,1,1]], [[0,0,0],[0,0,0],[0,0,0]]), 
     ([[100,200,100],[200,50,200],[100,200,100]], [[137,141,137],[141,138,141],[137,141,137]])
])
def test_imageSmoother(img: List[List[int]], expected: List[List[int]]):
        result = Solution().imageSmoother(img)
        assert(result == expected)

def test_case_55(): 
    img = [[19,2,8,6,4,14,1,0,17],[0,1,9,10,11,4,12,14,5],[14,12,16,0,15,8,5,2,8],[5,4,1,17,9,18,8,5,2],[9,5,4,8,16,7,11,5,0],[5,7,14,18,10,0,14,14,0],[9,14,4,13,18,16,9,12,10],[18,13,9,18,11,4,12,10,10],[7,14,16,19,10,19,11,6,4],[16,2,3,7,15,9,7,1,1],[1,6,16,15,18,6,6,1,14],[9,5,2,9,8,3,2,3,10],[2,3,16,8,7,7,0,18,16],[11,0,16,8,13,13,11,3,8],[17,11,0,12,11,15,12,17,0]]
    start_time = time.perf_counter()
    result = Solution().imageSmoother(img)
    end_time = time.perf_counter()
    #print(result)
    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.4f} seconds")
    expected = [[5, 6, 6, 8, 8, 7, 7, 8, 9], [8, 9, 7, 8, 8, 8, 6, 7, 7], [6, 6, 7, 9, 10, 10, 8, 6, 6], [8, 7, 7, 9, 10, 10, 7, 5, 3], [5, 6, 8, 10, 11, 10, 9, 6, 4], [8, 7, 9, 11, 11, 11, 9, 8, 6], [11, 10, 12, 12, 12, 10, 10, 10, 9], [12, 11, 13, 13, 14, 12, 11, 9, 8], [11, 10, 11, 12, 12, 10, 8, 6, 5], [7, 9, 10, 13, 13, 11, 7, 5, 4], [6, 6, 7, 10, 10, 8, 4, 5, 5], [4, 6, 8, 11, 9, 6, 5, 7, 10], [5, 7, 7, 9, 8, 7, 6, 7, 9], [7, 8, 8, 10, 10, 9, 10, 9, 10], [9, 9, 7, 10, 12, 12, 11, 8, 7]]
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 