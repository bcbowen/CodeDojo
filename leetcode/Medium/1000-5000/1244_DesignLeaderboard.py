import pytest


class Leaderboard:

    def __init__(self):
        self.scores = {}             

    def addScore(self, playerId: int, score: int) -> None:
        if not playerId in self.scores: 
            self.scores[playerId] = 0
        self.scores[playerId] += score

    def top(self, K: int) -> int:
        all_scores = list(self.scores.values()) 
        all_scores.sort(reverse = True)
        return sum(all_scores[:K])

    def reset(self, playerId: int) -> None:
        del self.scores[playerId]
        


# Your Leaderboard object will be instantiated and called as such:
# obj = Leaderboard()
# obj.addScore(playerId,score)
# param_2 = obj.top(K)
# obj.reset(playerId)


"""
Example 1:

Input: 
["Leaderboard","addScore","addScore","addScore","addScore","addScore","top","reset","reset","addScore","top"]
[[],[1,73],[2,56],[3,39],[4,51],[5,4],[1],[1],[2],[2,51],[3]]
Output: 
[null,null,null,null,null,null,73,null,null,null,141]

Explanation: 
Leaderboard leaderboard = new Leaderboard ();
leaderboard.addScore(1,73);   // leaderboard = [[1,73]];
leaderboard.addScore(2,56);   // leaderboard = [[1,73],[2,56]];
leaderboard.addScore(3,39);   // leaderboard = [[1,73],[2,56],[3,39]];
leaderboard.addScore(4,51);   // leaderboard = [[1,73],[2,56],[3,39],[4,51]];
leaderboard.addScore(5,4);    // leaderboard = [[1,73],[2,56],[3,39],[4,51],[5,4]];
leaderboard.top(1);           // returns 73;
leaderboard.reset(1);         // leaderboard = [[2,56],[3,39],[4,51],[5,4]];
leaderboard.reset(2);         // leaderboard = [[3,39],[4,51],[5,4]];
leaderboard.addScore(2,51);   // leaderboard = [[2,51],[3,39],[4,51],[5,4]];
leaderboard.top(3);           // returns 141 = 51 + 51 + 39;
"""
def test_leader_board(): 
    board = Leaderboard()
    board.addScore(1, 73)
    board.addScore(2, 56)
    board.addScore(3, 39)
    board.addScore(4, 51)
    board.addScore(5, 4)
    result = board.top(1)
    expected = 73
    assert(result == expected)
    board.reset(1)
    board.reset(2)
    board.addScore(2, 51)
    result = board.top(3)
    expected = 141
    assert(result == expected)
     


if __name__ == "__main__": 
    pytest.main([__file__])