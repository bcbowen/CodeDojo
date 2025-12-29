import pytest
from typing import List
from pathlib import Path

def get_inputs(file_name: str) -> str: 
    input = "" 
    current_path = Path(__file__).parent
    path = current_path / file_name
    with open(path, "r") as file:
        input = file.readline() 
    
    return input


def part1(file_name: str) -> int: 
    max_height = 0
    height = 0
    input = get_inputs(file_name)
    for c in input: 
        match c: 
            case 'v': 
                height -= 1
            case '^': 
                height += 1
                max_height = max(height, max_height)
    return max_height


def part2(file_name: str) -> int: 
    max_height = 0
    input = get_inputs(file_name)
    height = 1 if input[0] == '^' else -1
    streak = 1

    for i in range(1, len(input)): 
        if input[i] == input[i - 1]: 
            streak += 1
        else: 
            streak = 1

        match input[i]: 
            case 'v': 
                height -= streak
            case '^': 
                height += streak
                max_height = max(height, max_height)
    return max_height

    
  
def part3(file_name: str) -> int: 
    max_height = 0
    input = get_inputs(file_name)
    height = 0
    streak = 1

    fibs = {0: 0, 1: 1, 2: 1}
    def get_fib(val: int) -> int: 
        if val in fibs: 
            return fibs[val]
        
        fib = get_fib(val - 1) + get_fib(val - 2)
        fibs[val] = fib

        return fib

    for i in range(1, len(input)): 
        if input[i] == input[i - 1]: 
            streak += 1
        else: 
            change = get_fib(streak)
            if input[i - 1] == "^": 
                height += change
                max_height = max(height, max_height)
            else: 
                height -= change
            streak = 1

    change = get_fib(streak)
    if input[-1] == "^": 
        height += change
        max_height = max(height, max_height)
    else: 
        height -= change


                
    return max_height

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part1: {result}")

    result = part2(file_name)
    print(f"Part2: {result}")

    result = part3(file_name)
    print(f"Part3: {result}")


@pytest.mark.parametrize("file_name", [
    ("sample.txt"), 
    ("sample2.txt")
])
def test_load_inputs(file_name: str):    
    input = get_inputs(file_name)
    assert(len(input) > 0)
    
@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 1), 
    ("sample2.txt", 6)
])
def test_part1(file_name: str, expected: int): 
    result = part1(file_name)
    assert(result == expected)

def test_part2(): 
    file_name = "sample2.txt"
    result = part2(file_name)
    expected = 15
    assert(result == expected)

@pytest.mark.parametrize("file_name, expected", [
    ("sample2.txt", 4),
    ("sample3.txt", 144),
    ("sample4.txt", 5)
])
def test_part3(file_name: str, expected: int): 
    result = part3(file_name)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()