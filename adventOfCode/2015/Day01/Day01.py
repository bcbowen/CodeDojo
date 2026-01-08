import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io
import pytest

def main(): 
	file_name = "input.txt"
	result = part1(file_name)
	print(f"Part 1: {result}")

	result = part2(file_name)
	print(f"Part 2: {result}")

def santa_basement(input: str) -> int: 
	result = 0
	position = 0; 
	for c in input:
		position += 1 
		if c == '(':
			result += 1
		else: 
			result -= 1
			
		if (result < 0): 
			return position; 
	
	return -1


def santa_elevator(input: str) -> int: 
	result = 0
	for c in input: 
		if c == '(': 
			result += 1
		else: 
			result -= 1

	return result

def part1(file_name: str) -> int:
	input = Modules.aoc_io.read_input(2015, 1, file_name)
	return santa_elevator(input)
	
def part2(file_name: str) -> int:
	input = Modules.aoc_io.read_input(2015, 1, file_name)
	return santa_basement(input)
	

@pytest.mark.parametrize("input, expected", [
	("(())", 0),
	("()()", 0),
	("(((", 3),
	("(()(()(", 3),
	("))(((((", 3),
	("())", -1),
	("))(", -1),
	(")))", -3),
	(")())())", -3)
])
def test_santa_elevator(input: str, expected: int):  
	result = santa_elevator(input) 
	assert(expected == result) 

@pytest.mark.parametrize("input, expected", [
	(")", 1),
	("()())", 5)
])
def test_santa_basement(input: str, expected: int): 
	result = santa_basement(input)
	assert(expected == result) 

def test_part1(): 
	file_name = "sample.txt"
	expected = 3 
	result = part1(file_name)
	assert(expected == result)

def test_load_input(): 
    file_name = "input.txt"
    input = Modules.aoc_io.read_input(2015, 1, file_name)
    assert(len(input) > 0)

if __name__ == "__main__":
    pytest.main([__file__])
    main()