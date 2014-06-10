# -*- coding: utf-8 -*-
"""
Created on Sun Aug 11 13:33:14 2013

@author: Kael Larkin - 42011716
"""

import os, sys, numpy as np,Tkinter, tkFileDialog
os.system('cls')

root = Tkinter.Tk()
root.withdraw()




def third(tests, data):
    D = np.array(data)
    x = np.array(tests) 
    #print x
    
    rms = []
    E = []
    numDirec = np.size(D,1)
    numLoc = np.size(D,0)
    
    vals = []
    inds = []
    origD = np.array(D)
      

    for i in range(numLoc):  # loop over locations
        #print
        #print "------",i,"------"
        rms = []
        numFeatures = 7
        
        # Find rms of test point directions to the i-th location, then rotate i clockwise and do it again to determine orientation
        for j in range(numDirec):  # clockwise rotation of D[i] points
            #print "-----",j,"------"  # direction number relative to test point ie 0 = "North"
            #print x
            #print
            #print D[i]
            r = abs(np.linalg.norm(x-D[i]))

            #rms.append(np.sqrt(r))
            rms.append(r)
            t = D[i][np.size(D,1)-1]
            y = D[i][:(np.size(D,1)-1)]
            D[i] = np.insert(y,0,t,0)
            #break
        
        val = np.min(rms)
        vals.append(val)
        ind = np.argmin(rms)
        inds.append(ind)
        E.append([val,ind])
        D = origD
        #print "RMS for point ",i,": ",rms
        #print
    #print "  RMS to each location from test point:  "
    #print "   ",E  # List of total rms to all locations from test point and their orientations
    print 
    re = np.argmin(vals)
    print "  Closest location (raw): ", E[re]
    print "     Distance:  ", E[re][0]
    print "     Direction:  ", E[re][1]
    print "     Location index:  ", re+1
    return re+1, E[re][1]

if __name__ == "__main__":
    mypath = "D:\\Stuff\\Other\\Uni\\2013\\Semester 2\\Thesis\\Data"
    tests = []
    data = []
    temp = []
    actualpts = []
    actualdirs = []
    mapFile = ""
    testFile = ""
    cont = True
    mapLines = []
    solnLines = []
    testLines = []
    while cont:
        if len(sys.argv) < 3:
            for line in os.listdir(mypath):
                print line
            print 
            print
            test = raw_input("Enter prefix of files:  ")
            mapf = test + " map.txt"
            mapFile = os.path.join(mypath,mapf)
            #mapFile = tkFileDialog.askopenfilename()
            print "Selected mapfile:  ",mapFile
            
            print
            #test = raw_input("Enter name of test file:  ")
            testf = test+" tests.txt"
            testFile = os.path.join(mypath,testf)
            #testFile = tkFileDialog.askopenfilename()
            print "Selected testfile:  ",testFile
            
            solnf = test + " soln.txt"
            solnFile = os.path.join(mypath,solnf)
            #solnFile = tkFileDialog.askopenfilename()
            print "Selected solnFile:  ",solnFile
            try:
                f1 = open(mapFile, 'r')
                f2 = open(testFile, 'r')
                f3 = open(solnFile,'r')
                mapLines = f1.readlines()
                testLines = f2.readlines()
                solnLines = f3.readlines()
                f1.close()
                f2.close()
                f3.close()
                print "yay"
                cont = False
                
                break
            except:
                print "here"
                pass
            #cont = False
            #if (raw_input("Press Enter to continue or anything else to start again...")==""):
            #    cont = False
        else:
            kjas = " ".join(sys.argv).split('#')
            mapFile = kjas[1].encode('ascii')
            testFile = kjas[2].encode('ascii')
            
    #mapFile = "D:\\Stuff\\Other\\Uni\\2013\\Semester 2\\Thesis\\Tests\\Beside computers.TXT"
    #testFile = "D:\\Stuff\\Other\\Uni\\2013\\Semester 2\\Thesis\\Tests\\Beside computers Test points.TXT"
            
    

    count = 0
    
    for i in mapLines:
        if (i=='\n') & (count==0):
            temp = temp[0:-1]
            print temp
            raw_input()
            data.append(temp)
            temp = []
            count = 1
        elif i!='\n':
            el = i.strip('\n').split(' ')
            t = []
            for j in range(len(el)):
                t.append(float(el[j])) 
            temp.append(t)
            count = 0
    
    count = 0
    for j in testLines:
        if (j=='\n') & (count==0):
            temp = temp[0:-1]
            tests.append(temp)
            temp = []
            count = 1
        elif j!='\n':
            el = j.strip('\n').split(' ')
            t = []
            for m in range(len(el)):
                t.append(float(el[m])) 
            temp.append(t)
            count = 0
            
    count = 0
    for m in solnLines:
        el = m.strip('\n').split(' ')
        actualpts.append(float(el[0]))
        actualdirs.append(float(el[1]))
        count = 0       
    
    print 
    print
    print "Number of map locations:  ", len(data)
    print "Number of test points:  ",len(tests)
    print
    
    
    newdata = [] 
    newtests = []
    numFeatures = 0
    
    for i in range(len(data)):
        count = 0
        temp = []
        temp2 = []
        for j in range(len(data[i])):
            print j, count
            if numFeatures == 0:
                temp.append(data[i][j])
                try:
                    temp2.append(tests[i][j])
                except:
                    pass
            elif j==count:
                temp.append(data[i][j])
                try:
                    temp2.append(tests[i][j])
                except:
                    pass
                count += (len(data[i])+1)/numFeatures

        newdata.append(temp)
        newtests.append(temp2)
    
    pts = []
    dirs = []
    for t in range(len(tests)):
        print "-------- Test point:",t+1," --------"
        temp = []
        temp.append(newtests[t])
        temp2, pt = third(temp, newdata)
        pts.append(temp2)
        dirs.append(pt)
        print 
        print
        print
        
        
        
    print
    print
    print "---------- SUMMARY ----------"
    numCorrect = 0
    totalCorrect = 0
    current = 1
    straightcorr = 0
    for i in range(len(pts)):
        pt = pts[i]
        gdir = dirs[i]
        apt = actualpts[i]
        adir = actualdirs[i]
        stri1 = "FALSE"
        stri2 = "FALSE"
        stri3 = "FALSE"
        if (abs(pt-apt)<=2):
            stri1 = "TRUE"
            numCorrect +=1
        if (abs(adir-gdir)<0.00001):
            stri2 = "TRUE"
        if (stri1 == "TRUE" and stri2 == "TRUE"):
            stri3 = "TRUE"
            totalCorrect+=1
        print "Test point ",current,"  Got: (pt:",pt," dir: ",gdir,")   Expected: (pt: ",apt," dir: ",adir,")   pt correct? ",stri1, "  dir correct? ", stri2, "   BOTH CORRECT: ",stri3
        if not i % 2==0:
            current+=1
            
            print
        else:
            if stri1 == "TRUE":
                straightcorr+=1
    print
    print
    print "Percent Points Correct: ",(float(numCorrect)/float(len(pts)))*100.0
    print "Percent Complete Correct: ",(float(totalCorrect)/float(len(pts)))*100.0
    print "Percent Straight Correct: ",(float(straightcorr)/float(len(pts)/2.0))*100.0
        
        










#def first():pt
#    D = np.array([[[-94.00, 92.00, -13.00],[-28.00, 81.00, -109.00],[75.00, 80.00, -34.00],[-8.00, 83.00, 66.00]], [[-80.00, 105.00, -12.00],[-11.00, 102.00, -98.00],[73.00, 89.00, -35.00],[-13.00, 87.00, 64.00]], [[-81.00, 90.00, -9.00],[-19.00, 90.00, -89.00],[66.00, 80.00, -34.00],[-15.00, 79.00, 62.00]]])
#    print D.shape
#    
#    x = np.array([[[-95.00, 90.00, -15.00],[-24.00, 82.00, -104.00],[68.00, 85.00, -40.00],[-18.00, 86.00, 65.00]]])
#    print x.shape
#    
#    rms = []
#    E = []
#    others = []
#    numDirec = np.size(D,1)
#    numLoc = np.size(D,0)
#    
#    for i in range(numDirec):  # Direction
#        rms=[]
#        for j in range(numLoc):  # Locations
#            rms.append(np.sqrt(abs(x[0][i][0]-D[j][i][0])**2.0 + abs(x[0][i][1]-D[j][i][1])**2.0 + abs(x[0][i][2]-D[j][i][2])**2.0))  # rms of direction, to each location
#        print "rms of direction ",rms
#        print
#        E.append(rms)
#          
#    print "E"
#    print E  # yerr[0] is rms to each location of direction 0
#    sum = 0
#    print 
#    print "RMS total to each location from sample location (x)"
#    rads = []
#    for i in range(numLoc):
#        sum = 0
#        for j in range(numDirec):
#            sum += E[j][i] 
#        rads.append(sum)
#    print rads
#
#
#def second():
#    D = np.array([[[-94.00, 92.00, -13.00],[-28.00, 81.00, -109.00],[75.00, 80.00, -34.00],[-8.00, 83.00, 66.00]], [[-80.00, 105.00, -12.00],[-11.00, 102.00, -98.00],[73.00, 89.00, -35.00],[-13.00, 87.00, 64.00]], [[-81.00, 90.00, -9.00],[-19.00, 90.00, -89.00],[66.00, 80.00, -34.00],[-15.00, 79.00, 62.00]]])
#    print D.shape
#    
#    x = np.array([[[-95.00, 90.00, -15.00],[-24.00, 82.00, -104.00],[68.00, 85.00, -40.00],[-18.00, 86.00, 65.00]]])
#    print x.shape
#    rms = []
#    E = []
#    others = []
#    numDirec = np.size(D,1)
#    numLoc = np.size(D,0)
#    
#    
#    for i in range(numLoc):  # Locations
#        rms = []
#        for j in range(numDirec): # Directions of test point
#            temp = []
#            for k in range(numDirec):  # Directions of D point
#                temp.append(np.sqrt(abs(x[0][j][0]-D[i][k][0])**2.0 + abs(x[0][j][1]-D[i][k][1])**2.0 + abs(x[0][j][1]-D[i][k][1])**2.0))
#            rms.append(temp)
#        
#        test = []
#        for h in range(len(rms)):
#            test.append([np.min(rms[h]), np.argmin(rms[h])])
#        print "test: ",test
#        
#        for h in range(len(test)):
#            print
#        print
#        print "rms:  ",rms
#        
#        print 



