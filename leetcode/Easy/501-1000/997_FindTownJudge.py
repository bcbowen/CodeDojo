import pytest 

from typing import List

class Solution:
    def findJudge(self, n: int, trust: List[List[int]]) -> int:
        if len(trust) < n - 1: 
            return -1
        
        if len(trust) == 0: 
            return 1
        
        inbound = [0] * (n + 1)
        outbound = [0] * (n + 1)
        for edge in trust: 
            outbound[edge[0]] += 1
            inbound[edge[1]] += 1
        
        for i in range(n + 1): 
            if inbound[i] == n - 1 and outbound[i] == 0: 
                return i
        return -1
    

"""
Example 1:
Input: n = 2, trust = [[1,2]]
Output: 2

Example 2:
Input: n = 3, trust = [[1,3],[2,3]]
Output: 3

Example 3:
Input: n = 3, trust = [[1,3],[2,3],[3,1]]
Output: -1

TC 92
n = 1, trust = [], output = 1

"""
@pytest.mark.parametrize("n, trust, expected", [
    (2, [[1,2]], 2), 
    (3, [[1,3],[2,3]], 3), 
    (3, [[1,3],[2,3],[3,1]], -1), 
    (1, [], 1)
])
def test_findJudge(n: int, trust: List[List[int]], expected: int):
    result = Solution().findJudge(n, trust)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 