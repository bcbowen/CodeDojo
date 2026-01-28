import pytest
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

# Continuation of monorail code from day 12

class Interpreter:
    def __init__(self, file_name: str, c: int):
        self.commands = self.get_commands(file_name)
        self.registers = {'a': 0, 'b': 0, 'c': c, 'd': 0}

    def get_commands(self, file_name: str) -> list[str]:
        text = Modules.aoc_io.read_input(2016, 23, file_name)
        commands = text.split('\n')
        return commands

    def process_toggle(self, current_instruction: int, reg: str): 
        index = self.registers[reg]
        command_index = current_instruction + index
        if command_index >= 0 and command_index < len(self.commands): 
            toggle_command = self.commands[command_index].split(' ')
            match toggle_command[0]: 
                case 'inc': 
                    self.commands[index] = 'dec'
                case 'dec': 
                    self.commands[index] = 'inc'
                case 'cpy': 
                    self.commands[index] = self.commands[index].replace('cpy', 'jnz')
                case 'jnz': 
                    self.commands[index] = self.commands[index].replace('jnz', 'cpy')

    def process_command(self, command : str, current_instruction : int) -> int:
        parts = command.strip().split(' ')
        next_instruction = current_instruction + 1
        interpret = lambda val: int(val) if val.isdigit() else self.registers[val]
        match parts[0]:
            case 'cpy':
                val = interpret(parts[1])
                reg = parts[2]
                if reg in self.registers: 
                    self.registers[reg] = val
            case 'dec':
                reg = parts[1]
                self.registers[reg] -= 1
            case 'inc':
                reg = parts[1]
                self.registers[reg] += 1
            case 'jnz':
                reg = interpret(parts[1])
                val = int(parts[2])
                if reg != 0:
                    next_instruction = current_instruction + val
            case 'tgl':
                self.process_toggle(current_instruction, parts[1])

        return next_instruction

    def run(self):
        current_command = 0
        while current_command < len(self.commands) and current_command >= 0:
            current_command = self.process_command(self.commands[current_command], current_command)
        return self.registers['a']

def part1(file_name: str) -> int:
    interpreter = Interpreter(file_name,0)
    result = interpreter.run()
    return result

def part2(file_name: str) -> int:
    #interpreter = Interpreter(file_name,1)
    #result = interpreter.run()
    result = 2
    return result

def test_part1():
    expected = 3
    result = part1("sample.txt")
    assert(result == expected)

def main():
    result = part1("input.txt")
    print(f"Part 1: {result}")
    result = part2("input.txt")
    print(f"Part 2: {result}")

if __name__ == "__main__":
    pytest.main([__file__])
    main()