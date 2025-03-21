import pytest
from collections import deque 

class Solution:
    def canReach(self, arr: list[int], start: int) -> bool:
        def inbounds(i: int) -> bool: 
            return i >= 0 and i < len(arr)
        
        seen = set()
        queue = deque([start])
        while queue: 
            i = queue.popleft()
            val = arr[i]
            seen.add(i)
            if val == 0: 
                return True
            else: 
                for i_next in [i + val, i - val]: 
                    if inbounds(i_next) and not i_next in seen: 
                        queue.append(i_next)
                    
                
        return False

"""
Example 1:
Input: arr = [4,2,3,0,3,1,2], start = 5
Output: true
Explanation: 
All possible ways to reach at index 3 with value 0 are: 
index 5 -> index 4 -> index 1 -> index 3 
index 5 -> index 6 -> index 4 -> index 1 -> index 3 

Example 2:
Input: arr = [4,2,3,0,3,1,2], start = 0
Output: true 
Explanation: 
One possible way to reach at index 3 with value 0 is: 
index 0 -> index 4 -> index 1 -> index 3

Example 3:
Input: arr = [3,0,2,1,2], start = 2
Output: false
Explanation: There is no way to reach at index 1 with value 0.
"""
@pytest.mark.parametrize("arr, start, expected", [
    ([4,2,3,0,3,1,2], 5, True),
    ([4,2,3,0,3,1,2], 0, True), 
    ([3,0,2,1,2], 2, False)
])
def test_canReach(arr: list[int], start: int, expected: bool):
    result = Solution().canReach(arr, start)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__])