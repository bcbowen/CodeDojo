import hashlib
from itertools import count
from functools import lru_cache
import pytest

# borrowed from here to troubleshoot my own implementation: 
# https://github.com/fuglede/adventofcode/blob/master/2016/day14/solutions.py
@lru_cache(maxsize=1000)
def md5(s, rounds):
    for _ in range(rounds):
        s = hashlib.md5(s.encode()).hexdigest()
    return s


def md5i(salt, i, rounds):
    return md5(f'{salt}{i}', rounds)


def find_index(salt, rounds):
    found = 0
    for i in count():
        h = md5i(salt, i, rounds)
        for j in range(len(h) - 2):
            if h[j] == h[j+1] and h[j] == h[j+2]:
                char = h[j]
                found_one = False
                for k in range(1, 1001):
                    h2 = md5i(salt, i + k, rounds)
                    for m in range(len(h2) - 5):
                        if h2[m:m+5] == char * 5:
                            found_one = True
                            print(f"{char}({found + 1}): {i}, {i + k}")
                            break
                if found_one:
                    found += 1
                    if found == 64:
                        return i
                break


def main():
    pass 
    #print(find_index('cuanljph', 1))
    #print(find_index('cuanljph', 2017))

def test_part1():
    print(f"Part 1 test: {find_index('abc', 1)}")

if __name__ == "__main__":
    pytest.main([__file__]) 
    main()