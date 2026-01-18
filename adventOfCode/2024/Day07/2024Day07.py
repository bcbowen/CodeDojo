import pytest
from pathlib import Path
from itertools import product
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

op_permutations = {}


def load_input(file_name: str) -> dict[int, list[int]]:
    content = Modules.aoc_io.read_input(2024, 7, file_name)
    input = {}
    for line in content.splitlines(keepends=True):
        key_part, value_part = line.split(":")
        key = int(key_part.strip())
        values = list(map(int, value_part.strip().split()))
        if not key in input:
            input[key] = []
        input[key].append(values)
    return input


def get_ops(len: int) -> list[str]:
    if len in op_permutations:
        return op_permutations[len]

    add = lambda a, b: a + b
    mul = lambda a, b: a * b
    op_list = [add, mul]
    ops = [p for p in product(op_list, repeat=len)]
    op_permutations[len] = ops
    return ops


def check_values(total: int, values: list[int]) -> bool:
    for op_set in get_ops(len(values) - 1):
        running_total = values[0]

        for i in range(1, len(values)):
            running_total = op_set[i - 1](running_total, values[i])
            if running_total > total:
                break

        if running_total == total:
            return True
    return False


"""
def part1_output(file_name, good, bad): 
    with open(f"{file_name}_good.txt", "w") as file: 
        for line in good: 
            file.write(line + "\n")
    with open(f"{file_name}_bad.txt", "w") as file: 
        for line in bad: 
            file.write(line + "\n")
"""


def part1(file_name: str) -> int:
    input = load_input(file_name)
    total = 0
    # good = []
    # bad = []
    for key in input:
        for values in input[key]:
            if check_values(key, values):
                total += key
            # good.append(f"{key}: {input[key]}")
        # else:
        # bad.append(f"{key}: {input[key]}")

    # part1_output(file_name, good, bad)
    return total


def test_part1():
    expected = 3749
    result = part1("sample.txt")
    assert result == expected


# too low: 1038838357435
# todo: key 360 is duplicated, update input to handle dupe keys
def main():
    # part 1:
    result = part1("sample.txt")
    print(f"Sample part1: {result}")

    result = part1("input.txt")
    print(f"Part1: {result}")


def test_input_load():
    input = load_input("sample.txt")
    assert input[190][0] == [10, 19]


if __name__ == "__main__":
    pytest.main([__file__])
    main()
