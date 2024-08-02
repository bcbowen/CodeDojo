import pytest

class Solution:
    def divideArray(self, nums: list[int]) -> bool:
        counts = {}
        for num in nums: 
            if not num in counts: 
                counts[num] = 0
            counts[num] += 1

        for key, value in counts.items(): 
            if value % 2 != 0: 
                return False
        return True
    
"""
You need to divide nums into n pairs such that:

Each element belongs to exactly one pair.
The elements present in a pair are equal.
Return true if nums can be divided into n pairs, otherwise return false.


Example 1:
Input: nums = [3,2,3,2,2,2]
Output: true
Explanation: 
There are 6 elements in nums, so they should be divided into 6 / 2 = 3 pairs.
If nums is divided into the pairs (2, 2), (3, 3), and (2, 2), it will satisfy all the conditions.

Example 2:
Input: nums = [1,2,3,4]
Output: false
Explanation: 
There is no way to divide nums into 4 / 2 = 2 pairs such that the pairs satisfy every condition.
"""

@pytest.mark.parametrize("nums, expected", [
    ([3,2,3,2,2,2], True),
    ([1,2,3,4], False)
])
def test_divideArray(nums, expected):
    result = Solution().divideArray(nums)
    #print(f"hey dude {names} {heights} --> {result} [{expected}] ")
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])