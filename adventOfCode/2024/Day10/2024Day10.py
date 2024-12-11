import pytest
from pathlib import Path

def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_grid(file_name: str) -> list[list[int]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        grid = [(list(map(int, line.strip()))) for line in file.readlines()]

    return grid

def part1(file_name: str) -> int: 
    grid = load_grid(file_name)
    return 4

def main(): 
    result = part1("input.txt")
    print(f"Part 1 result: {result}")

"""
Only test sample inputs with all ints since that's how the real input is
"""
@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 1), 
    ("sample5.txt", 36), 
])
def test_part1(file_name, expected):
    result = part1(file_name)
    assert(result == expected)
    

if __name__ == "__main__": 
    pytest.main([__file__])