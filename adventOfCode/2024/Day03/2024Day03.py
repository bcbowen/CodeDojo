import pytest
import re

from pathlib import Path

def get_input_filepath(file_name: str) -> str: 
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files 
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"
    
    input_path = private_files_base / year / day / file_name
    return input_path

def get_input(file_name: str) -> str: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        input = file.read()
    
    return input


def get_total(file_name : str) -> int: 
    #pattern = r"(mul\((\d+),(\d+)\))"
    pattern = r"mul\((\d+),(\d+)\)"
    input = get_input(file_name)
    #matches = re.match(pattern, input)
    total = 0
    for match in re.finditer(pattern, input): 
        num1, num2 = map(int, match.groups())
        total += num1 * num2
    return total

def get_total2(file_name : str) -> int: 
    #pattern = r"(mul\((\d+),(\d+)\))"
    pattern = r"(mul\((\d+),(\d+)\)|do\(\)|don't\(\))"
    input = get_input(file_name)
    #matches = re.match(pattern, input)
    total = 0
    processing = True
    for match in re.finditer(pattern, input): 
        full_match = match.group(1) # full matched text
        if full_match == "do()": 
            processing = True
        elif full_match == "don't()": 
            processing = False
        elif full_match.startswith("mul(") and processing: 
            num1, num2 = map(int, match.groups()[1:3])
            total += num1 * num2
    return total

def main(): 
    file_name = "sample.txt"
    result = get_total(file_name)
    print(f"Part 1 sample: {result}")
    file_name = "input.txt"
    result = get_total(file_name)
    print(f"Part 1 result: {result}")
    file_name = "sample_part2.txt"
    result = get_total2(file_name)
    print(f"Part 2 sample: {result}")
    file_name = "input.txt"
    result = get_total2(file_name)
    print(f"Part 2 result: {result}")

def test_part1(): 
    expected = 161
    file_name = "sample.txt"
    result = get_total(file_name)
    assert(expected == result)

def test_part2(): 
    expected = 48
    file_name = "sample_part2.txt"
    result = get_total(file_name)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])
    main()
