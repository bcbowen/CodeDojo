import pytest

class Solution:
    def subarraySum(self, nums: list[int], k: int) -> int:
        if len(nums) < 1: 
            return 0
        elif len(nums) == 1: 
            return 1 if nums[0] == k else 0

        sums = [0] * len(nums)
        sums[0] = nums[0]
        for i in range(1, len(nums)): 
            sums[i] = sums[i - 1] + nums[i]
        count = 0 
        left = -1
        for right in range(len(sums)):
            if sums[right] > k: 
                if left == -1: 
                    left += 1

                while sums[right] - sums[left] > k and right > left + 1: 
                    left += 1    
                
                if sums[right] - sums[left] == k: 
                    count += 1

            elif sums[right] == k: 
                count += 1
            
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
     ([1,2,3], 3, 2), 
     ([1], 0, 0), 
     ([-1, -1, 1], 0, 1)
])
def test_subarraySum( nums: list[int], k: int, expected: int):
    sol = Solution()
    result = sol.subarraySum(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])