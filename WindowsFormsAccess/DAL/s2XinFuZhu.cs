/**  版本信息模板在安装目录下，可自行修改。
* s2XinFuZhu.cs
*
* 功 能： N/A
* 类 名： s2XinFuZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/7 9:41:23   N/A    初版
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
	/// 数据访问类:s2XinFuZhu
	/// </summary>
	public partial class s2XinFuZhu
	{
       private AccessHelper DbHelperOleDb;
       public s2XinFuZhu(string dbPath)
       {
            DbHelperOleDb = new AccessHelper(dbPath);
       }
		public s2XinFuZhu()
       {
            DbHelperOleDb = new AccessHelper();
       }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "s2XinFuZhu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s2XinFuZhu");
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
		public bool Add(Maticsoft.Model.s2XinFuZhu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s2XinFuZhu(");
			strSql.Append("sBianMa,bXinFuZhu,sZhuYuanHao,sFangAn,sJiLiang,sLiaoCheng,sLiaoXiaoPingJia,sFangLiaoFangAn,sFangLiaoLiaoCheng,bShuQian2thBingJian,sResult,bXinFuZhuFangLiao,iUserID)");
			strSql.Append(" values (");
			strSql.Append("@sBianMa,@bXinFuZhu,@sZhuYuanHao,@sFangAn,@sJiLiang,@sLiaoCheng,@sLiaoXiaoPingJia,@sFangLiaoFangAn,@sFangLiaoLiaoCheng,@bShuQian2thBingJian,@sResult,@bXinFuZhuFangLiao,@iUserID)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@bXinFuZhu", OleDbType.Boolean,1),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sJiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoXiaoPingJia", OleDbType.VarChar,255),
					new OleDbParameter("@sFangLiaoFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sFangLiaoLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@bShuQian2thBingJian", OleDbType.Boolean,1),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@bXinFuZhuFangLiao", OleDbType.Boolean,1),
					new OleDbParameter("@iUserID", OleDbType.Integer,4)};
			parameters[0].Value = model.sBianMa;
			parameters[1].Value = model.bXinFuZhu;
			parameters[2].Value = model.sZhuYuanHao;
			parameters[3].Value = model.sFangAn;
			parameters[4].Value = model.sJiLiang;
			parameters[5].Value = model.sLiaoCheng;
			parameters[6].Value = model.sLiaoXiaoPingJia;
			parameters[7].Value = model.sFangLiaoFangAn;
			parameters[8].Value = model.sFangLiaoLiaoCheng;
			parameters[9].Value = model.bShuQian2thBingJian;
			parameters[10].Value = model.sResult;
			parameters[11].Value = model.bXinFuZhuFangLiao;
			parameters[12].Value = model.iUserID;

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
			strSql.Append("sBianMa=@sBianMa,");
			strSql.Append("bXinFuZhu=@bXinFuZhu,");
			strSql.Append("sZhuYuanHao=@sZhuYuanHao,");
			strSql.Append("sFangAn=@sFangAn,");
			strSql.Append("sJiLiang=@sJiLiang,");
			strSql.Append("sLiaoCheng=@sLiaoCheng,");
			strSql.Append("sLiaoXiaoPingJia=@sLiaoXiaoPingJia,");
			strSql.Append("sFangLiaoFangAn=@sFangLiaoFangAn,");
			strSql.Append("sFangLiaoLiaoCheng=@sFangLiaoLiaoCheng,");
			strSql.Append("bShuQian2thBingJian=@bShuQian2thBingJian,");
			strSql.Append("sResult=@sResult,");
			strSql.Append("bXinFuZhuFangLiao=@bXinFuZhuFangLiao,");
			strSql.Append("iUserID=@iUserID");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@bXinFuZhu", OleDbType.Boolean,1),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@sFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sJiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoXiaoPingJia", OleDbType.VarChar,255),
					new OleDbParameter("@sFangLiaoFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sFangLiaoLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@bShuQian2thBingJian", OleDbType.Boolean,1),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@bXinFuZhuFangLiao", OleDbType.Boolean,1),
					new OleDbParameter("@iUserID", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.sBianMa;
			parameters[1].Value = model.bXinFuZhu;
			parameters[2].Value = model.sZhuYuanHao;
			parameters[3].Value = model.sFangAn;
			parameters[4].Value = model.sJiLiang;
			parameters[5].Value = model.sLiaoCheng;
			parameters[6].Value = model.sLiaoXiaoPingJia;
			parameters[7].Value = model.sFangLiaoFangAn;
			parameters[8].Value = model.sFangLiaoLiaoCheng;
			parameters[9].Value = model.bShuQian2thBingJian;
			parameters[10].Value = model.sResult;
			parameters[11].Value = model.bXinFuZhuFangLiao;
			parameters[12].Value = model.iUserID;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from s2XinFuZhu ");
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
			strSql.Append("delete from s2XinFuZhu ");
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
		public Maticsoft.Model.s2XinFuZhu GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianMa,bXinFuZhu,sZhuYuanHao,sFangAn,sJiLiang,sLiaoCheng,sLiaoXiaoPingJia,sFangLiaoFangAn,sFangLiaoLiaoCheng,bShuQian2thBingJian,sResult,bXinFuZhuFangLiao,iUserID from s2XinFuZhu ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

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
				if(row["sLiaoXiaoPingJia"]!=null)
				{
					model.sLiaoXiaoPingJia=row["sLiaoXiaoPingJia"].ToString();
				}
				if(row["sFangLiaoFangAn"]!=null)
				{
					model.sFangLiaoFangAn=row["sFangLiaoFangAn"].ToString();
				}
				if(row["sFangLiaoLiaoCheng"]!=null)
				{
					model.sFangLiaoLiaoCheng=row["sFangLiaoLiaoCheng"].ToString();
				}
				if(row["bShuQian2thBingJian"]!=null && row["bShuQian2thBingJian"].ToString()!="")
				{
					if((row["bShuQian2thBingJian"].ToString()=="1")||(row["bShuQian2thBingJian"].ToString().ToLower()=="true"))
					{
						model.bShuQian2thBingJian=true;
					}
					else
					{
						model.bShuQian2thBingJian=false;
					}
				}
				if(row["sResult"]!=null)
				{
					model.sResult=row["sResult"].ToString();
				}
				if(row["bXinFuZhuFangLiao"]!=null && row["bXinFuZhuFangLiao"].ToString()!="")
				{
					if((row["bXinFuZhuFangLiao"].ToString()=="1")||(row["bXinFuZhuFangLiao"].ToString().ToLower()=="true"))
					{
						model.bXinFuZhuFangLiao=true;
					}
					else
					{
						model.bXinFuZhuFangLiao=false;
					}
				}
				if(row["iUserID"]!=null && row["iUserID"].ToString()!="")
				{
					model.iUserID=int.Parse(row["iUserID"].ToString());
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
			strSql.Append("select ID,sBianMa,bXinFuZhu,sZhuYuanHao,sFangAn,sJiLiang,sLiaoCheng,sLiaoXiaoPingJia,sFangLiaoFangAn,sFangLiaoLiaoCheng,bShuQian2thBingJian,sResult,bXinFuZhuFangLiao,iUserID ");
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
				strSql.Append("order by T.ID desc");
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

