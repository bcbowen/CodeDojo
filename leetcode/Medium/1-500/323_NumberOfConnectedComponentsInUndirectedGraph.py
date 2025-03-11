import pytest

class UnionFind: 
    def __init__(self, n: int): 
        self.root = list(range(n))
        self.rank = [1] * n
        self.component_count = n

    def find(self, i: int) -> int: 
        if self.root[i] == i: 
            return i
        
        return self.find(self.root[i])
    
    def is_connected(self, i: int, j: int) -> bool: 
        return self.find(i) == self.find(j)
        
    def union(self, i: int, j: int): 
        if self.is_connected(i, j): 
            return 

        i_root = self.find(i)
        j_root = self.find(j)

        if self.rank[i_root] >= self.rank[j_root]: 
            self.root[j_root] = self.root[i_root]
        else: 
            self.root[i_root] = self.root[j_root]
        self.component_count -= 1

class Solution:
    def countComponents(self, n: int, edges: list[list[int]]) -> int:
        uf = UnionFind(n)
        for x, y in edges: 
            uf.union(x, y)
        return uf.component_count


"""
Input: n = 5, edges = [[0,1],[1,2],[3,4]]
Output: 2

Input: n = 5, edges = [[0,1],[1,2],[2,3],[3,4]]
Output: 1
"""
@pytest.mark.parametrize("n, edges, expected", [
    (5, [[0,1],[1,2],[3,4]], 2), 
    (5, [[0,1],[1,2],[2,3],[3,4]], 1)
])
def test_countComponents(n: int, edges: list[list[int]], expected: int):
    result = Solution().countComponents(n, edges)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])