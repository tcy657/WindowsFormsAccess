using System.Text;
using System.Windows.Forms;
using System;

namespace WindowsFormsAccess
{
    public partial class Form1 : Form
    {
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
    }
}
