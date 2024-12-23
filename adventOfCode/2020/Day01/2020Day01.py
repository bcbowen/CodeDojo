import pytest
from pathlib import Path

import sys
sys.path.append('adventOfCode/Modules')
from FileUtility import get_input_filepath

def load_input(file_name: str) -> list[int]: 
    path = get_input_filepath(file_name, __file__)
    with open(path, "r") as file: 
        return [int(line.strip()) for line in file.readlines()]

def part1(file_name: str) -> int: 
    values = load_input(file_name)
    for val1 in values: 
        val2 = 2020 - val1
        if val2 in values: 
            return val1 * val2
        
    raise Exception("Not found, dude!")

def part2(file_name: str) -> int: 
    values = load_input(file_name)
    for i in range(len(values) - 1): 
        for j in range(1, len(values)): 
            val1 = values[i]
            val2 = values[j]
            val3 = 2020 - val1 - val2
    
            if val3 in values: 
                return val1 * val2 * val3
        
    raise Exception("Not found, dude!")

def test_part1(): 
    expected = 514579
    result = part1("sample.txt")
    assert(result == expected)

def test_part2(): 
    expected = 241861950
    result = part2("sample.txt")
    assert(result == expected)

def test_load_input(): 
    values = load_input("sample.txt")
    assert(1721 in values)
    assert(len(values) == 6)

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result for {file_name}: {result}")
    result = part2(file_name)
    print(f"Part 2 result for {file_name}: {result}")

if __name__ == "__main__": 
    pytest.main([__file__])
    main()