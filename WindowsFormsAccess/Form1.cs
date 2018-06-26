using System;
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
        SaveFileDialog save = new SaveFileDialog();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            //登录            
            outputLabel("开始登录"); //记录操作 
            F_Login FrmLogin = new F_Login();   //声明登录窗体，进行调用            
            FrmLogin.ShowDialog();
            if (0 == FrmLogin.iResult)
            {
                FrmLogin.Dispose();
                this.Close();
            }

            achelp = new AccessHelper();        //定义变量，设置列标题；       
            initDo(); //所有初始化

            //hideTab2Control2(ref this.tabPage2s1); //显示tabControl2的”首页“
        }

        //显示数据表全部内容；
        private void databind1(string sqlstr)  
        {  
            DataTable dt = new DataTable();  
            dt = achelp.GetDataTableFromDB(sqlstr);  
            dataGridView1.DataSource = dt;  
        }

       // 加载, 要更新记录到更新窗体控件；
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            outputLabel("加载开始");
            bXinJian = false; //解除新建状态

            //string sql1 = "None"; //保存sql语句

            //step1，判断是否选中
            if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
                return;
            }

            //step2, 清空所有sheet并跳到“基本信息页面”
            foreach (Control i in groupBox1.Controls)
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
            }
            

            foreach (Control i in groupBox2.Controls) //用户基本信息页，被加载后直接可编辑
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = true;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = true;
                }
                else if (i is Button)
                {
                    i.Enabled = true;
                }
            }

            foreach (Control i in groupBox5.Controls)
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }

                //所有下拉框，取默认值，待补
            }
            
            //sheet 4; //清空
            foreach (Control i in groupBox7.Controls)  //清空和使能
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
            }

            //sheet5
            label116.Text = ""; //清空
            foreach (Control i in groupBox12.Controls)  //清空和使能
            {
                if (i is Button)
                {
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Enabled = false;
                }
            }
            treeViewS5.Nodes.Clear(); //清空树型结构

            //sheet6
            foreach (Control i in groupBox9.Controls)  //清空和使能
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
            }

            //step3
            object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //更新全局oid

            readSheet1(gOid);   //读取sheet1内容到页面1
            comboBox7Sheet1.Enabled = false; //编码不再改变，除非删除

            loadSheetBindOnly2();
            loadSheetBindOnly3();
            loadSheetBindOnly4();
            loadSheetBindOnly5();
            loadSheetBindOnly6();
            loadSheetBindOnly7();

            label20.Text = "当前加载用户： \n"+ textBox1Sheet1.Text + "\n用户编号： \n"+ gOid.ToString(); //在首页显示“当前用户：”

            //置位为查看状态
            gFlagAdd = 0;

            tabControl1.SelectedIndex = 1; //跳到“用户基本”信息页
            outputLabel("加载结束");
        }

        //新建，user基本信息；
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            clearAllSheet(); //清空所有sheet

            //跳到“基本信息页面”
            gOid = UsersDo.GetMaxId(); //gOid为0，无法跳到其他Tab页。另一种方法（实为同一种）gOid = achelp.GetMaxID("ID","Users"); 
            tabControl1.SelectedIndex = 1;
            comboBox7Sheet1.Enabled = true; //编码可以改变

            //清空查询条件，加载时默认使用查询条件过滤
            textBox23.Text = ""; 

            //置位为新增状态
            gFlagAdd = 1;

            bXinJian = true;   //新建状态，detail-datagridview的操作控件禁用
            groupBox6.Enabled = false; //detail-datagridview的操作控件禁用

            label20.Text = "当前用户：无";
        }
        
        //清空所有sheet
        private void clearAllSheet()
        {            
            foreach (Control i in groupBox1.Controls) //sheet2
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
            }

            foreach (Control i in groupBox2.Controls)  //sheet1, “基本信息页面”
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
                else if (i is Button)
                    i.Enabled = true;
            }

            foreach (Control i in groupBox5.Controls) //sheet3
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }

                //所有下拉框，取默认值，待补
            }


            foreach (Control i in groupBox7.Controls) //清空sheet4
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
            }

            //sheet5
            label116.Text = ""; //清空

            foreach (Control i in groupBox12.Controls)  //清空和使能
            {
                if (i is Button)
                {
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Enabled = false;
                }
            }

            foreach (Control i in groupBox9.Controls) //sheet6
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
                else if (i is ComboBox)
                {
                    i.Text = "";
                    i.Enabled = false;
                }
            }
        }

        // 删除记录
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //deleteSheet1();
            if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dataGridView1.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    //删除sheet1-sheet7
                    bool bRet1 = UsersDo.Delete(Convert.ToInt32(oid));
                    if (true == bRet1)
                    {
                        EraseSection("ID" + gOid.ToString(),  iniFileTabPath);    //删除selection
                        
                    }
                    if (true == achelp.Exists("select * from s2XinFuZhu where iUserID = " + oid.ToString()  ))
                    {
                        achelp.ExcuteSql("delete from s2XinFuZhu where iUserID = " + oid.ToString()); 
                    }//s2
                    if (true == achelp.Exists("select * from s3ShuHouFuZhu where iUserID = " + oid.ToString()))
                    {
                        achelp.ExcuteSql("delete from s3ShuHouFuZhu where iUserID = " + oid.ToString());
                    }//s3
                    if (true == achelp.Exists("select * from s4SuiZhen where iUserID = " + oid.ToString()))
                    {
                        achelp.ExcuteSql("delete from s4SuiZhen where iUserID = " + oid.ToString());
                    }//s4
                    if (true == achelp.Exists("select * from s5ShuJuCunZhu where iUserID = " + oid.ToString()))
                    {
                        achelp.ExcuteSql("delete from s5ShuJuCunZhu where iUserID = " + oid.ToString());
                    } //s5
                    if (true == achelp.Exists("select * from s6QiBingQingKuang where iUserID = " + oid.ToString()))
                     {
                         achelp.ExcuteSql("delete from s6QiBingQingKuang where iUserID = " + oid.ToString());
                    } //s6
                    if (true == achelp.Exists("select * from s7ShuQianPingGu where iUserID = " + oid.ToString()))
                    {
                        achelp.ExcuteSql("select * from s7ShuQianPingGu where iUserID = " + oid.ToString()); 
                    }//s7
                }
                string sql1 = "select * from Users";
                databind(sql1, ref  dataGridView1);
                gOid = 0; //不让切换到其他sheet，只能从"首页"开始
                clearAllSheet(); //清空sheet页

                //显示
                outputLabel("sheet1删除成功!");
            }
            //待增加sheet2-sheet7的删除
            
        }

        //查询
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            outputLabel("查询开始");

            string sql1 = "select * from Users";
            if (textBox23.Text.Trim() == "")  //内容为空，取所有值
            {
                //MessageBox.Show("请输入要查询的内容", "系统提示");
                outputLabel("请输入要查询的内容");                 
            }
            else
            {
                string checkType = comboBox19.Text; //查询条件
                switch (checkType)
                {
                    case "编码":
                        sql1 = "select * from Users where sBianMa='" + textBox23.Text.Trim() + "'";
                        break;
                    case "姓名":
                        sql1 = "select * from Users where sName='" + textBox23.Text.Trim() + "'";
                        break;
                    default:
                        sql1 = "select * from Users";
                        break;
                }                
            }

            databind(sql1, ref  dataGridView1); //更新DataGridView

            outputLabel("查询结束");
            return;
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
                MessageBox.Show("没有要添加的内容", "系统提示添加");
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
            outputLabel("max ID: " + getMaxIDFromSheetX().ToString());
            if ( "" != textBox10.Text)
            {
            int id = int.Parse(textBox10.Text);
            bool ret = checkIDFromSheetX(id);
            outputLabel("ID Exist: " + textBox10.Text + "," + ret.ToString());
            }

            int ret1 = getCountFromSheetX("khmc = " + int.Parse(textBox10.Text));
            outputLabel("Count Exist: " +  ret1.ToString());
        }


        /// TreeView必须处理的两个事件之一  
        private void treeViewS5_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();  
        }

        //保存sheet1-基本信息
        private void buttonS1Save_Click(object sender, EventArgs e)
        {
            bool ret = updateSheet1();
            if (true == ret)  //保存成功
            {
                tabControl1.SelectedIndex = 0; //跳到首页
                gOid = 0; //回到初始流程
                //自动编码，写ini
                Section = comboBox7Sheet1.Text.Trim(); //获取生病部位
                Key = "now";                   
                WriteIniData(Section, Key, next, iniFilePath);  //当前值
                Key = "next";
                next = (int.Parse(next) +1).ToString("0000"); //下一位值
                WriteIniData(Section, Key, next, iniFilePath);

                clearAllSheet(); //清空所有sheet1-sheet7
            }
            else
            {
                outputLabel("保存不成功!");
            }
           

        }

        //刷新sheet1-基本信息
        private void buttonS1Flash_Click(object sender, EventArgs e)
        {
            readSheet1(gOid);
            readSheet2();
        }

        //sheet1，加载
        private void button17_Click(object sender, EventArgs e)
        {
            readSheet1(gOid);
        }



        #region sheet2
        //加载s2信息
        private void button15_Click(object sender, EventArgs e)
        {
            readSheet2();
        }

        //保存s2信息
        private void button3_Click(object sender, EventArgs e)
        {
            updateSheet2();
        }

        //添加前，清空
        private void button16_Click(object sender, EventArgs e)
        {
            gFlagAdd2 = 1; //新建，局部新增
            //清空
            foreach (Control i in groupBox1.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }
        }

        //删除
         private void button18_Click(object sender, EventArgs e)
        {
            deleteSheet2();

        }
        
        #endregion
     

        #region sheet3

        //保存,s3
         private void button7_Click(object sender, EventArgs e)
         {
             updateSheet3();
         }

        //新建,s3 
        private void button20_Click(object sender, EventArgs e)
         {
             gFlagAdd3 = 1; //新建，局部新增
             //清空
             foreach (Control i in groupBox5.Controls)
             {
                 if (i is TextBox)
                     i.Text = "";
                 else if (i is ComboBox)
                     i.Text = "";
                 
             }
         } 
        
        //删除，s3
        private void button19_Click(object sender, EventArgs e)
        {
            deleteSheet3();
        }
        //加载，s3
        private void button21_Click(object sender, EventArgs e)
        {
            readSheet3();
        }
        #endregion

        //两个tabControll联动
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabPage1Index = this.tabControl1.SelectedIndex; //读取当前操作tab页
            TabPage i = this.tabPage2s1;
            //未加载，则不允许从“首页”切换到其他页。
            if (0 == gOid &&  0 != tabPage1Index) //未加载，且当前页为首页不显示
            {
                MessageBox.Show("请加载用户信息！", "系统提示");
                this.tabControl1.SelectedIndex = 0; //跳到首页  
                //hideTab2Control2(ref this.tabPage2s1);
                return;
            }

            
            switch (tabPage1Index)
            {
                case 0:
                    tabPage2Index = 0;
                    i = this.tabPage2s1;
                    
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 1:
                    tabPage2Index = 0;
                    i = this.tabPage2s1;

                    button25.Enabled = true; //detail-保存使能
                    break;
                case 2:     //sheet2，加1
                    tabPage2Index = 1;
                    i = this.tabPage2s2;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 3: //sheet3

                    tabPage2Index = 2;
                    i = this.tabPage2s3;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 4:    
                    tabPage2Index = 3;
                    i = this.tabPage2s4;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 5:             
                    tabPage2Index = 4;
                    i = this.tabPage2s5;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 6:           
                    tabPage2Index = 5;
                    i = this.tabPage2s6;
                    button25.Enabled = true; //detail-保存使能

                    label116.Text = ""; //清空
                    button12.Enabled = false; //禁用treeview
                    button31.Enabled = false; //禁用按键
                    button33.Enabled = false; //禁用按键
       
                    break;
                case 7: //sheet7
                    tabPage2Index = 6;
                    i = this.tabPage2s7;
                    button25.Enabled = false; //detail-保存, 不使能
                    break;
                case 8:
                    tabPage2Index = 0;
                    i = this.tabPage2s1;
                    break;
                
                default:
                    tabPage1Index = 100;
                    break;
            }
            outputLabel("内容查看跳转: " + tabPage1Index.ToString());
            if (100 != tabPage2Index)
            {
                this.tabControl2.SelectedIndex = tabPage2Index;
            }

            //首页则只显示首页按键，分页显示分页按键
            if (0 == tabPage1Index || 1  == tabPage1Index) //首页和信息页sheet2，则禁用
            {
                groupBox8.Visible = true;  //使能-总操作
                groupBox8.Enabled = true;

                groupBox6.Visible = false; //禁用-分操作
                groupBox6.Enabled = false;
            }
            else
            {
                groupBox8.Visible = false;  //禁用-总操作
                groupBox8.Enabled = false;

                groupBox6.Visible = true; //使能-分操作
                groupBox6.Enabled = true;
            }

            //新建状态，则不使分detail-datagridview的操作控件
            //加else会有误判断
            if (true == bXinJian )
            {
                groupBox6.Enabled = false;
            }
        }

        #region 全局
        //保存，全局，区别于每个sheet页面上按键
        private void button25_Click(object sender, EventArgs e)
        {
            outputLabel("s5保存");
            try
            {
            bool bResult = false; //记录保存的结果
            string stringBin = label83.Text.Trim(); //获取当前编号
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2: //sheet2
                    bResult = updateSheet2();
                    if (true == bResult)
                    {
                        foreach (Control i in groupBox1.Controls)  //清空和禁用
                        {
                            if (i is TextBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                            else if (i is ComboBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                        }
                               string number =  ReadIniData("ID" + gOid.ToString(), "sheet2", NoText, iniFileTabPath);
                               if ( "None" == number) //编号不存在，则写入
                               {
                                   WriteIniData("ID" + gOid.ToString(), "sheet2", "002", iniFileTabPath);    //保存002 
                               }
                               else //编号存在，则加1
                               {                                    
                                   stringBin = stringBin.Replace("-B","-N"); //G0001-B -> G0001-N
                                   string  stringsB2 = label148.Text.Trim();
                                   stringsB2 =stringsB2.Replace(stringBin,"");  //G0001-N01 -> 01
                                   string next = (int.Parse(stringsB2) +1).ToString("000"); //下一位值
                                   if (int.Parse(number) < int.Parse(next))
                                   {
                                       WriteIniData("ID" + gOid.ToString(), "sheet2", next, iniFileTabPath);    //保存002    
                                   }
                               }  
                    }
                    break;
                case 3: //sheet3
                    bResult = updateSheet3();
                    if (true == bResult)
                    {
                        foreach (Control i in groupBox5.Controls)  //清空和禁用
                        {
                            if (i is TextBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                            else if (i is ComboBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                        }
                        string number = ReadIniData("ID" + gOid.ToString(), "sheet3", NoText, iniFileTabPath);
                        if ("None" == number) //编号不存在，则写入
                        {
                            WriteIniData("ID" + gOid.ToString(), "sheet3", "002", iniFileTabPath);    //保存002 
                        }
                        else //编号存在，则加1
                        {
                            stringBin = stringBin.Replace("-B", "-A"); //G0001-B -> G0001-N
                            string stringsB2 = label147.Text.Trim();
                            stringsB2 = stringsB2.Replace(stringBin, "");  //G0001-N01 -> 01
                            string next = (int.Parse(stringsB2) + 1).ToString("000"); //下一位值
                            if (int.Parse(number) < int.Parse(next))
                            {
                                WriteIniData("ID" + gOid.ToString(), "sheet3", next, iniFileTabPath);    //保存002       
                            }
                        }  
                    }
                    break;
                case 4: //sheet4
                    bResult = updateSheet4();
                    if (true == bResult)
                    {
                        //sheet 4; //清空
                        foreach (Control i in groupBox7.Controls)
                        {
                            if (i is TextBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                            else if (i is ComboBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                        }
                        string number = ReadIniData("ID" + gOid.ToString(), "sheet4", NoText, iniFileTabPath);
                        if ("None" == number) //编号不存在，则写入
                        {
                            WriteIniData("ID" + gOid.ToString(), "sheet4", "002", iniFileTabPath);    //保存002 
                        }
                        else //编号存在，则加1
                        {
                            stringBin = stringBin.Replace("-B", "-F"); //G0001-B -> G0001-N
                            string stringsB2 = label149.Text.Trim();
                            stringsB2 = stringsB2.Replace(stringBin, "");  //G0001-N01 -> 01
                            string next = (int.Parse(stringsB2) + 1).ToString("000"); //下一位值
                            if (int.Parse(number) < int.Parse(next))
                            {
                                WriteIniData("ID" + gOid.ToString(), "sheet4", next, iniFileTabPath);    //保存002      
                            }
                        }  
                    }
                    break;                
                case 5:  //sheet5
                    bResult = updateSheet5();
                    if (true == bResult)
                    {          
                        foreach (Control i in groupBox12.Controls)  //清空和使能
                        {
                            if (i is Button)
                            {
                                //i.Text = "";
                                i.Enabled = false;
                            }
                            else if (i is ComboBox)
                            {
                                //i.Text = "";
                                i.Enabled = false;
                            }
                        }
                        string number = ReadIniData("ID" + gOid.ToString(), "sheet5", NoText, iniFileTabPath);
                        if ("None" == number) //编号不存在，则写入
                        {
                            WriteIniData("ID" + gOid.ToString(), "sheet5", "002", iniFileTabPath);    //保存002 
                        }
                        else //编号存在，则加1
                        {
                            stringBin = stringBin.Replace("-B", "-S"); //G0001-B -> G0001-N
                            string stringsB2 = label116.Text.Trim();
                            stringsB2 = stringsB2.Replace(stringBin, "");  //G0001-N01 -> 01
                            string next = (int.Parse(stringsB2) + 1).ToString("000"); //下一位值
                            if (int.Parse(number) < int.Parse(next))
                            {
                                WriteIniData("ID" + gOid.ToString(), "sheet5", next, iniFileTabPath);    //保存002  
                            }
                        }

                        label116.Text = "";
                        treeViewS5.Nodes.Clear(); //清空
                    }

                    break;
                case 6:  //sheet6 起病情况
                    bResult = updateSheet6();
                    if (true == bResult)
                    {
                        foreach (Control i in groupBox9.Controls)  //清空和禁用
                        {
                            if (i is TextBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                            else if (i is ComboBox)
                            {
                                i.Text = "";
                                i.Enabled = false;
                            }
                        }
                        string number = ReadIniData("ID" + gOid.ToString(), "sheet6", NoText, iniFileTabPath);
                        if ("None" == number) //编号不存在，则写入
                        {
                            WriteIniData("ID" + gOid.ToString(), "sheet6", "002", iniFileTabPath);    //保存002 
                        }
                        else //编号存在，则加1
                        {
                            stringBin = stringBin.Replace("-B", "-M"); //G0001-B -> G0001-N
                            string stringsB2 = label145.Text.Trim();
                            stringsB2 = stringsB2.Replace(stringBin, "");  //G0001-N01 -> 01
                            string next = (int.Parse(stringsB2) + 1).ToString("000"); //下一位值
                            if (int.Parse(number) < int.Parse(next))
                            {
                                WriteIniData("ID" + gOid.ToString(), "sheet6", next, iniFileTabPath);    //保存002    
                            }
                        } 
                    }
                    break;
                case 7: //sheet7

                    break;
                default:

                    break;
            }
            }//try 
            catch (Exception objException)
            {
                outputLabel("s5保存，失败！" + objException);
            }  

        }
        //新建，全局
        private void button11_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2://sheet2
                    gFlagAdd2 = 1; //新建，局部新增
                    //清空
                    foreach (Control i in groupBox1.Controls)
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                            i.Enabled = true;

                            if ("label148" == i.Name) //编码保持一致
                            {  
                               string number =  ReadIniData("ID" + gOid.ToString(), "sheet2", NoText, iniFileTabPath);
                               if ( "None" == number) //编号不存在，则自1始
                               {
                                   i.Text = label83.Text.Replace("-B", "-N001");
                                   //WriteIniData("ID1000", "sheet2", "002", iniFileTabPath);    //保存 
                               }
                               else //编号存在，则读取
                               {
                                   i.Text = label83.Text.Replace("-B", "-N" + number);                           
                               }          
                            }
                        }
                        else if (i is ComboBox)
                        {
                            i.Text = "";
                            i.Enabled = true;
                        }
                        else if (i is Label)
                        {
                            if ("label148" == i.Name) //编码保持一致
                            {
                                string number = ReadIniData("ID" + gOid.ToString(), "sheet2", NoText, iniFileTabPath);
                                if ("None" == number) //编号不存在，则自1始
                                {
                                    i.Text = label83.Text.Replace("-B", "-N001");
                                    //WriteIniData("ID1000", "sheet2", "002", iniFileTabPath);    //保存 
                                }
                                else //编号存在，则读取
                                {
                                    i.Text = label83.Text.Replace("-B", "-N" + number);
                                }
                            }
                        }
                    }
                    break;
                case 3: //sheet3
                    gFlagAdd3 = 1; //新建，局部新增
                    //清空
                    foreach (Control i in groupBox5.Controls)
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                            i.Enabled = true;
                           
                        }
                        else if (i is ComboBox)
                        {
                            i.Text = "";
                            i.Enabled = true;
                        }
                        else if (i is Label)
                        {
                            if ("label147" == i.Name) //编码保持一致
                            {
                                string number = ReadIniData("ID" + gOid.ToString(), "sheet3", NoText, iniFileTabPath);
                                if ("None" == number) //编号不存在，则自1始
                                {
                                    i.Text = label83.Text.Replace("-B", "-A001");
                                    //WriteIniData("ID1000", "sheet2", "002", iniFileTabPath);    //保存 
                                }
                                else //编号存在，则读取
                                {
                                    i.Text = label83.Text.Replace("-B", "-A" + number);
                                }
                            }
                        }
                    }
                    break;
                case 4: //sheet4
                    gFlagAdd4 = 1; //新建，局部新增
                    foreach (Control i in groupBox7.Controls)
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                            i.Enabled = true;
                        }
                        else if (i is ComboBox)
                        {
                            i.Text = "";
                            i.Enabled = true;
                        }
                        else if (i is Label)
                        {
                            if ("label149" == i.Name) //编码保持一致
                            {
                                string number = ReadIniData("ID" + gOid.ToString(), "sheet4", NoText, iniFileTabPath);
                                if ("None" == number) //编号不存在，则自1始
                                {
                                    i.Text = label83.Text.Replace("-B", "-F001");
                                    //WriteIniData("ID1000", "sheet2", "002", iniFileTabPath);    //保存 
                                }
                                else //编号存在，则读取
                                {
                                    i.Text = label83.Text.Replace("-B", "-F" + number);
                                }
                            }
                        }
                    }                   
                    break;
                case 5: //sheet5
                    gFlagAdd5 = 1; //新建，局部新增
                    //清空
                   label116.Text = "None";
                   treeViewS5.Nodes.Clear(); //清空treeview                 
                   foreach (Control i in groupBox12.Controls)  //清空和使能
                   {
                       if (i is Button)
                       {
                           i.Enabled = true;
                       }
                       else if (i is ComboBox)
                       {
                           i.Enabled = true;
                       }
                       else if (i is Label)
                       {
                           if ("label116" == i.Name) //编码保持一致
                           {
                               string number = ReadIniData("ID" + gOid.ToString(), "sheet5", NoText, iniFileTabPath);
                               if ("None" == number) //编号不存在，则自1始
                               {
                                   i.Text = label83.Text.Replace("-B", "-S001");                                   
                               }
                               else //编号存在，则读取
                               {
                                   i.Text = label83.Text.Replace("-B", "-S" + number);
                               }
                           }
                       }
                   }
                   button12.PerformClick(); //刷新，显示treeview
                    break;
                case 6:  //sheet6 起病情况
                   gFlagAdd6 = 1; //新建，局部新增
                   foreach (Control i in groupBox9.Controls)  //清空和使能
                   {
                       if (i is TextBox)
                       {
                           i.Text = "";
                           i.Enabled = true;
                       }
                       else if (i is ComboBox)
                       {
                           i.Text = "";
                           i.Enabled = true;
                       }
                       else if (i is Label)
                       {
                           if ("label145" == i.Name) //编码保持一致
                           {
                               string number = ReadIniData("ID" + gOid.ToString(), "sheet6", NoText, iniFileTabPath);
                               if ("None" == number) //编号不存在，则自1始
                               {
                                   i.Text = label83.Text.Replace("-B", "-M001");
                               }
                               else //编号存在，则读取
                               {
                                   i.Text = label83.Text.Replace("-B", "-M" + number);
                               }
                           }
                       }
                   }
                    break;
                case 7: //sheet7
                    FormSheet7 f7 = new FormSheet7(); //创建一个新窗口7
                    f7.iUserID = gOid; //iUserID必须带过去
                    //f7.lOid = dos7ShuQianPingGu.GetMaxId(); //下一个编号

                    string number1 = ReadIniData("ID" + gOid.ToString(), "sheet7", NoText, iniFileTabPath);
                    if ("None" == number1) //编号不存在，则自1始
                    {
                        f7.Text36 = label83.Text.Replace("-B", "-S001");
                        f7.gsBianMa = label83.Text; //自动编码用
                    }
                    else //编号存在，则读取
                    {
                        f7.Text36 = label83.Text.Replace("-B", "-S" + number1);
                        f7.gsBianMa = label83.Text; //自动编码用
                    } 

                    f7.ShowDialog();
                    string sql1 = "select * from s7ShuQianPingGu where iUserID = " + gOid.ToString(); //重新刷新，只显示本用户的信息
                    databind(sql1, ref dgView7);
  
                    break;
                default:

                    break;
            }                       
            
        }
        //删除，全局
        private void button9_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2: //sheet2
                    deleteSheet2();
                    foreach (Control i in groupBox1.Controls) //清空
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                            i.Enabled = false;
                        }
                        else if (i is ComboBox)
                        {
                            i.Text = "";
                            i.Enabled = false;
                        }
                    }
                    break;
                case 3: //sheet3
                    deleteSheet3();
                    foreach (Control i in groupBox5.Controls) //清空
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                            i.Enabled = false;
                        }
                        else if (i is ComboBox)
                        {
                            i.Text = "";
                            i.Enabled = false;
                        }
                        
                    }
                    break;
                case 4: //sheet4
                    deleteSheet4();
                    foreach (Control i in groupBox7.Controls) //清空
                    {
                        if (i is TextBox)
                            i.Text = "";
                        else if (i is ComboBox)
                            i.Text = "";
                    }
                    foreach (Control i in groupBox7.Controls) //禁用
                    {
                        if (i is TextBox)
                            i.Enabled = false;
                        else if (i is ComboBox)
                            i.Enabled = false;
                    }
                    break;
                case 5: //sheet5
                    deleteSheet5();
                    //清空
                    label116.Text = "";
                    treeViewS5.Nodes.Clear(); //清空treeview                 
                    foreach (Control i in groupBox12.Controls)  //清空和使能
                    {
                        if (i is Button)
                        {
                            //i.Text = "";
                            i.Enabled = false;
                        }
                        else if (i is ComboBox)
                        {
                            //i.Text = "";
                            i.Enabled = false;
                        }
                    }                   
                    break;
                case 6:  //sheet6 起病情况
                    deleteSheet6();
                    foreach (Control i in groupBox9.Controls)  //清空和使能
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                            i.Enabled = false;
                        }
                        else if (i is ComboBox)
                        {
                            i.Text = "";
                            i.Enabled = false;
                        }
                    }
                    break;
                case 7: //sheet 7，不需要清空窗体
                    deleteSheet7();
                    break;
                default:

                    break;
            }  

        }
        //加载，全局
        private void button24_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2: //sheet
                    readSheet2();
                    foreach (Control i in groupBox1.Controls) //使能
                    {
                        if (i is TextBox)
                            i.Enabled = true;
                        else if (i is ComboBox)
                            i.Enabled = true;
                    }
                    break;
                case 3: //sheet3
                    readSheet3();
                    foreach (Control i in groupBox5.Controls) //使能
                    {
                        if (i is TextBox)
                            i.Enabled = true;
                        else if (i is ComboBox)
                            i.Enabled = true;
                    }
                    break;
                case 4:  //sheet4
                    readSheet4();
                    foreach (Control i in groupBox7.Controls) //禁用
                    {
                        if (i is TextBox)
                            i.Enabled = true;
                        else if (i is ComboBox)
                            i.Enabled = true;
                    }
                    break;
                case 5: //sheet5， 加载
                    readSheet5(); 
                    //使能                 
                    foreach (Control i in groupBox12.Controls)  //清空和使能
                    {
                        if (i is Button)
                        {
                            //i.Text = "";
                            i.Enabled = true;
                        }
                        else if (i is ComboBox)
                        {
                            //i.Text = "";
                            i.Enabled = true;
                        }
                    }
                    //Delay(1000); //延时
                    button12.PerformClick(); //显示treeview
                    break;
                case 6:  //sheet6
                    readSheet6();
                    foreach (Control i in groupBox9.Controls)  //清空和使能
                    {
                        if (i is TextBox)
                        {
                            //i.Text = "";
                            i.Enabled = true;
                        }
                        else if (i is ComboBox)
                        {
                            //i.Text = "";
                            i.Enabled = true;
                        }
                    }
                    break;
                case 7:  //sheet7
                    FormSheet7 f7 = new FormSheet7();
                    bool ret = readSheet7(ref f7);
                    if (true == ret)
                    {
                        f7.gsBianMa = label83.Text; //自动编码用
                        f7.ShowDialog();
                        string sql1 = "select * from s7ShuQianPingGu where iUserID = " + gOid.ToString(); //重新刷新，只显示本用户的信息
                        databind(sql1,ref dgView7);
                    }
                    break;
                default:

                    break;
            }  
        }
        #endregion

        //打开，路径1
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                string fileDir = label86.Text + @"\"; //globalWorkPath + @"\result";  保存路径
                if (Directory.Exists(fileDir) == false)//不存在,就创建NE文件夹
                {
                    Directory.CreateDirectory(fileDir);
                }

                outputLabel("打开目录");
                System.Diagnostics.Process.Start("explorer.exe", fileDir);
            } //try
            catch (Exception objException)
            {
                outputLabel("打开目录，失败");
            }
        }
        //上传路径1
        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                outputLabel("上传文件");
                string fileDir = label86.Text + @"\"; //globalWorkPath + @"\result";  保存路径
                
                OpenFileDialog filePath = new OpenFileDialog();
				filePath.InitialDirectory = fileDir; //初始路径
                filePath.Title = "选择上传文件";
                filePath.Filter = "All files(*.*)|*.*"; //设备控件保存的文件类型
                filePath.FilterIndex = 1; //默认打开*.ini            
                filePath.RestoreDirectory = true; //记忆之前打开的目录
                filePath.FileName = "";
                
                if (filePath.ShowDialog() == DialogResult.OK)
                {
                    string fileNe = filePath.FileName; //保存文件名
                    outputLabel("选择文件");

                    //拷贝到路径 
                    File.Copy(fileNe, fileDir + Path.GetFileName(fileNe) );
                }
            } //try
            catch (Exception objException)
            {
                outputLabel("上传，失败");
            }
        }
        //打开文件1
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                outputLabel("打开文件");
                string fileDir = label86.Text + @"\"; //globalWorkPath + @"\result";  保存路径

                OpenFileDialog filePath = new OpenFileDialog();
                filePath.InitialDirectory = fileDir; //初始路径
                filePath.Title = "选择文件";
                filePath.Filter = "All files(*.*)|*.*"; //设备控件保存的文件类型
                filePath.FilterIndex = 1; //默认打开*.*     
                filePath.RestoreDirectory = true; //记忆之前打开的目录
                filePath.FileName = "";

                if (filePath.ShowDialog() == DialogResult.OK)
                {
                    string fileNe = filePath.FileName; //保存文件名
                    outputLabel("选择文件");

                    //拷贝到路径 
                     System.Diagnostics.Process.Start(fileNe);
                }
            } //try
            catch (Exception objException)
            {
                outputLabel("打开文件，失败");
            }
        }

        //设置目录1
        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                //显示folderBrowserDialog1控件
                FolderBrowserDialog fbdPath = new FolderBrowserDialog();                
                fbdPath.Description = "目录选择...";
                if (fbdPath.ShowDialog() == DialogResult.OK)
                {

                    if (fbdPath.SelectedPath.IndexOf(" ") < 0) //路径非空
                    {
                        string PC_Path = fbdPath.SelectedPath ; //路径最后默认不加\
                        label86.Text = PC_Path; //保存路径

                        outputLabel("选择目录");
                    }
                    else
                    {
                        MessageBox.Show("错误！您选择的文件目录中带有空格，请重新选择: " + fbdPath.SelectedPath, "提示");
                    }

                }
            }//try
            catch (Exception objException)
            {
                outputLabel("选择目录，失败");
            }
            
        }

        //打开目录，s5
        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                if (label116.Text == "") //档案号不能为空
                {
                    MessageBox.Show("档案号不能为空");
                    return;
                }

                string fileDir = ftpRootPath + label116.Text.Trim();
                if (Directory.Exists(fileDir) == false)//不存在,就创建NE文件夹
                {
                    Directory.CreateDirectory(fileDir); //以档案号创建主文件夹                    
                }

                if (Directory.Exists(fileDir + @"/CT") == false)//不存在,就创建NE文件夹
                {
                     Directory.CreateDirectory(fileDir + @"/CT"); //
                }
                if (Directory.Exists(fileDir + @"/磁共振") == false)//不存在,就创建NE文件夹
                {
                     Directory.CreateDirectory(fileDir + @"/磁共振"); //
                }
                if (Directory.Exists(fileDir + @"/病理") == false)//不存在,就创建NE文件夹
                {
                    Directory.CreateDirectory(fileDir + @"/病理"); //
                }                                  
                    
                outputLabel("打开目录");
                System.Diagnostics.Process.Start("explorer.exe", fileDir);
            } //try
            catch (Exception objException)
            {
                outputLabel("打开目录，失败");
            }
        }
        //设置目录，s5
        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                //显示folderBrowserDialog1控件
                FolderBrowserDialog fbdPath = new FolderBrowserDialog();
                fbdPath.Description = "目录选择...";
                if (fbdPath.ShowDialog() == DialogResult.OK)
                {

                    if (fbdPath.SelectedPath.IndexOf(" ") < 0) //路径非空
                    {
                        string PC_Path = fbdPath.SelectedPath; //路径最后默认不加\
                        switch (comboBox18.SelectedIndex)
                        {
                            case 0:
                                label141.Text = PC_Path; //保存路径
                                break;
                            case 1:
                                label89.Text = PC_Path; //保存路径
                                break;
                            case 2:
                                label83.Text = PC_Path; //保存路径
                                break;
                            default:
                                outputLabel("目录未找到");
                                break;
                        }                                                
                        outputLabel("选择目录");
                    }
                    else
                    {
                        MessageBox.Show("错误！您选择的文件目录中带有空格，请重新选择: " + fbdPath.SelectedPath, "提示");
                    }

                }
            }//try
            catch (Exception objException)
            {
                outputLabel("选择目录，失败");
            }
        }
        //上传文件，s5
        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                outputLabel("上传文件");
                string fileDir ; //globalWorkPath + @"\result";  保存路径
                switch (comboBox18.SelectedIndex)
                        {
                            case 0:
                               fileDir = label141.Text + @"\"; 
                                break;
                            case 1:
                                fileDir = label89.Text + @"\";
                                break;
                            case 2:
                                fileDir = label93.Text + @"\";
                                break;
                            default:
                                fileDir = label141.Text + @"\";
                                outputLabel("目录未找到");
                                break;
                        }      
                OpenFileDialog filePath = new OpenFileDialog();
                filePath.InitialDirectory = fileDir; //初始路径
                filePath.Title = "选择上传文件";
                filePath.Filter = "All files(*.*)|*.*"; //设备控件保存的文件类型
                filePath.FilterIndex = 1; //默认打开*.ini            
                filePath.RestoreDirectory = true; //记忆之前打开的目录
                filePath.FileName = "";

                if (filePath.ShowDialog() == DialogResult.OK)
                {
                    string fileNe = filePath.FileName; //保存文件名
                    outputLabel("选择文件");

                    //拷贝到路径 
                    File.Copy(fileNe, fileDir + Path.GetFileName(fileNe));
                }
            } //try
            catch (Exception objException)
            {
                outputLabel("上传，失败");
            }
        }
        //打开文件，s5
        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                outputLabel("打开文件");
                if (label116.Text == "") //档案号不能为空
                {
                    MessageBox.Show("档案号不能为空");
                    return;
                }

                string fileDir = ftpRootPath + label116.Text.Trim();
                
                
                 //globalWorkPath + @"\result";  保存路径

                OpenFileDialog filePath = new OpenFileDialog();
                filePath.InitialDirectory = fileDir; //初始路径
                filePath.Title = "选择文件";
                filePath.Filter = "All files(*.*)|*.*"; //设备控件保存的文件类型
                filePath.FilterIndex = 1; //默认打开*.*     
                filePath.RestoreDirectory = true; //记忆之前打开的目录
                filePath.FileName = "";

                if (filePath.ShowDialog() == DialogResult.OK)
                {
                    string fileNe = filePath.FileName; //保存文件名
                    outputLabel("选择文件");

                    //拷贝到路径 
                    System.Diagnostics.Process.Start(fileNe);
                }
            } //try
            catch (Exception objException)
            {
                outputLabel("打开文件，失败");
            }
        }

        //刷新treeview，显示新的目录结构
        private void button12_Click(object sender, EventArgs e)
        {
            outputLabel("刷新sheet5 ");
            try
            {
                #region 递归加载所有的目录，按照层次结构显示到TreeView 上            
                string path = ftpRootPath + label116.Text.Trim();  //获取用户输入的一个路径

                if (false == Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Directory.CreateDirectory(path + @"\CT");
                    Directory.CreateDirectory(path + @"\磁共振");
                    Directory.CreateDirectory(path + @"\PET");
                    Directory.CreateDirectory(path + @"\病理");
                }

                treeViewS5.Nodes.Clear();  //清除所有结构，避免二次刷新时重复显示            
                LoadFilesAndDirectoriesToTree(path, treeViewS5.Nodes);  //调用该方法实现将指定路径下的子文件与子目录按照层次结构加载到TreeView
                treeViewS5.ExpandAll(); //展开所有节点
                #endregion  
            } //try
            catch (Exception objException)
            {
                outputLabel("刷新sheet5 treeview，失败");
            }
        }
       
        //将目录与文件加载到TreeView上
        private void LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.先根据路径获取所有的子文件和子文件夹
            //if (false == Directory.Exists(path)) //路径不存在，返回
            //    return;

            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);
            //2.把所有的子文件与子目录加到TreeView上。
            foreach (string item in files)
            {
                //把每一个子文件加到TreeView上
                treeNodeCollection.Add(Path.GetFileName(item));
            }
            //文件夹
            foreach (string item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));

                //由于目录，可能下面还存在子目录，所以这时要对每个目录再次进行获取子目录与子文件的操作
                //这里进行了递归
                LoadFilesAndDirectoriesToTree(item, node.Nodes);
            }

        }

        // tabControl2_SelectedIndexChanged标签页切换
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            outputLabel("切换标签页");
            tabPage2Index = this.tabControl2.SelectedIndex;

            //未加载，则不允许从“首页”切换到其他页。
            if (0 == gOid && 0 != tabPage2Index) //未加载，且当前页为首页不显示
            {
                MessageBox.Show("请加载用户信息！", "系统提示");
                this.tabControl1.SelectedIndex = 0; //跳到首页                 
                this.tabControl2.SelectedIndex = 0; //跳到首页                 
                return;
            }


            if ((0 <= tabPage2Index) && (8 >= tabPage2Index))
            {
                tabPage1Index = tabPage2Index;  //保存值
                
                switch (tabPage2Index)
                {
                    case 0:
                        this.tabControl1.SelectedIndex = 0;
                        break;
                    case 1:
                        this.tabControl1.SelectedIndex = 2;
                        break;
                    case 2:     //sheet2，加1
                        this.tabControl1.SelectedIndex = 3;
                        break;
                    case 3: //sheet3

                        this.tabControl1.SelectedIndex = 4;
                        break;
                    case 4:
                        this.tabControl1.SelectedIndex = 5;
                        break;
                    case 5:
                        this.tabControl1.SelectedIndex = 6;
                        break;
                    case 6:
                        this.tabControl1.SelectedIndex = 7;
                        break;
                    case 7: //sheet7
                        this.tabControl1.SelectedIndex = 8;
                        break;
                    default:
                        tabPage1Index = 100;
                        break;
                }

                
            }
            else
            {
                tabPage1Index = 100; //不存在的值
            }

            //首页则只显示首页按键，分页显示分页按键
            if (0 == tabPage1Index)
            {
                groupBox8.Visible = true;  //使能-总操作
                groupBox8.Enabled = true;

                groupBox6.Visible = false; //禁用-分操作
                groupBox6.Enabled = false;
            }
            else
            {
                groupBox8.Visible = false;  //禁用-总操作
                groupBox8.Enabled = false;

                groupBox6.Visible = true; //使能-分操作
                groupBox6.Enabled = true;
            }
        }

        //将所有dataGrid导出到excel，分sheet页导出
        private void button23_Click(object sender, EventArgs e)
        {
            //Step1， 获取用户ID
            DataTable dt = new DataTable();
            dt = (DataTable)(dataGridView1.DataSource); //保留现场

            outputLabel("2/5，收集数据");
            //Step2-7
            loadSheet2_7();

            Dictionary<string, DataGridView> Dic2Excel = new Dictionary<string, DataGridView> {
                  {"基本信息",dataGridView1} ,
                  {"新辅助",dgView2},
                  {"术后辅助化疗",dgView3},
                  {"随诊情况",dgView4},
                  {"文件档案",dgView5},
                  {"起病情况",dgView6},
                  {"术前评估",dgView7} };
            //Dictionary<string, DataGridView> Dic2Excel = new Dictionary<string, DataGridView> {
            //      {"基本信息",dataGridView1} ,
            //      {"新辅助",dgView2} };
            outputLabel("3/5，导出数据");
            CExcelSheet.setMoreExcelSheet2(Dic2Excel);

            outputLabel("4/5，还原现场");
            dataGridView1.DataSource = dt;
            gOid = 0;

            outputLabel("5/5，导出结束");
        }

        private void 文件FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 记事本NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start("notepad.exe");
            outputLabel("打开记事本");
            
        }

        private void 计算器CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
            outputLabel("打开计算器");
        }

        private void 打开数据库目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string currentDir = System.Windows.Forms.Application.StartupPath; //获取启动了应用程序的可执行文件的路径，“D：\fh_bk”形式，末尾不带“\”
                string fileDir = currentDir + @"\dataBase";  //保存路径
                if (Directory.Exists(fileDir) == false)//不存在,就创建NE文件夹
                {
                    Directory.CreateDirectory(fileDir);
                }

                outputLabel("打开数据库目录");
                System.Diagnostics.Process.Start("explorer.exe", fileDir);
            } //try
            catch (Exception objException)
            {
                outputLabel("打开数据库目录，失败");
            }
        }


        private void 帮忙文档LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outputLabel("打开帮助文档");
            try
            {
                string currentDir = System.Windows.Forms.Application.StartupPath; //获取当前路径，末尾不带“\”
                string fileDir = currentDir + @"\doc\readme.doc";  //保存路径
                if (File.Exists(fileDir) == false)//不存在,就退出
                {
                    outputLabel("帮助文件不存在");
                    return;
                }

               
                System.Diagnostics.Process.Start(fileDir);
            } //try
            catch (Exception objException)
            {
                outputLabel("打开帮助文档，失败");
            }
        }

        //导出当前加载的用户
        private void button2_Click(object sender, EventArgs e)
        {
            if (0 == gOid)
            {
                MessageBox.Show("当前用户未加载，退出!");
                return;
            }
            
            //Step1， 获取用户ID
            DataTable dt = new DataTable();
            dt = (DataTable)(dataGridView1.DataSource); //保留现场

            outputLabel("1/5，选择文件");
            string fileName = @"c:\all_.xls";
            save.FileName = "all_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (save.ShowDialog() == DialogResult.OK)
            {
                fileName = save.FileName;
            }
            else
            {
                return;
            }

            outputLabel("2/5，收集数据");
            string sql2 = "select * from Users where ID = " + gOid.ToString();
            databind(sql2, ref dataGridView1); //更新DataGridView1
            loadSheetBindOnly2();
            loadSheetBindOnly3();
            loadSheetBindOnly4();
            loadSheetBindOnly5();
            loadSheetBindOnly6();
            loadSheetBindOnly7();
                        
            outputLabel("3/5，处理数据");
            Dictionary<string, DataGridView> Dic2Excel = new Dictionary<string, DataGridView> {
                  {"基本信息",dataGridView1} ,
                  {"新辅助",dgView2},
                  {"术后辅助化疗",dgView3},
                  {"随诊情况",dgView4},
                  {"文件档案",dgView5},
                  {"起病情况",dgView6},
                  {"术前评估",dgView7} };
            outputLabel("3/5，导出数据");
            CExcelSheet.setMoreExcelSheet2(Dic2Excel, fileName);

            outputLabel("4/5，还原现场");
            //databind(sql1, dataGridView1); //还原DataGridView1
            dataGridView1.DataSource = dt;
            
            outputLabel("5/5，导出结束");
        }

        //导出查询结果
        private void button8_Click(object sender, EventArgs e)
        {
            //Step1， 获取用户ID
            string sql1 = "select ID from Users ";
            if (textBox23.Text.Trim() != "")  //内容为空，取所有值
            {
                string checkType = comboBox19.Text; //查询条件
                switch (checkType)
                {
                    case "编码":
                        sql1 = sql1 + "where sBianMa='" + textBox23.Text.Trim() + "'";
                        break;
                    case "姓名":
                        sql1 = sql1 + "where sName='" + textBox23.Text.Trim() + "'";
                        break;
                    default:
                        break;
                }
            }

            if ((dataGridView1.DataSource as DataTable).Rows.Count == 0) //绑定的数据源，但数据为空
            {
                MessageBox.Show("数据为空，退出!");
                return;
            }
            //dataGridView1.Rows[0].Selected = true; //取第一行
            //buttonUpdate.PerformClick(); //加载，产生DataGridView报头。
            //tabControl1.SelectedIndex = 0; //跳到首页
            
            outputLabel("1/5，选择文件");
            string fileName = @"c:\all_.xls";            
            save.FileName = "all_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (save.ShowDialog() == DialogResult.OK)
            {
                fileName = save.FileName;
            }
            else
            {
                return;
            }

            outputLabel("2/5，收集数据");
            //Step2-7
            string sql2 = "select * from s2XinFuZhu where iUserID in (" + sql1 + ")";
            databind(sql2, ref  dgView2); //更新DataGridView2
            sql2 = "select * from s3ShuHouFuZhu where iUserID in (" + sql1 + ")"; //dos3ShuHouFuZhu
            databind(sql2, ref  dgView3);
            sql2 = "select * from s4SuiZhen where iUserID in (" + sql1 + ")"; //dos4SuiZhen
            databind(sql2, ref  dgView4);
            sql2 = "select * from s5ShuJuCunZhu where iUserID in (" + sql1 + ")"; //dos5ShuJuCunZhu
            databind(sql2, ref  dgView5);
            sql2 = "select * from s6QiBingQingKuang where iUserID in (" + sql1 + ")"; //dos6QiBingQingKuang
            databind(sql2, ref  dgView6);
            sql2 = "select * from s7ShuQianPingGu where iUserID in (" + sql1 + ")"; //dos7ShuQianPingGu
            databind(sql2, ref  dgView7);

            outputLabel("4/5，处理数据");
            Dictionary<string, DataGridView> Dic2Excel = new Dictionary<string, DataGridView> {
                  {"基本信息",dataGridView1} ,
                  {"新辅助",dgView2},
                  {"术后辅助化疗",dgView3},
                  {"随诊情况",dgView4},
                  {"文件档案",dgView5},
                  {"起病情况",dgView6},
                  {"术前评估",dgView7} };
            //Dictionary<string, DataGridView> Dic2Excel = new Dictionary<string, DataGridView> {
            //      {"基本信息",dataGridView1} ,
            //      {"新辅助",dgView2} };
            outputLabel("3/5，导出数据");
            CExcelSheet.setMoreExcelSheet2(Dic2Excel, fileName);
            outputLabel("5/5，导出结束");
        }

        private void 数据库备份BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //显示folderBrowserDialog1控件
                FolderBrowserDialog fbdPath = new FolderBrowserDialog();
                fbdPath.Description = "目录选择...";
                if (fbdPath.ShowDialog() == DialogResult.OK)
                {

                    if (fbdPath.SelectedPath.IndexOf(" ") < 0) //路径非空
                    {
                        string PC_Path = fbdPath.SelectedPath + @"\"; //路径最后默认不加\
                        outputLabel("选择目录");
                        string currentDir = System.Windows.Forms.Application.StartupPath; //获取启动了应用程序的可执行文件的路径，“D：\fh_bk”形式，末尾不带“\”
                        string fileDb = currentDir + @"\dataBase\linChuang.accdb";  //保存路径
						string fileUserIni = currentDir + @"\ini\config.ini";  //保存User的自动编号信息
						string fileSheetIni = currentDir + @"\ini\configTab.ini";  //保存sheet2-sheet7的自动编号信息

                        //备份前验证
						if (true == File.Exists(PC_Path + Path.GetFileName(fileDb)))
                        {
                            MessageBox.Show("错误！您选择的目录中已存在同名数据库文件，退出!", "系统提示");
                            return;
                        }
						
						if (true == File.Exists(PC_Path + Path.GetFileName(fileUserIni)))
                        {
                            MessageBox.Show("错误！您选择的目录中已存在同名config.ini文件，退出!", "系统提示");
                            return;
                        }
						
						if (true == File.Exists(PC_Path + Path.GetFileName(fileSheetIni)))
                        {
                            MessageBox.Show("错误！您选择的目录中已存在同名configTab.ini文件，退出!", "系统提示");
                            return;
                        }

                        //拷贝到路径 
                        File.Copy(fileDb, PC_Path + Path.GetFileName(fileDb));
						File.Copy(fileUserIni, PC_Path + Path.GetFileName(fileUserIni));
						File.Copy(fileSheetIni, PC_Path + Path.GetFileName(fileSheetIni));
                        
						outputLabel("备份数据库，结束");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("错误！您选择的文件目录中带有空格，请重新选择: " + fbdPath.SelectedPath, "系统提示");
                        return;
                    }

                }
            }//try
            catch (Exception objException)
            {
                outputLabel("备份数据库，失败");
                MessageBox.Show("备份数据库,错误！\n" + objException.ToString(), "提示");
                return;
            }

        }

        private void 打开数据库目录OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string currentDir = System.Windows.Forms.Application.StartupPath; //获取启动了应用程序的可执行文件的路径，“D：\fh_bk”形式，末尾不带“\”
                string fileDir = currentDir + @"\dataBase";  //保存路径
                if (Directory.Exists(fileDir) == false)//不存在,就创建NE文件夹
                {
                    Directory.CreateDirectory(fileDir);
                }

                outputLabel("打开数据库目录");
                System.Diagnostics.Process.Start("explorer.exe", fileDir);
            } //try
            catch (Exception objException)
            {
                outputLabel("打开数据库目录，失败");
            }
        }

        private void 关于信息记录系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //步骤5，自动更新编译时间，指示版本号
            string ver = "ver" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); //获取程序集的版本号, V1.0
            string timeComp = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString();    //获取程序集的最后编译时间，日期+时间
            //string timeComp = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToShortDateString();  //编译日期, 
            MessageBox.Show("程序版本：\n" + ver + ", " + timeComp +"\n技术支持邮箱: nawenyi@126.com", "信息记录系统");              //ver 1.0.2, 2016.4
            
        }

        //上传路径1
        private void button34_Click(object sender, EventArgs e)
        {             
            try
            {
                outputLabel("s5上传文件");
                string s5BianMa = label116.Text.Trim(); //保存文件名，以命名编码为文件夹名
                string stringBin = comboBox26.Text.Trim(); //获取文件目录位置
                string fileDir = ftpRootPath + s5BianMa + @"\" + stringBin + @"\"; //保存到路径
                
                OpenFileDialog filePath = new OpenFileDialog();
				filePath.InitialDirectory = fileDir; //初始路径
                filePath.Title = "选择上传文件";
                filePath.Filter = "All files(*.*)|*.*"; //设备控件保存的文件类型
                filePath.FilterIndex = 1; //默认打开*.ini            
                filePath.RestoreDirectory = true; //记忆之前打开的目录
                filePath.FileName = "";
                
                if (filePath.ShowDialog() == DialogResult.OK)
                {
                    string fileNe = filePath.FileName; //保存文件名
                    outputLabel("选择文件");

                    //拷贝到路径，路径不存在则创建 
                    if (false == Directory.Exists(fileDir))
                    {
                        Directory.CreateDirectory(fileDir);
                    }

                    //获取新文件名
                    string newFileName = fileNe;
                    switch (comboBox26.Text.Trim())
                    {
                        case "CT":
                            newFileName = s5BianMa + "_C01";
                            break;
                        case "磁共振":
                            newFileName = s5BianMa + "_M01";
                            break;
                        case "PET":
                            newFileName = s5BianMa + "_E01";
                            break;
                        case "病理":
                            newFileName = s5BianMa + "_P01";
                            break;

                        default:
                            newFileName = s5BianMa + "_error";
                            break;
                    }
                    //文件存在则报错
                    if (true == File.Exists(fileDir + Path.GetFileName(newFileName)))
                    {
                        MessageBox.Show("当前目录已存在同名文件，退出！","系统提示");
                        return;
                    }
                    string fileType = Path.GetExtension(fileNe); //获取文件后辍
                    File.Copy(fileNe, fileDir + Path.GetFileName(newFileName + fileType));

                    button12.PerformClick(); //刷新，显示treeview
                }
            } //try
            catch (Exception objException)
            {
                outputLabel("s5上传文件，失败\n" + objException);
            }
        }

        //编码跟随编号动作
        private void comboBox7Sheet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = "next";
            resultIni = ""; //清空
            switch (comboBox7Sheet1.Text.Trim())
            {
                
                case "胃":  //胃G0001
                    Section = "胃";                    
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "G" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                case "十二指肠"://十二指肠D0001
                    Section = "十二指肠";
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "D" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                case "小肠"://小肠S0001
                    Section = "小肠";
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "S" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                case "结肠"://结肠C0001
                    Section = "结肠";
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "C" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                case "直肠"://直肠R0001
                    Section = "直肠";
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "R" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                case "胃食管结合部"://胃食管结合部E0001
                    Section = "胃食管结合部";
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "E" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                case "肛管"://肛管A0001
                    Section = "肛管";
                    next = ReadIniData(Section, Key, NoText, iniFilePath);  //1，获取编码
                    resultIni += "A" + next.PadLeft(4, '0'); //字符串不足4位补0
                    break;
                default:
                    resultIni = "None";
                    break;
            }

            label83.Text = resultIni + "-B";  //编码G0001-B
        }



        #region sheet4

        #endregion

        #region sheet5

        #endregion

        #region sheet6

        #endregion

        #region sheet7

        #endregion

    }
}
