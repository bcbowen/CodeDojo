import pytest
from typing import List

class Solution:
    def findKOr(self, nums: List[int], k: int) -> int:
        result = 0
        mask = 1
        max_number = max(nums)
        while mask <= max_number: 
            count = 0
            for num in nums: 
                if (num & mask) == mask: 
                    count += 1
                if count == k: 
                    count = 0
                    result += mask
                    break
            mask <<= 1
        return result
    

"""

Example 1:
Input: nums = [7,12,9,8,9,15], k = 4
Output: 9
Explanation:
Represent numbers in binary:
Number	Bit 3	Bit 2	Bit 1	Bit 0
7	0	1	1	1
12	1	1	0	0
9	1	0	0	1
8	1	0	0	0
9	1	0	0	1
15	1	1	1	1
Result = 9	1	0	0	1
Bit 0 is set in 7, 9, 9, and 15. Bit 3 is set in 12, 9, 8, 9, and 15.
Only bits 0 and 3 qualify. The result is (1001)2 = 9.

Example 2:
Input: nums = [2,12,1,11,4,5], k = 6
Output: 0
Explanation: No bit appears as 1 in all six array numbers, as required for K-or with k = 6. Thus, the result is 0.

Example 3:
Input: nums = [10,8,5,9,11,6,8], k = 1
Output: 15
Explanation: Since k == 1, the 1-or of the array is equal to the bitwise OR of all its elements. Hence, the answer is 10 OR 8 OR 5 OR 9 OR 11 OR 6 OR 8 = 15.

TC 941: 
nums: [1], k: 1, expected: 1 
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([7,12,9,8,9,15], 4, 9), 
    ([2,12,1,11,4,5], 6, 0), 
    ([10,8,5,9,11,6,8], 1, 15), 
    ([1], 1, 1)
])
def test_findKOr(nums: List[int], k: int, expected: int):
    result = Solution().findKOr(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 