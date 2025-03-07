import pytest
from collections import defaultdict

class Solution:
    def validPath(self, n: int, edges: list[list[int]], source: int, destination: int) -> bool:
        if source == destination: 
            return True
        
        graph = defaultdict(list)
        for edge in edges: 
            graph[edge[0]].append(edge[1])
            graph[edge[1]].append(edge[0])

        seen = [False] * n
        def dfs(val: int):
            if val == destination: 
                return True
            if not seen[val]: 
                seen[val] = True    
                for d in graph[val]: 
                    if dfs(d): 
                        return True
            return False
        
        return dfs(source) 
        

"""
Example 1:
Input: n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
Output: true
Explanation: There are two paths from vertex 0 to vertex 2:
- 0 → 1 → 2
- 0 → 2

Example 2:
Input: n = 6, edges = [[0,1],[0,2],[3,5],[5,4],[4,3]], source = 0, destination = 5
Output: false
Explanation: There is no path from vertex 0 to vertex 5.

10
[[4,3],[1,4],[4,8],[1,7],[6,4],[4,2],[7,4],[4,0],[0,9],[5,4]]
5
9
True

1
[]
0
0
True
"""
@pytest.mark.parametrize("n, edges, source, destination, expected", [
    (3, [[0,1],[1,2],[2,0]], 0, 2, True), 
    (6, [[0,1],[0,2],[3,5],[5,4],[4,3]], 0, 5, False), 
    (10, [[4,3],[1,4],[4,8],[1,7],[6,4],[4,2],[7,4],[4,0],[0,9],[5,4]], 5, 9, True), 
    (1, [], 0, 0, True)
])
def test_validPath(n: int, edges: list[list[int]], source: int, destination: int, expected: bool):
    result = Solution().validPath(n, edges, source, destination)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])