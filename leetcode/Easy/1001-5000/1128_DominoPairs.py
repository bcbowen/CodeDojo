import pytest
from typing import List

class Solution:
    def numEquivDominoPairs(self, dominoes: List[List[int]]) -> int:
        
        vals = [0] * 100
        pair_count = 0
        for domino in dominoes: 
            if domino[0] > domino[1]: 
                x = domino[0] * 10
                y = domino[1]
            else: 
                x = domino[1] * 10
                y = domino[0]
            index = x + y
            pair_count += vals[index]
            vals[index] += 1
        return pair_count

        """
        count = 1
        dominoSet = set() 
        for domino in dominoes:
            domino.sort()
            if tuple(domino) in dominoSet: 
                count += 1
            else: 
                dominoSet.add(tuple(domino))

        return int(count * (count - 1)/2)
        """
    

"""
Example 1:
Input: dominoes = [[1,2],[2,1],[3,4],[5,6]]
Output: 1

Example 2:
Input: dominoes = [[1,2],[1,2],[1,1],[1,2],[2,2]]
Output: 3
"""
@pytest.mark.parametrize("dominoes, expected", [
    ([[1,2],[2,1],[3,4],[5,6]], 1), 
    ([[1,2],[1,2],[1,1],[1,2],[2,2]], 3), 
    ([[1,1],[2,2],[1,1],[1,2],[1,2],[1,1]], 4)
])
def test_numEquivDominoPairs(dominoes: List[List[int]], expected: int):
    result = Solution().numEquivDominoPairs(dominoes)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 