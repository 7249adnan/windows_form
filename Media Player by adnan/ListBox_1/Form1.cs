using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ListBox_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Blue;

            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = " Uploading video From List 1 to 2 ";

                String tempI = listBox1.SelectedItem.ToString();

               int index= listBox1.SelectedIndex;
              

                int total = listBox1.Items.Count;

             

                if (total > 1 && index< total-1)
                {
                    listBox1.SelectedIndex = index + 1;
                }
                else if ((index+1) == total){

                    listBox1.SelectedIndex = index-1;
                }
                else
                {
                    listBox1.SelectedIndex = index;
                }
                

                listBox1.Items.Remove(tempI); 
                listBox2.Items.Add(tempI);

            }

           
        }

        private void button2_Click(object sender, EventArgs e)

        {

            textBox1.ForeColor = Color.Blue;

            if (listBox2.SelectedItem != null)
            {
                String tempI = listBox2.SelectedItem.ToString();

                int index = listBox2.SelectedIndex;


                int total = listBox2.Items.Count;

              

                if (total > 1 && index < total - 1)
                {
                    listBox2.SelectedIndex = index + 1;
                }
                else if ((index + 1) == total)
                {
                   

                    listBox2.SelectedIndex = index - 1;
                   
                }
                else
                {
                    listBox2.SelectedIndex = index;
                }

                textBox1.Text = " Taking video From List 2 to 1 ";

                listBox2.Items.Remove(tempI);
                listBox1.Items.Add(tempI);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fd1.ShowDialog() == DialogResult.OK){

                textBox1.Text = "File Choosed Successfully ";
                textBox1.ForeColor = Color.Green;
                listBox1.Items.Add(fd1.FileName);
              
            }
            else
            {
                textBox1.Text = " Choose Correct file  ";
                textBox1.ForeColor = Color.Red;
            }


        }
        int temp = 0;
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

         


            if (listBox2.SelectedItem != null)
            {

                String tempI2 = listBox2.SelectedItem.ToString();
                textBox1.ForeColor = Color.Blue;

               
                string lastFour = tempI2.Substring(tempI2.Length - 4);

               



                textBox1.Text = lastFour;

                if (lastFour == ".mp4")
                {
                    mdp1.URL = tempI2;
                    mdp1.Ctlcontrols.play();
                    textBox1.Text = "Playing Current Selected File ";
                    temp = 0; 
                }
                else
                {   
                    listBox2.Items.Remove(tempI2);
                }
                

            }
            else
            {
               
                    textBox1.Text = " Choose Correct file with .mp4 Extension  ";
                    textBox1.ForeColor = Color.Red;

            }


           
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
