class HashMap:
    def insert(self, key, value):
        index = self.key_to_index(key)
        first_iteration = True
        initial_index = index
        
        while self.hashmap[index] != None: 
            index = (index + 1) % len(self.hashmap)
            if index == 0: 
                first_iteration = False
            if not first_iteration and index == initial_index: 
                raise Exception("hashmap is full")
        self.hashmap[index] = (key, value)
    
    def get(self, key):
        index = self.key_to_index(key)
        initial_index = index
        while self.hashmap[index] != None and key != self.hashmap[index][0]:
            index = (index + 1) % len(self.hashmap)
            if index == initial_index: 
                raise Exception("sorry, key not found")
        return self.hashmap[index][1]
    
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


def test(size, items):
    print(f"Creating Hashmap with size: {size}")
    hm = HashMap(size)
    for item in items:
        key = item[0]
        val = item[1]
        try:
            print(f"Inserting ({key}, {val})...")
            hm.insert(key, val)
        except Exception as e:
            print(e)
    if len(items) > 0:
        key = items[0][0]
        print(f"Getting: {key}")
        print(hm.get(key))
    print("-------------------------------------")
    print(f"Hashmap:\n{hm}")
    print("=====================================")


def main():
    test(
        5,
        [
            ("Billy Beane", "General Manager"),
            ("Peter Brand", "Assistant GM"),
            ("Art Howe", "Manager"),
            ("Ron Washington", "Coach"),
            ("David Justice", "Designated Hitter"),
        ],
    )
    test(
        4,
        [
            ("Billy Beane", "General Manager"),
            ("Peter Brand", "Assistant GM"),
            ("Art Howe", "Manager"),
            ("Scott Hatteberg", "First Baseman"),
            ("David Justice", "Designated Hitter"),
            ("Paul DePodesta", "Analyst"),
            ("Ron Washington", "Coach"),
            ("Chad Bradford", "Pitcher"),
        ],
    )


main()