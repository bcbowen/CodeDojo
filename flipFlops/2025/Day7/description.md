-= Puzzle 7: Hyper Grids =-
You've gotten quite far in your journey through C-land, and now you find yourself at your final destination: the map makers' guild.

You arrive at the map makers' guild in C-land. The guild is filled with maps of all shapes and sizes, and you're eager to explore them all.

You meet the guild master, who hands you a few maps of empty grids (your puzzle input). "We need you to find the shortest path to the farthest corner of each grid," they explain.

"After that, you need to determine the number of distinct shortest paths to the farthest corner"

Your input consists of a series of sizes, like this:

```text
2 2
3 3
2 3
```

The first number in each line represents the number of rows, and the second number represents the number of columns in the grid.

Mapping these 3 grids out would make them look something like this:

```text
      ..       ...       ..
2 2 = .. 3 3 = ... 2 3 = ..
               ...       ..
```

We can then mark the start and end positions like this:

``` text
      S.       S..       S.
2 2 = .E 3 3 = ... 2 3 = ..
               ..E       .E
```

One of the shortest paths to the farthest corner of each grid is then:

```text
      -+       --+       -+
2 2 = .| 3 3 = ..| 2 3 = .|
               ..|       .|
```

The shortest path for the first grid is 3 steps long, the shortest path for the second grid is 5 steps long, and the shortest path for the third grid is 4 steps long.

Now, the guild master wants you to determine how many shortest paths exist for each grid.

For example, the first grid has 2 shortest paths, the second grid has 6 shortest paths, and the third grid has 3 shortest paths.

Here are all the shortest paths:

```text
      -+     |.
2 2 = .| and +-


      --+   -+.   |..   |..   |..     -+.
3 3 = ..| , .++ , +-+ , ++. , |.. and .|.
      ..|   ..|   ..|   .+-   +--     .+-

      -+   |      |.
2 3 = .| , ++ and |.
      .+   .|     +-
```

Your answer is the sum of the number of shortest paths for each grid. For all the examples that answer is `11`.

What is the sum of the number of shortest paths for each grid?