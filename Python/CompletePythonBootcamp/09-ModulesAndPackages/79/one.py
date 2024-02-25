def func(): 
    print("func in one.py")

print("top level in one.py")

if __name__ == "__main__":
    print("one.py running directly")
else: 
    print("one.py has been imported")