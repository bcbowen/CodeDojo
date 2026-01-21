import pytest
from typing import List


"""
def canThreePartsEqualSum(self, arr: List[int]) -> bool:
        total = sum(arr)
        if total % 3 != 0:
            return False
        target = total // 3
        current_sum = 0
        partitions = 0
        for i in range(len(arr)):
            current_sum += arr[i]
            if current_sum == target:
                partitions += 1
                current_sum = 0
                # If we found two partitions and it's not the end, the rest must be the third
                if partitions == 2 and i < len(arr) - 1:
                    return True
        return False

"""

class Solution:
    def canThreePartsEqualSum(self, arr: List[int]) -> bool:
        total = sum(arr)
        if len(arr) < 3 or total % 3 != 0: 
            return False
        
        target = total // 3

        running_sum = 0
        partitions = 0
        for i in range(len(arr)): 
            running_sum += arr[i]
            if running_sum == target: 
                partitions += 1
                running_sum = 0
                if partitions == 2 and i < len(arr) - 1: 
                    return True
        return False 


        
"""
i = 1
        running_sum = arr[0]
        while i < len(arr) and running_sum != target: 
            running_sum += arr[i]
            i += 1

        j = i
        running_sum = arr[j]
        while j < len(arr) and running_sum != target:
            running_sum += arr[j]
            j += 1
        
        if j < len(arr) - 1 and running_sum == target: 
            running_sum = sum(arr[j:])
        else: 
            return False

        return running_sum == target
"""
        
        

"""
Works for sample input, TLE for TC 39 (runs forever)
"""
class Solution_1:
    def canThreePartsEqualSum(self, arr: List[int]) -> bool:
        
        result = False

        def backTrack(i: int, j: int): 
            nonlocal result
            if result or i == j - 1: 
                return
            
            sum1 = sum(arr[0: i + 1])
            sum2 = sum(arr[i + 1:j])
            sum3 = sum(arr[j:])
            if (sum1 == sum2 == sum3): 
                result = True
                return

            backTrack(i + 1, j)
            backTrack(i, j - 1) 
        i = 0
        j = len(arr) - 1
        backTrack(i, j)
        return result
    
"""
Example 1:
Input: arr = [0,2,1,-6,6,-7,9,1,2,0,1]
Output: true
Explanation: 0 + 2 + 1 = -6 + 6 - 7 + 9 + 1 = 2 + 0 + 1

Example 2:
Input: arr = [0,2,1,-6,6,7,9,-1,2,0,1]
Output: false

Example 3:
Input: arr = [3,3,6,5,-2,2,5,1,-9,4]
Output: true
Explanation: 3 + 3 = 6 = 5 - 2 + 2 + 5 + 1 - 9 + 4

TC 39: 
arr: [-2,-8,6,5,9,3,-3,4,6,0,5,4,-2,1,-6,2,-8,1,-1,6,6,-2,8,7,6,-4,5,7,1,5,-8,-10,3,-7,0,2,-6,1,10,8,-2]
output true

TC 70
arr = [1,-1,1,-1]

Expected false

arr = [0, 0, 0, 0]

Expected true
"""
@pytest.mark.parametrize("arr, expected", [
    ([0,2,1,-6,6,-7,9,1,2,0,1], True), 
    ([0,2,1,-6,6,7,9,-1,2,0,1], False), 
    ([3,3,6,5,-2,2,5,1,-9,4], True), 
    ([-2,-8,6,5,9,3,-3,4,6,0,5,4,-2,1,-6,2,-8,1,-1,6,6,-2,8,7,6,-4,5,7,1,5,-8,-10,3,-7,0,2,-6,1,10,8,-2], False),
    ([1,-1,1,-1], False), 
    ([0, 0, 0, 0], True)
])
def test_can_three_parts_equal_sum(arr: List[int], expected: bool): 
    result = Solution().canThreePartsEqualSum(arr)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 