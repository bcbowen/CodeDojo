import pytest
import re
from typing import List
from pathlib import Path

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    input_path = current_path / file_name
    return input_path

def get_inputs(file_name: str) -> List[str]: 
    inputs = [] 
    path = get_input_filepath(file_name)
    with open(path, "r") as file:
        inputs = file.readlines() 
    
    return inputs

def score_line(val: str) -> int: 
    pattern = "(ba|na|ne)"
    return len(re.findall(pattern, val))


def part1(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    for line in inputs: 
        result += score_line(line)

    return result     

def part2(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    for line in inputs: 
        score = score_line(line)
        if score % 2 == 0: 
            result += score

    return result   
  
def part3(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    for line in inputs: 
        if not 'ne' in line: 
            result += score_line(line)

    return result   

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part1: {result}")

    result = part2(file_name)
    print(f"Part2: {result}")

    result = part3(file_name)
    print(f"Part3: {result}")

"""
banana       (3) 
banenanana   (5)
bananana     (4)
bananananana (6)
bananananana (6)
"""
@pytest.mark.parametrize("line, expected", [
    ("banana", 3),
    ("banenanana", 5),
    ("bananana", 4),
    ("bananananana", 6),
    ("bananananana", 6), 
])
def test_score_line(line: str, expected: int):
    result = score_line(line)
    assert(result == expected)

def test_load_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert(len(inputs) == 5)
    #print(inputs[0])

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = 24
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    result = part2(file_name)
    expected = 16
    assert(result == expected)

def test_part3(): 
    file_name = "sample.txt"
    result = part3(file_name)
    expected = 19
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()