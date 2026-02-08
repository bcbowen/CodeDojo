import pytest

from typing import List

class Solution:
    def minRemoval(self, nums: List[int], k: int) -> int:
        
        n = len(nums)
        nums.sort()
        result = n
        right = 0
        for left in range(n): 
            while right < n and nums[right] <= nums[left] * k: 
                right += 1
            result = min(result, n - (right - left))
        return result

        """
        removals = 0
        if len(nums) > 1: 
            nums.sort()
            start = 0
            end = len(nums) - 1
            while start < len(nums): 
                limit = nums[start] * k
                if nums[-1] <= limit: 
                    removals = start + 1
                    break
                start += 1
                limit = nums[0] * k
                if nums[end] <= limit: 
                    removals = len(nums) - end - 1
                    break
                end -= 1

        return removals
        """

"""
Example 1:

Input: nums = [2,1,5], k = 2
Output: 1

Explanation:
Remove nums[2] = 5 to get nums = [2, 1].
Now max = 2, min = 1 and max <= min * k as 2 <= 1 * 2. Thus, the answer is 1.

Example 2:

Input: nums = [1,6,2,9], k = 3
Output: 2

Explanation:

Remove nums[0] = 1 and nums[3] = 9 to get nums = [6, 2].
Now max = 6, min = 2 and max <= min * k as 6 <= 2 * 3. Thus, the answer is 2.

Example 3:

Input: nums = [4,6], k = 2
Output: 0

Explanation:

Since nums is already balanced as 6 <= 4 * 2, no elements need to be removed.

TC 435: nums = [1,34,23], k=2 
Output 1

"""
@pytest.mark.parametrize("nums, k, expected", [
    ([2,1,5], 2, 1), 
    ([1,6,2,9], 3, 2), 
    ([4,6], 2, 0), 
    ([1,34,23], 2, 1), 
])
def test_minRemoval(nums: List[int], k: int, expected: int): 
    result = Solution().minRemoval(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])