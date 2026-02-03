import pytest
from typing import List
from pathlib import Path

def get_inputs(file_name: str) -> str: 
    input = "" 
    current_path = Path(__file__).parent
    path = current_path / file_name
    with open(path, "r") as file:
        input = file.readline() 
    
    return input


def find_next(tunnel_map: str, tunnel: str, index: int) -> int: 
    pos = index + 1
    while pos < len(tunnel_map): 
        if tunnel_map[pos] == tunnel: 
            return pos
        pos += 1
    pos = index - 1
    while pos >= 0: 
        if tunnel_map[pos] == tunnel: 
            return pos
        pos -= 1

    raise Exception("Next not found!")

def part1(file_name: str) -> int: 
    result = 0
    tunnel_map = get_inputs(file_name)

    pos = 0
    while pos < len(tunnel_map): 
        next_pos = find_next(tunnel_map, tunnel_map[pos], pos)
        result += abs(pos - next_pos)
        if next_pos == len(tunnel_map) - 1: 
            break
        pos = next_pos + 1
    return result   

def part2(file_name: str) -> str: 
    tunnel_map = get_inputs(file_name)
    unvisited = tunnel_map

    pos = 0
    while pos < len(tunnel_map): 
        next_pos = find_next(tunnel_map, tunnel_map[pos], pos)
        unvisited = unvisited.replace(tunnel_map[pos], '')
        if next_pos == len(tunnel_map) - 1: 
            break
        pos = next_pos + 1
    result = set() 
    for c in unvisited: 
        result.add(c)
    return "".join(result)
  
def part3(file_name: str) -> int: 
    result = 0
    tunnel_map = get_inputs(file_name)
    

    return result   

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part1: {result}")

    result = part2(file_name)
    print(f"Part2: {result}")

    result = part3(file_name)
    print(f"Part3: {result}")


def test_load_inputs(): 
    file_name = "sample.txt"
    input = get_inputs(file_name)
    assert(len(input) == 14)
    

@pytest.mark.parametrize("tunnel_map, tunnel, index, expected", [
    ("dacabdcb", 'a', 1, 3),
    ("dacabdcb", 'a', 3, 1),
    ("dacabdcb", 'd', 0, 5),
    ("dacabdcb", 'd', 5, 0)
])
def test_find_next(tunnel_map: str, tunnel: str, index: int, expected: int): 
    result = find_next(tunnel_map, tunnel, index)
    assert(result == expected)

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = 38
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    result = part2(file_name)
    expected = 'Bc'
    assert(result == expected)

def test_part3(): 
    file_name = "sample.txt"
    result = part3(file_name)
    expected = -1
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()