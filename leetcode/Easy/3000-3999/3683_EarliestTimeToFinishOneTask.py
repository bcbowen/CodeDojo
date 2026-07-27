from typing import List

class Solution:
    def earliestTime(self, tasks: List[List[int]]) -> int:
        earliest = tasks[0][0] + tasks[0][1]
        for task in tasks: 
            finish_time = task[0] + task[1]
            earliest = min(earliest, finish_time)

        return earliest