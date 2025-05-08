import pytest

class Solution:
    def climbStairs(self, n: int) -> int:
        if not n:
            return 0
        if n < 3:
            return n
        
        counts = [0] * n
        counts[0] = 1
        counts[1] = 2
        i = 2
        while i < n: 
            counts[i] = counts[i - 1] + counts[i - 2]
            i += 1
            
        return counts[-1]

"""
Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

3: 
n = 4; e = 5
1. 1 + 1 + 1 + 1
2. 1 + 1 + 2
3. 1 + 2 + 1
4. 2 + 1 + 1
5. 2 + 2
"""
@pytest.mark.parametrize("n, expected", [
    (2, 2), 
    (3, 3), 
    (4, 5)
])
def test_climbStairs(n: int, expected: int):
    result = Solution().climbStairs(n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])