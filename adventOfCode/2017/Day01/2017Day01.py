import pytest
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

def get_value(file_name: str) -> str: 
    path = get_input_filepath(file_name)
    with open(path, "rt") as file: 
        line = file.readline().strip()
    return line

def part1(value: str) -> int: 
    i = 1
    total = 0
    while i < len(value):
        if value[i] == value[i - 1]: 
            total += int(value[i])
        i += 1
    if value[0] == value[-1]: 
         total += int(value[0])
    
    return total

def part2(value: str) -> int: 
    offset = len(value) // 2
    total = 0
    for i in range(len(value)): 
        j = i + offset
        if j >= len(value): 
            j -= len(value)
        if value[i] == value[j]: 
                total += int(value[i])
    return total

def main(): 
    value = get_value("input.txt")
    result = part1(value)
    print(f"Part1: {result}")
    result = part2(value)
    print(f"Part2: {result}")

"""
- 1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.  
- 1111 produces 4 because each digit (all 1) matches the next.  
- 1234 produces 0 because no digit matches the next.  
- 91212129 produces 9 because the only digit that matches the next one is the last digit, 9.  
"""
@pytest.mark.parametrize("file_name, expected", [
     ("1122", 3), 
     ("1111", 4), 
     ("1234", 0), 
     ("91212129", 9)
])
def test_part1(file_name: str, expected: int): 
     result = part1(file_name)
     assert(result == expected)

"""
1212 produces 6: the list contains 4 items, and all four digits match the digit 2 items ahead.
1221 produces 0, because every comparison is between a 1 and a 2.
123425 produces 4, because both 2s match each other, but no other digit has a match.
123123 produces 12.
12131415 produces 4.
"""
@pytest.mark.parametrize("val, expected", [
     ("1212", 6), 
     ("1221", 0), 
     ("123425", 4), 
     ("123123", 12), 
     ("12131415", 4)
])
def test_part2(val: str, expected: int): 
     result = part2(val)
     assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()