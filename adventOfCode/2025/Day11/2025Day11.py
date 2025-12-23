import pytest
from typing import Dict, List, Set
from pathlib import Path

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

"""
aaa: you hhh
you: bbb ccc
bbb: ddd eee
ccc: ddd eee fff
ddd: ggg
eee: out
fff: out
ggg: out
hhh: ccc fff iii
iii: out
"""
def get_inputs(file_name: str) -> Dict[str, List[str]]: 
    inputs = {} 
    path = get_input_filepath(file_name)
    with open(path, "r") as file:
        for line in file: 
            fields = line.strip().split(':')
            if len(fields) == 2: 
                inputs[fields[0].strip()] = [v.strip() for v in fields[1].split(' ') if v != '']
    return inputs

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1: {result}")

    result = part2(file_name)
    print(f"Part 2: {result}")

def part1(file_name: str) -> int:
    inputs = get_inputs(file_name)
    paths = 0

    def backtrack(key: str, visited: Set[str]): 
        nonlocal paths
        if 'out' in inputs[key]: 
            paths += 1
            return
        for dest in inputs[key]: 
            if dest not in visited: 
                v = visited.copy()
                v.add(dest)
                backtrack(dest, v)
    start = "you"
    v = set([start])        
    backtrack(start, v)

    return paths 

def part2(file_name: str) -> int:
    inputs = get_inputs(file_name)
    paths = 0

    def backtrack(key: str, visited: Set[str]): 
        nonlocal paths
        if 'out' in inputs[key]:
            if 'dac' in visited and 'fft' in visited:  
                paths += 1
            return
        for dest in inputs[key]: 
            if dest not in visited: 
                v = visited.copy()
                v.add(dest)
                backtrack(dest, v)
    start = "svr"
    v = set([start])        
    backtrack(start, v)

    return paths 

def test_part1(): 
    file_name = "sample.txt"
    expected = 5
    result = part1(file_name)

def test_part2(): 
    file_name = "sample2.txt"
    expected = 2
    result = part2(file_name)

def test_load_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert(inputs["aaa"] == ["you", "hhh"])
    assert(inputs['hhh'] == ["ccc", "fff", "iii"])

if __name__ == "__main__":
    pytest.main([__file__])
    main()