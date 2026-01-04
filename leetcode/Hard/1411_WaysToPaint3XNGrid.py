import math
import pytest

from collections import defaultdict
from typing import List

class Solution:
    def numOfWays(self, n: int) -> int:
        mod = 10**9 + 7

        # Hash mapping stores all valid coloration schemes for a single row that meet the requirements
        # The key represents mask, and the value represents the ternary string of mask (stored as a list)
        valid = dict()
        m = 3
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

"""
Example 1: 
Input: n = 1
Output: 12
Explanation: There are 12 possible way to paint the grid as shown.

Example 2:
Input: n = 5000
Output: 30228214

12, 54, 246, 1122, 5118, 23346, 106494, 485778, 2215902, 10107954​

"""
@pytest.mark.parametrize("n, expected", [
    (1, 12), 
    (2, 54), 
    (3, 246), 
    (4, 1122), 
    (5, 5118), 
    (6, 23346), 
    (7, 106494), 
    (8, 485778), 
    (9, 2215902), 
    (10, 10107954)
])
def test_numOfWays(n: int, expected: int): 
    result = Solution().numOfWays(n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 