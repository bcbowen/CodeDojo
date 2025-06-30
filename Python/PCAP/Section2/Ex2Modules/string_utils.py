import math 

def halve_string(input_string): 
    mid = int(math.ceil(len(input_string) / 2))
    return ((input_string[0:mid]), input_string[mid:])
    
if __name__ == "__main__":
    input_string = "mark"
    result = halve_string(input_string)
    assert(len(result) == 2)
    assert(result[0] == "ma")
    assert(result[1] == "rk")
    print("halve_string with even len OK")
    
    input_string = "lydia"
    result = halve_string(input_string)
    assert(len(result) == 2)
    assert(result[0] == "lyd")
    assert(result[1] == "ia")
    print("halve_string with odd len OK")