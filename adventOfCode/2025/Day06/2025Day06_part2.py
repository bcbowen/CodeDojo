import math
import pytest
from typing import List
from pathlib import Path

class HomeworkProblem: 

    def __init__(self): 
        self.values = [] 
        self.operator = '_'

    def calculate(self) -> int:
        numbers = HomeworkProblem.parse_numbers(self) 
        match self.operator: 
            case '+':
                return sum(numbers)
            case '*': 
                return math.prod(numbers)
            case _: 
                return 0
    
    @staticmethod
    def parse_numbers(p: HomeworkProblem) -> List[int]:
        result = []
        for i in range(len(p.values[0]) - 1, -1, -1): 
            digits = []
            for j in range(len(p.values)): 
                if p.values[j][i] != ' ': 
                    digits.append(p.values[j][i])
            result.append(int(''.join(digits)))

        return result

    @staticmethod
    def calculate_all(problems: List["HomeworkProblem"]) -> int: 
        total = 0
        for p in problems: 
            total += p.calculate()

        return total

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def get_inputs(file_name: str, word_len: int) -> List[HomeworkProblem]: 
    inputs = [] 
    lines = []
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        lines = [line.strip('\n') + ' ' for line in file.readlines()]

    input_count = len(lines[0]) // (word_len + 1)
    for _ in range(input_count): 
        inputs.append(HomeworkProblem())

    # get numerical values
    for i in range(len(lines) - 1):
        #values = lines[i].split()
        #if len(inputs) == 0: 
        #    for _ in range(len(values)): 
        for j in range(len(inputs)):
            pos = j * (word_len + 1)
            inputs[j].values.append(lines[i][pos: pos + word_len - 1])


        

        #for i in range(len(values)): 
        #    inputs[i].values.append(int(values[i]))

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
    inputs = get_inputs(file_name, 4)
    return HomeworkProblem.calculate_all(inputs)

def test_part1(): 
    file_name = "sample.txt"
    expected = 4277556
    result = part1(file_name)
    assert(result == expected)


@pytest.mark.parametrize("values, operator, expected", [
    (["123", " 45", "  6"], '*', 8544), 
    (["328", "64 ", "98 "], '+', 625), 
    ([" 51", "387", "215"], '*', 3253600), 
    (["64 ", "23 ", "314"], '+', 1058)
])
def test_calculate(values: List[int], operator: str, expected: int): 
    p = HomeworkProblem() 
    p.values.extend(values)
    p.operator = operator
    result = p.calculate()
    assert(result == expected)

"""
123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  
Reading the problems right-to-left one column at a time, the problems are now quite different:

```text
The rightmost problem is 4 + 431 + 623 = 1058
The second problem from the right is 175 * 581 * 32 = 3253600
The third problem from the right is 8 + 248 + 369 = 625
Finally, the leftmost problem is 356 * 24 * 1 = 8544
Now, the g
"""

@pytest.mark.parametrize("values, expected", [
    (["64 ", "23 ", "314"], [4, 431, 623]),
    ([" 51", "387", "215"], [175, 581, 32]), 
    (["328", "64 ", "98 "], [8, 248, 369]), 
    (["123", " 45", "  6"], [356, 24, 1]) 
])
def test_get_numbers(values: List[str], expected: List[int]): 
    p = HomeworkProblem()
    result = HomeworkProblem.parse_numbers(p)
    assert(result == expected)


def test_get_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name, 3)
    assert(len(inputs) == 4)
    p = inputs[0]
    assert(len(p.values) == 3)
    assert(p.operator == '*')
    assert(p.values[0] == "123")
    assert(p.values[2] == "  6")

    p = inputs[3]
    assert(len(p.values) == 3)
    assert(p.operator == '+')
    assert(p.values[0] == "64 ")
    assert(p.values[2] == "314 ")

if __name__ == "__main__":
    pytest.main([__file__])
    main()