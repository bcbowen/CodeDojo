# Advent of Code Solutions

## Overview

These are solutions hacked together to solve the yearly Advent of Code puzzles. I originally did these in C# using LinqPad but for the last few years I've switched to Python. Also I've gone back and started doing the earlier years in Python.

## Getting Started

I have the inputs in a private repo. I recommend you create a private repo or a location on your personal network with the same structure as the solution files. This makes it easy to find the inputs for each puzzle. Then set the path to the input files using an environment variable or .env file.

The code uses `python-dotenv` to load environment variables from a `.env` file in the project root.

Linux/macOS (bash/zsh):

```bash
export AOC_INPUTS_DIR="$HOME/code/aoc-inputs"
```

Put that in ~/.bashrc or ~/.zshrc.

Windows:

Create a `.env` file in the `adventOfCode` directory with your input path:

```text
AOC_INPUTS_DIR=C:\path\to\your\aoc-inputs
```

Replace `C:\path\to\your\aoc-inputs` with the actual path to your input files.