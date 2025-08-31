import pytest 

from typing import List

class Solution:
    def count_subs(self, val: str) -> int: 
        char_set = set([c for c in val])
        if char_set != set('0'): 
            raise Exception(f"Invalid string {val}")
        count = 0
        for i in range(len(val)):
            count += 1
            for j in range(i + 1, len(val)):  
                count += 1
        return count

    def zeroFilledSubarray(self, nums: List[int]) -> int:
        count = 0
        i = 0
        while i < len(nums): 
            if nums[i] == 0: 
                for j in range(i + 1, len(nums)):
                    if nums[j] != 0: 
                        break
                #if j < len(nums) - 1: 
                    count += self.count_subs('0' * (j - i))
                #else: 
                #    count += self.count_subs('0' * (len(nums) - i + 1))
                i = j
            else: 
                i += 1
        return count
                
"""
0: 1
00: 3
000: 6
0000: 10
00000: 15
"""
@pytest.mark.parametrize("val, expected", [
    ("0", 1), 
    ("00", 3), 
    ("000", 6), 
    ("0000", 10), 
    ("00000", 15)
])
def test_get_counts(val: str, expected: int): 
    result = Solution().count_subs(val)
    assert(result == expected)
"""
Example 1:
Input: nums = [1,3,0,0,2,0,0,4]
Output: 6
Explanation: 
There are 4 occurrences of [0] as a subarray.
There are 2 occurrences of [0,0] as a subarray.
There is no occurrence of a subarray with a size more than 2 filled with 0. Therefore, we return 6.

Example 2:
Input: nums = [0,0,0,2,0,0]
Output: 9
Explanation:
There are 5 occurrences of [0] as a subarray.
There are 3 occurrences of [0,0] as a subarray.
There is 1 occurrence of [0,0,0] as a subarray.
There is no occurrence of a subarray with a size more than 3 filled with 0. Therefore, we return 9.

Example 3:
Input: nums = [2,10,2019]
Output: 0
Explanation: There is no subarray filled with 0. Therefore, we return 0.
"""
@pytest.mark.parametrize("nums, expected", [
   ([1,3,0,0,2,0,0,4], 6),
   ([0,0,0,2,0,0], 9),
   ([2,10,2019], 0)  
])
def test_zeroFilledSubarray(nums: List[int], expected: int):
        result = Solution().zeroFilledSubarray(nums)
        assert(result == expected)

if __name__ == "__main__":
     pytest.main([__file__]) 