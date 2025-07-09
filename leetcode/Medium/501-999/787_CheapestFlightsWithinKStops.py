import heapq
import pytest
from typing import List

class Solution:
    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:
        if k == 0: 
            return -1
        
        flight_graph = {}
        for fm, to, price in flights: 
            if not fm in flight_graph: 
                flight_graph[fm] = []
            flight_graph[flights[fm]].append((to, price))
        
        heap = []
        cheapest = -1
        for to, price in flight_graph[src]:
            if to == dst: 
                cheapest = price
            heapq.heappush(heap, (to, price, 1))
            
        while heap:
            to, price, hops = heapq.heappop(heap)
            if to == dst and hops <= k: 
                cheapest = min(cheapest, price)
            for next, next_price in flight_graph[to]: 
                heapq.heappush(heap, (next, price + next_price, hops + 1))

        return cheapest
    
       
"""
Example 1:
Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1
Output: 700
Explanation:
The graph is shown above.
The optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.
Note that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.

Example 2:
Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1
Output: 200
Explanation:
The graph is shown above.
The optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.

Example 3:
Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0
Output: 500
Explanation:
The graph is shown above.
The optimal path with no stops from city 0 to 2 is marked in red and has cost 500.
 
"""
@pytest.mark.parametrize("n, flights, src, dst, k, expected", [
    (4, [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], 0, 3, 1, 700), 
    (3, [[0,1,100],[1,2,100],[0,2,500]], 0, 2, 1, 200), 
    (3, [[0,1,100],[1,2,100],[0,2,500]], 0, 2, 0, 500)
])
def test_findCheapestPrice(n: int, flights: List[List[int]], src: int, dst: int, k: int, expected: int):
    result = Solution().findCheapestPrice(n, flights, src, dst, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])