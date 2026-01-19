import math
import pytest
from typing import List
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

class HomeworkProblem: 

    def __init__(self): 
        self.values = [] 
        self.operator = '_'

    def calculate(self) -> int: 
        match self.operator: 
            case '+': 
                return sum(self.values)
            case '*': 
                return math.prod(self.values)
            case _: 
                return 0
        
    @staticmethod
    def calculate_all(problems: List["HomeworkProblem"]) -> int: 
        total = 0
        for p in problems: 
            total += p.calculate()

        return total

def get_inputs(file_name: str) -> List[HomeworkProblem]: 
    inputs = [] 
    lines = Modules.aoc_io.read_input(2025, 6, file_name).split('\n')

    # get numerical values
    for i in range(len(lines) - 1):
        values = lines[i].split()
        if len(inputs) == 0: 
            for _ in range(len(values)): 
                inputs.append(HomeworkProblem())
        
        for i in range(len(values)): 
            inputs[i].values.append(int(values[i]))

    # get operators
    i = len(lines) - 1
    values = lines[i].split()
    for i in range(len(values)): 
        inputs[i].operator = values[i]
    return inputs

def main(): 
    file_name = 'input.txt'
    result = part1(file_name)
    print(f"Part 1 result: {result}")

def part1(file_name: str) -> int: 
    inputs = get_inputs(file_name)
    return HomeworkProblem.calculate_all(inputs)

def test_part1(): 
    file_name = "sample.txt"
    expected = 4277556
    result = part1(file_name)
    assert(result == expected)


@pytest.mark.parametrize("values, operator, expected", [
    ([123, 45, 6], '*', 33210), 
    ([328, 64, 98], '+', 490), 
    ([51, 387, 215], '*', 4243455), 
    ([64, 23, 314], '+', 401)
])
def test_calculate(values: List[int], operator: str, expected: int): 
    p = HomeworkProblem() 
    p.values.extend(values)
    p.operator = operator
    result = p.calculate()
    assert(result == expected)


def test_get_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert(len(inputs) == 4)
    p = inputs[0]
    assert(len(p.values) == 3)
    assert(p.operator == '*')
    assert(p.values[0] == 123)
    assert(p.values[2] == 6)

    p = inputs[3]
    assert(len(p.values) == 3)
    assert(p.operator == '+')
    assert(p.values[0] == 64)
    assert(p.values[2] == 314)

if __name__ == "__main__":
    pytest.main([__file__])
    main()