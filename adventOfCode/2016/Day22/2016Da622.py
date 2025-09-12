import pytest
from typing import List, Tuple
from pathlib import Path

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


def get_input_filepath(file_name: str) -> Path:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

# 38 col * 24 row
def load_input() -> List[List[StorageNode | None]]:

    path = get_input_filepath("input.txt")
    with open(path, 'r') as f: 
        lines = f.readlines()
    nodes : List[List[StorageNode | None]] = [[None for _ in range(38)] for _ in range(24)]
    for line in lines[2:]: 
        parts = line.split()
        name = parts[0]
        size = int(parts[1][:-1])
        used = int(parts[2][:-1])
        avail = int(parts[3][:-1])
        use_pct = float(parts[4][:-1])
        node = StorageNode(name, size, used, avail, use_pct)
        col, row = node.get_position()
        nodes[row][col] = node
        

    return nodes    

def main(): 
    pass


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