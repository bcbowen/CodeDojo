import pytest
from typing import List 

class Solution:
    def findPoisonedDuration(self, timeSeries: List[int], duration: int) -> int:
        result = 0
        for i in range(len(timeSeries) - 1):
            interval = timeSeries[i + 1] - timeSeries[i] 
            if interval < duration: 
                result += interval
            else:
                result += duration
        result += duration
        return result

"""
Example 1:

Input: timeSeries = [1,4], duration = 2
Output: 4
Explanation: Teemo's attacks on Ashe go as follows:
- At second 1, Teemo attacks, and Ashe is poisoned for seconds 1 and 2.
- At second 4, Teemo attacks, and Ashe is poisoned for seconds 4 and 5.
Ashe is poisoned for seconds 1, 2, 4, and 5, which is 4 seconds in total.

Example 2:

Input: timeSeries = [1,2], duration = 2
Output: 3
Explanation: Teemo's attacks on Ashe go as follows:
- At second 1, Teemo attacks, and Ashe is poisoned for seconds 1 and 2.
- At second 2 however, Teemo attacks again and resets the poison timer. Ashe is poisoned for seconds 2 and 3.
Ashe is poisoned for seconds 1, 2, and 3, which is 3 seconds in total.
"""
@pytest.mark.parametrize("timeSeries, duration, expected", [
    ([1,4], 2, 4), 
    ([1,2], 2, 3)
])
def test_findPoisonedDuration(timeSeries: List[int], duration: int, expected: int):
    result = Solution().findPoisonedDuration(timeSeries, duration)
    assert(result == expected) 

if __name__ == "__main__": 
    pytest.main([__file__])