import pytest
from typing import List, Tuple
from pathlib import Path

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_inputs(file_name: str) -> List[Tuple[int, int]]: 
    path = get_input_filepath(file_name)
    result = [] 
    with open(path, "r") as file: 
        line = file.readline()
    inputs = line.split(',')
    for input in inputs:
        vals = input.split('-') 
        result.append((int(vals[0]), int(vals[1])))


    return result 

def part1(file_name: str) -> int: 
    inputs = load_inputs(file_name)
    result = 0
    for start, end in inputs:
        ids = find_invalid_ids(start, end)
        result += sum(ids)
    return result 

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result: {result}")

    # too low: 33906626186

def get_max_value(current: int) -> int: 
    val_text = str(current)
    val_len = len(val_text)
    return int('9' * val_len)
    
def get_next_valid_value(val: int) -> int: 
    
    val_text = str(val)
    val_len = len(val_text)
    if val_len % 2 == 0: 
        return val
    else: 
        max_valid_value = get_max_value(val)
        return max_valid_value + 1



def find_valid_ranges(start: int, end: int) -> List[Tuple[int, int]]: 
    current = start
    ranges = [] 
    while current < end: 
        current = get_next_valid_value(current)
        if current > end: 
            break
        current_end = min(get_max_value(current), end)
        ranges.append((current, current_end))
        current = current_end + 1

    return ranges

"""
    start and end are valid numbers: same number of digits and both have an even number of digits
    Returns the number of invalid ids in this range
"""
def find_invalid_ids_in_range(start: int, end: int) -> List[int]: 
    def increment_current(): 
        nonlocal current
        c_val = int(''.join([str(d) for d in current[0:mid_count]]))
        c_val += 1
        c_text = str(c_val)
        #for i in range(mid_count): 
        #    current[i] = int(c_text[i])
        current = [int(d) for d in c_text] + [0] * mid_count 

    result = []
    start_digits = [int(d) for d in str(start)]
    end_digits = [int(d) for d in str(end)]
    mid_count = len(start_digits) // 2
    for i in range(mid_count, len(start_digits)): 
        start_digits[i] = 0
        end_digits[i] = 0

    current = start_digits.copy()

    while len(current) == len(end_digits) and current <= end_digits: 
        val = int(''.join([str(d) for d in current[0:mid_count]]) * 2)
        if val >= start and val <= end: 
            result.append(val)
            increment_current()
        
        #else: 
        #    break

    return result

"""
start and end can have a different number of digits. We'll find the valid ranges 
for start and end and then find the invalid ids in each range. 

A valid range has a start and end with an even number of digits, and both have the same number
of digits
"""
def find_invalid_ids(start: int, end: int) -> List[int]: 
    result = [] 
    ranges = find_valid_ranges(start, end)
    for range_start, range_end in ranges: 
        result.extend(find_invalid_ids_in_range(range_start, range_end))
    return result


@pytest.mark.parametrize("start, end, expected", [
    (11, 22, [11, 22]), 
    (95, 115, [99]), 
    (998, 1012, [1010]), 
    (1188511880, 1188511890, [1188511885]), 
    (222220, 222224, [222222]), 
    (1698522, 1698528, []), 
    (446443, 446449, [446446]), 
    (38593856, 38593862, [38593859]), 
    (565653, 565659, []), 
    (824824821, 824824827, []), 
    (2121212118, 2121212124, [])
])
def test_find_invalid_ids(start: int, end: int, expected: List[int]): 
    result = find_invalid_ids(start, end)
    assert(result == expected)

@pytest.mark.parametrize("start, end, expected", [
    (11, 22, [(11, 22)]),
    (95, 115, [(95,99)]), 
    (998, 1012, [(1000, 1012)]),
    (1, 500000, [(10, 99), (1_000, 9_999), (100_000, 500_000)])
])
def test_find_valid_ranges(start: int, end: int, expected: List[Tuple[int, int]]): 
    result = find_valid_ranges(start, end)
    assert(result == expected)

@pytest.mark.parametrize("val, expected", [
    (34, 34), 
    (1, 10), 
    (100, 1_000), 
    (99_999, 100_000)
])
def test_get_next_valid_value(val: int, expected: int):
    result = get_next_valid_value(val)
    assert(result == expected)

@pytest.mark.parametrize("val, expected", [
    (4, 9),
    (99, 99), 
    (10, 99), 
    (123, 999), 
    (1324, 9999)
])
def test_max_value(val: int, expected: int): 
    result = get_max_value(val)
    assert(result == expected)


@pytest.mark.parametrize("start, end, expected", [
    (11, 22, [11, 22]), 
    (11, 35, [11, 22, 33]), 
    (9_595_822_750, 9_596_086_139, [9_595_895_958, 9_595_995_959]), 
    (1957, 2424, [2020, 2121, 2222, 2323, 2424])
])
def test_find_invalid_ids_in_range(start: int, end: int, expected: List[int]): 
    result = find_invalid_ids_in_range(start, end)
    assert(result == expected)

def test_load_inputs(): 
    file_name = "sample.txt"
    inputs = load_inputs(file_name)
    assert(len(inputs) > 0)
    assert(inputs[0] == (11, 22))

def test_part1(): 
    expected = 1227775554
    file_name = "sample.txt"
    result = part1(file_name)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()