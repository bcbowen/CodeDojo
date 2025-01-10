import pytest

class Solution(object):
    def numTeams(self, rating):
        """
        :type rating: List[int]
        :rtype: int
        """
        # brute force asc
        a = 0 
        #b = 1 
        #c = 2
        teams = 0
        while a <= len(rating) - 2: 
            b = a + 1
            print(f"a: {a}: {rating[a]}")
            while b < len(rating) - 1 and rating[b] <= rating[a]:
                b += 1 
                print(f"b: {b}: {rating[b]}")
                c = b + 1
                while c < len(rating):
                    if rating[b] < rating[c]: 
                        teams += 1
                        self.feedback(a, b, c, True)
                    else: 
                        self.feedback(a, b, c, False)
                    c += 1
            a += 1
        
        # brute force desc
        a = 0
        while a <= len(rating) - 2: 
            b = a + 1
            print(f"a: {a}: {rating[a]}")
            while b < len(rating) - 1 and rating[b] >= rating[a]:
                b += 1 
                print(f"b: {b}: {rating[b]}")
                c = b + 1
                while c < len(rating):
                    if rating[b] > rating[c]: 
                        teams += 1
                        self.feedback(a, b, c, True)
                    else: 
                        self.feedback(a, b, c, False)
                    c += 1
            a += 1

        return teams
   
    def feedback(self, a, b, c, isGood): 
        print(f"{isGood}: {a} {b} {c}")

@pytest.mark.parametrize("rating, expected", [
    ([2, 5, 3, 4, 1], 3),
    ([2, 1, 3], 0),
    ([1, 2, 3, 4], 4), 
    ([4, 3, 2, 1], 4)
])
def test_number_of_pairs(rating, expected):
    result = Solution().numTeams(rating)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])