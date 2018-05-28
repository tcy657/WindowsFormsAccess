using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;

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
                //当前用户
                tssLabel1.Text = "当前用户：管理员";
                tssLabel2.Text = "| 一定成功，加油！";

                tabControl1.TabPages.Remove(tabPage2); //调试用
                tabControl1.TabPages.Remove(tabPage3);  //test
                tabControl1.TabPages.Remove(tabPageS5File);  //file
                //tabControl1.TabPages.Remove(tabPageS3);

                string sql1 = "select * from Users"; //重新刷新
                databind(sql1, dataGridView1);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderCell.Value = "手机号码";
                dataGridView1.Columns[2].HeaderCell.Value = "员工名称";
                dataGridView1.Columns[3].HeaderCell.Value = "归属地区";
                dataGridView1.Columns[4].HeaderCell.Value = "当前部门";
                dataGridView1.Columns[5].HeaderCell.Value = "当前专项";
                dataGridView1.Columns[6].HeaderCell.Value = "当前状态";
                
                
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

        #endregion 公用方法

        #region sheet1
        private Maticsoft.Model.Users model = new Maticsoft.Model.Users();
        Maticsoft.DAL.Users UsersDo = new Maticsoft.DAL.Users();

        //添加记录1-基本信息；
        private void addSheet1()
        {
            if (textBox1Sheet1.Text == "") //姓名不能为空
            {
                output("员工添加时，没有要添加的内容");
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

                bool ret = UsersDo.Add(model);

                string sql1 = "select * from Users";
                databind1(sql1);

                //清空
               

                //显示
                output("sheet1添加成功!");
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
                output("sheet1删除成功!");
            }
        }       

        //基本信息-加载；
        private void readSheet1(int oid)
        {
            //if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)
            //{
            //    MessageBox.Show("没有选中行。", "系统提示");
            //    return;
            //}

            
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

            string sql1 = "select * from Users"; //刷新主页面，防止后台改了access数据库后，基本信息页面刷新了，主页面不刷新。
            databind1(sql1);  

            //显示
            output("sheet1加载成功!");
        }

        //基本信息-更新；
        private bool updateSheet1()
        {
            bool result = false; //返回值
            try
            {
                if (textBox1Sheet1.Text == "") //住院号不能为空
                {
                    output("姓名不能为空");
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
                    output("sheet1更新成功");
                    result = true;
                }
                else
                {
                    output("sheet1更新失败");
                    result = false;
                }

               
            }
            catch (Exception ex)
            {
                output(ex.Message);
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

        #endregion

        #region sheet6

        #endregion

        #region sheet7

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
                output("添加成功!");
            }
        }



        //添加记录1-基本信息；用于测试
        private void addSheetX(int oidUsersID)
        {
            if (textBox1Sheet1.Text == "") //姓名不能为空
            {
                output("员工添加时，没有要添加的内容");
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
                output("sheetX添加成功!");
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
                output("sheetX删除成功!");
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
            output("sheetX加载成功!");
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
                    output("sheetX更新成功");
                }
                else 
                {
                    output("sheetX更新失败");
                }
            }
            catch (Exception ex)
            {
                output(ex.Message);
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
                output(ex.Message);
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
                output(ex.Message);
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
                output(ex.Message);
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
