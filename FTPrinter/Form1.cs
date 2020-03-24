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

        // verify ftp connection 
        public bool IsItReal(string dirPath)
        {
            bool isReal = false;
            string host = this.addressTxtBox.Text;
            string userID = this.usernameTxtBox.Text;
            string password = this.passwordTxtBox.Text;

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
            Form form1 = new Form();
            form1.FormBorderStyle = FormBorderStyle.FixedSingle;
            form1.MaximizeBox = false;
            form1.MinimizeBox = false;

            this.portTxtBox.Text = "21";
            this.maskTxtBox.Text = ".pdf";
            this.intervalTxtBox.Text = "5";
            this.deleteCheckBox.Checked = true;


            // find default printer
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinter = settings.PrinterName;
            this.cmbPrinter.Text = defaultPrinter;
            Console.WriteLine(defaultPrinter);

            var server = new PrintServer();

            var queues = server.GetPrintQueues(new[]
            { EnumeratedPrintQueueTypes.Shared, EnumeratedPrintQueueTypes.Connections });

            foreach (var item in queues)
            {
                cmbPrinter.Items.Add(item.FullName);
            }

            queues = server.GetPrintQueues(new[]{ EnumeratedPrintQueueTypes.Local });

            foreach (var item in queues)
            {
                cmbPrinter.Items.Add(item.FullName);
            }

            // Get command line arguments and put them in form
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                //MessageBox.Show("address = " + args[2]);
                //MessageBox.Show("folder = " + args[4]);
                //MessageBox.Show("username = " + args[6]);
                //MessageBox.Show("password = " + args[8]);
                //MessageBox.Show("printer = " + args[10]);
                //MessageBox.Show("start = " + args[11]);
                //MessageBox.Show("quiet = " + args[12]);

                this.addressTxtBox.Text = args[2];
                this.folderTxtBox.Text = args[4];
                this.usernameTxtBox.Text = args[6];
                this.passwordTxtBox.Text = args[8];
                this.cmbPrinter.SelectedItem = args[10];

                if (args[12] == "-quiet")
                {
                    MessageBox.Show(args[12]);
                    this.WindowState = FormWindowState.Minimized;
                    
                }
                if (FormWindowState.Minimized == WindowState)
                {
                    Hide();
                }

                if (args[11] == "-start")
                {
                    //StartButton_Click(sender, e);
                    MessageBox.Show("this should have started");
                }
                //foreach (string a in args)
                //{
                //    MessageBox.Show("command line arg - " + a);
                //}
            }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // exception handling
            if (this.addressTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the FTP address.");
            }
            else if (this.folderTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the FTP hot folder.");
            }
            else if (this.portTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the port number, default is 21.");
            }
            else if (this.usernameTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the FTP username.");
            }
            else if (this.passwordTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the FTP password.");
            }
            else if (this.maskTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the file type mask, default is .pdf");
            }
            else if (this.cmbPrinter.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select a printer.");
            }
            else if (this.intervalTxtBox.Text == "")
            {
                MessageBox.Show("Please enter a time interval, default is 5 minutes.");
            }
            else
            {

                // change icons to show program is running
                this.Icon = new System.Drawing.Icon("green.ico");
                this.notifyIcon1.Icon = new System.Drawing.Icon("green.ico");

                // timer for recursive calls every n interval
                if (this.intervalTxtBox.Text != "")
                {
                    double interval = Double.Parse(this.intervalTxtBox.Text);
                    System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromMinutes(interval).TotalMilliseconds);
                    timer.AutoReset = true;
                    timer.Elapsed += new System.Timers.ElapsedEventHandler(StartButton_Click);
                    timer.Start();
                }

                //create filepath to hold dl'd files, if it exists, this will do nothing
                DirectoryInfo di = Directory.CreateDirectory(@"c:\Temp");

                string tempFilePath = @"C:\Temp\temptest" + this.maskTxtBox.Text;
                string addy = this.addressTxtBox.Text;
                string path = this.folderTxtBox.Text;
                string ftpPath = "ftp://" + addy + "/" + path + "/";
                string userID = this.usernameTxtBox.Text;
                string password = this.passwordTxtBox.Text;

                // check if ftp folder exists
                if (!IsItReal(ftpPath))
                {
                    MessageBox.Show("FTP directory not found.");
                }
                else
                {
                    List<string> filesFound = ListAllFiles(ftpPath, userID, password);

                    // loop through all files found in ftp server to perform funcs on
                    foreach (string fileName in filesFound)
                    {
                        //get files in ftp server
                        if (filesFound.Count > 0)
                        {
                            // gets first file found 
                            ftpPath += fileName;
                            string firstFile = fileName;
                            // foreach used for testing
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
                        // if not using FTP, simply transfer from shared folder to Temp here
                        // using... File.Move(src, dest);
                        using (WebClient req = new WebClient())
                        {
                            req.Credentials = new NetworkCredential(userID, password);
                            byte[] fileData = req.DownloadData(ftpPath);

                            using (FileStream file = File.Create(tempFilePath))
                            {
                                file.Write(fileData, 0, fileData.Length);
                                file.Close();
                            }
                            Console.WriteLine("Download successful - ftpPath = " + ftpPath);
                        }

                        // print file 

                        // invoke printer name to maintain thread safety, thnx msft
                        //string printerName = cmbPrinter.SelectedItem.ToString();
                        string printerName = "";
                        cmbPrinter.Invoke((Action)delegate
                        {
                            printerName = cmbPrinter.SelectedItem.ToString();
                        });

                        try
                        {
                            if (this.maskTxtBox.Text == ".docx")
                            {
                                ProcessStartInfo info = new ProcessStartInfo();
                                info.Verb = "print";
                                info.FileName = @"c:\Temp\temptest" + this.maskTxtBox.Text;
                                info.CreateNoWindow = true;
                                info.WindowStyle = ProcessWindowStyle.Hidden;

                                Process p = new Process();
                                p.StartInfo = info;
                                p.Start();

                                p.WaitForInputIdle();
                                System.Threading.Thread.Sleep(5000);
                                if (false == p.CloseMainWindow())
                                {
                                    p.Kill();
                                }

                                // Delete file we just printed from ftp
                                DeleteFile(ftpPath, userID, password);
                                // Delete file from temp folder
                                DeleteLocalFile();
                            }
                            else
                            {
                                IPrinter printer = new Printer();
                                printer.PrintRawFile(printerName, tempFilePath, "temptest" + this.maskTxtBox.Text);

                                DeleteFile(ftpPath, userID, password);
                                // Delete file from temp folder
                                DeleteLocalFile();
                                //Console.WriteLine("Printing file + " + fileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("during printing exception thrown " + ex.Message);
                        }

                        // remove file name suffix from ftpPath
                        foreach (string suffix in filesFound)
                        {
                            if (ftpPath.EndsWith(fileName))
                            {
                                ftpPath = ftpPath.Remove(ftpPath.Length - suffix.Length);
                                break;
                            }
                        }
                        Console.WriteLine("new ftpPath = " + ftpPath);
                    }

                }
            }
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

        public static void DeleteLocalFile()
        {
            string path = @"c:\Temp";
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach(FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
