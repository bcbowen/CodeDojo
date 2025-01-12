import pytest
from pathlib import Path
from itertools import combinations


def get_input_filepath(file_name: str) -> str:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def get_inputs(file_name: str) -> list[list[str]]: 
    #lookup = {}
    inputs = {}
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        for line in file.readlines(): 
            vals = line.strip().split('-')
            if not vals[0] in inputs: 
                inputs[vals[0]] = set()
            inputs[vals[0]].add(vals[1])

            if not vals[1] in inputs: 
                inputs[vals[1]] = set() 
            inputs[vals[1]].add(vals[0])
            
    return inputs        

def get_triplets(inputs : dict[str, set[str]]) -> set[tuple[str]]:
    triplets = set()
    for key in inputs: 
        neighbors = inputs[key]
        for neighbor1, neighbor2 in combinations(neighbors, 2): 
            if neighbor2 in inputs[neighbor1]: 
                triplets.add(tuple(sorted([key, neighbor1, neighbor2])))
    return triplets



def part1(file_name): 
    
    inputs = get_inputs(file_name)
    triplets = get_triplets(inputs)
    count_tees = 0
    for triplet in triplets: 
        if triplet[0][0] == 't' or triplet[1][0] == 't' or triplet[2][0] == 't':
            count_tees += 1
    return count_tees 

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result: {result}")

def test_part1(): 
    file_name = "sample.txt"
    expected = 7
    result = part1(file_name)
    assert(result == expected)

def test_get_inputs(): 
    file_name = 'sample.txt'
    inputs = get_inputs(file_name)
    # should contain aq,cg,yn
    triplets = get_triplets(inputs)
    expected = ("aq", "cg", "yn")
    found = False
    for group in triplets: 
        if group == expected: 
            found = True
            break
    assert(found)

if __name__ == "__main__":
    pytest.main([__file__])
    main()