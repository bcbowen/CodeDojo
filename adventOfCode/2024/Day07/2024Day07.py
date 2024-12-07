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

def load_input(file_name: str) -> dict[int, list[int]]: 
    path = get_input_filepath(file_name)
    input = {}
    with open(path, "r") as file: 
        for line in file.readlines():
            key_part, value_part = line.split(':') 
            key = int(key_part.strip())
            values = list(map(int, value_part.strip().split()))
            input[key] = values
    return input


def part1(): 
    pass

def test_part1(): 
    pass

def test_part2(): 
    pass


def main(): 
    pass

def test_input_load(): 
    input = load_input("sample.txt")
    assert(input[190] == [10, 19])

if __name__ == "__main__": 
    pytest.main([__file__])
    main()