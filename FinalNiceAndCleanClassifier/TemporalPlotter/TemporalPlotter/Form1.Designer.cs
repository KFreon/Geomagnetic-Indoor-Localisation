namespace TemporalPlotter
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ClearDatasetButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlotButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.TimeDelayBox = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GenerateButton);
            this.splitContainer1.Panel2.Controls.Add(this.ClearDatasetButton);
            this.splitContainer1.Panel2.Controls.Add(this.StopButton);
            this.splitContainer1.Panel2.Controls.Add(this.PlotButton);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.ResetButton);
            this.splitContainer1.Panel2.Controls.Add(this.TimeDelayBox);
            this.splitContainer1.Panel2.Controls.Add(this.LoadButton);
            this.splitContainer1.Size = new System.Drawing.Size(1089, 513);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 0;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(601, 4);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(135, 23);
            this.GenerateButton.TabIndex = 8;
            this.GenerateButton.Text = "Generate Blender Script";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ClearDatasetButton
            // 
            this.ClearDatasetButton.Location = new System.Drawing.Point(196, 3);
            this.ClearDatasetButton.Name = "ClearDatasetButton";
            this.ClearDatasetButton.Size = new System.Drawing.Size(128, 23);
            this.ClearDatasetButton.TabIndex = 7;
            this.ClearDatasetButton.Text = "Clear Datasets";
            this.ClearDatasetButton.UseVisualStyleBackColor = true;
            this.ClearDatasetButton.Click += new System.EventHandler(this.ClearDatasetButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(423, 4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 6;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PlotButton
            // 
            this.PlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotButton.Location = new System.Drawing.Point(341, 3);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(75, 23);
            this.PlotButton.TabIndex = 5;
            this.PlotButton.Text = "PLOT";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(925, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time delay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loaded datasets";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(504, 5);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // TimeDelayBox
            // 
            this.TimeDelayBox.Location = new System.Drawing.Point(989, 8);
            this.TimeDelayBox.Name = "TimeDelayBox";
            this.TimeDelayBox.Size = new System.Drawing.Size(100, 20);
            this.TimeDelayBox.TabIndex = 1;
            this.TimeDelayBox.Text = "100";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(3, 3);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load Data";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 513);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Temporal Plotter";
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TextBox TimeDelayBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ClearDatasetButton;
        private System.Windows.Forms.Button GenerateButton;
    }
}

