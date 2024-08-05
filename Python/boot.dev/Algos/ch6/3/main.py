def tsp(cities, paths, dist):
    routes = permutations(cities)
    #print(f"p: {city_permutations}")
    min_dist = float("inf")
    min_route = []
    for route in routes: 
        route_dist = get_total_distance(route, paths)
        if route_dist < min_dist: 
            min_dist = route_dist
            min_route = route
    if dist == 1066: 
        print(f"md: {min_dist}")
    print (f"min_route: {min_route}")
    return min_dist < dist

def get_total_distance(route: list[int], paths: list[list[int]]) -> int:
    dist = 0
    
    for i in range(len(route) - 1): 
        #next_dist = 0
        #path = paths[i]
        #next_dist = path[route[i + 1]]
        #if next_dist == 0: 
        #    path = paths[i + 1]
        #    next_dist = path[route[i]]
        #dist += next_dist
        dist += get_distance_to_city(route[i], route[i + 1], paths)
    return dist

def get_distance_to_city(start: int, end: int, paths: list[list[int]]) -> int: 
    path = paths[start]
    dist = path[end]
    return dist

# don't touch below this line


def permutations(arr):
    res = []
    res = helper(res, arr, len(arr))
    return res


def helper(res, arr, n):
    if n == 1:
        tmp = arr.copy()
        res.append(tmp)
    else:
        for i in range(n):
            res = helper(res, arr, n - 1)
            if n % 2 == 1:
                arr[n - 1], arr[i] = arr[i], arr[n - 1]
            else:
                arr[0], arr[n - 1] = arr[n - 1], arr[0]
    return res