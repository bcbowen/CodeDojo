-= Puzzle 4: Beach Cleanup =-

You're on a mission to clean up all the trash in the entire world (anything for some Pointers these days, eh?), starting with this local beach.

The beach is 101 by 101 meters. You're given a list of coordinates where trash is located.
Each coordinate is represented by two numbers, each ranging from 0 to 100.
The first number represents the x-coordinate and the second number represents the y-coordinate.
The numbers are separated by a comma.

You start at the corner of the beach, at coordinates (x: 0, y: 0).
You can walk up, down, left or right 1 meter at a time.
You can only pick up trash when you're standing on the exact coordinates where it's located.

The trash pieces are listed in the order they were discovered, and you must collect them in that exact sequence.
You can only pick up a piece of trash when you are standing on its coordinates; after collecting it, you proceed to the next one in the list.
Passing over a trash piece that is not the next one in the sequence will not collect it.

For example:

Let's say for this example the beach is 10 by 10 meters,
Input:

```text
3,3
9,9
6,6
```

This input has 3 trash pieces, each at coordinates (3,3), (9,9) and (6,6).
Let's label them A, B and C respectively and label your starting position as @.

We can visualize this beach as follows:

```text
.........B
..........
..........
......C...
..........
..........
...A......
..........
..........
@.........
```

To reach the first piece of trash (A) in the shortest amount of steps, you would walk 3 steps right and 3 steps up (This is one of the many ways to reach the point).
After picking up the trash, your position would be at (3,3).
To reach the second piece of trash (B), you would walk 6 steps right and 6 steps up from your new position (3,3).
After picking up the trash, your position would be at (9,9).
To reach the third piece of trash (C), you would walk 3 steps left and 3 steps down.
After picking up the trash, your position would be at (6,6).

The total number of steps taken in this example is 3 + 3 + 6 + 6 + 3 + 3 = 24.

Your puzzle input contains the coordinates of all the trash pieces on the beach, in the exact order you need to pick them up.

What is the total amount of steps taken to pick up all the trash?