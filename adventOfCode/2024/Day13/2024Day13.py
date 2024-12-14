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
    fixtures = load_fixtures(file_name)
    cost = 0
    for fixture in fixtures: 
        result, fixture_cost = calc_cost(fixture)
        if result: 
            cost += fixture_cost
    return cost


def main(): 
    result = part1("input.txt")
    print(f"Part1: {result}")

"""
it costs 3 tokens to push the A button and 1 token to push the B button

Pushing the machine's A button would move the claw 94 units along the X axis and 34 units along the Y axis.
Pushing the B button would move the claw 22 units along the X axis and 67 units along the Y axis.
The prize is located at X=8400, Y=5400; this means that from the claw's initial position, it would need 
to move exactly 8400 units along the X axis and exactly 5400 units along the Y axis to be perfectly aligned 
with the prize in this machine.
The cheapest way to win the prize is by pushing the A button 80 times and the B button 40 times. 
This would line up the claw along the X axis (because 80*94 + 40*22 = 8400) and along the Y axis 
(because 80*34 + 40*67 = 5400). 
Doing this would cost 80*3 tokens for the A presses and 40*1 for the B presses, 
a total of 280 tokens.

For the second and fourth claw machines, there is no combination of A and B presses that will ever win a prize.

"""
def calc_cost(fixture : Fixture) -> tuple[bool, int]: 
    """
    A = (p_x*b_y - prize_y*b_x) / (a_x*b_y - a_y*b_x)
    B = (a_x*p_y - a_y*p_x) / (a_x*b_y - a_y*b_x)

    A = (8400*67 - 5400*22) / (94*67 - 34*22) = 80
    B = (8400*34 - 5400*94) / (94*67 - 34*22) = 40

    80 * 3 + 40 * 1 = 200

    """
    cost = 0
    result = False
    divisor = (fixture.ButtonA.X * fixture.ButtonB.Y - fixture.ButtonA.Y * fixture.ButtonB.X)
    a_dividend = fixture.Prize.X * fixture.ButtonB.Y - fixture.Prize.Y * fixture.ButtonB.X
    b_dividend = fixture.ButtonA.X * fixture.Prize.Y - fixture.ButtonA.Y * fixture.Prize.X

    if a_dividend % divisor == 0 and b_dividend % divisor == 0: 
        a = int ((a_dividend) / divisor)
        b = int ((b_dividend) / divisor)
        cost = a * 3 + b
        result = True
    
    return result, cost


@pytest.mark.parametrize("a_x, a_y, b_x, b_y, p_x, p_y, expected_result, expected_cost", [
    (94, 34, 22, 67, 8400, 5400, True, 280), 
    (26, 66, 67, 21, 12748, 12176, False, 0),
    (17, 86, 84, 37, 7870, 6450, True, 200),  
    (69, 23, 27, 71, 18641, 10279, False, 0)
])
def test_calc_cost(a_x: int, a_y: int, b_x : int, b_y: int, p_x: int, p_y: int, expected_result, expected_cost): 
    fixture = Fixture()
    fixture.ButtonA = Point(a_x, a_y)
    fixture.ButtonB = Point(b_x, b_y)
    fixture.Prize = Point(p_x, p_y)
    
    actual_result, actual_cost = calc_cost(fixture)
    assert((actual_result, actual_cost) == (expected_result, expected_cost))

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
    main()
