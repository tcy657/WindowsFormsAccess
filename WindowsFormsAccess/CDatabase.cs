using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsAccess
{
    public partial class Form1 : Form
    {
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
#region sheet1
        private Maticsoft.Model.Users model = new Maticsoft.Model.Users();
        private string sqlString = ""; //保存sql语句 

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
                model.sBianHao = "None";
                model.sBianMa = comboBox7Sheet1.Text;
                model.sZhuYuanHao = textBox8Sheet1.Text;
                model.sName = textBox1Sheet1.Text;
                model.sSex = comboBox2Sheet1.Text;
                model.iAge = textBox4Sheet1.Text;
                model.sZhiYe = textBox3Sheet1.Text;
                model.dRuYuanShiJian = dtp1time9Sheet1.Value;
                model.sPhone = textBox6Sheet1.Text;
                
                //string sql = "insert into Users (sBianHao,sBianMa,sZhuYuanHao,sName,sSex,iAge,sZhiYe,dRuYuanShiJian,sPhone) values ('None', '" +comboBox7Sheet1.Text + "','" +textBox8Sheet1.Text + "','" +textBox1Sheet1.Text + "','"
                //           + comboBox2Sheet1.Text + "','" + textBox4Sheet1.Text + "','" + textBox3Sheet1.Text + "','" + dtp1time9Sheet1.Value + "','" + textBox6Sheet1.Text + "')";

                string sql = "insert into Users (sBianHao,sBianMa,sZhuYuanHao,sName,sSex,iAge,sZhiYe,dRuYuanShiJian,sPhone) values ('" + model.sBianHao +"', '"
                                                                                                                                       + model.sBianMa + "','"
                                                                                                                                       + model.sZhuYuanHao + "','"
                                                                                                                                       + model.sName + "','"
                                                                                                                                       + model.sSex + "','"
                                                                                                                                       + model.iAge + "','"
                                                                                                                                       + model.sZhiYe + "','"
                                                                                                                                       + model.dRuYuanShiJian + "','"
                                                                                                                                       + model.sPhone + "')";

                int ret = achelp.ExcuteSql(sql);
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
                    string sql = "delete from Users where ID=" + oid;  
                    int ret = achelp.ExcuteSql(sql);  
                }  
                string sql1 = "select * from Users";  
                databind1(sql1);  

                //显示
                output("sheet1删除成功!");
            }
        }


        //基本信息-更新；
        private void updateSheet1()
        {
            if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)  
            {  
                MessageBox.Show("没有选中行。", "M员工");  
                return;  
            }  

            DataTable dt = new DataTable();  
            object oid = dataGridView1.SelectedRows[0].Cells[0].Value;  
            string sql = "select * from Users where ID=" + oid;  
            dt = achelp.GetDataTableFromDB(sql);
            
            //读取数据库数据到model，中转
            model.sBianHao            =dt.Rows[0][1].ToString();
            model.sBianMa             =dt.Rows[0][2].ToString();
            model.sZhuYuanHao         =dt.Rows[0][3].ToString();
            model.sName               =dt.Rows[0][4].ToString();
            model.sSex                =dt.Rows[0][5].ToString();
            model.iAge                =dt.Rows[0][6].ToString();
            model.sZhiYe              =dt.Rows[0][7].ToString();
            model.dRuYuanShiJian      = Convert.ToDateTime(dt.Rows[0][8].ToString());
            model.sPhone              =dt.Rows[0][9].ToString();
                       //model.sBianHao
            //model赋值给窗体
            comboBox7Sheet1.Text    =  model.sBianMa;
            textBox8Sheet1.Text     =  model.sZhuYuanHao;
            textBox1Sheet1.Text     =  model.sName;
            comboBox2Sheet1.Text    =  model.sSex;
            textBox4Sheet1.Text     =  model.iAge;
            textBox3Sheet1.Text     =  model.sZhiYe;
            dtp1time9Sheet1.Value =    Convert.ToDateTime(model.dRuYuanShiJian);
            textBox6Sheet1.Text     =  model.sPhone;

            
            //更新
            try
            {
                //UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing'WHERE LastName = 'Wilson'  
                //string sql = "update ycyx set fwhm='" + textBox1.Text + "',khmc='" + textBox2.Text + "',gsdq='" + textBox3.Text + "',dqpp='" + textBox4.Text +
                //    "',dqtc='" + textBox5.Text + "',dqzt='" + textBox6.Text + "' where ID=" + iid;


                model.sBianHao = "None1";
                model.sBianMa = comboBox7Sheet1.Text;
                model.sZhuYuanHao = textBox8Sheet1.Text;
                model.sName = textBox1Sheet1.Text;
                model.sSex = comboBox2Sheet1.Text;
                model.iAge = textBox4Sheet1.Text;
                model.sZhiYe = textBox3Sheet1.Text;
                model.dRuYuanShiJian = dtp1time9Sheet1.Value;
                model.sPhone = textBox6Sheet1.Text;

                int iid = int.Parse(oid.ToString());
                sqlString = "update Users set sBianHao ='" + model.sBianHao 
                                         + "',sBianMa ='" + model.sBianMa 
                                         + "',sZhuYuanHao ='" + model.sZhuYuanHao
                                         + "',sName ='" + model.sName
                                         + "',sSex ='" + model.sSex 
                                         + "',iAge ='" + model.iAge
                                         + "',sZhiYe ='" + model.sZhiYe 
                                         + "',dRuYuanShiJian ='" + model.dRuYuanShiJian
                                         + "',sPhone ='" + model.sPhone 
                                         + "' where ID=" +iid;                     

                int ret = achelp.ExcuteSql(sql);
                if (ret > -1)
                {
                  output("更新成功");
                }
            }
            catch (Exception ex)
            {
                output(ex.Message);
            }  
            
            
            
            string sql1 = "select * from Users"; //重新刷新
            databind1(sql1);  

                //显示
                output("sheet1更新成功!");
        }
#endregion sheet1

    } //class
} //nameSpace
