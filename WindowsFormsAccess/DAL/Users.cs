/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
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
using Maticsoft.DBUtility;//Please add references
 
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class Users
	{
        AccessHelper DbHelperOleDb = new AccessHelper();
        public Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("sBianHao,sBianMa,sZhuYuanHao,sName,sSex,iAge,sZhiYe,dRuYuanShiJian,sPhone)");
			strSql.Append(" values (");
			strSql.Append("@sBianHao,@sBianMa,@sZhuYuanHao,@sName,@sSex,@iAge,@sZhiYe,@dRuYuanShiJian,@sPhone)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255),
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sName", OleDbType.VarChar,255),
					new OleDbParameter("@sSex", OleDbType.VarChar,255),
					new OleDbParameter("@iAge", OleDbType.VarChar,255),
					new OleDbParameter("@sZhiYe", OleDbType.VarChar,255),
					new OleDbParameter("@dRuYuanShiJian", OleDbType.Date),
					new OleDbParameter("@sPhone", OleDbType.VarChar,20)};
			parameters[0].Value = model.sBianHao;
			parameters[1].Value = model.sBianMa;
			parameters[2].Value = model.sZhuYuanHao;
			parameters[3].Value = model.sName;
			parameters[4].Value = model.sSex;
			parameters[5].Value = model.iAge;
			parameters[6].Value = model.sZhiYe;
			parameters[7].Value = model.dRuYuanShiJian;
			parameters[8].Value = model.sPhone;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("sBianHao=@sBianHao,");
			strSql.Append("sBianMa=@sBianMa,");
			strSql.Append("sZhuYuanHao=@sZhuYuanHao,");
			strSql.Append("sName=@sName,");
			strSql.Append("sSex=@sSex,");
			strSql.Append("iAge=@iAge,");
			strSql.Append("sZhiYe=@sZhiYe,");
			strSql.Append("dRuYuanShiJian=@dRuYuanShiJian,");
			strSql.Append("sPhone=@sPhone");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255),
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sName", OleDbType.VarChar,255),
					new OleDbParameter("@sSex", OleDbType.VarChar,255),
					new OleDbParameter("@iAge", OleDbType.VarChar,255),
					new OleDbParameter("@sZhiYe", OleDbType.VarChar,255),
					new OleDbParameter("@dRuYuanShiJian", OleDbType.Date),
					new OleDbParameter("@sPhone", OleDbType.VarChar,20),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.sBianHao;
			parameters[1].Value = model.sBianMa;
			parameters[2].Value = model.sZhuYuanHao;
			parameters[3].Value = model.sName;
			parameters[4].Value = model.sSex;
			parameters[5].Value = model.iAge;
			parameters[6].Value = model.sZhiYe;
			parameters[7].Value = model.dRuYuanShiJian;
			parameters[8].Value = model.sPhone;
			parameters[9].Value = model.ID;

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
			strSql.Append("delete from Users ");
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
			strSql.Append("delete from Users ");
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
		public Maticsoft.Model.Users GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianHao,sBianMa,sZhuYuanHao,sName,sSex,iAge,sZhiYe,dRuYuanShiJian,sPhone from Users ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.Users model=new Maticsoft.Model.Users();
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
		public Maticsoft.Model.Users DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Users model=new Maticsoft.Model.Users();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["sBianHao"]!=null)
				{
					model.sBianHao=row["sBianHao"].ToString();
				}
				if(row["sBianMa"]!=null)
				{
					model.sBianMa=row["sBianMa"].ToString();
				}
				if(row["sZhuYuanHao"]!=null)
				{
					model.sZhuYuanHao=row["sZhuYuanHao"].ToString();
				}
				if(row["sName"]!=null)
				{
					model.sName=row["sName"].ToString();
				}
				if(row["sSex"]!=null)
				{
					model.sSex=row["sSex"].ToString();
				}
				if(row["iAge"]!=null)
				{
					model.iAge=row["iAge"].ToString();
				}
				if(row["sZhiYe"]!=null)
				{
					model.sZhiYe=row["sZhiYe"].ToString();
				}
				if(row["dRuYuanShiJian"]!=null && row["dRuYuanShiJian"].ToString()!="")
				{
					model.dRuYuanShiJian=DateTime.Parse(row["dRuYuanShiJian"].ToString());
				}
				if(row["sPhone"]!=null)
				{
					model.sPhone=row["sPhone"].ToString();
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
			strSql.Append("select ID,sBianHao,sBianMa,sZhuYuanHao,sName,sSex,iAge,sZhiYe,dRuYuanShiJian,sPhone ");
			strSql.Append(" FROM Users ");
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
			strSql.Append("select count(1) FROM Users ");
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
			strSql.Append(")AS Row, T.*  from Users T ");
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
			parameters[0].Value = "Users";
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

