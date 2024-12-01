import pytest
from pathlib import Path
from collections import defaultdict

def get_input_filepath(file_name: str): 
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files 
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"
    
    input_path = private_files_base / year / day / file_name
    return input_path

def part1(file_name: str) -> int: 
    list1 = []
    list2 = []
    path = get_input_filepath(file_name)

    with open(path) as file: 
        text = file.read()
        file.close()
    lines = text.split('\n')
    #row = 0
    for line in lines: 
        nums = line.split(' ')
        if len(nums) > 1: 
            list1.append(int(nums[0]))
            list2.append(int(nums[-1]))

    list1 = sorted(list1)
    list2 = sorted(list2)
    diff = 0
    for i in range(len(list1)): 
        diff += abs(list1[i] - list2[i])

    return diff

def part2(file_name: str) -> int: 
    values = []
    counts = defaultdict(int)
    path = get_input_filepath(file_name)

    with open(path) as file: 
        text = file.read()
        file.close()
    lines = text.split('\n')
    #row = 0
    for line in lines: 
        nums = line.split(' ')
        if len(nums) > 1: 
            values.append(int(nums[0]))
            key = int(nums[-1])
            counts[key] += 1

    score = 0
    for i in range(len(values)): 
        key = values[i]
        score += key * counts[key]

    return score

def main():
    diff = part1("sample.txt")
    print(f"Sample part1: {diff}")
    diff = part1("input.txt")
    print(f"Part1: {diff}")
    diff = part2("sample.txt")
    print(f"Sample part2: {diff}")
    diff = part2("input.txt")
    print(f"Part2: {diff}")


def test_part1(): 
    file_name = "sample.txt"
    expected = 11
    result = part1(file_name)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 31
    result = part2(file_name)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
    main()