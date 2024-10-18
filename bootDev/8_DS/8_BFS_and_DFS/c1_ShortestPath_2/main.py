class Graph:
    def bfs_path(self, start, end):
        queue = []
        visited = set()  # Using a set for faster lookup
        queue.append([start])
        visited.add(start)
        while queue:
            path = queue.pop(0)
            city = path[-1]
            if city == end:
                return path
            connected_cities = sorted(self.graph[city])  # Sort the neighbors
            for next_city in connected_cities:
                if next_city not in visited:
                    visited.add(next_city)
                    queue.append(path + [next_city])
        return None
            

    # don't touch below this line

    def __init__(self):
        self.graph = {}

    def add_edge(self, u, v):
        if u in self.graph.keys():
            self.graph[u].add(v)
        else:
            self.graph[u] = set([v])
        if v in self.graph.keys():
            self.graph[v].add(u)
        else:
            self.graph[v] = set([u])

    def __repr__(self):
        result = ""
        for key in self.graph.keys():
            result += f"Vertex: '{key}'\n"
            for v in sorted(self.graph[key]):
                result += f"has an edge leading to --> {v} \n"
        return result
