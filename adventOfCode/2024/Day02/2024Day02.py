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

def is_safe(report: list[int], tolerance: int) -> bool: 
    if len(report) < 2 or report[0] == report[1]: 
        return False

    increasing = report[1] > report[0]

    is_bad = False
    for i in range(1, len(report)): 
        if increasing and report[i] <= report[i - 1]: 
            is_bad = True        
        
        if not increasing and report[i] >= report[i -1]: 
            is_bad = True
        
        diff = abs(report[i] - report[i - 1])
        if diff > 3: 
            is_bad = True

        if is_bad: 
            if tolerance == 0: 
                return False
            if i == len(report) - 1: 
                return True
            return is_safe(report[0 : i] + report[i + 1 :] , tolerance - 1)
        
    return True

def day2(file_name: str, tolerance: int) -> int: 
    
    path = get_input_filepath(file_name)

    parsed_reports = []
    with open(path, "r") as file: 
        parsed_reports = [[int(num) for num in line.split()] for line in file]

    safe_count = sum(1 for report in parsed_reports if is_safe(report, tolerance))
    
    return safe_count

def main():
    # part 1: 
    result = day2("sample.txt", 0)
    print(f"Sample part1: {result}")
    result = day2("input.txt", 0)
    print(f"Part1: {result}")
    # part 2: 
    result = day2("sample.txt", 1)
    print(f"Sample part2: {result}")
    result = day2("input.txt", 1)
    print(f"Part2: {result}")


@pytest.mark.parametrize("report, tolerance, expected", [
    ([7, 6, 4, 2, 1], 0, True), 
    ([1, 2, 7, 8, 9], 0, False), 
    ([9, 7, 6, 2, 1], 0, False), 
    ([1, 3, 2, 4, 5], 0, False), 
    ([8, 6, 4, 4, 1], 0, False), 
    ([1, 3, 6, 7, 9], 0, True), 
    ([7, 6, 4, 2, 1], 1, True), 
    ([1, 2, 7, 8, 9], 1, False), 
    ([9, 7, 6, 2, 1], 1, False), 
    ([1, 3, 2, 4, 5], 1, True), 
    ([8, 6, 4, 4, 1], 1, True), 
    ([1, 3, 6, 7, 9], 1, True), 
    ([3, 2, 3, 4, 5], 1, True), 
    ([1, 2, 3, 4, 3], 1, True),
    ([9, 2, 3, 4, 5], 1, True), 
    ([1, 2, 3, 4, 9], 1, True), 
    ([1, 2, 9, 4, 5], 1, True),
    ([1, 2, 2, 4, 5], 1, True)
])
def test_is_safe(report: list[int], tolerance: int, expected: bool): 
    result = is_safe(report, tolerance)
    assert(expected == result)

def test_part1(): 
    file_name = "sample.txt"
    expected = 2
    # part1
    result = day2(file_name, 0)
    assert(result == expected)
    # part2
    expected = 4
    result = day2(file_name, 1)
    assert(result == expected)

if __name__ == '__main__': 
    pytest.main([__file__])
    main()    