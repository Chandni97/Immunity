﻿using System;
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
    public partial class Quarantine_Folder : Form
    {
        string fullFileName = "";
        string fileName = "";

        public Quarantine_Folder()
        {
            InitializeComponent();
            printFiles();
        }

        void printFiles()
        {
            string namestring = "";
            string typestring = "";
            StreamWriter f1 = new StreamWriter(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\QFile.txt");
            string[] filePaths = Directory.GetFiles(@"C:\Users\niluf\Desktop\Immunity\QuarantineFolder\");
            //string line = "\n";
            for(int j=0; j< filePaths.Length; j++)
            {
                string path = filePaths[j];
                f1.WriteLine(Path.GetFileName(path));
                f1.WriteLine(Path.GetExtension(path));
                //f1.Write(line);
            }
            f1.Close();

            StreamReader f2 = new StreamReader(@"C:\Users\niluf\Desktop\Immunity\ImmunityApp\QFile.txt");

            namestring = "";
            namestring = f2.ReadLine();
            typestring = "";
            typestring = f2.ReadLine();
            label3.Text = namestring;
            label13.Text = typestring;

            namestring = "";
            namestring = f2.ReadLine();
            typestring = "";
            typestring = f2.ReadLine();
            label5.Text = namestring;
            label12.Text = typestring;

            namestring = "";
            namestring = f2.ReadLine();
            typestring = "";
            typestring = f2.ReadLine();
            label6.Text = namestring;
            label11.Text = typestring;

            namestring = "";
            namestring = f2.ReadLine();
            typestring = "";
            typestring = f2.ReadLine();
            label7.Text = namestring;
            label10.Text = typestring;

            namestring = "";
            namestring = f2.ReadLine();
            typestring = "";
            typestring = f2.ReadLine();
            label8.Text = namestring;
            label9.Text = typestring;

            f2.Close();
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

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            this.button10.BackColor = Color.Transparent;
        }
        private void button10_MouseLeave(object sender, EventArgs e)
        {
            this.button10.BackColor = Color.Transparent;
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
            Quarantine_Folder Q2 = new Quarantine_Folder();
            Q2.ShowDialog();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H3 = new Home();
            H3.ShowDialog();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            UserGuide U5 = new UserGuide();
            U5.ShowDialog();
            this.Close();
        }
    }
}
