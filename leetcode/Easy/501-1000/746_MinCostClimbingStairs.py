import pytest
from typing import List
from collections import defaultdict

class Solution:
    

    # minCost(i) = min(mincost(i - 2) + cost[i - 2], mincost(i - 1) + cost[i - 1])
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        cache = defaultdict(int)
        
        def minCost(i: int) -> int: 
            min_next = 0
            if i in cache: 
                min_next =  cache[i]
            else: 
                if i <= 1: 
                    min_next = 0
                else:
                    min_next = min(minCost(i - 2) + cost[i - 2], minCost(i - 1) + cost[i - 1])
                cache[i] = min_next
            return min_next                
        
        return minCost(len(cost))

"""
Example 1:
Input: cost = [10,15,20]
Output: 15
Explanation: You will start at index 1.
- Pay 15 and climb two steps to reach the top.
The total cost is 15.
Example 2:

Input: cost = [1,100,1,1,1,100,1,1,100,1]
Output: 6
Explanation: You will start at index 0.
- Pay 1 and climb two steps to reach index 2.
- Pay 1 and climb two steps to reach index 4.
- Pay 1 and climb two steps to reach index 6.
- Pay 1 and climb one step to reach index 7.
- Pay 1 and climb two steps to reach index 9.
- Pay 1 and climb one step to reach the top.
The total cost is 6.
"""
@pytest.mark.parametrize("cost, expected", [
    ([10,15,20], 15), 
    ([1,100,1,1,1,100,1,1,100,1], 6)
])
def test_minCostClimbingStairs(cost: List[int], expected:  int):
    result = Solution().minCostClimbingStairs(cost)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])