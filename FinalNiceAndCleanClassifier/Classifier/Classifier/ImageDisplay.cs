using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classifier
{
    public partial class ImageDisplay : Form
    {

        Rectangle selected;
        
        System.Drawing.Pen pen;
        System.Drawing.SolidBrush mapPen;
        System.Drawing.SolidBrush testPen;
        bool clicked = false;
        System.Drawing.Graphics formGraphics;
        Point startPt = new Point();
        Point endPt = new Point();

        // Image storage for original, currently displayed, and temp current
        Image orig;
        Image current;
        Image currentOrig;

        bool SelectingTestpts = false;
        bool SelectingMapPts = false;
        bool ignoreResize = false;

        // List of points added to lists
        public List<Point> mapPts = new List<Point>();
        public List<Point> testPts = new List<Point>();
        public List<hoverPoint> mapTooltipList = new List<hoverPoint>();
        public List<hoverPoint> testTooltipList = new List<hoverPoint>();

        public struct hoverPoint
        {
            public ToolTip tt;
            public Label placeholder;
        }

        public ImageDisplay(Image img)
        {
            InitializeComponent();

            // Set things up
            selected.X = -1;
            orig = (Image) img.Clone();
            current = (Image)img.Clone();
            currentOrig = (Image)img.Clone();
            SolidBrush brush = new SolidBrush(Color.Red);
            this.DoubleBuffered = true;
            pen = new Pen(brush);
            formGraphics = splitContainer1.Panel2.CreateGraphics();
            mapPen = new SolidBrush(Color.LightBlue);
            testPen = new SolidBrush(Color.LawnGreen);
            ignoreResize = true;
            this.Height = img.Height;
            this.Width = splitContainer1.Panel1.Width + img.Width;
            ignoreResize = false;
        }

        /* Crops given image to rectangle specified in selected */
        private Image CropImage(Image srcImg)
        {
            Bitmap cropped = new Bitmap(srcImg);
            cropped = cropped.Clone(selected, cropped.PixelFormat);
            return (Image)cropped;
        }

        /* Mouse down handler */
        private void PictureDown(object sender, MouseEventArgs e)
        {
            if (SelectingMapPts)
            {
                mapPts.Add(e.Location);
                listView1.Items.Add("Point " + (mapPts.Count-1) + ":  (" + e.X + ", " + e.Y + ")");
                
                // Setup invisible label - used as anchor for tooltip
                Label temp = new Label();
                temp.Text = "   ";
                temp.Location = mapPts[mapPts.Count - 1];
                temp.AutoSize = true;
                temp.BackColor = Color.Transparent;
                temp.Parent = splitContainer1.Panel2;

                // Setup tooltip
                ToolTip tt = new ToolTip();
                tt.IsBalloon = true;
                tt.ToolTipIcon = ToolTipIcon.Info;
                tt.ToolTipTitle = "Map Point: " + (mapPts.Count - 1);
                tt.AutoPopDelay = 1000;
                tt.SetToolTip(temp, "lkhgsd");

                hoverPoint hp = new hoverPoint();
                hp.placeholder = temp;
                hp.tt = tt;
                mapTooltipList.Add(hp);

                splitContainer1.Panel2.Invalidate();
            }
            else if (SelectingTestpts)
            {
                testPts.Add(e.Location);
                listView2.Items.Add("Point " + (testPts.Count-1) + ":  (" + e.X + ", " + e.Y + ")");

                // Setup invisible label - used as anchor for tooltip
                Label temp = new Label();
                temp.Text = "   ";
                temp.Location = testPts[testPts.Count - 1];
                temp.AutoSize = true;
                temp.BackColor = Color.Transparent;
                temp.Parent = splitContainer1.Panel2;

                // Setup tooltip
                ToolTip tt = new ToolTip();
                tt.IsBalloon = true;
                tt.ToolTipIcon = ToolTipIcon.Info;
                tt.ToolTipTitle = "Test Point: " + (testPts.Count - 1);
                tt.AutoPopDelay = 1000;
                tt.SetToolTip(temp, "lkhgsd");

                hoverPoint hp = new hoverPoint();
                hp.placeholder = temp;
                hp.tt = tt;
                testTooltipList.Add(hp);

                splitContainer1.Panel2.Invalidate();
            }
            else if (CropBox.Checked)
            {
                clicked = true;
                startPt = e.Location;
            }
        }

        private void PictureEnter(object sender, EventArgs e)
        {
            if (CropBox.Checked)
                this.Cursor = Cursors.Cross;
            
        }

        private void PictureLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void PictureMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                selected.X = Math.Min(startPt.X, e.X);
                selected.Y = Math.Min(startPt.Y, e.Y);
                selected.Width = Math.Abs(startPt.X - e.X);
                selected.Height = Math.Abs(startPt.Y - e.Y);
                splitContainer1.Panel2.Invalidate();
            }
        }

        private void PictureUp(object sender, MouseEventArgs e)
        {
            /*if (clicked)
            {
                try
                {
                    current = CropImage(current);
                }
                catch
                {
                    return;
                }
                endPt = e.Location;
                currentOrig = (Image)current.Clone();
                ignoreResize = true;
                this.Height = current.Height + 50;
                this.Width = splitContainer1.Panel1.Width + current.Width;// +10;
                ignoreResize = false;
                clicked = false;
                selected.X = -1;
                splitContainer1.Panel2.Invalidate();
                CropBox.Checked = false;
            }*/
        }

        private void PicturePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(current, 0, 0);
            if (selected.X != -1)
            {
                e.Graphics.DrawRectangle(pen, selected);
            }
            if (mapPts.Count != 0)
            {
                foreach (Point pt in mapPts)
                {
                    drawPoints(e, pt, mapPen);
                }
            }
            if (testPts.Count != 0)
            {
                foreach (Point pt in testPts)
                {
                    drawPoints(e, pt, testPen);
                }
            }
        }

        private void drawPoints(PaintEventArgs e, Point pt, SolidBrush drawer)
        {
            e.Graphics.FillEllipse(drawer, pt.X, pt.Y, 10, 10);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current = (Image)orig.Clone();
            listView1.Clear();
            listView2.Clear();
            mapPts.Clear();
            testPts.Clear();
            ignoreResize = true;
            this.Height = current.Height;
            this.Width = splitContainer1.Panel1.Width + current.Width;
            ignoreResize = true;
            splitContainer1.Panel2.Invalidate();
        }

        private void PictureREsize(object sender, EventArgs e)
        {
            if (currentOrig != null && !ignoreResize)
            {
                current = (Image)new Bitmap(currentOrig, new Size(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height));
                splitContainer1.Panel2.Invalidate();
            }
        }

        private void TestPtSelectBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TestPtSelectBox.Checked)
            {
                if (SelectingMapPts)
                {
                    System.Windows.Forms.DialogResult res = MessageBox.Show("Stop selecting Map points?", "", MessageBoxButtons.YesNoCancel);
                    if (res == System.Windows.Forms.DialogResult.No || res == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                SelectingMapPts = false;
                MapPtSelectBox.Checked = false;
                SelectingTestpts = true;

            }
            else
            {
                SelectingTestpts = false;
            }
        }

        private void MapPtSelectBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MapPtSelectBox.Checked)
            {
                if (SelectingTestpts)
                {
                    System.Windows.Forms.DialogResult res = MessageBox.Show("Stop selecting Test points?", "", MessageBoxButtons.YesNoCancel);
                    if (res == System.Windows.Forms.DialogResult.No || res == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                SelectingMapPts = true;
                TestPtSelectBox.Checked = false;
                SelectingTestpts = false;
            }
            else
            {
                SelectingMapPts = false;
            }
        }

        private void CropBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void UpdateToolTipPoints(List<string> mapData, List<string> testData)
        {
            for (int i = 0; i < mapData.Count; i++)
            {
                hoverPoint temp = mapTooltipList[i];
                temp.tt.SetToolTip(temp.placeholder, mapData[i]);
            }

            for (int i = 0; i < testData.Count; i++)
            {
                hoverPoint temp = testTooltipList[i];
                temp.tt.SetToolTip(temp.placeholder, testData[i]);
            }
            splitContainer1.Panel2.Invalidate();
        }

        private void saveMapCoordsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCoords("Map");
        }

        private void saveTestCoordsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCoords("Test");
        }


        private void SaveCoords(string which)
        {
            string savePath = "";
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Select destination for " + which + " coords file";
                sfd.Filter = "Text file|*.txt";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                    savePath = sfd.FileName;
            }

            if (savePath == "")
                MessageBox.Show("No save file specified.");
            else
            {
                bool CorrectY = true;
                if (MessageBox.Show("Correct Y coordinate system? (Currently inverted)", "Y coord system", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    CorrectY = false;

                if (CorrectY)
                {
                    // Correct Y coords
                    int PanelHeight = splitContainer1.Panel2.Height;
                    List<Point> NewPoints = new List<Point>();

                    List<Point> temp = (which == "Test") ? testPts : mapPts;
                    foreach (Point pt in temp)
                    {
                        Point tmp = new Point();
                        tmp.Y = PanelHeight - pt.Y;
                        tmp.X = pt.X;
                        NewPoints.Add(tmp);
                    }

                    mapPts = NewPoints;
                }

                // Multiprint
                int printnum = 1;
                string num = Microsoft.VisualBasic.Interaction.InputBox("Enter number of times to print each set of coords: ");
                if (num != "")
                    printnum = Convert.ToInt32(num);

                // Write to file
                using (StreamWriter sw = new StreamWriter(savePath))
                    foreach (Point pt in mapPts)
                        for (int i = 0; i < printnum; i++)
                        {
                            int additionx = 0;
                            int additiony = 0;
                            switch (i)
                            {
                                case 0:
                                    additiony = 10;
                                    break;
                                case 1:
                                    additionx = 5;
                                    additiony = 5;
                                    break;
                                case 2:
                                    additionx = 10;
                                    break;
                                case 3:
                                    additionx = 5;
                                    additiony = -5;
                                    break;
                                case 4:
                                    additiony = -10;
                                    break;
                                case 5:
                                    additionx = -5;
                                    additiony = -5;
                                    break;
                                case 6:
                                    additionx = -10;
                                    break;
                                case 7:
                                    additionx = -5;
                                    additiony = 5;
                                    break;
                                default:
                                    Console.WriteLine("OOOO");
                                    break;
                            }
                            sw.WriteLine((pt.X + additionx) + "," + (pt.Y + additiony));
                        }



                MessageBox.Show("Finished.");
            }
        }
    }
}
