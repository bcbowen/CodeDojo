import pytest

class Solution:
    def countServers(self, grid: list[list[int]]) -> int:
        row_lookup = {}
        col_lookup = {}

        rows = len(grid)
        cols = len(grid[0])
        server_count = 0
        for row in range(rows): 
            for col in range(cols): 
                if grid[row][col] == 1: 
                    if not row in row_lookup: 
                        row_lookup[row] = []
                    row_lookup[row].append(col)
                    
                    if not col in col_lookup: 
                        col_lookup[col] = []
                    col_lookup[col].append(row)
                    server_count += 1
        
        isolated_servers = set()
        for key in row_lookup.keys():
            if len(row_lookup[key]) == 1: 
                col = row_lookup[key][0]
                if len(col_lookup[col]) == 1:
                    isolated_servers.add((key, col)) 
            #if len(row_lookup[key]) == 1 and len(col_lookup[row_lookup[0]]) == 1:
                #isolated_servers.add((key, row_lookup[key][0])) 
        return server_count - len(isolated_servers)

"""
Input: grid = [[1,0],[0,1]]
Output: 0

Input: grid = [[1,0],[1,1]]
Output: 3
Explanation: All three servers can communicate with at least one other server.

Input: grid = [[1,1,0,0],[0,0,1,0],[0,0,1,0],[0,0,0,1]]
Output: 4
Explanation: The two servers in the first row can communicate with each other. 
The two servers in the third column can communicate with each other. 
The server at right bottom corner can't communicate with any other server.

"""

@pytest.mark.parametrize("grid, expected", [
    ([[1,0],[0,1]], 0), 
    ([[1,0],[1,1]], 3), 
    ([[1,1,0,0],[0,0,1,0],[0,0,1,0],[0,0,0,1]], 4)
])
def test_countServers(grid: list[list[int]], expected: int): 
    s = Solution()
    result = s.countServers(grid)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])