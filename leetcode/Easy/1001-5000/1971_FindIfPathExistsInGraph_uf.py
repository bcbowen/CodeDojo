import pytest

class UnionFind:
    def __init__(self, len: int):  
        self.root = list(range(len)) 
        self.rank = [1] * len
    
    def find(self, i: int) -> int: 
        if self.root[i] == i: 
            return i
        
        return self.find(self.root[i])
    
    def is_connected(self, i: int, j: int) -> bool: 
        return self.find(i) == self.find(j)

    def union(self, i: int, j: int):
        if self.is_connected(i, j): 
            return
        root_i = self.find(i)
        root_j = self.find(j)
        if self.rank[root_i] >= self.rank[root_j]: 
            self.root[root_j] = self.root[root_i]
            self.rank[root_i] += self.rank[root_j]
        else: 
            self.root[root_i] = self.root[root_j]
            self.rank[root_j] += self.rank[root_i]

class Solution:
    def validPath(self, n: int, edges: list[list[int]], source: int, destination: int) -> bool:
        if source == destination: 
            return True
        
        uf = UnionFind(n)
        for x, y in edges: 
            uf.union(x, y)
            #if (source in [x, y] or destination in [x, y]) and uf.is_connected(source, destination): 
            #    return True
        return uf.is_connected(source, destination) 
        

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

6
[[0,1],[2,3],[4,5],[3,4],[1,2]]
0
5
true
"""
@pytest.mark.parametrize("n, edges, source, destination, expected", [

    (6, [[0,1],[2,3],[4,5],[3,4],[1,2]], 0, 5, True), 
    (6, [[0,1],[0,2],[3,5],[5,4],[4,3]], 0, 5, False), 
    (10, [[4,3],[1,4],[4,8],[1,7],[6,4],[4,2],[7,4],[4,0],[0,9],[5,4]], 5, 9, True), 
    (1, [], 0, 0, True), 
    (3, [[0,1],[1,2],[2,0]], 0, 2, True)
])
def test_validPath(n: int, edges: list[list[int]], source: int, destination: int, expected: bool):
    result = Solution().validPath(n, edges, source, destination)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])