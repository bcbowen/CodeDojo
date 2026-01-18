import pytest
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io
from typing import List


def load_data(file_name: str) -> List[List[int]]: 
    data = []

    for line in Modules.aoc_io.read_input(2017, 2, file_name).split('\n'):
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