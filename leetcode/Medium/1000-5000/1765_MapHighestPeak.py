import pytest

class Solution:
    def highestPeak(self, isWater: list[list[int]]) -> list[list[int]]:
        rows = len(isWater)
        columns = len(isWater[0])

        result = [[-1] * columns for i in range(rows)]
        # q holds row, col, previous height
        q = []
        # N E S W
        d_row = [-1, 0, 1, 0]
        d_col = [0, 1, 0, -1]


        def is_inbounds(point: tuple[int, int]) -> bool: 
            row, col = point
            return 0 <= row and row < rows and 0 <= columns and col < columns

        for row in range(rows): 
            for col in range(columns): 
                if isWater[row][col] == 1: 
                    result[row][col] = 0
                    q.append((row, col))

        next_layer_height = 1

        while q: 
            layer_len = len(q)
            for i in range(layer_len): 
                row, col = q.pop(0)

                for d in range(4): 
                    next = (row + d_row[d], col + d_col[d])
                    if is_inbounds(next) and result[next[0]][next[1]] == -1:
                        q.append((next[0], next[1]))
                        result[next[0]][next[1]] = next_layer_height

            next_layer_height += 1                        
        return result
                

@pytest.mark.parametrize("isWater, expected", [
    ([[0,1],[0,0]], [[1,0],[2,1]]), 
    ([[0,0,1],[1,0,0],[0,0,0]], [[1,1,0],[0,1,1],[1,2,2]])
])
def test_highestPeak(isWater: list[list[int]], expected: list[list[int]]): 
    solution = Solution()
    result = solution.highestPeak(isWater)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])