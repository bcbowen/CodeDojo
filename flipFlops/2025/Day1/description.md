-= Prologue: Dream Vacation =-
You are on vacation to C-land, a true paradise filled with segmentation faults, null pointers and memory leaks.
There's just one problem, you're out of Pointers *!
Pointers are the currency of C-land, and you need them to pay for your vacation.

Over the course of the next four days you're going to try to earn enough Pointers to pay for your vacation.

On Monday, Tuesday and Wednesday you will be solving 2 puzzles each day, and on Thursday you will be solving 1 final puzzle. (each day releasing at 10:00:00 and 14:00:00)
Each puzzle has 3 parts, each part harder than the last.
Solving each part will earn you 1 Pointer.
Can you earn all 21 Pointers in time?

Finishing all the puzzles will surely get you a nice vacation!

Good luck!
-= Puzzle 1: Banana Contest =-
You arrive at the Annual Banana Contest in C-land. The room is filled with excitement and the smell of bananas.

As you get seated, you notice the presenter behind the stage. They seem to be panicking about something.

You walk over to the stage and ask them what's wrong. They explain that one of their judges has fallen ill and they need someone to take their place.
"I'm not sure if you're qualified," they say, "but we're in a bit of a pickle here. Can you help us out?"

You agree to help out and they show you a bunch of bananas on a table. "We need you to give this bunch of bananas a score," they explain. "The score is based on the total length of the bananas in the bunch."

The way the length of the bananas is measured is a bit peculiar. The length of each banana is measured by the name of the banana. It's equal to the number of "ba"'s or "na"'s in the name of the banana.

The presenter shows you the first bunch:

```text
banana
banenanana
bananana
bananananana
bananananana
```

After counting the "ba"s and "na"s in each name, you find that the total length of this bunch is 24.
For each banana:

```text
banana       (3) 
banenanana   (5)
bananana     (4)
bananananana (6)
bananananana (6)
```

But hold on! Why is there a "banenanana" in the bunch? It has an e in it! You ask the presenter about it and they explain that it's the banena™ substitute.
"Think of it as just another 'na', even though it has an 'e' in it. Just count it normally in the total."

We should count the "banenanana" as a normal banana.
With this, the total length of the example bunch is (again) 24 points.

After you scored the bunch, the next bunch is handed to you, and this one is big. (your puzzle input)

What is the total length of this bunch of bananas?


Your answer was: 10081

-= Part 2: Uneven Bunch =-
Impressed by your work, the presenter invites you to judge the next round. But this time, there's a new rule...

"This time, we want you to ignore the score of the bananas that have an odd length." they explain.

Looking at the first smaller bunch, you see that the odd-length bananas are:

```text
banana       (3: odd)
banenanana   (5: odd)
bananana     (4: even)
bananananana (6: even)
bananananana (6: even)
```

Now, we only sum up the even-length bananas: 4 + 6 + 6 = 16.
What is the total length of the even-length bananas in the big bunch?

Your answer was: 5004

-= Part 3: Deprecation! =-
The presenter seems deep in thought, nodding as they admire the new banena™ substitutes. But suddenly, their phone rings...

They pick it up and start talking to someone. You can't hear what they're saying, but you can see the presenter's face turning pale.

After hanging up, the presenter turns to you and explains that the banena™ substitutes are being deprecated.
"We need to know how many points come from banena™ substitutes in the bunch," they say, "so we can remove them from the score."

The smaller bunch has one banena™ substitute:

```text
banana       (3)
banenanana   (5, banena™ substitute)
bananana     (4)
bananananana (6)
bananananana (6)                    
```

Originally: 24. But we subtract the 5 points from 'banenanana', leaving us with 19.
The presenter hands you the big bunch of bananas and asks you to calculate the new score, excluding the banena™ substitutes.

How many points do you get after removing the banena™ substitutes from the big bunch?

Your answer was: 2388

You've completed all the parts for this day! This earns you 3 Pointers ***!