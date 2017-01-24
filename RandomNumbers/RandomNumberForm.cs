using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RandomNumbers
{
    public partial class RandomNumbersForm : Form
    {
        public RandomNumbersForm()
        {
            InitializeComponent();
            EnableControls();
            string filePath = getFilePath();
            if (File.Exists(filePath))
            {
                ResultTextBox.Text = 
                    timeStampMessage("Welcome! Would you like to create a new sorted list or randomize the existing list?");
            }
            else
            {
                ResultTextBox.Text =
                    timeStampMessage("Welcome! A list textfile does not currently exist. Click \"Create Sorted List\" to create a new file");
            }
        }

        private void EnableControls()
        {
            bool fileExists = File.Exists(getFilePath());
            RandomizeButton.Enabled = fileExists;
            OpenListButton.Enabled = fileExists;
            CreateSortedButton.Enabled = true;
        }

        private void DisableControls()
        {
            RandomizeButton.Enabled = false;
            OpenListButton.Enabled = false;
            CreateSortedButton.Enabled = false;
        }

        private string getFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "RandomList.txt");
        }

        private string timeStampMessage(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(DateTime.Now.ToString("h:mm:ss tt"));
            sb.Append("]: ");
            sb.Append(message);
            return sb.ToString();
        }

        private List<int> CreateSortedList()
        {
            List<int> randomList = Enumerable.Range(1, 10000).ToList();
            return randomList;
        }

        private bool PrintList(List<int> randomList)
        {
            string outputPath = getFilePath();
            TextWriter tw = new StreamWriter(outputPath);
            try
            {
                foreach (var num in randomList)
                {
                    tw.WriteLine(num.ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                tw.Close();
            }
        }

        private List<int> ReadList()
        {
            string inputPath = getFilePath();
            if (File.Exists(inputPath))
            {
                List<string> allLinesText = File.ReadLines(inputPath).ToList();
                return allLinesText.ConvertAll(int.Parse);
            }
            return null;
        }

        public bool FisherYatesShuffle(List<int> orderedList)
        {
            Random rng = new Random();
            int n = orderedList.Count;
            while (n > 0)
            {
                int k = rng.Next(n);
                n--;
                int temp = orderedList[n];
                orderedList[n] = orderedList[k];
                orderedList[k] = temp;
            }
            return true;
        }

        private void CreateSortedButtonClick(object sender, EventArgs e)
        {
            DisableControls();
            List<int> sortedList = CreateSortedList();
            bool success = PrintList(sortedList);
            if (success)
            {
                ResultTextBox.Text = timeStampMessage("Sorted list created.");
            }
            else
            {
                ResultTextBox.Text = timeStampMessage("Error. Sorted list could not be printed properly. Try again.");
            }
            EnableControls();
        }

        private void RandomizeListButtonClick(object sender, EventArgs e)
        {
            DisableControls();
            List<int> orderedList = ReadList();
            if (orderedList == null)
            {
                ResultTextBox.Text = timeStampMessage("No valid list was found. Please click \"Create List\"");
            }
            else
            {
                bool success = FisherYatesShuffle(orderedList);
                success = PrintList(orderedList);
                if (success)
                {
                    ResultTextBox.Text = timeStampMessage("Randomized! Click \"Open List\" to see the results!");
                }
                else
                {
                    ResultTextBox.Text = timeStampMessage("List could not be randomized and printed properly.");
                }
            }
            EnableControls();
        }

        private void OpenListButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            string filePath = getFilePath();
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
            }
            EnableControls();
        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
