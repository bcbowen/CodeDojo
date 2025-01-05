import pytest
from pathlib import Path

class ElfWare: 
    def __init__(self): 
        self.reg_a = 0
        self.reg_b = 0
        self.reg_c = 0
        
        self.program = ""

    def get_input_filepath(self, file_name: str) -> str:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path
    
    def load(self, file_name: str): 
        self.path = self.get_input_filepath(file_name)


    def run(self) -> str: 
        pass


def main(): 
    pass

def part1(file_name: str): 
    p = ElfWare()
    p.load(file_name)
    result = p.run()
    return result

"""
* If register C contains 9, the program 2,6 would set register B to 1.
* If register A contains 10, the program 5,0,5,1,5,4 would output 0,1,2.
* If register A contains 2024, the program 0,1,5,4,3,0 would output 4,2,5,6,7,7,7,7,3,1,0 and leave 
  0 in register A.
* If register B contains 29, the program 1,7 would set register B to 26.
* If register B contains 2024 and register C contains 43690, the program 4,0 would set register B 
  to 44354.

The Historians' strange device has finished initializing its debugger and is displaying some 
information about the program it is trying to run (your puzzle input). For example:

Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0
Your first task is to determine what the program is trying to output. To do this, initialize 
the registers to the given values, then run the given program, collecting any output produced 
by out instructions. (Always join the values produced by out instructions with commas.) After 
the above program halts, its final output will be 4,6,3,5,6,3,5,2,1,0.
"""
@pytest.mark.parametrize("a_in, b_in, c_in, program, a_ex, b_ex, c_ex, expected_output", [
    (0, 0, 9, "2,6", 0, 1, 0, ""),
    (10, 0, 0, "5,0,5,1,5,4", 10, 0, 0, "0,1,2"),
    (2024, 0, 0, "0,1,5,4,3,0", 0, 0, 0, "4,2,5,6,7,7,7,7,3,1,0"),
    (0, 29, 0, "1,7", 0, 26, 0, ""),
    (0, 2024, 43690, "4,0", 0, 44354, 0, ""),
    (729, 0, 0, "0,1,5,4,3,0", 0, 0, 0, "4,6,3,5,6,3,5,2,1,0"),
])
def test_program(a_in: int, b_in: int, c_in: int, program: str, a_ex: int, b_ex: int, c_ex: int, expected_output: str): 
    p = ElfWare()
    p.reg_a = a_in
    p.reg_b = b_in
    p.reg_c = c_in
    p.program = program
    result = p.run()

    if a_ex > 0: 
        assert (p.reg_a == a_ex)

    if b_ex > 0: 
        assert (p.reg_b == b_ex)

    if c_ex > 0: 
        assert (p.reg_c == c_ex)
        
    if expected_output != "": 
        assert (result == expected_output)


def test_part1(): 
    file_name = "sample.txt"
    expected = "4,6,3,5,6,3,5,2,1,0"
    result = part1(file_name)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()
