class Solution:
    def toGoatLatin(self, sentence: str) -> str:
        result = [] 
        
        vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']
        words = sentence.split(' ')
        for i in range(len(words)):
            word = words[i]
            if word[0] in vowels: 
                result.append(f"{word}ma{'a' * (i + 1)}")
            else: 
                result.append(f"{word[1:]}{word[0]}ma{'a' * (i + 1)}")
        return " ".join(result)

