import pytest
from collections import defaultdict

class Solution:
    def minReorder(self, n: int, connections: list[list[int]]) -> int:
        graph = defaultdict(list)
        for connection in connections: 
            x, y = connection
            graph[x].append(y)
            graph[y].append(x)

        routes = set()
        for row in connections: 
            x, y = row
            routes.add((x, y))

        result = 0
        def dfs(node: int):
            nonlocal result
            nonlocal seen 
            seen.add(node)
            for val in graph[node]: 
                path = (node, val)
                if not val in seen: 
                    if path in routes: 
                        result += 1
                    dfs(val)
        
        seen = set()
        dfs(0)
        return result         

"""
Example 1:
Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
Output: 3
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 2:
Input: n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
Output: 2
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 3:
Input: n = 3, connections = [[1,0],[2,0]]
Output: 0
"""
@pytest.mark.parametrize("n, connections, expected", [
    (6,[[0,1],[1,3],[2,3],[4,0],[4,5]],3), 
    (5,[[1,0],[1,2],[3,2],[3,4]],2), 
    (3,[[1,0],[2,0]],0)
])
def test_minReorder(n: int, connections: list[list[int]], expected: int):
    result = Solution().minReorder(n, connections)
    assert(result == expected)    

if __name__ == "__main__": 
    pytest.main([__file__])