using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CURD_operation_win
{
    public partial class create : Form
    {
        MySqlConnection myconn = my_setting.myset();
        MySqlCommand cmd = null;
        string cmdString = "";

        int last_id = 0;

        public create()
        {
            InitializeComponent();
        }


      
        private void create_Load(object sender, EventArgs e)
        {
            myconn.Open();

            using (var cmd1 = new MySqlCommand("SELECT * from empinfo ORDER BY id desc", myconn))
            {

                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        last_id = reader.GetInt32(0);

                        break;
                    }

                }

            }

            myconn.Close();

            last_id = last_id + 1;
            textBox1.Text = last_id.ToString();

            textBox1.ForeColor = Color.Green;

        }

      
        private void button1_Click(object sender, EventArgs e)
        {

            String id = textBox1.Text;
            String name = textBox2.Text;
            String salary = textBox3.Text;
            String lang = textBox4.Text;
            String address = textBox5.Text;

          
            if (id != "" && name != "" && salary != "" && lang != "" && address != "")
            {

                cmdString = " INSERT INTO `empinfo` (`id`, `name`, `salary`, `language`, `address`) VALUES('"+id+"', '"+ name +"', '"+ salary +"', '"+ lang +"', '"+address+" ');";

                myconn.Open();
                cmd = new MySqlCommand(cmdString, myconn);
                cmd.ExecuteNonQuery();
                myconn.Close();

                MessageBox.Show(" Data Inserterd Succesfully ");

                last_id = last_id + 1;
                textBox1.Text = last_id.ToString();

                textBox2.Text="";
               textBox3.Text = "";
               textBox4.Text = "";   
               textBox5.Text = "";

            }
            else
            {
                MessageBox.Show(" Fill All Detail , Any TextBox Should not be Blank !!   ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

      
    }
}
