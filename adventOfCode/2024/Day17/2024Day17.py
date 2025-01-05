import pytest
from pathlib import Path

class ElfWare: 
    def __init__(self): 
        self.reg_a = 0
        self.reg_b = 0
        self.reg_c = 0
        
        self.program : list[int] = [] 

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
        def parse_input_val(line: str) -> str: 
            fields = line.split(':')
            return fields[1].strip()
        
        path = self.get_input_filepath(file_name)
        with open(path, "r") as file: 
            line = file.readline()
            self.reg_a = int(parse_input_val(line))

            line = file.readline()
            self.reg_b = int(parse_input_val(line))

            line = file.readline()
            self.reg_c = int(parse_input_val(line))

            line = file.readline() 
            self.program = [int(val) for val in parse_input_val(file.readline()).split(',') ]
    
    """
    Combo operands 0 through 3 represent literal values 0 through 3.
    Combo operand 4 represents the value of register A.
    Combo operand 5 represents the value of register B.
    Combo operand 6 represents the value of register C.
    Combo operand 7 is reserved and will not appear in valid programs.
    """
    

    """
    The adv instruction (opcode 0) performs division. The numerator is the value in the A register. 
    The denominator is found by raising 2 to the power of the instruction's combo operand. (So, an 
    operand of 2 would divide A by 4 (2^2); an operand of 5 would divide A by 2^B.) The result of 
    the division operation is truncated to an integer and then written to the A register.
    """
    def __get_combo_op__(self, val : int) -> int: 
        if val < 0 or val > 6: 
            raise Exception("Invalid value for combo operand")
        match val: 
            case 4: 
                return self.reg_a
            case 5: 
                return self.reg_b
            case 6: 
                return self.reg_c
            case _: 
                return val
            
    
    def adv(self, arg: int): 
        val = self.__get_combo_op__(arg)
        
        result = self.reg_a // 2 ** val
        self.reg_a = result

    """
    The bxl instruction (opcode 1) calculates the bitwise XOR of register B and the instruction's 
    literal operand, then stores the result in register B.
    """
    def bxl(self, arg: int): 
        self.reg_b = self.reg_b ^ arg

    """    
    The bst instruction (opcode 2) calculates the value of its combo operand modulo 8 (thereby 
    keeping only its lowest 3 bits), then writes that value to the B register.
    """
    def bst(self, arg: int): 
        val = self.__get_combo_op__(arg) % 8
        self.reg_b = val

    """
    The jnz instruction (opcode 3) does nothing if the A register is 0. However, if the A register 
    is not zero, it jumps by setting the instruction pointer to the value of its literal operand; 
    if this instruction jumps, the instruction pointer is not increased by 2 after this instruction.

    Note: Set the instruction pointer to the return value if it is > -1, leave it alone otherwise
    """
    def jnz(self, arg: int) -> int: 
        if self.reg_a != 0: 
            return arg
        return -1

    """
    The bxc instruction (opcode 4) calculates the bitwise XOR of register B and register C, then 
    stores the result in register B. (For legacy reasons, this instruction reads an operand but 
    ignores it.)
    """
    def bxc(self, arg): 
        self.reg_b = self.reg_b ^ self.reg_c

    """
    The out instruction (opcode 5) calculates the value of its combo operand modulo 8, then outputs 
    that value. (If a program outputs multiple values, they are separated by commas.)
    """
    def out(self, arg : int) -> int: 
        val = self.__get_combo_op__(arg)
        return val % 8

    """
    The bdv instruction (opcode 6) works exactly like the adv instruction except that the result is 
    stored in the B register. (The numerator is still read from the A register.)
    """
    def bdv(self, arg: int): 
        val = self.__get_combo_op__(arg)
        
        result = self.reg_a // 2 ** val
        self.reg_b = result

    """
    The cdv instruction (opcode 7) works exactly like the adv instruction except that the result is 
    stored in the C register. (The numerator is still read from the A register.)
    """
    def cdv(self, arg: int): 
        val = self.__get_combo_op__(arg)
        
        result = self.reg_a // 2 ** val
        self.reg_c = result

    def __execute__(self, opcode: int, arg: int) -> int:
        match opcode: 
            case 0: 
                self.adv(arg)
            case 1: 
                self.bxl(arg)
            case 2: 
                self.bst(arg)
            case 3: 
                return self.jnz(arg)
            case 4: 
                self.bxc(arg)
            case 5: 
                return self.out(arg)
            case 6: 
                self.bdv(arg)
            case 7: 
                self.cdv(arg)
            case _: 
                raise Exception("Unsupported opcode")

    """

    A number called the instruction pointer identifies the position in the program from which 
    the next opcode will be read; it starts at 0, pointing at the first 3-bit number in the 
    program. Except for jump instructions, the instruction pointer increases by 2 after each 
    instruction is processed (to move past the instruction's opcode and its operand). If the 
    computer tries to read an opcode past the end of the program, it instead halts.

    So, the program 0,1,2,3 would run the instruction whose opcode is 0 and pass it the operand 
    1, then run the instruction having opcode 2 and pass it the operand 3, then halt.

    There are two types of operands; each instruction specifies the type of its operand. The 
    value of a literal operand is the operand itself. For example, the value of the literal 
    operand 7 is the number 7. The value of a combo operand can be found as follows:


    The eight instructions are as follows:

    """


    def run(self) -> str: 
        ptr = 0
        output = []
        while ptr < len(self.program):
            cmd = self.program[ptr]
            arg = self.program[ptr + 1]
            result = self.__execute__(cmd, arg)
            if cmd == 3 and result > -1: 
                ptr = result
            else: 
                ptr += 2
            
            if cmd == 5: 
                output.append(result)
        
        return ','.join(str(val) for val in output)
    
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
    (0, 0, 9, [2,6], 0, 1, 0, ""),
    (10, 0, 0, [5,0,5,1,5,4], 10, 0, 0, "0,1,2"),
    (2024, 0, 0, [0,1,5,4,3,0], 0, 0, 0, "4,2,5,6,7,7,7,7,3,1,0"),
    (0, 29, 0, [1,7], 0, 26, 0, ""),
    (0, 2024, 43690, [4,0], 0, 44354, 0, ""),
    (729, 0, 0, [0,1,5,4,3,0], 0, 0, 0, "4,6,3,5,6,3,5,2,1,0")
])
def test_program(a_in: int, b_in: int, c_in: int, program: list[int], a_ex: int, b_ex: int, c_ex: int, expected_output: str): 
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

def test_load(): 
    file_name = "sample.txt"
    p = ElfWare()
    p.load(file_name)
    assert(p.reg_a == 729)
    assert(p.program == [0,1,5,4,3,0])

def test_part1(): 
    file_name = "sample.txt"
    expected = "4,6,3,5,6,3,5,2,1,0"
    result = part1(file_name)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()
