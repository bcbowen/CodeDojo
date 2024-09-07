class HashMap:
    def insert(self, key, value):
        
        if len(self.hashmap) == 0: 
            self.hashmap.append(None)
        else: 
            load = self.current_load()
            if load >= .05: 
                self.resize()

        index = self.key_to_index(key)
        self.hashmap[index] = (key, value)

    def resize(self):
        new_hashmap = HashMap(len(self.hashmap) * 10)
        old_hashmap = self.hashmap
        self.hashmap = new_hashmap.hashmap
        for i in range(len(old_hashmap)): 
            if old_hashmap[i] != None: 
                key, value = old_hashmap[i]
                index = self.key_to_index(key)
                self.hashmap[index] = (key, value)
    
                

    def current_load(self):
        count = 0
        for i in range(len(self.hashmap)):
            if self.hashmap[i] != None: 
                count += 1
        return 1 if count == 0 else count / len(self.hashmap)

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