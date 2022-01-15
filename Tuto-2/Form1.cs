using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuto_2
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier; 

        int dividend;
        int divisor; 

        int timeLeft; 

        public void StartTheQuiz()
        {
            addend1 = random.Next(51);
            addend2 = random.Next(51);
            plusLeftLabel.Text = addend1.ToString(); 
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;


            minuend = random.Next(1, 101);
            subtrahend = random.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = random.Next(2, 11);
            multiplier = random.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = random.Next(2, 11);
            int temp = random.Next(2, 11);
            dividend = divisor * temp;
            devidedLeftLabel.Text = dividend.ToString();
            devidedRightLabel.Text = divisor.ToString();
            quotient.Value = 0; 

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start(); 
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && 
                (minuend - subtrahend == difference.Value)&&
                (multiplicand * multiplier == product.Value)&&
                (dividend / divisor == quotient.Value))
                return true;
            return false; 
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers correct!", "Congrats !!");
                startButton.Enabled = true; 
            }
            if(timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft == 5)
                    timeLabel.BackColor = Color.Red; 
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplier * multiplicand;
                quotient.Value = dividend / divisor; 
                startButton.Enabled = true; 
            }
        }

        private void answer_enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown; 
            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer); 
            }
        }
    }
}
