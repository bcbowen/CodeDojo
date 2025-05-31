import pytest

class Solution:
    def hammingDistance(self, x: int, y: int) -> int:
        b1 = bin(x)[2:]
        b2 = bin(y)[2:]
        diff = len(b1) - len(b2)
        if diff > 0: 
            b2 = '0' * diff + b2
        elif diff < 0: 
            b1 = '0' * -diff + b1

        dist = 0
        # start at pos 2, strings always start with '0b'
        for i in range(len(b1)): 
            if b1[i] != b2[i]:
                dist += 1
        return dist
 

"""
Example 1:
Input: x = 1, y = 4
Output: 2
Explanation:
1   (0 0 0 1)
4   (0 1 0 0)
       ↑   ↑
The above arrows point to positions where the corresponding bits are different.

Example 2:
Input: x = 3, y = 1
Output: 1
 
TC54: x = 4; y = 14; expected = 2
"""
@pytest.mark.parametrize("x, y, expected", [
    (1, 4, 2), 
    (3, 1, 1), 
    (4, 14, 2)
])
def test_hammingDistance(x: int, y: int, expected: int):
    result = Solution().hammingDistance(x, y)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 