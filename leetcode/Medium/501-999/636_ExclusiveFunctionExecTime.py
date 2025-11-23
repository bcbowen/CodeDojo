import pytest
from typing import List

class LogEntry: 
    def __init__(self, id: int, op: str, time: int): 
        self.id = id
        self.time = time
        self.op = op
    
    @staticmethod
    def parse(value: str) -> "LogEntry": 
        id_string, op, time_string = value.split(':')
        return LogEntry(int(id_string), op, int(time_string))
    
class FunctionCall: 
    def __init__(self, id: int, start: int): 
        self.id = id
        self.start = start
        self.end = -1
    
    @staticmethod
    def parse_start(log: LogEntry) -> "FunctionCall": 
        return FunctionCall(log.id, log.time)
    
    def get_exec_time(self, end: int) -> int: 
        self.end = end
        return self.end - self.start + 1


class Solution:
    def exclusiveTime(self, n: int, logs: List[str]) -> List[int]:
        function_times = {} 
        function_stack : List[FunctionCall] = []
        for log in logs: 
            log_entry = LogEntry.parse(log)

            match log_entry.op: 
                case 'start':
                    function_start = FunctionCall.parse_start(log_entry)

                    if not function_start.id in function_times: 
                        function_times[function_start.id] = 0
                    if len(function_stack) > 0: 
                        previous_call = function_stack[-1] 
                        function_times[previous_call.id] += log_entry.time - previous_call.start
                    function_stack.append(function_start)
                case 'end': 
                    previous_call = function_stack.pop()
                    exec_time = previous_call.get_exec_time(log_entry.time)
                    function_times[previous_call.id] += exec_time
                    if len(function_stack) > 0: 
                        previous_call = function_stack[-1] 
                        previous_call.start = log_entry.time + 1
        result = []
        for i in range(n): 
            result.append(function_times[i])
        return result 
    
"""
Input: n = 2, logs = ["0:start:0","1:start:2","1:end:5","0:end:6"]
Output: [3,4]
Explanation:
Function 0 starts at the beginning of time 0, then it executes 2 for units of time and reaches the end of time 1.
Function 1 starts at the beginning of time 2, executes for 4 units of time, and ends at the end of time 5.
Function 0 resumes execution at the beginning of time 6 and executes for 1 unit of time.
So function 0 spends 2 + 1 = 3 units of total time executing, and function 1 spends 4 units of total time executing.

Example 2:
Input: n = 1, logs = ["0:start:0","0:start:2","0:end:5","0:start:6","0:end:6","0:end:7"]
Output: [8]
Explanation:
Function 0 starts at the beginning of time 0, executes for 2 units of time, and recursively calls itself.
Function 0 (recursive call) starts at the beginning of time 2 and executes for 4 units of time.
Function 0 (initial call) resumes execution then immediately calls itself again.
Function 0 (2nd recursive call) starts at the beginning of time 6 and executes for 1 unit of time.
Function 0 (initial call) resumes execution at the beginning of time 7 and executes for 1 unit of time.
So function 0 spends 2 + 4 + 1 + 1 = 8 units of total time executing.

Example 3:
Input: n = 2, logs = ["0:start:0","0:start:2","0:end:5","1:start:6","1:end:6","0:end:7"]
Output: [7,1]
Explanation:
Function 0 starts at the beginning of time 0, executes for 2 units of time, and recursively calls itself.
Function 0 (recursive call) starts at the beginning of time 2 and executes for 4 units of time.
Function 0 (initial call) resumes execution then immediately calls function 1.
Function 1 starts at the beginning of time 6, executes 1 unit of time, and ends at the end of time 6.
Function 0 resumes execution at the beginning of time 6 and executes for 2 units of time.
So function 0 spends 2 + 4 + 1 = 7 units of total time executing, and function 1 spends 1 unit of total time executing.
"""
@pytest.mark.parametrize("n, logs, expected", [
    (2, ["0:start:0","1:start:2","1:end:5","0:end:6"], [3, 4]), 
    (1, ["0:start:0","0:start:2","0:end:5","0:start:6","0:end:6","0:end:7"], [8]), 
    (2, ["0:start:0","0:start:2","0:end:5","1:start:6","1:end:6","0:end:7"], [7, 1])
])
def test_exclusiveTime(n: int, logs: List[str], expected: List[int]):
    result = Solution().exclusiveTime(n, logs)
    assert(expected == result)


if __name__ == "__main__":
    pytest.main([__file__])