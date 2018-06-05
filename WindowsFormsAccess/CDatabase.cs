using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Drawing;

namespace WindowsFormsAccess
{
    public partial class Form1 : Form
    {        
        
        #region 公用方法/变量
        int gOid = 0; //全局oid，记录Users的ID号, s1
        int gOid2 = 0; //全局oid，记录s2的ID号
        int gOid3 = 0; //全局oid，记录s3的ID号
        int gOid4 = 0; //全局oid，记录s4的ID号
        int gOid5 = 0; //全局oid，记录s5的ID号
        int gOid6 = 0; //全局oid，记录s6的ID号
        int gOid7 = 0; //全局oid，记录s7的ID号
        int gFlagAdd = 0; //默认为查看，其他值则为新增，全局
        int gFlagAdd2 = 0; //默认为查看，其他值则为新增,局部新增s2
        int gFlagAdd3 = 0; //默认为查看，其他值则为新增
        int gFlagAdd4 = 0; //默认为查看，其他值则为新增
        int gFlagAdd5 = 0; //默认为查看，其他值则为新增
        int gFlagAdd6 = 0; //默认为查看，其他值则为新增
        int gFlagAdd7 = 0; //默认为查看，其他值则为新增

        int tabPage1Index = 100; //tabControl1索引
        int tabPage2Index = 100; //tabControl2索引

        string ftpRootPath = @"d:\ftp\"; //文件存放位置
        bool bXinJian = false; //新建则为true,控制detail-datagridview的操作控件使能（false）/禁用(true)。
                               //新建则控件禁用，加载后恢复使能
                               //防止在未创建“用户基本信息”时，先创建后面的sheet2-sheet7信息，导致信息不可用

            //日志输出函数
        private void output(string log)
        {
            try
            {
                //如果日志超过100行，则自动清空；                
                if (txtLog.GetLineFromCharIndex(txtLog.Text.Length) > 100)
                {
                    //清空显示框
                    txtLog.Text = "";
                } //if 日志超过100行

                //添加日志
                txtLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss ") + log + "\r\n");
                //save2FileTime(autoBackupLogPath, log);  //日志记录到文件
            }//try
            catch
            {
                //output("日志输出时发生意外：" + objException.Message);
                ; //不处理。因为处理可能会导致死循环。若save2FileTime()出错，则save2FileTime()->output()->save2FileTime()
            }
        }
            //日志输出函数,label
            private void outputLabel(string log)
            {
                try
                {
                    //添加日志
                    this.tssLabel2.Text = log ;
                    //save2FileTime(autoBackupLogPath, log);  //日志记录到文件
                }//try
                catch
                {
                    ; //不处理。
                }
            }

            //显示数据表全部内容到dataGridView1；
            private void databind(string sqlstr,  DataGridView dataGridView1)
            {
                DataTable dt = new DataTable();
                dt = achelp.GetDataTableFromDB(sqlstr);
                dataGridView1.DataSource = dt;
            }

            //初始化
            private void initDo()
            {               
                //1 当前用户
                tssLabel1.Text = "当前用户：管理员";
                tssLabel2.Text = "| 一定成功，加油！";

                //2 隐藏多余tab页
                tabControl1.TabPages.Remove(tabPage2); //调试用
                tabControl1.TabPages.Remove(tabPage3);  //test
                tabControl1.TabPages.Remove(tabPage6);

                //3 显示用户列表
                string sql1 = "select * from Users"; //重新刷新
                databind(sql1, dataGridView1);
                //dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[0].HeaderCell.Value = "编号"; //自动递增项
                dataGridView1.Columns[1].Visible = false; //不显示“编号”，多余的设计字段
                dataGridView1.Columns[2].HeaderCell.Value = "编码";
                dataGridView1.Columns[3].HeaderCell.Value = "住院号";
                dataGridView1.Columns[4].HeaderCell.Value = "姓名";
                dataGridView1.Columns[5].HeaderCell.Value = "性别";
                dataGridView1.Columns[6].HeaderCell.Value = "年龄";
                dataGridView1.Columns[7].HeaderCell.Value = "职业";
                dataGridView1.Columns[8].HeaderCell.Value = "入院时间";
                dataGridView1.Columns[9].HeaderCell.Value = "联系方式";
                dataGridView1.Columns[10].HeaderCell.Value = "民族";

                //4 初始化treeview, sheet5
                ImageList myImageList = new ImageList();
                myImageList.Images.Add(Image.FromFile(@"images\4.gif"));  //磁盘
                myImageList.Images.Add(Image.FromFile(@"images\5.gif"));  //灯泡
                myImageList.Images.Add(Image.FromFile(@"images\3.gif"));

                // Assign the ImageList to the TreeView.
                treeViewS5.ImageList = myImageList;

                // Set the TreeView control's default image and selected image indexes.
                treeViewS5.ImageIndex = 0;
                treeViewS5.SelectedImageIndex = 1;

                //5 首页则只显示首页按键，禁用分页按键；分页显示分页按键，禁用首页按键
                tabPage1Index = tabControl1.SelectedIndex;
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

                //6 首页初始化 
               
                comboBox19.SelectedIndex = 2;  //设置查询条件默认为"姓名"
                this.tabControl1.SelectedIndex = 0; //跳到首页 
                this.tabControl2.SelectedIndex = 0; //跳到首页 

                
                
            }

            //根据“true/false”转换为汉字(hanzi)“是/否”
            public string bool2HanZi(bool stringBool)
            {
                string ret = "是";
                if (false == stringBool) { ret = "否"; }
                return ret;
            }
            //根据汉字(hanzi)“是/否”转换为“true/false”
            public bool hanZi2Bool(string stringBin)
            {
                bool ret = true; //
                if ("否" == stringBin) { ret = false; }
                return ret;
            }

            /// <summary>
            ///延时
            /// </summary>
            /// <param name="delayTime"></param>
            /// <returns></returns>
            public static bool Delay(int delayTime)
            {
                DateTime now = DateTime.Now;
                int s;
                do
                {
                    TimeSpan spand = DateTime.Now - now;
                    s = spand.Seconds;
                    Application.DoEvents();
                }
                while (s < delayTime);
                return true;
            }

        #endregion 公用方法

        
        
        
        #region sheet1
        private Maticsoft.Model.Users model = new Maticsoft.Model.Users();
        Maticsoft.DAL.Users UsersDo = new Maticsoft.DAL.Users();

        //添加记录1-基本信息；
        private void addSheet1()
        {
            if (textBox1Sheet1.Text == "") //姓名不能为空
            {
                MessageBox.Show("姓名不能为空","系统提示");
                return;
            }
            else
            {
                model.sBianHao = label83.Text;
                model.sBianMa = comboBox7Sheet1.Text;
                model.sZhuYuanHao = textBox8Sheet1.Text;
                model.sName = textBox1Sheet1.Text;
                model.sSex = comboBox2Sheet1.Text;
                model.iAge = textBox4Sheet1.Text;
                model.sZhiYe = textBox3Sheet1.Text;
                model.dRuYuanShiJian = dtp1time9Sheet1.Value;
                model.sPhone = textBox6Sheet1.Text;
                model.sMinZu = textBox5Sheet1.Text;

                bool ret = UsersDo.Add(model);

                string sql1 = "select * from Users";
                databind1(sql1);

                //清空
               

                //显示
                outputLabel("sheet1添加成功!");
            }
        }

        //删除记录1-基本信息；
        private void deleteSheet1()
        {
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
                    bool ret = UsersDo.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from Users";
                databind1(sql1);

                //显示
                outputLabel("sheet1删除成功!");
            }
        }       

        //基本信息-加载；
        private void readSheet1(int oid)
        {
                       
            model = UsersDo.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体
            label83.Text = model.sBianHao;
            comboBox7Sheet1.Text = model.sBianMa;
            textBox8Sheet1.Text = model.sZhuYuanHao;
            textBox1Sheet1.Text = model.sName;
            comboBox2Sheet1.Text = model.sSex;
            textBox4Sheet1.Text = model.iAge;
            textBox3Sheet1.Text = model.sZhiYe;
            dtp1time9Sheet1.Value = Convert.ToDateTime(model.dRuYuanShiJian);
            textBox6Sheet1.Text = model.sPhone;
            textBox5Sheet1.Text = model.sMinZu;

            //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            buttonCheck.PerformClick(); //点击查询，设置查询条件后，点击加载，此时应以查询条件过滤

            //显示
            outputLabel("sheet1加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet1()
        {
            bool result = false; //返回值
            try
            {
                if (textBox1Sheet1.Text == "") //住院号不能为空
                {
                    MessageBox.Show("住院号不能为空","系统提示");
                    return false;
                }
                
                model.sBianHao = label83.Text;
                model.sBianMa = comboBox7Sheet1.Text;
                model.sZhuYuanHao = textBox8Sheet1.Text;
                model.sName = textBox1Sheet1.Text;
                model.sSex = comboBox2Sheet1.Text;
                model.iAge = textBox4Sheet1.Text;
                model.sZhiYe = textBox3Sheet1.Text;
                model.dRuYuanShiJian = dtp1time9Sheet1.Value;
                model.sPhone = textBox6Sheet1.Text;
                model.sMinZu = textBox5Sheet1.Text;
                model.ID = gOid;

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd)  //全局新增或单条新增，
                {
                    ret = UsersDo.Add(model); 
                }
                else  //更新
                {
                    ret = UsersDo.Update(model); 
                }

                gFlagAdd2 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel("sheet1更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("sheet1更新失败");
                    result = false;
                }

               
            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
                return false;
            }

            string sql1 = "select * from Users"; //重新刷新
            databind(sql1, dataGridView1);

            return result;
        }

    #endregion sheet1


        #region sheet2
        private Maticsoft.Model.s2XinFuZhu modelS2XinFuZhu = new Maticsoft.Model.s2XinFuZhu();
        Maticsoft.DAL.s2XinFuZhu doS2XinFuZhu = new Maticsoft.DAL.s2XinFuZhu();

        //添加记录1-基本信息；
        private void addSheet2()
        {
            if (textBox12.Text == "") //住院号不能为空
            {
                output("住院号不能为空");
                return;
            }
    
            modelS2XinFuZhu.sBianMa = textBox77.Text;  //编码
            modelS2XinFuZhu.bXinFuZhu = true; //新辅助治疗
			if ("否" == comboBox2.Text) { modelS2XinFuZhu.bXinFuZhu = false;}

             modelS2XinFuZhu.sZhuYuanHao = textBox12.Text;  //住院号
             modelS2XinFuZhu.sFangAn = comboBox3.Text;  //方案
             modelS2XinFuZhu.sJiLiang = textBox14.Text;  //剂量
             modelS2XinFuZhu.sLiaoCheng = textBox11.Text;  //疗程
    
			modelS2XinFuZhu.bXinFuZhuFangLiao = true; //新辅助化疗
            if ("否" == comboBox1.Text) { modelS2XinFuZhu.bXinFuZhuFangLiao = false; }

            modelS2XinFuZhu.sLiaoXiaoPingJia = comboBox4.Text;  //疗效评价
            modelS2XinFuZhu.bShuQian2thBingJian = true;//术前二次病检
            if ("否" == comboBox5.Text) { modelS2XinFuZhu.bShuQian2thBingJian = false; }

            modelS2XinFuZhu.sResult = textBox13.Text;  //结果
            modelS2XinFuZhu.iUserID = gOid.ToString(); //用户id
            modelS2XinFuZhu.sFangLiaoFangAn = textBox78.Text; //新放疗方案
            modelS2XinFuZhu.sFangLiaoLiaoCheng = textBox79.Text; //新放疗疗程

               bool ret = doS2XinFuZhu.Add(modelS2XinFuZhu);

               string sql1 = "select * from s2XinFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView2);

                //清空


                //显示
                output("Sheet2添加成功!");
   
        }

        //删除记录1-基本信息；
        private void deleteSheet2()
        {
            if (dgView2.SelectedRows.Count < 1 || dgView2.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dgView2.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dgView2.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    bool ret = doS2XinFuZhu.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from s2XinFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView2);

                //显示
                output("Sheet2删除成功!");
            }
        }

        //基本信息-加载；
        private void readSheet2()
        {
            if (dgView2.SelectedRows.Count < 1 || dgView2.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提醒");
                return;
            }
                        
            object oid = dgView2.SelectedRows[0].Cells[0].Value;
            gOid2 = Convert.ToInt32(oid);  //更新全局oid

            modelS2XinFuZhu = doS2XinFuZhu.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体
            textBox77.Text = modelS2XinFuZhu.sBianMa;  //编码
            comboBox2.Text = "是";  //新辅助治疗
            if (false == modelS2XinFuZhu.bXinFuZhu) { comboBox2.Text = "否";}

            textBox12.Text = modelS2XinFuZhu.sZhuYuanHao;  //住院号
            comboBox3.Text = modelS2XinFuZhu.sFangAn;  //方案
            textBox14.Text = modelS2XinFuZhu.sJiLiang;  //剂量
            textBox11.Text = modelS2XinFuZhu.sLiaoCheng;  //疗程
            comboBox1.Text = "是"; //新辅助化疗
            if (false == modelS2XinFuZhu.bXinFuZhuFangLiao) { comboBox1.Text = "否"; }

            comboBox4.Text = modelS2XinFuZhu.sLiaoXiaoPingJia;  //疗效评价
            comboBox5.Text = "是";  //术前二次病检
            if (false == modelS2XinFuZhu.bShuQian2thBingJian) { comboBox5.Text = "否"; }

            textBox13.Text = modelS2XinFuZhu.sResult;  //结果
            gOid2 = modelS2XinFuZhu.ID;
            textBox78.Text = modelS2XinFuZhu.sFangLiaoFangAn ; //新放疗方案
            textBox79.Text = modelS2XinFuZhu.sFangLiaoLiaoCheng ; //新放疗疗程

            string sql1 = "select * from s2XinFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind(sql1, dgView2);

            gFlagAdd2 = 0; //设置局部更新标志位


            //显示
            output("Sheet2加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet2()
        {
            bool result = false; //返回值
            try
            {
                if (textBox12.Text == "") //住院号不能为空
                {
                    output("住院号不能为空");
                    return false;
                }

                modelS2XinFuZhu.sBianMa = textBox77.Text;  //编码
                modelS2XinFuZhu.bXinFuZhu = true; //新辅助治疗
                if ("否" == comboBox2.Text) { modelS2XinFuZhu.bXinFuZhu = false; }

                modelS2XinFuZhu.sZhuYuanHao = textBox12.Text;  //住院号
                modelS2XinFuZhu.sFangAn = comboBox3.Text;  //方案
                modelS2XinFuZhu.sJiLiang = textBox14.Text;  //剂量
                modelS2XinFuZhu.sLiaoCheng = textBox11.Text;  //疗程

                modelS2XinFuZhu.bXinFuZhuFangLiao = true; //新辅助化疗
                if ("否" == comboBox1.Text) { modelS2XinFuZhu.bXinFuZhuFangLiao = false; }

                modelS2XinFuZhu.sLiaoXiaoPingJia = comboBox4.Text;  //疗效评价
                modelS2XinFuZhu.bShuQian2thBingJian = true;//术前二次病检
                if ("否" == comboBox5.Text) { modelS2XinFuZhu.bShuQian2thBingJian = false; }

                modelS2XinFuZhu.sResult = textBox13.Text;  //结果
                modelS2XinFuZhu.iUserID = gOid.ToString(); //用户id
                modelS2XinFuZhu.sFangLiaoFangAn = textBox78.Text; //新放疗方案
                modelS2XinFuZhu.ID = gOid2;
                modelS2XinFuZhu.sFangLiaoLiaoCheng = textBox79.Text; //新放疗疗程

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd2)  //全局新增或单条新增，
                {
                    ret = doS2XinFuZhu.Add(modelS2XinFuZhu);
                }
                else if (false == doS2XinFuZhu.Exists(gOid2)) //若无记录，则点击保存也视为增加
                    ret = doS2XinFuZhu.Add(modelS2XinFuZhu);
                else  //更新
                {
                    ret = doS2XinFuZhu.Update(modelS2XinFuZhu);
                }

                gFlagAdd2 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel ("Sheet2更新成功");
                    result = true;
                }
                else
                {
                    output("Sheet2更新失败");
                    result = false;
                }


            }
            catch (Exception ex)
            {
                output(ex.Message);
                return false;
            }

            string sql1 = "select * from s2XinFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView2);

            return result;
        }
        #endregion

        #region sheet3
        private Maticsoft.Model.s3ShuHouFuZhu ms3ShuHouFuZhu = new Maticsoft.Model.s3ShuHouFuZhu();
        Maticsoft.DAL.s3ShuHouFuZhu dos3ShuHouFuZhu = new Maticsoft.DAL.s3ShuHouFuZhu();


        //添加记录1-基本信息；
        private void addSheet3()
        {
            if (textBox12.Text == "") //住院号不能为空
            {
                output("住院号不能为空");
                return;
            }

            //ms3ShuHouFuZhu.ID                =  textBox.Text Text ;
            ms3ShuHouFuZhu.sBianMa                = textBox80.Text;
            ms3ShuHouFuZhu.bFuZhuHuaLiao                = true; //
             if ("否" == comboBox14.Text) { ms3ShuHouFuZhu.bFuZhuHuaLiao = false; }
            ms3ShuHouFuZhu.sZhouQi                = textBox33.Text;
            ms3ShuHouFuZhu.sFangAn                = textBox29.Text;
            ms3ShuHouFuZhu.sTiBiaoMianJi                = textBox32.Text;
            ms3ShuHouFuZhu.sShiJiJiLiang       = textBox27.Text;
            ms3ShuHouFuZhu.sWBC                = textBox31.Text;
            ms3ShuHouFuZhu.sHb                = textBox34.Text;
            ms3ShuHouFuZhu.sPLT                = textBox35.Text;
            ms3ShuHouFuZhu.sBMI                = textBox37.Text;
            ms3ShuHouFuZhu.sNRS2002                = textBox39.Text;
            ms3ShuHouFuZhu.sECOG                = textBox36.Text;
            ms3ShuHouFuZhu.bFuCha                = true; //
             if ("否" == comboBox13.Text) { ms3ShuHouFuZhu.bFuCha = false; }
            ms3ShuHouFuZhu.sCT                = textBox41.Text;
            ms3ShuHouFuZhu.sMRI                = textBox43.Text;
            ms3ShuHouFuZhu.sNeiJing                = textBox40.Text;
            ms3ShuHouFuZhu.sPET                = textBox42.Text;
            ms3ShuHouFuZhu.bFuFa                = true; //
             if ("否" == comboBox15.Text) { ms3ShuHouFuZhu.bFuFa = false; }
            ms3ShuHouFuZhu.sWeiZhi                = textBox47.Text;
            ms3ShuHouFuZhu.sChuliFangShi                = textBox44.Text;
            ms3ShuHouFuZhu.sjiLiang                = textBox48.Text;
            ms3ShuHouFuZhu.sLiaoCheng                = textBox50.Text;
            ms3ShuHouFuZhu.sLiaoXiaoPingFen                = "true"; //数据库设计失误，考虑兼容，故不改
             if ("否" == comboBox17.Text) { ms3ShuHouFuZhu.sLiaoXiaoPingFen = "false"; }
             ms3ShuHouFuZhu.iUserID = gOid.ToString();
            ms3ShuHouFuZhu.sZhuYuanHao                = textBox28.Text;
            ms3ShuHouFuZhu.bBaXiangYaoWu                = true; //
             if ("否" == comboBox16.Text) { ms3ShuHouFuZhu.bBaXiangYaoWu = false; }
            ms3ShuHouFuZhu.sYaoWuPinZhong                = textBox49.Text;
            ms3ShuHouFuZhu.sJianCeResult                 = textBox51.Text;
            bool ret = dos3ShuHouFuZhu.Add(ms3ShuHouFuZhu);

            string sql1 = "select * from s3ShuHouFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView3);

            //清空


            //显示
            output("Sheet3添加成功!");

        }

        //删除记录1-基本信息；
        private void deleteSheet3()
        {
            if (dgView3.SelectedRows.Count < 1 || dgView3.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dgView3.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dgView3.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    bool ret = dos3ShuHouFuZhu.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from s3ShuHouFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView3);

                //显示
                output("Sheet3删除成功!");
            }
        }

        //基本信息-加载；
        private void readSheet3()
        {
            if (dgView3.SelectedRows.Count < 1 || dgView3.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提醒");
                return;
            }

            object oid = dgView3.SelectedRows[0].Cells[0].Value;
            gOid3 = Convert.ToInt32(oid);  //更新全局oid

            ms3ShuHouFuZhu = dos3ShuHouFuZhu.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体
            //ms3ShuHouFuZhu.ID                textBox.Text Text 
            textBox80.Text = ms3ShuHouFuZhu.sBianMa;
            comboBox14.Text = "是"; //
            if (false == ms3ShuHouFuZhu.bFuZhuHuaLiao) { comboBox14.Text = "否"; }
            textBox33.Text = ms3ShuHouFuZhu.sZhouQi;
            textBox29.Text = ms3ShuHouFuZhu.sFangAn;
            textBox32.Text = ms3ShuHouFuZhu.sTiBiaoMianJi;
            textBox27.Text = ms3ShuHouFuZhu.sShiJiJiLiang;
            textBox31.Text = ms3ShuHouFuZhu.sWBC;
            textBox34.Text = ms3ShuHouFuZhu.sHb;
            textBox35.Text = ms3ShuHouFuZhu.sPLT;
            textBox37.Text = ms3ShuHouFuZhu.sBMI;
            textBox39.Text = ms3ShuHouFuZhu.sNRS2002;
            textBox36.Text = ms3ShuHouFuZhu.sECOG;
            comboBox13.Text = "是"; //
            if (false == ms3ShuHouFuZhu.bFuCha) { comboBox13.Text = "否"; }
            textBox41.Text = ms3ShuHouFuZhu.sCT;
            textBox43.Text = ms3ShuHouFuZhu.sMRI;
            textBox40.Text = ms3ShuHouFuZhu.sNeiJing;
            textBox42.Text = ms3ShuHouFuZhu.sPET;
            comboBox15.Text = "是"; //
            if (false == ms3ShuHouFuZhu.bFuFa) { comboBox15.Text = "否"; }
            textBox47.Text = ms3ShuHouFuZhu.sWeiZhi;
            textBox44.Text = ms3ShuHouFuZhu.sChuliFangShi;
            textBox48.Text = ms3ShuHouFuZhu.sjiLiang;
            textBox50.Text = ms3ShuHouFuZhu.sLiaoCheng;
            comboBox17.Text = "是"; //
            if ("false" == ms3ShuHouFuZhu.sLiaoXiaoPingFen) { comboBox17.Text = "否"; }

            label133.Text = ms3ShuHouFuZhu.iUserID;
            textBox28.Text = ms3ShuHouFuZhu.sZhuYuanHao;
            comboBox16.Text = "是"; //
            if (false == ms3ShuHouFuZhu.bBaXiangYaoWu) { comboBox16.Text = "否"; }

            textBox49.Text = ms3ShuHouFuZhu.sYaoWuPinZhong;
            textBox51.Text = ms3ShuHouFuZhu.sJianCeResult;

            string sql1 = "select * from s3ShuHouFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind(sql1, dgView3);

            gFlagAdd3 = 0; //设置局部更新标志位


            //显示
            output("Sheet3加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet3()
        {
            bool result = false; //返回值
            try
            {
                if (textBox28.Text == "") //住院号不能为空
                {
                    MessageBox.Show("住院号不能为空");
                    return false;
                }

                ms3ShuHouFuZhu.ID                =  gOid3 ;
                ms3ShuHouFuZhu.sBianMa = textBox80.Text;
                ms3ShuHouFuZhu.bFuZhuHuaLiao = true; //
                if ("否" == comboBox14.Text) { ms3ShuHouFuZhu.bFuZhuHuaLiao = false; }
                ms3ShuHouFuZhu.sZhouQi = textBox33.Text;
                ms3ShuHouFuZhu.sFangAn = textBox29.Text;
                ms3ShuHouFuZhu.sTiBiaoMianJi = textBox32.Text;
                ms3ShuHouFuZhu.sShiJiJiLiang = textBox27.Text;
                ms3ShuHouFuZhu.sWBC = textBox31.Text;
                ms3ShuHouFuZhu.sHb = textBox34.Text;
                ms3ShuHouFuZhu.sPLT = textBox35.Text;
                ms3ShuHouFuZhu.sBMI = textBox37.Text;
                ms3ShuHouFuZhu.sNRS2002 = textBox39.Text;
                ms3ShuHouFuZhu.sECOG = textBox36.Text;
                ms3ShuHouFuZhu.bFuCha = true; //
                if ("否" == comboBox13.Text) { ms3ShuHouFuZhu.bFuCha = false; }
                ms3ShuHouFuZhu.sCT = textBox41.Text;
                ms3ShuHouFuZhu.sMRI = textBox43.Text;
                ms3ShuHouFuZhu.sNeiJing = textBox40.Text;
                ms3ShuHouFuZhu.sPET = textBox42.Text;
                ms3ShuHouFuZhu.bFuFa = true; //
                if ("否" == comboBox15.Text) { ms3ShuHouFuZhu.bFuFa = false; }
                ms3ShuHouFuZhu.sWeiZhi = textBox47.Text;
                ms3ShuHouFuZhu.sChuliFangShi = textBox44.Text;
                ms3ShuHouFuZhu.sjiLiang = textBox48.Text;
                ms3ShuHouFuZhu.sLiaoCheng = textBox50.Text;
                ms3ShuHouFuZhu.sLiaoXiaoPingFen = "true"; //数据库设计失误，考虑兼容，故不改
                if ("否" == comboBox17.Text) { ms3ShuHouFuZhu.sLiaoXiaoPingFen = "false"; }
                ms3ShuHouFuZhu.iUserID = gOid.ToString();
                ms3ShuHouFuZhu.sZhuYuanHao = textBox28.Text;
                ms3ShuHouFuZhu.bBaXiangYaoWu = true; //
                if ("否" == comboBox16.Text) { ms3ShuHouFuZhu.bBaXiangYaoWu = false; }
                ms3ShuHouFuZhu.sYaoWuPinZhong = textBox49.Text;
                ms3ShuHouFuZhu.sJianCeResult = textBox51.Text;

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd3)  //全局新增或单条新增，
                {
                    ret = dos3ShuHouFuZhu.Add(ms3ShuHouFuZhu);
                }
                else if (false == dos3ShuHouFuZhu.Exists(gOid3)) //若无记录，则点击保存也视为增加
                    ret = dos3ShuHouFuZhu.Add(ms3ShuHouFuZhu);
                else  //更新
                {
                    ret = dos3ShuHouFuZhu.Update(ms3ShuHouFuZhu);
                }

                gFlagAdd3 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel("Sheet3更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("Sheet3更新失败");
                    result = false;
                }


            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
                return false;
            }

            string sql1 = "select * from s3ShuHouFuZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView3);

            return result;
        }
        #endregion

        #region sheet4
        private Maticsoft.Model.s4SuiZhen ms4SuiZhen = new Maticsoft.Model.s4SuiZhen();
        Maticsoft.DAL.s4SuiZhen dos4SuiZhen = new Maticsoft.DAL.s4SuiZhen();


        //添加记录1-基本信息；
        private void addSheet4()
        {
            if (textBox12.Text == "") //住院号不能为空
            {
                output("住院号不能为空");
                return;
            }

            //ms4SuiZhen.ID                =  textBox.Text Text ;
            ms4SuiZhen.iUserID = gOid.ToString();
            ms4SuiZhen.sBianHao = textBox30.Text;
            ms4SuiZhen.sSuiZhenCiShu = textBox38.Text;
            ms4SuiZhen.dSuiZhenTime = dateTimePicker2.Value;
            ms4SuiZhen.sZhuYuanHao = textBox45.Text;
            ms4SuiZhen.sCT = textBox59.Text;
            ms4SuiZhen.sMRI = textBox57.Text;
            ms4SuiZhen.sNeiJing = textBox46.Text;
            ms4SuiZhen.sPET = textBox52.Text;
            ms4SuiZhen.bFuFa = hanZi2Bool( comboBox21.Text );//根据汉字“是/否”转换为“true/false”

            bool ret = dos4SuiZhen.Add(ms4SuiZhen);

            string sql1 = "select * from s4SuiZhen where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView4);

            //清空


            //显示
            output("Sheet4添加成功!");

        }

        //删除记录1-基本信息；
        private void deleteSheet4()
        {
            if (dgView4.SelectedRows.Count < 1 || dgView4.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dgView4.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dgView4.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    bool ret = dos4SuiZhen.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from s4SuiZhen where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView4);

                //显示
                output("Sheet4删除成功!");
            }
        }

        //基本信息-加载；
        private void readSheet4()
        {
            if (dgView4.SelectedRows.Count < 1 || dgView4.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提醒");
                return;
            }

            object oid = dgView4.SelectedRows[0].Cells[0].Value;
            gOid4 = Convert.ToInt32(oid);  //更新全局oid

            ms4SuiZhen = dos4SuiZhen.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体
            textBox30.Text = ms4SuiZhen.sBianHao;
            textBox38.Text = ms4SuiZhen.sSuiZhenCiShu;
            dateTimePicker2.Value = Convert.ToDateTime(ms4SuiZhen.dSuiZhenTime);
            textBox45.Text = ms4SuiZhen.sZhuYuanHao;
            textBox59.Text = ms4SuiZhen.sCT;
            textBox57.Text = ms4SuiZhen.sMRI;
            textBox46.Text = ms4SuiZhen.sNeiJing;
            textBox52.Text = ms4SuiZhen.sPET;
            comboBox21.Text = bool2HanZi(ms4SuiZhen.bFuFa); //根据“true/false”转换为汉字“是/否”

            string sql1 = "select * from s4SuiZhen where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind(sql1, dgView4);

            gFlagAdd4 = 0; //设置局部更新标志位


            //显示
            output("Sheet4加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet4()
        {
            bool result = false; //返回值
            try
            {
                if (textBox45.Text == "") //住院号不能为空
                {
                    MessageBox.Show("住院号不能为空");
                    return false;
                }

                ms4SuiZhen.ID = gOid4;
                ms4SuiZhen.iUserID = gOid.ToString();
                ms4SuiZhen.sBianHao = textBox30.Text;
                ms4SuiZhen.sSuiZhenCiShu = textBox38.Text;
                ms4SuiZhen.dSuiZhenTime = dateTimePicker2.Value;
                ms4SuiZhen.sZhuYuanHao = textBox45.Text;
                ms4SuiZhen.sCT = textBox59.Text;
                ms4SuiZhen.sMRI = textBox57.Text;
                ms4SuiZhen.sNeiJing = textBox46.Text;
                ms4SuiZhen.sPET = textBox52.Text;
                ms4SuiZhen.bFuFa = true; //
                if ("否" == comboBox21.Text) { ms4SuiZhen.bFuFa = false; }

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd4)  //全局新增或单条新增，
                {
                    ret = dos4SuiZhen.Add(ms4SuiZhen);
                }
                else if (false == dos4SuiZhen.Exists(gOid4)) //若无记录，则点击保存也视为增加
                    ret = dos4SuiZhen.Add(ms4SuiZhen);
                else  //更新
                {
                    ret = dos4SuiZhen.Update(ms4SuiZhen);
                }

                gFlagAdd4 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel("Sheet4更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("Sheet4更新失败");
                    result = false;
                }


            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
                return false;
            }

            string sql1 = "select * from s4SuiZhen where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView4);

            return result;
        }

        #endregion

        #region sheet5
        private Maticsoft.Model.s5ShuJuCunZhu ms5ShuJuCunZhu = new Maticsoft.Model.s5ShuJuCunZhu();
        Maticsoft.DAL.s5ShuJuCunZhu dos5ShuJuCunZhu = new Maticsoft.DAL.s5ShuJuCunZhu();


        //添加记录1-基本信息；
        private void addSheet5()
        {
            if (textBox81.Text == "") //档案号
            {
                output("档案号不能为空");
                return;
            }

            //ms5ShuJuCunZhu.ID                =  textBox.Text Text ;
            ms5ShuJuCunZhu.iUserID = gOid.ToString();
            ms5ShuJuCunZhu.sBianHao = textBox81.Text;
            ms5ShuJuCunZhu.sCT = "default";
            ms5ShuJuCunZhu.sCiGongZheng = "default";
            ms5ShuJuCunZhu.sBingLi = "default";

            bool ret = dos5ShuJuCunZhu.Add(ms5ShuJuCunZhu);

            string sql1 = "select * from s5ShuJuCunZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView5);

            //清空


            //显示
            output("Sheet5添加成功!");

        }

        //删除记录1-基本信息；
        private void deleteSheet5()
        {
            if (dgView5.SelectedRows.Count < 1 || dgView5.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dgView5.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dgView5.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    bool ret = dos5ShuJuCunZhu.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from s5ShuJuCunZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView5);

                //显示
                output("Sheet5删除成功!");
            }
        }

        //基本信息-加载；
        private void readSheet5()
        {
            if (dgView5.SelectedRows.Count < 1 || dgView5.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提醒");
                return;
            }

            object oid = dgView5.SelectedRows[0].Cells[0].Value;
            gOid5 = Convert.ToInt32(oid);  //更新全局oid

            ms5ShuJuCunZhu = dos5ShuJuCunZhu.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体
            textBox81.Text = ms5ShuJuCunZhu.sBianHao;

            //若档案号主目录不存在，则创建。
            string fileDir = ftpRootPath + textBox81.Text;
            if (false == Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }

            string sql1 = "select * from s5ShuJuCunZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind(sql1, dgView5);

            gFlagAdd5 = 0; //设置局部更新标志位


            //显示
            output("Sheet5加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet5()
        {
            bool result = false; //返回值
            try
            {
                if (textBox81.Text == "") //档案号不能为空
                {
                    MessageBox.Show("档案号不能为空");
                    return false;
                }
                
                //更新前，重命名
                string fileDir = ftpRootPath + textBox81.Text.Trim(); //获取新路径

                string fileDirOld = ftpRootPath + ms5ShuJuCunZhu.sBianHao; //旧目录
                if (true == (Directory.Exists(fileDirOld)) && fileDirOld != ftpRootPath && fileDirOld != fileDir) //同名则不改名
                {
                    Directory.Move(fileDirOld, fileDir);
                }

                //更新
                ms5ShuJuCunZhu.ID = gOid5;
                ms5ShuJuCunZhu.iUserID = gOid.ToString();
                ms5ShuJuCunZhu.sBianHao = textBox81.Text;
                ms5ShuJuCunZhu.sCT = "default";
                ms5ShuJuCunZhu.sCiGongZheng = "default";
                ms5ShuJuCunZhu.sBingLi = "default";

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd5)  //全局新增或单条新增，
                {
                    ret = dos5ShuJuCunZhu.Add(ms5ShuJuCunZhu);
                }
                else if (false == dos5ShuJuCunZhu.Exists(gOid5)) //若无记录，则点击保存也视为增加
                    ret = dos5ShuJuCunZhu.Add(ms5ShuJuCunZhu);
                else  //更新
                {
                    ret = dos5ShuJuCunZhu.Update(ms5ShuJuCunZhu);
                }

                gFlagAdd5 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel("Sheet5更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("Sheet5更新失败");
                    result = false;
                }


            }
            catch (Exception ex)
            {
                outputLabel("Sheet5更新失败，" + ex.Message);
                return false;
            }

            string sql1 = "select * from s5ShuJuCunZhu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView5);

            return result;
        }
        #endregion

        #region sheet6
        private Maticsoft.Model.s6QiBingQingKuang ms6QiBingQingKuang = new Maticsoft.Model.s6QiBingQingKuang();
        Maticsoft.DAL.s6QiBingQingKuang dos6QiBingQingKuang = new Maticsoft.DAL.s6QiBingQingKuang();


        //添加记录1-基本信息；
        private void addSheet6()
        {
            if (textBox82.Text == "") //编号
            {
                output("编号不能为空");
                return;
            }

            //ms6QiBingQingKuang.ID                =  textBox.Text Text ;
            ms6QiBingQingKuang.iUserID = gOid.ToString();
            ms6QiBingQingKuang.sBianMa = textBox82.Text;
            ms6QiBingQingKuang.sZhongLiuBuWei = comboBox29.Text;
            ms6QiBingQingKuang.sShouFaZhengZhuang = comboBox28.Text;
            ms6QiBingQingKuang.dTime = dateTimePicker6.Value;
            ms6QiBingQingKuang.dChuBuZhengDuanTime = dateTimePicker5.Value;
            ms6QiBingQingKuang.sResult = "default";
            ms6QiBingQingKuang.sZhenDuanYiJiu = comboBox27.Text;

            bool ret = dos6QiBingQingKuang.Add(ms6QiBingQingKuang);

            string sql1 = "select * from s6QiBingQingKuang where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView6);

            //清空


            //显示
            outputLabel("Sheet6添加成功!");

        }

        //删除记录1-基本信息；
        private void deleteSheet6()
        {
            if (dgView6.SelectedRows.Count < 1 || dgView6.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dgView6.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dgView6.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    bool ret = dos6QiBingQingKuang.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from s6QiBingQingKuang where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView6);

                //显示
                outputLabel("Sheet6删除成功!");
            }
        }

        //基本信息-加载；
        private void readSheet6()
        {
            if (dgView6.SelectedRows.Count < 1 || dgView6.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提醒");
                return;
            }

            object oid = dgView6.SelectedRows[0].Cells[0].Value;
            gOid6 = Convert.ToInt32(oid);  //更新全局oid

            ms6QiBingQingKuang = dos6QiBingQingKuang.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体
            textBox81.Text = ms6QiBingQingKuang.sBianMa;

            //ms6QiBingQingKuang.iUserID = gOid.ToString();
            textBox82.Text = ms6QiBingQingKuang.sBianMa;
            comboBox29.Text = ms6QiBingQingKuang.sZhongLiuBuWei;
            comboBox28.Text = ms6QiBingQingKuang.sShouFaZhengZhuang;
            dateTimePicker6.Value = Convert.ToDateTime(ms6QiBingQingKuang.dTime);
            dateTimePicker5.Value = Convert.ToDateTime(ms6QiBingQingKuang.dChuBuZhengDuanTime);
            //ms6QiBingQingKuang.sResult = "default";  //设计数据库时，多加了个字段
            comboBox27.Text = ms6QiBingQingKuang.sZhenDuanYiJiu;

            string sql1 = "select * from s6QiBingQingKuang where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind(sql1, dgView6);

            gFlagAdd6 = 0; //设置局部更新标志位


            //显示
            output("Sheet6加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet6()
        {
            bool result = false; //返回值
            try
            {
                if (textBox82.Text == "") //编号不能为空
                {
                    MessageBox.Show("编号不能为空");
                    return false;
                }

                //更新
                ms6QiBingQingKuang.ID = gOid6;
                ms6QiBingQingKuang.iUserID = gOid.ToString();
                ms6QiBingQingKuang.sBianMa = textBox82.Text;
                ms6QiBingQingKuang.sZhongLiuBuWei = comboBox29.Text;
                ms6QiBingQingKuang.sShouFaZhengZhuang = comboBox28.Text;
                ms6QiBingQingKuang.dTime = dateTimePicker6.Value;
                ms6QiBingQingKuang.dChuBuZhengDuanTime = dateTimePicker5.Value;
                ms6QiBingQingKuang.sResult = "default";
                ms6QiBingQingKuang.sZhenDuanYiJiu = comboBox27.Text;

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd6)  //全局新增或单条新增，
                {
                    ret = dos6QiBingQingKuang.Add(ms6QiBingQingKuang);
                }
                else if (false == dos6QiBingQingKuang.Exists(gOid6)) //若无记录，则点击保存也视为增加
                    ret = dos6QiBingQingKuang.Add(ms6QiBingQingKuang);
                else  //更新
                {
                    ret = dos6QiBingQingKuang.Update(ms6QiBingQingKuang);
                }

                gFlagAdd6 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel("Sheet6更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("Sheet6更新失败");
                    result = false;
                }


            }
            catch (Exception ex)
            {
                outputLabel("Sheet6更新失败，" + ex.Message);
                return false;
            }

            string sql1 = "select * from s6QiBingQingKuang where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView6);

            return result;
        }
        #endregion

        #region sheet7
        private Maticsoft.Model.s7ShuQianPingGu ms7ShuQianPingGu = new Maticsoft.Model.s7ShuQianPingGu();
        Maticsoft.DAL.s7ShuQianPingGu dos7ShuQianPingGu = new Maticsoft.DAL.s7ShuQianPingGu();


        //添加记录1-基本信息；
        private void addSheet7(ref FormSheet7 f7)
        {
            if (f7.Text1 == "") //编号
            {
                MessageBox.Show("编号不能为空","系统提示");
                return;
            }

            //ms7ShuQianPingGu.ID                =  textBox.Text Text ;
            ms7ShuQianPingGu.iUserID = gOid.ToString();
            ms7ShuQianPingGu.ID = f7.lOid;
            ms7ShuQianPingGu.sBianHao = f7.Text36;
            ms7ShuQianPingGu.bWoYuanBingJian = hanZi2Bool(f7.Text37);
            ms7ShuQianPingGu.sResult = f7.Text38;
            ms7ShuQianPingGu.sBingLiHao = f7.Text35;
            ms7ShuQianPingGu.bWoYuanCT = hanZi2Bool(f7.Text1);
            ms7ShuQianPingGu.sZhongLiuDaXiao = f7.Text41;
            ms7ShuQianPingGu.sJuBuQinFang = f7.Text42;
            ms7ShuQianPingGu.bLinBaJieZhuanYi = hanZi2Bool(f7.Text43);
            ms7ShuQianPingGu.bZhuanYi = hanZi2Bool(f7.Text40);
            ms7ShuQianPingGu.sBuWei = f7.Text34;
            ms7ShuQianPingGu.bWoYuanMRI = hanZi2Bool(f7.Text39);
            ms7ShuQianPingGu.sMRIZhongliuDaXiao = f7.Text45;
            ms7ShuQianPingGu.sMRIJuBuQinFang = f7.Text46;
            ms7ShuQianPingGu.bMRILinBaJieZhuanYi = hanZi2Bool(f7.Text47);
            ms7ShuQianPingGu.bMRIZhuanYi = hanZi2Bool(f7.Text44);
            ms7ShuQianPingGu.sMRIBuWei = f7.Text48;
            ms7ShuQianPingGu.bPET = hanZi2Bool(f7.Text54);
            ms7ShuQianPingGu.sPETZhongLiuDaXiao = f7.Text50;
            ms7ShuQianPingGu.sPETJuBuQinFang = f7.Text51;
            ms7ShuQianPingGu.sDaiXieQiangDu = f7.Text55;
            ms7ShuQianPingGu.sLinBaZhuanYi = f7.Text52;
            ms7ShuQianPingGu.bPETZhuanYi = f7.Text49;
            ms7ShuQianPingGu.sPETBuWei = f7.Text53;
            ms7ShuQianPingGu.sZhuanYiBuWeiDaiXieQD = f7.Text56;
            ms7ShuQianPingGu.sCT = f7.Text57;
            ms7ShuQianPingGu.sCN = f7.Text58;
            ms7ShuQianPingGu.sCM = f7.Text64;
            ms7ShuQianPingGu.sWBC = f7.Text59;
            ms7ShuQianPingGu.sHb = f7.Text65;
            ms7ShuQianPingGu.sALB = f7.Text60;
            ms7ShuQianPingGu.sCEA = f7.Text61;
            ms7ShuQianPingGu.sCA125 = f7.Text62;
            ms7ShuQianPingGu.sCA199 = f7.Text66;
            ms7ShuQianPingGu.sCA724 = f7.Text63;
            ms7ShuQianPingGu.sAFP = f7.Text20;
            ms7ShuQianPingGu.bGengZhu = hanZi2Bool(f7.Text32);
            ms7ShuQianPingGu.bChuXie = hanZi2Bool(f7.Text67);
            ms7ShuQianPingGu.bChuanKong = hanZi2Bool(f7.Text68);
            ms7ShuQianPingGu.sBMI = f7.Text11;
            ms7ShuQianPingGu.sNRS2002 = f7.Text29;
            ms7ShuQianPingGu.sTengTongPingFen = f7.Text30;
            ms7ShuQianPingGu.sECOG = f7.Text33;
            ms7ShuQianPingGu.sXinGongNeng = f7.Text19;
            ms7ShuQianPingGu.sFeiGongNeng = f7.Text12;
            ms7ShuQianPingGu.sShenGongNeng = f7.Text18;
            ms7ShuQianPingGu.sGanGongNeng = f7.Text110;
            ms7ShuQianPingGu.sNingXieGongneng = f7.Text109;
            ms7ShuQianPingGu.bJiZhenShouShu = hanZi2Bool(f7.Text17);
            ms7ShuQianPingGu.sShouShuRiqi = f7.Text114;
            ms7ShuQianPingGu.sQiangjingKaiFu = f7.Text69;
            ms7ShuQianPingGu.sShuShi = f7.Text31;
            ms7ShuQianPingGu.sShouShuTime = f7.Text28;
            ms7ShuQianPingGu.sKaiFuWenHeTime = f7.Text27;
            ms7ShuQianPingGu.sZhongLiuJuTiWeiZhi = f7.Text16;
            ms7ShuQianPingGu.bLianHeQiZhuangQieChu = hanZi2Bool(f7.Text70);
            ms7ShuQianPingGu.sChuXieLiang = f7.Text26;
            ms7ShuQianPingGu.sFuQiangWuRuan = f7.Text71;
            ms7ShuQianPingGu.sFuShenShang = f7.Text21;
            ms7ShuQianPingGu.bYingYangGuan = hanZi2Bool(f7.Text13);
            ms7ShuQianPingGu.bZaoLou = hanZi2Bool(f7.Text72);
            ms7ShuQianPingGu.bShuZhongBingLi = hanZi2Bool(f7.Text73);
            ms7ShuQianPingGu.sResult2 = f7.Text77;
            ms7ShuQianPingGu.sQieChuQingkong = f7.Text74;
            ms7ShuQianPingGu.sLinBaJieQingShao = f7.Text75;
            ms7ShuQianPingGu.sTeShuShuoMing = f7.Text78;
            ms7ShuQianPingGu.bERAS = hanZi2Bool(f7.Text76);
            ms7ShuQianPingGu.bICUJianHu = hanZi2Bool(f7.Text77);
            ms7ShuQianPingGu.sJianHuTime = f7.Text37;
            ms7ShuQianPingGu.sJinShuiShiJian = f7.Text14;
            ms7ShuQianPingGu.sTongQiTime = f7.Text24;
            ms7ShuQianPingGu.sPaiBianTime = f7.Text80;
            ms7ShuQianPingGu.sFuTongHuanJieTime = f7.Text6;
            ms7ShuQianPingGu.sNiaoGuanBaChuTime = f7.Text23;
            ms7ShuQianPingGu.sYinLiuGuanBaChuTime = f7.Text15;
            ms7ShuQianPingGu.sXiaChuangTime = f7.Text9;
            ms7ShuQianPingGu.sJinShi = f7.Text10;
            ms7ShuQianPingGu.bChangNeiYingYang = hanZi2Bool(f7.Text113);
            ms7ShuQianPingGu.sChangNeiYingYangZhiChiTime = f7.Text1;
            ms7ShuQianPingGu.sTPNtime = f7.Text2;
            ms7ShuQianPingGu.sShuHouChuXue = f7.Text81;
            ms7ShuQianPingGu.sFuQiangGanRuan = f7.Text82;
            ms7ShuQianPingGu.sQieKouGanRuan = f7.Text84;
            ms7ShuQianPingGu.sWenHeKouLou = f7.Text85;
            ms7ShuQianPingGu.sChangGenZhu = f7.Text86;
            ms7ShuQianPingGu.sWeiTan = f7.Text5;
            ms7ShuQianPingGu.sFeiBuFanRuan = f7.Text83;
            ms7ShuQianPingGu.sDiDanBaiXueZheng = f7.Text8;
            ms7ShuQianPingGu.sWEiGuanTuoChu = f7.Text98;
            ms7ShuQianPingGu.sYingYangGuanTuoChu = f7.Text90;
            ms7ShuQianPingGu.sZaoKouBingFaZheng = f7.Text87;
            ms7ShuQianPingGu.b2thShouShu = hanZi2Bool(f7.Text4);
            ms7ShuQianPingGu.sShouShuTime = f7.Text88;
            ms7ShuQianPingGu.sShouShuFangShi = f7.Text7;
            ms7ShuQianPingGu.sJieJueWenTi = f7.Text3;
            ms7ShuQianPingGu.sShuHouBingLiZhengDuan = f7.Text102;
            ms7ShuQianPingGu.sFenHuaChengDu = f7.Text101;
            ms7ShuQianPingGu.sJinRunShenDu = f7.Text91;
            ms7ShuQianPingGu.sMaiGuanAiShuan = f7.Text100;
            ms7ShuQianPingGu.sShenJingQinFang = f7.Text99;
            ms7ShuQianPingGu.sAiJieJie = f7.Text98;
            ms7ShuQianPingGu.sZongLinBaJieShu = f7.Text104;
            ms7ShuQianPingGu.sZhuanyiLinBaJieShu = f7.Text93;
            ms7ShuQianPingGu.sMSI = f7.Text92;
            ms7ShuQianPingGu.sHER_2 = f7.Text106;
            ms7ShuQianPingGu.sP53 = f7.Text103;
            ms7ShuQianPingGu.sKi_67 = f7.Text105;
            ms7ShuQianPingGu.sK_RAS = f7.Text95;
            ms7ShuQianPingGu.sN_RAS = f7.Text94;
            ms7ShuQianPingGu.sShouHouBingLiFenQi = f7.Text107;
            ms7ShuQianPingGu.sMSIQueZheng = f7.Text111;
            ms7ShuQianPingGu.sJiYinJianCe = f7.Text112;
            ms7ShuQianPingGu.sChuYuanTime = f7.Text97;
            ms7ShuQianPingGu.sChuYuanQingKong = f7.Text96;
            ms7ShuQianPingGu.sYiLiaoFeiYong = f7.Text108;

            bool ret = dos7ShuQianPingGu.Add(ms7ShuQianPingGu);

            string sql1 = "select * from s7ShuQianPingGu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView7);

            //清空


            //显示
            outputLabel("Sheet7添加成功!");

        }

        //删除记录1-基本信息；
        private void deleteSheet7()
        {
            if (dgView7.SelectedRows.Count < 1 || dgView7.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提示");
            }
            else
            {
                object oid = dgView7.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dgView7.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "系统提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                else
                {
                    bool ret = dos7ShuQianPingGu.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from s7ShuQianPingGu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
                databind(sql1, dgView7);

                //显示
                outputLabel("Sheet7删除成功!");
            }
        }

        //基本信息-加载；
        //加载完后，show，f3.ShowDialog(); 
        private bool readSheet7(ref FormSheet7 f7)
        {
            if (dgView7.SelectedRows.Count < 1 || dgView7.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("没有选中行。", "系统提醒");
                return false;
            }

            object oid = dgView7.SelectedRows[0].Cells[0].Value;
            gOid7 = Convert.ToInt32(oid);  //更新全局oid

            ms7ShuQianPingGu = dos7ShuQianPingGu.GetModel(Convert.ToInt32(oid)); //读取数据库数据到model，中转

            //model赋值给窗体, TextX并非全为文本类型，命名是为了方便统一处理
            //ms7ShuQianPingGu.iUserID = gOid.ToString();            
            f7.lOid = ms7ShuQianPingGu.ID;
            f7.iUserID = ms7ShuQianPingGu.iUserID;
            f7.Text36 = ms7ShuQianPingGu.sBianHao;
            f7.Text37 = bool2HanZi(ms7ShuQianPingGu.bWoYuanBingJian);
            f7.Text38 = ms7ShuQianPingGu.sResult;
            f7.Text35 = ms7ShuQianPingGu.sBingLiHao;
            f7.Text1 = bool2HanZi(ms7ShuQianPingGu.bWoYuanCT);
            f7.Text41 = ms7ShuQianPingGu.sZhongLiuDaXiao;
            f7.Text42 = ms7ShuQianPingGu.sJuBuQinFang;
            f7.Text43 = bool2HanZi(ms7ShuQianPingGu.bLinBaJieZhuanYi);
            f7.Text40 = bool2HanZi(ms7ShuQianPingGu.bZhuanYi);
            f7.Text34 = ms7ShuQianPingGu.sBuWei;
            f7.Text39 = bool2HanZi(ms7ShuQianPingGu.bWoYuanMRI);
            f7.Text45 = ms7ShuQianPingGu.sMRIZhongliuDaXiao;
            f7.Text46 = ms7ShuQianPingGu.sMRIJuBuQinFang;
            f7.Text47 = bool2HanZi(ms7ShuQianPingGu.bMRILinBaJieZhuanYi);
            f7.Text44 = bool2HanZi(ms7ShuQianPingGu.bMRIZhuanYi);
            f7.Text48 = ms7ShuQianPingGu.sMRIBuWei;
            f7.Text54 = bool2HanZi(ms7ShuQianPingGu.bPET);
            f7.Text50 = ms7ShuQianPingGu.sPETZhongLiuDaXiao;
            f7.Text51 = ms7ShuQianPingGu.sPETJuBuQinFang;
            f7.Text55 = ms7ShuQianPingGu.sDaiXieQiangDu;
            f7.Text52 = ms7ShuQianPingGu.sLinBaZhuanYi;
            f7.Text49 = ms7ShuQianPingGu.bPETZhuanYi;
            f7.Text53 = ms7ShuQianPingGu.sPETBuWei;
            f7.Text56 = ms7ShuQianPingGu.sZhuanYiBuWeiDaiXieQD;
            f7.Text57 = ms7ShuQianPingGu.sCT;
            f7.Text58 = ms7ShuQianPingGu.sCN;
            f7.Text64 = ms7ShuQianPingGu.sCM;
            f7.Text59 = ms7ShuQianPingGu.sWBC;
            f7.Text65 = ms7ShuQianPingGu.sHb;
            f7.Text60 = ms7ShuQianPingGu.sALB;
            f7.Text61 = ms7ShuQianPingGu.sCEA;
            f7.Text62 = ms7ShuQianPingGu.sCA125;
            f7.Text66 = ms7ShuQianPingGu.sCA199;
            f7.Text63 = ms7ShuQianPingGu.sCA724;
            f7.Text20 = ms7ShuQianPingGu.sAFP;
            f7.Text32 = bool2HanZi(ms7ShuQianPingGu.bGengZhu);
            f7.Text67 = bool2HanZi(ms7ShuQianPingGu.bChuXie);
            f7.Text68 = bool2HanZi(ms7ShuQianPingGu.bChuanKong);
            f7.Text11 = ms7ShuQianPingGu.sBMI;
            f7.Text29 = ms7ShuQianPingGu.sNRS2002;
            f7.Text30 = ms7ShuQianPingGu.sTengTongPingFen;
            f7.Text33 = ms7ShuQianPingGu.sECOG;
            f7.Text19 = ms7ShuQianPingGu.sXinGongNeng;
            f7.Text12 = ms7ShuQianPingGu.sFeiGongNeng;
            f7.Text18 = ms7ShuQianPingGu.sShenGongNeng;
            f7.Text110 = ms7ShuQianPingGu.sGanGongNeng;
            f7.Text109 = ms7ShuQianPingGu.sNingXieGongneng;
            f7.Text17 = bool2HanZi(ms7ShuQianPingGu.bJiZhenShouShu);
            f7.Text114 = ms7ShuQianPingGu.sShouShuRiqi;
            f7.Text69 = ms7ShuQianPingGu.sQiangjingKaiFu;
            f7.Text31 = ms7ShuQianPingGu.sShuShi;
            f7.Text28 = ms7ShuQianPingGu.sShouShuTime;
            f7.Text27 = ms7ShuQianPingGu.sKaiFuWenHeTime;
            f7.Text16 = ms7ShuQianPingGu.sZhongLiuJuTiWeiZhi;
            f7.Text70 = bool2HanZi(ms7ShuQianPingGu.bLianHeQiZhuangQieChu);
            f7.Text26 = ms7ShuQianPingGu.sChuXieLiang;
            f7.Text71 = ms7ShuQianPingGu.sFuQiangWuRuan;
            f7.Text21 = ms7ShuQianPingGu.sFuShenShang;
            f7.Text13 = bool2HanZi(ms7ShuQianPingGu.bYingYangGuan);
            f7.Text72 = bool2HanZi(ms7ShuQianPingGu.bZaoLou);
            f7.Text73 = bool2HanZi(ms7ShuQianPingGu.bShuZhongBingLi);
            f7.Text77 = ms7ShuQianPingGu.sResult2;
            f7.Text74 = ms7ShuQianPingGu.sQieChuQingkong;
            f7.Text75 = ms7ShuQianPingGu.sLinBaJieQingShao;
            f7.Text78 = ms7ShuQianPingGu.sTeShuShuoMing;
            f7.Text76 = bool2HanZi(ms7ShuQianPingGu.bERAS);
            f7.Text77 = bool2HanZi(ms7ShuQianPingGu.bICUJianHu);
            f7.Text37 = ms7ShuQianPingGu.sJianHuTime;
            f7.Text14 = ms7ShuQianPingGu.sJinShuiShiJian;
            f7.Text24 = ms7ShuQianPingGu.sTongQiTime;
            f7.Text80 = ms7ShuQianPingGu.sPaiBianTime;
            f7.Text6 = ms7ShuQianPingGu.sFuTongHuanJieTime;
            f7.Text23 = ms7ShuQianPingGu.sNiaoGuanBaChuTime;
            f7.Text15 = ms7ShuQianPingGu.sYinLiuGuanBaChuTime;
            f7.Text9 = ms7ShuQianPingGu.sXiaChuangTime;
            f7.Text10 = ms7ShuQianPingGu.sJinShi;
            f7.Text113 = bool2HanZi(ms7ShuQianPingGu.bChangNeiYingYang);
            f7.Text1 = ms7ShuQianPingGu.sChangNeiYingYangZhiChiTime;
            f7.Text2 = ms7ShuQianPingGu.sTPNtime;
            f7.Text81 = ms7ShuQianPingGu.sShuHouChuXue;
            f7.Text82 = ms7ShuQianPingGu.sFuQiangGanRuan;
            f7.Text84 = ms7ShuQianPingGu.sQieKouGanRuan;
            f7.Text85 = ms7ShuQianPingGu.sWenHeKouLou;
            f7.Text86 = ms7ShuQianPingGu.sChangGenZhu;
            f7.Text5 = ms7ShuQianPingGu.sWeiTan;
            f7.Text83 = ms7ShuQianPingGu.sFeiBuFanRuan;
            f7.Text8 = ms7ShuQianPingGu.sDiDanBaiXueZheng;
            f7.Text98 = ms7ShuQianPingGu.sWEiGuanTuoChu;
            f7.Text90 = ms7ShuQianPingGu.sYingYangGuanTuoChu;
            f7.Text87 = ms7ShuQianPingGu.sZaoKouBingFaZheng;
            f7.Text4 = bool2HanZi(ms7ShuQianPingGu.b2thShouShu);
            f7.Text88 = ms7ShuQianPingGu.sShouShuTime;
            f7.Text7 = ms7ShuQianPingGu.sShouShuFangShi;
            f7.Text3 = ms7ShuQianPingGu.sJieJueWenTi;
            f7.Text102 = ms7ShuQianPingGu.sShuHouBingLiZhengDuan;
            f7.Text101 = ms7ShuQianPingGu.sFenHuaChengDu;
            f7.Text91 = ms7ShuQianPingGu.sJinRunShenDu;
            f7.Text100 = ms7ShuQianPingGu.sMaiGuanAiShuan;
            f7.Text99 = ms7ShuQianPingGu.sShenJingQinFang;
            f7.Text98 = ms7ShuQianPingGu.sAiJieJie;
            f7.Text104 = ms7ShuQianPingGu.sZongLinBaJieShu;
            f7.Text93 = ms7ShuQianPingGu.sZhuanyiLinBaJieShu;
            f7.Text92 = ms7ShuQianPingGu.sMSI;
            f7.Text106 = ms7ShuQianPingGu.sHER_2;
            f7.Text103 = ms7ShuQianPingGu.sP53;
            f7.Text105 = ms7ShuQianPingGu.sKi_67;
            f7.Text95 = ms7ShuQianPingGu.sK_RAS;
            f7.Text94 = ms7ShuQianPingGu.sN_RAS;
            f7.Text107 = ms7ShuQianPingGu.sShouHouBingLiFenQi;
            f7.Text111 = ms7ShuQianPingGu.sMSIQueZheng;
            f7.Text112 = ms7ShuQianPingGu.sJiYinJianCe;
            f7.Text97 = ms7ShuQianPingGu.sChuYuanTime;
            f7.Text96 = ms7ShuQianPingGu.sChuYuanQingKong;
            f7.Text108 = ms7ShuQianPingGu.sYiLiaoFeiYong;

            string sql1 = "select * from s7ShuQianPingGu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind(sql1, dgView7);

            gFlagAdd7 = 0; //设置局部更新标志位

            //显示
            outputLabel("Sheet7加载成功!");
            return true;
        }

        //基本信息-更新；
        private bool updateSheet7(ref FormSheet7 f7)
        {
            bool result = false; //返回值
            try
            {
                if (textBox82.Text == "") //编号不能为空
                {
                    MessageBox.Show("编号不能为空");
                    return false;
                }

                //更新
                ms7ShuQianPingGu.ID = gOid7;
                ms7ShuQianPingGu.iUserID = gOid.ToString();
                if (f7.Text1 == "") //编号
                {
                    output("编号不能为空");
                    return false;
                }

                //ms7ShuQianPingGu.ID                =  textBox.Text Text ;
                ms7ShuQianPingGu.iUserID = gOid.ToString();
                ms7ShuQianPingGu.ID = gOid7;
                ms7ShuQianPingGu.sBianHao = f7.Text36;
                ms7ShuQianPingGu.bWoYuanBingJian = hanZi2Bool(f7.Text37);
                ms7ShuQianPingGu.sResult = f7.Text38;
                ms7ShuQianPingGu.sBingLiHao = f7.Text35;
                ms7ShuQianPingGu.bWoYuanCT = hanZi2Bool(f7.Text1);
                ms7ShuQianPingGu.sZhongLiuDaXiao = f7.Text41;
                ms7ShuQianPingGu.sJuBuQinFang = f7.Text42;
                ms7ShuQianPingGu.bLinBaJieZhuanYi = hanZi2Bool(f7.Text43);
                ms7ShuQianPingGu.bZhuanYi = hanZi2Bool(f7.Text40);
                ms7ShuQianPingGu.sBuWei = f7.Text34;
                ms7ShuQianPingGu.bWoYuanMRI = hanZi2Bool(f7.Text39);
                ms7ShuQianPingGu.sMRIZhongliuDaXiao = f7.Text45;
                ms7ShuQianPingGu.sMRIJuBuQinFang = f7.Text46;
                ms7ShuQianPingGu.bMRILinBaJieZhuanYi = hanZi2Bool(f7.Text47);
                ms7ShuQianPingGu.bMRIZhuanYi = hanZi2Bool(f7.Text44);
                ms7ShuQianPingGu.sMRIBuWei = f7.Text48;
                ms7ShuQianPingGu.bPET = hanZi2Bool(f7.Text54);
                ms7ShuQianPingGu.sPETZhongLiuDaXiao = f7.Text50;
                ms7ShuQianPingGu.sPETJuBuQinFang = f7.Text51;
                ms7ShuQianPingGu.sDaiXieQiangDu = f7.Text55;
                ms7ShuQianPingGu.sLinBaZhuanYi = f7.Text52;
                ms7ShuQianPingGu.bPETZhuanYi = f7.Text49;
                ms7ShuQianPingGu.sPETBuWei = f7.Text53;
                ms7ShuQianPingGu.sZhuanYiBuWeiDaiXieQD = f7.Text56;
                ms7ShuQianPingGu.sCT = f7.Text57;
                ms7ShuQianPingGu.sCN = f7.Text58;
                ms7ShuQianPingGu.sCM = f7.Text64;
                ms7ShuQianPingGu.sWBC = f7.Text59;
                ms7ShuQianPingGu.sHb = f7.Text65;
                ms7ShuQianPingGu.sALB = f7.Text60;
                ms7ShuQianPingGu.sCEA = f7.Text61;
                ms7ShuQianPingGu.sCA125 = f7.Text62;
                ms7ShuQianPingGu.sCA199 = f7.Text66;
                ms7ShuQianPingGu.sCA724 = f7.Text63;
                ms7ShuQianPingGu.sAFP = f7.Text20;
                ms7ShuQianPingGu.bGengZhu = hanZi2Bool(f7.Text32);
                ms7ShuQianPingGu.bChuXie = hanZi2Bool(f7.Text67);
                ms7ShuQianPingGu.bChuanKong = hanZi2Bool(f7.Text68);
                ms7ShuQianPingGu.sBMI = f7.Text11;
                ms7ShuQianPingGu.sNRS2002 = f7.Text29;
                ms7ShuQianPingGu.sTengTongPingFen = f7.Text30;
                ms7ShuQianPingGu.sECOG = f7.Text33;
                ms7ShuQianPingGu.sXinGongNeng = f7.Text19;
                ms7ShuQianPingGu.sFeiGongNeng = f7.Text12;
                ms7ShuQianPingGu.sShenGongNeng = f7.Text18;
                ms7ShuQianPingGu.sGanGongNeng = f7.Text110;
                ms7ShuQianPingGu.sNingXieGongneng = f7.Text109;
                ms7ShuQianPingGu.bJiZhenShouShu = hanZi2Bool(f7.Text17);
                ms7ShuQianPingGu.sShouShuRiqi = f7.Text114;
                ms7ShuQianPingGu.sQiangjingKaiFu = f7.Text69;
                ms7ShuQianPingGu.sShuShi = f7.Text31;
                ms7ShuQianPingGu.sShouShuTime = f7.Text28;
                ms7ShuQianPingGu.sKaiFuWenHeTime = f7.Text27;
                ms7ShuQianPingGu.sZhongLiuJuTiWeiZhi = f7.Text16;
                ms7ShuQianPingGu.bLianHeQiZhuangQieChu = hanZi2Bool(f7.Text70);
                ms7ShuQianPingGu.sChuXieLiang = f7.Text26;
                ms7ShuQianPingGu.sFuQiangWuRuan = f7.Text71;
                ms7ShuQianPingGu.sFuShenShang = f7.Text21;
                ms7ShuQianPingGu.bYingYangGuan = hanZi2Bool(f7.Text13);
                ms7ShuQianPingGu.bZaoLou = hanZi2Bool(f7.Text72);
                ms7ShuQianPingGu.bShuZhongBingLi = hanZi2Bool(f7.Text73);
                ms7ShuQianPingGu.sResult2 = f7.Text77;
                ms7ShuQianPingGu.sQieChuQingkong = f7.Text74;
                ms7ShuQianPingGu.sLinBaJieQingShao = f7.Text75;
                ms7ShuQianPingGu.sTeShuShuoMing = f7.Text78;
                ms7ShuQianPingGu.bERAS = hanZi2Bool(f7.Text76);
                ms7ShuQianPingGu.bICUJianHu = hanZi2Bool(f7.Text77);
                ms7ShuQianPingGu.sJianHuTime = f7.Text37;
                ms7ShuQianPingGu.sJinShuiShiJian = f7.Text14;
                ms7ShuQianPingGu.sTongQiTime = f7.Text24;
                ms7ShuQianPingGu.sPaiBianTime = f7.Text80;
                ms7ShuQianPingGu.sFuTongHuanJieTime = f7.Text6;
                ms7ShuQianPingGu.sNiaoGuanBaChuTime = f7.Text23;
                ms7ShuQianPingGu.sYinLiuGuanBaChuTime = f7.Text15;
                ms7ShuQianPingGu.sXiaChuangTime = f7.Text9;
                ms7ShuQianPingGu.sJinShi = f7.Text10;
                ms7ShuQianPingGu.bChangNeiYingYang = hanZi2Bool(f7.Text113);
                ms7ShuQianPingGu.sChangNeiYingYangZhiChiTime = f7.Text1;
                ms7ShuQianPingGu.sTPNtime = f7.Text2;
                ms7ShuQianPingGu.sShuHouChuXue = f7.Text81;
                ms7ShuQianPingGu.sFuQiangGanRuan = f7.Text82;
                ms7ShuQianPingGu.sQieKouGanRuan = f7.Text84;
                ms7ShuQianPingGu.sWenHeKouLou = f7.Text85;
                ms7ShuQianPingGu.sChangGenZhu = f7.Text86;
                ms7ShuQianPingGu.sWeiTan = f7.Text5;
                ms7ShuQianPingGu.sFeiBuFanRuan = f7.Text83;
                ms7ShuQianPingGu.sDiDanBaiXueZheng = f7.Text8;
                ms7ShuQianPingGu.sWEiGuanTuoChu = f7.Text98;
                ms7ShuQianPingGu.sYingYangGuanTuoChu = f7.Text90;
                ms7ShuQianPingGu.sZaoKouBingFaZheng = f7.Text87;
                ms7ShuQianPingGu.b2thShouShu = hanZi2Bool(f7.Text4);
                ms7ShuQianPingGu.sShouShuTime = f7.Text88;
                ms7ShuQianPingGu.sShouShuFangShi = f7.Text7;
                ms7ShuQianPingGu.sJieJueWenTi = f7.Text3;
                ms7ShuQianPingGu.sShuHouBingLiZhengDuan = f7.Text102;
                ms7ShuQianPingGu.sFenHuaChengDu = f7.Text101;
                ms7ShuQianPingGu.sJinRunShenDu = f7.Text91;
                ms7ShuQianPingGu.sMaiGuanAiShuan = f7.Text100;
                ms7ShuQianPingGu.sShenJingQinFang = f7.Text99;
                ms7ShuQianPingGu.sAiJieJie = f7.Text98;
                ms7ShuQianPingGu.sZongLinBaJieShu = f7.Text104;
                ms7ShuQianPingGu.sZhuanyiLinBaJieShu = f7.Text93;
                ms7ShuQianPingGu.sMSI = f7.Text92;
                ms7ShuQianPingGu.sHER_2 = f7.Text106;
                ms7ShuQianPingGu.sP53 = f7.Text103;
                ms7ShuQianPingGu.sKi_67 = f7.Text105;
                ms7ShuQianPingGu.sK_RAS = f7.Text95;
                ms7ShuQianPingGu.sN_RAS = f7.Text94;
                ms7ShuQianPingGu.sShouHouBingLiFenQi = f7.Text107;
                ms7ShuQianPingGu.sMSIQueZheng = f7.Text111;
                ms7ShuQianPingGu.sJiYinJianCe = f7.Text112;
                ms7ShuQianPingGu.sChuYuanTime = f7.Text97;
                ms7ShuQianPingGu.sChuYuanQingKong = f7.Text96;
                ms7ShuQianPingGu.sYiLiaoFeiYong = f7.Text108;

                bool ret = false;
                if (1 == gFlagAdd || 1 == gFlagAdd7)  //全局新增或单条新增，
                {
                    ret = dos7ShuQianPingGu.Add(ms7ShuQianPingGu);
                }
                else if (false == dos7ShuQianPingGu.Exists(gOid7)) //若无记录，则点击保存也视为增加
                    ret = dos7ShuQianPingGu.Add(ms7ShuQianPingGu);
                else  //更新
                {
                    ret = dos7ShuQianPingGu.Update(ms7ShuQianPingGu);
                }

                gFlagAdd7 = 0; //局部新增还原

                if (true == ret) //显示
                {
                    outputLabel("Sheet7更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("Sheet7更新失败");
                    result = false;
                }


            }
            catch (Exception ex)
            {
                outputLabel("Sheet7更新失败，" + ex.Message);
                return false;
            }

            string sql1 = "select * from s7ShuQianPingGu where iUserID = '" + gOid.ToString() + "'"; //重新刷新，只显示本用户的信息
            databind(sql1, dgView7);

            return result;
        }
        #endregion
       
      
        #region test
        private Maticsoft.Model.ycyx modelYcyx = new Maticsoft.Model.ycyx();
        Maticsoft.DAL.ycyx ycyxDo = new Maticsoft.DAL.ycyx();


        //添加记录1-调试用；
        private void addSheetTest()
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("没有要添加的内容", "系统提示添加");
                return;
            }
            else
            {
                string sql = "insert into ycyx (fwhm,khmc,gsdq,dqpp,dqtc,dqzt) values ('" + textBox1.Text + "','" + textBox2.Text + "','" +
                    textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                int ret = achelp.ExcuteSql(sql);
                string sql1 = "select * from ycyx";
                databind1(sql1);

                //清空
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                //显示
                outputLabel("添加成功!");
            }
        }



        //添加记录1-基本信息；用于测试
        private void addSheetX(int oidUsersID)
        {
            if (textBox1Sheet1.Text == "") //姓名不能为空
            {
                MessageBox.Show("姓名不能为空","系统提示");
                return;
            }
            else
            {
                modelYcyx.fwhm = int.Parse(textBox1.Text);
                modelYcyx.khmc = int.Parse(textBox2.Text);
                modelYcyx.gsdq = int.Parse(textBox3.Text);
                modelYcyx.dqpp = textBox4.Text;
                modelYcyx.dqtc = int.Parse(textBox5.Text);
                modelYcyx.dqzt = int.Parse(textBox6.Text);
                modelYcyx.iUserID = oidUsersID; //关联两表
                
                bool ret =  ycyxDo.Add(modelYcyx);
 
                //string sql1 = "select * from ycyx";
                //databind1(sql1);

                //清空
                //显示
                outputLabel("sheetX添加成功!");
            }
        }

        //删除记录1-基本信息；
        private void deleteSheetX()
        {
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
                    bool ret = ycyxDo.Delete(Convert.ToInt32(oid));
                }
                string sql1 = "select * from ycyx";
                databind1(sql1);

                //显示
                outputLabel("sheetX删除成功!");
            }
        }

        
        //基本信息-更新；
        private void readSheetX(int oid)
        {
            
            //string sql = "select * from ycyx where ID=" + oid;
            //dt = achelp.GetDataTableFromDB(sql);

            //读取数据库数据到model，中转        
            Maticsoft.Model.Users modelUsersBin = UsersDo.GetModel(oid); //获取Userswyth
            
            //modelYcyx = ycyxDo.GetModelByiUserID(modelUsersBin.ID);

            //model赋值给窗体
            //textBox1.Text = modelYcyx.fwhm.ToString();
            //textBox2.Text = modelYcyx.khmc.ToString();
            //textBox3.Text = modelYcyx.gsdq.ToString();
            //textBox4.Text = modelYcyx.dqpp;   //string
            //textBox5.Text = modelYcyx.dqtc.ToString();
            //textBox6.Text = modelYcyx.dqzt.ToString();

            //显示
            outputLabel("sheetX加载成功!");
        }

        //基本信息-更新；
        private void updateSheetX()
        {       
            //更新
            try
            {
                modelYcyx.fwhm = int.Parse(textBox1.Text);
                modelYcyx.khmc = int.Parse(textBox2.Text);
                modelYcyx.gsdq = int.Parse(textBox3.Text);
                modelYcyx.dqpp = textBox4.Text;
                modelYcyx.dqtc = int.Parse(textBox5.Text);
                modelYcyx.dqzt = int.Parse(textBox6.Text);
                modelYcyx.ID = gOid;

                bool ret = ycyxDo.Update(modelYcyx);

                if (true == ret) //显示
                {
                    outputLabel("sheetX更新成功");
                }
                else 
                {
                    outputLabel("sheetX更新失败");
                }
            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
            }

            string sql1 = "select * from ycyx"; //重新刷新
            databind1(sql1);

        }

        //基本信息-最大ID；
        private int getMaxIDFromSheetX()
        {
            //查找
            try
            {
                return ycyxDo.GetMaxId();
            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
                return 0;
            }

        }

        //基本信息-ID是否存在；
        private bool checkIDFromSheetX(int ID)
        {
            //查找
            try
            {
                return ycyxDo.Exists(ID);
            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
                return false;
            }

        }

        //基本信息-获取记录总数；
        private int getCountFromSheetX(string stringBin)
        {
            //查找
            try
            {
                return ycyxDo.GetRecordCount(stringBin); //"khmc = '2'"
            }
            catch (Exception ex)
            {
                outputLabel(ex.Message);
                return 0;
            }

        }
  
    #endregion test

        #region "others "
        public static class TreeViewItems
        {
            public static void Add(object sender, TreeViewCancelEventArgs e)  
       {  
           e.Node.Nodes.Clear();  
           TreeNode tNode = e.Node;  
           //MessageBox.Show(tNode.Name);  
           string path = tNode.Name;  
           string[] dics = Directory.GetDirectories(path);  
           foreach (string dic in dics)  
           {  
               TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name);  
               subNode.Name = new DirectoryInfo(dic).FullName;  
               subNode.Tag = subNode.Name;
               subNode.Nodes.Add("");  
               tNode.Nodes.Add(subNode);  
  
           }  
           string[] files = Directory.GetFiles(path);  
           foreach (string aFile in files)  
           {  
               TreeNode subNode = new TreeNode(new FileInfo(aFile).Name);  
               subNode.Tag = aFile;  
               subNode.Name = subNode.Text;  
               tNode.Nodes.Add(subNode);  
           }  
       }
        }


        #endregion
    } //class
} //nameSpace
