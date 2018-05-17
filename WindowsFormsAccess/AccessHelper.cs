using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Maticsoft.DBUtility
{
    public class AccessHelper
    {
        private string conn_str = null;
        private OleDbConnection ole_connection = null;
        private OleDbCommand ole_command = null;
        private OleDbDataReader ole_reader = null;
        private DataTable dt = null;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        public AccessHelper()
        {
            //conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Environment.CurrentDirectory + "\\yxdain.accdb'";  
            //无密码
            conn_str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + Environment.CurrentDirectory + "\\linChuang.accdb'"; 
            //有密码
            //conn_str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + Environment.CurrentDirectory + "\\linChuang.accdb';Jet OLEDB:Database Password=admin";
            InitDB();
        }

        private void InitDB()
        {
            ole_connection = new OleDbConnection(conn_str);//创建实例  
            ole_command = new OleDbCommand();
        }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="db_path">数据库路径</param>  
        public AccessHelper(string db_path)
        {
            //conn_str ="Provider=Microsoft.Jet.OLEDB.4.0;Data Source='"+ db_path + "'";  
            conn_str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + db_path + "'";

            InitDB();
        }

        /// <summary>  
        /// 转换数据格式  
        /// </summary>  
        /// <param name="reader">数据源</param>  
        /// <returns>数据列表</returns>  
        private DataTable ConvertOleDbReaderToDataTable(ref OleDbDataReader reader)
        {
            DataTable dt_tmp = null;
            DataRow dr = null;
            int data_column_count = 0;
            int i = 0;

            data_column_count = reader.FieldCount;
            dt_tmp = BuildAndInitDataTable(data_column_count);

            if (dt_tmp == null)
            {
                return null;
            }

            while (reader.Read())
            {
                dr = dt_tmp.NewRow();

                for (i = 0; i < data_column_count; ++i)
                {
                    dr[i] = reader[i];
                }

                dt_tmp.Rows.Add(dr);
            }

            return dt_tmp;
        }

        /// <summary>  
        /// 创建并初始化数据列表  
        /// </summary>  
        /// <param name="Field_Count">列的个数</param>  
        /// <returns>数据列表</returns>  
        private DataTable BuildAndInitDataTable(int Field_Count)
        {
            DataTable dt_tmp = null;
            DataColumn dc = null;
            int i = 0;

            if (Field_Count <= 0)
            {
                return null;
            }

            dt_tmp = new DataTable();

            for (i = 0; i < Field_Count; ++i)
            {
                dc = new DataColumn(i.ToString());
                dt_tmp.Columns.Add(dc);
            }

            return dt_tmp;
        }

        /// <summary>  
        /// 从数据库里面获取数据  
        /// </summary>  
        /// <param name="strSql">查询语句</param>  
        /// <returns>数据列表</returns>  
        public DataTable GetDataTableFromDB(string strSql)
        {
            if (conn_str == null)
            {
                return null;
            }

            try
            {
                ole_connection.Open();//打开连接  

                if (ole_connection.State == ConnectionState.Closed)
                {
                    return null;
                }

                ole_command.CommandText = strSql;
                ole_command.Connection = ole_connection;

                ole_reader = ole_command.ExecuteReader(CommandBehavior.Default);

                dt = ConvertOleDbReaderToDataTable(ref ole_reader);

                ole_reader.Close();
                ole_reader.Dispose();
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e.ToString());  
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (ole_connection.State != ConnectionState.Closed)
                {
                    ole_connection.Close();
                }
            }

            return dt;
        }

        /// <summary>  
        /// 执行sql语句  
        /// </summary>  
        /// <param name="strSql">sql语句</param>  
        /// <returns>返回结果</returns>  
        public int ExcuteSql(string strSql)
        {
            int nResult = 0;

            try
            {
                ole_connection.Open();//打开数据库连接  
                if (ole_connection.State == ConnectionState.Closed)
                {
                    return nResult;
                }

                ole_command.Connection = ole_connection;
                ole_command.CommandText = strSql;

                nResult = ole_command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e.ToString());  
                MessageBox.Show(e.Message);
                return nResult;
            }
            finally
            {
                if (ole_connection.State != ConnectionState.Closed)
                {
                    ole_connection.Close();
                }
            }

            return nResult;
        }

        #region 扩充，移植
        /// <summary>  
        /// 执行sql语句，带参数  
        /// </summary>  
        /// <param name="strSql">sql语句</param>  
        /// <returns>返回结果</returns>  
        public int ExecuteSql(string strSql, params OleDbParameter[] cmdParms)
        {
            int nResult = 0;

            try
            {
                if (ole_connection.State != ConnectionState.Open)  //数据库未打开，则连接。防止二次打开报错
                {
                    ole_connection.Open();//打开数据库连接 
                }
                 
                if (ole_connection.State == ConnectionState.Closed)
                {
                    return nResult;
                }

                ole_command.Connection = ole_connection;
                ole_command.CommandText = strSql;
                PrepareCommand(ole_command, ole_command.Connection, null, strSql, cmdParms);

                nResult = ole_command.ExecuteNonQuery();
                ole_command.Parameters.Clear();
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e.ToString());  
                MessageBox.Show(e.Message);
                return nResult;
            }
            finally
            {
                if (ole_connection.State != ConnectionState.Closed)
                {
                    ole_connection.Close();
                }
            }

            return nResult;
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        /// 从public static去掉了static有何影响
        public  DataSet Query(string SQLString, params OleDbParameter[] cmdParms)
        {
            ole_command.Connection = ole_connection;
            ole_command.CommandText = SQLString;
            PrepareCommand(ole_command, ole_command.Connection, null, SQLString, cmdParms);
            using (OleDbDataAdapter da = new OleDbDataAdapter(ole_command))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        ole_command.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
        }


        //参数处理
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public  int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public  bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public  bool Exists(string strSql, params OleDbParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public  object GetSingle(string SQLString)
        {
            ole_command.Connection = ole_connection;
            ole_command.CommandText = SQLString;       
                    try
                    {
                        if (ole_connection.State != ConnectionState.Open)
                        {
                            ole_connection.Open();
                        }
                        object obj = ole_command.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        ole_connection.Close();
                        throw new Exception(e.Message);
                    }
            
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public  object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
        {
            ole_command.Connection = ole_connection;
            ole_command.CommandText = SQLString;
            try
            {
                PrepareCommand(ole_command, ole_command.Connection, null, SQLString, cmdParms);
                object obj = ole_command.ExecuteScalar();
                ole_command.Parameters.Clear();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }

        }



        /// <summary>  
        /// 执行sql, 二进制语句  
        /// </summary>  
        /// <param name="strSql">sql语句</param>  
        /// <returns>返回结果</returns>  
        public int ExcuteSql2(string strSql, byte[] bytes)
        {
            int nResult = 0;

            try
            {
                ole_connection.Open();//打开数据库连接  
                if (ole_connection.State == ConnectionState.Closed)
                {
                    return nResult;
                }

                ole_command.Connection = ole_connection;
                ole_command.CommandType = CommandType.Text;
                ole_command.CommandText = strSql;

                OleDbParameter spFile = new OleDbParameter("@file", OleDbType.Binary);
                spFile.Value = bytes;
                ole_command.Parameters.Add(spFile);

                nResult = ole_command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e.ToString());  
                MessageBox.Show(e.Message);
                return nResult;
            }
            finally
            {
                if (ole_connection.State != ConnectionState.Closed)
                {
                    ole_connection.Close();
                }
            }

            return nResult;
        }


        /// <summary>  
        /// 从数据库里面获取数据，二进制获取文件  
        /// </summary>  
        /// <param name="strSql">查询语句</param>  
        /// <returns>文件的下进制流</returns>  
        public byte[] GetDataTableFromDB2(string strSql)
        {
            byte[] fileStream = null;
            if (conn_str == null)
            {
                return null;
            }

            try
            {
                ole_connection.Open();//打开连接  

                if (ole_connection.State == ConnectionState.Closed)
                {
                    return null;
                }
                ole_command.CommandType = CommandType.Text;
                ole_command.CommandText = strSql;
                ole_command.Connection = ole_connection;

                ole_reader = ole_command.ExecuteReader(CommandBehavior.Default);

                if (ole_reader.Read())
                {
                    fileStream = (byte[])ole_reader[0];
                    MessageBox.Show(ole_reader[1].ToString());
                }

                //dt = ConvertOleDbReaderToDataTable(ref ole_reader);

                ole_reader.Close();
                ole_reader.Dispose();
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e.ToString());  
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (ole_connection.State != ConnectionState.Closed)
                {
                    ole_connection.Close();
                }
            }

            return fileStream;
        }
        #endregion 扩充，移植
    }
}