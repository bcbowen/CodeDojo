import pytest
import re
from typing import List
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

def get_inputs(file_name: str): 
    path = get_input_filepath(file_name)

    lines = open(path).read().split("\n\n")[-1].splitlines()
    return lines

def main(): 
    result = part1()
    print(f"Part1 result: {result}")

def part1() -> int: 
    file_name = "input.txt"
    lines = get_inputs(file_name)

    total = 0

    for line in lines:
        x, y, *counts = list(map(int, re.findall(r"\d+", line)))
        if (x // 3) * (y // 3) >= sum(counts):
            total += 1

    return total

if __name__ == "__main__":
    pytest.main([__file__])
    main()

"""
import re

lines = open(0).read().split("\n\n")[-1].splitlines()

total = 0

for line in lines:
    x, y, *counts = list(map(int, re.findall(r"\d+", line)))
    if (x // 3) * (y // 3) >= sum(counts):
        total += 1

print(total)
"""
