class Trie:
    def words_with_prefix(self, prefix):
        words = []
        current = self.root
        for c in prefix: 
            if not c in current: 
                return words
            current = current[c]
        words = self.search_level(current, prefix, words)

        return words

    def search_level(self, cur, cur_prefix, words):
        if self.end_symbol in cur and not cur_prefix in words: 
            words.append(cur_prefix)
        for key in cur: 
            if key != self.end_symbol: 
                self.search_level(cur[key], cur_prefix + key, words)

        return words

    # don't touch below this line

    def __init__(self):
        self.root = {}
        self.end_symbol = "*"

    def add(self, word):
        current = self.root
        for letter in word:
            if letter not in current:
                current[letter] = {}
            current = current[letter]
        current[self.end_symbol] = True
