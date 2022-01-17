from . import variable
my_variable = variable

def print_variable():
    print(variable)

def increase_variable():
    global variable
    variable += 1

def print_my_variable():
    print(my_variable)

def increase_my_variable():
    global my_variable
    my_variable += 1
