import pytest
class Solution:
    def minBitFlips(self, start: int, goal: int) -> int:
        b1 = bin(start)[2:]
        b2 = bin(goal)[2:]
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
Input: start = 10, goal = 7
Output: 3
Explanation: The binary representation of 10 and 7 are 1010 and 0111 respectively. We can convert 10 to 7 in 3 steps:
- Flip the first bit from the right: 1010 -> 1011.
- Flip the third bit from the right: 1011 -> 1111.
- Flip the fourth bit from the right: 1111 -> 0111.
It can be shown we cannot convert 10 to 7 in less than 3 steps. Hence, we return 3.

Example 2:
Input: start = 3, goal = 4
Output: 3
Explanation: The binary representation of 3 and 4 are 011 and 100 respectively. We can convert 3 to 4 in 3 steps:
- Flip the first bit from the right: 011 -> 010.
- Flip the second bit from the right: 010 -> 000.
- Flip the third bit from the right: 000 -> 100.
It can be shown we cannot convert 3 to 4 in less than 3 steps. Hence, we return 3.
"""
@pytest.mark.parametrize("start, goal, expected", [
    (10, 7, 3), 
    (3, 4, 3)
])
def test_minBitFlips(start: int, goal: int, expected: int):
    result = Solution().minBitFlips(start, goal)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 