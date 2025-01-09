import pytest

class Solution(object):
    def sortPeople(self, names, heights):
        """
        :type names: List[str]
        :type heights: List[int]
        :rtype: List[str]
        """
        name_heights = list(zip(names, heights))


        return list(map(lambda nh: nh[0], sorted(name_heights, key=lambda tup: tup[1], reverse=True)))

"""
Return names sorted in descending order by the people's heights.
Example 1:
Input: names = ["Mary","John","Emma"], heights = [180,165,170]
Output: ["Mary","Emma","John"]
Explanation: Mary is the tallest, followed by Emma and John.

Example 2:
Input: names = ["Alice","Bob","Bob"], heights = [155,185,150]
Output: ["Bob","Alice","Bob"]
Explanation: The first Bob is the tallest, followed by Alice and the second Bob.
"""


@pytest.mark.parametrize("names, heights, expected", [
    (["Mary","John","Emma"], [180,165,170], ["Mary","Emma","John"]),
    (["Alice","Bob","Bob"], [155,185,150], ["Bob","Alice","Bob"])
])
def test_number_of_pairs(names, heights, expected):
    result = Solution().sortPeople(names, heights)
    print(f"hey dude {names} {heights} --> {result} [{expected}] ")
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])