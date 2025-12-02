import pytest
from collections import defaultdict
from typing import List, Tuple
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

# return new_pos, number of times past zero
def move2(input: str, pos: int) -> Tuple[int, int]: 
    
    # dist, times past zero
    def parse_distance() -> Tuple[int, int]: 
        dist = int(input[1:])
        passes = dist // 100
        return (dist % 100, passes)

    def move_left() -> Tuple[int, int]: 
        dist, passes = parse_distance()
        new_pos = pos - dist
        if new_pos < 0: 
            new_pos = 100 + new_pos
            if pos != 0: 
                passes += 1
        elif new_pos == 0: 
            passes += 1

        return (new_pos, passes)
    
    def move_right() -> Tuple[int, int]: 
        dist, passes = parse_distance()
        new_pos = pos + dist
        if new_pos >= 100: 
            new_pos = new_pos - 100
            if pos != 0: 
                passes += 1
        elif new_pos == 0: 
            passes += 1

        return (new_pos, passes)

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
    zero_count = 0
    inputs = load_inputs(file_name)
    pos = 50
    for input in inputs: 
        new_pos, passes = move2(input, pos)
        zero_count += passes
        pos = new_pos

    return zero_count


def main(): 
    result = part1("input.txt")
    print(f"Part 1 result: {result}")

    result = part2("input.txt")
    print(f"Part 2 result: {result}")



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

"""
The dial starts by pointing at 50.
* The dial is rotated L68 to point at 82; during this rotation, it points at 0 once.
The dial is rotated L30 to point at 52.
* The dial is rotated R48 to point at 0.
The dial is rotated L5 to point at 95.
* The dial is rotated R60 to point at 55; during this rotation, it points at 0 once.
* The dial is rotated L55 to point at 0.
The dial is rotated L1 to point at 99.
* The dial is rotated L99 to point at 0.
The dial is rotated R14 to point at 14.
* The dial is rotated L82 to point at 32; during this rotation, it points at 0 once.
"""

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

@pytest.mark.parametrize("input, pos, expected_pos, expected_passes", [
     ("R1", 50, 51, 0), 
     ("R10", 50, 60, 0), 
     ("L1", 50, 49, 0), 
     ("L10", 50, 40, 0), 
     ("R1", 99, 0, 1), 
     ("L1", 0, 99, 0), 
     ("R50", 50, 0, 1), 
     ("L51", 50, 99, 1), 
     ("R101", 50, 51, 1), 
     ("R110", 50, 60, 1), 
     ("L101", 50, 49, 1), 
     ("L110", 50, 40, 1), 
     ("R1000", 50, 50, 10)

])
def test_move2(input: str, pos: int, expected_pos: int, expected_passes: int):
     new_pos, passes = move2(input, pos)
     assert((new_pos, passes) == (expected_pos, expected_passes))

if __name__ == "__main__":
    pytest.main([__file__])
    main()