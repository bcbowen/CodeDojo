from typing import List

class Solution:
    def dietPlanPerformance(self, calories: List[int], k: int, lower: int, upper: int) -> int:
        result = 0 
        for i in range(len(calories) - k + 1): 
            c = sum(calories[i : i + k]) 
            if c < lower: 
                result -= 1
            elif c > upper: 
                result += 1
        return result