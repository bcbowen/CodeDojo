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

def main():
    # part 1:
    result = day2("sample.txt", 0)
    print(f"Sample part1: {result}")
    result = day2("input.txt", 0)
    print(f"Part1: {result}")
    # part 2:
    result = day2("sample.txt", 1)
    print(f"Sample part2: {result}")
    result = day2("input.txt", 1)
    print(f"Part2: {result}")

if __name__ == "__main__": 
    pytest.main([__file__])
    main()
