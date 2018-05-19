﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using Maticsoft.DBUtility; //引入命名空间

namespace WindowsFormsAccess
{
    public partial class Form1 : Form
    {
        //变量定义
        private AccessHelper achelp;
        static string workPath = System.Windows.Forms.Application.StartupPath; //获取启动了应用程序的可执行文件的路径，“D：\fh_bk”形式，末尾不带“\”
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            achelp = new AccessHelper();        //定义变量，设置列标题；
            //string sql1 = "select * from ycyx";
            string sql1 = "select * from Users"; //重新刷新
            databind1(sql1);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderCell.Value = "手机号码";
            dataGridView1.Columns[2].HeaderCell.Value = "员工名称";
            dataGridView1.Columns[3].HeaderCell.Value = "归属地区";
            dataGridView1.Columns[4].HeaderCell.Value = "当前部门";
            dataGridView1.Columns[5].HeaderCell.Value = "当前专项";
            dataGridView1.Columns[6].HeaderCell.Value = "当前状态";

            tabControl1.TabPages.Remove(this.tabPage2);
            tabControl1.TabPages.Remove(this.tabPage3);
            tabControl1.TabPages.Remove(this.tabPageS5File);
            tabControl1.TabPages.Remove(this.tabPageS3);

        }

        //显示数据表全部内容；
        private void databind1(string sqlstr)  
        {  
            DataTable dt = new DataTable();  
            dt = achelp.GetDataTableFromDB(sqlstr);  
            dataGridView1.DataSource = dt;  
        }

       // 读取要更新记录到更新窗体控件；
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "M员工");
                return;
            }

            DataTable dt = new DataTable();
            object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //更新全局oid

            readSheet1(gOid);   //读取sheet1内容到页面1
            readSheetX(gOid);   //读取内容到页面
        }

        //添加记录；
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addSheet1();
            addSheetX(gOid);
        }

        // 删除记录
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //deleteSheet1();
            deleteSheetX();
        }

        //查询
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                //MessageBox.Show("请输入要查询的员工当前部门", "M员工");
                labelCheck.Text = "请输入要查询的员工当前部门";
                string sql1 = "select * from ycyx";
                databind1(sql1);  

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

        private void button5_Click(object sender, EventArgs e)
        {
            //用户确定显示或不显示哪些数据列；

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

        //插入一条记录
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" && textBox7.Text == "" )
            {
                MessageBox.Show("没有要添加的内容", "M员工添加");
                return;
            }
            else
            {
                string sql = "insert into file (sFileName, iUserID) values ('" + textBox8.Text + "','" + textBox7.Text  + "')";
                int ret = achelp.ExcuteSql(sql);
                string sql1 = "select * from file";
                databind1(sql1);

                //清空
                textBox8.Text = "";
                textBox7.Text = "";
            }  
        }

        //上传文件
        private void buttonFileUp_Click(object sender, EventArgs e)
        {
            //fileLoadUpDown fileOption = new fileLoadUpDown();
            //fileOption.UpLoadFile(workPath + @"\..\test.accdb", workPath, "user", "pwd");

            FileStream fs = new FileStream(textBox1.Text, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Byte[] byData = br.ReadBytes((int)fs.Length);
            fs.Close();

            string sql = "insert into file (sFileName, iUserID,sType,sFileStream) values ('测试文件', 333, 'ct', @file)";
            int ret = achelp.ExcuteSql2(sql, byData); //byData为文件的二进制流
            string sql1 = "select * from file";
            databind1(sql1);


        }

        //下载文件
        private void buttonDownLoad_Click(object sender, EventArgs e)
        {
           // fileLoadUpDown fileOption = new fileLoadUpDown();
           // fileOption.DownLoadFile2(workPath + @"\test.accdb", workPath + @"\..\..\", "user", "pwd");

            string checkName = textBox2.Text;
            string fileName = textBox4.Text; //保存的文件名
            //从数据库中把二进制流读出写入还原成文件 
            string sql = "select sFileStream, sFileName from file where  sFileName='" + checkName + "'";  //(id, sFileName, iUserID,sType,sFileStream) values ('测试文件', 333, 'ct', @file)";
            byte[] File = achelp.GetDataTableFromDB2(sql); //byData为文件的二进制流

            
            FileStream fs;
            FileInfo fi = new System.IO.FileInfo(fileName);
            fs = fi.OpenWrite();
            fs.Write(File, 0, File.Length);
            fs.Close();  

        }

        //更新test页面
        private void buttonTestOK_Click(object sender, EventArgs e)
        {
            updateSheetX(); //更新数据库
        }

        //取消更新test页面，清空
        private void buttonTestCancel_Click(object sender, EventArgs e)
        {

        }

        //test page 测试
        private void buttonTest_Click(object sender, EventArgs e)
        {
            output("max ID: " + getMaxIDFromSheetX().ToString());
            if ( "" != textBox10.Text)
            {
            int id = int.Parse(textBox10.Text);
            bool ret = checkIDFromSheetX(id);
            output("ID Exist: " + textBox10.Text + "," + ret.ToString());
            }

            int ret1 = getCountFromSheetX("khmc = " + int.Parse(textBox10.Text));
            output("Count Exist: " +  ret1.ToString());
        }

        //显示文件夹存储位置
        /// 加载逻辑磁盘文件  
        private void button2_Click(object sender, EventArgs e)
        {
             DriveInfo[] myDrivers = DriveInfo.GetDrives();  
            foreach (DriveInfo di in myDrivers)  
            {  
                if (di.IsReady)  
                {  
                    TreeNode tNode = new TreeNode(di.Name.Split(':')[0]);  
                    tNode.Name = di.Name;  
                    tNode.Tag = tNode.Name;
                    tNode.ImageIndex = 3;         //获取结点显示图片  ,IconIndexes.FixedDrive
                    tNode.SelectedImageIndex = 3; //选择显示图片, IconIndexes.FixedDrive  
                    tNode.Nodes.Add("DUMMY");
                    treeViewS5.Nodes.Add(tNode); //加载驱动节点
                    
                }  
            } 

            //添加鼠标右键的事件  
            //this.treeViewS5.ContextMenuStrip = new TreeViewContextMenu().Load();
        }

        /// TreeView必须处理的两个事件之一  
        private void treeViewS5_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();  
        }

        /// TreeView必须处理的两个事件之一  
        private void treeViewS5_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeViewItems.Add(sender, e);            
        }

        //保存sheet1-基本信息
        private void buttonS1Save_Click(object sender, EventArgs e)
        {
            updateSheet1();
        }

        //刷新sheet1-基本信息
        private void buttonS1Flash_Click(object sender, EventArgs e)
        {
            readSheet1(gOid);
        }

    }
}
