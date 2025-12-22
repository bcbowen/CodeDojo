import pytest 
from typing import List

class Solution:
    """
    1 = column sorted
    0 = column equal
    -1 = column unsorted

    unsorted column takes into account the previous character

    unsorted: 
    - ag
    - af

    sorted: 
    - ag
    - ba
    """
    def check_column(self, strs: List[str], i: int) -> int: 
        for row in range(1, len(strs)): 
            if ord(strs[row][i]) < ord(strs[row - 1][i]): 
                if i == 0 or strs[row - 1][i - 1] >= strs[row][i - 1]:
                    return -1
        
        if strs[0][i] == strs[-1][i]: 
            if i == 0 or strs[0][i - 1] == strs[-1][i - 1]: 
                return 0
            
        return 1

    def delete_column(self, strs: List[str], i: int) -> List[str]: 
        new_list = []
        for row in strs: 
            new_list.append(row[0:i] + row[i + 1:])
        return new_list


    def minDeletionSize(self, strs: List[str]) -> int:
        dels = 0
        i = 0
        while i < len(strs[0]): 
            if self.check_column(strs, i) == -1:
                dels += 1
                strs = self.delete_column(strs, i)
            else: 
                i += 1
                    
        return dels
"""
Example 1:
Input: strs = ["ca","bb","ac"]
Output: 1
Explanation: 
After deleting the first column, strs = ["a", "b", "c"].
Now strs is in lexicographic order (ie. strs[0] <= strs[1] <= strs[2]).
We require at least 1 deletion since initially strs was not in lexicographic order, so the answer is 1.

Example 2:
Input: strs = ["xc","yb","za"]
Output: 0
Explanation: 
strs is already in lexicographic order, so we do not need to delete anything.
Note that the rows of strs are not necessarily in lexicographic order:
i.e., it is NOT necessarily true that (strs[0][0] <= strs[0][1] <= ...)

Example 3:
Input: strs = ["zyx","wvu","tsr"]
Output: 3
Explanation: We have to delete every column.

TC 102: 
["xga","xfb","yfa"] : 1

TC 88: 
["bbjwefkpb","axmksfchw"] : 1
"""
@pytest.mark.parametrize("strs, expected", [
    (["ca","bb","ac"], 1),
    (["xc","yb","za"], 0),
    (["zyx","wvu","tsr"], 3),  
    (["xxa","xxb","xxc"], 0),  
    (["xxa","xxb","xxa"], 1), 
    (["xga","xfb","yfa"], 1), 
    (["bbjwefkpb","axmksfchw"], 1)

])
def test_minDeletionSize(strs: List[str], expected: int):
    result = Solution().minDeletionSize(strs)
    assert(result == expected)

@pytest.mark.parametrize("strs, i, expected", [
    (["ca","bb","ac"], 0, -1),
    (["ca","bb","ac"], 1, 1),
    (["xc","yb","za"], 0, 1),
    (["xc","yb","za"], 1, 1), 
    (["xc","xb","xa"], 0, 0), 
    (["xxa","xxb","xxa"], 1, 0), 
    (["xga","xfb","yfa"], 2, -1), 
    (["xa","xb","ya"], 1, 1)
])
def test_check_column(strs: List[str], i: int, expected: int): 
    result = Solution().check_column(strs, i)
    assert(result == expected)

@pytest.mark.parametrize("strs, i, expected", [
    (["ca","bb","ac"], 0, ["a","b","c"]),
    (["zyx","wvu","tsr"], 0, ["yx","vu","sr"]),   
    (["yx","vu","sr"], 0, ["x","u","r"]),  
    (["x","u","r"], 0, ['', '', '']),  
    (["xxa","xxb","xxa"], 2, ["xx","xx","xx"]), 
    (["xga","xfb","yfa"], 1, ["xa","xb","ya"])
])
def test_delete_column(strs: List[str], i: int, expected: List[str]): 
    result = Solution().delete_column(strs, i)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 