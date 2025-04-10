import pytest
from pathlib import Path

class Interpreter:
    def __init__(self, file_name: str, c: int):
        self.commands = self.get_commands(file_name)
        self.registers = {'a': 0, 'b': 0, 'c': c, 'd': 0}

    def get_input_filepath(self, file_name: str):
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

    def get_commands(self, file_name: str) -> list[str]:
        path = self.get_input_filepath(file_name)
        with open(path, "r") as file:
            commands = [line for line in file.readlines()]
        return commands

    def process_command(self, command : str, current_instruction : int) -> int:
        parts = command.strip().split(' ')
        next_instruction = current_instruction + 1
        interpret = lambda val: int(val) if val.isdigit() else self.registers[val]
        match parts[0]:
            case 'cpy':
                val = interpret(parts[1])
                reg = parts[2]
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


        return next_instruction

    def run(self):
        current_command = 0
        while current_command < len(self.commands) and current_command >= 0:
            current_command = self.process_command(self.commands[current_command], current_command)
        return self.registers['a']

def part1(file_name: str):
    interpreter = Interpreter(file_name,0)
    result = interpreter.run()
    return result

def part2(file_name: str):
    interpreter = Interpreter(file_name,1)
    result = interpreter.run()
    return result

def test():
    expected = 42
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