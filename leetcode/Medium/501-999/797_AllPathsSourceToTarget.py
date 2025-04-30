import pytest 
from typing import List

class Solution:
    def allPathsSourceTarget(self, graph: List[List[int]]) -> List[List[int]]:
        adjacencyList = {} 
        for i in range(len(graph)):
            adjacencyList[i] = graph[i]
        paths = []
        def backtrack(node: int, path: List[int]): 
            if path[-1] == len(graph) - 1: 
                paths.append(path)
                return
            for nextNode in adjacencyList[node]:
                path.append(nextNode)
                backtrack(nextNode, path.copy())
                path.pop()
        backtrack(0, [0])
        return paths


"""
Example 1:
Input: graph = [[1,2],[3],[3],[]]
Output: [[0,1,3],[0,2,3]]
Explanation: There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.

Example 2:
Input: graph = [[4,3,1],[3,2,4],[3],[4],[]]
Output: [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]
"""
@pytest.mark.parametrize("graph, expected", [
    ([[1,2],[3],[3],[]], [[0,1,3],[0,2,3]]), 
    ([[4,3,1],[3,2,4],[3],[4],[]], [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]])
])
def test_allPathsSourceTarget(graph: List[List[int]], expected: List[List[int]]):
    result = Solution().allPathsSourceTarget(graph)
    assert(len(expected) == len(result))
    for path in result: 
        assert(path in expected)

if __name__ == "__main__": 
    pytest.main([__file__])