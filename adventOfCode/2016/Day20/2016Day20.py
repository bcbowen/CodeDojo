import pytest
from typing import List
from pathlib import Path

def get_input_filepath(file_name: str) -> Path:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

class block_range: 
    def __init__(self, start: int, end: int): 
        self.start = start
        self.end = end
    
    @staticmethod
    def parse(val: str) -> "block_range": 
         vals = val.split('-')
         if len(vals) != 2: 
              raise Exception(f"Invalid parse string: {val}")
         return block_range(int(vals[0]), int(vals[1]))

    @staticmethod
    def combine(values: "List[block_range]") -> "List[block_range]":
        result : List[block_range] = []
        values.sort(key=lambda val: val.start)
        begin = values[0].start
        end = -1

        for i in range(1,len(values)):
            if values[i].start > values[i - 1].end: 
                end = values[i - 1].end
                result.append(block_range(begin, end))
                begin = values[i].start
                end = -1
        
        if end == -1: 
            result.append(block_range(begin, values[-1].end))
        
        return result
    
    """
    Precondition: combine has already been called, these are sorted and combined
    """
    @staticmethod
    def find_first(values: "List[block_range]") -> int: 
        if values[0].start > 1: 
            return 1
        for i in range(len(values)):
            if values[i].start - values[i - 1].end > 1: 
                return values[i - 1].end + 1
        return -1 

def load_test_data(file_name: str) -> List[block_range]: 
    result = [] 
    path = get_input_filepath(file_name)
    with open(path) as file: 
        for line in file.readlines():
            result.append(block_range.parse(line))
    return result

def main(): 
    file_name = "input.txt"
    part1(file_name)   
    

def part1(file_name: str) -> int: 
    ip_data = load_test_data(file_name)
    block_range.combine(ip_data)
    first = block_range.find_first(ip_data)
    print(f'First available ip address for file {file_name} is {first}')    
    return first

def test_part1(): 
    file_name = "sample.txt"
    expected = 3
    result = part1(file_name)
    assert(result == expected)

"""
5-8
0-2
4-7
"""
def test_combine(): 
    values : List[block_range] = []
    values.append(block_range(5, 8))
    values.append(block_range(0, 2))
    values.append(block_range(4, 7))
    result = block_range.combine(values)
    assert(len(result) == 2)
    assert(result[0].start == 0)
    assert(result[0].end == 2)
    assert(result[1].start == 4)
    assert(result[1].end == 8)

"""
5-8
0-2
4-7
"""
def test_find_first(): 
    values : List[block_range] = []
    values.append(block_range(5, 8))
    values.append(block_range(0, 2))
    values.append(block_range(4, 7))
    combined = block_range.combine(values)
    expected = 3
    result = block_range.find_first(combined)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()