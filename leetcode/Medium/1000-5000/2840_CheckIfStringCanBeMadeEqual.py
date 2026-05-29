class Solution:
    def checkStrings(self, s1: str, s2: str) -> bool:
        e1 = [] 
        o1 = [] 
        e2 = [] 
        o2 = [] 

        for i in range(len(s1)): 
            if i % 2 == 0: 
                e1.append(s1[i])
                e2.append(s2[i])
            else: 
                o1.append(s1[i])
                o2.append(s2[i])

        e1.sort()
        e2.sort() 
        o1.sort()
        o2.sort()
        return e1 == e2 and o1 == o2