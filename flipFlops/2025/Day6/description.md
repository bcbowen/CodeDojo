-= Puzzle 6: Bird Spotters =-
After the long train journey, you finally arrive at the Annual Bird Spotting Contest in C-land. The room is filled with excitement and the smell of fresh coffee.

As you get seated, the presenter (the same guy at the Banena™ competition) behind the stage starts explaining the rules of the contest.

The contest is simple: you need to take a picture of as many birds as possible in a given time.

You are provided with a list of birds and their speeds (your puzzle input), both for the x and the y speed. Each line represents a bird.

The birds start at position x: 0, y: 0 in the sky, and each second, they move the exact amount given by their speed.

Because this is C-land, the birds overflow when they reach the edge of the sky and wrap around to the other side.

Birds can also underflow when they go backwards below 0 and wrap around to the other side.

For this next example, the sky is 8x8, and the birds have the following speeds:

The puzzle input:

```text
1,0
0,1
1,1
1,-1
-1,1
-1,-1
```

The corresponding birds' speeds:

```text
Bird 1: x: 1, y: 0
Bird 2: x: 0, y: 1
Bird 3: x: 1, y: 1
Bird 4: x: 1, y: -1
Bird 5: x: -1, y: 1
Bird 6: x: -1, y: -1
```

After 1 second, the birds are at the following positions:

```text
Bird 1: x: 1, y: 0
Bird 2: x: 0, y: 1
Bird 3: x: 1, y: 1
Bird 4: x: 1, y: 7 // -1 wraps around to 7
Bird 5: x: 7, y: 1 // -1 wraps around to 7
Bird 6: x: 7, y: 7 // -1 wraps around to 7
```

After 2 seconds, the birds are at the following positions:

```text
Bird 1: x: 2, y: 0
Bird 2: x: 0, y: 2
Bird 3: x: 2, y: 2
Bird 4: x: 2, y: 6
Bird 5: x: 6, y: 2
Bird 6: x: 6, y: 6
```

Until the birds are at the following positions after 7 seconds:

```text
Bird 1: x: 7, y: 0
Bird 2: x: 0, y: 7
Bird 3: x: 7, y: 7
Bird 4: x: 7, y: 1
Bird 5: x: 1, y: 7
Bird 6: x: 1, y: 1
```

And then positively overflowing/reaching zero at 8 seconds:

```text
Bird 1: x: 0, y: 0
Bird 2: x: 0, y: 0
Bird 3: x: 0, y: 0
Bird 4: x: 0, y: 0
Bird 5: x: 0, y: 0
Bird 6: x: 0, y: 0
```

Now, taking a picture only captures birds that are in the frame.

In this case, the frame is 4x4, and the center is in the middle of the sky (x:between 3 and 4, y:between 3 and 4).

We can picture that grid as:

```text
........
........
..####..
..####..
..####..
..####..
........
........
```

The area marked with the # is the area in which the picture can view the birds.

When taking the picture, you count the number of birds in the frame.

For the real contest, the sky is 1000x1000, and the picture frame is 500x500.

That picture frame is also centered in the middle of the sky (top left corner starting at (250, 250)).

You take your picture exactly 100 seconds after the start.

How many birds are in the frame when you take your picture?