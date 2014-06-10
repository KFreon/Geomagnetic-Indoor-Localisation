using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifier
{
    class MainDataStructure
    {
        List<string> mapData;
        List<string> testData;
        List<string> solnData;

        List<object> Map = new List<object>();
        List<TestPoint> Tests = new List<TestPoint>();

        bool Multisensor = false;

        public struct TestPoint
        {
            public List<object> Data;
            public int ExpectedPoint;
            public int ExpectedDirection;
            public int CalculatedPoint;
            public int CalculatedDirection;
            public double CalculatedMin;
            public int xCoord;
            public int yCoord;
            public List<object> CalculatedData;
        }

        public MainDataStructure(string mapFile, string testFile, string solnFile)
        {
            LoadData(mapFile, solnFile, testFile);
            OrganiseData();
        }

        public void LoadData(string mapFile, string solnFile, string testFile)
        {
            if (!File.Exists(mapFile))
                throw new FileNotFoundException("Map file not found\n" + mapFile);

            if (!File.Exists(solnFile))
                throw new FileNotFoundException("Soln file not found\n" + solnFile);

            if (!File.Exists(testFile))
                throw new FileNotFoundException("Test file not found\n" + testFile);


            mapData = new List<string>(File.ReadAllLines(mapFile));
            solnData = new List<string>(File.ReadAllLines(solnFile));
            testData = new List<string>(File.ReadAllLines(testFile));
        }


        /// <summary>
        /// Organises data into Lists.
        /// </summary>
        public void OrganiseData()
        {
            // MAP
            List<object> point = new List<object>();
            foreach (string line in mapData)
            {
                switch (line)
                {
                    // Add point to map if end of data
                    case "": 
                        if (point.Count != 0)
                        {
                            Map.Add(point);
                            point = new List<object>();
                        }
                        break;
                    default:
                        point.AddRange(AddPoint(line));
                        break;
                }
            }

            // Add final point
            if (!Map.Contains(point) && point.Count != 0)
                Map.Add(point);


            // TESTS AND SOLNS
            TestPoint tp = new TestPoint();
            tp.Data = new List<object>();
            int solnCount = 0;
            foreach (string line in testData)
            {
                if (line == "")
                {
                    if (tp.Data.Count != 0)
                    {
                        string[] bits = solnData[solnCount].Split(' ');
                        tp.ExpectedPoint = Convert.ToInt32(bits[0]);
                        tp.ExpectedDirection = (bits.Length == 1) ? 0 : Convert.ToInt32(bits[1]);
                        solnCount++;
                        Tests.Add(tp);
                        tp = new TestPoint();
                        tp.Data = new List<object>();
                    }
                }
                else
                    tp.Data.AddRange(AddPoint(line));   
            }

            // Add final point
            if (!Tests.Contains(tp) && tp.Data.Count != 0)
            {
                if (solnCount != solnData.Count)
                {
                    string[] bits = solnData[solnCount].Split(' ');
                    tp.ExpectedPoint = Convert.ToInt32(bits[0]);
                    tp.ExpectedDirection = (bits.Length == 1) ? 0 : Convert.ToInt32(bits[1]);
                    Tests.Add(tp);
                }
            }
        }


        /// <summary>
        /// Returns new point from line of data.
        /// </summary>
        /// <param name="line">Data line to parse.</param>
        /// <returns>List of data of new point.</returns>
        public List<object> AddPoint(string line)
        {
            List<object> point = new List<object>();

            if (line.Contains('|'))
            {
                Multisensor = true;

                // Split into seperate sensors
                string[] parts = line.Split('|');
                List<object> sensors = new List<object>();
                foreach (string part in parts)
                    sensors.Add(AddDirection(part));

                // Add to point and reset sensor
                point.Add(sensors);
                sensors = new List<object>();
            }
            else
            {
                // Add 3D readings of 1 sensor to list
                List<double> direction = AddDirection(line);
                point.Add(direction);
            }
            return point;
        }


        /// <summary>
        /// Returns List of direction data from line of file.
        /// </summary>
        /// <param name="line">Line to parse.</param>
        /// <returns>List of doubles of direction data.</returns>
        public List<double> AddDirection(string line)
        {
            List<double> direction = new List<double>();
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            direction.Add(Convert.ToDouble(parts[0]));
            direction.Add(Convert.ToDouble(parts[1]));
            direction.Add(Convert.ToDouble(parts[2]));
            return direction;
        }


        /// <summary>
        /// Returns number of Test points loaded.
        /// </summary>
        /// <returns>Number of Tests loaded.</returns>
        public int NumTests()
        {
            return Tests.Count;
        }


        /// <summary>
        /// Returns number of Map points.
        /// </summary>
        /// <returns>Number of Map points.</returns>
        public int NumMapPts()
        {
            return Map.Count;
        }


        /// <summary>
        /// Returns number of orientations in each Test.
        /// </summary>
        /// <returns>Number of orientations in Tests.</returns>
        public int NumDirecs()
        {
            return Tests[0].Data.Count;
        }


        public TestPoint GetTestPoint(int ind)
        {
            return Tests[ind];
        }

        public void SetTest(int ind, TestPoint rep)
        {
            Tests[ind] = rep;
        }


        /// <summary>
        /// Returns tests as single depth points.
        /// </summary>
        /// <param name="testInd">Orientation to use.</param>
        /// <param name="simNum">Number of sensors to simulate.</param>
        /// <returns>Tests as list of single depth points.</returns>
        public List<List<double>> GetFlattenedTests(int testInd, int simNum)
        {
            int simIncrement = (simNum == 0) ? Tests[0].Data.Count : Tests[0].Data.Count / simNum;
            if (simIncrement == 0)
                simIncrement = 1;
            List<List<double>> retval = new List<List<double>>();

            // Loop over all test points
            foreach (TestPoint tp in Tests)
            {
                List<double> temp = new List<double>();
                // Loop over orientations
                for (int i = 0; i < tp.Data.Count; i++)
                {
                    if (testInd != -1 && testInd != i)
                        continue;

                    if (simNum != 0)
                    {
                        int HalfCount = int.MaxValue;
                        for (int j = 0; j < tp.Data.Count; j++)
                        {
                            int count = 0;
                            try
                            {
                                count = ((List<object>)tp.Data[j]).Count;
                            }
                            catch
                            {
                                count = ((List<double>)tp.Data[j]).Count;
                            }
                            // If half other half already exists, skip it
                            if (count == 2)
                                HalfCount = tp.Data.Count / simIncrement -1;
                            if (j % simIncrement != 0)
                                continue;
                            if (j > HalfCount)
                                continue;

                            List<object> herp = StringifyList((IEnumerable)tp.Data[j]);
                            for (int k = 0; k < herp.Count; k++)
                                temp.Add((double)herp[k]);
                        }
                    }
                    else
                    {
                        List<object> herp = StringifyList((IEnumerable)tp.Data[i]);
                        for (int j = 0; j < herp.Count; j++)
                            temp.Add((double)herp[j]);
                    }
                }

                retval.Add(temp);
            }
            return retval;
        }


        /// <summary>
        /// Returns map as single layer points.
        /// </summary>
        /// <param name="simNum">Number of sensors to simulate.</param>
        /// <returns>Map as single depth points.</returns>
        public List<List<double>> GetFlattenedMap(int simNum, int ExpOrient)
        {
            List<List<double>> retval = new List<List<double>>();
            List<object> initial = (List<object>)Map[0];
            int simIncrement = (simNum == 0) ? initial.Count : initial.Count / simNum;
            if (simIncrement == 0)
                simIncrement = 1;
            foreach (List<object> point in Map)
            {
                List<double> temp = new List<double>();
                for (int i = 0; i < point.Count; i++)
                {
                    if (simNum != 0)
                    {
                        int HalfCount = int.MaxValue;
                        for (int j = 0; j < point.Count; j++)
                        {
                            int count = 0;
                            try
                            {
                                count = ((List<object>)point[j]).Count;
                            }
                            catch
                            {
                                count = ((List<double>)point[j]).Count;
                            }

                            // If half other half already exists, skip it
                            if (count == 2)
                                HalfCount = point.Count / simIncrement - 1;
                            if (j % simIncrement != 0)
                                continue;
                            if (j > HalfCount)
                                continue;

                            List<object> herp = StringifyList((IEnumerable)point[j]);
                            for (int k = 0; k < herp.Count; k++)
                                temp.Add((double)herp[k]);
                        }
                    }
                    else
                    {
                        if (ExpOrient == -1 || ExpOrient == i)
                        {
                            List<object> herp = StringifyList((IEnumerable)point[i]);
                            for (int j = 0; j < herp.Count; j++)
                                temp.Add((double)herp[j]);
                        }                        
                    }
                    
                }
                retval.Add(temp);
            }
            return retval;
        }


        /// <summary>
        /// Returns single layer list from list of any depth.
        /// </summary>
        /// <param name="list">List to make single layer.</param>
        /// <returns>List of single depth.</returns>
        public List<object> StringifyList(object list)
        {
            ICollection coll = list as ICollection;
            IEnumerator ien = coll.GetEnumerator();
            ien.Reset();
            List<object> retval = new List<object>();
            while (ien.MoveNext() != false)
            {
                Type type = ien.Current.GetType();
                if (type == typeof(double))
                    retval.Add(Convert.ToDouble(ien.Current));
                else
                {
                    retval.AddRange(StringifyList(ien.Current));
                }
            }
            
            return retval;
        }
    }
}
