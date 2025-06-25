import pytest
import heapq

from typing import List

class Solution:
    def maximumProduct(self, nums: List[int], k: int) -> int:
        heapq.heapify(nums)
        
        for _ in range(k): 
            num = heapq.heappop(nums)
            heapq.heappush(nums, num + 1)
    
        result = 1
        mod_factor = 10**9 + 7
        for num in nums: 
            result = (result * num) % mod_factor

        return result




"""
Example 1:

Input: nums = [0,4], k = 5
Output: 20
Explanation: Increment the first number 5 times.
Now nums = [5, 4], with a product of 5 * 4 = 20.
It can be shown that 20 is maximum product possible, so we return 20.
Note that there may be other ways to increment nums to have the maximum product.

Example 2:

Input: nums = [6,3,3,2], k = 2
Output: 216
Explanation: Increment the second number 1 time and increment the fourth number 1 time.
Now nums = [6, 4, 3, 3], with a product of 6 * 4 * 3 * 3 = 216.
It can be shown that 216 is maximum product possible, so we return 216.
Note that there may be other ways to increment nums to have the maximum product.
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([0, 4], 5, 20), 
    ([6, 3, 3, 2], 2, 216)
])
def test_maximumProduct(nums: List[int], k: int, expected: int):
    result = Solution().maximumProduct(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 