import pytest

class Solution:
    def binaryGap(self, n: int) -> int:
        #s = bin(n)
        space = 0 
        max_space = 0
        counting = False
        while n: 
            if counting: 
                space += 1
            if (n & 1) == 1: 
                if not counting and n > 1: 
                    space += 1
                counting = True
                max_space = max(max_space, space)
                space = 0
                
            n >>= 1

        return max_space
    
"""
Example 1:
Input: n = 22
Output: 2
Explanation: 22 in binary is "10110".
The first adjacent pair of 1's is "10110" with a distance of 2.
The second adjacent pair of 1's is "10110" with a distance of 1.
The answer is the largest of these two distances, which is 2.
Note that "10110" is not a valid pair since there is a 1 separating the two 1's underlined.

Example 2:
Input: n = 8
Output: 0
Explanation: 8 in binary is "1000".
There are not any adjacent pairs of 1's in the binary representation of 8, so we return 0.

Example 3:
Input: n = 5
Output: 2
Explanation: 5 in binary is "101".
"""
@pytest.mark.parametrize("n, expected", [
    (22, 2), 
    (8, 0), 
    (5, 2)
])
def test_binaryGap(n: int, expected: int):
    result = Solution().binaryGap(n)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])