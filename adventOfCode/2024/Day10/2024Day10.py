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

def part1(file_name: str): 
    pass

def main(): 
    pass

@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", 1), 
    ("sample2.txt", 2), 
    ("sample3.txt", 4), 
    ("sample4.txt", 3), 
    ("sample5.txt", 36), 
])
def test_part1(file_name, expected):
    pass
    

if __name__ == "__main__": 
    pytest.main([__file__])