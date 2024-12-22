import pytest
from pathlib import Path

"""
First attempt: Use quick implementation of a trie to store the patterns. 
Worked good for part 1 but when I adjusted for part 2 it runs forever. 


"""
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

def possible_combo_count(trie: Node, design: str) -> int: 
    def find_combos(trie: Node, s: str) -> int: 
        if not s: 
            return 1

        total = 0
        for i in range(1, len(s) + 1):
            prefix = s[:i]
            if trie.find(prefix): 
                total += find_combos(trie, s[i:]) 

        return total

def part1(file_name: str) -> int: 
    trie, designs = load_input(file_name)
    result = 0
    for design in designs: 
        if possible_combo_count(trie, design) > 0: 
            result += 1

    return result

def part2(file_name: str) -> int: 
    trie, designs = load_input(file_name)
    result = 0
    for design in designs: 
        result += possible_combo_count(trie, design)
        
    return result

def test_part1(): 
    file_name = "sample.txt"
    expected = 6
    result = part1(file_name)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 16
    result = part2(file_name)
    assert(result == expected)


@pytest.mark.parametrize("value, expected", [
    ("brwrr", 2), 
    ("bggr", 1),
    ("gbbr", 4),
    ("rrbgbr", 6),
    ("ubwu", 0),
    ("bwurrg", 1),
    ("brgr", 2),
    ("bbrgwb", 0)
])
def test_possible_combo_count(value : str, expected: int): 
    file_name = "sample.txt"
    trie, _ = load_input(file_name)
    result = possible_combo_count(trie, value)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 16
    result = part2(file_name)
    assert(result == expected)

@pytest.mark.parametrize("value, expected", [
    ("brwrr", True), 
    ("bggr", True),
    ("gbbr", True),
    ("rrbgbr", True),
    ("ubwu", False),
    ("bwurrg", True),
    ("brgr", True),
    ("bbrgwb", False)
])
def test_is_possible(value : str, expected: bool): 
    file_name = "sample.txt"
    trie, _ = load_input(file_name)
    result = possible_combo_count(trie, value) > 0
    assert(result == expected)

def test_is_possible2(): 
    trie = Node()
    trie.add("gw")
    trie.add("bub")
    trie.add("rur")
    trie.add("rr")
    trie.add("rrw")
    trie.add("g")
    trie.add("wb")
    trie.add("ubr")
    trie.add("urrr")
    expected = True
    design = "gwbubrurrrw"
    result = possible_combo_count(trie, design) > 0
    assert(result == expected)
    
    

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

# 400 is too high
def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result for {file_name}: {result}")

if __name__ == "__main__": 
    pytest.main([__file__])
    # Don't uncomment the call to main, it will run forever... need to refactor for part 2
    #main()