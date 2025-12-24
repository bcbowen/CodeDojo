**-= Puzzle 2: Rollercoaster Heights =-**
You run into two suspiciously familiar inventors: Feneas and Pherb (not related to anyone famous). "We've designed the ultimate rollercoaster!" Feneas exclaims, handing you a blueprint. Pherb nods, silently. "We want to advertise it as the tallest rollercoaster in the world," Feneas continues. "Can you do that for us?"

Aren't you two a bit young to be designing rollercoasters? you think to yourself. But you decide to help them out anyway.

The blueprint (your puzzle input) consists of a series of movements: Up (^) and Down (v). Each movement corresponds to a change in height. The rollercoaster starts at ground level (height = 0). Each Up (^) movement increases the height by 1 meter, and each Down (v) movement decreases the height by 1 meter.

For example:

Blueprint: `^v^v^v^v^v`
Movements: `up, down, up, down, up, down, up`
This blueprint results in the following heights:
`1, 0, 1, 0, 1, 0, 1, 0, 1, 0`
The highest point the coaster reaches in this example is 1 meter.

Because the coaster is pretty awesome, it can even descend below ground level!

Another Example:

Blueprint: `^^^v^^^^vvvvvvv`
Movements: 

```text
up, up, up, down, up, up, up, up, down, down, down, down, down, down, down
This blueprint results in the following heights:
1, 2, 3, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1, 0, -1
```

The highest point the coaster reaches in this example is 6 meters.

What is the highest point the full coaster reaches?

Your answer was: `108`

**-= Part 2: Aim Higher =-**

You look at the numbers... and you realize they are way too small! The height changes are not linear anymore. Instead, each movement adds or subtracts a value that increases cumulatively.

For consecutive Up (^) movements, the height increases by the current movement number.
For example:
The 1st up movement increases the height by 1.
The 2nd consecutive up movement increases the height by 2.
The 3rd consecutive up movement increases the height by 3.
And so on.
For consecutive Down (v) movements, the height decreases by the current movement number.
For example:
The 1st down movement decreases the height by 1.
The 2nd consecutive down movement decreases the height by 2.
The 3rd consecutive down movement decreases the height by 3.
And so on.
When the direction changes (e.g., from Up to Down or Down to Up), the count resets.

Here's a simple example:

Blueprint: `^^^^^`
Movements: `up, up, up, up, up`
Height changes:

```text
1 up -> +1 -> 1
2 up -> +2 -> 3
3 up -> +3 -> 6
4 up -> +4 -> 10
5 up -> +5 -> 15
```

 The highest point the coaster reaches in this example is 15 meters.

Revisiting the previous example:

Blueprint: `^^^v^^^^vvvvvvv`
Movements: `up, up, up, down, up, up, up, up, down, down, down, down, down, down, down`
Height changes:

```text
1 up -> +1 -> 1
2 up -> +2 -> 3
3 up -> +3 -> 6
1 down -> -1 -> 5
1 up -> +1 -> 6
2 up -> +2 -> 8
3 up -> +3 -> 11
4 up -> +4 -> 15
1 down -> -1 -> 14
2 down -> -2 -> 12
3 down -> -3 -> 9
4 down -> -4 -> 5
5 down -> -5 -> 0
6 down -> -6 -> -6
7 down -> -7 -> -13
```

 The highest point the coaster reaches in this example is also, 15 meters.

What is the highest point the full coaster reaches with these steep height changes?

Your answer was: `1152`

**-= Part 3: Aim even higher! =-**

You look over at the coaster, and then back at the numbers... and you realize they are still waaaay too small!

The height changes actually follow the Fibonacci sequence instead of the linear or stepwise patterns from before. A sequence of Up (^) or Down (v) movements now corresponds to the Fibonacci value of the total number of movements.

The height change for a consecutive sequence of movements is determined by the Fibonacci number of the total steps in that sequence:

n consecutive Up (^) movements add fib(n) to the height.
n consecutive Down (v) movements subtract fib(n) from the height.
When the direction changes (e.g., from Up to Down or Down to Up), the count resets.

Fibonacci Sequence:
The Fibonacci sequence is defined as follows:

```text
fib(0) = 0
fib(1) = 1
fib(2) = fib(0) + fib(1) = 0 + 1 = 1
fib(3) = fib(1) + fib(2) = 1 + 1 = 2
fib(4) = fib(2) + fib(3) = 1 + 2 = 3
fib(5) = fib(3) + fib(4) = 2 + 3 = 5
fib(6) = fib(4) + fib(5) = 3 + 5 = 8
Etc.
```

Each Fibonacci number is the sum of the two preceding numbers.
A simple coaster would be:
Blueprint: `^^^^^`
Movements: `up, up, up, up, up`
Height changes:
5 consecutive Up -> fib(5) = 5 -> 5
 The highest point the coaster reaches in this example is 5 meters.

The example from before:
Blueprint: `^^^v^^^^vvvvvvv`
Movements: `up, up, up, down, up, up, up, up, down, down, down, down, down, down, down`
Height changes:

```text
3 consecutive Up -> (fib(3) = 2) -> 2
1 consecutive Down -> (fib(1) = 1) -> 1
4 consecutive Up -> (fib(4) = 3) -> 4
7 consecutive Down -> (fib(7) = 13) -> -9
```

 The highest point the coaster reaches in this example is `4` meters.

Example 3:
Blueprint: `^^^^^^^^^^^^vvvvvvvvv^`
Movements: `12 consecutive Up, 9 consecutive Down, 1 consecutive Up`
Height changes:

```text
12 consecutive Up -> fib(12) = 144 -> 144
9 consecutive Down -> fib(9) = 34 -> 110
1 consecutive Up -> fib(1) = 1 -> 111    
```

 The highest point the coaster reaches in this example is 144 meters.

What is the highest point the full coaster reaches with these Fibonacci height changes?

It hasn't changed, but you can still get your puzzle input