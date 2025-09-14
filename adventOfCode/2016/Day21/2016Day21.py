import pytest
from typing import List
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

def load_password(file_name: str) -> str: 
    result = ""
    
    path = get_input_filepath(file_name)
    with open(path, 'r') as file: 
        result = file.read()
    return result

def load_commands(file_name: str) -> List[str]: 
    commands = [] 
    path = get_input_filepath(file_name)
    with open(path, 'r') as file: 
        commands = file.readlines()
    return commands

def main(): 
    pass

def swap_positions(value: str, i1: int, i2: int) -> str: 
    chars = [c for c in value]
    chars[i1], chars[i2] = chars[i2], chars[i1]

    return "".join(chars)

def swap_letters(value: str, c1: str, c2: str): 
    if c1 == c2: 
        return value
    i1 = -1
    i2 = -1

    for i in range(len(value)): 
        if value[i] == c1: 
            i1 = i
            if i2 > -1: 
                break
        elif value[i] == c2: 
            i2 = i
            if i1 > -1: 
                break
    if i1 > -1 and i2 > -1: 
        return swap_positions(value, i1, i2)

def rotate_right(value: str, moves: int) -> str: 
    if moves > len(value):  
        moves = moves % len(value)
    chars = []
    for i in range(len(value) - moves, len(value)): 
        chars.append(value[i])

    for i in range(len(value) - moves): 
        chars.append(value[i])
    
    return "".join(chars)

def rotate_left(value: str, moves: int) -> str: 
    if moves > len(value):  
        moves = moves % len(value)
    chars = []
    for i in range(moves, len(value)): 
        chars.append(value[i])
    for i in range(moves): 
        chars.append(value[i])
    return "".join(chars)

def reverse(value: str, start_index: int, end_index: int) -> str:
    chars = []
    for i in range(start_index): 
        chars.append(value[i])
    for i in range(end_index, start_index - 1, -1): 
        chars.append(value[i])
    for i in range(end_index + 1, len(value)):
        chars.append(value[i])
    return "".join(chars)  

def move(value: str, from_index: int, to_index: int) -> str: 
    chars = []
    for i in range(to_index): 
        if i == from_index: 
            continue
        chars.append(value[i])
    chars.append(value[from_index])
    for i in range(to_index + 1, len(value)):
        chars.append(value[i])
    return "".join(chars) 

"""
swap position X with position Y means that the letters at indexes X and Y (counting from 0) 
should be swapped.
swap letter X with letter Y means that the letters X and Y should be swapped (regardless of 
where they appear in the string).

rotate left/right X steps means that the whole string should be rotated; 
for example, one right rotation would turn abcd into dabc.

rotate based on position of letter X means that the whole string should be rotated to the right 
based on the index of letter X (counting from 0) as determined before this instruction does 
any rotations. Once the index is determined, rotate the string to the right one time, plus a 
number of times equal to that index, plus one additional time if the index was at least 4.

reverse positions X through Y means that the span of letters at indexes X through Y 
(including the letters at X and Y) should be reversed in order.

move position X to position Y means that the letter which is at index X should be removed 
from the string, then inserted such that it ends up at index Y.


##################
For example, suppose you start with abcde and perform the following operations:

swap position 4 with position 0 swaps the first and last letters, producing the input for the 
next step, ebcda.

swap letter d with letter b swaps the positions of d and b: edcba.

reverse positions 0 through 4 causes the entire string to be reversed, producing abcde.

rotate left 1 step shifts all letters left one position, causing the first letter to wrap to the end of the string: bcdea.

move position 1 to position 4 removes the letter at position 1 (c), then inserts it at position 4 (the end of the string): bdeac. 

move position 3 to position 0 removes the letter at position 3 (a), then inserts it at position 0 (the front of the string): abdec.

rotate based on position of letter b finds the index of letter b (1), then rotates the string right once plus a number of times equal to that index (2): ecabd.

rotate based on position of letter d finds the index of letter d (4), then rotates the string right once, plus a number of times equal to that index, plus an additional time because the index was at least 4, for a total of 6 right rotations: decab.

After these steps, the resulting scrambled password is decab.
"""

def test_swap_positions(): 
    value = "abcde"
    expected = "ebcda"
    i1 = 0
    i2 = 4
    result = swap_positions(value, i1, i2)
    assert(result == expected)

def test_swap_letters(): 
    value = "ebcda"
    expected = "edcba"
    c1 = 'd'
    c2 = 'b'
    result = swap_letters(value, c1, c2)
    assert(expected == result)

@pytest.mark.parametrize("value, moves, expected", [
    ("abcd", 1, "dabc"), 
    ("abcd", 5, "dabc"), 
    ("abcde", 3, "cdeab")
])
def test_rotate_right(value: str, moves: int, expected: str): 
    # one right rotation would turn abcd into dabc.
    result = rotate_right(value, moves)
    assert(result == expected)


@pytest.mark.parametrize("value, moves, expected", [
    ("dabc", 1, "abcd"), 
    ("dabc", 5, "abcd"), 
    ("cdeab", 3, "abcde")
])
def test_rotate_left(value: str, moves: int, expected: str): 
    result = rotate_left(value, moves)
    assert(result == expected)


@pytest.mark.parametrize("value, start_index, end_index, expected", [
    ("edcba", 0, 4, "abcde"), 
    ("edcba", 1, 3, "ebcda")
])
def test_reverse(value: str, start_index: int, end_index: int, expected: str): 
    result = reverse(value, start_index, end_index)
    assert(result == expected)

@pytest.mark.parametrize("value, from_index, to_index, expected", [
    ("abcde", 0, 4, "bcdea"), 
    ("abcde", 1, 3, "acdbe"), 
    ("abcde", 3, 1, "adbce"), 
    ("bcdea", 1, 4, "bdeac")
    
])
def test_move(value: str, from_index: int, to_index: int, expected: str): 
    result = move(value, from_index, to_index)
    assert(result == expected)

def test_load_password(): 
    expected = "abcde"
    file_name = "samplePassword.txt"
    result = load_password(file_name)
    assert(result == expected)



if __name__ == "__main__":
    pytest.main([__file__])
    main()