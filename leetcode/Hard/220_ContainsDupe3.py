import json
import pytest
import time
from sortedcontainers import SortedList
from typing import List
from pathlib import Path


"""
Given an integer array nums and an integer k, 
return true if there are two distinct indices i and j in the array such that 
nums[i] == nums[j] and abs(i - j) <= k.
"""
class Solution:
    def containsNearbyAlmostDuplicate(self, nums: List[int], indexDiff: int, valueDiff: int) -> bool:
        neighbors = SortedList()

        for i in range(len(nums)):
            num = nums[i]
            # find successor to current element
            bi = neighbors.bisect_left(num)
            if bi != len(neighbors) and neighbors[bi] <= num + valueDiff: 
                return True
            if bi > 0 and num <= neighbors[bi - 1] + valueDiff: 
                return True
            neighbors.add(num)

            if len(neighbors) > indexDiff: 
                neighbors.remove(nums[i - indexDiff]) 

        return False
    
    def containsNearbyAlmostDuplicate_a(self, nums: List[int], indexDiff: int, valueDiff: int) -> bool:
        if indexDiff >= len(nums): 
            return self.containsNearbyAlmostDuplicate(nums, len(nums) - 1, valueDiff)
        
        if indexDiff == 1: 
            if abs(nums[0] - nums[1]) <= valueDiff: 
                return True
        elif indexDiff > 0: 
            for i in range(indexDiff - 1): 
                for j in range(i + 1, indexDiff):
                    if abs(nums[i] - nums[j]) <= valueDiff: 
                        return True

        for i in range(indexDiff, len(nums)):
            for j in range(i - 1, i - indexDiff - 1, -1): 
                if abs(nums[i] - nums[j]) <= valueDiff: 
                    return True
        return False
    
    def containsNearbyAlmostDuplicate_sol(self, nums, k, t):
        set_ = SortedList()
        for i in range(len(nums)):
            # Find the successor of current element
            idx = set_.bisect_left(nums[i])
            if idx != len(set_) and set_[idx] <= nums[i] + t:
                return True

            # Find the predecessor of current element
            if idx > 0 and nums[i] <= set_[idx - 1] + t:
                return True

            set_.add(nums[i])
            if len(set_) > k:
                set_.remove(nums[i - k])

        return False

"""
Example 1:
Input: nums = [1,2,3,1], indexDiff = 3, valueDiff = 0
Output: true
Explanation: We can choose (i, j) = (0, 3).
We satisfy the three conditions:
i != j --> 0 != 3
abs(i - j) <= indexDiff --> abs(0 - 3) <= 3
abs(nums[i] - nums[j]) <= valueDiff --> abs(1 - 1) <= 0

Example 2:
Input: nums = [1,5,9,1,5,9], indexDiff = 2, valueDiff = 3
Output: false
Explanation: After trying all the possible pairs (i, j), we cannot satisfy the three conditions, so we return false.

TC 34: 
nums = [-2,3], indexDiff = 2, valueDiff = 5, expected: True

TC 37: 
nums = [1,2,2,3,4,5], indexDiff = 3, valueDiff = 0, expected True
"""
@pytest.mark.parametrize("nums, indexDiff, valueDiff, expected", [
     ([1,2,2,3,4,5], 3, 0, True),
     ([-2,3], 2, 5, True),
     ([1,2,3,1], 3, 0, True), 
     ([1,5,9,1,5,9], 2, 3, False), 
     ([1,5,9,1,2,9], 2, 1, True)
])
def test_containsNearbyAlmostDuplicate(nums: List[int], indexDiff: int, valueDiff: int, expected: bool):
    result = Solution().containsNearbyAlmostDuplicate(nums, indexDiff, valueDiff)
    assert(result == expected) 
"""
First attempt takes about 11 seconds

"""
def test_40BigInput(): 
    data_path = Path(__file__).parent.parent / "Data"
    file_name = "220_40.txt"    
    path = data_path / file_name
    with open(path, "r") as file: 
        nums = json.loads(file.readline())
        indexDiff = int(file.readline())
        valueDiff = int(file.readline())

    start_time = time.perf_counter()  # Start the timer
    result = Solution().containsNearbyAlmostDuplicate(nums, indexDiff, valueDiff)
    end_time = time.perf_counter()    # Stop the timer
    expected = False

    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.6f} seconds")
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 