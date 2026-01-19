import math
import pytest
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io
from typing import List, Tuple

"""
borrowed this approach (with thanks) from hyperneutrino: 
https://www.youtube.com/watch?v=Rd7c4Wx7QDg
"""

"""
    Return boxes from input (x, y, z) and all edges, sorted by dist (i, j)
    Edges are index of bozes
"""
def get_inputs(file_name: str) -> Tuple[List[Tuple[int, ...]], List[Tuple[int, int]]]:  
    boxes : List[Tuple[int, ...]] = [
        tuple(int(i) for i in line.strip().split(',')) for line in Modules.aoc_io.read_input(2025, 8, file_name).split('\n')
    ]
    edges : List[Tuple[int, int]] = [(i, j) for i in range(len(boxes) - 1) for j in range(i + 1, len(boxes))]
    edges.sort(key = lambda x: math.hypot(*[x - y for x, y in zip(boxes[x[0]], boxes[x[1]])]))
    return (boxes, edges)

def main():
    file_name = "input.txt"
    result = part1(file_name, 1000, 3)
    print(f"Part 1: {result}")

    result = part2(file_name)
    print(f"Part 2: {result}")

def part1(file_name: str, connection_count: int, rank: int) -> int: 
    boxes, edges = get_inputs(file_name)

    # parent of each node, initially each node is its own parent
    parent = list(range(len(boxes)))

    def root(x): 
        if (parent[x] == x): 
            return x
        parent[x] = root(parent[x])
        return parent[x]
    
    def merge(a, b): 
        parent[root(a)] = root(b)


    for a, b in edges[:connection_count]: 
        merge(a, b)

    sizes = [0] * len(boxes)

    for box in range(len(boxes)): 
        sizes[root(box)] += 1
    
    sizes.sort(reverse = True)

    return math.prod(sizes[0: rank])


def part2(file_name: str) -> int: 
    boxes, edges = get_inputs(file_name)

    # parent of each node, initially each node is its own parent
    parent = list(range(len(boxes)))

    def root(x): 
        if (parent[x] == x): 
            return x
        parent[x] = root(parent[x])
        return parent[x]
    
    def merge(a, b): 
        parent[root(a)] = root(b)


    circuits = len(boxes)
    for a, b in edges:
        if root(a) == root(b): 
            continue 
        merge(a, b)
        circuits -= 1
        if circuits == 1: 
            return boxes[a][0] * boxes[b][0]
    
    return -1

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name, 10, 3)
    expected = 40
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 25272
    result = part2(file_name)
    assert(result == expected)

def test_get_inputs(): 
    file_name = "sample.txt"
    boxes, edges = get_inputs(file_name)
    assert(len(boxes) == 20)
    assert(edges[0] == (0, 19))

if __name__ == "__main__":
    pytest.main([__file__])
    main()