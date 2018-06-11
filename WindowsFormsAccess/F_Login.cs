using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Maticsoft.DBUtility; //引入命名空间

namespace WindowsFormsAccess
{
    public partial class F_Login : Form
    {
        //变量定义
        private AccessHelper achelp;
        private int iiResult = 0; 

        public int iResult  ///验证结果
        {
            get { return this.iiResult; }
            set { this.iiResult = value; }
        }
        
        public F_Login()
        {
            InitializeComponent();
        }
        //取消
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //登录
        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPass.Text != "")
            {
                //int result = achelp.ExcuteSql("select * from s0Login where Name='" + textName.Text.Trim() + "' and Pass='" + textPass.Text.Trim() + "'");
                if("admin" == textName.Text.Trim() && "111" == textPass.Text.Trim())
                {
                    iResult = 1; //验证通过
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                    iResult = 0; //验证不通过
                }

            }
            else
                MessageBox.Show("请将登录信息添写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            try
            {
                 //连接数据库
                
                //textName.Text = "";
                //textPass.Text = "";

            }
            catch (Exception objException)
            {
                MessageBox.Show("数据库连接失败。" +objException.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textPass.Focus();
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                butLogin.Focus();　　　　　　　　　　　　　　　
        }

        private void F_Login_Activated(object sender, EventArgs e)
        {
            textName.Focus();
        }

    }
}