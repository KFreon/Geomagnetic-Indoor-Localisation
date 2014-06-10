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
    public partial class ClassifierForm : Form
    {
        MainDataStructure MainData;
        int testInd = -1;
        int limit = -1;
        int lowerlimit = -1;
        int CurrentLocation = -1;

        public ClassifierForm()
        {
            InitializeComponent();
            List<string> args = new List<string>(Environment.GetCommandLineArgs());
            if (args.Count == 4)
            {
                args.RemoveAt(0);
                LoadData(args);


                // TESTING LIBRARY
                //GradientAscent();


                KNNSearch();
                WriteResults();
            }
        }


        private double Sigmoid(List<double> data, double weight)
        {
            double z = 0;
            for (int i = 0; i < data.Count; i++)
                z += data[i] * weight;
            return 1.0 / (1 + Math.Exp(-z));
        }


        private void GradientAscent()
        {
            double alpha = 0.01;
            int MaxLoops = 500;

            int simNum = Convert.ToInt32(SimulateBox.Text);
            List<List<double>> Tests = MainData.GetFlattenedTests(testInd, simNum);
            List<List<double>> map = MainData.GetFlattenedMap(simNum, -1);


            List<double> Weights = new List<double>();
            for (int i = 0; i < map.Count; i++)
                Weights.Add(1);

            // Loop for specified time or until finished
            for (int i = 0; i < MaxLoops; i++)
            {
                // Get outputs
                List<double> sigmoids = new List<double>();
                for (int j = 0; j < Weights.Count; i++)
                    sigmoids.Add(Sigmoid(map[j], Weights[j]));

                /*List<double> error = GetError(sigmoids, desired);
                Weights = UpdateWeights(error, Weights, map, alpha);*/
            }
        }

        private List<double> GetError(List<double> outputs, List<double> desired)
        {
            List<double> error = new List<double>();
            for (int i = 0; i < outputs.Count; i++)
                error.Add(desired[i] - outputs[i]);

            return error;   
        }

        private List<double> UpdateWeights(List<double> error, List<double> oldweights, List<List<double>> data, double alpha)
        {
            List<double> newweights = new List<double>();
            for (int i = 0; i < data.Count; i++)
                for (int j = 0; j < data[i].Count; j++)
                    newweights.Add(oldweights[i] + alpha * data[i][j] * error[i]);

            return newweights;
        }


        public bool LoadData(List<string> args = null)
        {
            List<string> filenames = new List<string>();
            

            // If no cmd line provided, ask
            if (args == null)
            {
                // Make list of things for OFD to show as title
                List<string> names = new List<string>();
                names.Add("Select Map file");
                names.Add("Select Tests file");
                names.Add("Select Soln File");

                // Display ofd and load files
                for (int i = 0; i < 3; i++)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Title = names[i];
                        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            filenames.Add(ofd.FileName);
                        else
                            return false;
                    }
                }
            }
            else
                filenames.AddRange(args);

            if (filenames.Count == 3)
            {
                MainData = new MainDataStructure(filenames[0], filenames[1], filenames[2]);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Performs a sort of K Nearest Neighbour.
        /// </summary>
        public void KNNSearch()
        {
            CurrentLocation = -1;
            limit = Convert.ToInt32(UpperTextBox.Text);
            lowerlimit = Convert.ToInt32(LowerTextBox.Text);
            testInd = Convert.ToInt32(TestOrientBox.Text);

            int simNum = Convert.ToInt32(SimulateBox.Text);
            List<List<double>> Tests = MainData.GetFlattenedTests(testInd, simNum);
            List<List<double>> map = MainData.GetFlattenedMap(simNum, -1);
            List<List<List<double>>> Distances = new List<List<List<double>>>();

            // Get distance metrics
            for (int i = 0; i < Tests.Count; i++)
                Distances.Add(GetDistWithDirec(map, Tests[i]));

            // Perform search
            int currentTest = 0;
            foreach (List<List<double>> test in Distances)
            {
                // Get minimums
                List<int> MinInds = new List<int>();
                List<double> Mins = new List<double>();
                foreach (List<double> orientation in test)
                {
                    List<object> details = GetMin(limit, orientation.Count, orientation);
                    Mins.Add((double)details[0]);
                    MinInds.Add((int)details[1]);
                }

                // Find min orientation
                double TotalMin = Mins.Min();
                int OrientationInd = Mins.IndexOf(TotalMin);
                int PointInd = MinInds[OrientationInd];

                // First test must be 0 (?)
                if (currentTest == 0)
                    PointInd = 0;


                MainDataStructure.TestPoint point = MainData.GetTestPoint(currentTest);
                point.CalculatedPoint = PointInd;
                point.CalculatedDirection = OrientationInd;
                point.CalculatedMin = TotalMin;
                MainData.SetTest(currentTest, point);
                CurrentLocation = PointInd;


                Console.WriteLine("Test " + currentTest + ":  Expected: " + point.ExpectedPoint + "  Got: " + PointInd + " with " + TotalMin);
                Console.WriteLine("                Direction -> Expected: " + point.ExpectedDirection + "  Got: " + OrientationInd);
                Console.WriteLine("All mins");
                for (int j = 0; j < Mins.Count; j++)
                    Console.WriteLine("Min:" + Mins[j] + "  at: " + MinInds[j]);
                Console.WriteLine("---------------------------" + Environment.NewLine);
                currentTest++;
            }
        }


        /// <summary>
        /// Returns list of minimums for each orientation
        /// </summary>
        /// <param name="limit">Max dist forward to look</param>
        /// <param name="distCount">Number of orientations</param>
        /// <param name="currentDist">Current orientation</param>
        /// <returns>List of minimums for each orientation</returns>
        private List<object> GetMin(int limit, int distCount, List<double> currentDist)
        {
            //int min = (CurrentLocation < limit) ? 0 : CurrentLocation - (limit/2);
            int min = (CurrentLocation < lowerlimit) ? 0 : CurrentLocation - lowerlimit;
            int max = (CurrentLocation < distCount - limit) ? ((CurrentLocation == -1) ? limit : CurrentLocation + limit) : distCount;

            // limit = 0 => free range
            if (limit == 0)
            {
                min = 0;
                max = distCount;
            }

            List<object> retval = new List<object>();
            //double minimum = currentDist.Min();
            double minimum = int.MaxValue;
            for (int j = min; j < max; j++)
                if (currentDist[j] < minimum)
                    minimum = currentDist[j];
            /*List<double> temp = new List<double>(currentDist);
            temp.Sort();
            minimum = temp[0];
            for (int i = 0; i < temp.Count; i++)
                Console.WriteLine(currentDist.IndexOf(temp[i]));*/
                
            int ind = currentDist.IndexOf(minimum);

            retval.Add(minimum);
            retval.Add(ind);
            return retval;
        }


        /// <summary>
        /// Returns distance metric for a test at every orientation.
        /// </summary>
        /// <param name="map">Map data</param>
        /// <param name="test">Test to check</param>
        /// <returns>Distances for a test to all map at an orientation</returns>
        public List<List<double>> GetDistWithDirec(List<List<double>> map, List<double> test)
        {
            List<List<double>> retval = new List<List<double>>();
            List<List<double>> tempMap = new List<List<double>>(map);

            int numdirecs = MainData.NumDirecs();
            for (int i = 0; i < numdirecs; i++)
            {
                List<double> temp = GetDistancesFromPoint(test, tempMap);
                retval.Add(temp);

                // Break if north only
                if (NorthCheckBox.Checked)
                    break;

                // Rotate Map
                int count = tempMap.Count;
                for (int j = 0; j < count; j++)
                {
                    List<double> current = tempMap[j];
                    double front = current[0];
                    current.RemoveAt(0);
                    current.Add(front);
                    tempMap[j] = current;
                }
            }

            return retval;
        }


        /// <summary>
        /// Returns test point distance to all map points.
        /// </summary>
        /// <param name="test">Test to get distances</param>
        /// <param name="map">Map data</param>
        /// <returns>Distances of test to all map pts</returns>
        public List<double> GetDistancesFromPoint(List<double> test, List<List<double>> map)
        {
            List<double> retval = new List<double>();
            foreach (List<double> MapElement in map)
            {
                double sum = 0;
                double tempsum = 0;
                

                // Loop over x, y, z
                for (int i = 0; i < 3; i++)
                {
                    // Loop over all elements for the specified axis
                    for (int j = 0; j < test.Count; j+=3)
                    {
                        tempsum += test[i + j] - MapElement[i + j];
                        //tempsum += Math.Abs(test[i + j]) - Math.Abs(MapElement[i + j]);
                        //tempsum += Math.Pow(test[i+j] - MapElement[i+j], 2);
                        //tempsum += Math.Pow(Math.Abs(test[i+j]) - Math.Abs(MapElement[i+j]), 2);
                    }

                    sum += Math.Pow(tempsum, 2);
                    tempsum = 0;
                }

                
                /*for (int i = 0; i < test.Count; i++)
                {
                    if (i % 3 == 0)
                    {
                        sum += Math.Pow(tempsum, 2);
                        tempsum = 0;
                    }
                        

                    //tempsum += Math.Pow(Math.Abs(test[i]) - Math.Abs(MapElement[i]), (i % 3 == 0) ? 2 : 1);  // WORKS OK
                    //tempsum += Math.Pow(Math.Abs(test[i]) - Math.Abs(MapElement[i]), 2);   // DOESN'T WORK
                    //tempsum += Math.Pow(test[i] - MapElement[i], 2);                       // DOESN'T WORK
                    tempsum += Math.Pow(test[i] - MapElement[i], (i % 3 == 0) ? 2 : 1);    // WORKS GOOD
                }*/
                    
                retval.Add(sum);
            }
            return retval;
        }


        /// <summary>
        ///  Writes results of search to window.
        /// </summary>
        public void WriteResults()
        {
            int CompareLimit = Convert.ToInt32(CompareTextBox.Text);
            int CorrectNum = 0;
            int TotalCorrect = 0;
            int num = MainData.NumTests();

            for (int i = 0; i < num; i++)
            {
                MainDataStructure.TestPoint tp = MainData.GetTestPoint(i);
                int expectedPoint = tp.ExpectedPoint;
                double minimum = tp.CalculatedMin;
                int calculatedPoint = tp.CalculatedPoint;
                int calculatedDirection = tp.CalculatedDirection;
                int expectedDirection = (testInd == -1) ? tp.ExpectedDirection : testInd;
                string ptcorrect = (Math.Abs(calculatedPoint - expectedPoint) < CompareLimit) ? "TRUE" : "False";
                string dircorrect = (calculatedDirection == expectedDirection) ? "TRUE" : "False";
                string bothcorrect = (ptcorrect.Contains("TRUE") && dircorrect.Contains("TRUE")) ? "TRUE" : "False";
                rtb.AppendText("Test " + i + ":  Expected: " + expectedPoint + "   Got: " + calculatedPoint + "  with " + minimum + "  Expected Dir: " + expectedDirection + "  Got: " + calculatedDirection + "  Pt? " + ptcorrect + "  Dir? " + dircorrect + " Both? " + bothcorrect + Environment.NewLine);
                if (ptcorrect.Contains("TRUE"))
                    CorrectNum++;

                if (bothcorrect.Contains("TRUE"))
                    TotalCorrect++;
            }

            double ptpercent = (double)CorrectNum * 100.0 / (double)num;
            double bothpercent = (double)TotalCorrect * 100.0 / (double)num;
            rtb.AppendText(Environment.NewLine + "Score: " + CorrectNum + "\\" + num + "   " + ptpercent + '%');
            rtb.AppendText(Environment.NewLine + "Score: " + TotalCorrect + "\\" + num + "   " + bothpercent + '%');
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!LoadData())
                return;
            rtb.Clear();
            KNNSearch();
            WriteResults();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            rtb.Clear();
        }

        private void ExpOrientButton_Click(object sender, EventArgs e)
        {
            int expind = 0;
            string inp = Microsoft.VisualBasic.Interaction.InputBox("Which orientation to export?");
            if (inp == "")
                return;
            expind = Convert.ToInt32(inp);
            string path = "";
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                    path = fbd.SelectedPath;
            }

            List<List<double>> map = MainData.GetFlattenedMap(0, expind);
            List<string> lines = new List<string>();
            List<string> lines2 = new List<string>();
            foreach (List<double> mapelement in map)
            {
                lines.Add(mapelement[0] + "," + mapelement[1] + "," + mapelement[2]);
                if (mapelement.Count > 3)
                    lines2.Add(mapelement[3] + "," + mapelement[4] + "," + mapelement[5]);
            }

            File.WriteAllLines(path + "\\sensor1.txt", lines);
            if (lines2.Count != 0)
                File.WriteAllLines(path + "\\sensor2.txt", lines2);
        }

        private void RescanButton_Click(object sender, EventArgs e)
        {
            rtb.Clear();
            KNNSearch();
            WriteResults();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            Image img;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select image to open";
                ofd.Filter = "Images|*.png;*.jpg";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                    img = Image.FromFile(ofd.FileName);
            }
            ImageDisplay imd = new ImageDisplay(img);
            imd.Show();
        }

        private void PlotterButton_Click(object sender, EventArgs e)
        {
            TemporalPlotter.Form1 plotter = new TemporalPlotter.Form1();
            plotter.Show();
        }

        private void ExportMatlab_Click(object sender, EventArgs e)
        {
            testInd = Convert.ToInt32(TestOrientBox.Text);

            int simNum = Convert.ToInt32(SimulateBox.Text);
            List<List<double>> Tests = MainData.GetFlattenedTests(testInd, simNum);
            List<List<double>> map = MainData.GetFlattenedMap(simNum, -1);

            List<string> testlines = new List<string>();
            List<string> maplines = new List<string>();
            foreach (List<double> test in Tests)
            {
                string line = "";
                for (int i = 0; i < test.Count; i++)
                    line += test[i] + " ";
                testlines.Add(line);
            }

            foreach (List<double> m in map)
            {
                string line = "";
                for (int i = 0; i < m.Count; i++)
                    line += m[i] + " ";
                maplines.Add(line);
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "SELECT PREFIX TO MAP AND TEST FILES";
                sfd.Filter = "Text Files|*.txt";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string name = Path.GetFileNameWithoutExtension(sfd.FileName);
                    string path = Path.GetDirectoryName(sfd.FileName) + "\\";
                    File.WriteAllLines(path + name + "MAP.txt", maplines.ToArray());
                    File.WriteAllLines(path + name + "TESTS.txt", testlines.ToArray());
                }
            }
        }
    }
}
