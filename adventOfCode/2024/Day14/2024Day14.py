import pytest
from pathlib import Path
from collections import namedtuple


Cell = namedtuple("Cell", ['y', 'x'])
Position = namedtuple("Position", ['x', 'y'])
Velocity = namedtuple("Velocity", ['x', 'y'])

class Robot: 
    def __init__(self, id: int):
        self.position = Position(0, 0) 
        self.velocity = Position(0, 0)
        self.id = id

    def set_location(self, position : Position): 
        self.position = position

    def set_velocity(self, velocity : Velocity): 
        self.velocity = velocity


    def move_one(self, grid_height: int, grid_width: int): 
        x, y = self.position.x + self.velocity.x, self.position.y + self.velocity.y
        
        if x < 0: 
            x += grid_width
        elif x >= grid_width:
            x -= grid_width
        
        if y < 0: 
            y += grid_height
        elif y >= grid_height: 
            y -= grid_height

        self.position = Position(x, y)

    def calc_future_position(self, turns: int, grid_height: int, grid_width: int) -> Position: 
       
        x = self.position.x
        y = self.position.y
        for _ in range(turns):
            x += self.velocity.x
            y += self.velocity.y

            if x < 0: 
                x += grid_width
            elif x >= grid_width:
                x = x - grid_width
         
            if y < 0: 
                y += grid_height
            elif y >= grid_height: 
                y = y - grid_height
        
        return Position(x, y)
    
    """
    ex: p=9,5 v=-3,-3
    """
    def parse(line: str, id: int) -> 'Robot': 
        parts = line.strip().split(' ')
        pos_values = parts[0].replace("p=", "").split(',')
        velocity_values = parts[1].replace("v=", "").split(',')
        robot = Robot(id)
        robot.set_location(Position(int(pos_values[0]), int(pos_values[1])))
        robot.set_velocity(Velocity(int(velocity_values[0]), int(velocity_values[1])))
        return robot

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path


def load_robots(file_name: str) -> list[Robot]: 
    path = get_input_filepath(file_name)
    id = 1
    robots = []
    with open (path, "r") as file: 
        for line in file.readlines():
            robots.append(Robot.parse(line, id))
            id += 1
    
    return robots

def generate_grid(rows: int, cols: int) -> list[list[str]]: 
    return [['.' for _ in range(cols)] for _ in range(rows)]


def reset_grid(grid: list[list[str]]): 
    for row in grid: 
        for col in range(len(row)): 
            row[col] = '.'

def populate_grid(robots: list[Robot], grid: list[list[str]]): 
    reset_grid(grid)
    for robot in robots: 
        val = grid[robot.position.y][robot.position.x]
        if val != '.':
            val = int(val) + 1
        else: 
            val = 1
        grid[robot.position.y][robot.position.x] = val

def part1(file_name: str, grid_width: int, grid_height: int) -> int: 
    robots = load_robots(file_name)
    #grid = generate_grid(grid_height, grid_width)
    iterations = 100

    def get_quadrant(position: Position) -> int: 
        quadrant = 0
        mid_col = grid_width // 2
        mid_row = grid_height // 2
        if position.y != mid_row and position.x != mid_col: 
            if position.y < mid_row: 
                quadrant = 1 if position.x < mid_col else 2
            else: 
                quadrant = 3 if position.x < mid_col else 4
            
        return quadrant

    def get_score(robots: list[Robot]) -> int: 
        q1 = 0
        q2 = 0
        q3 = 0
        q4 = 0
        for robot in robots: 
            quadrant = get_quadrant(robot.position)
            match quadrant: 
                case 1: 
                    q1 += 1
                case 2: 
                    q2 += 1
                case 3: 
                    q3 += 1
                case 4: 
                    q4 += 1
        return q1 * q2 * q3 * q4

    for robot in robots: 
        position = robot.calc_future_position(iterations, grid_height, grid_width)
        robot.set_location(position)
    
    #    val = grid[y][x]
    #    if val != '.':
    #        val = int(val) + 1
    #    else: 
    #        val = 1
    #    grid[y][x] = val
    #populate_grid(robots, grid)
    score = get_score(robots)
    return score
        
def write_grid(grid: list[list[str]], index): 
    print(f"Grid {index}\n")
    for row in grid: 
        print(f"{str(row)}")
    print("\n")
    print("\n")

def part2(): 
    file_name = "input.txt"
    robots = load_robots(file_name)

    grid_height = 103
    grid_width = 101

    grid = generate_grid(grid_height, grid_width)

    def get_connectedness_score(grid : list[list[str]]) -> int: 
        current_streak = 0 if grid[0][0] == '.' else 1
        max_hstreak = 0

        for row in range(1, len(grid)): 
            for col in range(1, len(grid[0])): 
                if grid[row][col] == '.': 
                    max_hstreak = max(current_streak, max_hstreak)
                    current_streak = 0
                else: 
                    current_streak += 1
            max_hstreak = max(current_streak, max_hstreak)

        current_streak = 0 if grid[0][0] == '.' else 1
        max_vstreak = 0
        for col in range(1, len(grid[0])): 
            for row in range(1, len(grid)): 
            
                if grid[row][col] == '.': 
                    max_vstreak = max(current_streak, max_vstreak)
                    current_streak = 0
                else: 
                    current_streak += 1
            max_vstreak = max(current_streak, max_vstreak)

        return (max_hstreak + max_vstreak) // 2

    iterations = 10403
    max_score = 0
    max_i = 0
    max_grid = 0
    for i in range(iterations): 
        for robot in robots: 
            robot.move_one(grid_height, grid_width)
        populate_grid(robots, grid)
        score = get_connectedness_score(grid)
        if score > max_score: 
            max_score = score
            print(f"max score found: {max_score}")
            max_i = i
            max_grid = grid.copy()
    # 6474 too low
    write_grid(max_grid, max_i)
    return max_i


def main():
    file_name = "input.txt"
    result = part1(file_name, 101, 103)
    print(f"Part 1 result for {file_name}: {result}")
    part2()

def test_part1(): 
    file_name = "sample.txt"
    expected = 12
    result = part1(file_name, 11, 7)
    assert(result == expected)

"""
p=2,4 v=2,-3
"""
@pytest.mark.parametrize("start_x, start_y, v_x, v_y, iterations, expected_x, expected_y", [
    (2, 4, 2, -3, 1, 4, 1), 
    (2, 4, 2, -3, 2, 6, 5), 
    (2, 4, 2, -3, 3, 8, 2), 
    (2, 4, 2, -3, 4, 10, 6), 
    (2, 4, 2, -3, 5, 1, 3)
])
def test_future_position(start_x: int, start_y: int, v_x: int, v_y: int, iterations: int, expected_x : int, expected_y: int):
    robot = Robot(1)
    position = Position(start_x, start_y)
    velocity = Velocity(v_x, v_y)
    robot.set_location(position)
    robot.set_velocity(velocity)
    position = robot.calc_future_position(iterations, 7, 11)
    expected_position = Position(expected_x, expected_y)
    assert(position == expected_position)



"""
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
"""
@pytest.mark.parametrize("line, p_x, p_y, v_x, v_y, id", [
    ("p=9,3 v=2,3", 9, 3, 2, 3, 1), 
    ("p=7,3 v=-1,2", 7, 3, -1, 2, 2), 
    ("p=2,4 v=2,-3", 2, 4, 2, -3, 3)
])
def test_parse_robot(line: str, p_x: int, p_y: int, v_x: int, v_y: int, id: int): 
    robot = Robot.parse(line, id)
    assert(robot.position[0] == p_x)
    assert(robot.position[1] == p_y)

    assert(robot.velocity[0] == v_x)
    assert(robot.velocity[1] == v_y)
    assert(robot.id == id)

def test_load_robots(): 
    file_name = "sample.txt"
    robots = load_robots(file_name)
    assert(len(robots) == 12)
    assert(robots[0].id == 1)
    assert(robots[0].position[0] == 0)
    assert(robots[0].position[1] == 4)
    assert(robots[0].velocity[0] == 3)
    assert(robots[0].velocity[1] == -3)

    assert(robots[-1].id == 12)
    assert(robots[-1].position[0] == 9)
    assert(robots[-1].position[1] == 5)
    assert(robots[-1].velocity[0] == -3)
    assert(robots[-1].velocity[1] == -3)


@pytest.mark.parametrize("width, height", [
    (101, 103),
    (11, 7)
])
def test_generate_grid(width, height):
    grid = generate_grid(height, width)
    assert(len(grid) == height) 
    assert(len(grid[0]) == width) 
    assert(grid[1][1] == '.')

if __name__ == "__main__": 
    pytest.main([__file__])
    main()