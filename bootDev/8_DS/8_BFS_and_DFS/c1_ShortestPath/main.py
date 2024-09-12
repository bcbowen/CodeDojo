class Graph:
    def bfs_path(self, start, end):
        paths = {}
        queue = []
        visited = [] 
        queue.append(start)
        visited.append(start)
        paths[start] = [] 
        paths[start].append(start)
        while len(queue) > 0: 
            val = queue.pop(0)
            visited.append(val)
            for n in self.graph[val]:
                if not n in visited and not n in queue: 
                    queue.append(n)
                    paths[n] = paths[val] + [n]
                    if n == end: 
                        return paths[n]
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