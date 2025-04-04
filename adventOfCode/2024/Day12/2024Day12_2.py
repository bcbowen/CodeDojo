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

def traverse_connected_cells(grid: list[list[str]], visited: set[tuple[int, int]], position: tuple[int, int], plots : dict[str, list[tuple[int, int]]]): 
    value = grid[position[0]][position[1]]
    
    q = []
    q.append(position)
    area = 0
    perimiter = 0
    cells = []
    while len(q) > 0: 
        cell = q.pop(0)
        if cell in visited: 
            continue

        visited.add(cell)
        cells.append(cell)
        area += 1
        perimiter += calc_perimiter(grid, cell[0], cell[1])

        # north
        if cell[0] > 0 and grid[cell[0] - 1][cell[1]] == value: 
            q.append((cell[0] - 1, cell[1]))

        # east
        if cell[1] < len(grid) - 1 and grid[cell[0]][cell[1] + 1] == value: 
            q.append((cell[0], cell[1] + 1))
        
        #south
        if cell[0] < len(grid) - 1 and grid[cell[0] + 1][cell[1]] == value: 
            q.append((cell[0] + 1, cell[1]))

        #west
        if cell[1] > 0 and grid[cell[0]][cell[1] - 1] == value: 
            q.append((cell[0], cell[1] - 1))

    if not value in plots:
        plots[value] = []
    plots[value].append((perimiter, area, cells))

"""
Take group of cells and find the 2 corners: 
- Top Left: min y, min x
- Bottom Right: max y, max x
"""
def count_corners(cells : list[tuple[int, int]]) -> int:
    y_coords, x_coords = zip(*cells)
    return ((min(y_coords), min(x_coords)),(max(y_coords, max(x_coords))))

"""
Build a grid with the lower right corner cooresponding to the max_corner. 
This is for part 2
"""
def init_grid(lower_corner: tuple[int, int]) -> list[list[str]]: 
    grid = []
    
    for row in range(lower_corner[0]):
        row_values = []
        for col in range(lower_corner[1]): 
            row_values.append('.')
        grid.append(row_values)
    return grid

"""
find a right edge of the grid to start with. 
Once we find the edge, follow outline to top 
Then we'll calc the perimiter from that cell going counter clockwise

def find_edge(grid: list[list[str]]) -> tuple[int, int]:
    row = len(grid)
    col = len(grid[row])
    while grid[row][col] == '.':
        col -= 1

    return row, col
"""
    

def calc_parimeter(key: str, cells : list[tuple[int, int]]):
    corners = find_corners(cells)
    grid = init_grid(corners[1])
    for cell in cells: 
        grid[cell[0]][cell[1]] = key
    cell = find_edge(grid)

    perimeter = 0
    height = corners[1][0] - corners[0][0]
    width = corners[1][1] - corners[0][1]
    start = cell
    direction = North 
    perimeter = 1
    if cell[1] < corners[1][1] and grid[cell[0] - 1][cell[1] + 1] == key: 
        direction = East
        perimeter += 1
        cell = grid[cell[0] - 1][cell[1] + 1]
    elif grid[cell[0] - 1][cell[1]] == key: 
        cell = grid[cell[0] - 1][cell[1]]
    else: 
        Direction = West
        cell = grid[cell[0]][cell[1] - 1]
        perimeter += 1
    
    while cell != start: 
        # todo: based on current direction see if we continue or turn, update perimiter and 
        # keep going until we get back to start
        
        pass




    return perimeter    
   
def day12_part2(file_name: str) -> tuple[int, int]: 
    grid = load_grid(file_name)
    # plots key = garden, val = [p, a]
    plots = {}
    visited = set()
    for row in range(len(grid)): 
        for col in range(len(grid[0])):
            if ((row, col)) in visited: 
                continue
            traverse_connected_cells(grid, visited, (row, col), plots)

    result = 42

    return result

def main(): 
    file_name = "input.txt"
    result = day12_part2(file_name)
    print(f"Part 1 result for {file_name}: {result}")

@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 80),
    ("sample2.txt", 436),
    ("sample3.txt", 1206), 
    ("sample4.txt", 236)
])
def test_day12_part2(file_name : str, expected: int): 
    _, result2 = day12_part2(file_name)
    assert(result2 == expected)    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()

