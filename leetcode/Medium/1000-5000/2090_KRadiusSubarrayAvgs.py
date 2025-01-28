import pytest

class Solution:
    def getAverages(self, nums: list[int], k: int) -> list[int]:
        if k == 0: 
            return nums
        
        result = [0] * len(nums)
        prefix_sums = [0] * len(nums)
        prefix_sums[0] = nums[0]
        for i in range(1, len(nums)): 
            prefix_sums[i] = prefix_sums[i - 1] + nums[i]

        
        #left = 0 - k
        #center = 0
        #right = 0 + k
        
        for center in range(len(nums)): 
            left = center - k
            right = center + k
            spread = right - left + 1
            if left < 0 or right >= len(nums): 
                result[center] = -1
            elif left == 0:     
                result[center] = prefix_sums[right] // spread
            else: 
                result[center] = (prefix_sums[right] - prefix_sums[left - 1]) // spread

        return result

"""
Example 1: 
Input: nums = [7,4,3,9,1,8,5,2,6], k = 3
Output: [-1,-1,-1,5,4,4,-1,-1,-1]
Explanation:
- avg[0], avg[1], and avg[2] are -1 because there are less than k elements before each index.
- The sum of the subarray centered at index 3 with radius 3 is: 7 + 4 + 3 + 9 + 1 + 8 + 5 = 37.
  Using integer division, avg[3] = 37 / 7 = 5.
- For the subarray centered at index 4, avg[4] = (4 + 3 + 9 + 1 + 8 + 5 + 2) / 7 = 4.
- For the subarray centered at index 5, avg[5] = (3 + 9 + 1 + 8 + 5 + 2 + 6) / 7 = 4.
- avg[6], avg[7], and avg[8] are -1 because there are less than k elements after each index.

Example 2:
Input: nums = [100000], k = 0
Output: [100000]
Explanation:
- The sum of the subarray centered at index 0 with radius 0 is: 100000.
  avg[0] = 100000 / 1 = 100000.

Example 3:
Input: nums = [8], k = 100000
Output: [-1]
Explanation: 
- avg[0] is -1 because there are less than k elements before and after index 0.
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([7,4,3,9,1,8,5,2,6], 3, [-1,-1,-1,5,4,4,-1,-1,-1]), 
    ([100000], 0, [100000]), 
    ([8], 100000, [-1])
])
def test_getAverages(nums: list[int], k: int, expected: list[int]): 
    sol = Solution()
    result = sol.getAverages(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])