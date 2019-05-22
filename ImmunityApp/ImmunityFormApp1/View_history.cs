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
using System.IO;
using System.Drawing.Printing;

namespace ImmunityFormApp1
{
    public partial class View_history : Form
    {
        string fullFileName = "";
        string fileName = "";

        public View_history()
        {
            InitializeComponent();
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
            Home H5 = new Home();
            H5.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserGuide U6 = new UserGuide();
            U6.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H3 = new Home();
            H3.ShowDialog();
            this.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            button10.ForeColor = Color.Coral;
            button11.ForeColor = Color.WhiteSmoke;

            textBox1.Visible = false;
            string StaticReport = "";
            string line = "";
            StreamReader f1 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\StaticAnalysisHistory.txt");
            while (!f1.EndOfStream)
            {
                line = f1.ReadLine();
                StaticReport += "File Name: ";
                line = f1.ReadLine();
                StaticReport += line;
                StaticReport += Environment.NewLine;

                line = f1.ReadLine();
                StaticReport += "Full File Name: ";
                line = f1.ReadLine();
                StaticReport += line;
                StaticReport += Environment.NewLine;

                line = f1.ReadLine();
                StaticReport += "Result: ";
                line = f1.ReadLine();
                StaticReport += line;
                StaticReport += Environment.NewLine;

                line = f1.ReadLine();
                line = f1.ReadLine();
                if (line != "NULL")
                {
                    StaticReport += "Confidence Level: ";
                    StaticReport += line;
                    StaticReport += Environment.NewLine;
                }
                StaticReport += "---------------------------------------------------------------------------------";
                StaticReport += Environment.NewLine;
                StaticReport += Environment.NewLine;
            }
            f1.Close();
            textBox1.Text = StaticReport;
            textBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Folder Q1 = new Quarantine_Folder();
            Q1.ShowDialog();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            UserGuide U5 = new UserGuide();
            U5.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.ForeColor = Color.Coral;
            button10.ForeColor = Color.WhiteSmoke;

            textBox1.Visible = false;
            string DynamicReport = "";
            string line = "";
            StreamReader f1 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\ImmunityFormApp1\bin\DynamicAnalysisHistory.txt");
            while (!f1.EndOfStream)
            {
                line = f1.ReadLine();
                DynamicReport += "File Name: ";
                line = f1.ReadLine();
                DynamicReport += line;
                DynamicReport += Environment.NewLine;

                line = f1.ReadLine();
                DynamicReport += "Full File Name: ";
                line = f1.ReadLine();
                DynamicReport += line;
                DynamicReport += Environment.NewLine;

                line = f1.ReadLine();
                DynamicReport += "Result: ";
                line = f1.ReadLine();
                DynamicReport += line;
                DynamicReport += Environment.NewLine;

                line = f1.ReadLine();
                line = f1.ReadLine();
                if (line != "NULL")
                {
                    DynamicReport += "Confidence Level: ";
                    DynamicReport += line;
                    DynamicReport += Environment.NewLine;
                }
                DynamicReport += "---------------------------------------------------------------------------------";
                DynamicReport += Environment.NewLine;
                DynamicReport += Environment.NewLine;
            }
            f1.Close();
            textBox1.Text = DynamicReport;
            textBox1.Visible = true;
        }
    }
}
