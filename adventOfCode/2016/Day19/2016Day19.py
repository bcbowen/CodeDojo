import pytest

class GiftNode: 
    def __init__(self, id, next: "GiftNode | None"):
        self.next = next
        self.gift_count = 1
        self.id = id

class GiftExchange: 

    def __init__(self): 
        self.first = GiftNode(1, None) 
        self.last = self.first
        self.last.next = self.first
        self.next_id = 2

    def add(self):
        next = GiftNode(self.next_id, self.first)
        self.next_id += 1 
        self.last.next = next
        self.last = next

    @staticmethod
    def configure_exchange(players: int) -> "GiftExchange":
        exchange = GiftExchange()
        for i in range(players): 
            exchange.add()
        return exchange 

    def play(self) -> int:
        current = self.first
        while self.first != self.last:
            if not current.next: 
                raise Exception("Current node has no next node!")
            if not current.next.next: 
                    raise Exception("Current Next node has no next node!")
            current.gift_count += current.next.gift_count 
            if current == self.last:
                self.first = current.next.next 
                current.next = self.first
            else: 
                current.next = current.next.next
            current = current.next
        return self.first.id

def exchange_gifts(player_count: int) -> int:
    exchange = GiftExchange.configure_exchange(player_count)
    result = exchange.play()
    return result


def test_part1(): 
    result = exchange_gifts(5)
    expected = 3
    assert(result == expected)




if __name__ == "__main__": 
    pytest.main([__file__])