import pytest
import re
from collections import deque, Counter
from itertools import chain, combinations
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io
from typing import List, Set

# Solution borrowed from Ed Mann: https://eddmann.com/posts/advent-of-code-2016-day-11-radioisotope-thermoelectric-generators/

def load_input(file_name: str) -> List[Set[str]]: 
  input = Modules.aoc_io.read_input(2016, 11, file_name)
  return parse_floors(input)

def parse_floors(input) -> List[Set[str]]:
    return [set(re.findall(r'(\w+)(?:-compatible)? (microchip|generator)', line))
      for line in input.splitlines()]   

def is_valid_transition(floor):
    return len(set(type for _, type in floor)) < 2 or \
           all((obj, 'generator') in floor
               for (obj, type) in floor
               if type == 'microchip')

def next_states(state):
    moves, elevator, floors = state

    possible_moves = chain(combinations(floors[elevator], 2), combinations(floors[elevator], 1))

    for move in possible_moves:
        for direction in [-1, 1]:
            next_elevator = elevator + direction
            if not 0 <= next_elevator < len(floors):
                continue

            next_floors = floors.copy()
            next_floors[elevator] = next_floors[elevator].difference(move)
            next_floors[next_elevator] = next_floors[next_elevator].union(move)

            if (is_valid_transition(next_floors[elevator]) and is_valid_transition(next_floors[next_elevator])):
                yield (moves + 1, next_elevator, next_floors)

def is_all_top_level(floors):
    return all(not floor
               for number, floor in enumerate(floors)
               if number < len(floors) - 1)

def count_floor_objects(state):
    _, elevator, floors = state
    return elevator, tuple(tuple(Counter(type for _, type in floor).most_common()) for floor in floors)

def min_moves_to_top_level(floors) -> int:
    seen = set()
    queue = deque([(0, 0, floors)])
    moves = -1

    while queue:
        state = queue.popleft()
        moves, _, floors = state

        if is_all_top_level(floors):
            return moves

        for next_state in next_states(state):
            if (key := count_floor_objects(next_state)) not in seen:
                seen.add(key)
                queue.append(next_state)
    return moves

def main():
  file_name = "input.txt"
  result = day11(file_name)
  print(f"Part1 result: {result}")

  file_name = "input2.txt"
  result = day11(file_name)
  print(f"Part2 result: {result}")

def day11(file_name: str) -> int: 
   floors = load_input(file_name)
   result = min_moves_to_top_level(floors)
   return result


def test_part1():
  file_name = "sample.txt"
  result = day11(file_name)
  expected = 11
  assert(result == expected)

if __name__ == "__main__":
  pytest.main([__file__])
  main()