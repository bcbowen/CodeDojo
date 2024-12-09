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

def load_data(file_name: str) -> list[str]: 
    path = get_input_filepath(file_name)
    drive = []
    with open(path, "r") as file:
        line = file.readline()
        #grid = [list(line.strip()) for line in file.readline()]
        id = 0 

        for i, size in enumerate(line): 
            if i % 2 == 0: 
                value = str(id)
                id += 1
            else: 
                value = '.'
            
            for j in range(int(size)): 
                drive.append(value)
    return drive

def calc_checksum(drive : list[str]) -> int: 
    checksum = 0
    for i, val in enumerate(drive): 
        if val == '.': 
            continue
        checksum += i * int(val)
    return checksum

def part1(file_name: str) -> int: 
    drive = load_data(file_name)


def test_part1(): 
    pass

def main(): 
    pass

def test_calc_checksum(): 
    expected = 1928
    drive = list("0099811188827773336446555566..............")
    result = calc_checksum(drive)
    assert(result == expected)

def test_load_data(): 
    drive = load_data("sample.txt")
    assert(isinstance(drive, list))
    assert(len(drive) == 42)
    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()