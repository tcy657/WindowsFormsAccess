using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsAccess
{
    class ClogFile
    {
        private string workPath;

        public ClogFile()
        {
           workPath = System.Windows.Forms.Application.StartupPath; //获取启动了应用程序的可执行文件的路径，“D：\fh_bk”形式，末尾不带“\”
        }

        //F0.11 保存到文件，带日期+时间
        public void writeLog( string log, string filePath )
        {
            try
            {
                //文件超过10M则删除
                if (File.Exists(filePath))
                {
                    System.IO.FileInfo MyFileInfo = new FileInfo(filePath);
                    int MyFileSize = (int)MyFileInfo.Length / (1024 * 1024);
                    if (MyFileSize > 10) //文件大于10M
                    {
                        File.Delete(filePath);
                    }
                }

                //保存数据到文件
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write); //追加
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));//通过指定字符编码方式可以实现对汉字的支持，否则在用记事本打开查看会出现乱码

                //整理数据
                sw.WriteLine(DateTime.Now.ToLocalTime().ToString() + "," + log);
                sw.Flush();
                sw.Close();
                sw.Dispose(); //确保文件对象被完全释放
            }//try 
            catch (Exception objException)
            {
                //不处理。因为处理可能会导致死循环。若save2FileTime()出错，则save2FileTime()->output()->save2FileTime()
                //output("保存到文件(带时间)时发生意外：" + objException.Message);
                ;
            }
        }

        //F0.11 保存到默认文件名，带日期+时间
        public bool writeLog(string log)
        {
           bool result = false; //'默认为false
           string myLog_FileName = System.DateTime.Now.ToString("yyyyMMdd");
           // 以日期作文件名，一天记录一个日志
           try
           {
               string my_Dir  = workPath + @"\log\"+ System.DateTime.Now.ToString("yyyyMMdd");
               if ( false == Directory.Exists(my_Dir) )
               {
                   Directory.CreateDirectory(my_Dir);  //'--如果目录不存在，就建立它。 
               }

               string strRecord = System.String.Format("[{0:yyyy/MM/dd HH:mm:ss}]Message : {1}", System.DateTime.Now, log.Trim()); //DateTime.Now.ToLocalTime().ToString() + "," + log

               string LogFile = my_Dir + @"\" + myLog_FileName + ".log";   //'--每一个日志后辍都是 .log
               
               //文件超过10M则删除
               if (File.Exists(LogFile))
               {
                   System.IO.FileInfo MyFileInfo = new FileInfo(LogFile);
                   int MyFileSize = (int)MyFileInfo.Length / (1024 * 1024);
                   if (MyFileSize > 10) //文件大于10M
                   {
                       File.Delete(LogFile);
                   }
               }

                //保存数据到文件
                FileStream fs = new FileStream(LogFile, FileMode.Append, FileAccess.Write); //追加
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));//通过指定字符编码方式可以实现对汉字的支持，否则在用记事本打开查看会出现乱码

                //整理数据
                sw.WriteLine(strRecord);
                sw.Flush();
                sw.Close();
                sw.Dispose(); //确保文件对象被完全释放

               result = true;
               return result;
           }//try 
           catch (Exception objException)
            {
                result = false;
                return result;
           }            
        }

  } //class

}
