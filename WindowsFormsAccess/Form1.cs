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
            textBox81.Text = ""; //清空
            textBox81.Enabled = false; 
            button12.Enabled = false; //禁用treeview
            button31.Enabled = false; //禁用按键
            button33.Enabled = false; //禁用按键
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

            //foreach (Control i in groupBox8.Controls)
            //{
            //    if (i is TextBox)
            //        i.Text = "";
            //    else if (i is ComboBox)
            //        i.Text = "";
            //}



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

            //读取sheet4内容到页面
            sql1 = "select * from s4SuiZhen where iUserID='" + gOid.ToString() + "'"; //重新刷新
            databind(sql1, dgView4);
            dgView4.Columns[0].Visible = false;
            dgView4.Columns[1].HeaderCell.Value = "编码";
            dgView4.Columns[2].HeaderCell.Value = "随诊次数";
            dgView4.Columns[3].HeaderCell.Value = "随诊时间";
            dgView4.Columns[4].HeaderCell.Value = "住院号";
            dgView4.Columns[5].HeaderCell.Value = "CT";
            dgView4.Columns[6].HeaderCell.Value = "MRI";
            dgView4.Columns[7].HeaderCell.Value = "内镜";
            dgView4.Columns[8].HeaderCell.Value = "PET";
            dgView4.Columns[9].HeaderCell.Value = "复发";
            dgView4.Columns[10].HeaderCell.Value = "用户ID";

            //读取sheet5内容到页面
            sql1 = "select * from s5ShuJuCunZhu where iUserID='" + gOid.ToString() + "'"; //重新刷新
            databind(sql1, dgView5);
            dgView5.Columns[0].Visible = false;
            dgView5.Columns[1].HeaderCell.Value = "档案号/编码";
            dgView5.Columns[2].HeaderCell.Value = "CT";
            dgView5.Columns[3].HeaderCell.Value = "磁共振";
            dgView5.Columns[4].HeaderCell.Value = "病理";
            dgView5.Columns[5].HeaderCell.Value = "用户ID";

            //读取sheet6内容到页面
            sql1 = "select * from s6QiBingQingKuang where iUserID='" + gOid.ToString() + "'"; //重新刷新
            databind(sql1, dgView6);
            dgView6.Columns[0].Visible = false;
            dgView6.Columns[1].HeaderCell.Value = "编码";
            dgView6.Columns[2].HeaderCell.Value = "肿瘤位置";
            dgView6.Columns[3].HeaderCell.Value = "首发症状";
            dgView6.Columns[4].HeaderCell.Value = "时间";
            dgView6.Columns[5].HeaderCell.Value = "初步诊断时间";
            dgView6.Columns[6].HeaderCell.Value = "诊断依据";
            dgView6.Columns[7].HeaderCell.Value = "用户ID";
            
            //读取sheet7内容到页面
            sql1 = "select * from s7ShuQianPingGu where iUserID='" + gOid.ToString() + "'"; //重新刷新
            databind(sql1, dgView7);
            dgView7.Columns[0].Visible = false;
            dgView7.Columns[1].HeaderCell.Value = "编码";
            dgView7.Columns[2].HeaderCell.Value = "我院病检";
            dgView7.Columns[3].HeaderCell.Value = "结果";
            dgView7.Columns[4].HeaderCell.Value = "病理号";
            dgView7.Columns[5].HeaderCell.Value = "我院CT";
            dgView7.Columns[6].HeaderCell.Value = "肿瘤大小";
            dgView7.Columns[7].HeaderCell.Value = "局部侵犯";
			dgView7.Columns[8].HeaderCell.Value = "淋巴结转移";
			dgView7.Columns[9].HeaderCell.Value = "转移";
			dgView7.Columns[10].HeaderCell.Value = "部位";
			dgView7.Columns[11].HeaderCell.Value = "我院MRI";
			dgView7.Columns[12].HeaderCell.Value = "MRI肿瘤大小";
			dgView7.Columns[13].HeaderCell.Value = "MRI局部侵犯";
			dgView7.Columns[14].HeaderCell.Value = "MRI淋巴转移";
			dgView7.Columns[15].HeaderCell.Value = "MRI转移";
			dgView7.Columns[16].HeaderCell.Value = "MRI部位";
			dgView7.Columns[17].HeaderCell.Value = "PET";
			dgView7.Columns[18].HeaderCell.Value = "PET肿瘤大小";
			dgView7.Columns[19].HeaderCell.Value = "PET局部侵犯";
			dgView7.Columns[20].HeaderCell.Value = "PET代谢强度";
			dgView7.Columns[21].HeaderCell.Value = "PET淋巴转移";
			dgView7.Columns[22].HeaderCell.Value = "PET转移";
			dgView7.Columns[23].HeaderCell.Value = "PET部位";
			dgView7.Columns[24].HeaderCell.Value = "转移部位代谢强度";
			dgView7.Columns[25].HeaderCell.Value = "CT";   
			dgView7.Columns[26].HeaderCell.Value = "CN";   
			dgView7.Columns[27].HeaderCell.Value = "CM";   
			dgView7.Columns[28].HeaderCell.Value = "WBC";  
			dgView7.Columns[29].HeaderCell.Value = "Hb";   
			dgView7.Columns[30].HeaderCell.Value = "ALB";  
			dgView7.Columns[31].HeaderCell.Value = "CEA";  
			dgView7.Columns[32].HeaderCell.Value = "CA125";
			dgView7.Columns[33].HeaderCell.Value = "CA199";
			dgView7.Columns[34].HeaderCell.Value = "CA724";
			dgView7.Columns[35].HeaderCell.Value = "AFP";  
			dgView7.Columns[36].HeaderCell.Value = "是否梗阻";
			dgView7.Columns[37].HeaderCell.Value = "是否出血";
			dgView7.Columns[38].HeaderCell.Value = "是否穿孔";
			dgView7.Columns[39].HeaderCell.Value = "BMI";
			dgView7.Columns[40].HeaderCell.Value = "NRS2002";
			dgView7.Columns[41].HeaderCell.Value = "疼痛评分";
			dgView7.Columns[42].HeaderCell.Value = "ECOG";
			dgView7.Columns[43].HeaderCell.Value = "心功能";
			dgView7.Columns[44].HeaderCell.Value = "肺功能";
			dgView7.Columns[45].HeaderCell.Value = "肾功能";
			dgView7.Columns[46].HeaderCell.Value = "肝功能";
			dgView7.Columns[47].HeaderCell.Value = "凝血功能";
			dgView7.Columns[48].HeaderCell.Value = "是否急诊手术";
			dgView7.Columns[49].HeaderCell.Value = "手术日期";
			dgView7.Columns[50].HeaderCell.Value = "腔镜/开腹";
			dgView7.Columns[51].HeaderCell.Value = "术式";
			dgView7.Columns[52].HeaderCell.Value = "手术时间";
			dgView7.Columns[53].HeaderCell.Value = "开腹吻合时间";
			dgView7.Columns[54].HeaderCell.Value = "肿瘤具体位置";
			dgView7.Columns[55].HeaderCell.Value = "联合器脏切除";
			dgView7.Columns[56].HeaderCell.Value = "出血量";
			dgView7.Columns[57].HeaderCell.Value = "腹腔污染";
			dgView7.Columns[58].HeaderCell.Value = "副损伤";
			dgView7.Columns[59].HeaderCell.Value = "是否营养管";
			dgView7.Columns[60].HeaderCell.Value = "是否造篓";
			dgView7.Columns[61].HeaderCell.Value = "是否术中病理";
			dgView7.Columns[62].HeaderCell.Value = "结果2";
			dgView7.Columns[63].HeaderCell.Value = "切除情况";
			dgView7.Columns[64].HeaderCell.Value = "淋巴结清扫";
			dgView7.Columns[65].HeaderCell.Value = "特殊说明";
			dgView7.Columns[66].HeaderCell.Value = "ERAS";
			dgView7.Columns[67].HeaderCell.Value = "ICU监护";
			dgView7.Columns[68].HeaderCell.Value = "监护时间";
			dgView7.Columns[69].HeaderCell.Value = "进水时间";
			dgView7.Columns[70].HeaderCell.Value = "通气时间";
			dgView7.Columns[71].HeaderCell.Value = "排便时间";
			dgView7.Columns[72].HeaderCell.Value = "腹痛缓解时间";
			dgView7.Columns[73].HeaderCell.Value = "尿管拔除时间";
			dgView7.Columns[74].HeaderCell.Value = "引流管拔除时间";
			dgView7.Columns[75].HeaderCell.Value = "下床时间";
			dgView7.Columns[76].HeaderCell.Value = "进食时间";
			dgView7.Columns[77].HeaderCell.Value = "是否肠内营养管";
			dgView7.Columns[78].HeaderCell.Value = "肠内营养管时间";
			dgView7.Columns[79].HeaderCell.Value = "TPN时间";
			dgView7.Columns[80].HeaderCell.Value = "术后出血";
			dgView7.Columns[81].HeaderCell.Value = "腹腔感染";
			dgView7.Columns[82].HeaderCell.Value = "切口感染";
			dgView7.Columns[83].HeaderCell.Value = "吻合口瘘";
			dgView7.Columns[84].HeaderCell.Value = "肠梗阻";
			dgView7.Columns[85].HeaderCell.Value = "胃瘫";
			dgView7.Columns[86].HeaderCell.Value = "肺部感染";
			dgView7.Columns[87].HeaderCell.Value = "低蛋白血症";
			dgView7.Columns[88].HeaderCell.Value = "胃管脱出";
			dgView7.Columns[89].HeaderCell.Value = "营养管脱出";
			dgView7.Columns[90].HeaderCell.Value = "造口并发症";
			dgView7.Columns[91].HeaderCell.Value = "是否二次手术";
			dgView7.Columns[92].HeaderCell.Value = "手术时间2";
			dgView7.Columns[93].HeaderCell.Value = "手术方式2";
			dgView7.Columns[94].HeaderCell.Value = "解决问题";
			dgView7.Columns[95].HeaderCell.Value = "术后病理诊断";
			dgView7.Columns[96].HeaderCell.Value = "分化程度";
			dgView7.Columns[97].HeaderCell.Value = "浸润深度";
			dgView7.Columns[98].HeaderCell.Value = "脉管癌栓";
			dgView7.Columns[99].HeaderCell.Value = "神经侵犯";
			dgView7.Columns[100].HeaderCell.Value = "癌结节";
			dgView7.Columns[101].HeaderCell.Value = "总淋巴结数";
			dgView7.Columns[102].HeaderCell.Value = "转移淋巴结数";
			dgView7.Columns[103].HeaderCell.Value = "MSI";  
			dgView7.Columns[104].HeaderCell.Value = "HER_2";
			dgView7.Columns[105].HeaderCell.Value = "P53";
			dgView7.Columns[106].HeaderCell.Value = "Ki_67";
			dgView7.Columns[107].HeaderCell.Value = "K_RAS";
			dgView7.Columns[108].HeaderCell.Value = "N_RAS";
			dgView7.Columns[109].HeaderCell.Value = "术后病理分期";
			dgView7.Columns[110].HeaderCell.Value = "MSI确证";
			dgView7.Columns[111].HeaderCell.Value = "基因检测";
			dgView7.Columns[112].HeaderCell.Value = "出院时间";
			dgView7.Columns[113].HeaderCell.Value = "出院情况";
			dgView7.Columns[114].HeaderCell.Value = "医疗费用";
			dgView7.Columns[115].HeaderCell.Value = "用户ID";

		

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

            //sheet5
            textBox81.Text = ""; //清空
            button12.Enabled = false; //禁用treeview
            button31.Enabled = false; //禁用按键
            button33.Enabled = false; //禁用按键
            textBox81.Enabled = false;

            foreach (Control i in groupBox7.Controls) //清空sheet4
            {
                if (i is TextBox)
                    i.Text = "";
                else if (i is ComboBox)
                    i.Text = "";
            }

            //foreach (Control i in groupBox8.Controls)
            //{
            //    if (i is TextBox)
            //        i.Text = "";
            //    else if (i is ComboBox)
            //        i.Text = "";
            //}

            //置位为新增状态
            gFlagAdd = 1;
        }

        // 删除记录
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //deleteSheet1();
            //待增加sheet2-sheet7的删除
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            CExcel excelExport = new CExcel();
            excelExport.ExportExcel("123", dataGridView1, saveFileDialog);
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


        /// TreeView必须处理的两个事件之一  
        private void treeViewS5_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();  
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
            tabPage1Index = this.tabControl1.SelectedIndex; //读取当前操作tab页
            switch (tabPage1Index)
            {
                case 0:
                    tabPage2Index = 0;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 1:     
                    tabPage2Index = 1;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 2:

                    tabPage2Index = 2;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 3:    
                    tabPage2Index = 3;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 4:             
                    tabPage2Index = 4;
                    button25.Enabled = true; //detail-保存使能
                    break;
                case 5:           
                    tabPage2Index = 5;
                    button25.Enabled = true; //detail-保存使能

                    textBox81.Text = ""; //清空
                    button12.Enabled = false; //禁用treeview
                    button31.Enabled = false; //禁用按键
                    button33.Enabled = false; //禁用按键
                    textBox81.Enabled = false;
                    break;
                case 6: //sheet
                    tabPage2Index = 6;
                    button25.Enabled = false; //detail-保存, 不使能
                    break;
                case 7:
                    tabPage2Index = 0;
                    break;
                
                default:
                    tabPage1Index = 100;
                    break;
            }
            outputLabel("tabpage: " + tabPage1Index.ToString());
            if (100 != tabPage2Index)
            {
                this.tabControl2.SelectedIndex = tabPage2Index;
            }
        }

        #region 全局
        //保存，全局，区别于每个sheet页面上按键
        private void button25_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3: //sheet4
                    updateSheet4(); //保存
                    //sheet 4; //清空
                    foreach (Control i in groupBox7.Controls)
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
                case 4:  //sheet5
                    updateSheet5(); //保存
                    break;
                case 5:  //sheet6 起病情况
                    updateSheet6();
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
      
                    break;
                case 6: //sheet7

                    break;
                case 7:

                    break;
                default:

                    break;
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
                case 2:

                    break;
                case 3: //sheet4
                    gFlagAdd4 = 1; //新建，局部新增
                    foreach (Control i in groupBox7.Controls)
                    {
                        if (i is TextBox)
                            i.Text = "";
                        else if (i is ComboBox)
                            i.Text = "";
                    }
                    foreach (Control i in groupBox7.Controls) //使能
                    {
                        if (i is TextBox)
                            i.Enabled = true;
                        else if (i is ComboBox)
                            i.Enabled = true;
                    }
                    break;
                case 4: //sheet5

                    gFlagAdd5 = 1; //新建，局部新增
                    //清空
                   textBox81.Text = "";
                   treeViewS5.Nodes.Clear(); //清空treeview                 
                   button12.Enabled = false; //禁用刷新按键
                   button31.Enabled = false; //禁用按键
                   button33.Enabled = false; //禁用按键
                   textBox81.Enabled = true;  //使能
                   break;
                case 5:  //sheet6 起病情况
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
                   }
                    break;
                case 6: //sheet7
                    FormSheet7 f7 = new FormSheet7(); //创建一个新窗口7
                    f7.iUserID = gOid.ToString(); //iUserID必须带过去
                    
                    f7.ShowDialog();
                    string sql1 = "select * from s7ShuQianPingGu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                    databind(sql1, dgView7);
  
                    break;
                case 7:

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
                case 2:

                    break;
                case 3: //sheet4
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
                case 4: //sheet5
                    deleteSheet5();
                    //清空
                    textBox81.Text = "";
                    treeViewS5.Nodes.Clear(); //清空treeview                 
                    button12.Enabled = false; //禁用刷新按键
                    button31.Enabled = false; //禁用按键
                    button33.Enabled = false; //禁用按键
                    textBox81.Enabled = false;
                    break;
                case 5:  //sheet6 起病情况
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
                case 6: //sheet 7，不需要清空窗体
                    deleteSheet7();
                    break;
                case 7:

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
                case 2:

                    break;
                case 3:  //sheet4
                    readSheet4();
                    foreach (Control i in groupBox7.Controls) //禁用
                    {
                        if (i is TextBox)
                            i.Enabled = true;
                        else if (i is ComboBox)
                            i.Enabled = true;
                    }
                    break;
                case 4: //sheet5， 加载
                    readSheet5(); 
                    //使能                 
                    button12.Enabled = true; //使能刷新按键
                    button31.Enabled = true; //
                    button33.Enabled = true; //
                    textBox81.Enabled = true;
                    //Delay(1000); //延时
                    button12.PerformClick(); //显示treeview
                    break;
                case 5:  //sheet6
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
                case 6:  //sheet7
                    FormSheet7 f7 = new FormSheet7();
                    bool ret = readSheet7(ref f7);
                    if (true == ret)
                    {
                        f7.ShowDialog();
                        string sql1 = "select * from s7ShuQianPingGu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                        databind(sql1, dgView7);
                    }
                    break;
                case 7:

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
                if (textBox81.Text == "") //档案号不能为空
                {
                    MessageBox.Show("档案号不能为空");
                    return;
                }

                string fileDir = ftpRootPath + textBox81.Text.Trim();
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
                if (textBox81.Text == "") //档案号不能为空
                {
                    MessageBox.Show("档案号不能为空");
                    return;
                }

                string fileDir = ftpRootPath + textBox81.Text.Trim();
                
                
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
            string path = ftpRootPath + textBox81.Text.Trim();  //获取用户输入的一个路径
            treeViewS5.Nodes.Clear();  //清除所有结构，避免二次刷新时重复显示            
            LoadFilesAndDirectoriesToTree(path, treeViewS5.Nodes);  //调用该方法实现将指定路径下的子文件与子目录按照层次结构加载到TreeView
            #endregion
                        
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

            if ((0 <= tabPage2Index) && (7 >= tabPage2Index))
            {
                tabPage1Index = tabPage2Index;  //保存值
                this.tabControl1.SelectedIndex = tabPage1Index;
            }
            else
            {
                tabPage1Index = 100; //不存在的值
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
