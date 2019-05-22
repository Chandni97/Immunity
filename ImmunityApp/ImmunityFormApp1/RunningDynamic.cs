using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ImmunityFormApp1
{
    public partial class RunningDynamic : Form
    {
        string fullFileName = "";
        string fileName = "";
        float ranDynLevel = 100;

        public RunningDynamic()
        {
            InitializeComponent();
            pictureBox3.Visible = false;
        }

        public void getLabel5text(string fileName1, string fullFName)
        {
            label5.Text = fileName1;
            fullFileName += fullFName;
            fileName += fileName1;
        }
       
        private void label1_Click(object sender, EventArgs e)
        {
          
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
            int button16X = button16.Location.X;
            int button16Y = button16.Location.Y;

            if (flag == 0)
            {
                int panel1pointX2 = panel1pointX + 140;
                int panel2pointX2 = panel2pointX + 140;
                int button7x2 = button7X - 140;
                int button16x2 = button16X - 140;
                button7.Location = new Point(button7x2, button7Y);
                button16.Location = new Point(button16x2, button16Y);
                panel1.Location = new Point(panel1pointX2, panel1pointY);
                panel2.Location = new Point(panel2pointX2, panel2pointY);
                flag = 1;
            }
            else
            {
                int panel1pointX3 = panel1pointX - 140;
                int panel2pointX3 = panel2pointX - 140;
                int button7x3 = button7X + 140;
                int button16x3 = button16X + 140;
                button7.Location = new Point(button7x3, button7Y);
                button16.Location = new Point(button16x3, button16Y);
                panel1.Location = new Point(panel1pointX3, panel1pointY);
                panel2.Location = new Point(panel2pointX3, panel2pointY);
                flag = 0;
            }
        }

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserGuide U5 = new UserGuide();
            U5.ShowDialog();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H4 = new Home();
            H4.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_history V6 = new View_history();
            V6.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H7 = new Home();
            H7.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fullFileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Folder Q1 = new Quarantine_Folder();
            Q1.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button9.Visible = false;

            ThreadStart threadStart = new ThreadStart(scanGif);
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            ThreadStart threadStart1 = new ThreadStart(scanS);
            Thread thread1 = new Thread(threadStart1);
            thread1.SetApartmentState(ApartmentState.STA);
            thread1.Start();
        }

        void scanS()
        {
            run_cmd();
        }

        void scanGif()
        {
            pictureBox3.Visible = true;
            while (true)
            {
                pictureBox3.Refresh();
            }
        }

        public void dynresults()
        {
            if (ranDynLevel == 0) // is benign
            {
                Safe_file F1 = new Safe_file();
                F1.getLabel5text(fileName, fullFileName);
                this.Hide();
                F1.ShowDialog();
                this.Close();
                recordDynScanSafe(fileName, fullFileName);
                //goto finish;
            }
            if (ranDynLevel == 100) // is a ransomware
            {
                ThreadStart threadStart6 = new ThreadStart(quarantineFile);
                Thread thread6 = new Thread(threadStart6);
                thread6.SetApartmentState(ApartmentState.STA);
                thread6.Start();

                Malware_detected M1 = new Malware_detected();
                M1.getLabel5text(fileName, fullFileName);
                M1.enablePictureBox6();
                this.Hide();
                M1.ShowDialog();
                this.Close();
                recordDynScanMalware(fileName, fullFileName);
                //goto finish;
            }
        }

        public void quarantineFile()
        {
            string destinationFolder = @"C:\Users\niluf\Desktop\Immunity\QuarantineFolder\";
            string destinationFile = Path.Combine(destinationFolder + fileName);

            if (File.Exists(fullFileName))
            {
                File.Move(fullFileName, destinationFile);
            }
        }

        void run_cmd()
        {
            ProcessStartInfo dynamicClient = new ProcessStartInfo();
            dynamicClient.FileName = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\venv\Scripts\pythonw.exe";//cmd is full path to python.exe
            dynamicClient.Arguments = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\dynamic_client.pyw" + " " + fullFileName;//args is path to .py file and any cmd line args
            dynamicClient.UseShellExecute = false;
            dynamicClient.RedirectStandardOutput = true;
            using (Process process = Process.Start(dynamicClient))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                    //ranStatLevel = Convert.ToSingle(result);
                }
            }

            StreamReader f3 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\dynErrorHandle.txt");
            string ehD = "";
            ehD = f3.ReadLine();
            f3.Close();

            if(ehD == "0000")
            {
                MessageBox.Show("Looks like it needs more Time! Please Try again later..");
                Home h = new Home();
                this.Hide();
                h.ShowDialog();
                this.Close();
            }
            else
            {
                ProcessStartInfo ranDyn = new ProcessStartInfo();
                ranDyn.FileName = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\venv\Scripts\pythonw.exe";//cmd is full path to python.exe
                ranDyn.Arguments = @"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\ransomwareDynamic.pyw";//args is path to .py file and any cmd line args
                ranDyn.UseShellExecute = false;
                ranDyn.RedirectStandardOutput = true;
                using (Process process = Process.Start(ranDyn))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                        //ranDynLevel = Convert.ToSingle(result);
                    }
                }

                StreamReader f2 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\ranDynLevel.txt");
                string ranD = "";
                ranD = f2.ReadLine();
                f2.Close();

                StreamWriter truncFile = File.CreateText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\common\ranDynLevel.txt");
                truncFile.Flush();
                truncFile.Close();

                StreamWriter truncFile1 = File.CreateText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\ImmunityScans\received_file.json");
                truncFile1.Flush();
                truncFile1.Close();

                if (ranD == "0000")
                {
                    MessageBox.Show("Something went wrong...try again.");
                    Home H = new Home();
                    this.Hide();
                    H.ShowDialog();
                    this.Close();
                }
                else
                {
                    ranDynLevel = float.Parse(ranD);
                    Console.WriteLine("ranDynlevel:");
                    Console.WriteLine(ranD);

                    dynresults();
                }
            }     
        }

        void recordDynScanSafe(string fileName, string fullFileName)
        {
            StreamWriter f1 = File.AppendText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\DynamicAnalysisHistory.txt");
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

        void recordDynScanMalware(string fileName, string fullFileName)
        {
            StreamWriter f2 = File.AppendText(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\DynamicAnalysisHistory.txt");
            f2.WriteLine("File Name: ");
            f2.WriteLine(fileName);
            f2.WriteLine("Full File Name: ");
            f2.WriteLine(fullFileName);
            f2.WriteLine("Result: ");
            f2.WriteLine("Dangerous File - Ransomware");
            f2.WriteLine("Confidence Level: ");
            f2.WriteLine("NULL");
           
            f2.Close();
        }
    }
}
