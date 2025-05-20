import pytest
from collections import defaultdict

class Solution:
    def colorTheGrid(self, m: int, n: int) -> int:
        mod = 10**9 + 7
        # Hash mapping stores all valid coloration schemes for a single row that meet the requirements
        # The key represents mask, and the value represents the ternary string of mask (stored as a list)
        valid = dict()

        # Enumerate masks that meet the requirements within the range [0, 3^m)
        for mask in range(3**m):
            color = list()
            mm = mask
            for i in range(m):
                color.append(mm % 3)
                mm //= 3
            if any(color[i] == color[i + 1] for i in range(m - 1)):
                continue
            valid[mask] = color

        # Preprocess all (mask1, mask2) binary tuples, satisfying mask1 and mask2 When adjacent rows, the colors of the two cells in the same column are different
        adjacent = defaultdict(list)
        for mask1, color1 in valid.items():
            for mask2, color2 in valid.items():
                if not any(x == y for x, y in zip(color1, color2)):
                    adjacent[mask1].append(mask2)

        f = [int(mask in valid) for mask in range(3**m)]
        for i in range(1, n):
            g = [0] * (3**m)
            for mask2 in valid.keys():
                for mask1 in adjacent[mask2]:
                    g[mask2] += f[mask1]
                    if g[mask2] >= mod:
                        g[mask2] -= mod
            f = g

        return sum(f) % mod
    
    def colorTheGrid_1(self, m: int, n: int) -> int:
        factor = 10**9 + 7

        dp = [[col for col in range(n)] for _ in range(m)]

        dp[0][0] = 3
        for col in range(1, len(dp[0])): 
            dp[0][col] = dp[0][col - 1] * 2

        for row in range(1, len(dp)): 
            dp[row][0] = dp[row - 1][len(dp[0]) - 1] * 2

            for col in range(1, len(dp[0])): 
                dp[row][col] = dp[row][col - 1] * 2

        result = dp[-1][-1]
        
        return result % factor

"""
Input: m = 1, n = 1
Output: 3

Input: m = 1, n = 2
Output: 6
Explanation: The six possible colorings are shown in the image above.
Example 3:

Input: m = 5, n = 5
Output: 580986
"""
@pytest.mark.parametrize("rows, cols, expected", [
    (1, 1, 3), 
    (1, 2, 6), 
    (5, 5, 580986), 
    (3, 3, 246)
])
def test_colorTheGrid(rows: int, cols: int, expected: int):
    result = Solution().colorTheGrid(rows, cols)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])
