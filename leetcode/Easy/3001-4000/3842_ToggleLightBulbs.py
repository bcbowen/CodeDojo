class Solution:
    def toggleLightBulbs(self, bulbs: list[int]) -> list[int]:
        lit = set() 
        for bulb in bulbs: 
            if not bulb in lit: 
                lit.add(bulb)
            else: 
                lit.remove(bulb)

        result = list(lit)
        result.sort()
        return result