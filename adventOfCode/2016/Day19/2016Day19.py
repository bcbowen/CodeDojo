import pytest
import math

"""
This is the "Josephus problem": 
https://observablehq.com/@jwolondon/advent-of-code-2016-day-19
https://en.wikipedia.org/wiki/Josephus_problem

Part 2 takes too long, needs to be done mathmatically

"""
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
        for i in range(2, players + 1): 
            exchange.add()
        exchange.last.next = exchange.first
        return exchange 

    # Part 1: players go around the circle 
    def play_1(self) -> int:
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
            elif current.next == self.last: 
                self.last = current
                current.next = current.next.next
            else: 
                current.next = current.next.next
            current = current.next
        return self.first.id

    # part 2: Players exchange with player across from them to the left
    # ex 1 -> 2 -> 3 -> 4 -> 5: player 1 goes to player 3 (on his left)
 

def get_winning_elf_part_2(n : int) -> int: 
    exp = math.floor(math.log(n) / math.log(3))
    p = 3**exp
    return n if n == p else n - p + max(0, n - 2 * p)


def exchange_gifts_1(player_count: int) -> int:
    exchange = GiftExchange.configure_exchange(player_count)
    result = exchange.play_1()
    return result


def main(): 
    part1()
    part2()


def test_part1(): 
    result = exchange_gifts_1(5)
    expected = 3
    assert(result == expected)

def test_part2(): 
    #result = exchange_gifts_2(5)
    result = get_winning_elf_part_2(5)
    expected = 2
    assert(result == expected)

def part1(): 
    elf_count = 3001330
    result = exchange_gifts_1(elf_count)
    print(f'Part 1 result for {elf_count} elves: {result}')

def part2(): 
    elf_count = 3001330
    #result = exchange_gifts_2(elf_count)
    result = get_winning_elf_part_2(elf_count)
    print(f'Part 2 result for {elf_count} elves: {result}')

if __name__ == "__main__": 
    pytest.main([__file__])
    main()