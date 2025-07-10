import pytest
#from typing import List
from operator import xor
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

"""
A new tile is a trap only in one of the following situations:

- Its left and center tiles are traps, but its right tile is not.  
- Its center and right tiles are traps, but its left tile is not.  
- Only its left tile is a trap.  
- Only its right tile is a trap.  
"""
def generate_row(previous_row : str) -> str:
    new_row = ['.'] * len(previous_row)
    # left edge
    if previous_row[0] != previous_row[1]: 
        new_row[0] = '^'
    for i in range(1, len(previous_row) - 1):
        if previous_row[i] == '^' and xor(previous_row[i - 1] == '^', previous_row[i + 1] == '^'):
            new_row[i] = '^'
        elif previous_row == '.' and xor(previous_row[i - 1] == '^', previous_row[i + 1] == '^'): 
            new_row[i] = '^'  
    # right edge
    if previous_row[-1] != previous_row[-2]: 
        new_row[-1] = '^'

    return ''.join(new_row)      



def main(): 
    pass

"""
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
    (".^^^..^.^^", "^^.^^^..^^")

])
def test_generate_row(previous_row: str, expected: str): 
    result = generate_row(previous_row)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()