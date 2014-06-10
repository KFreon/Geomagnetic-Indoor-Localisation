using System.Reflection;
using System.Windows.Forms;
namespace Classifier
{
    partial class ImageDisplay
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

        public partial class NonFlickerSplitContainer : SplitContainer
        {
            public NonFlickerSplitContainer()
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                                   ControlStyles.UserPaint |
                                   ControlStyles.OptimizedDoubleBuffer, true);

                MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);

                object[] objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                                                                ControlStyles.UserPaint |
                                                               ControlStyles.OptimizedDoubleBuffer, true };

                objMethodInfo.Invoke(this.Panel1, objArgs);
                objMethodInfo.Invoke(this.Panel2, objArgs);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapCoordsToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestPtSelectBox = new System.Windows.Forms.CheckBox();
            this.MapPtSelectBox = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new Classifier.ImageDisplay.NonFlickerSplitContainer();
            this.splitContainer2 = new Classifier.ImageDisplay.NonFlickerSplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.CropBox = new System.Windows.Forms.CheckBox();
            this.saveTestCoordsToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.saveMapCoordsToFileToolStripMenuItem,
            this.saveTestCoordsToFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // saveMapCoordsToFileToolStripMenuItem
            // 
            this.saveMapCoordsToFileToolStripMenuItem.Name = "saveMapCoordsToFileToolStripMenuItem";
            this.saveMapCoordsToFileToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.saveMapCoordsToFileToolStripMenuItem.Text = "Save Map Coords to File";
            this.saveMapCoordsToFileToolStripMenuItem.Click += new System.EventHandler(this.saveMapCoordsToFileToolStripMenuItem_Click);
            // 
            // TestPtSelectBox
            // 
            this.TestPtSelectBox.AutoSize = true;
            this.TestPtSelectBox.Location = new System.Drawing.Point(391, 6);
            this.TestPtSelectBox.Name = "TestPtSelectBox";
            this.TestPtSelectBox.Size = new System.Drawing.Size(112, 17);
            this.TestPtSelectBox.TabIndex = 1;
            this.TestPtSelectBox.Text = "Select Test Points";
            this.TestPtSelectBox.UseVisualStyleBackColor = true;
            this.TestPtSelectBox.CheckedChanged += new System.EventHandler(this.TestPtSelectBox_CheckedChanged);
            // 
            // MapPtSelectBox
            // 
            this.MapPtSelectBox.AutoSize = true;
            this.MapPtSelectBox.Location = new System.Drawing.Point(509, 6);
            this.MapPtSelectBox.Name = "MapPtSelectBox";
            this.MapPtSelectBox.Size = new System.Drawing.Size(112, 17);
            this.MapPtSelectBox.TabIndex = 2;
            this.MapPtSelectBox.Text = "Select Map Points";
            this.MapPtSelectBox.UseVisualStyleBackColor = true;
            this.MapPtSelectBox.CheckedChanged += new System.EventHandler(this.MapPtSelectBox_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.PicturePaint);
            this.splitContainer1.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureDown);
            this.splitContainer1.Panel2.MouseEnter += new System.EventHandler(this.PictureEnter);
            this.splitContainer1.Panel2.MouseLeave += new System.EventHandler(this.PictureLeave);
            this.splitContainer1.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureMove);
            this.splitContainer1.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureUp);
            this.splitContainer1.Panel2.Resize += new System.EventHandler(this.PictureREsize);
            this.splitContainer1.Size = new System.Drawing.Size(687, 246);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listView2);
            this.splitContainer2.Size = new System.Drawing.Size(229, 246);
            this.splitContainer2.SplitterDistance = 117;
            this.splitContainer2.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(229, 117);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(229, 125);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // CropBox
            // 
            this.CropBox.AutoSize = true;
            this.CropBox.Location = new System.Drawing.Point(627, 7);
            this.CropBox.Name = "CropBox";
            this.CropBox.Size = new System.Drawing.Size(48, 17);
            this.CropBox.TabIndex = 4;
            this.CropBox.Text = "Crop";
            this.CropBox.UseVisualStyleBackColor = true;
            this.CropBox.CheckedChanged += new System.EventHandler(this.CropBox_CheckedChanged);
            // 
            // saveTestCoordsToFileToolStripMenuItem
            // 
            this.saveTestCoordsToFileToolStripMenuItem.Name = "saveTestCoordsToFileToolStripMenuItem";
            this.saveTestCoordsToFileToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.saveTestCoordsToFileToolStripMenuItem.Text = "Save Test Coords to File";
            this.saveTestCoordsToFileToolStripMenuItem.Click += new System.EventHandler(this.saveTestCoordsToFileToolStripMenuItem_Click);
            // 
            // ImageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(687, 270);
            this.Controls.Add(this.CropBox);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MapPtSelectBox);
            this.Controls.Add(this.TestPtSelectBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageDisplay";
            this.Text = "ImageDisplay";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.CheckBox TestPtSelectBox;
        private System.Windows.Forms.CheckBox MapPtSelectBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.CheckBox CropBox;
        private ImageDisplay.NonFlickerSplitContainer splitContainer1;
        private ImageDisplay.NonFlickerSplitContainer splitContainer2;
        private ToolStripMenuItem saveMapCoordsToFileToolStripMenuItem;
        private ToolStripMenuItem saveTestCoordsToFileToolStripMenuItem;


    }
}