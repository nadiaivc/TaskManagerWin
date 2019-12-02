namespace Process_Note
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FileInfo = new System.Windows.Forms.ListView();
            this.Integrity_level = new System.Windows.Forms.Button();
            this.high = new System.Windows.Forms.Button();
            this.medium = new System.Windows.Forms.Button();
            this.Low_b = new System.Windows.Forms.Button();
            this.Medium_b = new System.Windows.Forms.Button();
            this.HIgh_b = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-1, -1);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1542, 323);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.ListView1_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(-1, 321);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1542, 65);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(819, 554);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(424, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(526, 484);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path to file";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FloralWhite;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(965, 585);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FileInfo
            // 
            this.FileInfo.HideSelection = false;
            this.FileInfo.Location = new System.Drawing.Point(12, 462);
            this.FileInfo.Name = "FileInfo";
            this.FileInfo.Size = new System.Drawing.Size(1399, 77);
            this.FileInfo.TabIndex = 6;
            this.FileInfo.UseCompatibleStateImageBehavior = false;
            // 
            // Integrity_level
            // 
            this.Integrity_level.Location = new System.Drawing.Point(230, 393);
            this.Integrity_level.Name = "Integrity_level";
            this.Integrity_level.Size = new System.Drawing.Size(112, 31);
            this.Integrity_level.TabIndex = 7;
            this.Integrity_level.Text = "low";
            this.Integrity_level.UseVisualStyleBackColor = true;
            this.Integrity_level.Click += new System.EventHandler(this.Low);
            // 
            // high
            // 
            this.high.Location = new System.Drawing.Point(466, 393);
            this.high.Name = "high";
            this.high.Size = new System.Drawing.Size(112, 31);
            this.high.TabIndex = 8;
            this.high.Text = "high";
            this.high.UseVisualStyleBackColor = true;
            this.high.Click += new System.EventHandler(this.High_Click);
            // 
            // medium
            // 
            this.medium.Location = new System.Drawing.Point(348, 393);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(112, 31);
            this.medium.TabIndex = 9;
            this.medium.Text = "medium";
            this.medium.UseVisualStyleBackColor = true;
            this.medium.Click += new System.EventHandler(this.Medium_Click);
            // 
            // Low_b
            // 
            this.Low_b.Location = new System.Drawing.Point(446, 545);
            this.Low_b.Name = "Low_b";
            this.Low_b.Size = new System.Drawing.Size(112, 31);
            this.Low_b.TabIndex = 11;
            this.Low_b.Text = "Low";
            this.Low_b.UseVisualStyleBackColor = true;
            this.Low_b.Click += new System.EventHandler(this.Low_b_Click);
            // 
            // Medium_b
            // 
            this.Medium_b.Location = new System.Drawing.Point(446, 582);
            this.Medium_b.Name = "Medium_b";
            this.Medium_b.Size = new System.Drawing.Size(112, 31);
            this.Medium_b.TabIndex = 12;
            this.Medium_b.Text = "Medium";
            this.Medium_b.UseVisualStyleBackColor = true;
            this.Medium_b.Click += new System.EventHandler(this.Medium_b_Click);
            // 
            // HIgh_b
            // 
            this.HIgh_b.Location = new System.Drawing.Point(446, 619);
            this.HIgh_b.Name = "HIgh_b";
            this.HIgh_b.Size = new System.Drawing.Size(112, 31);
            this.HIgh_b.TabIndex = 13;
            this.HIgh_b.Text = "High";
            this.HIgh_b.UseVisualStyleBackColor = true;
            this.HIgh_b.Click += new System.EventHandler(this.HIgh_b_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1303, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 33);
            this.button2.TabIndex = 14;
            this.button2.Text = "Change privileges";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1408, 684);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 31);
            this.button3.TabIndex = 15;
            this.button3.Text = "Reload";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(82, 547);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 28);
            this.button4.TabIndex = 16;
            this.button4.Text = "GetMine";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(257, 547);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 29);
            this.button5.TabIndex = 17;
            this.button5.Text = "Change ACL";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1541, 725);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.HIgh_b);
            this.Controls.Add(this.Medium_b);
            this.Controls.Add(this.Low_b);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.high);
            this.Controls.Add(this.Integrity_level);
            this.Controls.Add(this.FileInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "lab1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView FileInfo;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ListView listView2;
        public System.Windows.Forms.Button Integrity_level;
        public System.Windows.Forms.Button high;
        public System.Windows.Forms.Button medium;
        public System.Windows.Forms.Button Low_b;
        public System.Windows.Forms.Button Medium_b;
        public System.Windows.Forms.Button HIgh_b;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

