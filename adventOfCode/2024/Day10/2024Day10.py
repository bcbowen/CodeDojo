import pytest
from pathlib import Path
from collections import namedtuple
from collections import defaultdict
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

Direction = namedtuple("Direction", ["y", "x"])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

trails = defaultdict(set[tuple[int, int]])


def load_grid(file_name: str) -> list[list[int]]:
    content = Modules.aoc_io.read_input(2024, 10, file_name)
    grid = [
        (list(map(int, line.strip()))) for line in content.splitlines(keepends=True)
    ]

    return grid


def find_starts(grid: list[list[int]]) -> set[tuple[int, int]]:
    starts = set()
    for row in range(len(grid)):
        for col in range(len(grid[row])):
            if grid[row][col] == 0:
                starts.add((row, col))
    return starts


def find_path(grid: list[list[int]], point: tuple[int, int], origin: tuple[int, int]):
    val = grid[point[0]][point[1]]
    next = val + 1
    row = point[0]
    col = point[1]

    inbounds = (
        lambda p: p[0] >= 0 and p[0] < len(grid) and p[1] >= 0 and p[1] < len(grid[0])
    )

    next_point = (row + North[0], col + North[1])
    if inbounds(next_point) and grid[next_point[0]][next_point[1]] == next:
        if next == 9:
            trails[origin].add(next_point)
        else:
            find_path(grid, (next_point[0], next_point[1]), origin)

    next_point = (row + West[0], col + West[1])
    if inbounds(next_point) and grid[next_point[0]][next_point[1]] == next:
        if next == 9:
            trails[origin].add(next_point)
        else:
            find_path(grid, (next_point[0], next_point[1]), origin)

    next_point = (row + South[0], col + South[1])
    if inbounds(next_point) and grid[next_point[0]][next_point[1]] == next:
        if next == 9:
            trails[origin].add(next_point)
        else:
            find_path(grid, (next_point[0], next_point[1]), origin)

    next_point = (row + East[0], col + East[1])
    if inbounds(next_point) and grid[next_point[0]][next_point[1]] == next:
        if next == 9:
            trails[origin].add(next_point)
        else:
            find_path(grid, (next_point[0], next_point[1]), origin)


def part1(file_name: str) -> int:
    global trails
    trails = defaultdict(set[tuple[int, int]])
    grid = load_grid(file_name)
    starts = find_starts(grid)
    for start in starts:
        find_path(grid, start, start)
    trail_count = 0
    for key in trails:
        trail_count += len(trails[key])
    return trail_count


def main():
    result = part1("input.txt")
    print(f"Part 1 result: {result}")


"""
Only test sample inputs with all ints since that's how the real input is
"""


@pytest.mark.parametrize(
    "file_name, expected",
    [
        ("sample.txt", 1),
        ("sample5.txt", 36),
    ],
)
def test_part1(file_name, expected):
    result = part1(file_name)
    assert result == expected


if __name__ == "__main__":
    pytest.main([__file__])
    main()
