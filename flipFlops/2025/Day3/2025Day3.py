import pytest
from enum import Enum
from typing import List, Tuple
from pathlib import Path

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    input_path = current_path / file_name
    return input_path

def get_inputs(file_name: str) -> List[Tuple[int, int, int]]: 
    inputs = [] 
    path = get_input_filepath(file_name)
    with open(path, "r") as file:
        for line in file: 
            inputs.append(tuple([int(v) for v in line.split(',')]))
    
    return inputs


def part1(file_name: str) -> Tuple[int, int, int]: 

    inputs = get_inputs(file_name)
    counts = {}
    max_count = 0
    max_result = (0, 0, 0)
    for input in inputs: 
        if not input in counts: 
            counts[input] = 0
        counts[input] += 1
        if counts[input] > max_count: 
            max_result = input
            max_count = counts[input]


    return max_result   

class Color(Enum): 
    Red = 1
    Green = 2
    Blue = 3
    Special = 10


def getColor(input: Tuple[int, int, int]) -> Color: 
    r, g, b = input
    if r == g or r == b or g == b: 
        return Color.Special
    if r > g and r > b: 
        return Color.Red
    if g > r and g > b: 
        return Color.Green
    return Color.Blue

"""
Red bushes are 5 Pointers
Green bushes are 2 Pointers
Blue bushes are 4 Pointers
Special bushes are 10 Pointers
"""
def getPrice(input: Tuple[int, int, int]) -> int: 
    match getColor(input): 
        case Color.Red: 
            return 5
        case Color.Green: 
            return 2
        case Color.Blue: 
            return 4
        case Color.Special: 
            return 10
        case _: 
            return 0

def part2(file_name: str) -> int: 
    inputs = get_inputs(file_name)
    green_count = 0

    for input in inputs: 
        if getColor(input) == Color.Green: 
            green_count += 1
    
    return green_count   
  
def part3(file_name: str) -> int: 
    inputs = get_inputs(file_name)
    total = 0

    for input in inputs: 
        total += getPrice(input)
    
    return total
    

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part1: {result}")

    result = part2(file_name)
    print(f"Part2: {result}")

    result = part3(file_name)
    print(f"Part3: {result}")


def test_load_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert(len(inputs) == 6)
    assert(inputs[0] == (10, 20, 30))
    

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = (10, 20, 30)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    result = part2(file_name)
    expected = 0
    assert(result == expected)

"""
10,20,30: Blue
20,10,30: Blue
30,20,10: Red
10,50,10: Special
50,10,50: Special
10,20,30: Blue
expected: 4 * 3 + 5 + 2 * 10 = 12 + 5 + 20 = 37
"""
def test_part3(): 
    file_name = "sample.txt"
    result = part3(file_name)
    expected = 37
    assert(result == expected)

@pytest.mark.parametrize("input, expected", [
    ((1, 2, 3), Color.Blue), 
    ((1, 3, 2), Color.Green), 
    ((3, 2, 1), Color.Red), 
    ((1, 2, 1), Color.Special), 
    ((1, 1, 1), Color.Special), 
    ((1, 1, 2), Color.Special), 
    ((2, 1, 1), Color.Special), 
])
def test_getColor(input: Tuple[int, int, int], expected: Color): 
    result = getColor(input)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()