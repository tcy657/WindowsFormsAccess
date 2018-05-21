using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace WindowsFormsAccess
{
    public partial class Form1 : Form
    {        
        
        #region 公用方法/变量
        int gOid = 0; //全局oid，记录Users的ID号

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
                MessageBox.Show("没有选中行。", "M员工");
            }
            else
            {
                object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dataGridView1.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "M员工", MessageBoxButtons.YesNo))
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

                bool ret = UsersDo.Update(model); 

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
            databind1(sql1);

            return result;
        }

    #endregion sheet1

       #region test
        private Maticsoft.Model.ycyx modelYcyx = new Maticsoft.Model.ycyx();
        Maticsoft.DAL.ycyx ycyxDo = new Maticsoft.DAL.ycyx();


        //添加记录1-调试用；
        private void addSheetTest()
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("没有要添加的内容", "M员工添加");
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
                MessageBox.Show("没有选中行。", "M员工");
            }
            else
            {
                object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
                if (DialogResult.No == MessageBox.Show("将删除第 " + (dataGridView1.CurrentCell.RowIndex + 1).ToString() + " 行，确定？", "M员工", MessageBoxButtons.YesNo))
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
            modelYcyx = ycyxDo.GetModelByUserID(modelUsersBin.ID);

            //model赋值给窗体
            textBox1.Text = modelYcyx.fwhm.ToString();
            textBox2.Text = modelYcyx.khmc.ToString();
            textBox3.Text = modelYcyx.gsdq.ToString();
            textBox4.Text = modelYcyx.dqpp;   //string
            textBox5.Text = modelYcyx.dqtc.ToString();
            textBox6.Text = modelYcyx.dqzt.ToString();

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
