import pytest
from pathlib import Path

class Robot: 
    def __init__(self, id: int):
        self.position = (0, 0) 
        self.velocity = (0, 0)
        self.id = id

    def set_location(self, x: int, y: int): 
        self.position = (x, y)

    def set_velocity(self, x: int, y: int): 
        self.velocity = (x, y)

    def calc_future_position(self, turns: int, grid_height: int, grid_width: int) -> tuple[int, int]: 
        raw_x, raw_y = self.position[0] * self.velocity[0] * turns, self.position[1] * self.velocity[1] * turns
        x = raw_x % grid_width
        y = raw_y % grid_height
        return (x, y)
    
    """
    ex: p=9,5 v=-3,-3
    """
    def parse(line: str, id: int) -> 'Robot': 
        parts = line.strip().split(' ')
        pos_values = parts[0].replace("p=", "").split(',')
        velocity_values = parts[1].replace("v=", "").split(',')
        robot = Robot(id)
        robot.set_location(int(pos_values[0]), int(pos_values[1]))
        robot.set_velocity(int(velocity_values[0]), int(velocity_values[1]))
        return robot

def get_input_filepath(file_name: str):
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

def main():
    pass


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