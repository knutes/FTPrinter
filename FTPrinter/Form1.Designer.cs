namespace FTPrinter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listFilesButton = new System.Windows.Forms.Button();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.addressTxtBox = new System.Windows.Forms.TextBox();
            this.folderTxtBox = new System.Windows.Forms.TextBox();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.usernameTxtBox = new System.Windows.Forms.TextBox();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.maskTxtBox = new System.Windows.Forms.TextBox();
            this.intervalTxtBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.deleteCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTPrinter";
            // 
            // listFilesButton
            // 
            this.listFilesButton.Location = new System.Drawing.Point(43, 395);
            this.listFilesButton.Name = "listFilesButton";
            this.listFilesButton.Size = new System.Drawing.Size(128, 36);
            this.listFilesButton.TabIndex = 3;
            this.listFilesButton.Text = "List All Files";
            this.listFilesButton.UseVisualStyleBackColor = true;
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(172, 310);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(210, 21);
            this.cmbPrinter.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "FTP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "FTP Folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "FTP Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "FTP Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "FTP Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "File Mask";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Delete After Print";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Printer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(40, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Interval";
            // 
            // addressTxtBox
            // 
            this.addressTxtBox.Location = new System.Drawing.Point(172, 102);
            this.addressTxtBox.Name = "addressTxtBox";
            this.addressTxtBox.Size = new System.Drawing.Size(210, 20);
            this.addressTxtBox.TabIndex = 19;
            // 
            // folderTxtBox
            // 
            this.folderTxtBox.Location = new System.Drawing.Point(172, 135);
            this.folderTxtBox.Name = "folderTxtBox";
            this.folderTxtBox.Size = new System.Drawing.Size(210, 20);
            this.folderTxtBox.TabIndex = 20;
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(172, 166);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(210, 20);
            this.portTxtBox.TabIndex = 21;
            // 
            // usernameTxtBox
            // 
            this.usernameTxtBox.Location = new System.Drawing.Point(172, 196);
            this.usernameTxtBox.Name = "usernameTxtBox";
            this.usernameTxtBox.Size = new System.Drawing.Size(210, 20);
            this.usernameTxtBox.TabIndex = 22;
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Location = new System.Drawing.Point(172, 225);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.Size = new System.Drawing.Size(210, 20);
            this.passwordTxtBox.TabIndex = 23;
            // 
            // maskTxtBox
            // 
            this.maskTxtBox.Location = new System.Drawing.Point(172, 255);
            this.maskTxtBox.Name = "maskTxtBox";
            this.maskTxtBox.Size = new System.Drawing.Size(210, 20);
            this.maskTxtBox.TabIndex = 24;
            // 
            // intervalTxtBox
            // 
            this.intervalTxtBox.Location = new System.Drawing.Point(172, 341);
            this.intervalTxtBox.Name = "intervalTxtBox";
            this.intervalTxtBox.Size = new System.Drawing.Size(210, 20);
            this.intervalTxtBox.TabIndex = 26;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(254, 395);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(128, 36);
            this.startButton.TabIndex = 27;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // deleteCheckBox
            // 
            this.deleteCheckBox.AutoSize = true;
            this.deleteCheckBox.Location = new System.Drawing.Point(172, 284);
            this.deleteCheckBox.Name = "deleteCheckBox";
            this.deleteCheckBox.Size = new System.Drawing.Size(15, 14);
            this.deleteCheckBox.TabIndex = 28;
            this.deleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FTPrinter.Properties.Resources.mcsilogo;
            this.pictureBox1.Location = new System.Drawing.Point(31, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 67);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 454);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.deleteCheckBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.intervalTxtBox);
            this.Controls.Add(this.maskTxtBox);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.usernameTxtBox);
            this.Controls.Add(this.portTxtBox);
            this.Controls.Add(this.folderTxtBox);
            this.Controls.Add(this.addressTxtBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPrinter);
            this.Controls.Add(this.listFilesButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listFilesButton;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox addressTxtBox;
        private System.Windows.Forms.TextBox folderTxtBox;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.TextBox usernameTxtBox;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.TextBox maskTxtBox;
        private System.Windows.Forms.TextBox intervalTxtBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox deleteCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

