import pytest
from typing import List, Tuple
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


def load_inputs(file_name: str) -> List[List[str]]:
    inputs = [
        [c for c in line.strip()]
        for line in Modules.aoc_io.read_input(2025, 4, file_name).split("\n")
    ]
    return inputs


def process_rolls(board: List[List[str]]) -> Tuple[List[List[str]], int]:
    roll_count = 0
    rolls = []
    limit = 4
    roll = "@"
    for row in range(len(board)):
        for col in range(len(board[0])):
            if board[row][col] == roll:
                c = count_rolls(board, row, col)
                if c < limit:
                    roll_count += 1
                    rolls.append((row, col))

    for row, col in rolls:
        board[row][col] = "x"

    return (board, roll_count)


def part1(file_name: str) -> Tuple[List[List[str]], int]:
    board = load_inputs(file_name)
    board, roll_count = process_rolls(board)
    return (board, roll_count)


def part2(file_name: str) -> int:
    board = load_inputs(file_name)
    total_count = 0
    board, current_count = process_rolls(board)
    total_count += current_count
    while current_count > 0:
        board, current_count = process_rolls(board)
        total_count += current_count

    return total_count


def count_rolls(board: List[List[str]], row: int, col: int) -> int:
    def is_inbounds(row: int, col: int) -> bool:
        if row < 0 or row >= len(board):
            return False
        if col < 0 or col >= len(board[0]):
            return False
        return True

    roll = "@"
    roll_count = 0

    for y in range(row - 1, row + 2):
        for x in range(col - 1, col + 2):
            if is_inbounds(y, x) and (y, x) != (row, col) and board[y][x] == roll:
                roll_count += 1

    return roll_count


def main():
    file_name = "input.txt"
    _, count = part1(file_name)
    print(f"Part 1 result: {count}")

    count = part2(file_name)
    print(f"Part 2 result: {count}")


def test_load_inputs():
    file_name = "sample.txt"
    inputs = load_inputs(file_name)
    assert len(inputs) == 10
    assert inputs[0][0] == "."
    assert inputs[0][2] == "@"


@pytest.mark.parametrize(
    "row, col, expected", [(0, 2, 3), (1, 0, 3), (4, 4, 8), (9, 9, 2)]
)
def test_count_rolls(row: int, col: int, expected: int):
    file_name = "sample.txt"
    board = load_inputs(file_name)
    result = count_rolls(board, row, col)
    assert result == expected


def test_part1():
    file_name = "sample.txt"
    result_file_name = "sample_result.txt"
    expected_count = 13
    expected_board = load_inputs(result_file_name)
    result_board, result_count = part1(file_name)

    assert expected_count == result_count
    assert expected_board == result_board


def test_part2():
    file_name = "sample.txt"
    expected_count = 43
    result = part2(file_name)
    assert expected_count == result


if __name__ == "__main__":
    pytest.main([__file__])
    main()
