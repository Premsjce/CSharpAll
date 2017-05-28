using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitSampleDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            int number1, number2;
            bool validValue1, validValue2;


            //Doing some basic validations
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter the value and try again");
                return;
            }
            else
            {
                validValue1 = int.TryParse(textBox1.Text, out number1);
                validValue2 = int.TryParse(textBox2.Text, out number2);
            }

            if (validValue1 && validValue2)
            {
                //Using Threading
                //Thread workerThread = new Thread(BeginCalulcate);
                //workerThread.Start();


                //Using Async and Await specifiers
                int output = await Task.Run(() =>
                {
                    //Time consuming calculation
                    Thread.Sleep(5000);
                    return (number1 + number2);
                });

                textBox3.Text = output.ToString();
            }
            else
            {
                MessageBox.Show("Enter the valid value and try again");
                return;
            }


        }

        //Used in Multi Threadin
        private void BeginCalulcate()
        {
            //Time consuming calculation
            Thread.Sleep(3000);
            int numA = int.Parse(textBox1.Text);
            int numB = int.Parse(textBox2.Text);
            int resutl = numA + numB;
            //textBox3.Text = resutl.ToString();

            this.Invoke(new EventHandler(delegate
            {
                textBox3.Text = resutl.ToString();
            }));


        }
    }
}

