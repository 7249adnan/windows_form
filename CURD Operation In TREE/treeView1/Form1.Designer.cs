namespace treeView1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.del_node = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxparent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.insert_node = new System.Windows.Forms.Button();
            this.update_node = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.update_textbox = new System.Windows.Forms.TextBox();
            this.select_node_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(279, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Table ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dg1
            // 
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(81, 456);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(546, 235);
            this.dg1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(746, 253);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(363, 390);
            this.treeView1.TabIndex = 3;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(845, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Create Tree";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // del_node
            // 
            this.del_node.Location = new System.Drawing.Point(324, 289);
            this.del_node.Name = "del_node";
            this.del_node.Size = new System.Drawing.Size(115, 28);
            this.del_node.TabIndex = 6;
            this.del_node.Text = "Delete Node";
            this.del_node.UseVisualStyleBackColor = true;
            this.del_node.Click += new System.EventHandler(this.del_node_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID : ";
            // 
            // textBoxid
            // 
            this.textBoxid.Location = new System.Drawing.Point(165, 133);
            this.textBoxid.Name = "textBoxid";
            this.textBoxid.Size = new System.Drawing.Size(73, 20);
            this.textBoxid.TabIndex = 8;
            this.textBoxid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxid_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(256, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Node Name : ";
            // 
            // textBoxparent
            // 
            this.textBoxparent.Location = new System.Drawing.Point(550, 138);
            this.textBoxparent.Name = "textBoxparent";
            this.textBoxparent.ReadOnly = true;
            this.textBoxparent.Size = new System.Drawing.Size(100, 20);
            this.textBoxparent.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(478, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Parent : ";
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(355, 136);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(100, 20);
            this.textBoxname.TabIndex = 10;
            // 
            // insert_node
            // 
            this.insert_node.Location = new System.Drawing.Point(123, 178);
            this.insert_node.Name = "insert_node";
            this.insert_node.Size = new System.Drawing.Size(91, 30);
            this.insert_node.TabIndex = 11;
            this.insert_node.Text = "insert Node";
            this.insert_node.UseVisualStyleBackColor = true;
            this.insert_node.Click += new System.EventHandler(this.insert_node_Click);
            // 
            // update_node
            // 
            this.update_node.Location = new System.Drawing.Point(177, 289);
            this.update_node.Name = "update_node";
            this.update_node.Size = new System.Drawing.Size(99, 28);
            this.update_node.TabIndex = 12;
            this.update_node.Text = "Update Node ";
            this.update_node.UseVisualStyleBackColor = true;
            this.update_node.Click += new System.EventHandler(this.update_node_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Update  Name : ";
            // 
            // update_textbox
            // 
            this.update_textbox.Location = new System.Drawing.Point(243, 254);
            this.update_textbox.Name = "update_textbox";
            this.update_textbox.Size = new System.Drawing.Size(153, 20);
            this.update_textbox.TabIndex = 13;
            // 
            // select_node_textbox
            // 
            this.select_node_textbox.Location = new System.Drawing.Point(550, 253);
            this.select_node_textbox.Name = "select_node_textbox";
            this.select_node_textbox.ReadOnly = true;
            this.select_node_textbox.Size = new System.Drawing.Size(100, 20);
            this.select_node_textbox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(430, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Selected Node  : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(370, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(384, 36);
            this.label6.TabIndex = 7;
            this.label6.Text = "CURD Operation in TREE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 703);
            this.Controls.Add(this.update_textbox);
            this.Controls.Add(this.update_node);
            this.Controls.Add(this.insert_node);
            this.Controls.Add(this.textBoxname);
            this.Controls.Add(this.select_node_textbox);
            this.Controls.Add(this.textBoxparent);
            this.Controls.Add(this.textBoxid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.del_node);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button del_node;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxparent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Button insert_node;
        private System.Windows.Forms.Button update_node;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox update_textbox;
        private System.Windows.Forms.TextBox select_node_textbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

