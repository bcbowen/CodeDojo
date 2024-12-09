import pytest
from pathlib import Path

class Interpreter:
    def __init__(self, file_name: str): 
        self.commands = self.get_commands(file_name)
         
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


def test(): 
    print("nitz")

if __name__ == "__main__": 
    pytest.main([__file__])