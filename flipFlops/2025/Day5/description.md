-= Puzzle 5: Strange Tunnels =-
You arrive at the train station in C-land, ready to explore the vast network of tunnels.

As you board one of the trains, you look ahead and see a long series of tunnels.

Each tunnel is labeled with a single letter and has exactly two ends.

You're given a sequence of tunnel labels (your puzzle input). Each tunnel is represented by a single uppercase or lowercase letter.

Each letter appears exactly twice, representing the two ends of a single tunnel.

Example Input:

`ABccksiPiBAksP`
This input contains seven different tunnels: A, B, c, k, s, i, and P.

The train starts at the first tunnel and moves through the sequence in the order the tunnels appear.

When it enters a tunnel, it instantly moves to the matching letter's position.

The number of steps taken inside a tunnel is equal to the number of characters between the two ends of that tunnel plus the exit step.

In the following diagram, arrows indicate the direction of travel between matching tunnel ends:

ABccksiPiBAksP
|---------^      // A -> A  (10 steps)
ABccksiPiBAksP
    ^------|     // k <- k  (7 steps)
ABccksiPiBAksP
     |------^    // s -> s  (7 steps)
ABccksiPiBAksP
       ^-----|   // P <- P  (6 steps)
ABccksiPiBAksP
      ^-|        // i <- i  (2 steps)
ABccksiPiBAksP
       |-----^   // P -> P  (6 steps, end of line)
The train moves forward or backward, depending on which tunnel it is currently in.

Counting the steps taken inside each tunnel, we get:

```text
A -> A  = 10 steps
k <- k  =  7 steps
s -> s  =  7 steps
P <- P  =  6 steps
i <- i  =  2 steps
P -> P  =  6 steps
------------------
Total   = 38 steps
```

Keep in mind that the step from one tunnel to the next is not counted. (Outside the tunnel)

What is the total number of steps the train takes inside tunnels for the full map?

Your answer was: `1546`

-= Part 2: Unused Tunnels =-
After exploring the tunnels, you realize that some tunnels are not visited by the train.

You have to know which tunnels are not visited so you can plan another trip to go back and visit them still.

In the previous example, the train visits the tunnels A, k, s, i, and P.

The tunnels B and c are not visited.

The answer, in the order in which they appear, is Bc.

What tunnels are not visited by the train on the full map? (Answer must be in order of appearance)

Your answer was: `FdEsPoHkfjaSLze`

-= Part 3: Powered Tunnels =-
As you near the first tunnel, you notice a sign that says "Powered Tunnels".

Curious, you read the sign and learn that these tunnels have special properties.

When the train enters a powered tunnel, it emerges at the other end having taken a negative number of steps (don't question it).

A powered tunnel is represented by an uppercase letter.

Example Walkthrough:

```text
A -> A  = -10 steps
k <- k  =   7 steps
s -> s  =   7 steps
P <- P  =  -6 steps
i <- i  =   2 steps
P -> P  =  -6 steps
-------------------
```

Total   =  -6 steps
Since A and P are powered tunnels, the train takes negative steps for those tunnels.

What is the total number of steps the train takes inside tunnels for the full map with these new rules?

