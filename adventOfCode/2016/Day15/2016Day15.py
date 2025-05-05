import pytest
from pathlib import Path
from typing import List, Tuple

def get_input_filepath(file_name: str) -> str:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

def load_disks(file_name: str) -> List[Tuple[int, int]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        disks = [parse_disk(line) for line in file.readlines()]
    return disks

def parse_disk(line: str) -> Tuple[int, int]: 
    fields = line.split(' ')
    len = int(fields[3])
    start = int(fields[-1].replace('.', ''))
    return (len, start)

# 249 too low
def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part1 result: {result}")
    result = part2(file_name)
    print(f"Part2 result: {result}")

def part1(file: str) -> int: 
    disks = load_disks(file)
    disk1_len, disk1_start = disks[0]
    time = disk1_len - disk1_start
    found = False
    while not found: 
        for i in range(1, len(disks)): 
            if is_zero(disks[i], time + i): 
                if i == len(disks) - 1: 
                    found = True

                    break
            else: 
                time += disk1_len
                break
    return time - 1

def part2(file: str) -> int: 
    disks = load_disks(file)
    disks.append((11, 0))
    disk1_len, disk1_start = disks[0]
    time = disk1_len - disk1_start
    found = False
    while not found: 
        for i in range(1, len(disks)): 
            if is_zero(disks[i], time + i): 
                if i == len(disks) - 1: 
                    found = True

                    break
            else: 
                time += disk1_len
                break
    return time - 1


def is_zero(disk: Tuple[int, int], iteration: int) -> bool: 
    len, start = disk
    return (start + iteration) % len == 0    

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name) 
    expected = 5
    assert(result == expected)

@pytest.mark.parametrize("line, len, start", [
     ("Disc #1 has 5 positions; at time=0, it is at position 4.", 5, 4), 
     ("Disc #2 has 2 positions; at time=0, it is at position 1.", 2, 1)
])
def test_parse_disk(line: str, len: int, start: int): 
    result = parse_disk(line)
    assert(result[0] == len)
    assert(result[1] == start)

def test_load_dists(): 
    file_name = "sample.txt"
    disks = load_disks(file_name)
    assert(len(disks) == 2)
    disk = disks[0]
    assert(disk[0] == 5)
    assert(disk[1] == 4)
    disk = disks[1]
    assert(disk[0] == 2)
    assert(disk[1] == 1)

@pytest.mark.parametrize("len, start, iteration, expected", [
    (5, 4, 1, True), 
    (5, 4, 0, False), 
    (5, 4, 2, False), 
    (5, 4, 3, False), 
    (5, 4, 4, False),  
    (5, 4, 5, False),
    (5, 4, 6, True),
    (2, 1, 7, True),
    (2, 1, 6, False)
])
def test_is_zero(len: int, start: int, iteration: int, expected: bool): 
    result = is_zero((len, start), iteration)
    assert(result == expected)            

if __name__ == "__main__":
    pytest.main([__file__])
    main()