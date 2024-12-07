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
            if key in input: 
                raise Exception("key already exists man: " + str(key))
            values = list(map(int, value_part.strip().split()))
            input[key] = values
    return input


def get_ops(len: int) -> list[str]: 
    if len in op_permutations: 
        return op_permutations[len]
    
    add = lambda a, b: a + b
    mul = lambda a, b: a * b
    op_list = [add, mul]
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

def part1_output(file_name, good, bad): 
    with open(f"{file_name}_good.txt", "w") as file: 
        for line in good: 
            file.write(line + "\n")
    with open(f"{file_name}_bad.txt", "w") as file: 
        for line in bad: 
            file.write(line + "\n")

def part1(file_name: str) -> int: 
    input = load_input(file_name)
    total = 0
    good = [] 
    bad = []
    for key in input: 
        if check_values(key, input[key]): 
            total += key
            good.append(f"{key}: {input[key]}")
        else: 
            bad.append(f"{key}: {input[key]}")

    part1_output(file_name, good, bad)
    return total

def test_part1(): 
    expected = 3749
    result = part1("sample.txt")
    assert(result == expected)

#def test_part2(file_name: str): 
#    pass

# too low: 1038838357435
# todo: key 360 is duplicated, update input to handle dupe keys
def main(): 
    
    # part 1:
    result = part1("sample.txt")
    print(f"Sample part1: {result}")
    
    result = part1("input.txt")
    print(f"Part1: {result}")
    
    
    """
    # part 2:
    result = part2("sample.txt")
    print(f"Sample part2: {result}")
    result = part2("input.txt")
    print(f"Part2: {result}")
    """

def test_part1(): 
    expected = 3749
    result = part1("sample.txt")
    assert (expected == result)

def test_input_load(): 
    input = load_input("sample.txt")
    assert(input[190] == [10, 19])

if __name__ == "__main__": 
    pytest.main([__file__])
    main()