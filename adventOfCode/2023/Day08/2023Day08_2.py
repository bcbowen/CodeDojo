import pytest
from pathlib import Path
import math

class MapData: 
    def __init__(self): 
        self.directions = ''
        self.routes = {}

    def write_trace(records): 
        path = Path(Path(__file__).parent, "trace.txt").resolve()
        with open(path, 'w') as f:
            for line in records: 
                f.write(" ".join(line) + '\n')
            f.close(); 
                

    def load(file_name: str) -> 'MapData': 
        path = str(Path(__file__).parent)
        data_path = path.replace("CodeDojo\\adventOfCode", "adventOfCodePrivateFiles")
        file_path = Path(data_path, file_name).resolve()
        map_data = MapData()
        with open(file_path) as file: 
            text = file.read() 
            lines = text.split('\n')
            
            map_data.directions = lines[0]
            for i in range(2, len(lines)): 
                fields = lines[i].split('=')
                routeFields = fields[1].replace("(", "").replace(")", "").split(',')
                map_data.routes[fields[0].strip()] = (routeFields[0].strip(), routeFields[1].strip())
            file.close()
        return map_data

    # After initial attemps and research, the brute force approach requires more than 10 trillion 
    # iterations. The accepted approach is get the path lenght for each starting node
    # and find the LCM
    def find_path_length(file_name: str) -> int: 
        map_data = MapData.load(file_name)
        length = 0
        pos = 0
        keys = []
        
        for key in map_data.routes.keys(): 
            if key.endswith('A'): 
                keys.append(key)
                
        #trace = []
        #trace.append(next_keys.copy())
        
        path_lengths = []
        for i in range(len(keys)):
            next_key = keys[i]
            length = 0
            while not next_key.endswith('Z'): 
                dir = map_data.directions[pos]
                currentRoute = map_data.routes[next_key]
                if dir == "L": 
                    next_key = currentRoute[0]
                else:
                    next_key = currentRoute[1]
                #trace.append(next_keys.copy())
                pos = pos + 1 if pos < len(map_data.directions) - 1 else 0
                length += 1
            path_lengths.append(length)
        #MapData.write_trace(trace)
        length = math.lcm(*path_lengths)
        return length


def test_load_data(): 
    file_name = "sample3.txt"
    map_data = MapData.load(file_name)
    print(map_data.routes)
    assert map_data.directions == "LR"
    assert map_data.routes["11Z"] == ("11B", "XXX")

def part2(): 
    file_name = "input.txt"
    result = MapData.find_path_length(file_name)
    print(f"Part 2 result: {result}")

@pytest.mark.parametrize("file_name, expected", [
    ("sample3.txt", 6)
])
def test_path(file_name: str, expected: int):
    result = MapData.find_path_length(file_name)
    assert expected == result

if __name__ == "__main__": 
    pytest.main([__file__])
    part2()