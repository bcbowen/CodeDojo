import pytest
from pathlib import Path
from collections import namedtuple

Direction = namedtuple('Direction', ['y', 'x'])
Point = namedtuple('Point', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

debug_mode = False

def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def expand_grid(grid : list[list[str]]) -> list[list[str]]:
    new_grid = [] 
    for row in grid: 
        new_row = [] 
        for c in row: 
            if c == '@': 
                new_row.extend(['@', '.'])
            elif c == "O": 
                new_row.extend(['[', ']'])
            else: 
                new_row.extend([c, c])
        new_grid.append(new_row)
    return new_grid

def load_input(file_name : str) -> tuple[list[list[str]], list[str]]:
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        lines = file.readlines()
        grid = []
        for index, line in enumerate(lines): 
            if line.strip() == "": 
                break
            grid.append(list(line.strip()))
        index += 1
        moves = [line for line in lines[index:]]

        grid = expand_grid(grid)
        return grid, moves


def load_grid(file_name : str) -> list[list[str]]:
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        lines = file.readlines()
        grid = []
        for index, line in enumerate(lines): 
            if line.strip() == "": 
                break
            grid.append(list(line.strip()))
    return grid

def find_robot(grid : list[list[str]]) -> Point: 
    for row in range(len(grid)): 
        for col in range(len(grid[0])):
            if grid[row][col] == "@": 
                #return row, col
                return Point(row, col) 

def get_direction(value : str) -> Direction: 
    match value: 
        case '>': 
            return East
        case '<':
            return West
        case '^':  
            return North
        case 'v':
            return South
    raise Exception(f"Invalid direction: {value}")  

"""
Will move a box if it can.
"""
def move_box(grid: list[list[str]], box_left: Point, direction: Direction) -> bool: 
    if can_move(grid, box_left, direction): 
        
        if direction == East:
            row = box_left.y
            col = box_left.x + 2
            next_char = grid[row][col]
            if next_char in ['#', ']']: 
                raise Exception(f"Illegal move {box_left} {direction}")
            if next_char == '[':
                if can_move(grid, Point(row, col), direction):  
                    move_box(grid, Point(row, col), direction)
                else: 
                    return False
            grid[row][col] = grid[row][col - direction.x]
            col -= direction.x
            grid[row][col] = grid[row][col - direction.x]
            col -= direction.x
            grid[row][col] = '.'
            return True

        elif direction == West: 
            row = box_left.y
            col = box_left.x + direction.x
            next_char = grid[row][col]
            if next_char == '#': 
                raise Exception(f"Illegal move {box_left} {direction}")
            if next_char == ']':
                if can_move(grid, Point(row, col - 1), direction):  
                    move_box(grid, Point(row, col - 1), direction)
                else: 
                    return False

            grid[row][col] = grid[row][col - direction.x]
            col -= direction.x
            grid[row][col] = grid[row][col - direction.x]
            col -= direction.x
            grid[row][col] = '.'
            return True
            
        else: 
            col_l = box_left.x
            col_r = col_l + 1
            row = box_left.y + direction.y
            if '#' in [grid[row][col_l], grid[row][col_r]]:
                raise Exception("Illegal move, putz")
            
            box_parts = ['[', ']']
            if grid[row][col_l] in box_parts or grid[row][col_r] in box_parts: 
#            if grid[row][col_l] == '.' and grid[row][col_r] == '.': 

                """
                    b2 b3     b1    b2   b1   b2     b2    b1  b1
                        b1     b2 b3  b1   b2    b1   b1    b2    b2
                """
                # boxes holds the left point for each connected box
                boxes = []
                # check for direct vertical box
                missing_box_msg = "We're missing half a box, buddy"
                if grid[row][col_l] == '[': 
                    if grid[row][col_r] != ']': 
                        raise Exception(missing_box_msg)
                    boxes.append(Point(row, col_l))
                else: 
                    if grid[row][col_l] == ']': 
                        if grid[row][col_l - 1] != '[': 
                            raise Exception(missing_box_msg)
                        boxes.append(Point(row, col_l - 1))
                    if grid[row][col_r] == '[':
                        if grid[row][col_r + 1] != ']': 
                            raise Exception(missing_box_msg)
                        boxes.append(Point(row, col_r))

                for box in boxes: 
                    move_box(grid, box, direction)

            # at this point the spaces above the box have to be empty         
            grid[row][col_l] = grid[box_left.y][col_l]
            grid[row][col_r] = grid[box_left.y][col_r]
            grid[box_left.y][col_l] = '.'
            grid[box_left.y][col_r] = '.'
            return True
    else: 
        return False
 

def can_move(grid: list[list[str]], box_left: Point, direction: Direction) -> bool: 
    if direction == East: 
        row = box_left.y
        col = box_left.x + 2
        if grid[row][col] == '#': 
            return False
        elif grid[row][col] == '[': 
            return can_move(grid, Point(row, col), direction)
        else: 
            return True      
    elif direction == West: 
        row = box_left.y
        col = box_left.x + direction.x
        if grid[row][col] == '#': 
            return False
        elif grid[row][col] == ']': 
            # next position is another box, see if this is already the second box
            col += direction.x
            return can_move(grid, Point(row, col), direction)
        else: 
            return True      
    else: 
        col_l = box_left.x
        col_r = col_l + 1
        row = box_left.y + direction.y
        if '#' in [grid[row][col_l], grid[row][col_r]]:
            return False
        
        if grid[row][col_l] == '.' and grid[row][col_r] == '.': 
            return True
        
        else: 
            """
                  b2 b3     b1    b2   b1   b2     b2    b1  b1
                    b1     b2 b3  b1   b2    b1   b1    b2    b2
            """
            # boxes holds the left point for each connected box
            boxes = []
            # check for direct vertical box
            missing_box_msg = "We're missing half a box, buddy"
            if grid[row][col_l] == '[': 
                if grid[row][col_r] != ']': 
                    raise Exception(missing_box_msg)
                boxes.append(Point(row, col_l))
            else: 
                if grid[row][col_l] == ']': 
                    if grid[row][col_l - 1] != '[': 
                        raise Exception(missing_box_msg)
                    boxes.append(Point(row, col_l - 1))
                if grid[row][col_r] == '[':
                    if grid[row][col_r + 1] != ']': 
                        raise Exception(missing_box_msg)
                    boxes.append(Point(row, col_r))
            result = True
            for box in boxes: 
                result = result and can_move(grid, box, direction)

            return result

def move_robot(grid : list[list[str]], current_location: Point, direction: Direction) -> tuple[Point, list[list[str]]]:
    next_location = Point(y=current_location.y + direction.y, x=current_location.x + direction.x)
    can_move = False
    if grid[next_location.y][next_location.x] == "#": 
        return current_location, grid
    elif grid[next_location.y][next_location.x] == ".":
        can_move = True
        
    elif grid[next_location.y][next_location.x] == "]":
        if direction == East: 
            raise Exception("This should never happen")
        else: 
            can_move = move_box(grid, Point(next_location.y, next_location.x - 1), direction)
    else: 
        # this is the left side of a box
        can_move = move_box(grid, Point(next_location.y, next_location.x), direction)

    if can_move: 
        grid[next_location.y][next_location.x] = "@"
        grid[current_location.y][current_location.x] = "."
        return next_location, grid
    else: 
        return current_location, grid

# too low: 1530888, 1532066
def part2(file_name : str) -> int: 
    grid, moves = load_input(file_name)
    current_location = find_robot(grid)
    counter = 0
    print_grid(grid, '0', counter)
    for line in moves: 
        for move in line.strip(): 
            counter += 1
            #if counter == 158: 
            #    print("Time to break")
            direction = get_direction(move)
            current_location, grid = move_robot(grid, current_location, direction)
            print_grid(grid, move, counter)

    return get_gps_total(grid)

def main():
    file_name = "input.txt"
    result = part2(file_name)
    print(f"Part 2 result: {result}")

def get_gps_total(grid: list[list[str]]) -> int: 
    gps_score = lambda y, x : y * 100 + x

    total = 0
    for y in range(len(grid)): 
        for x in range(len(grid[0])): 
            if grid[y][x] == "[": 
                total += gps_score(y, x)
    return total

@pytest.mark.parametrize("file_name, expected", [
    ("part2_gps_sample.txt", 9021), 
    ("part2_move_sample_12.txt", 618)
])
def test_get_gps_total(file_name: str, expected: int): 
    grid = load_grid(file_name)
    result = get_gps_total(grid)
    assert(result == expected)

# larger example, the sum of all boxes' GPS coordinates is 10092. In the smaller example, the sum is 2028.

def test_find_robot(): 
    file_name = "sample1.txt"
    grid, _ = load_input(file_name)
    expected = Point(4, 8)
    result = find_robot(grid)
    assert(result == expected)

def print_grid(grid: list[list[str]], command : str, counter: int): 
    global debug_mode
    if debug_mode: 
        print(command, counter)
        for row in grid: 
            print("".join(row))
        print(" ")

def test_move_robot(): 
    def do_move(move_index : int, grid: list[list[str]], current_location : Point, test_file : str) -> tuple[Point, list[list[str]]]: 
        move = moves[0][move_index] 
        direction = get_direction(move)
        current_location, grid = move_robot(grid, current_location, direction)
        file_name = test_file
        expected_grid = load_grid(file_name)
        assert(grid == expected_grid)
        return current_location, grid

    file_name = "part2_move_sample_1.txt"
    grid, moves = load_input(file_name)

    file_name = "part2_move_sample_2.txt"
    expected_grid = load_grid(file_name)
    assert(grid == expected_grid)

    current_location = find_robot(grid)
    move_index = 0
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_3.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_4.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_5.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_6.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_7.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_8.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_8.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_9.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_10.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_11.txt")

    move_index += 1
    current_location, grid = do_move(move_index, grid, current_location, "part2_move_sample_12.txt")

@pytest.mark.parametrize("file_name, expected", [
    ("sample1.txt", 9021), 
    ("sample5.txt", 618)
])
def test_part2(file_name : str, expected: int): 
    result = part2(file_name)
    assert(result == expected)

def test_load_input(): 
    file_name = "sample1.txt"
    # load grid and moves from original input:
    grid, moves = load_input(file_name)

    # load transformed grid sample: 
    file_name = "sample_2_before.txt"
    expanded_grid = load_grid(file_name)

    assert(grid == expanded_grid)
    assert(len(moves) == 10)

if __name__ == "__main__": 
    pytest.main([__file__])
    main()

