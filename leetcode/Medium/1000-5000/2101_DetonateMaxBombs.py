
import math
import pytest
from typing import List

class Solution:
    def maximumDetonation(self, bombs: List[List[int]]) -> int:
        pass

def circles_overlap(x1, y1, r1, x2, y2, r2):
    distance = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
    return distance < (r1 + r2)

"""
Example 1:
Input: bombs = [[2,1,3],[6,1,4]]
Output: 2
Explanation:
The above figure shows the positions and ranges of the 2 bombs.
If we detonate the left bomb, the right bomb will not be affected.
But if we detonate the right bomb, both bombs will be detonated.
So the maximum bombs that can be detonated is max(1, 2) = 2.

Example 2:
Input: bombs = [[1,1,5],[10,10,5]]
Output: 1
Explanation:
Detonating either bomb will not detonate the other bomb, so the maximum number of bombs that can be detonated is 1.

Example 3:
Input: bombs = [[1,2,3],[2,3,1],[3,4,2],[4,5,3],[5,6,4]]
Output: 5
Explanation:
The best bomb to detonate is bomb 0 because:
- Bomb 0 detonates bombs 1 and 2. The red circle denotes the range of bomb 0.
- Bomb 2 detonates bomb 3. The blue circle denotes the range of bomb 2.
- Bomb 3 detonates bomb 4. The green circle denotes the range of bomb 3.
Thus all 5 bombs are detonated.
"""
@pytest.mark.parametrize("", [
     
])
def test_maximumDetonation(bombs: List[List[int]], expected: int):
        pass

if __name__ == "__main__":
    pytest.main([__file__]) 