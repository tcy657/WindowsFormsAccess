/**  版本信息模板在安装目录下，可自行修改。
* ycyx.cs
*
* 功 能： N/A
* 类 名： ycyx
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-5-11 21:45:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility; //引入命名空间
//using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ycyx
	/// </summary>
	public partial class ycyx
	{
        //WindowsFormsAccess.AccessHelper DbHelperOleDb = new WindowsFormsAccess.AccessHelper();
        AccessHelper DbHelperOleDb = new AccessHelper();
        public ycyx()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "ycyx");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ycyx");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.ycyx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ycyx(");
			strSql.Append("fwhm,khmc,gsdq,dqpp,dqtc,dqzt)");
			strSql.Append(" values (");
			strSql.Append("@fwhm,@khmc,@gsdq,@dqpp,@dqtc,@dqzt)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@fwhm", OleDbType.Integer,4),
					new OleDbParameter("@khmc", OleDbType.Integer,4),
					new OleDbParameter("@gsdq", OleDbType.Integer,4),
					new OleDbParameter("@dqpp", OleDbType.VarChar,200),
					new OleDbParameter("@dqtc", OleDbType.Integer,4),
					new OleDbParameter("@dqzt", OleDbType.Integer,4)};
			parameters[0].Value = model.fwhm;
			parameters[1].Value = model.khmc;
			parameters[2].Value = model.gsdq;
			parameters[3].Value = model.dqpp;
			parameters[4].Value = model.dqtc;
			parameters[5].Value = model.dqzt;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
     
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ycyx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ycyx set ");
			strSql.Append("fwhm=@fwhm,");
			strSql.Append("khmc=@khmc,");
			strSql.Append("gsdq=@gsdq,");
			strSql.Append("dqpp=@dqpp,");
			strSql.Append("dqtc=@dqtc,");
			strSql.Append("dqzt=@dqzt");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@fwhm", OleDbType.Integer,4),
					new OleDbParameter("@khmc", OleDbType.Integer,4),
					new OleDbParameter("@gsdq", OleDbType.Integer,4),
					new OleDbParameter("@dqpp", OleDbType.VarChar,200),
					new OleDbParameter("@dqtc", OleDbType.Integer,4),
					new OleDbParameter("@dqzt", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.fwhm;
			parameters[1].Value = model.khmc;
			parameters[2].Value = model.gsdq;
			parameters[3].Value = model.dqpp;
			parameters[4].Value = model.dqtc;
			parameters[5].Value = model.dqzt;
			parameters[6].Value = model.ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ycyx ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ycyx ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

       
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ycyx GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,fwhm,khmc,gsdq,dqpp,dqtc,dqzt from ycyx ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.ycyx model=new Maticsoft.Model.ycyx();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

       
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Maticsoft.Model.ycyx DataRowToModel(DataRow row)
       {
           Maticsoft.Model.ycyx model=new Maticsoft.Model.ycyx();
           if (row != null)
           {
               if(row["ID"]!=null && row["ID"].ToString()!="")
               {
                   model.ID=int.Parse(row["ID"].ToString());
               }
               if(row["fwhm"]!=null && row["fwhm"].ToString()!="")
               {
                   model.fwhm=int.Parse(row["fwhm"].ToString());
               }
               if(row["khmc"]!=null && row["khmc"].ToString()!="")
               {
                   model.khmc=int.Parse(row["khmc"].ToString());
               }
               if(row["gsdq"]!=null && row["gsdq"].ToString()!="")
               {
                   model.gsdq=int.Parse(row["gsdq"].ToString());
               }
               if(row["dqpp"]!=null)
               {
                   model.dqpp=row["dqpp"].ToString();
               }
               if(row["dqtc"]!=null && row["dqtc"].ToString()!="")
               {
                   model.dqtc=int.Parse(row["dqtc"].ToString());
               }
               if(row["dqzt"]!=null && row["dqzt"].ToString()!="")
               {
                   model.dqzt=int.Parse(row["dqzt"].ToString());
               }
           }
           return model;
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql=new StringBuilder();
           strSql.Append("select ID,fwhm,khmc,gsdq,dqpp,dqtc,dqzt ");
           strSql.Append(" FROM ycyx ");
           if(strWhere.Trim()!="")
           {
               strSql.Append(" where "+strWhere);
           }
           return DbHelperOleDb.Query(strSql.ToString());
       }
       
       /// <summary>
       /// 获取记录总数
       /// </summary>
       public int GetRecordCount(string strWhere)
       {
           StringBuilder strSql=new StringBuilder();
           strSql.Append("select count(1) FROM ycyx ");
           if(strWhere.Trim()!="")
           {
               strSql.Append(" where "+strWhere);
           }
           object obj = DbHelperOleDb.GetSingle(strSql.ToString());
           if (obj == null)
           {
               return 0;
           }
           else
           {
               return Convert.ToInt32(obj);
           }
       }
       
      /// <summary>
      /// 分页获取数据列表
      /// </summary>
      public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
      {
          StringBuilder strSql=new StringBuilder();
          strSql.Append("SELECT * FROM ( ");
          strSql.Append(" SELECT ROW_NUMBER() OVER (");
          if (!string.IsNullOrEmpty(orderby.Trim()))
          {
              strSql.Append("order by T." + orderby );
          }
          else
          {
              strSql.Append("order by T.ID desc");
          }
          strSql.Append(")AS Row, T.*  from ycyx T ");
          if (!string.IsNullOrEmpty(strWhere.Trim()))
          {
              strSql.Append(" WHERE " + strWhere);
          }
          strSql.Append(" ) TT");
          strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
          return DbHelperOleDb.Query(strSql.ToString());
      }

      /*
      /// <summary>
      /// 分页获取数据列表
      /// </summary>
      public DataSet GetList(int PageSize,int PageIndex,string strWhere)
      {
          OleDbParameter[] parameters = {
                  new OleDbParameter("@tblName", OleDbType.VarChar, 255),
                  new OleDbParameter("@fldName", OleDbType.VarChar, 255),
                  new OleDbParameter("@PageSize", OleDbType.Integer),
                  new OleDbParameter("@PageIndex", OleDbType.Integer),
                  new OleDbParameter("@IsReCount", OleDbType.Boolean),
                  new OleDbParameter("@OrderType", OleDbType.Boolean),
                  new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
                  };
          parameters[0].Value = "ycyx";
          parameters[1].Value = "ID";
          parameters[2].Value = PageSize;
          parameters[3].Value = PageIndex;
          parameters[4].Value = 0;
          parameters[5].Value = 0;
          parameters[6].Value = strWhere;	
          return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
      }*/

      
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

