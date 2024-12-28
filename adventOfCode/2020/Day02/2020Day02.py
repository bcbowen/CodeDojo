import pytest
from pathlib import Path

class PasswordValidation: 
    def __init__(self, line: str):
        # 1-3 a: abcde
        fields = line.split(' ')
        tolerance = fields[0].split('-')
        self.min = int(tolerance[0])
        self.max = int(tolerance[1])
        self.test_char = fields[1][0]
        self.password = fields[2]

    def is_valid(self) -> bool: 
        count = 0

        for c in self.password: 
            if c == self.test_char: 
                count += 1
        return count >= self.min and count <= self.max 

def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_inputs(file_name: str) -> list[PasswordValidation]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        inputs = [PasswordValidation(line.strip()) for line in file.readlines()]
    return inputs

def main(): 
    result = part1("input.txt")
    print(f"Part 1 result: {result}")

def part1(file_name: str) -> int: 
    inputs = load_inputs(file_name)
    count = 0
    for p in inputs: 
        if p.is_valid():
            count += 1
    return count

"""
1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc
Each line gives the password policy and then the password. The password policy indicates the lowest 
and highest number of times a given letter must appear for the password to be valid. For example, 
1-3 a means that the password must contain a at least 1 time and at most 3 times.

In the above example, 2 passwords are valid. The middle password, cdefg, is not; it contains no 
instances of b, but needs at least 1. The first and third passwords are valid: they contain one a 
or nine c, both within the limits of their respective policies.
"""
@pytest.mark.parametrize("line, min, max, char, password, should_be_valid", [
    ("1-3 a: abcde", 1, 3, 'a', "abcde", True), 
    ("1-3 b: cdefg", 1, 3, 'b', "cdefg", False), 
    ("2-9 c: ccccccccc", 2, 9, 'c', "ccccccccc", True), 
])
def test_init(line: str, min: int, max: int, char: str, password: str, should_be_valid: bool): 
    p = PasswordValidation(line)
    assert(p.min == min)
    assert(p.max == max)
    assert(p.test_char == char)
    assert(p.password == password)
    assert(p.is_valid() == should_be_valid)

if __name__ == "__main__": 
    pytest.main([__file__])
    main()