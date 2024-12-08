import pytest
from pathlib import Path


def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_grid(file_name: str) -> list[list[str]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file:
        grid = [list(line.strip()) for line in file.readlines()]
    return grid 

"""
From the input grid, create a dictionary of each station frequency and locations
"""
def map_stations(grid: list[list[str]]) -> dict[str, list[tuple[int, int]]]:
    station_map = {}
    for row in range(len(grid)): 
        for col in range(len(grid[row])): 
            if grid[row][col] != '.':
                key = grid[row][col] 
                if not key in station_map: 
                    station_map[key] = []
                station_map[key].append((row, col))

    return station_map

"""
for each station, map the antinode locations and return them along with a total count
"""
def map_antinodes(station_map : dict[str, list[tuple[int, int]]], grid_size : int) -> tuple[dict[str, list[tuple[int, int]], int]]: 
    all_nodes = set()
    node_map = {}

    """
    for a pair of stations, calculate the antinode positions and return the ones that are in bounds
    """
    def calc_antinodes (a: tuple[int, int], b: tuple[int, int], grid_size) -> set[tuple[int, int]]:  
        
        dy = b[0] - a[0]
        dx = b[1] - a[1]
        nodes = set()
        node1 = (a[0] - dy, a[1] - dx)
        if node1[0] >= 0 and node1[0] < grid_size and node1[1] >= 0 and node1[1] < grid_size: 
            nodes.add(node1)
            all_nodes.add(node1)

        node2 = (b[0] + dy, b[1] + dx)
        if node2[0] >= 0 and node2[0] < grid_size and node2[1] >= 0 and node2[1] < grid_size: 
            nodes.add(node2)
            all_nodes.add(node2)

        return nodes
    
    for station_key in station_map:
        node_map[station_key] = []
        for i in range(len(station_map[station_key]) -1): 
            for j in range(i + 1, len(station_map[station_key])): 
                nodes = calc_antinodes(station_map[station_key][i], station_map[station_key][j], grid_size) 
                node_map[station_key].extend(nodes)



    return (node_map, len(all_nodes))

def part1(file_name: str) -> int: 
    grid = load_grid(file_name)
    #print('stations:')
    station_map = map_stations(grid)
    
    _, node_count = map_antinodes(station_map, len(grid))
    """
    for key in station_map:
        print(f"Station {key}") 
        for node in station_map[key]: 
            print(node)
    
    for key in node_map: 
        print(f"Station {key} nodes")
        for node in node_map[key]: 
            print(node)
    """            
    return node_count


"""
......#....#
...#....0...
....#0....#.
..#....0....
....0....#..
.#....A.....
...#........
#......#....
........A...
.........A..
..........#.
..........#.
"""
def test_part1(): 
    expected = 14
    result = part1("sample.txt")
    assert(result == expected)

def test_calc_antinodes(): 
    stations = {}
    stations[0] = [(1, 8),(2, 5)]
    result, _ = map_antinodes(stations, 12) 
    assert((0, 11) in result[0])
    assert((3, 2) in result[0])

def main(): 
    # part 1:
    result = part1("sample.txt")
    print(f"Sample part1: {result}")
    
    result = part1("input.txt")
    print(f"Part1: {result}")
    
    """
    # part 2:
    result = part2("sample.txt")
    print(f"Sample part2: {result}")
    
    result = part2("input.txt")
    print(f"Part2: {result}")
    """
    
    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()