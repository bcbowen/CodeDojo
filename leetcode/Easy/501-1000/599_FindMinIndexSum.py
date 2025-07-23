from typing import List

class Solution:
    def findRestaurant(self, list1: List[str], list2: List[str]) -> List[str]:
        result = [] 
        restaurants = {}
        for i in range(len(list1)):
            restaurants[list1[i]] = i 

        min_sum = float('inf')
        for i in range(len(list2)): 
            if list2[i] in restaurants.keys(): 
                sum = i + restaurants[list2[i]]
                if sum < min_sum: 
                    result.clear()
                    min_sum = sum
                    result.append(list2[i]) 

                elif sum == min_sum: 
                    result.append(list2[i]) 

        return result