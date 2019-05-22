import string
import sys
import os
import sklearn
import joblib
import pefile
import time
from threading import Thread
# import pickle
# import numpy
from bisect import bisect_left

def binary_search(a, x, lo=0, hi=None):
    hi = hi if hi is not None else len(a)  # hi defaults to len(a)
    pos = bisect_left(a, x, lo, hi)  # find insertion position
    if (pos != hi) and (a[pos] == x):
        return pos
    else:
        return -1  # don't walk off the end


def strings(filename, minimum=4):
    with open(filename, errors="ignore") as f:  # Python 3.x
        # with open(filename, "rb") as f:           # Python 2.x
        result = ""
        for c in f.read():
            if c in string.printable:
                result += c
                continue
            if len(result) >= minimum:
                yield result
            result = ""
        if len(result) >= minimum:  # catch result at EOF
            yield result

def main_function():
    try:
        # folder = sys.argv[1]
        file = sys.argv[1]
        # outputFile = open('C:/Users/amith/ImmunityScans1/StackRanRfANDANNStack.csv', 'w')

        f = open('C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\columnNamesStringsSpyware.txt')
        allStrings = f.readlines()

        for i in range(0, len(allStrings)):
            allStrings[i] = allStrings[i][:-1]

        f = open('C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\columnNamesApisSpyware.txt', 'r')
        allAPIs = f.readlines()

        for i in range(0, len(allAPIs)):
            allAPIs[i] = allAPIs[i][:-1]

        sampleFile = []
        for s in strings(file):
            sampleFile.append(s)
        found = False
        index = 0
        results = []
        for i in range(0, len(allStrings)):
            results.append(0)
        for str1 in sampleFile:
            c = ''.join(e for e in str1 if e.isalnum())
            if len(c) > 3:
                if c in allStrings:
                    index = -1
                    found = False
                    for str2 in allStrings:
                        index = index + 1
                        if c == str2:
                            results[index] = 1
                            found = True
                            break
        results2 = []
        for i in range(0, len(allAPIs)):
            results2.append(0)

        apiCalls = []

        try:
            pe = pefile.PE(file)
        except Exception as a:
            print('1111')
            s = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\spyStatLevel.txt", "w+")
            s.write("1111")
            s.close()
            os._exit(1)

        if hasattr(pe, "DIRECTORY_ENTRY_IMPORT"):
            for entry in pe.DIRECTORY_ENTRY_IMPORT:
                for imp in entry.imports:
                    api = str(imp.name)[2:-1]
                    apiCalls.append(api)
        else:
            print(00)

        for a in apiCalls:
            if a in allAPIs:
                index = -1
                # apiFoundFile.write(a.split()[1] + '\n')
                for a2 in allAPIs:
                    index = index + 1
                    if a == a2:
                        results2[index] = 1
                        break

        stringresults = results.copy()
        results.extend(results2)

        clf = joblib.load('C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\svm-ann-static-spyware.pkl')
        annmodel = clf.predict_proba([results])[0]
        spyStatLevel = annmodel[1] * 100  # prints result using the svm and ann model

        s2 = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\spyStatLevel.txt", "w+")
        print(spyStatLevel)
        s2.write("%f" % spyStatLevel)
        s2.close()
        os._exit(1)


    except Exception as e:
        s2 = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\spyStatLevel.txt", "w+")
        errorValue = 0000
        print(errorValue)
        s2.write("0000")
        s2.close()
        os._exit(1)

t = Thread(target=main_function)
t.daemon = True
t.start()
time.sleep(130)
s = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\spyStatLevel.txt", "w+")
errorValue = 0000
print(errorValue);
s.write("5555")
s.close()
exit()