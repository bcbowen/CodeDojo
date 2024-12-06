import pytest
from collections import defaultdict
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

def load_data(file_name : str) -> tuple[dict[int, list[int]], list[list[int]]]: 
    path = get_input_filepath(file_name)
    rules = defaultdict(list[int])
    pages = []
    with open(path, "r") as file: 
        reading_rules = True
        for line in file.readlines(): 
            if reading_rules: 
                if line.strip() == "": 
                    reading_rules = False
                    continue

                fields = line.split('|')
                rules[int(fields[0])].append(int(fields[1]))
            else: 
                pages.append([int(page) for page in line.split(',')]) 
    return rules, pages   

"""
Find pages that are in the correct order and total up the middle page number for each, for obvious reasons
"""
def part1(file_name: str) -> int: 
    rules, pages = load_data(file_name)
    total = 0

    for job in pages: 
        is_bad = False
        for i in range(len(job) - 1): 
            if job[i + 1] in rules and job[i] in rules[job[i + 1]]: 
                is_bad = True
                break
        if not is_bad: 
            mid = len(job)//2
            total += job[mid]
    return total 

def test_load(): 
    file_name = "sample.txt"
    rules, pages = load_data(file_name)
    assert(97 in rules)
    assert(len(rules[97]) > 0)
    assert(len(pages) == 6)
    assert(75 in pages[0])

def test_part1(): 
    result = part1("sample.txt")
    expected = 143
    assert(result == expected)

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
    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()