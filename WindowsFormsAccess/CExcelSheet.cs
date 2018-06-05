using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection; // 引用这个才能使用Missing字段 

namespace WindowsFormsAccess
{
    /**
 * datagirdview导出到excel的工具类
 * Function:dataGridView导出到excel或者excel的多个sheet当中
 * author:Kelsey_Chen
 * Date:2013-11-14
 * */
    public static class CExcelSheet
    {             
        /// <summary>
        ///  读入DataGridView的数据在Excel中显示
        /// </summary>
        /// <param name="dgv">显示内容的DataGridView的名称</param>
        public static void setExcel(DataGridView dgv, string name)
        {
            //总可见列数，总可见行数
            int colCount = dgv.Columns.GetColumnCount(DataGridViewElementStates.Visible);
            int rowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Visible);
            //dataGridView 没有数据提示
            if (dgv.Rows.Count == 0 || rowCount == 0)
            {
                MessageBox.Show("表中没有数据", "提示");
            }
            else
            {
                //选择创建文件的路径
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "excel files(*.xls)|*.xls";
                save.Title = @"C:\AutoTestTool";
                save.FileName = name + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string fileName = save.FileName;
                  
                    // 创建Excel对象
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    if (excel == null)
                    {
                        MessageBox.Show("Excel无法启动", "提示");
                        return;
                    }
                    //创建Excel工作薄
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excel.Workbooks.Add(true);
                    Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)                                        excelBook.Worksheets[1];
                    excelSheet.Name = name;
                    //excel.Application.Workbooks.Add(true);
                    //生成字段名称
                    int k = 0;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (dgv.Columns[i].Visible)  //不导出隐藏的列
                        {
                            excelSheet.Cells[1, k + 1] = dgv.Columns[i].HeaderText;
                            k++;
                        }
                    }
                    //填充数据
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        k = 0;
                        for (int j = 0; j < dgv.ColumnCount; j++)
                        {
                            if (dgv.Columns[j].Visible)  //不导出隐藏的列
                            {
                                if (dgv[j, i].ValueType == typeof(string))
                                {
                                    excelSheet.Cells[i + 2, k + 1] = "" + dgv[j, i].Value.ToString();
                                }
                                else
                                {
                                    excelSheet.Cells[i + 2, k + 1] = dgv[j, i].Value.ToString();
                                }
                            }
                            k++;
                        }
                    }
                    try
                    {
                        excelBook.Saved = true;
                        excelBook.SaveCopyAs(fileName);
                    }
                    catch
                    {
                        MessageBox.Show("导出失败，文件可能正在使用中", "提示");
                    }
                    //excelBook.Close(true);
                    excel.Quit();


                    releaseObject(excelSheet);
                    releaseObject(excelBook);
                    releaseObject(excel);


                }
            }
        }


        /// <summary>
        ///  多个dataGirdView导出到同一个excel的多个sheet当中
        /// </summary>
        /// <param name="myDics">一个装载多个datagirdview的集合</param>
        public static void setMoreExcelSheet(Dictionary<string, DataGridView> myDics)
        {
            string fileName = "";
            Microsoft.Office.Interop.Excel.Application excel = null;
             //选择创建文件的路径
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "excel files(*.xls)|*.xls";
            save.Title = @"C:\AutoTestTool";
            save.FileName = "all_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (save.ShowDialog() == DialogResult.OK)
            {
                fileName = save.FileName;
                //MessageBox.Show(save.FileName);
                // 创建Excel对象
                excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("Excel无法启动", "提示");
                    return;
                }
            }
            else
            {
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook excelBook = null;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = null;
          
            //创建Excel工作薄
            excelBook = excel.Workbooks.Add(true);
             foreach (KeyValuePair<string, DataGridView> kvp in myDics)
            {
                DataGridView dataGridView = kvp.Value;
                string name = kvp.Key;
               
                Console.WriteLine("Key = {0}, Value = {1}", name, dataGridView);


               
                //总可见列数，总可见行数
                int colCount = dataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                int rowCount = dataGridView.Rows.GetRowCount(DataGridViewElementStates.Visible);
                //dataGridView 没有数据提示
                if (dataGridView.Rows.Count == 0 || rowCount == 0)
                {
                    MessageBox.Show("表中没有数据", "提示");
                }
                else
                {
                    if (null == excelSheet)
                    {
                        excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets[1];
                        excelSheet.Name = name;
                   
                    }
                    else
                    {
                        //expression.Add(Before, After, Count, Type)
                        //expression     ：    必需。该表达式返回上面的对象之一。
                        //Before    ：    Variant 类型，可选。指定工作表对象，新建的工作表将置于此工作表之前。
                        //After    ：    Variant 类型，可选。指定工作表对象，新建的工作表将置于此工作表之后。
                        //Count    ：    Variant 类型，可选。要新建的工作表的数目。默认值为 1。
                       //Type    ：    Variant 类型，可选。指定工作表类型。
                        excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.Add(Type.Missing,
                            excelSheet, 1, Type.Missing);
                        excelSheet.Name = name;
                    }
                                     
                    //生成字段名称
                    int k = 0;
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        if (dataGridView.Columns[i].Visible)  //不导出隐藏的列
                        {
                            excel.Cells[1, k + 1] = dataGridView.Columns[i].HeaderText;
                            k++;
                        }
                    }
                    //填充数据
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        k = 0;
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            if (dataGridView.Columns[j].Visible)  //不导出隐藏的列
                            {
                                if (dataGridView[j, i].ValueType == typeof(string))
                                {
                                    excel.Cells[i + 2, k + 1] = "" + dataGridView[j, i].Value.ToString();
                                }
                                else
                                {
                                    excel.Cells[i + 2, k + 1] = dataGridView[j, i].Value.ToString();
                                }
                            }
                            k++;
                        }
                    } 
                }
            }


             try
             {
                 excelBook.Saved = true;
                 excelBook.SaveCopyAs(fileName);


                 //excelBook.Close(true);
                 excel.Quit();
                 releaseObject(excelSheet);
                 releaseObject(excelBook);
                 releaseObject(excel);
             }
             catch
             {
                 MessageBox.Show("导出失败，文件可能正在使用中", "提示");
             }


        }




        /// <summary>
        /// 释放对象
        /// </summary>
        /// <param name="obj">需要被释放的对象</param>
        /// <param name="strCaption"></param>
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 
        
    }
}


