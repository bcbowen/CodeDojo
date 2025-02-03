import pytest

class Solution:
    def findWinners(self, matches: list[list[int]]) -> list[list[int]]:
        loss_counts = {}
        for match in matches: 
            key = match[0]
            if not key in loss_counts: 
                loss_counts[key] = 0
            key = match[1]
            if not key in loss_counts: 
                loss_counts[key] = 0

            loss_counts[key] += 1

        no_loss = []
        one_loss = [] 
        for key in loss_counts.keys(): 
            if loss_counts[key] == 0: 
                no_loss.append(key)
            elif loss_counts[key] == 1: 
                one_loss.append(key)
        
        result = [ sorted(no_loss), sorted(one_loss)]
        return result


"""
Example 1:
Input: matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
Output: [[1,2,10],[4,5,7,8]]
Explanation:
Players 1, 2, and 10 have not lost any matches.
Players 4, 5, 7, and 8 each have lost one match.
Players 3, 6, and 9 each have lost two matches.
Thus, answer[0] = [1,2,10] and answer[1] = [4,5,7,8].

Example 2:
Input: matches = [[2,3],[1,3],[5,4],[6,4]]
Output: [[1,2,5,6],[]]
Explanation:
Players 1, 2, 5, and 6 have not lost any matches.
Players 3 and 4 each have lost two matches.
Thus, answer[0] = [1,2,5,6] and answer[1] = [].
"""
@pytest.mark.parametrize("matches, expected", [
    ([[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]], [[1,2,10],[4,5,7,8]]), 
    ([[2,3],[1,3],[5,4],[6,4]], [[1,2,5,6],[]])
])
def test_findWinners(matches: list[list[int]], expected: list[list[int]]):
    sol = Solution() 
    result = sol.findWinners(matches)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])