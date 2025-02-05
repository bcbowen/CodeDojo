import pytest

class Solution:
    def subarraySum(self, nums: list[int], k: int) -> int:
        sums = [0] * len(nums)
        sums[0] = nums[0]
        for i in range(1, len(nums)): 
            sums[i] = sums[i - 1] + nums[i]
        count = 0 
        left = 0
        total = 0
        for right in range(len(nums)):
            total += sums[right]

            if total == k: 
                count += 1
            
            while total >= k: 
                total -= sums[left]
                left += 1
        return count
            

"""
Example 1:
Input: nums = [1,1,1], k = 2
Output: 2

Example 2:
Input: nums = [1,2,3], k = 3
Output: 2
"""
@pytest.mark.parametrize("nums, k, expected", [
     ([1,1,1], 2, 2),
     ([1,2,3], 3, 2) 
])
def test_subarraySum( nums: list[int], k: int, expected: int):
    sol = Solution()
    result = sol.subarraySum(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])