import json
import pytest
import time
from pathlib import Path
from typing import List

class Solution:
    def asteroidsDestroyed(self, mass: int, asteroids: List[int]) -> bool:
        asteroids.sort()
        for asteroid in asteroids: 
            if asteroid > mass: 
                return False
            mass += asteroid
        return True

"""
Example 1:
Input: mass = 10, asteroids = [3,9,19,5,21]
Output: true
Explanation: One way to order the asteroids is [9,19,5,3,21]:
- The planet collides with the asteroid with a mass of 9. New planet mass: 10 + 9 = 19
- The planet collides with the asteroid with a mass of 19. New planet mass: 19 + 19 = 38
- The planet collides with the asteroid with a mass of 5. New planet mass: 38 + 5 = 43
- The planet collides with the asteroid with a mass of 3. New planet mass: 43 + 3 = 46
- The planet collides with the asteroid with a mass of 21. New planet mass: 46 + 21 = 67
All asteroids are destroyed.

Example 2:
Input: mass = 5, asteroids = [4,9,23,4]
Output: false
Explanation: 
The planet cannot ever gain enough mass to destroy the asteroid with a mass of 23.
After the planet destroys the other asteroids, it will have a mass of 5 + 4 + 9 + 4 = 22.
This is less than 23, so a collision would not destroy the last asteroid.

"""
@pytest.mark.parametrize("mass, asteroids, expected", [
    (10, [3,9,19,5,21], True), 
    (5, [4,9,23,4], False)
])
def test_asteroidsDestroyed(mass: int, asteroids: List[int], expected: bool):
    result = Solution().asteroidsDestroyed(mass, asteroids)
    assert(result == expected)

# initial implementation 54 seconds
# improved implementation 1.45 seconds
# final implementation in .008669 seconds
def test_54TLE(): 
    data_path = Path(__file__).parent.parent.parent / "Data"
    file_name = "2126_54.txt"    
    path = data_path / file_name
    with open(path, "r") as file: 
        mass = int(file.readline())
        asteroids = json.loads(file.readline())
        expected = bool(file.readline())

    start_time = time.perf_counter()  # Start the timer
    result = Solution().asteroidsDestroyed(mass, asteroids)
    end_time = time.perf_counter()    # Stop the timer

    execution_time = end_time - start_time
    print(f"Execution time: {execution_time:.6f} seconds")
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 