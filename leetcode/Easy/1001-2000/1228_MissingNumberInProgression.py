from typing import List

class Solution:
    def missingNumber(self, arr: List[int]) -> int:
        if arr[1] > arr[0]: 
            gap = min(arr[1] - arr[0], arr[2] - arr[1])
        else: 
            gap = max(arr[1] - arr[0], arr[2] - arr[1])
        for i in range(1, len(arr)): 
            expected = arr[i - 1] + gap
            if arr[i] != expected: 
                return expected
        return arr[0]