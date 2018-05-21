/**  版本信息模板在安装目录下，可自行修改。
* s2XinFuZhu.cs
*
* 功 能： N/A
* 类 名： s2XinFuZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 12:22:47   N/A    初版
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
	/// 数据访问类:s2XinFuZhu
	/// </summary>
	public partial class s2XinFuZhu
	{
		AccessHelper DbHelperOleDb = new AccessHelper();

		public s2XinFuZhu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sBianMa)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s2XinFuZhu");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianMa;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.s2XinFuZhu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s2XinFuZhu(");
			strSql.Append("sBianMa,bXinFuZhu,sZhuYuanHao,sFangAn,sJiLiang,sLiaoCheng,sPingJia,b2thBingJian,sResult)");
			strSql.Append(" values (");
			strSql.Append("@sBianMa,@bXinFuZhu,@sZhuYuanHao,@sFangAn,@sJiLiang,@sLiaoCheng,@sPingJia,@b2thBingJian,@sResult)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@bXinFuZhu", OleDbType.Boolean,1),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sJiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sPingJia", OleDbType.VarChar,255),
					new OleDbParameter("@b2thBingJian", OleDbType.Boolean,1),
					new OleDbParameter("@sResult", OleDbType.VarChar,255)};
			parameters[0].Value = model.sBianMa;
			parameters[1].Value = model.bXinFuZhu;
			parameters[2].Value = model.sZhuYuanHao;
			parameters[3].Value = model.sFangAn;
			parameters[4].Value = model.sJiLiang;
			parameters[5].Value = model.sLiaoCheng;
			parameters[6].Value = model.sPingJia;
			parameters[7].Value = model.b2thBingJian;
			parameters[8].Value = model.sResult;

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
		public bool Update(Maticsoft.Model.s2XinFuZhu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update s2XinFuZhu set ");
			strSql.Append("bXinFuZhu=@bXinFuZhu,");
			strSql.Append("sZhuYuanHao=@sZhuYuanHao,");
			strSql.Append("sFangAn=@sFangAn,");
			strSql.Append("sJiLiang=@sJiLiang,");
			strSql.Append("sLiaoCheng=@sLiaoCheng,");
			strSql.Append("sPingJia=@sPingJia,");
			strSql.Append("b2thBingJian=@b2thBingJian,");
			strSql.Append("sResult=@sResult");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@bXinFuZhu", OleDbType.Boolean,1),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sJiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sPingJia", OleDbType.VarChar,255),
					new OleDbParameter("@b2thBingJian", OleDbType.Boolean,1),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)};
			parameters[0].Value = model.bXinFuZhu;
			parameters[1].Value = model.sZhuYuanHao;
			parameters[2].Value = model.sFangAn;
			parameters[3].Value = model.sJiLiang;
			parameters[4].Value = model.sLiaoCheng;
			parameters[5].Value = model.sPingJia;
			parameters[6].Value = model.b2thBingJian;
			parameters[7].Value = model.sResult;
			parameters[8].Value = model.ID;
			parameters[9].Value = model.sBianMa;

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
		public bool Delete(string sBianMa)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from s2XinFuZhu ");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianMa;

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
		public bool DeleteList(string sBianMalist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from s2XinFuZhu ");
			strSql.Append(" where sBianMa in ("+sBianMalist + ")  ");
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
		public Maticsoft.Model.s2XinFuZhu GetModel(string sBianMa)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianMa,bXinFuZhu,sZhuYuanHao,sFangAn,sJiLiang,sLiaoCheng,sPingJia,b2thBingJian,sResult from s2XinFuZhu ");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianMa;

			Maticsoft.Model.s2XinFuZhu model=new Maticsoft.Model.s2XinFuZhu();
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
		public Maticsoft.Model.s2XinFuZhu DataRowToModel(DataRow row)
		{
			Maticsoft.Model.s2XinFuZhu model=new Maticsoft.Model.s2XinFuZhu();
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
				if(row["bXinFuZhu"]!=null && row["bXinFuZhu"].ToString()!="")
				{
					if((row["bXinFuZhu"].ToString()=="1")||(row["bXinFuZhu"].ToString().ToLower()=="true"))
					{
						model.bXinFuZhu=true;
					}
					else
					{
						model.bXinFuZhu=false;
					}
				}
				if(row["sZhuYuanHao"]!=null)
				{
					model.sZhuYuanHao=row["sZhuYuanHao"].ToString();
				}
				if(row["sFangAn"]!=null)
				{
					model.sFangAn=row["sFangAn"].ToString();
				}
				if(row["sJiLiang"]!=null)
				{
					model.sJiLiang=row["sJiLiang"].ToString();
				}
				if(row["sLiaoCheng"]!=null)
				{
					model.sLiaoCheng=row["sLiaoCheng"].ToString();
				}
				if(row["sPingJia"]!=null)
				{
					model.sPingJia=row["sPingJia"].ToString();
				}
				if(row["b2thBingJian"]!=null && row["b2thBingJian"].ToString()!="")
				{
					if((row["b2thBingJian"].ToString()=="1")||(row["b2thBingJian"].ToString().ToLower()=="true"))
					{
						model.b2thBingJian=true;
					}
					else
					{
						model.b2thBingJian=false;
					}
				}
				if(row["sResult"]!=null)
				{
					model.sResult=row["sResult"].ToString();
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
			strSql.Append("select ID,sBianMa,bXinFuZhu,sZhuYuanHao,sFangAn,sJiLiang,sLiaoCheng,sPingJia,b2thBingJian,sResult ");
			strSql.Append(" FROM s2XinFuZhu ");
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
			strSql.Append("select count(1) FROM s2XinFuZhu ");
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
				strSql.Append("order by T.sBianMa desc");
			}
			strSql.Append(")AS Row, T.*  from s2XinFuZhu T ");
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
			parameters[0].Value = "s2XinFuZhu";
			parameters[1].Value = "sBianMa";
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

