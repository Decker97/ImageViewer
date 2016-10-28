namespace ImageViewer
{
    partial class frmPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbSeq = new System.Windows.Forms.RadioButton();
            this.rbRnd = new System.Windows.Forms.RadioButton();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbSeq);
            this.panel1.Controls.Add(this.rbRnd);
            this.panel1.Controls.Add(this.btnDirectory);
            this.panel1.Controls.Add(this.lblDirectory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudInterval);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 113);
            this.panel1.TabIndex = 0;
            // 
            // rbSeq
            // 
            this.rbSeq.AutoSize = true;
            this.rbSeq.Location = new System.Drawing.Point(112, 83);
            this.rbSeq.Name = "rbSeq";
            this.rbSeq.Size = new System.Drawing.Size(78, 17);
            this.rbSeq.TabIndex = 6;
            this.rbSeq.Text = "Sequencial";
            this.rbSeq.UseVisualStyleBackColor = true;
            // 
            // rbRnd
            // 
            this.rbRnd.AutoSize = true;
            this.rbRnd.Checked = true;
            this.rbRnd.Location = new System.Drawing.Point(112, 60);
            this.rbRnd.Name = "rbRnd";
            this.rbRnd.Size = new System.Drawing.Size(65, 17);
            this.rbRnd.TabIndex = 5;
            this.rbRnd.TabStop = true;
            this.rbRnd.Text = "Random";
            this.rbRnd.UseVisualStyleBackColor = true;
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(70, 39);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(24, 22);
            this.btnDirectory.TabIndex = 4;
            this.btnDirectory.Text = "...";
            this.btnDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(112, 43);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(0, 13);
            this.lblDirectory.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory:";
            // 
            // nudInterval
            // 
            this.nudInterval.DecimalPlaces = 4;
            this.nudInterval.Location = new System.Drawing.Point(112, 7);
            this.nudInterval.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(120, 20);
            this.nudInterval.TabIndex = 1;
            this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(94, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Interval (seconds):";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 146);
            this.panel2.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(174, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmPreferences
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(578, 259);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPreferences";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rbSeq;
        private System.Windows.Forms.RadioButton rbRnd;
    }
}

