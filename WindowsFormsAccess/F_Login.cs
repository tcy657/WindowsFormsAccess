using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Maticsoft.DBUtility; //���������ռ�

namespace WindowsFormsAccess
{
    public partial class F_Login : Form
    {
        //��������
        private AccessHelper achelp;
        private int iiResult = 0; 

        public int iResult  ///��֤���
        {
            get { return this.iiResult; }
            set { this.iiResult = value; }
        }
        
        public F_Login()
        {
            InitializeComponent();
        }
        //ȡ��
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //��¼
        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPass.Text != "")
            {
                //int result = achelp.ExcuteSql("select * from s0Login where Name='" + textName.Text.Trim() + "' and Pass='" + textPass.Text.Trim() + "'");
                if("admin" == textName.Text.Trim() && "111" == textPass.Text.Trim())
                {
                    iResult = 1; //��֤ͨ��
                    this.Close();
                }
                else
                {
                    MessageBox.Show("�û������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                    iResult = 0; //��֤��ͨ��
                }

            }
            else
                MessageBox.Show("�뽫��¼��Ϣ��д������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            try
            {
                 //�������ݿ�
                
                //textName.Text = "";
                //textPass.Text = "";

            }
            catch (Exception objException)
            {
                MessageBox.Show("���ݿ�����ʧ�ܡ�" +objException.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                butLogin.Focus();������������������������������
        }

        private void F_Login_Activated(object sender, EventArgs e)
        {
            textName.Focus();
        }

    }
}