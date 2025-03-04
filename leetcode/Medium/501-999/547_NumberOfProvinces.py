import pytest
from collections import defaultdict

class Solution:
    def findCircleNum(self, isConnected: list[list[int]]) -> int:
        graph = defaultdict(list[int])
        seen = set()
        num_groups = 0
        def dfs(node: int):
            for val in graph[node]: 
                if not val in seen: 
                    seen.add(node)
                    dfs(val)
            
        n = len(isConnected)
        for i in range(n): 
            for j in range(1, n):
                if isConnected[i][j]: 
                    graph[i].append(j)
                    graph[j].append(i) 

        for val in range(n):
            if val not in seen: 
                num_groups += 1
                seen.add(val) 
                dfs(val)
        return num_groups
"""
Example 1:
Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
Output: 2

Example 2:
Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3
"""
@pytest.mark.parametrize("isConnected, expected", [
    ([[1,1,0],[1,1,0],[0,0,1]], 2), 
    ([[1,0,0],[0,1,0],[0,0,1]], 3)
])
def test_findCircleNum(isConnected: list[list[int]], expected: int):
    result = Solution().findCircleNum(isConnected)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 