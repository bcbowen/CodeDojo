import pytest

from typing import List



class Solution:
    def prefixesDivBy5(self, nums: List[int]) -> List[bool]:
        result = []
        if nums[0] == 0: 
            result.append(True)
        else: 
            result.append(False)

        for i in range(1, len(nums)):
            val = int("".join(map(str, nums[:i + 1])), 2)
            result.append((val % 5) == 0) 
        return result
    


"""
Example 1:
Input: nums = [0,1,1]
Output: [true,false,false]
Explanation: The input numbers in binary are 0, 01, 011; which are 0, 1, and 3 in base-10.
Only the first number is divisible by 5, so answer[0] is true.

Example 2:
Input: nums = [1,1,1]
Output: [false,false,false]


TC 4
nums = [1,1,1,0,1]
[false,false,false,false,false]

"""
@pytest.mark.parametrize("nums, expected", [
    ([0,1,1], [True,False,False]), 
    ([1,1,1], [False,False,False]), 
    ([1,1,1,0,1], [False,False,False,False,False])
])
def test_prefixesDivBy5(nums: List[int], expected: List[bool]):
    result = Solution().prefixesDivBy5(nums)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])