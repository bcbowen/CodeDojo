import pytest
import re
from typing import List
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


def get_inputs(file_name: str):
    content = Modules.aoc_io.read_input(2025, 12, file_name)

    lines = content.split("\n\n")[-1].splitlines()
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
