from collections import deque

import pytest

class Hit: 
    def __init__(self, time_stamp: int, count: int): 
        self.time_stamp = time_stamp
        self.count = count

class HitCounter:

    def __init__(self):
        self.hitq = deque()


    def hit(self, time_stamp: int) -> None:
        # self.hits[timestamp] += 1
        last = len(self.hitq) - 1
        if last >= 0 and self.hitq[last].time_stamp == time_stamp: 
            self.hitq[last].count += 1
        else: 
            self.hitq.append(Hit(time_stamp, 1))


    def getHits(self, time_stamp: int) -> int:
        start_time = 1 if time_stamp < 300 else time_stamp - 299
        while len(self.hitq) > 0 and self.hitq[0].time_stamp < start_time: 
            self.hitq.popleft()
        hits = 0

        i = 0
        while i < len(self.hitq): 
            if self.hitq[i].time_stamp <= time_stamp: 
                hits += self.hitq[i].count
            else: 
                break
            i += 1

        return hits


# Your HitCounter object will be instantiated and called as such:
# obj = HitCounter()
# obj.hit(timestamp)
# param_2 = obj.getHits(timestamp)

"""
Example 1:

Input
["HitCounter", "hit", "hit", "hit", "getHits", "hit", "getHits", "getHits"]
[[], [1], [2], [3], [4], [300], [300], [301]]
Output
[null, null, null, null, 3, null, 4, 3]

Explanation
HitCounter hitCounter = new HitCounter();
hitCounter.hit(1);       // hit at timestamp 1.
hitCounter.hit(2);       // hit at timestamp 2.
hitCounter.hit(3);       // hit at timestamp 3.
hitCounter.getHits(4);   // get hits at timestamp 4, return 3.
hitCounter.hit(300);     // hit at timestamp 300.
hitCounter.getHits(300); // get hits at timestamp 300, return 4.
hitCounter.getHits(301); // get hits at timestamp 301, return 3.

"""
def test_1(): 
    hc = HitCounter()
    hc.hit(1)
    hc.hit(2)
    hc.hit(3)
    result = hc.getHits(4)
    expected = 3
    assert(result == expected)
    hc.hit(300)
    result = hc.getHits(300)
    expected = 4
    assert(result == expected)
    result = hc.getHits(301)
    expected = 3
    assert(result == expected)

def test_tc_6(): 
    """
    ["HitCounter","hit","hit","hit","getHits","getHits","getHits","getHits","getHits","hit","getHits"]
    [[],[2],[3],[4],[300],[301],[302],[303],[304],[501],[600]]
    """
    hc = HitCounter() 
    hc.hit(2)
    hc.hit(3)
    hc.hit(4)
    result = hc.getHits(300)
    expected = 3
    assert(result == expected)

    result = hc.getHits(301)
    expected = 3
    assert(result == expected)

    result = hc.getHits(302)
    expected = 2
    assert(result == expected)

    result = hc.getHits(303)
    expected = 1
    assert(result == expected)

    result = hc.getHits(304)
    expected = 0
    assert(result == expected)

    result = hc.getHits(501)
    expected = 0
    assert(result == expected)

    result = hc.getHits(600)
    expected = 0
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])