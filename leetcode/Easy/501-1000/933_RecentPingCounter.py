from collections import deque

class RecentCounter:


    def __init__(self):
        self.callQ = deque()    

    def ping(self, t: int) -> int:
        while len(self.callQ) > 0 and t - self.callQ[0] > 3000: 
            self.callQ.popleft()
        self.callQ.append(t)
        return len(self.callQ)


# Your RecentCounter object will be instantiated and called as such:
# obj = RecentCounter()
# param_1 = obj.ping(t)