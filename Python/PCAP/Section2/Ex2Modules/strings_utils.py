import string_utils

def halve_strings(string_list): 
    result = []
    for val in string_list: 
        result.append(string_utils.halve_string(val))
    return result