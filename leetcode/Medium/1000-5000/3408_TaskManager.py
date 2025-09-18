import pytest
import heapq
from collections import defaultdict
from typing import List

class TaskManager:

    def __init__(self, tasks: List[List[int]]):
        self.tasks = {}
        self.taskUsers = defaultdict(int)
        self.taskq = [] 

        for user_id, task_id, priority in tasks: 
            self.add(user_id, task_id, priority)

    def add(self, userId: int, taskId: int, priority: int) -> None:
        if not userId in self.tasks: 
            self.tasks[userId] = []
        self.tasks[userId].append((taskId, priority))
        heapq.heappush(self.taskq, (priority, taskId))
        self.taskUsers[taskId] = userId

    def edit(self, taskId: int, newPriority: int) -> None:
        

    def rmv(self, taskId: int) -> None:
        for i in range(len(self.taskq)): 
            if self.taskq[i][1] == taskId: 
                del self.taskq[i]
                heapq.heapify(self.taskq)
                break
        user_id = self.taskUsers[taskId]
        
        for i in range(len(self.tasks[user_id])): 
            if self.tasks[user_id][i][0] == taskId: 
                del self.tasks[user_id][i]
                break
        del self.taskUsers[taskId]

    def execTop(self) -> int:
        _, task_id = heapq.heappop(self.taskq)
        user_id = self.taskUsers[task_id]
        return user_id


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


if __name__ == "__main__": 
    pytest.main([__file__])