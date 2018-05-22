﻿/**  版本信息模板在安装目录下，可自行修改。
* s6QiBingQingKuang.cs
*
* 功 能： N/A
* 类 名： s6QiBingQingKuang
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/22 19:46:18   N/A    初版
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
	/// 数据访问类:s6QiBingQingKuang
	/// </summary>
	public partial class s6QiBingQingKuang
	{
       private AccessHelper DbHelperOleDb;
       public s6QiBingQingKuang(string dbPath)
       {
            DbHelperOleDb = new AccessHelper(dbPath);
       }
		public s6QiBingQingKuang()
       {
            DbHelperOleDb = new AccessHelper();
       }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "s6QiBingQingKuang"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s6QiBingQingKuang");
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
		public bool Add(Maticsoft.Model.s6QiBingQingKuang model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s6QiBingQingKuang(");
			strSql.Append("sBianMa,sZhongLiuBuWei,sShouFaZhengZhuang,dTime,dChuBuZhengDuanTime,sResult,sZhenDuanYiJiu,iUserID)");
			strSql.Append(" values (");
			strSql.Append("@sBianMa,@sZhongLiuBuWei,@sShouFaZhengZhuang,@dTime,@dChuBuZhengDuanTime,@sResult,@sZhenDuanYiJiu,@iUserID)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@sZhongLiuBuWei", OleDbType.VarChar,255),
					new OleDbParameter("@sShouFaZhengZhuang", OleDbType.VarChar,255),
					new OleDbParameter("@dTime", OleDbType.Date),
					new OleDbParameter("@dChuBuZhengDuanTime", OleDbType.Date),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@sZhenDuanYiJiu", OleDbType.VarChar,255),
					new OleDbParameter("@iUserID", OleDbType.VarChar,255)};
			parameters[0].Value = model.sBianMa;
			parameters[1].Value = model.sZhongLiuBuWei;
			parameters[2].Value = model.sShouFaZhengZhuang;
			parameters[3].Value = model.dTime;
			parameters[4].Value = model.dChuBuZhengDuanTime;
			parameters[5].Value = model.sResult;
			parameters[6].Value = model.sZhenDuanYiJiu;
			parameters[7].Value = model.iUserID;

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
		public bool Update(Maticsoft.Model.s6QiBingQingKuang model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update s6QiBingQingKuang set ");
			strSql.Append("sBianMa=@sBianMa,");
			strSql.Append("sZhongLiuBuWei=@sZhongLiuBuWei,");
			strSql.Append("sShouFaZhengZhuang=@sShouFaZhengZhuang,");
			strSql.Append("dTime=@dTime,");
			strSql.Append("dChuBuZhengDuanTime=@dChuBuZhengDuanTime,");
			strSql.Append("sResult=@sResult,");
			strSql.Append("sZhenDuanYiJiu=@sZhenDuanYiJiu,");
			strSql.Append("iUserID=@iUserID");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@sZhongLiuBuWei", OleDbType.VarChar,255),
					new OleDbParameter("@sShouFaZhengZhuang", OleDbType.VarChar,255),
					new OleDbParameter("@dTime", OleDbType.Date),
					new OleDbParameter("@dChuBuZhengDuanTime", OleDbType.Date),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@sZhenDuanYiJiu", OleDbType.VarChar,255),
					new OleDbParameter("@iUserID", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.sBianMa;
			parameters[1].Value = model.sZhongLiuBuWei;
			parameters[2].Value = model.sShouFaZhengZhuang;
			parameters[3].Value = model.dTime;
			parameters[4].Value = model.dChuBuZhengDuanTime;
			parameters[5].Value = model.sResult;
			parameters[6].Value = model.sZhenDuanYiJiu;
			parameters[7].Value = model.iUserID;
			parameters[8].Value = model.ID;

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
			strSql.Append("delete from s6QiBingQingKuang ");
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
			strSql.Append("delete from s6QiBingQingKuang ");
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
		public Maticsoft.Model.s6QiBingQingKuang GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianMa,sZhongLiuBuWei,sShouFaZhengZhuang,dTime,dChuBuZhengDuanTime,sResult,sZhenDuanYiJiu,iUserID from s6QiBingQingKuang ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.s6QiBingQingKuang model=new Maticsoft.Model.s6QiBingQingKuang();
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
		public Maticsoft.Model.s6QiBingQingKuang DataRowToModel(DataRow row)
		{
			Maticsoft.Model.s6QiBingQingKuang model=new Maticsoft.Model.s6QiBingQingKuang();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["sBianMa"]!=null)
				{
					model.sBianMa=row["sBianMa"].ToString();
				}
				if(row["sZhongLiuBuWei"]!=null)
				{
					model.sZhongLiuBuWei=row["sZhongLiuBuWei"].ToString();
				}
				if(row["sShouFaZhengZhuang"]!=null)
				{
					model.sShouFaZhengZhuang=row["sShouFaZhengZhuang"].ToString();
				}
				if(row["dTime"]!=null && row["dTime"].ToString()!="")
				{
					model.dTime=DateTime.Parse(row["dTime"].ToString());
				}
				if(row["dChuBuZhengDuanTime"]!=null && row["dChuBuZhengDuanTime"].ToString()!="")
				{
					model.dChuBuZhengDuanTime=DateTime.Parse(row["dChuBuZhengDuanTime"].ToString());
				}
				if(row["sResult"]!=null)
				{
					model.sResult=row["sResult"].ToString();
				}
				if(row["sZhenDuanYiJiu"]!=null)
				{
					model.sZhenDuanYiJiu=row["sZhenDuanYiJiu"].ToString();
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
			strSql.Append("select ID,sBianMa,sZhongLiuBuWei,sShouFaZhengZhuang,dTime,dChuBuZhengDuanTime,sResult,sZhenDuanYiJiu,iUserID ");
			strSql.Append(" FROM s6QiBingQingKuang ");
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
			strSql.Append("select count(1) FROM s6QiBingQingKuang ");
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
			strSql.Append(")AS Row, T.*  from s6QiBingQingKuang T ");
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
			parameters[0].Value = "s6QiBingQingKuang";
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

