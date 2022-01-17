from module import fileA, fileB, fileC, fileD

fileA.printX()      # 42
fileA.x += 1        
fileA.printX()      # 43

fileB.printX()      # 43
fileB.increaseX()   
fileB.printX()      # 44

fileC.printX()      # 44
fileC.increaseX()   
fileC.printX()      # 45

fileD.printX()      # 42
fileD.increaseX()   # Traceback
fileD.printX()
