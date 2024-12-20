import pytest
from pathlib import Path

class Node: 
    def __init__(self):
        self.is_final = False
        self.patterns = {}

    def add(self, value: str): 
        if value == "": 
            return
        
        if not value[0] in self.patterns: 
            self.patterns[value[0]] = Node()


        self.patterns[value[0]].add(value[1:])
        if len(value) == 1: 
            self.patterns[value[0]].is_final = True

    def find(self, value: str) -> bool: 
        if value == "": 
            return False
        if not value[0] in self.patterns: 
            return False
        elif len(value) == 1: 
            return self.patterns[value[0]].is_final
        else: 
            node = self.patterns[value[0]]
            return node.find(value[1:])


def get_input_filepath(file_name: str) -> str:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_input(file_name: str) -> tuple[Node, list[str]]: 
    trie = Node()
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        line = file.readline()
        for pattern in line.split(','): 
            trie.add(pattern.strip())
        file.readline() # blank
        designs = [line.strip() for line in file.readlines()]
        return (trie, designs)

def is_possible(trie: Node, design: str) -> bool: 
    return False

def part1(file_name: str) -> int: 
    trie, designs = load_input(file_name)
    result = 0
    for design in designs: 
        if is_possible(trie, design): 
            result += 1

    return result


@pytest.mark.parametrize("val, expected", [
    ("r", True),
    ("a", False),
    ("wr", True),
    ("bw", False), 
    ("bwu", True),
])
def test_trie_node_find(val: str, expected: bool): 
    trie = Node()
    trie.add("r")
    trie.add("wr")
    trie.add("b")
    trie.add("g")
    trie.add("bwu")
    trie.add("rb")
    trie.add("gb")
    trie.add("br")
    
    result = trie.find(val)
    assert(result == expected)

def test_load_inputs(): 
    file_name = "sample.txt"
    trie, designs = load_input(file_name)
    assert(trie.find("r") == True)
    assert(trie.find("br") == True)
    assert(trie.find("a") == False)

    assert(len(designs) == 8)
    assert(designs[1] == "bggr")

if __name__ == "__main__": 
    pytest.main([__file__])