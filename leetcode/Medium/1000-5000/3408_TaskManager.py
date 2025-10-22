import ast
import heapq
import os
import pytest
import time
from pathlib import Path
from typing import List


class TaskManager:

    def __init__(self, tasks: List[List[int]]):
        self.taskq = [] 

        for user_id, task_id, priority in tasks: 
            self.add(user_id, task_id, priority)

    def add(self, userId: int, taskId: int, priority: int) -> None:
        heapq.heappush(self.taskq, ((-priority, -taskId), userId))

    def edit(self, taskId: int, newPriority: int) -> None:
        
        user_id = -1
        for i in range(len(self.taskq)): 
            
            if self.taskq[i][0][1] == -taskId: 
                user_id = self.taskq[i][1]
                break
            
        if user_id == -1: 
            raise Exception("User not found in heap!")

        self.rmv(taskId)
        self.add(user_id, taskId, newPriority)

    def rmv(self, taskId: int) -> None:
        for i in range(len(self.taskq)): 
            if self.taskq[i][0][1] == -taskId: 
                del self.taskq[i]
                heapq.heapify(self.taskq)
                break

    def execTop(self) -> int:
        if len(self.taskq) > 0: 
            (_, _), user_id = heapq.heappop(self.taskq)
            return user_id
        else: 
            return -1

# Your TaskManager object will be instantiated and called as such:
# obj = TaskManager(tasks)
# obj.add(userId,taskId,priority)
# obj.edit(taskId,newPriority)
# obj.rmv(taskId)
# param_4 = obj.execTop()

"""
Example 1:
Input:
["TaskManager", "add", "edit", "execTop", "rmv", "add", "execTop"]
[[[[1, 101, 10], [2, 102, 20], [3, 103, 15]]], [4, 104, 5], [102, 8], [], [101], [5, 105, 15], []]

"add", "edit", "execTop", "rmv", "add", "execTop"
[4, 104, 5], [102, 8], [], [101], [5, 105, 15], []

Output:
[null, null, null, 3, null, null, 5]
"""
def test_task_manager(): 
    tasks = [[1, 101, 10], [2, 102, 20], [3, 103, 15]]
    t = TaskManager(tasks)
    t.add(4, 104, 5)
    t.edit(102, 8)
    result = t.execTop()
    expected = 3
    assert(result == expected)
    t.rmv(101)
    t.add(5, 105, 15)
    result = t.execTop() 
    expected = 5
    assert(result == expected)


def test_659(): 

    #def parse_list(line: str) -> list[int]: 
    #    return list(map(int, line.strip("[]\n").split(',')))

    data_path = Path(__file__).parent.parent.parent / "Data"
    file_name = "3408_659.txt"
    path = data_path / file_name
    
    
    with open(path, "r") as file: 
        commands = ast.literal_eval(file.readline()) 
        args = ast.literal_eval(file.readline())

    result = -1
    tasks = args[0][0]
    start_time = time.perf_counter()  # Start the timer
    t = TaskManager(tasks)
    for i in range(1, len(args)): 
        match commands[i]: 
            case "add": 
                user_id, task_id, priority = args[i]
                t.add(user_id, task_id, priority)
            case "edit":
                task_id, new_priority = args[i]
                t.edit(task_id, new_priority)
            case "execTop": 
                result = t.execTop()
            case "rmv": 
                task_id = args[i][0]
                t.rmv(task_id)

    expected = 15243
    
    end_time = time.perf_counter()    # Stop the timer
    #expected = False

    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.6f} seconds")
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])