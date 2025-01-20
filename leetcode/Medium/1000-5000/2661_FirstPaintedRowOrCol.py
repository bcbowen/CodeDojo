import ast
import os
import pytest

"""
Example 1
Input: arr = [1,3,4,2], mat = [[1,4],[2,3]]
Output: 2
Explanation: The moves are shown in order, 
and both the first row and second column of the matrix become fully painted at arr[2].

Example 2
Input: arr = [2,8,7,4,1,3,5,6,9], mat = [[3,2,5],[1,4,6],[8,7,9]]
Output: 3
Explanation: The second column becomes fully painted at arr[3].

"""

class Solution:
    def get_location_lookup(mat: list[list[int]]) -> dict[int, tuple[int, int]]:
        lookup = {}
        for row in range(len(mat)):
            for col in range(len(mat[0])): 
                lookup[mat[row][col]] = (row, col)  
        return lookup

    def firstCompleteIndex(self, arr: list[int], mat: list[list[int]]) -> int:
        row_len = len(mat)
        col_len = len(mat[0])
        
        row_counts = [0] * row_len
        col_counts = [0] * col_len
        lookup = Solution.get_location_lookup(mat)
        for i, val in enumerate(arr):
            row, col = lookup[val]
            row_counts[row] += 1
            if row_counts[row] == col_len: 
                return i
            col_counts[col] += 1
            if col_counts[col] == row_len: 
                return i


@pytest.mark.parametrize("arr, mat, expected", [
    ([1,3,4,2], [[1,4],[2,3]], 2), 
    ([2,8,7,4,1,3,5,6,9], [[3,2,5],[1,4,6],[8,7,9]], 3),
    ([1,4,5,2,6,3], [[4,3,5],[1,2,6]], 1)
])
def test_firstCompleteIndex(arr: list[int], mat: list[list[int]], expected: int): 
    solution = Solution()
    result = solution.firstCompleteIndex(arr, mat)
    assert(result == expected)

def get_path(file_name: str) -> str: 
    # Get the directory of the current script
    script_dir = os.path.dirname(os.path.abspath(__file__))

    # Construct the full path to the file
    path = os.path.join(script_dir, file_name)
    return path

def test_1055(): 

    #def parse_list(line: str) -> list[int]: 
    #    return list(map(int, line.strip("[]\n").split(',')))
    expected = 99000
    file_name = "2661_1055.txt"
    path = get_path(file_name)
    with open(path, "r") as file: 
        arr = ast.literal_eval(file.readline()) #parse_list(file.readline())
        mat = ast.literal_eval(file.readline())#parse_list(file.readline())

    solution = Solution() 
    result = solution.firstCompleteIndex(arr, mat)
    assert(result == expected)

pytest.main([__file__])