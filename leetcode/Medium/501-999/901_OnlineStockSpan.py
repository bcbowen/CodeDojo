import pytest

class StockSpanner:
    def __init__(self):
        self.stack = []

    def next(self, price: int) -> int:
        value = 1
        while self.stack and self.stack[-1][0] <= price: 
            value += self.stack[-1][1]
            self.stack.pop()
        self.stack.append((price, value))
        return value

# Your StockSpanner object will be instantiated and called as such:
# obj = StockSpanner()
# param_1 = obj.next(price)


"""
Input
["StockSpanner", "next", "next", "next", "next", "next", "next", "next"]
[[], [100], [80], [60], [70], [60], [75], [85]]
Output
[null, 1, 1, 1, 2, 1, 4, 6]

Explanation
StockSpanner stockSpanner = new StockSpanner();
stockSpanner.next(100); // return 1
stockSpanner.next(80);  // return 1
stockSpanner.next(60);  // return 1
stockSpanner.next(70);  // return 2
stockSpanner.next(60);  // return 1
stockSpanner.next(75);  // return 4, because the last 4 prices (including today's price of 75) were less than or equal to today's price.
stockSpanner.next(85);  // return 6

"""

@pytest.mark.parametrize("vals, expected", [
    ([100, 80, 60, 70, 60, 75, 85], [1, 1, 1, 2, 1, 4, 6]), 
    ([28,14,28,35,46,53,66,80,87,88], [1,1,3,4,5,6,7,8,9,10])
])
def test_spanner(vals: list[int], expected: list[int]): 
    spanner = StockSpanner()
    for i in range(len(vals)): 
        result = spanner.next(vals[i])
        assert(result == expected[i])


if __name__ == "__main__": 
    pytest.main([__file__])