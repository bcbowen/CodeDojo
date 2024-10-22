import pytest


def get_input_filepath(file_name: str): 
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files 
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"
    
    input_path = private_files_base / year / day / file_name
    return input_path

def load_map(file_name: str) -> list[list[str]]: 
    input_map = []
    path = get_input_filepath(file_name)
    text = ""
    with open(path) as file: 
        text = file.read()
        file.close()
    lines = file.split('\n')
    row = 0
    for line in lines: 
        input_map.append([])
        input_map[row] = [val for val in line]
        row += 1
    return input_map


"""
| is a vertical pipe connecting north and south.
- is a horizontal pipe connecting east and west.
L is a 90-degree bend connecting north and east.
J is a 90-degree bend connecting north and west.
7 is a 90-degree bend connecting south and west.
F is a 90-degree bend connecting south and east.
. is ground; there is no pipe in this tile.
S is the starting position of the animal;
"""

def find_entry_point(input_map: list[list[str]]) -> tuple[int, int]: 
    for row in range(len(input_map)): 
        for col in range(len(input_map[row])): 
            if input_map[row][col] == "S": 
                return (row, col)

    return (-1, -1)



def part1(file_name: str) -> int:
    pass 

def test(): 


    pass



if __name__ == "__main__": 
    pytest.main([__file__])