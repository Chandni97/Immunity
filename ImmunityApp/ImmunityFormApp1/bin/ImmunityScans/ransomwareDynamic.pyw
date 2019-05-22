import sys
import json
import joblib
import os
import numpy

input_file = "C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\ImmunityScans\\received_file.json"
#olumn_file = sys.argv[2]


def searchForFeature(data, f):
   index = 0
   for d in data:
       if(d==f):
           return index
       index = index + 1
   return -1



try:
    data1 = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\columns.txt", "r").readlines()
    print(len(data1))
    index = 0

    for d in data1:
        data1[index] = d[:-1]
        index = index + 1

    #print(data1)

    all_data_set = set(data1)

    features = []
    results = [0] * len(data1)

    utf8 = str("utf-8")

    with open(input_file, "r") as read_file:
        summary = json.load(read_file)
        for key in summary.keys():
            for value in summary[key]:
                if(isinstance(value,list)):
                    for v in value:
                        #features.append(key.encode("utf-8".encode('ascii')) + ":" + v.encode("utf-8".encode('ascii')))
                        features.append(key.encode("utf-8") + b":" + v.encode("utf-8"))
                else:
                    features.append(key.encode("utf-8") + b":" + value.encode("utf-8"))

        for f in features:
            index1 = -1
            if(f.decode("utf-8") in all_data_set):
                index1 = searchForFeature(data1, f.decode("utf-8"))
                if(index1 != -1):
                    results[index1] = 1
                else:
                    print(f)
                    print("error")


    #results stored in a list called results

    # f = open("resultsDynamic.csv","w")
    # for res in results:
    #     f.write(str(res) + ',')
    # f.close()
    #
    # f = open("resultsDynamicfeatures.txt","w")
    # for f1 in features:
    #     f.write(f1.decode("utf-8") + '\n')
    # f.close()



    #exit(1)

    #f = open("featuresDynamic.txt","w+")
    # for f in features:
    #     print(f)
    #f.close()


    #print(results)
    # print('Running the model SVM....')
    # clf1 = joblib.load('svm-dynamic.pkl')
    # res = clf1.decision_function([results])[0]
    # #print("% benign: ", res[0]*100)
    # #print("% ransomware: ", res[1]*100)
    # print(res*100)
    #res1 = clf1.predict([results])[0]
    #print(res1)

    # print('Running the model RF....')
    # clf2 = joblib.load('rf-dynamic.pkl')
    # res2 = clf2.predict_proba([results])[0]
    # print("% benign: ", res2[0]*100)
    # print("% : ", res2[1]*100)
    # #res2 = clf1.predict([results])[0]
    # #print(res2)

    print('Running the model NB....')
    clf2 = joblib.load('C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\nb-dynamic.pkl')     # THISIS THE FINAL CHOSEN MODEL
    res2 = clf2.predict_proba([results])[0]
    print(res2[1]*100)
    ranDynLevel = res2[1]*100
    s = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\ranDynLevel.txt", "w+")

    s.write("%f" % ranDynLevel)
    s.close()

    #res2 = clf1.predict([results])[0]
    #print(res2)

    #print('Running the model GTB....')
    #clf3 = joblib.load('gtb-dynamic.pkl')
    #res3 = clf3.predict_proba([results])[0]
    #print("% benign: ", res3[0]*100)
    #print("% : ", res3[1]*100)
    #res3 = clf1.predict([results])[0]
    #print(res3)

    # print('Running the model LR....')
    # clf4 = joblib.load('lb-dynamic.pkl')
    # res4 = clf4.predict_proba([results])[0]
    # print("% benign: ", res4[0]*100)
    # print("% : ", res4[1]*100)
    # #res4 = clf1.predict([results])[0]
    # #print(res4)
    #
    # print('Running the model RF+NB....')
    # clf4 = joblib.load('rfnb-dynamic.pkl')
    # res4 = clf4.predict_proba([results])[0]
    # print("% benign: ", res4[0]*100)
    # print("% : ", res4[1]*100)
    #res4 = clf1.predict([results])[0]
    #print(res4)
except Exception as e:
    s = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\ranDynLevel.txt", "w+")
    print(e)
    errorValue = 0000
    print(errorValue);
    s.write("0000")
    s.close()
    os._exit(1)
