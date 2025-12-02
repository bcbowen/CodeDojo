import pytest
from collections import defaultdict
from typing import List
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

def load_inputs(file_name: str) -> List[str]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
         inputs = [l.strip('\n') for l in file.readlines()]
    return inputs

def move(input: str, pos: int) -> int: 
     
    def parse_distance() -> int: 
        dist = int(input[1:])
        return dist % 100

    def move_left() -> int: 
        dist = parse_distance()
        new_pos = pos - dist
        return new_pos if new_pos >= 0 else 100 + new_pos
    
    def move_right() -> int: 
        dist = parse_distance()
        new_pos = pos + dist
        return new_pos if new_pos < 100 else new_pos - 100

    direction = input[0]
    if direction == 'R': 
        return move_right()
    else: 
        return move_left()

def part1(file_name: str) -> int: 
    counts = defaultdict(int)
    inputs = load_inputs(file_name)
    pos = 50
    for input in inputs: 
        new_pos = move(input, pos)
        counts[new_pos] += 1
        pos = new_pos

    return counts[0]

def part2(file_name: str) -> int:
    return 1 

def main(): 
    result = part1("input.txt")
    print(f"Part 1 result: {result}")


def test_load_inputs(): 
    file_name = "sample.txt"
    inputs = load_inputs(file_name)
    assert(len(inputs) == 10)
    assert(inputs[0] == "L68")

def test_part1(): 
    expected = 3
    file_name = "sample.txt"
    result = part1(file_name)
    assert(expected == result)

def test_part2(): 
    expected = 6
    file_name = "sample.txt"
    result = part2(file_name)
    assert(expected == result)

@pytest.mark.parametrize("input, pos, expected", [
     ("R1", 50, 51), 
     ("R10", 50, 60), 
     ("L1", 50, 49), 
     ("L10", 50, 40), 
     ("R1", 99, 0), 
     ("L1", 0, 99), 
     ("R50", 50, 0), 
     ("L51", 50, 99), 
     ("R101", 50, 51), 
     ("R110", 50, 60), 
     ("L101", 50, 49), 
     ("L110", 50, 40)

])
def test_move(input: str, pos: int, expected: int):
     result = move(input, pos)
     assert(result == expected) 

if __name__ == "__main__":
    pytest.main([__file__])
    main()