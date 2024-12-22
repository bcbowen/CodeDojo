import pytest
from pathlib import Path

def get_input_filepath(file_name: str) -> str:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path


def get_test_data(file_name: str) -> tuple[list[str], list[str]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        lines = file.readlines()
        patterns = [value.strip() for value in lines[0].split(', ')]
        designs = [line.strip() for line in lines[2:]]
    return patterns, designs

def get_possible_pattern_count(patterns : list[str], designs: list[str]) -> int: 
    count = 0

    return count

def get_total_pattern_count(patterns : list[str], designs: list[str]) -> int: 
    count = 0

    def get_pattern_count(patterns : list[str], design: str) -> int: 
        count = 0
        left = [["", 1]]
        while len(left) > 0: 
            if left[0][0] == design: 
                print("Found new paths: ", left[0][1])
                count += left[0][1]
            elif len(left[0][0]) < len(design): 
                for pattern in patterns: 
                    word = left[0][0] + pattern
                    if word[:len(word)] == design[:len(word)]:
                        for index in range(1, len(left)):
                          if word == left[index][0]:
                              left[index][1] += left[0][1]
                              break
                        else: 
                            left.append([word, left[0][1]])
            left = left[1:]

        return count
    
    for index, design in enumerate(designs):
        print(f"Processing design {index} of {len(designs)}: {design}") 
        count += get_pattern_count(patterns, design)
    
    return count

def part1(file_name: str) -> int: 
    patterns, designs = get_test_data(file_name)
    result = get_possible_pattern_count(patterns, designs)
    return result

def part2(file_name: str) -> int: 
    patterns, designs = get_test_data(file_name)
    result = get_total_pattern_count(patterns, designs)
    return result


def test_part1(): 
    file_name = "sample.txt"
    expected = 6
    result = part1(file_name)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 16
    result = part2(file_name)
    assert(result == expected)


@pytest.mark.parametrize("value, expected", [
    ("brwrr", 2), 
    ("bggr", 1),
    ("gbbr", 4),
    ("rrbgbr", 6),
    ("ubwu", 0),
    ("bwurrg", 1),
    ("brgr", 2),
    ("bbrgwb", 0)
])
def test_get_possible_combo_count(value : str, expected: int): 
    file_name = "sample.txt"
    patterns, _ = get_test_data(file_name)
    designs = [value]
    result = get_total_pattern_count(patterns, designs)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = 16
    result = part2(file_name)
    assert(result == expected)

@pytest.mark.parametrize("value, expected", [
    ("brwrr", True), 
    ("bggr", True),
    ("gbbr", True),
    ("rrbgbr", True),
    ("ubwu", False),
    ("bwurrg", True),
    ("brgr", True),
    ("bbrgwb", False)
])
def test_is_possible(value : str, expected: bool): 
    file_name = "sample.txt"
    patterns, _ = get_test_data(file_name)
    designs = [value]
    result = get_possible_pattern_count(patterns, designs) > 0
    assert(result == expected)
   
def test_load_inputs(): 
    file_name = "sample.txt"
    patterns, designs = get_test_data(file_name)
    assert("r" in patterns)
    assert("br" in patterns)

    assert(len(designs) == 8)
    assert(designs[1] == "bggr")

# 400 is too high
def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result for {file_name}: {result}")
    result = part2(file_name)
    print(f"Part 2 result for {file_name}: {result}")

if __name__ == "__main__": 
    pytest.main([__file__])
    main()