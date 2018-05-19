定义变量，设置列标题；

[csharp] view plain copy

    private AccessHelper achelp;  
    ......  
           private void Form1_Load(object sender, EventArgs e)  
           {  
      
               achelp = new AccessHelper();  
               string sql1 = "select * from ycyx";  
               databind1(sql1);  
                
               dataGridView1.Columns[0].Visible = false;  
               dataGridView1.Columns[1].HeaderCell.Value = "员工号码";  
               dataGridView1.Columns[2].HeaderCell.Value = "员工名称";  
               dataGridView1.Columns[3].HeaderCell.Value = "归属地区";  
               dataGridView1.Columns[4].HeaderCell.Value = "当前部门";  
               dataGridView1.Columns[5].HeaderCell.Value = "当前专项";  
               dataGridView1.Columns[6].HeaderCell.Value = "当前状态";  
           }  


显示数据表全部内容；

[csharp] view plain copy

    private void databind1(string sqlstr)  
    {  
        DataTable dt = new DataTable();  
        dt = achelp.GetDataTableFromDB(sqlstr);  
        dataGridView1.DataSource = dt;  
    }  


读取要更新记录到更新窗体控件；

[csharp] view plain copy

    private void button3_Click(object sender, EventArgs e)  
    {  
        if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)  
        {  
            MessageBox.Show("没有选中行。", "M营销");  
            return;  
        }  
        //f3.Owner = this;  
        DataTable dt = new DataTable();  
        object oid = dataGridView1.SelectedRows[0].Cells[0].Value;  
        string sql = "select * from ycyx where ID=" + oid;  
        dt = achelp.GetDataTableFromDB(sql);  
        f3 = new Form3();  
        f3.id = int.Parse(oid.ToString());  
        //f3.id = 2;  
        f3.Text1 = dt.Rows[0][1].ToString();  
        f3.Text2 = dt.Rows[0][2].ToString();  
        f3.Text3 = dt.Rows[0][3].ToString();  
        f3.Text4 = dt.Rows[0][4].ToString();  
        f3.Text5 = dt.Rows[0][5].ToString();  
        f3.Text6 = dt.Rows[0][6].ToString();  
      
        f3.ShowDialog();  
          
    }  


    //添加记录；
    private void button4_Click(object sender, EventArgs e)  
    {  
        if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")  
        {  
            MessageBox.Show("没有要添加的内容", "M营销添加");  
            return;  
        }  
        else  
        {  
            string sql = "insert into ycyx (fwhm,khmc,gsdq,dqpp,dqtc,dqzt) values ('" + textBox1.Text + "','" + textBox2.Text + "','"+  
                textBox3.Text + "','"+ textBox4.Text + "','"+ textBox5.Text + "','"+ textBox6.Text + "')";  
            int ret = achelp.ExcuteSql(sql);  
            string sql1 = "select * from ycyx";  
            databind1(sql1);  
            textBox1.Text = "";  
            textBox2.Text = "";  
            textBox3.Text = "";  
            textBox4.Text = "";  
            textBox5.Text = "";  
            textBox6.Text = "";  
        }  
    }  


删除记录；

[csharp] view plain copy

    private void button2_Click(object sender, EventArgs e)  
    {  
        if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)  
        {  
            MessageBox.Show("没有选中行。", "M营销");  
        }  
        else  
        {  
            object oid = dataGridView1.SelectedRows[0].Cells[0].Value;  
            if (DialogResult.No == MessageBox.Show("将删除第 " + (dataGridView1.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "M营销", MessageBoxButtons.YesNo))  
            {  
                return;  
            }  
            else  
            {  
                string sql = "delete from ycyx where ID=" + oid;  
                int ret = achelp.ExcuteSql(sql);  
            }  
            string sql1 = "select * from ycyx";  
            databind1(sql1);  
        }  
    }  


查询；

[csharp] view plain copy

    private void button13_Click(object sender, EventArgs e)  
    {  
        if (textBox23.Text == "")  
        {  
            MessageBox.Show("请输入要查询的当前品牌", "M营销");  
            return;  
        }  
        else  
        {  
            string sql = "select * from ycyx where dqpp='" + textBox23.Text + "'";  
            DataTable dt = new System.Data.DataTable();  
            dt = achelp.GetDataTableFromDB(sql);  
            dataGridView1.DataSource = dt;  
        }  
    }  


用户确定显示或不显示哪些数据列；

[csharp] view plain copy

    private void button15_Click(object sender, EventArgs e)  
    {  
        if (checkBox1.Checked == true)  
        {  
            dataGridView1.Columns[1].Visible = true;  
        }  
        else  
        {  
            dataGridView1.Columns[1].Visible = false;  
        }  
      
        if (checkBox2.Checked == true)  
        {  
            dataGridView1.Columns[2].Visible = true;  
        }  
        else  
        {  
            dataGridView1.Columns[2].Visible = false;  
        }  
      
        if (checkBox3.Checked == true)  
        {  
            dataGridView1.Columns[3].Visible = true;  
        }  
        else  
        {  
            dataGridView1.Columns[3].Visible = false;  
        }  
      
        if (checkBox4.Checked == true)  
        {  
            dataGridView1.Columns[4].Visible = true;  
        }  
        else  
        {  
            dataGridView1.Columns[4].Visible = false;  
        }  
      
        if (checkBox5.Checked == true)  
        {  
            dataGridView1.Columns[5].Visible = true;  
        }  
        else  
        {  
            dataGridView1.Columns[5].Visible = false;  
        }  
      
        if (checkBox6.Checked == true)  
        {  
            dataGridView1.Columns[6].Visible = true;  
        }  
        else  
        {  
            dataGridView1.Columns[6].Visible = false;  
        }  
    }  


更新数据；

[csharp] view plain copy

        public partial class Form3 : Form  
        {  
            private AccessHelper achelp;  
            private int iid;  
      
            public Form3()  
            {  
                InitializeComponent();  
                achelp = new AccessHelper();  
                iid = 0;  
            }  
      
            // 更新  
            private void button1_Click(object sender, EventArgs e)  
            {  
                try  
                {  
                    //UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing'WHERE LastName = 'Wilson'  
                    string sql = "update ycyx set fwhm='"+textBox1.Text+"',khmc='"+textBox2.Text+"',gsdq='"+textBox3.Text+"',dqpp='"+textBox4.Text+  
                        "',dqtc='"+textBox5.Text+"',dqzt='"+textBox6.Text+"' where ID="+iid;  
                          
      
                    int ret = achelp.ExcuteSql(sql);  
                    if (ret > -1)  
                    {  
                        this.Hide();  
                        MessageBox.Show("更新成功", "M营销");  
                    }  
                }  
                catch (Exception ex)  
                {  
                    MessageBox.Show(ex.Message);  
                }  
      
                  
      
            }  
      
            private void Form3_Load(object sender, EventArgs e)  
            {  
      
            }  
      
            public int id  
            {  
                get { return this.iid; }  
                set { this.iid = value; }  
            }  
      
      
            public string Text1  
            {  
                get { return this.textBox1.Text; }  
                set { this.textBox1.Text = value; }  
            }  
      
            public string Text2  
            {  
                get { return this.textBox2.Text; }  
                set { this.textBox2.Text = value; }  
            }  
      
            public string Text3  
            {  
                get { return this.textBox3.Text; }  
                set { this.textBox3.Text = value; }  
            }  
      
            public string Text4  
            {  
                get { return this.textBox4.Text; }  
                set { this.textBox4.Text = value; }  
            }  
      
            public string Text5  
            {  
                get { return this.textBox5.Text; }  
                set { this.textBox5.Text = value; }  
            }  
      
            public string Text6  
            {  
                get { return this.textBox6.Text; }  
                set { this.textBox6.Text = value; }  
            }  
      
            //取消  
            private void button2_Click(object sender, EventArgs e)  
            {  
                this.Hide();  
            }  
        }  
    }  


注意此处有一个技巧；C# Winform，在窗体之间传值，或在一个窗体中设置另一个窗体的控件的值时，有多种方式；
最好方式是如上代码所示；使用.net的get、set属性；

控件是一个窗体的私有变量，不能在另一个窗体中直接访问；为了在a窗体中设置b窗体的控件的值，
对b窗体的控件都添加一个带get、set的公共属性，就可在a中设置b中控件的值，具体看代码；