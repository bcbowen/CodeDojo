from typing import List

class Solution:
    def distributeCandies(self, candies: int, num_people: int) -> List[int]:
        p = int((2 * candies + .25)**0.5 - 0.5)
        remaining = remaining = int(candies - (p + 1) * p * 0.5)
        rows, cols = p // num_people, p % num_people

        result = [0] * num_people
        for i in range(num_people): 
            result[i] = (i + 1) * rows + int(rows * (rows - 1) * 0.5) * num_people
            if i < cols: 
                result[i] += i + 1 + rows * num_people
        result[cols] += remaining
        return result

