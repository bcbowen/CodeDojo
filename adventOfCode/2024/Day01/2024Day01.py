import pytest
from pathlib import Path
from collections import defaultdict
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


def part1(file_name: str) -> int:
    list1 = []
    list2 = []
    content = Modules.aoc_io.read_input(2024, 1, file_name)
    lines = content.split("\n")
    # row = 0
    for line in lines:
        nums = line.split(" ")
        if len(nums) > 1:
            list1.append(int(nums[0]))
            list2.append(int(nums[-1]))

    list1 = sorted(list1)
    list2 = sorted(list2)
    diff = 0
    for i in range(len(list1)):
        diff += abs(list1[i] - list2[i])

    return diff


def part2(file_name: str) -> int:
    values = []
    counts = defaultdict(int)
    content = Modules.aoc_io.read_input(2024, 1, file_name)
    lines = content.split("\n")
    # row = 0
    for line in lines:
        nums = line.split(" ")
        if len(nums) > 1:
            values.append(int(nums[0]))
            key = int(nums[-1])
            counts[key] += 1

    score = 0
    for i in range(len(values)):
        key = values[i]
        score += key * counts[key]

    return score


def main():
    diff = part1("sample.txt")
    print(f"Sample part1: {diff}")
    diff = part1("input.txt")
    print(f"Part1: {diff}")
    diff = part2("sample.txt")
    print(f"Sample part2: {diff}")
    diff = part2("input.txt")
    print(f"Part2: {diff}")


def test_part1():
    file_name = "sample.txt"
    expected = 11
    result = part1(file_name)
    assert result == expected


def test_part2():
    file_name = "sample.txt"
    expected = 31
    result = part2(file_name)
    assert result == expected


if __name__ == "__main__":
    pytest.main([__file__])
    main()
