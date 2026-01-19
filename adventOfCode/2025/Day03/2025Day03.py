import pytest
from typing import List, Tuple
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


def get_inputs(file_name: str) -> List[str]:
    content = Modules.aoc_io.read_input(2025, 3, file_name)
    inputs = content.split("\n")
    return inputs


def main():
    file_name = "input.txt"
    joltage_size = 2
    result = day03(file_name, joltage_size)
    print(f"Part 1 result: {result}")

    joltage_size = 12
    result = day03(file_name, joltage_size)
    print(f"Part 2 result: {result}")


def day03(file_name: str, joltage_size: int) -> int:
    result = 0
    inputs = get_inputs(file_name)

    for line in inputs:
        result += get_max_joltage(line, joltage_size)
    return result


"""
Return: 
    val: int
    index: int
"""


def get_next(line: str, start: int, joltage_size: int) -> Tuple[int, int]:
    # space is the available area to get the max from
    space = len(line) - start - joltage_size
    max_index = -1
    max_val = -1
    for i in range(start, start + space + 1):
        val = int(line[i])
        if val > max_val:
            max_val = val
            max_index = i

    return (max_val, max_index)


def get_max_joltage(line: str, joltage_size: int) -> int:
    multipier = 10 ** (joltage_size - 1)
    pos = 0
    result = 0
    while joltage_size > 0:
        val, index = get_next(line, pos, joltage_size)
        result += multipier * val
        pos = index + 1
        joltage_size -= 1
        multipier //= 10

    return result


"""
In 987654321111111, you can make the largest joltage possible, 98, by turning on the first two batteries.
In 811111111111119, you can make the largest joltage possible by turning on the batteries labeled 8 and 9, producing 89 jolts.
In 234234234234278, you can make 78 by turning on the last two batteries (marked 7 and 8).
In 818181911112111, the largest joltage you can produce is 92.

"""


@pytest.mark.parametrize(
    "line, joltage_size, expected",
    [
        ("987654321111111", 2, 98),
        ("811111111111119", 2, 89),
        ("234234234234278", 2, 78),
        ("818181911112111", 2, 92),
        ("987654321111111", 12, 987654321111),
        ("811111111111119", 12, 811111111119),
        ("234234234234278", 12, 434234234278),
        ("818181911112111", 12, 888911112111),
    ],
)
def test_get_max_joltage(line: str, joltage_size: int, expected: int):
    result = get_max_joltage(line, joltage_size)
    assert result == expected


@pytest.mark.parametrize(
    "line, start, joltage_size, expected",
    [
        ("987654321111111", 0, 12, (9, 0)),
        ("987654321111111", 1, 11, (8, 1)),
        ("987654321111111", 2, 10, (7, 2)),
        ("987654321111111", 3, 9, (6, 3)),
        ("818181911112111", 0, 12, (8, 0)),
        ("818181911112111", 1, 11, (8, 2)),
        ("818181911112111", 3, 10, (8, 4)),
        ("818181911112111", 5, 9, (9, 6)),
        ("818181911112111", 7, 8, (1, 7)),
        ("987654321111111", 0, 2, (9, 0)),
        ("987654321111111", 1, 1, (8, 1)),
        ("811111111111119", 0, 2, (8, 0)),
        ("811111111111119", 1, 1, (9, 14)),
        ("234234234234278", 0, 2, (7, 13)),
        ("234234234234278", 14, 1, (8, 14)),
        ("818181911112111", 0, 2, (9, 6)),
        ("818181911112111", 7, 1, (2, 11)),
    ],
)
def test_get_next(line: str, start: int, joltage_size: int, expected: Tuple[int, int]):
    result = get_next(line, start, joltage_size)
    assert result == expected


def test_load_inputs():
    file_name = "sample.txt"
    result = get_inputs(file_name)
    assert len(result) == 4
    assert result[0][0] == "9"


@pytest.mark.parametrize("joltage_size, expected", [(2, 357), (12, 3121910778619)])
def test_day03(joltage_size: int, expected: int):
    file_name = "sample.txt"
    result = day03(file_name, joltage_size)
    assert result == expected


if __name__ == "__main__":
    pytest.main([__file__])
    main()
