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
    
    diffs = [b - a for a, b in zip(report, report[1:])]
    if diffs[0] == 0: 
        if tolerance == 0: 
            return False
        return is_safe(report[0:1] + report[2:], tolerance - 1) or is_safe(report[1:], tolerance - 1)

    increasing = diffs[0] > 0

    for i in range(len(diffs)): 
        if (increasing and diffs[i] <= 0) or (not increasing and diffs[i] >= 0) or abs(diffs[i]) > 3: 
            if tolerance == 0: 
                return False
            if i == 1: 
                return is_safe(report[0:1] + report[2:], tolerance - 1) or \
                    is_safe(report[0:2] + report[3:], tolerance - 1) or \
                    is_safe(report[1:], tolerance - 1)
            elif i == len(diffs) - 1: 
                return is_safe(report[0:i] + report[i + 1:], tolerance - 1) or is_safe(report[0:i + 1], tolerance - 1)
            else: 
                return is_safe(report[0:i] + report[i + 1:], tolerance - 1) or is_safe(report[0 : i + 1] + report[i + 2:], tolerance - 1)
    return True


def day2(file_name: str, tolerance: int) -> int: 
    
    path = get_input_filepath(file_name)

    parsed_reports = []
    with open(path, "r") as file: 
        parsed_reports = [[int(num) for num in line.split()] for line in file]

    safe_count = sum(1 for report in parsed_reports if is_safe(report, tolerance))
    
    return safe_count

def part2_troubleshooting(): 
    file_name = "input.txt"
    path = get_input_filepath(file_name)
    output_path = path.name.replace(file_name, "output.txt")

    parsed_reports = []
    with open(path, "r") as file: 
        parsed_reports = [[int(num) for num in line.split()] for line in file]

    has_dupes = []
    increasing = []
    decreasing = []
    mixed = []

    for report in parsed_reports: 
        if is_safe(report, 1): 
            diffs = [b - a for a, b in zip(report, report[1:])]
            note = f"{str(report)}\t{str(diffs)}\r\n"
            if 0 in diffs: 
                has_dupes.append(note)
            else: 
                is_increasing = diffs[0] > 0
                is_mixed = False
                for i in range(len(diffs)): 
                    if is_increasing and diffs[i] < 0 or not is_increasing and diffs[i] > 0: 
                        is_mixed = True
                        break
                if is_mixed: 
                    mixed.append(note)
                elif is_increasing: 
                    increasing.append(note)
                else: 
                    decreasing.append(note)              

    with open (output_path, "w") as file:
        file.write("Dupes: \r\n")
        file.writelines(has_dupes)
        file.write("\r\n")

        file.write("Mixed: \r\n")
        file.writelines(mixed)
        file.write("\r\n")

        file.write("Decreasing: \r\n")
        file.writelines(decreasing)
        file.write("\r\n")

        file.write("Increasing: \r\n")
        file.writelines(increasing)
        file.write("\r\n")
    

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

    #part2_troubleshooting()


@pytest.mark.parametrize("report, tolerance, expected", [
    ([7, 6, 4, 2, 1], 0, True), 
    ([1, 2, 6, 8, 9], 0, False), 
    ([9, 7, 6, 2, 1], 0, False), 
    ([1, 3, 2, 4, 5], 0, False), 
    ([8, 6, 4, 4, 1], 0, False), 
    ([1, 3, 6, 7, 9], 0, True), 
    ([7, 6, 4, 2, 1], 1, True), 
    ([1, 2, 6, 7, 8], 1, False), 
    ([9, 7, 6, 2, 1], 1, False), 
    ([1, 3, 2, 4, 5], 1, True), 
    ([8, 6, 4, 4, 1], 1, True), 
    ([1, 3, 6, 7, 9], 1, True), 
    ([3, 2, 3, 4, 5], 1, True), 
    ([1, 2, 3, 4, 3], 1, True),
    ([9, 2, 3, 4, 5], 1, True), 
    ([1, 2, 3, 4, 9], 1, True), 
    ([1, 2, 9, 4, 5], 1, True),
    ([1, 2, 2, 4, 5], 1, True), 
    ([2, 1, 2, 3, 4], 1, True), 
    ([5, 2, 2, 4, 5], 1, False), 
    ([1, 2, 2, 6, 7], 1, False), 
    ([1, 2, 4, 5, 4], 1, True), 
    ([1, 2, 5, 8, 1], 1, True), 
    ([1, 4, 3, 2, 1], 1, True), 
    ([1, 1, 2, 4, 4], 1, False), 
    ([56, 56, 55, 53, 51, 48, 48, 46], 1, False),
    ([58, 56, 56, 55, 53, 51, 48, 48, 46], 1, False), 
    ([58, 57, 56, 55, 53, 51, 48, 48, 46], 1, True), 
    ([36, 37, 36, 32, 31, 30, 29, 27], 1, False), 
    ([50, 57, 58, 60, 63, 60, 61, 60], 1, False), 
    ([48, 46, 47, 49, 51, 54, 56], 1, True), 
    ([1, 1, 2, 3, 4, 5], 1, True), 
    ([1, 2, 3, 4, 5, 5], 1, True), 
    ([5, 1, 2, 3, 4, 5], 1, True), 
    ([1, 4, 3, 2, 1], 1, True), 
    ([1, 6, 7, 8, 9], 1, True), 
    ([1, 2, 3, 4, 3], 1, True), 
    ([9, 8, 7, 6, 7], 1, True), 
    ([7, 10, 8, 10, 11], 1, True), 
    ([29, 28, 27, 25, 26, 25, 22, 20], 1, True), 
    ([7, 10, 8, 10, 11], 1, True), 
    ([29, 28, 27, 25, 26, 25, 22, 20], 1, True),
    ([9, 8, 7, 7, 7], 1, False),
    ([21, 22, 23, 21, 21], 1, False),
    ([8, 9, 10, 11], 0, True),
    ([31, 34, 32, 30, 28, 27, 24, 22], 1, True)
])
def test_is_safe(report: list[int], tolerance: int, expected: bool): 
    result = is_safe(report, tolerance)
    assert(expected == result)

def test_troubleshooting(): 
    report = [21, 22, 23, 21, 21]
    tolerance = 1
    expected = False
    result = is_safe(report, tolerance)
    assert(expected == result)

@pytest.mark.parametrize("tolerance, expected", [
    (0, 2), 
    (1, 4)
])
def test_day2(tolerance: int, expected: bool): 
    file_name = "sample.txt"
    result = day2(file_name, tolerance)
    assert(result == expected)

if __name__ == '__main__': 
    pytest.main([__file__])
    main()    