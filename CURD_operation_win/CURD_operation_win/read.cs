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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CURD_operation_win
{
    public partial class read : Form
    {
        MySqlConnection con = my_setting.myset();
        
        MySqlCommand cmd = null;
        string cmdString = "";


        public read()
        {
            InitializeComponent();
            fillGrid();
            fillCombo();
            set_trackbar();


        }


        public void set_trackbar()
        {
            trackBar1.SetRange(1000, 100000);
            trackBar1.SmallChange = 1000;
            trackBar1.LargeChange = 2000;
            trackBar1.Visible = false;
            label3.Visible = false;
            label5.Visible = false;

            trackBar2.SetRange(1000, 100000);
            trackBar2.SmallChange = 1000;
            trackBar2.LargeChange = 2000;
            trackBar2.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

        }

        public void manage_size()
        {
            dg1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewColumn c1 = dg1.Columns[4];
            DataGridViewRow r1 = dg1.Rows[1];

            dg1.Width = c1.Width * dg1.ColumnCount + dg1.RowHeadersWidth + 120;
            dg1.Height = (dg1.RowCount + 2) * r1.Height - 7;

        }

        public void fillCombo()
        {

            con.Open();

            using (var cmd1 = new MySqlCommand("SHOW COLUMNS from empinfo", con))
            {

                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader.GetString(0));
                    }

                }

            }

            con.Close();

            comboBox1.SelectedIndex = 1;

        }

        public void fillGrid()
        {
            con.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter("Select * from empinfo;", con);

            DataTable dtb1 = new DataTable();
            adp.Fill(dtb1);

            dg1.DataSource = dtb1;


            dg1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewColumn c1 = dg1.Columns[4];
            DataGridViewRow r1 = dg1.Rows[1];

            dg1.Width = c1.Width * dg1.ColumnCount + dg1.RowHeadersWidth + 120;
            dg1.Height = (dg1.RowCount + 2) * r1.Height - 7;

            con.Close();



        }



        private void button1_Click(object sender, EventArgs e)
        {
            fillGrid();
        }


        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        String mykeydata = "";



        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            String myfind;
            String myfield;

            myfind = textBox1.Text + "%";

            myfield = comboBox1.SelectedItem.ToString();



            //SELECT* from empinfo WHERE salary >= 15000 AND salary <= 30000;

            if (myfield != "salary")
            {
                cmdString = " SELECT * FROM `empinfo` where " + myfield + " like '" + "%" + myfind + "' ;";
                // cmdString = " SELECT * FROM `empinfo` where name like 'a%' ;";
               
                con.Open();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmdString, con);

                DataTable dtb1 = new DataTable();
                adp.Fill(dtb1);

                dg1.DataSource = dtb1;

                con.Close();

                try
                {
                    manage_size();
                }
                catch
                {

                }

              

            }
         


        }

        private void read_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar1.SetRange(1000, 100000);
            trackBar1.SmallChange = 1000;

            trackBar1.LargeChange = 2000;
            //trackBar1.Size = new System.Drawing.Size(200, 600);

            trackBar1.Visible = true;

        }

        int min_value=0;
        int max_value=0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            label5.Text= trackBar1.Value.ToString(); 

            String myfield;

            myfield = comboBox1.SelectedItem.ToString();

            min_value = trackBar1.Value;
            

            //SELECT* from empinfo WHERE salary >= 15000 AND salary <= 30000;

            if (myfield == "salary" && min_value < max_value)
            {
                cmdString = " SELECT* from empinfo WHERE salary >= '" + min_value + "' AND salary <= '" + max_value + "';";

                // cmdString = " SELECT * FROM `empinfo` where name like 'a%' ;";
               
                con.Open();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmdString, con);

                DataTable dtb1 = new DataTable();
                adp.Fill(dtb1);

                dg1.DataSource = dtb1;

                con.Close();

                try
                {
                    manage_size();
                }
                catch
                {

                }

            }
            else if (min_value > max_value)
            {
                label5.Text = " Decrease The Min Value";
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myfield;

            myfield = comboBox1.SelectedItem.ToString();
            textBox1.Text = "";

            if (myfield == "salary")
            {
                trackBar1.Visible = true;
                trackBar2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                label2.Visible = false;
                textBox1.Visible = false;


            }
            else
            {
                trackBar1.Visible = false;
                trackBar2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                label2.Visible = true;
                textBox1.Visible = true;

            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            label6.Text = trackBar2.Value.ToString();

            String myfield;

            myfield = comboBox1.SelectedItem.ToString();

            max_value = trackBar2.Value;


            //SELECT* from empinfo WHERE salary >= 15000 AND salary <= 30000;

            if (myfield == "salary" && min_value<max_value)
            {
                cmdString = " SELECT* from empinfo WHERE salary >= '" + min_value + "' AND salary <= '" + max_value + "';";

                // cmdString = " SELECT * FROM `empinfo` where name like 'a%' ;";
               
                con.Open();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmdString, con);

                DataTable dtb1 = new DataTable();
                adp.Fill(dtb1);

                dg1.DataSource = dtb1;

                con.Close();

                try
                {
                    manage_size();
                }
                catch
                {

                }

            }
            else if (min_value > max_value)
            {
                label6.Text = " Increase The Max Value";
            }

        }
    }
}
