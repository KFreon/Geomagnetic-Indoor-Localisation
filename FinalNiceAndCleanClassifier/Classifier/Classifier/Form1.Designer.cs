namespace Classifier
{
    partial class ClassifierForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.ImageButton = new System.Windows.Forms.Button();
            this.PlotterButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SimulateBox = new System.Windows.Forms.TextBox();
            this.ExpOrientButton = new System.Windows.Forms.Button();
            this.RescanButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TestOrientBox = new System.Windows.Forms.TextBox();
            this.UpperTextBox = new System.Windows.Forms.TextBox();
            this.CompareTextBox = new System.Windows.Forms.TextBox();
            this.lowerlabel = new System.Windows.Forms.Label();
            this.LowerTextBox = new System.Windows.Forms.TextBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.NorthCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportMatlab = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ExportMatlab);
            this.splitContainer1.Panel2.Controls.Add(this.ImageButton);
            this.splitContainer1.Panel2.Controls.Add(this.PlotterButton);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.SimulateBox);
            this.splitContainer1.Panel2.Controls.Add(this.ExpOrientButton);
            this.splitContainer1.Panel2.Controls.Add(this.RescanButton);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.TestOrientBox);
            this.splitContainer1.Panel2.Controls.Add(this.UpperTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.CompareTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.lowerlabel);
            this.splitContainer1.Panel2.Controls.Add(this.LowerTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.ResetButton);
            this.splitContainer1.Panel2.Controls.Add(this.StartButton);
            this.splitContainer1.Panel2.Controls.Add(this.NorthCheckBox);
            this.splitContainer1.Size = new System.Drawing.Size(635, 591);
            this.splitContainer1.SplitterDistance = 476;
            this.splitContainer1.TabIndex = 0;
            // 
            // rtb
            // 
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Location = new System.Drawing.Point(0, 0);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(635, 476);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            // 
            // ImageButton
            // 
            this.ImageButton.Location = new System.Drawing.Point(388, 56);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(103, 23);
            this.ImageButton.TabIndex = 17;
            this.ImageButton.Text = "ImageDisplay";
            this.ImageButton.UseVisualStyleBackColor = true;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // PlotterButton
            // 
            this.PlotterButton.Location = new System.Drawing.Point(388, 85);
            this.PlotterButton.Name = "PlotterButton";
            this.PlotterButton.Size = new System.Drawing.Size(103, 23);
            this.PlotterButton.TabIndex = 16;
            this.PlotterButton.Text = "Temporal Plotter";
            this.PlotterButton.UseVisualStyleBackColor = true;
            this.PlotterButton.Click += new System.EventHandler(this.PlotterButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Simulate sensors";
            // 
            // SimulateBox
            // 
            this.SimulateBox.Location = new System.Drawing.Point(13, 28);
            this.SimulateBox.Name = "SimulateBox";
            this.SimulateBox.Size = new System.Drawing.Size(26, 20);
            this.SimulateBox.TabIndex = 14;
            this.SimulateBox.Text = "4";
            // 
            // ExpOrientButton
            // 
            this.ExpOrientButton.Location = new System.Drawing.Point(220, 62);
            this.ExpOrientButton.Name = "ExpOrientButton";
            this.ExpOrientButton.Size = new System.Drawing.Size(162, 23);
            this.ExpOrientButton.TabIndex = 13;
            this.ExpOrientButton.Text = "Export Orientation from Map";
            this.ExpOrientButton.UseVisualStyleBackColor = true;
            this.ExpOrientButton.Click += new System.EventHandler(this.ExpOrientButton_Click);
            // 
            // RescanButton
            // 
            this.RescanButton.Location = new System.Drawing.Point(220, 85);
            this.RescanButton.Name = "RescanButton";
            this.RescanButton.Size = new System.Drawing.Size(75, 23);
            this.RescanButton.TabIndex = 12;
            this.RescanButton.Text = "Rescan";
            this.RescanButton.UseVisualStyleBackColor = true;
            this.RescanButton.Click += new System.EventHandler(this.RescanButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Test Orientation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Upper";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Compare";
            // 
            // TestOrientBox
            // 
            this.TestOrientBox.Location = new System.Drawing.Point(139, 88);
            this.TestOrientBox.Name = "TestOrientBox";
            this.TestOrientBox.Size = new System.Drawing.Size(75, 20);
            this.TestOrientBox.TabIndex = 8;
            this.TestOrientBox.Text = "0";
            // 
            // UpperTextBox
            // 
            this.UpperTextBox.Location = new System.Drawing.Point(100, 88);
            this.UpperTextBox.Name = "UpperTextBox";
            this.UpperTextBox.Size = new System.Drawing.Size(27, 20);
            this.UpperTextBox.TabIndex = 7;
            this.UpperTextBox.Text = "6";
            // 
            // CompareTextBox
            // 
            this.CompareTextBox.Location = new System.Drawing.Point(43, 88);
            this.CompareTextBox.Name = "CompareTextBox";
            this.CompareTextBox.Size = new System.Drawing.Size(46, 20);
            this.CompareTextBox.TabIndex = 6;
            this.CompareTextBox.Text = "3";
            // 
            // lowerlabel
            // 
            this.lowerlabel.AutoSize = true;
            this.lowerlabel.Location = new System.Drawing.Point(3, 72);
            this.lowerlabel.Name = "lowerlabel";
            this.lowerlabel.Size = new System.Drawing.Size(36, 13);
            this.lowerlabel.TabIndex = 5;
            this.lowerlabel.Text = "Lower";
            // 
            // LowerTextBox
            // 
            this.LowerTextBox.Location = new System.Drawing.Point(13, 88);
            this.LowerTextBox.Name = "LowerTextBox";
            this.LowerTextBox.Size = new System.Drawing.Size(21, 20);
            this.LowerTextBox.TabIndex = 4;
            this.LowerTextBox.Text = "2";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(139, 28);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(139, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // NorthCheckBox
            // 
            this.NorthCheckBox.AutoSize = true;
            this.NorthCheckBox.Location = new System.Drawing.Point(13, 4);
            this.NorthCheckBox.Name = "NorthCheckBox";
            this.NorthCheckBox.Size = new System.Drawing.Size(76, 17);
            this.NorthCheckBox.TabIndex = 0;
            this.NorthCheckBox.Text = "North Only";
            this.NorthCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExportMatlab
            // 
            this.ExportMatlab.Location = new System.Drawing.Point(525, 85);
            this.ExportMatlab.Name = "ExportMatlab";
            this.ExportMatlab.Size = new System.Drawing.Size(107, 23);
            this.ExportMatlab.TabIndex = 18;
            this.ExportMatlab.Text = "Export for Matlab";
            this.ExportMatlab.UseVisualStyleBackColor = true;
            this.ExportMatlab.Click += new System.EventHandler(this.ExportMatlab_Click);
            // 
            // ClassifierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 591);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ClassifierForm";
            this.Text = "Indoor Geolocation Frontend";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.CheckBox NorthCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TestOrientBox;
        private System.Windows.Forms.TextBox UpperTextBox;
        private System.Windows.Forms.TextBox CompareTextBox;
        private System.Windows.Forms.Label lowerlabel;
        private System.Windows.Forms.TextBox LowerTextBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RescanButton;
        private System.Windows.Forms.Button ExpOrientButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SimulateBox;
        private System.Windows.Forms.Button PlotterButton;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.Button ExportMatlab;
    }
}

