import pytest
from typing import List



"""
Given an integer array nums and an integer k, 
return true if there are two distinct indices i and j in the array such that 
nums[i] == nums[j] and abs(i - j) <= k.
"""
class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        num_lookup = {} 
        for i in range(len(nums)): 
            if not nums[i] in num_lookup: 
                num_lookup[nums[i]] = []
            else: 
                for val in num_lookup[nums[i]]: 
                    if abs(val - i) <= k: 
                        return True
            num_lookup[nums[i]].append(i)
        return False

"""
Example 1:
Input: nums = [1,2,3,1], k = 3
Output: true

Example 2:
Input: nums = [1,0,1,1], k = 1
Output: true

Example 3:
Input: nums = [1,2,3,1,2,3], k = 2
Output: false
"""
@pytest.mark.parametrize("nums, k, expected", [
     ([1,2,3,1], 3, True), 
     ([1,0,1,1], 1, True), 
     ([1,2,3,1,2,3], 2, False)
])
def test_containsNearbyDuplicate(nums: List[int], k: int, expected: bool):
    result = Solution().containsNearbyDuplicate(nums, k)
    assert(result == expected) 

if __name__ == "__main__":
    pytest.main([__file__]) 