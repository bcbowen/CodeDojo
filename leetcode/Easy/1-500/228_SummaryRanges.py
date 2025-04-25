import pytest
from typing import List

class Solution:
    def summaryRanges(self, nums: List[int]) -> List[str]:
        result = []
        if not nums: 
            return result
        i = 0
        j = 1
        while j < len(nums): 
            if nums[j] > nums[j - 1] + 1: 
                if i < j - 1:
                    result.append(f"{nums[i]}->{nums[j - 1]}")
                else: 
                    result.append(str(nums[i]))
                i = j

            j += 1
        if i < j: 
            if j - i == 1: 
                result.append(str(nums[i]))
            else: 
                result.append(f"{nums[i]}->{nums[-1]}") 
        return result


"""
Example 1:
Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"

Example 2:
Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"
"""
@pytest.mark.parametrize("nums, expected", [
     ([0,1,2,4,5,7], ["0->2","4->5","7"]), 
     ([0,2,3,4,6,8,9], ["0","2->4","6","8->9"]), 
     ([], [])
])
def test_summaryRanges(nums: List[int], expected: List[str]):
    result = Solution().summaryRanges(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])