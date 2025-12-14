import math
import pytest
from typing import List
from pathlib import Path


class UnionFind: 
    
    def __init__(self, n):
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
    
    def union(self, i, j):
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
        


    #def are_connected(self, i: int, j: int) -> bool: 
    #    return self.find(i) == self.find(j)

class junction: 
    def __init__(self, x, y, z):
        self.x = x
        self.y = y
        self.z = z

    @staticmethod
    def get_distance(j1: junction, j2: junction) -> float: 
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

def get_inputs(file_name: str) -> List[List[int]]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        inputs = [[int(d) for d in line.strip().split(',')] for line in file.readlines()]
    return inputs

def main(): 
    pass

def part1(file_name: str, connection_count: int, rank: int) -> int: 
    distances = {}
    inputs = get_inputs(file_name)




def test_get_inputs(): 
    file_name = "sample.txt"
    result = get_inputs(file_name)
    assert(len(result) == 20)
    assert(len(result[0]) == 3)
    

if __name__ == "__main__":
    pytest.main([__file__])
    main()