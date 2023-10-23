using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows.Forms;



namespace CURD_operation_win
{
  

    public partial class mdiform : Form
    {
      
        public mdiform()
        {
            InitializeComponent();
            my_setting s1 = new my_setting();
          

        }
       

        
        read rd = new read();
        private void ReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCloseAll(3);
            rd.MdiParent = mdiform.ActiveForm;
            rd.Show();
        }

        update up = new update();        
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCloseAll(2);
            up.MdiParent = mdiform.ActiveForm;
            up.Show();
        }

        create ct = new create();
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCloseAll(1);
            ct.MdiParent = mdiform.ActiveForm;
            ct.Show();
        }

        delete dl = new delete();
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            myCloseAll(4);
            dl.MdiParent = mdiform.ActiveForm;
            dl.Show();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection con = my_setting.myset();

            try
            {    con.Open();               
                MessageBox.Show(" Connection Build Succesfully  ", " Testing Connection ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                con.Close();
            }
            catch
            {   
                MessageBox.Show(" Error : Connection Failed , Check Database and Server", " Testing Connection ", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            }

        }

        public void myCloseAll(int num)
        {

            if (ct.IsMdiChild && num != 1)
            {
                ct.Close();
                ct = new create();
            }

            if (up.IsMdiChild && num!=2)
            {
                up.Close();
                up = new update();
            }
            
            if (rd.IsMdiChild && num != 3)
            {
                rd.Close();
                rd = new read();
            }
            if (dl.IsMdiChild && num != 4)
            {
                dl.Close();
                dl = new delete();
            }
        }

       
    }

    // public static void myset()

    public class my_setting
    {

        // public static MySqlConnection conn_set = new MySqlConnection("server=localhost;uid=root;pwd='';database=winform");
       

        public static MySqlConnection myset()
        {
            MySqlConnection myconset;
            myconset = new MySqlConnection("server=localhost;uid=root;pwd='';database=winform");
              try
            {
                     myconset.Open();
            }
            catch
            {
                MessageBox.Show(" error in Connection ,Go in mdiform.cs change mysql config details");

            }

            myconset.Close();
            return myconset;
        }

       

    }

}
