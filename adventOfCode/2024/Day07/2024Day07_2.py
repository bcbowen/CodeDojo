import pytest
from pathlib import Path
from itertools import product

op_permutations = {}

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
            if not key in input: 
                input[key] = []
            input[key].append(values)
    return input


def get_ops(len: int) -> list[str]: 
    if len in op_permutations: 
        return op_permutations[len]
    
    add = lambda a, b: a + b
    mul = lambda a, b: a * b
    concat = lambda a, b: int(str(a) + str(b))
    op_list = [add, mul, concat]
    ops = [p for p in product(op_list, repeat=len)]
    op_permutations[len] = ops
    return ops

def check_values(total: int, values: list[int]) -> bool: 
    for op_set in get_ops(len(values) - 1): 
        running_total = values[0]
        
        for i in range(1, len(values)): 
            running_total = op_set[i - 1](running_total, values[i])
            if running_total > total: 
                break

        if running_total == total: 
            return True
    return False

def part2(file_name: str) -> int: 
    input = load_input(file_name)
    total = 0
    for key in input: 
        for values in input[key]: 
            if check_values(key, values): 
                total += key
    return total

def main(): 
    
    # part 1:
    result = part2("sample.txt")
    print(f"Sample part2: {result}")
    
    result = part2("input.txt")
    print(f"Part2: {result}")
    

def test_part2(): 
    expected = 11387
    result = part2("sample.txt")
    assert (expected == result)

def test_input_load(): 
    input = load_input("sample.txt")
    assert(input[190][0] == [10, 19])

if __name__ == "__main__": 
    pytest.main([__file__])
    main()