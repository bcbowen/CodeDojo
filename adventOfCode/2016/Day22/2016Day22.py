import pytest
from typing import List, Tuple
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

class StorageNode: 
    def __init__(self, name: str, size: int, used: int, avail: int, use_pct: float): 
        self.name = name
        self.size = size
        self.used = used
        self.avail = avail
        self.use_pct = use_pct

    def get_position(self) -> Tuple[int, int]: 
        parts = self.name.split('-')
        x = int(parts[1][1:])
        y = int(parts[2][1:])
        return (x, y)  

# 38 col * 24 row
def load_input() -> List[List[StorageNode]]:

    lines = Modules.aoc_io.read_input(2016, 22, "input.txt").split('\n')
    
    temp_nodes : List[List[StorageNode | None ]]= [[None for _ in range(38)] for _ in range(24)]
    for line in lines[2:]: 
        parts = line.split()
        name = parts[0]
        size = int(parts[1][:-1])
        used = int(parts[2][:-1])
        avail = int(parts[3][:-1])
        use_pct = float(parts[4][:-1])
        node = StorageNode(name, size, used, avail, use_pct)
        col, row = node.get_position()
        temp_nodes[row][col] = node
        
    nodes : List[List[StorageNode]] = []
    for row in range(len(temp_nodes)):
        new_row = [] 
        for col in range(len(temp_nodes[0])): 
            new_row.append(temp_nodes[row][col])
        nodes.append(new_row)

    return nodes    

def part1(storage_nodes: List[List[StorageNode]]) -> int:
    count = 0
    for row in storage_nodes:
        for node_a in row:
            if node_a is None or node_a.used == 0:
                continue
            for other_row in storage_nodes:
                for node_b in other_row:
                    if node_b is None or node_a == node_b:
                        continue
                    if node_a.used <= node_b.avail:
                        count += 1

    return count

def part2(storage_nodes: List[List[StorageNode]]) -> int:
    row, col = find_empty_node(storage_nodes)
    return 3
    

def main(): 
    storage_nodes = load_input()
    result1 = part1(storage_nodes)
    print(f"Part 1: {result1}")
    # result2 = part2(storage_nodes)
    # print(f"Part 2: {result2}")


def find_empty_node(nodes: List[List[StorageNode]]) -> Tuple[int, int]: 
    for row in range(len(nodes)): 
        for col in range(len(nodes[0])): 
            if nodes[row][col].used == 0: 
                return (row, col)
    return (-1, -1)


def test_find_empty_node(): 
    nodes = load_input()
    assert(nodes != None)
    result = find_empty_node(nodes)
    expected = (21, 35)
    assert(result == expected)


def test_load_input(): 
    nodes = load_input()
    assert(nodes[0][0] is not None)
    assert(nodes[0][0].name == "/dev/grid/node-x0-y0")
    assert(nodes[0][0].size == 92)
    assert(nodes[0][0].used == 70)
    assert(nodes[0][0].avail == 22)
    assert(nodes[0][0].use_pct == 76.0)

    assert(nodes[23][37] is not None)
    assert(nodes[23][37].name == "/dev/grid/node-x37-y23")
    assert(nodes[23][37].size == 90)
    assert(nodes[23][37].used == 72)
    assert(nodes[23][37].avail == 18)
    assert(nodes[23][37].use_pct == 80)

if __name__ == "__main__":
    pytest.main([__file__])
    main()