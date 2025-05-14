import pytest
from pathlib import Path
from typing import List

def get_input_filepath(file_name: str) -> str:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

def load_data(file_name: str) -> List[List[int]]: 
    path = get_input_filepath(file_name)
    data = []
    with open(path, "rt") as file: 
        #data = [[int(value) for value in line.strip().split('\t')] for line in file]
        for line in file.readlines():
            line = line.strip()
            vals = line.split()
            data.append([int(val) for val in vals])
    return data

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part1: {result}")
    result = part2(file_name)
    print(f"Part2: {result}")
    

def part1(file_name: str) -> int: 
    data = load_data(file_name)
    checksum = 0
    for row in data: 
        checksum += max(row) - min(row)
    return checksum

def part2(file_name: str) -> int: 
    data = load_data(file_name)
    checksum = 0
    for row in data: 
        row.sort() 
        found = False
        for i in range(len(row) - 1, -1, -1): 
            for j in range(i): 
                if row[i] % row[j] == 0: 
                    found = True
                    checksum += row[i] // row[j]
                    break
            if found: 
                break
    return checksum


def test_part1(): 
    expected = 18
    file_name = "sample.txt"
    result = part1(file_name)
    assert(result == expected)

def test_part2(): 
    expected = 9
    file_name = "sample2.txt"
    result = part2(file_name)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()