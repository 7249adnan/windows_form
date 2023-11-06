using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace treeView1
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=winform");

        MySqlCommand cmd = null;
        string cmdString = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sql_array();
        }

        String name = "";
        String str = "";
        String root = "";


        int[] myid_d = new int[50];
        String[] myname_d = new string[50];
        String[] myparent_d = new string[50];
        int mylen_d = 0;
        int ctr_d = 0;

        int[] Update_myid_d = new int[50];
        String[] Update_myname_d = new string[50];
        String[] Update_myparent_d = new string[50];
        int Update_mylen_d = 0;
        int Update_ctr_d = 0;

        // ----- SHOW TABLE SECTION OPEN -------

        public void sql_array()
        {
            ctr_d = 0;
            conn.Open();

            using (cmd = new MySqlCommand("Select * from mytree;", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myid_d[ctr_d] = reader.GetInt32(0);
                        myname_d[ctr_d] = reader.GetString(1).ToString();
                        myparent_d[ctr_d] = reader.GetString(2).ToString();

                        ctr_d++;
                    }

                }

            }

            mylen_d = ctr_d;

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("Select * from mytree;", conn);
            DataTable dtb1 = new DataTable();
            adp.Fill(dtb1);
            dg1.DataSource = dtb1;
            conn.Close();
        }

        // ---XXX--- SHOW TABLE SECTION CLOSE ---XXX----



        // ----- READ NODE SECTION OPEN -------

        TreeNode tempnode;
        public void myrecurz(TreeNode mytn, String rname)
        {
            int i = 0;

            while (i < mylen_d)
            {
                if (String.Equals(rname, myparent_d[i]))
                {
                    tempnode = mytn.Nodes.Add(myname_d[i].ToString());
                    myrecurz(tempnode, myname_d[i]);
                }
                i++;
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("root");
            TreeNode tn1 = new TreeNode();
            tn1 = treeView1.Nodes[0];
            myrecurz(tn1, "root");
        }

        // ---XXX--- READ NODE SECTION CLOSE ---XXX----



        // ----- DELETE NODE SECTION OPEN -------

        int del_which = 0;

        public TreeNode myrecurzdel(TreeNode ParentNode, TreeNode mytn, String rname)
        {
            int i = 0;

            while (i < mylen_d)
            {
                if (rname == myparent_d[i])
                {
                    if (mytn.Text == myparent_d[i])
                    {
                        Update_myid_d[Update_ctr_d] = myid_d[i];
                        Update_myparent_d[Update_ctr_d] = ParentNode.Text;
                        Update_ctr_d++;
                    }

                    ParentNode = ParentNode.Nodes.Add(myname_d[i]);
                    ParentNode = myrecurzdel(ParentNode, mytn, myname_d[i]);
                }
                i++;
            }

            return ParentNode.Parent;
        }

        public void del_sql(TreeNode ParentNode,String selected_node)
        {
            conn.Open();

            if (del_which == 1)
            {   

                for (int i = 0; i < Update_ctr_d; i++)
                {
                    cmdString = "DELETE FROM mytree WHERE `mytree`.`id` = '"+ Update_myid_d[i] +"'";
                    cmd = new MySqlCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }

                cmdString = "DELETE FROM mytree WHERE `mytree`.`name` = '"+ selected_node +"'";
                cmd = new MySqlCommand(cmdString, conn);
                cmd.ExecuteNonQuery();

            }

            if (del_which == 2) {

                for (int i = 0; i < Update_ctr_d; i++)
                {
                    cmdString = " update mytree set parent = '"+ ParentNode.Text +"' where id = '"+ Update_myid_d[i] +"';";
                    cmd = new MySqlCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }

                cmdString = "DELETE FROM mytree WHERE `mytree`.`name` = '"+ selected_node +"'";
                cmd = new MySqlCommand(cmdString, conn);
                cmd.ExecuteNonQuery();

            }

            conn.Close();
        }
        TreeNode tempN = new TreeNode();
        private void del_node_Click(object sender, EventArgs e)
        {
            

          //  tempN = treeView1.SelectedNode;

            var selectedOption = MessageBox.Show("Delete All Sub Inside Nodes of ' " + tempN.Text + " ' too ?? ", "Dialog Value Demo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (selectedOption == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show(" Deleting Selected Node and all Sub Internal Nodes Too ,\n CONFIRMED !! ", "CONFIRMATION ##", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    del_which = 1;
                }
            }
            if (selectedOption == DialogResult.No)
            {
                DialogResult result = MessageBox.Show(" Deleting Only Selected Node  ", " CONFIRMATION ## ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    del_which = 2;
                }
            }

            if (del_which == 1 || del_which == 2)
            {
                try {

                    myrecurzdel(tempN.Parent, tempN, tempN.Text);
                    Update_mylen_d = Update_ctr_d;
                    del_sql(tempN.Parent,tempN.Text);

                    treeView1.Nodes[0].Remove();
                    sql_array();
                    button2_Click(sender, e);


                }
                catch
                {
                    MessageBox.Show(" Node has not been Selected !!  ", " Error  ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                del_which = 0;
            }

        }

        // ---XXX--- DELETE NODE SECTION CLOSE ---XXX----


       
        // ----- INSERT NODE SECTION OPEN -------
        
        TreeNode insert_N = new TreeNode();
        public void insert_sql(TreeNode mynode ,String id , String name , String parent)
        {
            cmdString = " INSERT INTO `mytree` (`id`, `name`, `parent`) VALUES('" + id + "','" + name + "','" + parent + "');";

            conn.Open();
            cmd = new MySqlCommand(cmdString, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            mynode.Nodes.Add(textBoxname.Text);

            MessageBox.Show(" Data Inserterd Succesfully ","SUCCESS !! ",MessageBoxButtons.OK,MessageBoxIcon.Information);          

        }

        public int insert_check()
        {
            if(textBoxid.Text=="" || textBoxname.Text=="")            
                return 2;            

            if(textBoxparent.Text == "")            
                return 3;            

            for(int i = 0; i < mylen_d; i++)            
                if (textBoxid.Text == myid_d[i].ToString())
                    return 0;          

            return 1;
        }

        private void insert_node_Click(object sender, EventArgs e)
        {           
            if (insert_check() == 1)          
                insert_sql(insert_N, textBoxid.Text, textBoxname.Text, textBoxparent.Text.ToString());
                      
            else if (insert_check() == 0)            
                MessageBox.Show(textBoxid.Text + " ID Is Already Exsist ", "## ERROR ##", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else if (insert_check() == 2)        
                MessageBox.Show(" Fill All the Text Box ", "## ERROR ##", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
            else if (insert_check() == 3)            
                MessageBox.Show(" Plzz Select parent From the \n tree by Double Clicking on it ", "## ERROR ##", MessageBoxButtons.OK, MessageBoxIcon.Error);               
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            insert_N = treeView1.SelectedNode;
            tempN = treeView1.SelectedNode;
            textBoxparent.Text = insert_N.Text;
            select_node_textbox.Text = insert_N.Text;

        }

        private void textBoxid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
     


    // ---XXX--- INSERT NODE SECTION CLOSE ---XXX----



       // ----- UPDATE NODE SECTION OPEN -------

        public int update_check()
        {
            if (update_textbox.Text == "" || select_node_textbox.Text == "")
                return 0;          

            return 1;
        }

        public void update_sql(String new_Name , String old_Name)
        {
            cmdString = " UPDATE mytree SET name = '"+new_Name+"' WHERE name = '"+old_Name+"';";

            conn.Open();
            cmd = new MySqlCommand(cmdString, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show(" Data Updated Succesfully ", "SUCCESS !! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        }

        private void update_node_Click(object sender, EventArgs e)
        {
            if (update_check() == 1)
            {
                update_sql(update_textbox.Text, insert_N.Text);
                insert_N.Text = update_textbox.Text;
            }
            else if (update_check() == 0)
                MessageBox.Show(" Fill All the Text Box ", "## ERROR ##", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        // ---XXX--- UPDATE NODE SECTION CLOSE ---XXX----

    }
}
