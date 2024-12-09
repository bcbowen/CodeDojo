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

def fill_drive(input: str) -> list[str]: 
    drive = []
    id = 0 
    for i, size in enumerate(input): 
        if i % 2 == 0: 
            value = str(id)
            id += 1
        else: 
            value = '.'
        
        for j in range(int(size)): 
            drive.append(value)
    return drive

def load_data(file_name: str) -> list[str]: 
    path = get_input_filepath(file_name)
    drive = []
    with open(path, "r") as file:
        line = file.readline()
        drive = fill_drive(line)
        
    return drive

def calc_checksum(drive : list[str]) -> int: 
    checksum = 0
    for i, val in enumerate(drive): 
        if val == '.': 
            continue
        checksum += i * int(val)
    return checksum

"""
Find free space in drive of the given size. Finds first space from the left
limit: How far right to search... we don't want to move the file farther right than it currently is
"""
def find_space(drive: list[str], size: int, limit: int) -> tuple[bool, tuple[int, int]]:
    l = 0
    r = 0
    found = False
    for l in range(limit):
        if drive[l] == '.': 
            if (size > 1): 
                for r in range(l + 1, l + size): 
                    if drive[r] != '.': 
                        l = r
                        r = 0
                        break
            else: 
                r = l

            if r == l + size - 1: 
                found = True
                break
                    

    return (found, (l, r))

def move_file(drive: list[str], source: tuple[int, int], destination: tuple[int, int]): 
    for i in range(source[1] - source[0] + 1): 
        drive[source[0] + i], drive[destination[0] + i] = drive[destination[0] + i], drive[source[0] + i] 

def part2(file_name: str) -> int: 
    drive = load_data(file_name)
    r = len(drive) - 1
    moved = set()
    while r >= 0: 
        
        while drive[r] == '.': 
            r -= 1
        id = drive[r]
        if id not in moved: 
            
            source_end = r
            while drive[r] == id: 
                r -= 1
            source_begin = r + 1

            source_len = source_end - source_begin + 1

            space_found, destination = find_space(drive, source_len, source_begin)

            if space_found: 
                move_file(drive, (source_begin, source_end), destination)
                moved.add(id)
        else:
            while drive[r] == id: 
                r -= 1
        """
        
        for dest_begin in range(len(drive)): 
            if drive[dest_begin == '.']: 
                dest_end = dest_begin + 1
                while drive[dest_end] == '.' and dest_end < dest_begin + source_len: 
                    dest_end += 1
                if dest_end - dest_begin == source_end - source_begin: 
                    for i in range(source_len): 
                        drive[dest_begin + i], drive[source_begin + i] = drive[source_begin + i], drive[dest_begin + i]
        """

    #print(f"r: {r}\n {drive}")
    return calc_checksum(drive)
        
def test_part2(): 
    file_name = "sample.txt"
    expected = 2858
    result = part2(file_name)
    assert(result == expected)

def main(): 
    # part 2:
    result = part2("sample.txt")
    print(f"Sample part 2: {result}")
    
    result = part2("input.txt")
    print(f"Part 2: {result}")


def test_calc_checksum(): 
    expected = 1928
    drive = list("0099811188827773336446555566..............")
    result = calc_checksum(drive)
    assert(result == expected)

def test_load_data(): 
    drive = load_data("sample.txt")
    assert(isinstance(drive, list))
    assert(len(drive) == 42)
    expected = "00...111...2...333.44.5555.6666.777.888899"
    for i, val in enumerate(expected): 
        assert(drive[i] == val)

@pytest.mark.parametrize("input, expected", [
    ("2333133121414131402", "00...111...2...333.44.5555.6666.777.888899"),
    ("21311131214141314023", "00.111.2.333.44.5555.6666.777.888899...")
])
def test_fill_drive(input : str, expected : str):
    drive = fill_drive(input)
    for i, val in enumerate(expected): 
        assert(drive[i] == val)

@pytest.mark.parametrize("input, space, expected, expected_location", [
    ("2333133121414131402", 3, True, (2, 4)), 
    ("2333133121414131402", 5, False, (0, 0))
])
def test_find_space(input: str, space: int, expected: bool, expected_location: tuple[int, int]):
    drive = fill_drive(input)
    (result, location) = find_space(drive, space, len(drive) - space)
    assert(result == expected)
    if expected == True: 
        assert location == expected_location
    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()