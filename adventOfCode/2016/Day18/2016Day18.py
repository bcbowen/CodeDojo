import pytest
from operator import xor
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io
from pathlib import Path

def get_first_row(file_name: str) -> str: 
    row = Modules.aoc_io.read_input(2016, 18, file_name)
    return row

"""
A new tile is a trap only in one of the following situations:

- Its left and center tiles are traps, but its right tile is not.  
- Its center and right tiles are traps, but its left tile is not.  
- Only its left tile is a trap.  
- Only its right tile is a trap.  
"""
def generate_row(previous_row : str) -> str:
    new_row = ['.'] * len(previous_row)
    for i in range(len(previous_row)): 
        new_row[i] = get_value(previous_row, i)

    return ''.join(new_row)      

def get_value(previous_row: str, position: int) -> str: 
    is_trap = False
    if position == 0: 
        is_trap = previous_row[1] == '^'
    elif position == len(previous_row) - 1: 
        is_trap = previous_row[-2] == '^'
    else: 
        is_trap = previous_row[position - 1] != previous_row[position + 1]
    
    return '^' if is_trap else '.'

def day18(file_name: str, row_count: int) -> int: 
    first_row = get_first_row(file_name)
    current_row = first_row
    safe_count = current_row.count('.')
    for _ in range(row_count - 1): 
        current_row = generate_row(current_row)
        safe_count += current_row.count('.')
    
    print(f"{file_name} safe count: {safe_count} for {row_count} rows")
    return safe_count

def main(): 
    result = day18("input.txt", 40)
    print(f"Part 1 result: {result}")
    result = day18("input.txt", 400000)
    print(f"Part 2 result: {result}")


@pytest.mark.parametrize("previous_row, index, expected", [
    (".^...", 0, "^"),
    ("^^...", 0, "^"),
    ("^....", 0, "."),
    ("..^..", 3, "^"),
    ("..^^.", 3, "^"),
    (".^^^.", 2, "."),
    ("..^^.", 2, "^"),
    ("...^.", 2, "^"), 
    (".....", 2, ".") 
])
def test_get_value(previous_row: str, index: int, expected: str): 
    result = get_value(previous_row, index)
    assert(result == expected)

@pytest.mark.parametrize("file_name, expected", [
    ("sample_row1.txt", "..^^."), 
    ("sample_row2.txt", ".^^.^.^^^^")
])
def test_get_first_row(file_name: str, expected: str): 
    result = get_first_row(file_name)
    assert(result == expected)

"""

```text
ABCDE
12345
```

The type of tile 2 is based on the types of tiles A, B, and C; 
the type of tile 5 is based on tiles D, E, and an imaginary "safe" tile. 
Let's call these three tiles from the previous row the left, center, and right tiles, 
respectively. Then, a new tile is a trap only in one of the following situations:

- Its left and center tiles are traps, but its right tile is not.  
- Its center and right tiles are traps, but its left tile is not.  
- Only its left tile is a trap.  
- Only its right tile is a trap.  

In any other situation, the new tile is safe.



..^^.
.^^^^
^^..^

.^^.^.^^^^
^^^...^..^
^.^^.^.^^.
..^^...^^^
.^^^^.^^.^
^^..^.^^..
^^^^..^^^.
^..^^^^.^^
.^^^..^.^^
^^.^^^..^^

"""
@pytest.mark.parametrize("previous_row, expected", [
    ("..^^.", ".^^^^"), 
    (".^^^^", "^^..^"), 
    (".^^.^.^^^^", "^^^...^..^"), 
    (".^^^..^.^^", "^^.^^^..^^"), 
    (".^^.^.^^^^", "^^^...^..^"),
    ("^.^^.^.^^.", "..^^...^^^"),
    (".^^^^.^^.^", "^^..^.^^.."),
    ("^^^^..^^^.", "^..^^^^.^^"),
    (".^^^..^.^^", "^^.^^^..^^")
])
def test_generate_row(previous_row: str, expected: str): 
    result = generate_row(previous_row)
    assert(result == expected)

@pytest.mark.parametrize("file_name, row_count, expected", [
    ("sample_row1.txt", 3, 6), 
    ("sample_row2.txt", 10, 38)
])
def test_day18(file_name: str, row_count: int, expected: int): 
    result = day18(file_name, row_count)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()