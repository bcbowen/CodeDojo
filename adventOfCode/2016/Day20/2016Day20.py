import pytest
from typing import List
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

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

        highest = values[0].end
        for i in range(1,len(values)):
            if values[i].start > highest + 1: 
                end = highest
                result.append(block_range(begin, highest))
                begin = values[i].start
                highest = values[i].end
                end = -1
            else:
                highest = max(highest, values[i].end)
        
        result.append(block_range(begin,  highest))

        return result

    def __str__(self) -> str:
        return f"{self.start}-{self.end}"
        
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

    """
    Precondition: combine has already been called, these are sorted and combined
    """
    @staticmethod
    def find_available_ip_count(values: "List[block_range]") -> int: 
        ip_range = 4294967296
        ip_count = ip_range

        for value in values: 
            ip_count -= (value.end - value.start + 1)

        return ip_count 

def load_test_data(file_name: str) -> List[block_range]: 
    inputs = Modules.aoc_io.read_input(2016, 20, file_name)
    result = [block_range.parse(line) for line in inputs.split('\n')]
    return result

def main(): 
    file_name = "input.txt"
    part1(file_name)   
    part2(file_name)
    

def part1(file_name: str) -> int: 
    ip_data = load_test_data(file_name)
    combined = block_range.combine(ip_data)
    first = block_range.find_first(combined)
    print(f'First available ip address for file {file_name} is {first}')    
    return first


# too high: 837429
def part2(file_name: str) -> int: 
    ip_data = load_test_data(file_name)
    combined = block_range.combine(ip_data)
    count = block_range.find_available_ip_count(combined)
    print(f"Part2 ip count for {file_name}: {count}")
    return count

def test_part1(): 
    file_name = "sample.txt"
    expected = 3
    result = part1(file_name)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 4294967288
    result = part2(file_name)
    assert(result == expected)

"""
5-8
0-2
4-7
"""
@pytest.mark.parametrize("ip_ranges, expected", [
    (["5-8", "0-2", "4-7"], ["0-2", "4-8"]), 
    (["0-1", "2-3", "4-5"], ["0-5"]),
    (["0-1", "1-3", "6-7"], ["0-3", "6-7"]),
])
def test_combine(ip_ranges: List[str], expected: List[str]): 
    block_list = [] 
    for ip_range in ip_ranges: 
        block_list.append(block_range.parse(ip_range))

    combined = block_range.combine(block_list)
    assert(len(combined) == len(expected))
    for i in range(len(combined)):
        assert(str(combined[i]) == expected[i]) 

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