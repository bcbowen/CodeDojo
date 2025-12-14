import math
import pytest
from typing import List
from pathlib import Path


class junction: 
    def __init__(self, x, y, z):
        self.x = x
        self.y = y
        self.z = z

    @staticmethod
    def get_distance(j1: junction, j2: junction) -> float: 
        return math.sqrt((j2.x - j1.x)**2 + (j2.y - j1.y)**2 + (j2.z - j1.z)**2) 

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def get_inputs(file_name: str) -> List[List[int]]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        inputs = [[int(d) for d in line.strip().split(',')] for line in file.readlines()]
    return inputs

def main(): 
    pass

def part1(file_name: str, connection_count: int, rank: int) -> int: 
    distances = {}
    inputs = get_inputs(file_name)


def test_get_inputs(): 
    file_name = "sample.txt"
    result = get_inputs(file_name)
    assert(len(result) == 20)
    assert(len(result[0]) == 3)
    

if __name__ == "__main__":
    pytest.main([__file__])
    main()