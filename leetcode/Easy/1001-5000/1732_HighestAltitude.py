import pytest

class Solution:
    def largestAltitude(self, gain: list[int]) -> int:
        highest = 0
        alt = 0
        for height in gain: 
             alt += height
             highest = max(highest, alt)
        return highest

"""
Example 1:
Input: gain = [-5,1,5,0,-7]
Output: 1
Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.

Example 2:
Input: gain = [-4,-3,-2,-1,4,3,2]
Output: 0
Explanation: The altitudes are [0,-4,-7,-9,-10,-6,-3,-1]. The highest is 0.
"""
@pytest.mark.parametrize("gain, expected", [
     ([-5,1,5,0,-7], 1),
     ([-4,-3,-2,-1,4,3,2], 0), 
])
def test_largestAltitude(gain: list[int], expected: int):
        sol = Solution()
        result = sol.largestAltitude(gain)
        assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])