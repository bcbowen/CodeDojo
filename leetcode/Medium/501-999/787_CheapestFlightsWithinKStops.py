import heapq
import pytest
from typing import List

class Solution:
    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:
        flight_graph = {}
        for i in range(n): 
            flight_graph[i] = []

        for fm, to, price in flights: 
            flight_graph[fm].append((to, price))
        
        heap = []
        cheapest = float('inf')
        for to, price in flight_graph[src]:
            if to == dst: 
                cheapest = price
            heapq.heappush(heap, (to, price, 0, set([src, to])))

            
        while heap:
            to, price, hops, path = heapq.heappop(heap)
            if to == dst and hops <= k: 
                cheapest = min(cheapest, price)
            for next, next_price in flight_graph[to]: 
                new_hops = hops + 1
                if next not in path and new_hops <= k: 
                    new_path = path.copy() 
                    new_path.add(next)
                    heapq.heappush(heap, (next, price + next_price, new_hops, new_path))

        return int(cheapest) if cheapest < float('inf') else -1
    
       
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

TC 4: 
5
[[4,1,1],[1,2,3],[0,3,2],[0,4,10],[3,1,1],[1,4,3]]
2
1
1
 
"""
@pytest.mark.parametrize("n, flights, src, dst, k, expected", [
    (4, [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], 0, 3, 1, 700), 
    (3, [[0,1,100],[1,2,100],[0,2,500]], 0, 2, 1, 200), 
    (3, [[0,1,100],[1,2,100],[0,2,500]], 0, 2, 0, 500),
    (5, [[4,1,1],[1,2,3],[0,3,2],[0,4,10],[3,1,1],[1,4,3]], 2, 1, 1, -1)
])
def test_findCheapestPrice(n: int, flights: List[List[int]], src: int, dst: int, k: int, expected: int):
    result = Solution().findCheapestPrice(n, flights, src, dst, k)
    assert(result == expected)

def test_case_31_tle(): 
    n = 17
    flights = [[0,12,28],[5,6,39],[8,6,59],[13,15,7],[13,12,38],[10,12,35],[15,3,23],[7,11,26],[9,4,65],[10,2,38],[4,7,7],[14,15,31],[2,12,44],[8,10,34],[13,6,29],[5,14,89],[11,16,13],[7,3,46],[10,15,19],[12,4,58],[13,16,11],[16,4,76],[2,0,12],[15,0,22],[16,12,13],[7,1,29],[7,14,100],[16,1,14],[9,6,74],[11,1,73],[2,11,60],[10,11,85],[2,5,49],[3,4,17],[4,9,77],[16,3,47],[15,6,78],[14,1,90],[10,5,95],[1,11,30],[11,0,37],[10,4,86],[0,8,57],[6,14,68],[16,8,3],[13,0,65],[2,13,6],[5,13,5],[8,11,31],[6,10,20],[6,2,33],[9,1,3],[14,9,58],[12,3,19],[11,2,74],[12,14,48],[16,11,100],[3,12,38],[12,13,77],[10,9,99],[15,13,98],[15,12,71],[1,4,28],[7,0,83],[3,5,100],[8,9,14],[15,11,57],[3,6,65],[1,3,45],[14,7,74],[2,10,39],[4,8,73],[13,5,77],[10,0,43],[12,9,92],[8,2,26],[1,7,7],[9,12,10],[13,11,64],[8,13,80],[6,12,74],[9,7,35],[0,15,48],[3,7,87],[16,9,42],[5,16,64],[4,5,65],[15,14,70],[12,0,13],[16,14,52],[3,10,80],[14,11,85],[15,2,77],[4,11,19],[2,7,49],[10,7,78],[14,6,84],[13,7,50],[11,6,75],[5,10,46],[13,8,43],[9,10,49],[7,12,64],[0,10,76],[5,9,77],[8,3,28],[11,9,28],[12,16,87],[12,6,24],[9,15,94],[5,7,77],[4,10,18],[7,2,11],[9,5,41]]
    src = 13
    dst = 4
    k = 13
    expected = 4
    result = Solution().findCheapestPrice(n, flights, src, dst, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])