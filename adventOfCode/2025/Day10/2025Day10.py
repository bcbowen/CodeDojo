import pytest
import re
import itertools
from typing import List, Set, Tuple
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


def get_inputs(file_name: str):  # -> List[Tuple[str, Set[int]]]:
    content = Modules.aoc_io.read_input(2025, 10, file_name)
    inputs = []
    # target = ""
    # buttons : List[Set[int]] = []
    for line in content.split("\n"):
        match = re.match(r"^\[([.#]+)\] ([()\d, ]+) \{([\d,]+)\}$", line.strip())
        target, buttons, _ = match.groups()
        target = {index for index, light in enumerate(target) if light == "#"}
        buttons = [set(map(int, button[1:-1].split(","))) for button in buttons.split()]
        inputs.append((target, buttons))
    return inputs


def main():
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1: {result}")


def part1(file_name: str) -> int:
    total = 0
    inputs = get_inputs(file_name)
    for target, buttons in inputs:
        for count in range(1, len(buttons) + 1):
            for attempt in itertools.combinations(buttons, r=count):
                lights = set()
                for button in attempt:
                    lights ^= button
                if lights == target:
                    total += count
                    break
            else:
                continue
            break
    return total


def test_part1():
    file_name = "sample.txt"
    expected = 7
    result = part1(file_name)
    assert expected == result


def test_get_inputs():
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert len(inputs) > 0


if __name__ == "__main__":
    pytest.main([__file__])
    main()
