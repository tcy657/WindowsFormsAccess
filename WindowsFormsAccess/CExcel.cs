using System;
using System.Linq; 
    using System.Collections.Generic;  
    using System.Windows.Forms;  
    using System.Text;  
    using System.Diagnostics;  
    using System.IO;  
    using Microsoft.Office.Interop.Excel; 
namespace WindowsFormsAccess
{
    public class CExcel
    {    
                
        
        /// <summary>  
            /// DataGridView导出Excel  
            /// </summary>  
            /// <param name="strCaption">Excel文件中的标题，显示在第一行</param>  
            /// <param name="myDGV">DataGridView 控件</param>  
            /// <returns>0:成功;1:DataGridView中无记录;2:Excel无法启动;9999:异常错误</returns>  
            public int ExportExcel(string strCaption, DataGridView myDGV, SaveFileDialog saveFileDialog)  
            {  
                int result = 9999;

                //如身份证在excel中显示的格式发生变化，可用如下命令 
                //range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, ColCount]);
                //range.NumberFormatLocal = "@";
                //range.Value2 = objData;  

                //保存                    
                saveFileDialog.Filter = "Execl files (*.xls)|*.xls";  
                saveFileDialog.FilterIndex = 0;  
                saveFileDialog.RestoreDirectory = true;  
                //saveFileDialog.CreatePrompt = true;  
                saveFileDialog.Title = "Export Excel File";  
                if ( saveFileDialog.ShowDialog()== DialogResult.OK)  
                {  
                    if (saveFileDialog.FileName == "")  
                    {  
                        MessageBox.Show("请输入保存文件名！"); 
                        saveFileDialog.ShowDialog();  
                    }  
                        // 列索引，行索引，总列数，总行数  
                    int ColIndex = 0;  
                    int RowIndex = 0;  
                    int ColCount = myDGV.ColumnCount;  
                    int RowCount = myDGV.RowCount;  
      
                    if (myDGV.RowCount == 0)  
                    {  
                        result = 1;  
                    }  
      
                    // 创建Excel对象  
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();  
                    if (xlApp == null)  
                    {  
                        result = 2;  
                    }  
                    try  
                    {  
                        // 创建Excel工作薄  
                        Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);  
                        Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[1];  
                        // 设置标题  
                        Microsoft.Office.Interop.Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, ColCount]); //标题所占的单元格数与DataGridView中的列数相同  
                        range.MergeCells = true;  
                        xlApp.ActiveCell.FormulaR1C1 = strCaption;  
                        xlApp.ActiveCell.Font.Size = 20;  
                        xlApp.ActiveCell.Font.Bold = true;  
                        xlApp.ActiveCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;  
                        // 创建缓存数据  
                        object[,] objData = new object[RowCount + 1, ColCount];  
                        //获取列标题  
                        foreach (DataGridViewColumn col in myDGV.Columns)  
                        {  
                            objData[RowIndex, ColIndex++] = col.HeaderText;  
                        }  
                        // 获取数据  
                        for (RowIndex = 1; RowIndex < RowCount; RowIndex++)  
                        {  
                            for (ColIndex = 0; ColIndex < ColCount; ColIndex++)  
                            {  
                                if (myDGV[ColIndex, RowIndex - 1].ValueType == typeof(string)  
                                    || myDGV[ColIndex, RowIndex - 1].ValueType == typeof(DateTime))//这里就是验证DataGridView单元格中的类型,如果是string或是DataTime类型,则在放入缓存时在该内容前加入" ";  
                                {  
                                    objData[RowIndex, ColIndex] = "" + myDGV[ColIndex, RowIndex - 1].Value;  
                                }  
                                else  
                                {  
                                    objData[RowIndex, ColIndex] = myDGV[ColIndex, RowIndex - 1].Value;  
                                }  
                            }  
                            System.Windows.Forms.Application.DoEvents();  
                        }  
                        // 写入Excel  
                        range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount, ColCount]);  
                        range.Value2 = objData;  
      
                        xlBook.Saved = true;  
                        xlBook.SaveCopyAs(saveFileDialog.FileName);  
                    }  
                    catch (Exception err)  
                    {  
                        result = 9999;
                    }  
                    finally
                    {  
                        xlApp.Quit();  
                        GC.Collect(); //强制回收  
                    }  
                    //返回值  
                    result = 0;  
                }  
                  
                return result;  
            }
            /// <summary>  
            /// DataGridView导出Excel  
            /// </summary>  
            /// index, sheet的索引号
            /// <param name="strCaption">Excel文件中的标题，显示在第一行</param>  
            /// <param name="myDGV">DataGridView 控件</param>  
            /// fileDirectory， 保存的文件路径
            /// <returns>0:成功;1:DataGridView中无记录;2:Excel无法启动;9999:异常错误</returns> 
            public int ExportExcelSheet(int index, string strCaption, DataGridView myDGV, DataGridView myDGV2, string fileDirectory)
            {
                int result = 9999;

                //如身份证在excel中显示的格式发生变化，可用如下命令 
                //range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, ColCount]);
                //range.NumberFormatLocal = "@";
                //range.Value2 = objData;  


                // 列索引，行索引，总列数，总行数  
                int ColIndex = 0;
                int RowIndex = 0;
                int ColCount = myDGV.ColumnCount;
                int RowCount = myDGV.RowCount;

                if (myDGV.RowCount == 0)
                {
                    result = 1;
                }

                // 创建Excel对象  
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (xlApp == null)
                {
                    result = 2;
                }
                try
                {
                    // 创建Excel工作薄  
                    Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                    Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[index];
                    // 设置标题                    
                    Microsoft.Office.Interop.Excel.Range range = xlSheet.get_Range(xlSheet.Cells[1, 1], xlSheet.Cells[1, ColCount]); //标题所占的单元格数与DataGridView中的列数相同  
                    range.MergeCells = true;
                    xlApp.ActiveCell.FormulaR1C1 = strCaption;
                    xlApp.ActiveCell.Font.Size = 20;
                    xlApp.ActiveCell.Font.Bold = true;
                    xlApp.ActiveCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlSheet.Name = "s1";
                    // 创建缓存数据  
                    object[,] objData = new object[RowCount + 1, ColCount];
                    //获取列标题  
                    foreach (DataGridViewColumn col in myDGV.Columns)
                    {
                        objData[RowIndex, ColIndex++] = col.HeaderText;
                    }
                    // 获取数据  
                    for (RowIndex = 1; RowIndex < RowCount; RowIndex++)
                    {
                        for (ColIndex = 0; ColIndex < ColCount; ColIndex++)
                        {
                            if (myDGV[ColIndex, RowIndex - 1].ValueType == typeof(string)
                                || myDGV[ColIndex, RowIndex - 1].ValueType == typeof(DateTime))//这里就是验证DataGridView单元格中的类型,如果是string或是DataTime类型,则在放入缓存时在该内容前加入" ";  
                            {
                                objData[RowIndex, ColIndex] = "" + myDGV[ColIndex, RowIndex - 1].Value;
                            }
                            else
                            {
                                objData[RowIndex, ColIndex] = myDGV[ColIndex, RowIndex - 1].Value;
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    // 写入Excel  
                    range = xlSheet.get_Range(xlSheet.Cells[2, 1], xlSheet.Cells[RowCount, ColCount]);
                    range.Value2 = objData;

                    #region sheet2
                    // 列索引，行索引，总列数，总行数  
                    ColIndex = 0;
                    RowIndex = 0;
                    ColCount = myDGV2.ColumnCount;
                    RowCount = myDGV2.RowCount;

                    Microsoft.Office.Interop.Excel.Worksheet xlSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[2];
                    // 设置标题                    
                    Microsoft.Office.Interop.Excel.Range range2 = xlSheet.get_Range(xlSheet2.Cells[1, 1], xlSheet2.Cells[1, ColCount]); //标题所占的单元格数与DataGridView中的列数相同  
                    range2.MergeCells = true;                   
                    xlApp.ActiveCell.FormulaR1C1 = "s2";  //标题2
                    xlApp.ActiveCell.Font.Size = 20;
                    xlApp.ActiveCell.Font.Bold = true;
                    xlApp.ActiveCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;                  
                    xlSheet2.Name = "s2";
                    // 创建缓存数据  
                    object[,] objData2 = new object[RowCount + 1, ColCount];
                    //获取列标题  
                    foreach (DataGridViewColumn col in myDGV2.Columns)
                    {
                        objData2[RowIndex, ColIndex++] = col.HeaderText;
                    }
                    // 获取数据  
                    for (RowIndex = 1; RowIndex < RowCount; RowIndex++)
                    {
                        for (ColIndex = 0; ColIndex < ColCount; ColIndex++)
                        {
                            if (myDGV2[ColIndex, RowIndex - 1].ValueType == typeof(string)
                                || myDGV2[ColIndex, RowIndex - 1].ValueType == typeof(DateTime))//这里就是验证DataGridView单元格中的类型,如果是string或是DataTime类型,则在放入缓存时在该内容前加入" ";  
                            {
                                objData2[RowIndex, ColIndex] = "" + myDGV2[ColIndex, RowIndex - 1].Value;
                            }
                            else
                            {
                                objData2[RowIndex, ColIndex] = myDGV2[ColIndex, RowIndex - 1].Value;
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    // 写入Excel  
                    range2 = xlSheet2.get_Range(xlSheet2.Cells[2, 1], xlSheet2.Cells[RowCount, ColCount]);
                    range2.Value2 = objData2;

                    #endregion sheet2




                    xlBook.Saved = true;
                    xlBook.SaveCopyAs(fileDirectory);
                    
                }
                catch (Exception err)
                {
                    result = 9999;
                }
                finally
                {
                    xlApp.Quit();
                    GC.Collect(); //强制回收  
                }
                //返回值  
                result = 0;
                return result;
            }  
      
    }  //class
}
