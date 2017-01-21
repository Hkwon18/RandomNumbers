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

namespace RandomNumbers
{
    public partial class RandomNumbersForm : Form
    {
        public RandomNumbersForm()
        {
            InitializeComponent();
        }

        public static void FisherYatesShuffle(List<int> orderedList)
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

        private static void PrintList(List<int> randomList)
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "RandomList.txt");
            TextWriter tw = new StreamWriter(outputPath);
            foreach (var num in randomList)
                tw.WriteLine(num.ToString());
            tw.Close();
        }

        private void GenerateClick(object sender, EventArgs e)
        {
            List<int> randomList = Enumerable.Range(1, 10000).ToList();
            FisherYatesShuffle(randomList);
            PrintList(randomList);
        }

    }
}
