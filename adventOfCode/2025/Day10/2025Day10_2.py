import pytest
import re
import z3
from pathlib import Path

# z3: pip install z3-solver
def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def get_inputs(file_name: str): # -> List[Tuple[str, Set[int]]]:
    path = get_input_filepath(file_name)
    inputs = []

    with open(path, "r") as file: 
        for line in file: 
            match = re.match(r"^\[([.#]+)\] ([()\d, ]+) \{([\d,]+)\}$", line.strip())
            _, buttons, joltages = match.groups()
            buttons = [set(map(int, button[1:-1].split(","))) for button in buttons.split()]
            joltages = list(map(int, joltages.split(",")))
            inputs.append((buttons, joltages))
    return inputs

"""
import re, z3

total = 0

for line in open(0):
    match = re.match(r"^\[([.#]+)\] ([()\d, ]+) \{([\d,]+)\}$", line.strip())
    _, buttons, joltages = match.groups()
    buttons = [set(map(int, button[1:-1].split(","))) for button in buttons.split()]
    joltages = list(map(int, joltages.split(",")))
    o = z3.Optimize()
    vars = z3.Ints(f"n{i}" for i in range(len(buttons)))
    for var in vars: o.add(var >= 0)
    for i, joltage in enumerate(joltages):
        equation = 0
        for b, button in enumerate(buttons):
            if i in button:
                equation += vars[b]
        o.add(equation == joltage)
    o.minimize(sum(vars))
    o.check()
    total += o.model().eval(sum(vars)).as_long()

print(total)
"""

def main(): 
    file_name = "input.txt"
    result = part2(file_name)
    print(f"Part 2: {result}")

def part2(file_name: str) -> int: 
    total = 0
    inputs = get_inputs(file_name)
    for buttons, joltages in inputs: 
        o = z3.Optimize()
        vars = z3.Ints(f"n{i}" for i in range(len(buttons)))
        for var in vars: o.add(var >= 0)
        for i, joltage in enumerate(joltages):
            equation = 0
            for b, button in enumerate(buttons):
                if i in button:
                    equation += vars[b]
            o.add(equation == joltage)
        o.minimize(sum(vars))
        o.check()
        total += o.model().eval(sum(vars)).as_long()
    return total

def test_part2(): 
    file_name = "sample.txt"
    expected = 33
    result = part2(file_name)
    assert(expected == result)

def test_get_inputs(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    assert(len(inputs) > 0)

if __name__ == "__main__":
    pytest.main([__file__])
    main()