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

The total number of steps taken in this example is `3 + 3 + 6 + 6 + 3 + 3 = 24`.

Your puzzle input contains the coordinates of all the trash pieces on the beach, in the exact order you need to pick them up.

What is the total amount of steps taken to pick up all the trash?

Your answer was: `7094`

-= Part 2: Faster Path =-
After calculating the total amount of steps, you sigh, realizing that this is going to take a while.
You decide to take a different approach to pick up the trash.

Instead of only walking straight up or down, you can now walk diagonally as well.
You can now also walk up-right, up-left, down-right or down-left.

Although you're technically not walking exactly 1 meter diagonally, each diagonal step still counts as 1 meter.

For the previous example, this is how you would pick up the trash:

To reach the first piece of trash in the shortest amount of steps, you would walk 3 steps up-right.
After picking up the trash, your position would be at (3,3).
To reach the second piece of trash, you would walk 6 steps up-right.
After picking up the trash, your position would be at (9,9).
To reach the third piece of trash, you would walk 3 steps down-left.
After picking up the trash, your position would be at (6,6).

The total amount of steps taken in this example is 3 + 6 + 3 = 12.

You realize that this is a much faster way to pick up the trash and you decide to use this method to clean up the beach.

What is the total amount of steps taken to pick up all the trash with the new diagonal movements?

Your answer was: `4798`

-= Part 3: Making Up Your Own Rules =-
You realize, after finishing the cleanup, that the collection order was highly inefficient.

To prove that fact, you decide to place back all the trash in the same locations and try to find a more efficient way to pick them up.

The order of the trash pieces can be heavily optimized, so to do that you sort them based on the distance from it to your start position (0,0).

The distance you sort them by is the Manhattan distance, which is the sum of their horizontal and vertical distances.
You sort them from closest to furthest away from your start position (x: 0, y: 0).

For the previous example, this is how it would be sorted:

First we get the Manhattan distance for each trash piece:

A: (3,3) -> 3 + 3 = 6
B: (9,9) -> 9 + 9 = 18
C: (6,6) -> 6 + 6 = 12
Then we sort them from closest to furthest away:

A: (3,3)
C: (6,6)
B: (9,9)
You would then pick up the trash in the order A, C, B.

Your pickup strategy is the same as last part, but now you pick up the trash in the newly sorted order.

The total number of steps taken in the newly sorted example is now 3 + 3 + 3 = 9.

What is the total number of steps required to collect all the trash with this new sorting strategy?

Your answer was: `2062`