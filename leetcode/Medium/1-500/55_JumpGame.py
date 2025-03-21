import json
import pytest
import time 
from collections import deque
from pathlib import Path

class Solution:
    """
    def canJump(self, nums: list[int]) -> bool:
        if len(nums) == 1: 
            return True
        seen = [False] * len(nums)
        queue = deque([0])
        while queue: 
            pos = queue.popleft() 
            seen[pos] = True
            leap_range = nums[pos] 
            if pos + leap_range >= len(nums) - 1:
                return True
            for leap in range(1,leap_range + 1): 
                next_pos = pos + leap
                if next_pos < len(nums) and not seen[next_pos]: 
                    queue.append(next_pos)
        return False
    
        def canJump(self, nums):
        GOOD, BAD, UNKNOWN = 1, 0, -1
        memo = [UNKNOWN] * len(nums)
        memo[-1] = GOOD
        for i in range(len(nums) - 2, -1, -1):
            furthest_jump = min(i + nums[i], len(nums) - 1)
            for j in range(i + 1, furthest_jump + 1):
                if memo[j] == GOOD:
                    memo[i] = GOOD
                    break
        return memo[0] == GOOD

    """
    def canJump(self, nums: list[int]) -> bool:
        GOOD, BAD, UNK = 1, 0, -1
        memo = [UNK] * len(nums)
        memo[-1] = GOOD
        for i in range(len(nums) - 2, -1, -1):
            furthest_jump = min(i + nums[i], len(nums) - 1)
            for j in range(i + 1, furthest_jump + 1): 
                if memo[j] == GOOD: 
                    memo[i] = GOOD
                    break
        return memo[0] == GOOD 
        
"""
Example 1:
Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:
Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
"""
@pytest.mark.parametrize("nums, expected", [
    ([2,3,1,1,4], True), 
    ([3,2,1,0,4], False), 
    ([2,0,0], True),
    ([0], True), 
    ([2,0], True), 
    ([1,2,3], True)
])
def test_canJump(nums: list[int], expected: bool):
    result = Solution().canJump(nums)
    assert(result == expected) 

# initial implementation had memory limit exceeded on this case
def test_biginput77(): 
    data_path = Path(__file__).parent.parent.parent / "Data"
    file_name = "55_77MLE.txt"    
    path = data_path / file_name
    with open(path, "r") as file: 
        nums = json.loads(file.readline())

    expected = False
    start_time = time.perf_counter()  # Start the timer
    result = Solution().canJump(nums)
    end_time = time.perf_counter()    # Stop the timer

    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.6f} seconds")
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 