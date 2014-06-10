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
using SelectionForm;

namespace TemporalPlotter
{
    public partial class Form1 : Form
    {
        List<List<double>> DataSets = new List<List<double>>();
        List<string> DataNames = new List<string>();
        bool stop = false;
        Graphics FormGraphics;
        int loadedDatasets = 0;
        List<string> filenames = new List<string>();


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            FormGraphics = this.splitContainer1.Panel1.CreateGraphics();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Dataset";
                ofd.Filter = "Text files (.txt)|*.txt";
                ofd.Multiselect = true;
                
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                    foreach (string file in ofd.FileNames)
                    {
                        loadedDatasets += LoadData(File.ReadAllLines(file), file);
                        filenames.Add(Path.GetFileNameWithoutExtension(file));
                    }
            }
            label1.Text = "Loaded datasets: " + loadedDatasets.ToString();
        }

        private int LoadData(string[] data, string filename)
        {
            int current = 'a';
            if (DataNames.Count != 0)
                current = DataNames[DataNames.Count - 1][0];


            // Figure out how many lists to make
            string templine = data[0].Trim();
            int numLists = 1;
            if (templine.Contains(' '))
                numLists = templine.Split(' ').Length;
            else if (templine.Contains(','))
                numLists = templine.Split(',').Length;

            for (int i = 0; i < numLists; i++)
            {
                DataNames.Add(filename + " " + (char)current);
                List<double> templist = new List<double>();
                // Space delimiter
                foreach (string line in data)
                {
                    templine = line.Trim();
                    if (templine.Contains(' '))
                    {
                        string[] parts = templine.Split(' ');
                        templist.Add(Double.Parse(parts[i]));
                    }
                    else if (templine.Contains(','))
                    {
                        string[] parts = templine.Split(',');
                        templist.Add(Double.Parse(parts[i]));
                    }
                }
                DataSets.Add(templist);
                current++;
            }

            return numLists;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            FormGraphics.Clear(this.BackColor);
        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            // Select plots
            int x = 0;
            int y = 0;
            using (SelectionForm.SelectionForm sf = new SelectionForm.SelectionForm(DataNames, "Select 2 datasets to display.", "Select Datasets", false))
            {
                sf.ShowDialog();
                if (sf.SelectedItems == null || sf.SelectedItems.Count == 0)
                    return;
                else
                {
                    if (sf.SelectedItems.Count > 2)
                        MessageBox.Show("Select 2 only.");
                    else
                    {
                        x = DataNames.IndexOf(sf.SelectedItems[0]);
                        y = DataNames.IndexOf(sf.SelectedItems[1]);                        
                    }
                }
            }

            // Adjust Data ranges
            List<double> tempx = new List<double>();
            List<double> tempy = new List<double>();

            double xmin = DataSets[x].Min();
            double xmax = DataSets[x].Max();
            double ymin = DataSets[y].Min();
            double ymax = DataSets[y].Max();

            double yadder = splitContainer1.Panel1.Height / 2.0;
            double xadder = splitContainer1.Panel1.Width / 2.0;

            double ydivisor = ((Math.Abs(ymax) > Math.Abs(ymin)) ? ymax : ymin) / yadder;
            double xdivisor = ((Math.Abs(xmax) > Math.Abs(xmin)) ? xmax : xmin) / xadder;

            for (int i = 0; i < DataSets[x].Count; i++)
            {
                tempx.Add((DataSets[x][i] / xdivisor) + xadder);
                tempy.Add((DataSets[y][i] / ydivisor) + yadder);
            }

            Task.Factory.StartNew(() => Plot(tempx, tempy, Convert.ToInt32(TimeDelayBox.Text)));
        }

        private void Plot(List<double> x, List<double> y, int delay)
        {
            
            for (int i = 0; i < x.Count; i++)
            {
                if (stop)
                {
                    stop = false;
                    return;
                }
                    
                FormGraphics.DrawEllipse(Pens.Red, (float)x[i], (float)y[i], 10, 10);
                System.Threading.Thread.Sleep(delay);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void ClearDatasetButton_Click(object sender, EventArgs e)
        {
            DataSets.Clear();
            DataNames.Clear();
            filenames.Clear();
            label1.Text = "Loaded Datasets";
        }


        private void GenerateBlenderScript()
        {
            List<List<double>> tempDataSets = new List<List<double>>();
            char start = 'X';
            if (DataSets.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    char set = (char)((int)start + i);
                    using (SelectionForm.SelectionForm sf = new SelectionForm.SelectionForm(DataNames, "Select " + set + " dataset", "Select " + set + " for Blender", false))
                    {
                        sf.ShowDialog();
                        if (sf.SelectedItems == null || sf.SelectedItems.Count != 1)
                            return;
                        else
                            foreach (string selected in sf.SelectedItems)
                                tempDataSets.Add(DataSets[DataNames.IndexOf(selected)]);
                    }
                }
            }
            else
                tempDataSets.AddRange(DataSets);

            // Set size of spheres
            int size = 1;
            string ret = Microsoft.VisualBasic.Interaction.InputBox("Set size of spheres (default = 1: ");
            if (ret != "")
                size = Convert.ToInt16(ret);


            // Setup datasets in python format
            string PythonX = "[";
            string PythonY = "[";
            string PythonZ = "[";
            for (int i = 0; i < tempDataSets[0].Count; i++)
            {
                PythonX += tempDataSets[0][i].ToString() + ", ";
                PythonY += tempDataSets[1][i].ToString() + ", ";
                PythonZ += tempDataSets[2][i].ToString() + ", ";
            }

            PythonX += "]";
            PythonY += "]";
            PythonZ += "]";


            string TemplatePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\BlenderPlotter.py";
            string[] lines = File.ReadAllLines(TemplatePath);
            List<string> newlines = new List<string>();

            foreach (string line in lines)
            {
                string templine = line;
                if (line.Contains("\"*x*\""))
                    templine = line.Replace("\"*x*\"", PythonX);
                else if (line.Contains("\"*y*\""))
                    templine = line.Replace("\"*y*\"", PythonY);
                else if (line.Contains("\"*z*\""))
                    templine = line.Replace("\"*z*\"", PythonZ);
                else if (line.Contains("*s*"))
                    templine = line.Replace("*s*", size.ToString());

                newlines.Add(templine);
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Select destination for Blender script";
                sfd.Filter = "Python Scripts|*.py";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                    File.WriteAllLines(sfd.FileName, newlines.ToArray());
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            GenerateBlenderScript();
        }
    }
}
