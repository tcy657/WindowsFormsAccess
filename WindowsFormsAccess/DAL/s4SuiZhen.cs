/**  版本信息模板在安装目录下，可自行修改。
* s4SuiZhen.cs
*
* 功 能： N/A
* 类 名： s4SuiZhen
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/27 22:52:10   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：湘竹科技有限公司　　　　　　　　　　　　　　│
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
	/// 数据访问类:s4SuiZhen
	/// </summary>
	public partial class s4SuiZhen
	{
       private AccessHelper DbHelperOleDb;
       public s4SuiZhen(string dbPath)
       {
            DbHelperOleDb = new AccessHelper(dbPath);
       }
		public s4SuiZhen()
       {
            DbHelperOleDb = new AccessHelper();
       }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "s4SuiZhen"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s4SuiZhen");
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
		public bool Add(Maticsoft.Model.s4SuiZhen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s4SuiZhen(");
			strSql.Append("sBianHao,sSuiZhenCiShu,dSuiZhenTime,sZhuYuanHao,sCT,sMRI,sNeiJing,sPET,bFuFa,iUserID)");
			strSql.Append(" values (");
			strSql.Append("@sBianHao,@sSuiZhenCiShu,@dSuiZhenTime,@sZhuYuanHao,@sCT,@sMRI,@sNeiJing,@sPET,@bFuFa,@iUserID)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255),
					new OleDbParameter("@sSuiZhenCiShu", OleDbType.VarChar,255),
					new OleDbParameter("@dSuiZhenTime", OleDbType.Date),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sCT", OleDbType.VarChar,255),
					new OleDbParameter("@sMRI", OleDbType.VarChar,255),
					new OleDbParameter("@sNeiJing", OleDbType.VarChar,255),
					new OleDbParameter("@sPET", OleDbType.VarChar,255),
					new OleDbParameter("@bFuFa", OleDbType.Boolean,1),
					new OleDbParameter("@iUserID", OleDbType.VarChar,255)};
			parameters[0].Value = model.sBianHao;
			parameters[1].Value = model.sSuiZhenCiShu;
			parameters[2].Value = model.dSuiZhenTime;
			parameters[3].Value = model.sZhuYuanHao;
			parameters[4].Value = model.sCT;
			parameters[5].Value = model.sMRI;
			parameters[6].Value = model.sNeiJing;
			parameters[7].Value = model.sPET;
			parameters[8].Value = model.bFuFa;
			parameters[9].Value = model.iUserID;

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
		public bool Update(Maticsoft.Model.s4SuiZhen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update s4SuiZhen set ");
			strSql.Append("sBianHao=@sBianHao,");
			strSql.Append("sSuiZhenCiShu=@sSuiZhenCiShu,");
			strSql.Append("dSuiZhenTime=@dSuiZhenTime,");
			strSql.Append("sZhuYuanHao=@sZhuYuanHao,");
			strSql.Append("sCT=@sCT,");
			strSql.Append("sMRI=@sMRI,");
			strSql.Append("sNeiJing=@sNeiJing,");
			strSql.Append("sPET=@sPET,");
			strSql.Append("bFuFa=@bFuFa,");
			strSql.Append("iUserID=@iUserID");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255),
					new OleDbParameter("@sSuiZhenCiShu", OleDbType.VarChar,255),
					new OleDbParameter("@dSuiZhenTime", OleDbType.Date),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sCT", OleDbType.VarChar,255),
					new OleDbParameter("@sMRI", OleDbType.VarChar,255),
					new OleDbParameter("@sNeiJing", OleDbType.VarChar,255),
					new OleDbParameter("@sPET", OleDbType.VarChar,255),
					new OleDbParameter("@bFuFa", OleDbType.Boolean,1),
					new OleDbParameter("@iUserID", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.sBianHao;
			parameters[1].Value = model.sSuiZhenCiShu;
			parameters[2].Value = model.dSuiZhenTime;
			parameters[3].Value = model.sZhuYuanHao;
			parameters[4].Value = model.sCT;
			parameters[5].Value = model.sMRI;
			parameters[6].Value = model.sNeiJing;
			parameters[7].Value = model.sPET;
			parameters[8].Value = model.bFuFa;
			parameters[9].Value = model.iUserID;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from s4SuiZhen ");
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
			strSql.Append("delete from s4SuiZhen ");
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
		public Maticsoft.Model.s4SuiZhen GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianHao,sSuiZhenCiShu,dSuiZhenTime,sZhuYuanHao,sCT,sMRI,sNeiJing,sPET,bFuFa,iUserID from s4SuiZhen ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.s4SuiZhen model=new Maticsoft.Model.s4SuiZhen();
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
		public Maticsoft.Model.s4SuiZhen DataRowToModel(DataRow row)
		{
			Maticsoft.Model.s4SuiZhen model=new Maticsoft.Model.s4SuiZhen();
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
				if(row["sSuiZhenCiShu"]!=null)
				{
					model.sSuiZhenCiShu=row["sSuiZhenCiShu"].ToString();
				}
				if(row["dSuiZhenTime"]!=null && row["dSuiZhenTime"].ToString()!="")
				{
					model.dSuiZhenTime=DateTime.Parse(row["dSuiZhenTime"].ToString());
				}
				if(row["sZhuYuanHao"]!=null)
				{
					model.sZhuYuanHao=row["sZhuYuanHao"].ToString();
				}
				if(row["sCT"]!=null)
				{
					model.sCT=row["sCT"].ToString();
				}
				if(row["sMRI"]!=null)
				{
					model.sMRI=row["sMRI"].ToString();
				}
				if(row["sNeiJing"]!=null)
				{
					model.sNeiJing=row["sNeiJing"].ToString();
				}
				if(row["sPET"]!=null)
				{
					model.sPET=row["sPET"].ToString();
				}
				if(row["bFuFa"]!=null && row["bFuFa"].ToString()!="")
				{
					if((row["bFuFa"].ToString()=="1")||(row["bFuFa"].ToString().ToLower()=="true"))
					{
						model.bFuFa=true;
					}
					else
					{
						model.bFuFa=false;
					}
				}
				if(row["iUserID"]!=null)
				{
					model.iUserID=row["iUserID"].ToString();
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
			strSql.Append("select ID,sBianHao,sSuiZhenCiShu,dSuiZhenTime,sZhuYuanHao,sCT,sMRI,sNeiJing,sPET,bFuFa,iUserID ");
			strSql.Append(" FROM s4SuiZhen ");
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
			strSql.Append("select count(1) FROM s4SuiZhen ");
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
			strSql.Append(")AS Row, T.*  from s4SuiZhen T ");
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
			parameters[0].Value = "s4SuiZhen";
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

