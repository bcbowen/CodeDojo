import pytest
import re
from collections import deque, Counter
from itertools import chain, combinations
from pathlib import Path
from typing import List, Set

# Solution borrowed from Ed Mann: https://eddmann.com/posts/advent-of-code-2016-day-11-radioisotope-thermoelectric-generators/

def get_input_filepath(file_name: str) -> Path:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_input(file_name: str) -> List[Set[str]]: 
  path = get_input_filepath(file_name)
  with open(path, "rt") as file: 
    input = file.read()
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