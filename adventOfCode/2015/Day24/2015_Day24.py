import pytest
from pathlib import Path
import math

class Arrangement: 
    def __init__(self): 
        self.cockpit = []
        self.quantum_entaglement = 1

    def load_cockpit(self, values: list[int]): 
        self.cockpit = values
        self.quantum_entaglement = math.prod(self.cockpit)

class Part1: 

    def __init__(self): 
        pass

    def get_input(self, file_name: str) -> list[int]: 
        path = str(Path(__file__).parent)
        data_path = path.replace("CodeDojo\\adventOfCode", "adventOfCodePrivateFiles")
        file_path = Path(data_path, file_name).resolve()
        values = []
        with open(file_path) as file: 
            text = file.read() 
            lines = text.split('\n')
            for line in lines: 
                values.append(int(line))
            file.close()
        return values
    
    def run(self, file_name: str) -> list[list[int]]:
        values = self.get_input(file_name)        

if __name__ == '__main__': 
    pytest(__file__)