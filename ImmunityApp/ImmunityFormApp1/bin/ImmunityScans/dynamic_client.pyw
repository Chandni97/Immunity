import socket                   # Import socket module
import sys
import time

excep = 0
sent = False

while True:

    try:
        s = socket.socket()             # Create a socket object
        host = '35.245.228.177'     # Get local machine name
        port = 1000           # Reserve a port for your service.

        s.connect((host, port))
        #s.send("Hello server!")

        filename = sys.argv[1]
        f = open(filename, 'rb')
        l = f.read(1024)
        while(l):
            s.send(l)
            #print('Sent ', repr(l))
            l = f.read(1024)
        f.close()
        print('done sendinf file')
        s.close()
        s.close()
        print('connection closed')

        time.sleep(10)

        while True:
            ss = socket.socket()
            port = port  + 1
            ss.connect((host, port))
            data = ss.recv(1024)
            print(data)
            if 'no' in str(data):
                print("sending no")
                ss.close()
                time.sleep(10)
                continue
            elif '1234' in str(data):
                print("0000")
                s2 = open("C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\common\\dynErrorHandle.txt", "w+")
                s2.write("0000")
                s2.close()
                exit()
            else:
                with open('C:\\Users\\niluf\\Desktop\\Immunity\\ImmunityApp\\ImmunityFormApp1\\bin\\ImmunityScans\\received_file.json', 'wb') as f:
                    while True:
                        #print('receiving data...')
                        data = ss.recv(1024)
                        print('data=%s', (data))
                        if not data:
                            print('done')
                            break
                        f.write(data)
                    f.close()
                    ss.close()
                    exit()
                    break
                        # write data to a file
    except Exception as e:
        if(excep == 2):
            exit()
        excep = excep +1
        continue

