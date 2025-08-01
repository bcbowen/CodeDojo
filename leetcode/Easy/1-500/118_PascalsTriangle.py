from typing import List

class Solution:
    def generate(self, numRows: int) -> List[List[int]]:
        result = [[1]]
        for row_index in range(1, numRows): 
            row = [1] 
            previous_row = result[row_index - 1]
            for i in range(1, len(previous_row)):
                row.append(previous_row[i - 1] + previous_row[i]) 
            row.append(1)
            result.append(row)


        return result     