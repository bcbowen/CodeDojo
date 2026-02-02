import pytest
from typing import List
from pathlib import Path

def get_inputs(file_name: str) -> List[str]: 
    input = [] 
    current_path = Path(__file__).parent
    path = current_path / file_name
    with open(path, "r") as file:
        input = file.readlines() 
    
    return input


def part1(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    last = (0, 0)
    for line in inputs:
        x, y = line.strip().split(',')
        x = int(x)
        y = int(y.strip())

        result += abs(last[0] - x)
        result += abs(last[1] - y)
        last = (x, y)     


    return result   

def part2(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    last = (0, 0)
    for line in inputs:
        x, y = line.strip().split(',')
        x = int(x)
        y = int(y.strip())

        result += max(abs(last[1] - y), abs(last[0] - x))

        last = (x, y)     
   
    return result   
  
def part3(file_name: str) -> int: 
    result = 0
    inputs = get_inputs(file_name)
    last = (0, 0)
    inputs = sorted(inputs, key = lambda x: x[0] + x[1])
    for line in inputs:
        x, y = line.strip().split(',')
        x = int(x)
        y = int(y.strip())

        result += max(abs(last[1] - y), abs(last[0] - x))

        last = (x, y)     
   
    # 3445 too high
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
    assert(len(inputs) == 3)
    assert(inputs[0].strip() == "3,3")

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = 24
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    result = part2(file_name)
    expected = 12
    assert(result == expected)

def test_part3(): 
    file_name = "sample.txt"
    result = part3(file_name)
    expected = 9
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()