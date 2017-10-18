using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiceAverages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool trialText = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void totalTrialsBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (trialText)
            {
                totalTrialsBox.Text = "";
                totalTrialsBox.Foreground = Brushes.Black;
                totalTrialsBox.FontStyle = FontStyles.Normal;
            }
            trialText = false;
        }

        private void button_Average_Click(object sender, RoutedEventArgs e)
        {
            int diceNum;
            int diceSize;
            int rollsNum;
            int totalTrials;
            
            if (!int.TryParse(diceNumBox.Text, out diceNum))
            {
                diceNum = 0;
            }
            diceNumBox.Text = diceNum.ToString();

            if (!int.TryParse(diceSizeBox.Text, out diceSize))
            {
                diceSize = 0;
            }
            diceSizeBox.Text = diceSize.ToString();

            if (!int.TryParse(rollsNumBox.Text, out rollsNum))
            {
                rollsNum = 0;
            }
            rollsNumBox.Text = rollsNum.ToString();

            if (!int.TryParse(totalTrialsBox.Text, out totalTrials))
            {
                totalTrials = 0;
            }
            totalTrialsBox.Text = totalTrials.ToString();

            Random rand = new Random();
            double[] averageList = new double[totalTrials];
            for (int i = 0; i < totalTrials; i++)
            {
                int dmgSum = 0;
                for (int j = 0; j < rollsNum; j++)
                {
                    for (int k = 0; k < diceNum; k++)
                    {
                        dmgSum += rand.Next(1, diceSize + 1);
                    }
                }
                averageList[i] = dmgSum;
            }

            double average;
            if (averageList.Length > 0)
            {
                average = averageList.Average();
            }
            else
            {
                average = 0;
            }
            average = Math.Round(average, 2);
            averageBox.Text = average.ToString();
        }
    }
}
