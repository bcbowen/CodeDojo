import pytest
from pathlib import Path
from collections import namedtuple
#from collections import defaultdict

Direction = namedtuple('Direction', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

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

"""
perimeter = + 1 for each side bordered by another value or an edge
"""
def calc_perimiter(grid: list[list[str]], row : int, col: int): 
    val = grid[row][col]
    p = 0
    # west
    if col == 0 or grid[row][col - 1] != val: 
        p += 1
    # east
    if col == len(grid[0]) - 1 or grid[row][col + 1] != val: 
        p += 1
    # north
    if row == 0 or grid[row - 1][col] != val: 
        p += 1
    # south 
    if row == len(grid) - 1 or grid[row + 1][col] != val: 
        p += 1

    return p

def traverse_connected_cells(grid: list[list[str]], visited: set[tuple[int, int]], position: tuple[int, int], plots : dict[str, list[tuple[int, int]]]): 
    value = grid[position[0]][position[1]]
    #visited.add(position)
    q = []
    q.append(position)
    area = 0
    perimiter = 0
    while len(q) > 0: 
        cell = q.pop(0)
        visited.add(cell)
        area += 1
        perimiter += calc_perimiter(grid, cell[0], cell[1])

        # north
        if cell[0] > 0 and grid[cell[0] - 1][cell[1]] == value: 
            q.append((grid[cell[0] - 1], [cell[1]]))

        # east
        if cell[1] < len(grid) - 1 and grid[cell[0]][cell[1] + 1] == value: 
            q.append((grid[cell[0]], [cell[1] + 1]))
        
        #south
        if cell[0] < len(grid) - 1 and grid[cell[0] + 1][cell[1]] == value: 
            q.append((grid[cell[0] + 1], [cell[1]]))

        #west
        if cell[1] > 0 and grid[cell[0]][cell[1] - 1] == value: 
            q.append((grid[cell[0]], [cell[1] - 1]))

    if not value in plots:
        plots[value] = set()
    plots[value].add(perimiter, area)

def part1(file_name: str): 
    grid = load_grid(file_name)
    # plots key = garden, val = [p, a]
    plots = {}
    visited = set()
    for row in range(len(grid)): 
        for col in range(len(grid[0])):
            if ((row, col)) in visited: 
                continue
            traverse_connected_cells(grid, visited, (row, col), plots)
    result = 0
    for key in plots: 
        #result += plots[key][0] * plots[key][1]
        for group in plots[key]: 
            result += group[0] * group[1]

    return result

def main(): 
    pass

@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 140),
    ("sample2.txt", 772),
    ("sample3.txt", 1930) 
])
def test_part1(file_name : str, expected: int): 
    result = part1(file_name)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
    #main()

