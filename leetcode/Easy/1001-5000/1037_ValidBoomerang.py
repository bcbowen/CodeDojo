from typing import List 

class Solution:
    def isBoomerang(self, points: List[List[int]]) -> bool:
        if points[0] == points[1] or points[0] == points[2]: 
            return False 
        if points[1] == points[2]: 
            return False

        def get_slope(point1: List[int], point2: List[int]) -> float: 
            dy = point2[1] - point1[1]
            dx = point2[0] - point1[0]

            return float('inf') if dx == 0 else dy/dx


        s1 = get_slope(points[0], points[1])
        s2 = get_slope(points[1], points[2])

        
        return s1 != s2