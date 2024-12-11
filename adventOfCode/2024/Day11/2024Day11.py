import pytest
from pathlib import Path 

class NodeList: 
    def __init__(self, head: 'Node'): 
        self.head = head
        self.tail = head
        self.len = 1

    def append(self, node: 'Node'): 
        self.tail.next = node
        self.tail = node
        self.len += 1

    def blink(self): 
        current = self.head
        last = current
        while current != None: 
            if current.val == 0: 
                current.val = 1
            elif len(str(current.val)) % 2 == 0: 
                s = str(current.val)
                half_size = len(s) // 2
                node = Node(int(s[0:half_size]))
                node.next = Node(int(s[half_size:]))
                self.len += 1
                if current != self.head: 
                    last.next = node
                else: 
                    self.head = node
                node.next.next = current.next
                current = node.next
            else: 
                current.val *= 2024

            last = current
            current = current.next
        
    """
    Parse NodeList from space delimited string
    """
    def parse(line: str) -> 'NodeList': 
        values = list(map(int, line.strip().split(' ')))
        head = Node(values[0])
        node_list = NodeList(head)
        for val in values[1:]:
            node_list.append(Node(val))
        return node_list


class Node: 
        
    def __init__(self, val: int, next: 'Node' = None): 
        self.val = val
        self.next = next

def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_input_values(file_name: str) -> str: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        line = file.readline().strip()
    
    return line

"""
part1 works fine with 25 iterations. Part 2 asks for 75 iterations, but we CAN'T use the same approach
Need to completely refactor for part 2. 
"""
def part1(): 
    file_name = "input.txt"
    input = load_input_values(file_name)
    node_list = NodeList.parse(input)
    for i in range(25): 
        node_list.blink()
    print(f"Part 1: len after 25 iterations: {node_list.len}")

@pytest.mark.parametrize("line, expected, expected_len", [
    ("125 17", [125, 17], 2), 
    ("253000 1 7", [253000, 1, 7], 3), 
    ("253 0 2024 14168", [253, 0, 2024, 14168], 4), 
    ("512072 1 20 24 28676032", [512072, 1, 20, 24, 28676032], 5), 
    ("512 72 2024 2 0 2 4 2867 6032", [512, 72, 2024, 2, 0, 2, 4, 2867, 6032], 9), 
    ("1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32", [1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32], 13), 
    ("2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2", [2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2], 22)
])
def test_load(line : str, expected : list[int], expected_len: int): 
    node_list = NodeList.parse(line)
    assert(node_list.len == expected_len)
    assert(nodes_match(node_list, expected))

@pytest.mark.parametrize("line, expected, expected_len", [
    ("125 17", [253000, 1, 7], 3), 
    ("253000 1 7", [253, 0, 2024, 14168], 4), 
    ("253 0 2024 14168", [512072, 1, 20, 24, 28676032], 5), 
    ("512072 1 20 24 28676032", [512, 72, 2024, 2, 0, 2, 4, 2867, 6032], 9), 
    ("512 72 2024 2 0 2 4 2867 6032", [1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32], 13), 
    ("1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32", [2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2], 22) 
])
def test_blink(line : str, expected : list[int], expected_len: int): 
    node_list = NodeList.parse(line)
    node_list.blink() 
    assert(node_list.len == expected_len)
    assert(nodes_match(node_list, expected))

@pytest.mark.parametrize("iterations, expected_size", [
    (1, 3), 
    (2, 4), 
    (3, 5), 
    (4, 9), 
    (5, 13), 
    (6, 22), 
    (25, 55312)
])
def test_growth(iterations : int, expected_size : int): 
    values = "125 17"
    node_list = NodeList.parse(values)
    for i in range(iterations): 
        node_list.blink()
    assert(node_list.len == expected_size)


def nodes_match(node_list : NodeList, vals: list[int]) -> bool: 
    current = node_list.head
    i = 0
    while current != None: 
        if current.val != vals[i]: 
            return False
        i += 1
        current = current.next
    if  i != len(vals): 
        return False
    return True

def test_load_node_list(): 
    file_name = "input.txt"
    values = load_input_values(file_name)
    expected = "9759 0 256219 60 1175776 113 6 92833"
    assert(values == expected)



if __name__ == "__main__": 
    pytest.main([__file__])
    part1()
