
import math
import pytest
from typing import List

class Solution:
    def maximumDetonation(self, bombs: List[List[int]]) -> int:
        # bomb 1 blast reached bomb 2 (center of bomb2 circle)
        def reaches_bomb(x1, y1, x2, y2, radius):
            distance = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
            return distance <= radius

        bomb_graph = {} 
        
        for i in range(len(bombs)): 
            if not i in bomb_graph: 
                        bomb_graph[i] = []
            for j in range(i + 1, len(bombs)): 
                xi, yi, ri = bombs[i]
                xj, yj, rj = bombs[j]
                # does bomb i blast reach bomb j? 
                if reaches_bomb(xi, yi, xj, yj, ri): 
                    bomb_graph[i].append(j)
                # does bomb j blast reach bomb i? 
                if reaches_bomb(xi, yi, xj, yj, rj): 
                    if not j in bomb_graph: 
                        bomb_graph[j] = [] 
                    bomb_graph[j].append(i)

        bomb_stack = [] 
        max_detonations = 0

        for bomb in bomb_graph: 
            detonations = 0
            bomb_stack.clear()
            bomb_stack.append(bomb)
            seen = set()
            seen.add(bomb)
            while bomb_stack: 
                current = bomb_stack.pop()
                detonations += 1
                for next in bomb_graph[current]: 
                    if not next in seen: 
                        seen.add(next) 
                        bomb_stack.append(next)
            max_detonations = max(max_detonations, detonations)

        return max_detonations
            



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


TC 62: 
bombs: [[54,95,4],[99,46,3],[29,21,3],[96,72,8],[49,43,3],[11,20,3],[2,57,1],[69,51,7],[97,1,10],[85,45,2],[38,47,1],[83,75,3],[65,59,3],[33,4,1],[32,10,2],[20,97,8],[35,37,3]]
expected: 1

"""
@pytest.mark.parametrize("bombs, expected", [
     ([[2,1,3],[6,1,4]], 2), 
     ([[1,1,5],[10,10,5]], 1), 
     ([[1,2,3],[2,3,1],[3,4,2],[4,5,3],[5,6,4]], 5), 
     ([[54,95,4],[99,46,3],[29,21,3],[96,72,8],[49,43,3],[11,20,3],[2,57,1],[69,51,7],[97,1,10],[85,45,2],[38,47,1],[83,75,3],[65,59,3],[33,4,1],[32,10,2],[20,97,8],[35,37,3]], 1)
])
def test_maximumDetonation(bombs: List[List[int]], expected: int):
    result = Solution().maximumDetonation(bombs)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 