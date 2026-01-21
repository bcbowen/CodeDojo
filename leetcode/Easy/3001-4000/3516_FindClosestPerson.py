class Solution:
    def findClosest(self, x: int, y: int, z: int) -> int:
        p1 = abs(z - x)
        p2 = abs(z - y)
        if p1 == p2: 
            return 0
        elif p1 < p2: 
            return 1
        else: 
            return 2