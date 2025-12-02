import json
import pytest
import time
from pathlib import Path
from typing import List

class Solution:
    def minNumberOperations(self, target: List[int]) -> int:
        ops = 0
        if target[0] > 0: 
            ops += target[0]
        for i in range(1, len(target)): 
            if target[i] > target[i - 1]: 
                ops += target[i] - target[i - 1]
        return ops 
    
    def minNumberOperations_1(self, target: List[int]) -> int:
        ops = 0
        working = [0] * len(target)
        processing = True
        while processing: 
            replacements = 0
            pos = 0
            open = False
            while pos < len(target): 
                if target[pos] > working[pos]: 
                    if not open: 
                        ops += 1
                        replacements += 1
                        open = True
                    working[pos] += 1
                else: 
                    open = False
                pos += 1
            if replacements == 0: 
                processing = False

        return ops

"""
Example 1:
Input: target = [1,2,3,2,1]
Output: 3
Explanation: We need at least 3 operations to form the target array from the initial array.
[0,0,0,0,0] increment 1 from index 0 to 4 (inclusive).
[1,1,1,1,1] increment 1 from index 1 to 3 (inclusive).
[1,2,2,2,1] increment 1 at index 2.
[1,2,3,2,1] target array is formed.

Example 2:
Input: target = [3,1,1,2]
Output: 4
Explanation: [0,0,0,0] -> [1,1,1,1] -> [1,1,1,2] -> [2,1,1,2] -> [3,1,1,2]

Example 3:
Input: target = [3,1,5,4,2]
Output: 7
Explanation: [0,0,0,0,0] -> [1,1,1,1,1] -> [2,1,1,1,1] -> [3,1,1,1,1] -> [3,1,2,2,2] -> [3,1,3,3,2] -> [3,1,4,4,2] -> [3,1,5,4,2].

"""
@pytest.mark.parametrize("target, expected", [
    ([1,2,3,2,1], 3), 
    ([3,1,1,2], 4), 
    ([3,1,5,4,2], 7)     
])
def test_minNumberOperations(target: List[int], expected: int):
    result = Solution().minNumberOperations(target)
    assert(result == expected)

"""
Initial version takes 30 seconds

New version: Execution time: 0.000257 seconds
"""
def test_61(): 

    #def parse_list(line: str) -> list[int]: 
    #    return list(map(int, line.strip("[]\n").split(',')))

    data_path = Path(__file__).parent.parent / "Data"
    file_name = "1526_61.txt"
    path = data_path / file_name
    
    
    with open(path, "r") as file: 
        target = json.loads(file.readline())

    #result = -1
    
    start_time = time.perf_counter()  # Start the timer
    s = Solution()
    expected = 73_993_282
    result = s.minNumberOperations(target)
    
    end_time = time.perf_counter()    # Stop the timer
    
    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.6f} seconds")
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])