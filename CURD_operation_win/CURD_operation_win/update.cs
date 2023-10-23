using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CURD_operation_win
{
    public partial class update : Form
    {
        MySqlConnection con = my_setting.myset();
        MySqlCommand cmd = null;
        string cmdString = "";

        public update()
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

        int myrow = 0;
        int mycol = 0;
        String temp_val = "";

        private void dg1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            myrow = e.RowIndex;
            mycol = e.ColumnIndex;
            temp_val = dg1.Rows[myrow].Cells[mycol].Value.ToString();
        }

       

        int temp = 0;

        private void dg1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            String id;
            String data;

            String update_val = dg1.Rows[myrow].Cells[mycol].Value.ToString();

            if (temp > 2)
            {
                id = dg1.Rows[myrow].Cells[0].Value.ToString();
                data = dg1.Rows[myrow].Cells[mycol].Value.ToString();

                String Show_message = "";


                if (mycol == 0 &&  temp_val != update_val)
                {
                    dg1.Rows[myrow].Cells[mycol].Value = temp_val;
                
                    MessageBox.Show(" ID Cannot be Changed ", " Invalid Operations ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                }


                if (update_val != null && temp_val!= update_val && mycol!=0 )
                {
                    if (mycol == 1)
                    {
                        cmdString = " update empinfo set name = '" + data + "' where id = '" + id + "' ; ";
                        Show_message = " Name : " + data + " is updated Successfully !! ";
                    }
                    else if (mycol == 2)
                    {
                        cmdString = " update empinfo set salary = '" + data + "' where id = '" + id + "' ; ";
                        Show_message = " Salary : " + data + " Rs , is updated Successfully !! ";
                    }
                    else if (mycol == 3)
                    {
                        cmdString = " update empinfo set language = '" + data + "' where id = '" + id + "' ; ";
                        Show_message = " Programming language : " + data + " , is updated Successfully !! ";
                    }
                    else if (mycol == 4)
                    {
                        cmdString = " update empinfo set address = '" + data + "' where id = '" + id + "' ; ";
                        Show_message = " Address : " + data + " , is updated Successfully !! ";
                    }

                    con.Open();
                    cmd = new MySqlCommand(cmdString, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(Show_message);

                }

            }
            else
            {
                temp++;
            }
        }
    }
}
