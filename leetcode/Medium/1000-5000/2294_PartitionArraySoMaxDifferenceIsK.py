import pytest
from typing import List

class Solution:
    def partitionArray(self, nums: List[int], k: int) -> int:
        nums.sort()
        partition_count = 0
        i = 0
        j = 0
        while i < len(nums): 
            while j < len(nums) and nums[j] - nums[i] <= k: 
                j += 1
            i = j
            partition_count += 1
        return partition_count

"""
Example 1:
Input: nums = [3,6,1,2,5], k = 2
Output: 2
Explanation:
We can partition nums into the two subsequences [3,1,2] and [6,5].
The difference between the maximum and minimum value in the first subsequence is 3 - 1 = 2.
The difference between the maximum and minimum value in the second subsequence is 6 - 5 = 1.
Since two subsequences were created, we return 2. It can be shown that 2 is the minimum number of subsequences needed.

Example 2:
Input: nums = [1,2,3], k = 1
Output: 2
Explanation:
We can partition nums into the two subsequences [1,2] and [3].
The difference between the maximum and minimum value in the first subsequence is 2 - 1 = 1.
The difference between the maximum and minimum value in the second subsequence is 3 - 3 = 0.
Since two subsequences were created, we return 2. Note that another optimal solution is to partition nums into the two subsequences [1] and [2,3].

Example 3:
Input: nums = [2,2,4,5], k = 0
Output: 3
Explanation:
We can partition nums into the three subsequences [2,2], [4], and [5].
The difference between the maximum and minimum value in the first subsequences is 2 - 2 = 0.
The difference between the maximum and minimum value in the second subsequences is 4 - 4 = 0.
The difference between the maximum and minimum value in the third subsequences is 5 - 5 = 0.
Since three subsequences were created, we return 3. It can be shown that 3 is the minimum number of subsequences needed.
"""
@pytest.mark.parametrize("nums, k, expected", [
     ([3,6,1,2,5], 2, 2), 
     ([1,2,3], 1, 2), 
     ([2,2,4,5], 0, 3)
])
def test_partitionArray(nums: List[int], k: int, expected: int):
    result = Solution().partitionArray(nums, k)
    assert(result == expected)
    

if __name__ == "__main__":
    pytest.main([__file__]) 