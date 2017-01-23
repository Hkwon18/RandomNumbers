using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RandomNumbers
{
    public partial class RandomNumbersForm : Form
    {
        public RandomNumbersForm()
        {
            InitializeComponent();
            string filePath = getFilePath();
            if (File.Exists(filePath))
            {
                RandomizeButton.Enabled = true;
                OpenListButton.Enabled = true;
                ResultTextBox.Text = "Welcome! Would you like to randomize the existing list?";
            }
            else
            {
                RandomizeButton.Enabled = false;
                OpenListButton.Enabled = false;
                ResultTextBox.Text =
                    "Welcome! A list textfile does not currently exist. Click \"Create Sorted List\" to create a new file";
            }
        }

        private string getFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "RandomList.txt");
        }

        private List<int> CreateSortedList()
        {
            List<int> randomList = Enumerable.Range(1, 10000).ToList();
            RandomizeButton.Enabled = true;
            OpenListButton.Enabled = true;
            return randomList;
        }

        private void PrintList(List<int> randomList)
        {
            string outputPath = getFilePath();
            TextWriter tw = new StreamWriter(outputPath);
            foreach (var num in randomList)
            {
                tw.WriteLine(num.ToString());
            }
            tw.Close();
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

        public void FisherYatesShuffle(List<int> orderedList)
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
        }

        private void CreateSortedButtonClick(object sender, EventArgs e)
        {
            List<int> sortedList = CreateSortedList();
            PrintList(sortedList);
            string filePath = getFilePath();
            if (File.Exists(filePath))
            {
                RandomizeButton.Enabled = true;
                OpenListButton.Enabled = true;
                ResultTextBox.Text = "Sorted list created.";
            }
        }

        private void RandomizeListButtonClick(object sender, EventArgs e)
        {
            List<int> orderedList = ReadList();
            if (orderedList != null)
            {
                FisherYatesShuffle(orderedList);
                PrintList(orderedList);
                ResultTextBox.Text = "Randomized! Click \"Open List\" to see the results!";
            }
            else
            {
                ResultTextBox.Text = "No valid list was found. Please click \"Create List\"";
            }
        }

        private void OpenListButton_Click(object sender, EventArgs e)
        {
            string filePath = getFilePath();
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }


    }
}
