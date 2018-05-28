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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            achelp = new AccessHelper();        //定义变量，设置列标题；       
            initDo(); //所有初始化          

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
            string sql1 = "None"; //保存sql语句

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
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            foreach (Control i in groupBox2.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            foreach (Control i in groupBox5.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                {
                    i.Text = "";
                }

                //所有下拉框，取默认值，待补
            }

            //foreach (Control i in groupBox6.Controls)
            //{
            //    if (i is TextBox)
            //        i.Text = "";
            //    else if (i is ComboBox)
            //        i.Text = "";
            //}

            foreach (Control i in groupBox7.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            foreach (Control i in groupBox8.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            //step3
            object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //更新全局oid

            readSheet1(gOid);   //读取sheet1内容到页面1

            //读取sheet2内容到页面
            sql1 = "select * from s2XinFuZhu where iUserID='" +gOid.ToString() + "'"; //重新刷新
            databind(sql1, dgView2);
            dgView2.Columns[0].Visible = false;             //dgView2, sheet2
            dgView2.Columns[1].HeaderCell.Value = "编码";
            dgView2.Columns[2].HeaderCell.Value = "新辅助";
            dgView2.Columns[3].HeaderCell.Value = "住院号";
            dgView2.Columns[4].HeaderCell.Value = "方案";
            dgView2.Columns[5].HeaderCell.Value = "剂量";
            dgView2.Columns[6].HeaderCell.Value = "疗程";
            dgView2.Columns[7].HeaderCell.Value = "疗效评价";
            dgView2.Columns[8].HeaderCell.Value = "放疗方案";
            dgView2.Columns[9].HeaderCell.Value = "放疗疗程";
            dgView2.Columns[10].HeaderCell.Value = "术前二次病检";
            dgView2.Columns[11].HeaderCell.Value = "结果";
            dgView2.Columns[12].HeaderCell.Value = "新辅助放疗";
            dgView2.Columns[13].HeaderCell.Value = "UserID";

            //读取sheet3内容到页面
            sql1 = "select * from s3ShuHouFuZhu where iUserID='" + gOid.ToString() + "'"; //重新刷新
            databind(sql1, dgView3);
            dgView3.Columns[0].Visible = false;
            dgView3.Columns[1].HeaderCell.Value = "编码";
            dgView3.Columns[2].HeaderCell.Value = "辅助化疗";
            dgView3.Columns[3].HeaderCell.Value = "周期";
            dgView3.Columns[4].HeaderCell.Value = "方案";
            dgView3.Columns[5].HeaderCell.Value = "体表面积";
            dgView3.Columns[6].HeaderCell.Value = "实际剂量";
            dgView3.Columns[7].HeaderCell.Value = "WBC";
            dgView3.Columns[8].HeaderCell.Value = "Hb";
            dgView3.Columns[9].HeaderCell.Value = "PLT";
            dgView3.Columns[10].HeaderCell.Value = "BMI";
            dgView3.Columns[11].HeaderCell.Value = "NRS2002";
            dgView3.Columns[12].HeaderCell.Value = "ECOG";
            dgView3.Columns[13].HeaderCell.Value = "复查";
            dgView3.Columns[14].HeaderCell.Value = "CT";
            dgView3.Columns[15].HeaderCell.Value = "MRI";
            dgView3.Columns[16].HeaderCell.Value = "内镜";
            dgView3.Columns[17].HeaderCell.Value = "PET";
            dgView3.Columns[18].HeaderCell.Value = "复发";
            dgView3.Columns[19].HeaderCell.Value = "位置";
            dgView3.Columns[20].HeaderCell.Value = "处理方式";
            dgView3.Columns[21].HeaderCell.Value = "剂量";
            dgView3.Columns[22].HeaderCell.Value = "疗程";
            dgView3.Columns[23].HeaderCell.Value = "疗效评价";
            dgView3.Columns[24].HeaderCell.Value = "用户ID";
            dgView3.Columns[25].HeaderCell.Value = "住院号";
            dgView3.Columns[26].HeaderCell.Value = "靶向药物";
            dgView3.Columns[27].HeaderCell.Value = "药物品种";
            dgView3.Columns[27].HeaderCell.Value = "检测结果";
            
            
            
            //readSheetX(gOid);   //读取内容到页面

            //测试同一sheet存在多个ID和单ID
            //ycyxDo.GetListID("iUserID = 5");

            //置位为查看状态
            gFlagAdd = 0;
        }

        //添加记录；
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //清空所有sheet并跳到“基本信息页面”
            foreach (Control i in groupBox1.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            foreach (Control i in groupBox2.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            foreach (Control i in groupBox5.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                {
                    i.Text = "";                    
                }

                //所有下拉框，取默认值，待补
            }

            //foreach (Control i in groupBox6.Controls)
            //{
            //    if (i is TextBox)
            //        i.Text = "";
            //    else if (i is ComboBox)
            //        i.Text = "";
            //}

            foreach (Control i in groupBox7.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            foreach (Control i in groupBox8.Controls)
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            //置位为新增状态
            gFlagAdd = 1;
        }

        // 删除记录
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteSheet1();
            //deleteSheetX();
        }

        //查询
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                //MessageBox.Show("请输入要查询的员工当前部门", "系统提示");
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
            // DriveInfo[] myDrivers = DriveInfo.GetDrives();  //添加所有磁盘
            //foreach (DriveInfo di in myDrivers)  
            //{  
            //    if (di.IsReady)  
            //    {  
            //        TreeNode tNode = new TreeNode(di.Name.Split(':')[0]);  
            //        tNode.Name = di.Name;  
            //        tNode.Tag = tNode.Name;
            //        tNode.ImageIndex = 3;         //获取结点显示图片  ,IconIndexes.FixedDrive
            //        tNode.SelectedImageIndex = 3; //选择显示图片, IconIndexes.FixedDrive  
            //        tNode.Nodes.Add("DUMMY");
            //        treeViewS5.Nodes.Add(tNode); //加载驱动节点
                    
            //    }  
            //}
            TreeNode tNode = new TreeNode(@"Y:\project\20180508-access\wfsAccessSvn\test");
            tNode.Name = "文档结构";
            tNode.Tag = tNode.Name;
            tNode.ImageIndex = 3;         //获取结点显示图片  ,IconIndexes.FixedDrive
            tNode.SelectedImageIndex = 3; //选择显示图片, IconIndexes.FixedDrive  
            tNode.Nodes.Add("DUMMY");
            treeViewS5.Nodes.Add(tNode); //加载驱动节点

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
            switch (this.tabControl1.SelectedIndex)
            {
                //case 0:
                //    this.tabControl2.SelectedIndex = 2;
                //    break;
                //case 3:
                //    this.tabControl2.SelectedIndex = 3;
                //    break;
                //case 5:
                //    this.tabControl2.SelectedIndex = 0;
                //    break;
                default:
                    break;
            }
        }

        #region 全局
        //保存，全局，区别于每个sheet页面上按键
        private void button25_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    this.tabControl2.SelectedIndex = 2;
                    break;
                case 3:
                    this.tabControl2.SelectedIndex = 3;
                    break;
                case 5:
                    this.tabControl2.SelectedIndex = 0;
                    break;
                case 6:
                    this.tabControl2.SelectedIndex = 1;
                    break;
                case 7:
                    this.tabControl2.SelectedIndex = 6;
                    break;
                case 8:
                    this.tabControl2.SelectedIndex = 5;
                    break;
                default:
                    
                    break;
            }
        }
        //新建，全局
        private void button11_Click(object sender, EventArgs e)
        {

        }
        //删除，全局
        private void button9_Click(object sender, EventArgs e)
        {

        }
        //加载，全局
        private void button24_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

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
                string fileDir;  //初始路径
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
             #region 递归加载所有的目录，按照层次结构显示到TreeView 上

            //获取用户输入的一个路径
            string path = textBox1.Text.Trim();
            //调用该方法实现将指定路径下的子文件与子目录按照层次结构加载到TreeView
            LoadFilesAndDirectoriesToTree(path, treeViewS5.Nodes);
            #endregion
        }
       
  //将目录与文件加载到TreeView上
        private void LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.先根据路径获取所有的子文件和子文件夹
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
