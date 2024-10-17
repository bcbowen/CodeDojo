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


"""
0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45
"""
def load_data(file_name: str) -> list[list[int]]: 
    data = [] 
    
    input_path = get_input_filepath(file_name)
    text = ""
    with open(input_path) as file: 
        text = file.read() 
        file.close()

    for line in text.split('\n'): 
        data.append([int(nums) for nums in line.split(' ')])
        
    return data

    
def get_next(nums: list[int]) -> int: 
    matrix = []
    matrix.append([])
    matrix[0] = nums.copy()
    i = 1
    while len(matrix[i - 1]) > 1: 
        matrix.append([])
        matrix[i] = [matrix[i - 1][j + 1] - matrix[i - 1][j] for j in range(len(matrix[i - 1])-1)]
        if not any(x != 0 for x in matrix[i]): 
            break 
        i += 1

    for i in range(len(matrix) - 2,-1,-1): 
        matrix[i - 1].append(matrix[i][-1] + matrix[i - 1][-1])
    
    return matrix[0][-1]

def get_previous(nums: list[int]) -> int: 
    matrix = []
    matrix.append([])
    matrix[0] = nums.copy()
    i = 1
    while len(matrix[i - 1]) > 1: 
        matrix.append([])
        matrix[i] = [matrix[i - 1][j + 1] - matrix[i - 1][j] for j in range(len(matrix[i - 1])-1)]
        if not any(x != 0 for x in matrix[i]): 
            break 
        i += 1

    for i in range(len(matrix) - 2,-1,-1): 
        matrix[i - 1].insert(0, matrix[i - 1][0] - matrix[i][0])
        
    return matrix[0][0]



def part1(file_name: str) -> int: 
    data = load_data(file_name)
    total = 0
    for row in data:
        total += get_next(row)
    return total 

def part2(file_name: str) -> int: 
    data = load_data(file_name)
    total = 0
    for row in data:
        total += get_previous(row)
    return total

"""
0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45
"""
def test_load_data():
    file_name = "sample.txt"
    data = load_data(file_name)
    assert(len(data) == 3)
    assert(data[0][2] == 6)
    assert(data[1][0] == 1)
    assert(data[2][5] == 45)

def test_part1(): 
    expected = 114
    file_name = "sample.txt"
    result = part1(file_name)
    assert(expected == result)

def test_part2(): 
    expected = 2
    file_name = "sample.txt"
    result = part2(file_name)
    assert(expected == result)


@pytest.mark.parametrize("nums, expected", [
    ([0, 3, 6, 9, 12, 15], 18),
    ([1, 3, 6, 10, 15, 21], 28),
    ([10, 13, 16, 21, 30, 45], 68)
])
def test_get_next(nums: list[int], expected: int):
    result = get_next(nums)
    assert(expected == result)

@pytest.mark.parametrize("nums, expected", [
    ([0, 3, 6, 9, 12, 15], -3),
    ([1, 3, 6, 10, 15, 21], 0),
    ([10, 13, 16, 21, 30, 45], 5)
])
def test_get_previous(nums: list[int], expected: int):
    result = get_previous(nums)
    assert(expected == result)


if __name__ == "__main__": 
    pytest.main([__file__])
    result = part1("input.txt")
    print(f"Part1 result: {result}")
    result = part2("input.txt")
    print(f"Part2 result: {result}")