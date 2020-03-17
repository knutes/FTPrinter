using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawPrint;

namespace FTPrinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    string host = "localhost";
        //    string userID = "admin";
        //    string password = "MNCadmin@%!$$*$";

        //    bool checkDir = IsItReal("ftp://localhost/printed%20tests");

        //    if (checkDir)
        //    {
        //        this.isRealLabel.Text = "Test folder exists!";
        //    }
        //    else
        //    {
        //        this.isRealLabel.Text = "Test folder DNE";
        //    }
        //    this.isRealLabel.Visible = true;
        //}


        //private void ListFilesButton_Click(object sender, EventArgs e)
        //{
        //    List<string> filesFound = ListAllFiles("ftp://localhost/test", "admin", "MNCadmin@%!$$*$");
        //    if (filesFound.Count > 0)
        //    {
        //        foreach (string file in filesFound)
        //        {
        //            Console.WriteLine(file);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No files found");
        //    }
        //}


        public bool IsItReal(string dirPath)
        {
            bool isReal = false;
            string host = "localhost";
            string userID = "admin";
            string password = "MNCadmin@%!$$*$";

            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(dirPath);
                req.Credentials = new NetworkCredential(userID, password);
                // method gets/sends command to ftp server
                req.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse res = (FtpWebResponse)req.GetResponse())
                {
                    isReal = true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse res = (FtpWebResponse)ex.Response;
                    if (res.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return isReal;
        }

        //private void DeleteFileButton_Click(object sender, EventArgs e)
        //{
        //    // this all works :) uWu ggez no re nerds
        //    string fileToDelete = "ftp://localhost/test/" + this.fileToDeleteTextBox.Text; // "test.pdf"
        //    DeleteFile(fileToDelete, "admin", "MNCadmin@%!$$*$");
        //    MessageBox.Show("File Deleted :^)");
        //}

        public static void DeleteFile(string path, string userID, string password)
        {
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(path);
                req.Method = WebRequestMethods.Ftp.DeleteFile;
                req.Credentials = new System.Net.NetworkCredential(userID, password);
                req.GetResponse().Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPrinter.Items.Insert(0, "--Select Printer--");

            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[]
            { EnumeratedPrintQueueTypes.Shared, EnumeratedPrintQueueTypes.Connections });
            foreach (var item in queues)
            {
                cmbPrinter.Items.Add(item.FullName);
            }
            queues = server.GetPrintQueues(new[]
            { EnumeratedPrintQueueTypes.Local });
            foreach (var item in queues)
            {
                cmbPrinter.Items.Add(item.FullName);

            }

        }

        private void PrintFromFolder_Click(object sender, EventArgs e)
        {
            // path to file downloaded from ftp server
            string filePath = @"C:\Temp\temptest.pdf";

            string printerName = cmbPrinter.SelectedItem.ToString();

            try
            {
                IPrinter printer = new Printer();
                printer.PrintRawFile(printerName, filePath, "temptest.pdf");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //create filepath to hold dl'd files, if it exists, it will do nothing
            DirectoryInfo di = Directory.CreateDirectory(@"c:\Temp");

            string tempFilePath = @"C:\Temp\temptest.pdf";
            string ftpPath = "ftp://localhost/test/";
            string userID = this.usernameTxtBox.Text;
            string password = this.passwordTxtBox.Text;

            //get files in ftp server
            List<string> filesFound = ListAllFiles("ftp://localhost/test", userID, password);
            if (filesFound.Count > 0)
            {
                ftpPath += filesFound[0];
                foreach (string file in filesFound)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("No files found");
            }

            // download to Temp folder
            using (WebClient req = new WebClient())
            {

                req.Credentials = new NetworkCredential(userID, password);
                byte[] fileData = req.DownloadData(ftpPath);

                using (FileStream file = File.Create(tempFilePath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                MessageBox.Show("Download Successful");
            }

            // print file 
            string printerName = cmbPrinter.SelectedItem.ToString();
            try
            {
                IPrinter printer = new Printer();
                printer.PrintRawFile(printerName, tempFilePath, "temptest.pdf");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Delete file we just printed uWu
            DeleteFile(ftpPath, userID, password);
            MessageBox.Show("File Deleted :^)");
        }

        private List<string> ListAllFiles(string path, string userID, string password)
        {
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(path);
                req.Credentials = new NetworkCredential(userID, password);
                req.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse res = (FtpWebResponse)req.GetResponse();
                StreamReader strRead = new StreamReader(res.GetResponseStream());

                List<string> dirs = new List<string>();

                string line = strRead.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var lineArr = line.Split('/');
                    line = lineArr[lineArr.Count() - 1];
                    dirs.Add(line);
                    line = strRead.ReadLine();
                }

                strRead.Close();

                return dirs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
