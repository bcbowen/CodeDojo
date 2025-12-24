import pytest
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


def part1(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    

    return result   

def part2(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    

    return result   
  
def part3(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    

    return result   

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
    pass
    #assert(len(inputs) == 5)
    #print(inputs[0])

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = -1
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    result = part2(file_name)
    expected = -1
    assert(result == expected)

def test_part3(): 
    file_name = "sample.txt"
    result = part3(file_name)
    expected = -1
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()