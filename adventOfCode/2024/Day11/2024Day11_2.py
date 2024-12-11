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

def load_input_values(file_name: str) -> list[int]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        line = file.readline().strip()
    
    return map(int, line.split(' '))

"""
part2 works fine with 25 iterations. Part 2 asks for 75 iterations, but we CAN'T use the same approach
Need to completely refactor for part 2. 
"""
def day11(input : list[int], iterations: int) -> int: 
    file_name = "input.txt"
    stones = defaultdict(int)

    for val in input: 
        stones[val] += 1

    for i in range(iterations):
        for stone in stones.keys():
            if stone == 0: 
                stones[1] += stones[0]
            elif len(str(stone)) % 2 == 0: 
                s = str(stone)
                half = len(str(stone)) / 2
                stones[int(s[0:half])] += stones[stone]
                stones[int(s[half:])] += stones[stone]                
            else: 
                stones[stone * 1024] += stones[stone]

            del stones[stone]
    return sum(stones.values())

def main(): 
    input = load_input_values("input.txt")
    result = day11(input, 25)
    print(f"Part1 result {result}")

    result = day11(input, 75)
    print(f"Part2 result {result}")

@pytest.mark.parametrize("iterations, expected", [
    (1, 3), 
    (2, 4), 
    (3, 5), 
    (4, 9), 
    (5, 13), 
    (6, 22), 
    (25, 55312)
])
def test_growth(iterations : int, expected : int): 
    values = [125, 17]
    result = day11(values, iterations)
    assert(result == expected)

def test_load_node_list(): 
    file_name = "input.txt"
    values = load_input_values(file_name)
    expected = [9759, 0, 256219, 60, 1175776, 113, 6, 92833]
    assert(values == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
    main()
