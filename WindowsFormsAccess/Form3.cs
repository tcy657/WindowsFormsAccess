using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility; //引入命名空间

namespace WindowsFormsAccess
{
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


        private void button1_Click(object sender, EventArgs e)
        {
            // 更新  
                try  
                {  
                    //UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing'WHERE LastName = 'Wilson'  
                    string sql = "update ycyx set fwhm='"+textBox1.Text+"',khmc='"+textBox2.Text+"',gsdq='"+textBox3.Text+"',dqpp='"+textBox4.Text+  
                        "',dqtc='"+textBox5.Text+"',dqzt='"+textBox6.Text+"' where ID="+iid;  
                          
      
                    int ret = achelp.ExcuteSql(sql);  
                    if (ret > -1)  
                    {  
                        this.Hide();  
                        MessageBox.Show("更新成功", "M员工查询");  
                    }  
                }  
                catch (Exception ex)  
                {  
                    MessageBox.Show(ex.Message);  
                }  
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
