using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImmunityFormApp1
{
    public partial class StaticScan : Form
    {
        string fullFileName = "";
        string fileName = "";
        float ranStatLevel = 100;
        float spyStatLevel = 100;
        float errorHandlingValue;
        int flag2 = 0;

        //public Thread SG;

        public StaticScan()
        {
            InitializeComponent();
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void getFileName(string fileName1, string fullFileName1)
        {
            fullFileName = fullFileName1;
            fileName = fileName1;
            label4.Text = fullFileName;
            //scan();
        }

        int flag = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            int panel1pointX = panel1.Location.X;
            int panel1pointY = panel1.Location.Y;
            int panel2pointX = panel2.Location.X;
            int panel2pointY = panel2.Location.Y;
            int button7X = button7.Location.X;
            int button7Y = button7.Location.Y;
            int button8X = button8.Location.X;
            int button8Y = button8.Location.Y;

            if (flag == 0)
            {
                int panel1pointX2 = panel1pointX + 140;
                int panel2pointX2 = panel2pointX + 140;
                int button7x2 = button7X - 140;
                int button8x2 = button8X - 140;
                button7.Location = new Point(button7x2, button7Y);
                button8.Location = new Point(button8x2, button8Y);
                panel1.Location = new Point(panel1pointX2, panel1pointY);
                panel2.Location = new Point(panel2pointX2, panel2pointY);
                flag = 1;
            }
            else
            {
                int panel1pointX3 = panel1pointX - 140;
                int panel2pointX3 = panel2pointX - 140;
                int button7x3 = button7X + 140;
                int button8x3 = button8X + 140;
                button7.Location = new Point(button7x3, button7Y);
                button8.Location = new Point(button8x3, button8Y);
                panel1.Location = new Point(panel1pointX3, panel1pointY);
                panel2.Location = new Point(panel2pointX3, panel2pointY);
                flag = 0;
            }
        }
        //Close Window:
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //side menu mouse hover colors
        private void button1_MouseEnter(object sender, EventArgs e){
            this.button1.BackColor = ColorTranslator.FromHtml("#000000");}
        private void button1_MouseLeave(object sender, EventArgs e){
            this.button1.BackColor = Color.Transparent;}
        private void button2_MouseEnter(object sender, EventArgs e){
            this.button2.BackColor = ColorTranslator.FromHtml("#000000");}
        private void button2_MouseLeave(object sender, EventArgs e){
            this.button2.BackColor = Color.Transparent;}
        private void button3_MouseEnter(object sender, EventArgs e){
            this.button3.BackColor = ColorTranslator.FromHtml("#000000");}
        private void button3_MouseLeave(object sender, EventArgs e){
            this.button3.BackColor = Color.Transparent;}
        private void button4_MouseEnter(object sender, EventArgs e){
            this.button4.BackColor = ColorTranslator.FromHtml("#000000");}
        private void button4_MouseLeave(object sender, EventArgs e){
            this.button4.BackColor = Color.Transparent;}

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            this.button9.BackColor = Color.Transparent;
        }
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            this.button9.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H1 = new Home();
            H1.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fullFileName = file1.FileName;
                getFileName();
            }

            checkUPX();
        }

        public void checkUPX()
        {
            Process checkupx;
            //string ofile = @"D:\Immunity\ImmunityApp\ImmunityFormApp1\bin\upx\upxresults.txt";
            try
            {
                checkupx = new Process();
                // set start info
                checkupx.StartInfo = new ProcessStartInfo(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\upx\cmd.exe")
                {
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    WorkingDirectory = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\upx\"
                };
                checkupx.StartInfo.CreateNoWindow = true;
                // start process
                checkupx.Start();
                // send command to its input
                checkupx.StandardInput.Write("upx.exe -t " + fullFileName + " > upxresults.txt" + checkupx.StandardInput.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            StaticScan S1 = new StaticScan();
            this.Hide();
            S1.getFileName(fileName, fullFileName);
            S1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_history V3 = new View_history();
            V3.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H3 = new Home();
            H3.ShowDialog();
            this.Close();
        }

        public void getFileName()
        {
            string reversedFileName = "";
            int length = fullFileName.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (fullFileName[i] != '\\')
                {
                    reversedFileName += fullFileName[i];
                }
                else
                {
                    goto done;
                }
            }
        done:
            length = reversedFileName.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                fileName += reversedFileName[i];
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(fullFileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fullFileName = file1.FileName;
                getFileName();
                label4.Text = fullFileName;
            }
        }

        public void button10_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            button9.Visible = false;

            ThreadStart threadStart = new ThreadStart(scanGif);
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            ThreadStart threadStart1 = new ThreadStart(scanS);
            Thread thread1= new Thread(threadStart1);
            thread1.SetApartmentState(ApartmentState.STA);
            thread1.Start();  
        }

        void scanS()
        {
            upxresults();
            if (flag2 != 1)
                scan();
        }

        void scanGif()
        {
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            while(true)
            {
                pictureBox3.Refresh();
                pictureBox4.Refresh();
            }
        }

        public void upxresults()
        {
            StreamReader ofileread = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\upx\upxresults.txt");
            string upx = "";
            while (!ofileread.EndOfStream)
            {
                upx = ofileread.ReadLine();
            }
            Console.WriteLine("upx result1: " + upx);
            ofileread.Close();

            StreamWriter truncFile = File.CreateText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\upx\upxresults.txt");
            truncFile.Flush();
            truncFile.Close();

            if (upx == "Tested 1 file.")
            {
                flag2 = 1;
                RunningDynamic D1 = new RunningDynamic();
                D1.getLabel5text(fileName, fullFileName);
                this.Hide();
                D1.ShowDialog();
                this.Close();
            }
        }

        public void scan()
        {
            StreamWriter f3 = new StreamWriter(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\LastScanDateTime.txt");
            f3.WriteLine(DateTime.Today.ToString("dd-MM-yyyy"));
            f3.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            f3.Close();

            run_cmd();
        }

        void run_cmd()
        {
            //@"..\ImmunityScans\venv\Scripts\python.exe"
            //@"..\Python37\python.exe"

            //checkUPX();

            ProcessStartInfo ranStat = new ProcessStartInfo();
            ranStat.FileName = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\venv\Scripts\pythonw.exe";//cmd is full path to python.exe
            ranStat.Arguments = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\ransomwareStatic.pyw" + " " + fullFileName;//args is path to .py file and any cmd line args
            ranStat.UseShellExecute = false;
            ranStat.RedirectStandardOutput = true;
            using (Process process = Process.Start(ranStat))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }

            StreamReader f1 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\ranStatLevel.txt");
            string ranS = "";
            ranS = f1.ReadLine();
            f1.Close();

            StreamWriter truncFile = File.CreateText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\ranStatLevel.txt");
            truncFile.Flush();
            truncFile.Close();

            if (ranS == "0000" || ranS == "5555")
            {
                Console.WriteLine("ERROR");
            }
            else if (ranS == "1111")
            {
                MessageBox.Show("File not Supported");
                this.Hide();
                Home H3 = new Home();
                H3.ShowDialog();
                this.Close();
                this.Dispose();
            }
            ranStatLevel = float.Parse(ranS);
            Console.WriteLine("ranStatLevel:");
            Console.WriteLine(ranS);

            ProcessStartInfo spyStat = new ProcessStartInfo();
            spyStat.FileName = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\venv\Scripts\pythonw.exe";//cmd is full path to python.exe
            spyStat.Arguments = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\spywareStatic.pyw" + " " + fullFileName;//args is path to .py file and any cmd line args
            spyStat.UseShellExecute = false;
            spyStat.RedirectStandardOutput = true;
            using (Process process = Process.Start(spyStat))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }

            StreamReader f2 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\spyStatLevel.txt");
            string spyS = "";
            spyS = f2.ReadLine();
            f2.Close();

            StreamWriter truncFile2 = File.CreateText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\spyStatLevel.txt");
            truncFile2.Flush();
            truncFile2.Close();

            if (spyS == "0000" || spyS == "5555")
            {
                MessageBox.Show("error from spyware ML");
            }
            if (spyS == "1111")
            {
                MessageBox.Show("File not Supported");
                this.Hide();
                Home H3 = new Home();
                H3.ShowDialog();
                this.Close();
            }
            spyStatLevel = float.Parse(spyS);
            Console.WriteLine("spystatlevel:");
            Console.WriteLine(spyS);
            
            mlresults();    
        }
        
        // ML RESULTS--------------------------------------------------------------------------
        public void mlresults()
        {
            if (ranStatLevel < 30.0 && spyStatLevel < 45) // is benign
            {
                Safe_file F1 = new Safe_file();
                F1.getLabel5text(fileName, fullFileName);
                this.Hide();
                F1.ShowDialog();
                this.Close();
                recordStatScanSafe(fileName, fullFileName);
                goto finish;
            }
            if (ranStatLevel >= 60.0) // is a ransomware
            {
                ThreadStart threadStart10 = new ThreadStart(quarantineFile);
                Thread thread10 = new Thread(threadStart10);
                thread10.SetApartmentState(ApartmentState.STA);
                thread10.Start();

                Malware_detected M1 = new Malware_detected();
                M1.getLabel5text(fileName, fullFileName);
                M1.enablePictureBox6();
                this.Hide();
                M1.ShowDialog();
                this.Close();
                recordStatScanMalware(fileName, fullFileName, 1); //ransomare is type "1"
                goto finish;
            }
            if (spyStatLevel >= 80.0) // is a spyware
            {
                ThreadStart threadStart11 = new ThreadStart(quarantineFile);
                Thread thread11 = new Thread(threadStart11);
                thread11.SetApartmentState(ApartmentState.STA);
                thread11.Start();

                Malware_detected M2 = new Malware_detected();
                M2.getLabel5text(fileName, fullFileName);
                M2.enablePictureBox7();
                this.Hide();
                M2.ShowDialog();
                this.Close();
                recordStatScanMalware(fileName, fullFileName, 2); //spyware is type "2"
                goto finish;
            }
            if (ranStatLevel >= 30.0 && ranStatLevel < 60.0 || spyStatLevel >= 45.0 && spyStatLevel < 80.0) // run dynamic for both
            {
                RunningDynamic D1 = new RunningDynamic();
                D1.getLabel5text(fileName, fullFileName);
                this.Hide();
                D1.ShowDialog();
                this.Close();
                goto finish;
            }
        finish:;
        }

       
        public void quarantineFile()
        {
            string destinationFolder = @"C:\Users\niluf\Desktop\Immunity\QuarantineFolder\";
            string destinationFile = Path.Combine(destinationFolder + fileName);

            if (File.Exists(fullFileName))
            {
                Console.WriteLine("moved");
                File.Move(fullFileName, destinationFile);
            }
        }

        public void deleteFile(string fullFileName)
        {
            if (File.Exists(fullFileName))
            {
                try
                {
                    File.Delete(fullFileName);
                    MessageBox.Show("File Deleted!");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        void recordStatScanSafe(string fileName, string fullFileName)
        {
            StreamWriter f1 = File.AppendText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\StaticAnalysisHistory.txt");
            f1.WriteLine("File Name: ");
            f1.WriteLine(fileName);
            f1.WriteLine("Full File Name: ");
            f1.WriteLine(fullFileName);
            f1.WriteLine("Result: ");
            f1.WriteLine("Safe");
            f1.WriteLine("Confidence Level: ");
            f1.WriteLine("NULL");
            f1.Close();
        }

        void recordStatScanMalware(string fileName, string fullFileName, int type)
        {
            StreamWriter f2 = File.AppendText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\StaticAnalysisHistory.txt");
            f2.WriteLine("File Name: ");
            f2.WriteLine(fileName);
            f2.WriteLine("Full File Name: ");
            f2.WriteLine(fullFileName);
            f2.WriteLine("Result: ");
            if (type == 1)
            {
                f2.WriteLine("Dangerous File - Ransomware");
                f2.WriteLine("Confidence Level: ");
                f2.WriteLine(ranStatLevel);
            }
            if (type == 2)
            {
                f2.WriteLine("Dangerous File - Spyware");
                f2.WriteLine("Confidence Level: ");
                f2.WriteLine(spyStatLevel);
            }
            if (type == 3)
            {
                f2.WriteLine("Dangerous File - other Malware");
            }
            f2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Folder Q1 = new Quarantine_Folder();
            Q1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserGuide U5 = new UserGuide();
            U5.ShowDialog();
            this.Close();
        }
        
    }
}
