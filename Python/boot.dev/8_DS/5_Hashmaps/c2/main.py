class HashMap:
    def insert(self, key, value):
        self.resize()

        index = self.key_to_index(key)
        self.hashmap[index] = (key, value)

    def resize(self):
        if len(self.hashmap) == 0: 
            self.hashmap.append(None)
        else: 
            load = self.current_load()
            if load >= .05: 
                new_hashmap = HashMap(len(self.hashmap) * 10)
                for i in range(len(self.hashmap)): 
                    if self.hashmap[i] != None: 
                        key, value = self.hashmap[i]
                        new_hashmap.insert(key, value)
                self.hashmap = new_hashmap.hashmap

    def current_load(self):
        count = 0
        for i in range(len(self.hashmap)):
            if self.hashmap[i] != None: 
                count += 1
        return 1 if count == 0 else len(self.hashmap) / count

    # don't touch below this line

    def __init__(self, size):
        self.hashmap = [None for i in range(size)]

    def key_to_index(self, key):
        sum = 0
        for c in key:
            sum += ord(c)
        return sum % len(self.hashmap)

    def __repr__(self):
        final = ""
        for i, v in enumerate(self.hashmap):
            if v != None:
                final += f" - {str(v)}\n"
        return final
