#import heapq
import math
import pytest
from collections import defaultdict
from pathlib import Path
from typing import Dict, List, Tuple


"""
Going to start over after spending a lot of time and making this very complicated
"""

class UnionFind: 
    
    def __init__(self, n: int):
        # parent[i] points to the parent of node i
        # Initially, every node is its own parent (representing n distinct sets)
        self.parent = list(range(n))
        # rank[i] is an upper bound on the height of the tree rooted at i
        self.rank = [0] * n

    def find(self, i: int) -> int: 
        """
        Finds the representative (root) of the set containing element i.
        Uses Path Compression optimization.
        """
        # Base case: if the element is its own parent, it is the root.
        if self.parent[i] == i:
            return i
        
        # Path Compression Step: 
        # Recursively call find on the parent of i, 
        # and then set the parent of i directly to the root we found.
        self.parent[i] = self.find(self.parent[i])
        return self.parent[i]
    
    def union(self, i: int, j: int):
        """
        Unions the sets containing i and j using Union by Rank optimization.
        """
        # Find the roots of the sets for i and j
        root_i = self.find(i)
        root_j = self.find(j)

        # If they are already in the same set, do nothing.
        if root_i != root_j:
            # Union by Rank Step: 
            # Attach the smaller ranked tree to the root of the larger ranked tree.
            if self.rank[root_i] < self.rank[root_j]:
                self.parent[root_i] = root_j
            elif self.rank[root_i] > self.rank[root_j]:
                self.parent[root_j] = root_i
            else:
                # If ranks are the same, pick one root (e.g., root_j) 
                # and increment its rank because the height increased.
                self.parent[root_i] = root_j
                self.rank[root_j] += 1
            
            return True # Successfully performed a union
        return False # No union needed
        
    def get_group_counts(self):
        """
        Calculates the size of each distinct group (set) in the Union-Find structure.
        """
        counts = defaultdict(int)
        for i in range(len(self.parent)):
            # Calling find here ensures all remaining elements compress their paths 
            # and we count the true root representative.
            root = self.find(i) 
            counts[root] += 1
        return counts

    #def are_connected(self, i: int, j: int) -> bool: 
    #    return self.find(i) == self.find(j)

class junction: 
    def __init__(self, id: int, x: int, y: int, z: int):
        self.id = id
        self.x = x
        self.y = y
        self.z = z
        self.dist : float = 0.0

    @staticmethod
    def get_distance(j1: "junction", j2: "junction") -> float: 
        return math.sqrt((j2.x - j1.x)**2 + (j2.y - j1.y)**2 + (j2.z - j1.z)**2) 

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def get_inputs(file_name: str) -> List[junction]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        id = 0
        for line in file.readlines():
            vals = line.strip().split(',')
            j = junction(id, int(vals[0]), int(vals[1]), int(vals[2]))
            inputs.append(j)
            id += 1
    return inputs

def main(): 
    pass

def get_distances(inputs: List[junction]) -> Dict[int, List[junction]]: 
    distances : Dict[int, List[junction]] = {} 
    for source in inputs:
        distances[source.id] = [] 
        #current_junction = junction(i[0], i[1], i[2])
        for dest in inputs: 
            if source.id == dest.id: 
                continue
            distance = junction.get_distance(source, dest)
            dest.dist = distance
            distances[source.id].append(dest)
        #distances[source.id].sort(key = lambda x: x.dist)
    
    for destination_list in distances.values(): 
        destination_list.sort(key = lambda x: x.dist)

    return distances

"""

def get_closest_unconnected(distances : Dict[int, List[junction]], inputs: List[junction] ) -> List[int]: 
    min_ids = []
    min_dist = float('inf')
    for i in range(len(inputs)):
        #current = inputs[i]
        for j in range(len(distances[i])): 
            if distances[i][j].dist < min_dist and uf.find(i) == i: 
                min_dist = distances[i][j].dist
                min_ids = [i, distances[i][j].id]
            elif distances[i][j].dist > min_dist: 
                break

    return min_ids
"""

def part1(file_name: str, connection_count: int, rank: int) -> int: 

    inputs = get_inputs(file_name)
    distances = get_distances(inputs)
    uf = UnionFind(len(inputs))
    seen = set()
    i = 0
    j = distances[0][0]
    uf.union(i, j.id)
    seen.add((i, j))
    
    for _ in range(1, connection_count):
        min_dist = float('inf')
        min_pair = (-1, -1)
        for source in range(len(inputs)): 
            for dest in distances[source]:
                if (source, dest) in seen: 
                    continue 
                if dest.dist < min_dist:
                    min_dist = dest.dist
                    min_pair = (source, dest.id)
                else: 
                    break
        uf.union(*min_pair) 

        #i, j = get_closest_unconnected(distances, inputs)
        #d1 = inputs[i]
        #d2 = inputs[j]
        #print(f"Distances: {d1.x}, {d1.y}, {d1.z} : {d2.x}, {d2.y}, {d2.z}")
        #uf.union(i, j)
    
    counts = uf.get_group_counts()
    count_list = [] 
    for val in counts.values(): 
        count_list.append(val)
    count_list.sort(reverse = True)
    
    return math.prod(count_list[0:rank + 1])

def test_get_inputs(): 
    file_name = "sample.txt"
    result = get_inputs(file_name)
    assert(len(result) == 20)
    box = result[0]
    expectedX, expectedY, expectedZ = 162, 817, 812
    assert((box.x, box.y, box.z) == (expectedX, expectedY, expectedZ))

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name, 10, 3)
    expected = 40
    assert(result == expected)

"""
This list describes the position of 20 junction boxes, one per line. Each position is given as X,Y,Z coordinates. 
So, the first junction box in the list is at X=162, Y=817, Z=812.

To save on string lights, the Elves would like to focus on connecting pairs of junction boxes that are as close together as possible 
according to straight-line distance. In this example, the two junction boxes which are closest together are 162,817,812 and 425,690,689.

By connecting these two junction boxes together, because electricity can flow between them, they become part of the same circuit. 
After connecting them, there is a single circuit which contains two junction boxes, and the remaining 18 junction boxes remain in 
their own individual circuits.

Now, the two junction boxes which are closest together but aren't already directly connected are 162,817,812 and 431,825,988. 
After connecting them, since 162,817,812 is already connected to another junction box, there is now a single circuit which contains 
three junction boxes and an additional 17 circuits which contain one junction box each.

The next two junction boxes to connect are 906,360,560 and 805,96,715. After connecting them, there is a circuit containing 3 
junction boxes, a circuit containing 2 junction boxes, and 15 circuits which contain one junction box each.

The next two junction boxes are 431,825,988 and 425,690,689. Because these two junction boxes were already in the same circuit, 
nothing happens!


def test_get_closest_unconnected(): 
    file_name = "sample.txt"
    inputs = get_inputs(file_name)
    distances = get_distances(inputs)

"""


if __name__ == "__main__":
    pytest.main([__file__])
    main()