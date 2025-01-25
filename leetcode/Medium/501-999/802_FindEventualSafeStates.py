import pytest

class Solution:
    def eventualSafeNodes(self, graph: list[list[int]]) -> list[int]:
        terminal_nodes = [] 
        for i in range(len(graph)): 
            if len(graph[i]) == 0: 
                terminal_nodes.append(i)
        
        safe_nodes = []
        for i in range(len(graph)): 
            for j in graph[i]: 
                if j not in term



@pytest.mark.parametrize("graph, expected", [
    ([[1,2],[2,3],[5],[0],[5],[],[]], [2,4,5,6]), 
    ([[1,2,3,4],[1,2],[3,4],[0,4],[]], [4])
])
def test_eventualSafeNodes( graph: list[list[int]], expected: list[int]): 
    s = Solution()
    result = s.eventualSafeNodes(graph)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])