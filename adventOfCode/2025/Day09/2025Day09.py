import pytest
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

def get_inputs(file_name: str) -> List[Tuple[int, int]]:
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        for line in file:
            a, b = map(int, line.strip().split(','))
            inputs.append((a, b))

    return inputs

def calc_area(corner1: Tuple[int, int], corner2: Tuple[int, int]) -> int: 
    if corner1[0] < corner2[0]: 
        left_corner = corner1
        right_corner = corner2
    else:
        left_corner = corner2
        right_corner = corner1
    
    return (right_corner[0] - left_corner[0] + 1 ) * (abs(right_corner[1] - left_corner[1]) + 1)

def part1(file_name: str) -> int: 
    max_area = 0
    inputs = get_inputs(file_name)
    for i in range(len(inputs) - 1): 
        for j in range(1, len(inputs)): 
            area = calc_area(inputs[i], inputs[j])
            max_area = max(max_area, area)
    return max_area


def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1: {result}")

def test_get_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert(len(inputs) == 8)
    assert(inputs[0] == (7, 1))

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = 50
    assert(result == expected)

@pytest.mark.parametrize("corner1, corner2, expected", [
    ((2, 5), (9, 7), 24), 
    ((7, 1), (11, 7), 35), 
    ((7, 3), (2, 3), 6), 
    ((2, 5), (11, 1), 50)
])
def test_calc_area(corner1: Tuple[int, int], corner2: Tuple[int, int], expected: int): 
    result = calc_area(corner1, corner2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()