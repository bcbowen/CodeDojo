from typing import List


class Solution:
    def highFive(self, items: List[List[int]]) -> List[List[int]]:
        averages = []

        scores = {}
        for id, score in items:
            if not id in scores: 
                scores[id] = []
            scores[id].append(score)

        for item in scores.items(): 
            score_list = item[1]
            score_list.sort(reverse=True)
            score_list = score_list[0:5]
            averages.append([item[0], sum(score_list) // len(score_list)])


        averages.sort(key = lambda a: a[0])

        return averages