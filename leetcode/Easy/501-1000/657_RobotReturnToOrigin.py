class Solution:
    def judgeCircle(self, moves: str) -> bool:
        # U R D L
        directions = {'U': (-1, 0), 'R': (0, 1), 'D': (1, 0), 'L': (0, -1)}

        position = (0, 0)
        for move in moves: 
            position = (position[0] + directions[move][0], position[1] + directions[move][1]) 
        return position == (0, 0)