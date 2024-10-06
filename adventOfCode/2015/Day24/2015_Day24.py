import pytest
from pathlib import Path
import math

class Arrangement: 
    def __init__(self): 
        self.group1 = []
        self.quantum_entanglement = 1

    def load_cockpit(self, values: list[int]): 
        self.cockpit = values
        self.quantum_entanglement = math.prod(self.cockpit)

    def find_arrangements(values: list[int], groups: int) -> list['Arrangement']: 
        total = sum(values) 
        combos = Arrangement.find_combos(values, total//groups)
        # find the min length of combos, which will be candidates for the cockpit
        min_length = min(len(c) for c in combos)
        arrangements = [] 
        for c in combos: 
            if len(c) == min_length: 
                arrangement = Arrangement()
                arrangement.load_cockpit(c)
                arrangements.append(arrangement)
        return arrangements

    """
    Find all ways to get the given total from the list of numbers
    """
    def find_combos(values: list[int], target_sum: int) -> list[int]: 
        def backtrack(start: int, current_combo: list[int], current_sum: int):
            if current_sum == target_sum: 
                combos.append(list(current_combo))
                return
            if current_sum > target_sum: 
                return
            
            for i in range(start, len(values)):
                current_combo.append(values[i])
                backtrack(i + 1, current_combo, current_sum + values[i])
                current_combo.pop() 

        combos = []
        backtrack(0, [], 0)
        return combos



class Balancer: 

    def __init__(self, groups): 
        self.groups = groups

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
    
    def run(self, file_name: str) -> int:
        values = self.get_input(file_name)  
        #print(values)
        arrangements = Arrangement.find_arrangements(values, self.groups)
        minQ = min(a.quantum_entanglement for a in arrangements)
        return minQ

def test_day24_part1(): 
    part1 = Balancer(3)
    expected = 99 
    result = part1.run("sample.txt")
    assert expected == result

def test_day24_part2(): 
    part1 = Balancer(4)
    expected = 44
    result = part1.run("sample.txt")
    assert expected == result

if __name__ == '__main__': 
    pytest.main([__file__])
    part1 = Balancer(3)
    result = part1.run("input.txt")
    print(f"Part1 result: {result}")
    part2 = Balancer(4)
    result = part2.run("input.txt")
    print(f"Part2 result: {result}")