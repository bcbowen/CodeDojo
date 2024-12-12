import pytest
from pathlib import Path
from collections import namedtuple
from collections import defaultdict

Direction = namedtuple('Direction', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

#trails = defaultdict(defaultdict(set[tuple[int, int]]))
trails = defaultdict(lambda: defaultdict(int))

def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_grid(file_name: str) -> list[list[str]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        grid = [(list(line.strip())) for line in file.readlines()]

    return grid

def find_starts(grid : list[list[int]]) -> set[tuple[int, int]]: 
    starts = set()
    for row in range(len(grid)): 
        for col in range(len(grid[row])):
            if grid[row][col] == '0': 
                starts.add((row, col))
    return starts 


def find_path(grid : list[list[int]], point: tuple[int, int], origin: tuple[int, int]): 
    val = int(grid[point[0]][point[1]])
    next = val + 1
    row = point[0]
    col = point[1]

    inbounds = lambda p: p[0] >= 0 and p[0] < len(grid) and p[1] >= 0 and p[1] < len(grid[0])

    next_point = (row + North[0], col + North[1])  
    if inbounds(next_point) and grid [next_point[0]][next_point[1]] == str(next): 
        if next == 9: 
            trails[origin][next_point] += 1
        else: 
            find_path(grid, (next_point[0], next_point[1]), origin)
    
    next_point = (row + West[0], col + West[1])
    if inbounds(next_point) and grid [next_point[0]][next_point[1]] == str(next): 
        if next == 9: 
            trails[origin][next_point] += 1
        else: 
            find_path(grid, (next_point[0], next_point[1]), origin)
    
    next_point = (row + South[0], col + South[1])
    if inbounds(next_point) and grid [next_point[0]][next_point[1]] == str(next): 
        if next == 9: 
            trails[origin][next_point] += 1
        else: 
            find_path(grid, (next_point[0], next_point[1]), origin)

    next_point = (row + East[0], col + East[1])
    if inbounds(next_point) and grid [next_point[0]][next_point[1]] == str(next): 
        if next == 9: 
            trails[origin][next_point] += 1
        else: 
            find_path(grid, (next_point[0], next_point[1]), origin)


def part2(file_name: str) -> int:
    global trails 
    trails = defaultdict(lambda: defaultdict(int))
    grid = load_grid(file_name)
    starts = find_starts(grid)
    for start in starts: 
        find_path(grid, start, start)
    trail_count = 0
    for key in trails: 
        for key2 in trails[key]: 
            trail_count += trails[key][key2]
    return trail_count

def main(): 
    result = part2("input.txt")
    print(f"Part 2 result: {result}")

"""
Only test sample inputs with all ints since that's how the real input is
"""
@pytest.mark.parametrize("file_name, expected", [
    ("sample_2_1.txt", 3), 
    ("sample_2_2.txt", 13), 
    ("sample_2_3.txt", 227), 
    ("sample5.txt", 81), 
])
def test_part2(file_name, expected):
    result = part2(file_name)
    assert(result == expected)
    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()