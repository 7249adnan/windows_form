using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CURD_operation_win
{
    public partial class delete : Form
    {
        MySqlConnection con = my_setting.myset();
        MySqlCommand cmd = null;
        string cmdString = "";
        public delete()
        {
            InitializeComponent();
            fillGrid();
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

      
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        public int Check_id(int id)
        {

            con.Open();

            using (var cmd1 = new MySqlCommand("SELECT * from empinfo ORDER BY id desc", con))
            {

                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                
                        if (id== reader.GetInt32(0))
                        {
                            con.Close();
                            return 1;
                        }
                        
                    }

                }

            }

            con.Close();

            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String id = textBox1.Text;
            if(id != "") {

             
                int c = Check_id(int.Parse(id));

                if (c == 1)
                {


                    con.Open();

                    cmdString = "DELETE FROM empinfo WHERE `empinfo`.`id` = '" + id + "'";

                    cmd = new MySqlCommand(cmdString, con);
                    cmd.ExecuteNonQuery();

                    textBox1.Text = "";


                    MessageBox.Show(" Success  ");
                    con.Close();

                    fillGrid();

                }
                else
                {
                    MessageBox.Show(" This ID Does not Exisit  ", " Invalid Operations ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                }

            }
            else
            {
                MessageBox.Show(" Fill the ID TextBox ", " Invalid Operations ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            }

        }
    }
}
