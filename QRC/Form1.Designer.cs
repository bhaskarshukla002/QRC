using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QRC
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.drawBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rackLabel = new System.Windows.Forms.Label();
            this.rackCB = new System.Windows.Forms.ComboBox();
            this.rowLabel = new System.Windows.Forms.Label();
            this.rowCB = new System.Windows.Forms.ComboBox();
            this.spaceInputLabel = new System.Windows.Forms.Label();
            this.spaceInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(2, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1754, 1240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // drawBtn
            // 
            this.drawBtn.Location = new System.Drawing.Point(717, 8);
            this.drawBtn.Margin = new System.Windows.Forms.Padding(4);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(100, 34);
            this.drawBtn.TabIndex = 1;
            this.drawBtn.Text = "Draw";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.rackLabel);
            this.panel1.Controls.Add(this.rackCB);
            this.panel1.Controls.Add(this.rowLabel);
            this.panel1.Controls.Add(this.rowCB);
            this.panel1.Controls.Add(this.drawBtn);
            this.panel1.Controls.Add(this.spaceInputLabel);
            this.panel1.Controls.Add(this.spaceInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1756, 51);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rackLabel
            // 
            this.rackLabel.AutoSize = true;
            this.rackLabel.Location = new System.Drawing.Point(14, 15);
            this.rackLabel.Name = "rackLabel";
            this.rackLabel.Size = new System.Drawing.Size(48, 24);
            this.rackLabel.TabIndex = 3;
            this.rackLabel.Text = "Rack";
            // 
            // rackCB
            // 
            this.rackCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rackCB.FormattingEnabled = true;
            this.rackCB.Location = new System.Drawing.Point(67, 12);
            this.rackCB.MaxDropDownItems = 10;
            this.rackCB.Name = "rackCB";
            this.rackCB.Size = new System.Drawing.Size(121, 32);
            this.rackCB.TabIndex = 4;
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(232, 15);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(46, 24);
            this.rowLabel.TabIndex = 5;
            this.rowLabel.Text = "Row";
            // 
            // rowCB
            // 
            this.rowCB.FormattingEnabled = true;
            this.rowCB.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y"});
            this.rowCB.Location = new System.Drawing.Point(295, 12);
            this.rowCB.Name = "rowCB";
            this.rowCB.Size = new System.Drawing.Size(121, 32);
            this.rowCB.TabIndex = 6;
            // 
            // spaceInputLabel
            // 
            this.spaceInputLabel.AutoSize = true;
            this.spaceInputLabel.Location = new System.Drawing.Point(454, 15);
            this.spaceInputLabel.Name = "spaceInputLabel";
            this.spaceInputLabel.Size = new System.Drawing.Size(88, 24);
            this.spaceInputLabel.TabIndex = 7;
            this.spaceInputLabel.Text = "Gap(mm)";
            // 
            // spaceInput
            // 
            this.spaceInput.Location = new System.Drawing.Point(548, 11);
            this.spaceInput.Name = "spaceInput";
            this.spaceInput.Size = new System.Drawing.Size(100, 32);
            this.spaceInput.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1364, 845);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "QR Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitializeRackComboBox()
        {
            for (int i = 1; i < 100; i++)
            {
                string number = i.ToString("D2"); // Format the number as a two-digit string with leading zeros
                this.rackCB.Items.Add(number); // Add the number to the rackCB control
            }
        }
        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // Perform time-consuming operation here
        //}

        //private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // Perform another time-consuming operation here
        //}


        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label rackLabel;
        private System.Windows.Forms.ComboBox rackCB;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.ComboBox rowCB;
        private System.Windows.Forms.Label spaceInputLabel;
        private System.Windows.Forms.NumericUpDown spaceInput;
        //private System.Windows.Forms.ComboBox comboBox2;
        //private System.Windows.Forms.Label label3;

        
    }
    
}

