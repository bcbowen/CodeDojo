import pytest
import re
from pathlib import Path

class Point: 
    def __init__(self, x: int, y: int): 
        self.X = x
        self.Y = y

"""
Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=8400, Y=5400
"""
class Fixture: 
    def __init__(self): 
        self.ButtonA = Point(0, 0)
        self.ButtonB = Point(0, 0)
        self.Prize = Point(0, 0)


def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def parse_point(point: Point, line: str) -> Point:
    pattern = r".*X[+=](\d+), Y[+=](\d+)"
    match = re.search(pattern, line)
    if match: 
        point.X = int(match.group(1))
        point.Y = int(match.group(2))

    return point

def load_fixtures(file_name: str) -> list[Fixture]: 
    path = get_input_filepath(file_name)
    fixtures = []
    """
    Button A: X+94, Y+34
    Button B: X+22, Y+67
    Prize: X=8400, Y=5400

    """
    step = 0
    
    with open(path, "r") as file: 
        for line in file.readlines():  
            match step:
                case 0: 
                    fixture = Fixture()
                    fixture.ButtonA = parse_point(fixture.ButtonA, line)
                    step += 1     
                case 1: 
                    fixture.BUttonB = parse_point(fixture.ButtonB, line)
                    step += 1
                case 2: 
                    fixture.Prize = parse_point(fixture.Prize, line)
                    fixtures.append(fixture)
                    step += 1
                case 3: 
                    # every 4th line is blank
                    step = 0

    return fixtures

def part1(file_name: str) -> int: 
    pass

def main(): 
    result = part1("input.txt")
    print(f"Part1: {result}")

def test_part1(): 
    expected = 480
    result = part1("sample.txt")
    assert(result == expected)

def test_load_fixtures(): 
    fixtures = load_fixtures("sample.txt")
    assert(len(fixtures) == 4)
    fixture = fixtures[0]
    assert(fixture.ButtonA.X == 94)
    assert(fixture.Prize.Y == 5400)

"""
Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=8400, Y=5400

"""
def test_parse_points():
    line = "Button A: X+94, Y+34"
    fixture = Fixture()
    point = parse_point(fixture.ButtonA, line)
    assert(point.X == 94)
    assert(point.Y == 34)

    line = "Button B: X+22, Y+67"
    point = parse_point(fixture.ButtonB, line)
    assert(point.X == 22)
    assert(point.Y == 67)

    line = "Prize: X=8400, Y=5400"
    point = parse_point(fixture.Prize, line)
    assert(point.X == 8400)
    assert(point.Y == 5400)

if __name__ == "__main__": 
    pytest.main([__file__])
    #main()
