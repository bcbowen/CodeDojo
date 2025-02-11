class Solution:
    def backspaceCompare(self, s: str, t: str) -> bool:
        s_list = [] 
        t_list = [] 

        for c in s: 
            if c != '#': 
                s_list.append(c)
            elif s_list: 
                s_list.pop()
        
        for c in t: 
            if c  != '#': 
                t_list.append(c)
            elif t_list: 
                t_list.pop()

        return s_list == t_list