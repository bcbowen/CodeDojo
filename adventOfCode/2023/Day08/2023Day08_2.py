import pytest
from pathlib import Path

class MapData: 
    def __init__(self): 
        self.directions = ''
        self.routes = {}

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

    def find_path_length(target: str, file_name: str) -> int: 
        map_data = MapData.load(file_name)
        length = 0
        pos = 0
        key = "AAA"
        while key != target: 
            dir = map_data.directions[pos]
            currentRoute = map_data.routes[key]
            if dir == "L": 
                key = currentRoute[0]
            else:
                key = currentRoute[1]
            pos = pos + 1 if pos < len(map_data.directions) - 1 else 0
            length += 1

        return length


def test_load_data(): 
    file_name = "sample3.txt"
    map_data = MapData.load(file_name)
    print(map_data.routes)
    assert map_data.directions == "LR"
    assert map_data.routes["11Z"] == ("11B", "XXX")

def part2(): 
    file_name = "input.txt"
    result = MapData.find_path_length("ZZZ", file_name)
    print(f"Part 1 result: {result}")

@pytest.mark.parametrize("file_name, expected", [
    ("sample1.txt", 2),
    ("sample2.txt", 6)
])
def test_path(file_name: str, expected: int):
    result = MapData.find_path_length("ZZZ", file_name)
    assert expected == result

if __name__ == "__main__": 
    pytest.main([__file__])
    part2()