import pytest
from typing import Set

def main(): 
    squares = []
    for i in range(10,500): 
        squares.append(i**2)
    
    triplets = set()
    
    for i in range(len(squares)): 
        for j in range(i, len(squares)): 
            if squares[i] + squares[j] in squares: 
                triplets.add((squares[i], squares[j], squares[i] + squares[j]))

    min_diff = 1000
    for A, B, C in triplets: 
        a = A ** .5 
        b = B ** .5
        c = C ** .5
        diff = abs(a + b + c - 1000)
        if diff < min_diff: 
            print(f"New min diff found: {diff} {A}, {B}, {C} ___ {a}, {b}, {c} {a * b * c}")
            min_diff = diff
    print(f"Final min diff: {min_diff}")

if __name__ == "__main__":
    main()