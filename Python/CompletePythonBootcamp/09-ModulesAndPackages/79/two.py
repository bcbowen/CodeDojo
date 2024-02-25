import one

print("top in two.py") 

one.func()

if __name__ == '__main__': 
    print("two.py running directly ")
else: 
    print("two.py has been imported ")