import pytest
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


def load_data(file_name: str) -> list[str]:
    content = Modules.aoc_io.read_input(2024, 9, file_name)
    line = content.split("\n")[0]
    drive = []
    id = 0

    for i, size in enumerate(line):
        if i % 2 == 0:
            value = str(id)
            id += 1

        else:
            value = "."

        for j in range(int(size)):
            drive.append(value)
    return drive


def calc_checksum(drive: list[str]) -> int:
    checksum = 0
    for i, val in enumerate(drive):
        if val == ".":
            continue
        checksum += i * int(val)
    return checksum


def part1(file_name: str) -> int:
    drive = load_data(file_name)
    l = 0
    r = len(drive) - 1
    while l <= r:
        while drive[l] != ".":
            l += 1

        while drive[r] == ".":
            r -= 1

        drive[l], drive[r] = drive[r], drive[l]
    # final swap:
    drive[l], drive[r] = drive[r], drive[l]
    # print(f"l: {l} r: {r}\n {drive}")
    return calc_checksum(drive)


def test_part1():
    file_name = "sample.txt"
    expected = 1928
    result = part1(file_name)
    assert result == expected


def main():
    # part 1:
    result = part1("sample.txt")
    print(f"Sample part 1: {result}")

    result = part1("input.txt")
    print(f"Part 1: {result}")


def test_calc_checksum():
    expected = 1928
    drive = list("0099811188827773336446555566..............")
    result = calc_checksum(drive)
    assert result == expected


def test_load_data():
    drive = load_data("sample.txt")
    assert isinstance(drive, list)
    assert len(drive) == 42
    expected = "00...111...2...333.44.5555.6666.777.888899"
    for i, val in enumerate(expected):
        assert drive[i] == val


if __name__ == "__main__":
    pytest.main([__file__])
    main()
