# Import files (No need declared in __init__.py)
from module import fileA, fileB

# Import methods declared in __init__.py
from module import methodA

# Import methods not declared in __init__.py
from module.fileB import methodB

methodA()
fileA.methodA2()
methodB()
fileB.methodB2()
