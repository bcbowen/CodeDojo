import json
import pytest
import time
from collections import defaultdict
from collections import deque
from pathlib import Path

class Solution:
    def reachableNodes(self, n: int, edges: list[list[int]], restricted: list[int]) -> int:
        graph = defaultdict(list)
        seen = set()
        restricted = set(restricted)
        for source, dest in edges: 
            if not source in restricted and not dest in restricted: 
                graph[source].append(dest)
                graph[dest].append(source)

        queue = deque([0])
        seen.add(0)
        count = 0
        while queue: 
            node = queue.popleft() 
            count += 1
            for next_node in graph[node]: 
                if not next_node in restricted and not next_node in seen: 
                    queue.append(next_node)
                    seen.add(next_node)
        return count

"""
1: 
Input: n = 7, edges = [[0,1],[1,2],[3,1],[4,0],[0,5],[5,6]], restricted = [4,5]
Output: 4
Explanation: The diagram above shows the tree.
We have that [0,1,2,3] are the only nodes that can be reached from node 0 without visiting a restricted node.

2: 
Input: n = 7, edges = [[0,1],[0,2],[0,5],[0,4],[3,2],[6,5]], restricted = [4,2,1]
Output: 3
Explanation: The diagram above shows the tree.
We have that [0,5,6] are the only nodes that can be reached from node 0 without visiting a restricted node.
"""
@pytest.mark.parametrize("n, edges, restricted, expected", [
    (7, [[0,1],[1,2],[3,1],[4,0],[0,5],[5,6]], [4,5], 4),
    (7, [[0,1],[0,2],[0,5],[0,4],[3,2],[6,5]], [4,2,1], 3)
])
def test_reachableNodes(n: int, edges: list[list[int]], restricted: list[int], expected: int):
    result = Solution().reachableNodes(n, edges, restricted)
    assert(result == expected)

def test_biginput61(): 
    data_path = Path(__file__).parent.parent.parent / "Data"
    file_name = "2368_61.txt"    
    path = data_path / file_name
    with open(path, "r") as file: 
        n = int(file.readline().strip())
        edges = json.loads(file.readline())
        restricted = json.loads(file.readline())

    expected = 1
    start_time = time.perf_counter()  # Start the timer
    result = Solution().reachableNodes(n, edges, restricted)
    end_time = time.perf_counter()    # Stop the timer

    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.6f} seconds")
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
