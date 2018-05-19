/**  版本信息模板在安装目录下，可自行修改。
* s3ShuHouFuZhu.cs
*
* 功 能： N/A
* 类 名： s3ShuHouFuZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 12:22:48   N/A    初版
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
	/// 数据访问类:s3ShuHouFuZhu
	/// </summary>
	public partial class s3ShuHouFuZhu
	{
		AccessHelper DbHelperOleDb = new AccessHelper();

		public s3ShuHouFuZhu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sBianMa)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s3ShuHouFuZhu");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianMa;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.s3ShuHouFuZhu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s3ShuHouFuZhu(");
			strSql.Append("sBianMa,bFuZhuHuaLiao,sZhouQi,sFangAn,sTiBiaoMianJi,sShiJiJiLiang,sWBC,sHb,sPLT,sBMI,sNRS2002,sFCOG,bFuFa,sWeiZhi,sChuliFangShi,sjiLiang,sLiaoCheng,sLiaoXiaoPingFen)");
			strSql.Append(" values (");
			strSql.Append("@sBianMa,@bFuZhuHuaLiao,@sZhouQi,@sFangAn,@sTiBiaoMianJi,@sShiJiJiLiang,@sWBC,@sHb,@sPLT,@sBMI,@sNRS2002,@sFCOG,@bFuFa,@sWeiZhi,@sChuliFangShi,@sjiLiang,@sLiaoCheng,@sLiaoXiaoPingFen)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255),
					new OleDbParameter("@bFuZhuHuaLiao", OleDbType.Boolean,1),
					new OleDbParameter("@sZhouQi", OleDbType.VarChar,255),
					new OleDbParameter("@sFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sTiBiaoMianJi", OleDbType.VarChar,255),
					new OleDbParameter("@sShiJiJiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sWBC", OleDbType.VarChar,255),
					new OleDbParameter("@sHb", OleDbType.VarChar,255),
					new OleDbParameter("@sPLT", OleDbType.VarChar,255),
					new OleDbParameter("@sBMI", OleDbType.VarChar,255),
					new OleDbParameter("@sNRS2002", OleDbType.VarChar,255),
					new OleDbParameter("@sFCOG", OleDbType.VarChar,255),
					new OleDbParameter("@bFuFa", OleDbType.Boolean,1),
					new OleDbParameter("@sWeiZhi", OleDbType.VarChar,255),
					new OleDbParameter("@sChuliFangShi", OleDbType.VarChar,255),
					new OleDbParameter("@sjiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoXiaoPingFen", OleDbType.VarChar,255)};
			parameters[0].Value = model.sBianMa;
			parameters[1].Value = model.bFuZhuHuaLiao;
			parameters[2].Value = model.sZhouQi;
			parameters[3].Value = model.sFangAn;
			parameters[4].Value = model.sTiBiaoMianJi;
			parameters[5].Value = model.sShiJiJiLiang;
			parameters[6].Value = model.sWBC;
			parameters[7].Value = model.sHb;
			parameters[8].Value = model.sPLT;
			parameters[9].Value = model.sBMI;
			parameters[10].Value = model.sNRS2002;
			parameters[11].Value = model.sFCOG;
			parameters[12].Value = model.bFuFa;
			parameters[13].Value = model.sWeiZhi;
			parameters[14].Value = model.sChuliFangShi;
			parameters[15].Value = model.sjiLiang;
			parameters[16].Value = model.sLiaoCheng;
			parameters[17].Value = model.sLiaoXiaoPingFen;

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
		public bool Update(Maticsoft.Model.s3ShuHouFuZhu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update s3ShuHouFuZhu set ");
			strSql.Append("bFuZhuHuaLiao=@bFuZhuHuaLiao,");
			strSql.Append("sZhouQi=@sZhouQi,");
			strSql.Append("sFangAn=@sFangAn,");
			strSql.Append("sTiBiaoMianJi=@sTiBiaoMianJi,");
			strSql.Append("sShiJiJiLiang=@sShiJiJiLiang,");
			strSql.Append("sWBC=@sWBC,");
			strSql.Append("sHb=@sHb,");
			strSql.Append("sPLT=@sPLT,");
			strSql.Append("sBMI=@sBMI,");
			strSql.Append("sNRS2002=@sNRS2002,");
			strSql.Append("sFCOG=@sFCOG,");
			strSql.Append("bFuFa=@bFuFa,");
			strSql.Append("sWeiZhi=@sWeiZhi,");
			strSql.Append("sChuliFangShi=@sChuliFangShi,");
			strSql.Append("sjiLiang=@sjiLiang,");
			strSql.Append("sLiaoCheng=@sLiaoCheng,");
			strSql.Append("sLiaoXiaoPingFen=@sLiaoXiaoPingFen");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@bFuZhuHuaLiao", OleDbType.Boolean,1),
					new OleDbParameter("@sZhouQi", OleDbType.VarChar,255),
					new OleDbParameter("@sFangAn", OleDbType.VarChar,255),
					new OleDbParameter("@sTiBiaoMianJi", OleDbType.VarChar,255),
					new OleDbParameter("@sShiJiJiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sWBC", OleDbType.VarChar,255),
					new OleDbParameter("@sHb", OleDbType.VarChar,255),
					new OleDbParameter("@sPLT", OleDbType.VarChar,255),
					new OleDbParameter("@sBMI", OleDbType.VarChar,255),
					new OleDbParameter("@sNRS2002", OleDbType.VarChar,255),
					new OleDbParameter("@sFCOG", OleDbType.VarChar,255),
					new OleDbParameter("@bFuFa", OleDbType.Boolean,1),
					new OleDbParameter("@sWeiZhi", OleDbType.VarChar,255),
					new OleDbParameter("@sChuliFangShi", OleDbType.VarChar,255),
					new OleDbParameter("@sjiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoXiaoPingFen", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)};
			parameters[0].Value = model.bFuZhuHuaLiao;
			parameters[1].Value = model.sZhouQi;
			parameters[2].Value = model.sFangAn;
			parameters[3].Value = model.sTiBiaoMianJi;
			parameters[4].Value = model.sShiJiJiLiang;
			parameters[5].Value = model.sWBC;
			parameters[6].Value = model.sHb;
			parameters[7].Value = model.sPLT;
			parameters[8].Value = model.sBMI;
			parameters[9].Value = model.sNRS2002;
			parameters[10].Value = model.sFCOG;
			parameters[11].Value = model.bFuFa;
			parameters[12].Value = model.sWeiZhi;
			parameters[13].Value = model.sChuliFangShi;
			parameters[14].Value = model.sjiLiang;
			parameters[15].Value = model.sLiaoCheng;
			parameters[16].Value = model.sLiaoXiaoPingFen;
			parameters[17].Value = model.ID;
			parameters[18].Value = model.sBianMa;

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
			strSql.Append("delete from s3ShuHouFuZhu ");
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
			strSql.Append("delete from s3ShuHouFuZhu ");
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
		public Maticsoft.Model.s3ShuHouFuZhu GetModel(string sBianMa)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianMa,bFuZhuHuaLiao,sZhouQi,sFangAn,sTiBiaoMianJi,sShiJiJiLiang,sWBC,sHb,sPLT,sBMI,sNRS2002,sFCOG,bFuFa,sWeiZhi,sChuliFangShi,sjiLiang,sLiaoCheng,sLiaoXiaoPingFen from s3ShuHouFuZhu ");
			strSql.Append(" where sBianMa=@sBianMa ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianMa", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianMa;

			Maticsoft.Model.s3ShuHouFuZhu model=new Maticsoft.Model.s3ShuHouFuZhu();
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
		public Maticsoft.Model.s3ShuHouFuZhu DataRowToModel(DataRow row)
		{
			Maticsoft.Model.s3ShuHouFuZhu model=new Maticsoft.Model.s3ShuHouFuZhu();
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
				if(row["bFuZhuHuaLiao"]!=null && row["bFuZhuHuaLiao"].ToString()!="")
				{
					if((row["bFuZhuHuaLiao"].ToString()=="1")||(row["bFuZhuHuaLiao"].ToString().ToLower()=="true"))
					{
						model.bFuZhuHuaLiao=true;
					}
					else
					{
						model.bFuZhuHuaLiao=false;
					}
				}
				if(row["sZhouQi"]!=null)
				{
					model.sZhouQi=row["sZhouQi"].ToString();
				}
				if(row["sFangAn"]!=null)
				{
					model.sFangAn=row["sFangAn"].ToString();
				}
				if(row["sTiBiaoMianJi"]!=null)
				{
					model.sTiBiaoMianJi=row["sTiBiaoMianJi"].ToString();
				}
				if(row["sShiJiJiLiang"]!=null)
				{
					model.sShiJiJiLiang=row["sShiJiJiLiang"].ToString();
				}
				if(row["sWBC"]!=null)
				{
					model.sWBC=row["sWBC"].ToString();
				}
				if(row["sHb"]!=null)
				{
					model.sHb=row["sHb"].ToString();
				}
				if(row["sPLT"]!=null)
				{
					model.sPLT=row["sPLT"].ToString();
				}
				if(row["sBMI"]!=null)
				{
					model.sBMI=row["sBMI"].ToString();
				}
				if(row["sNRS2002"]!=null)
				{
					model.sNRS2002=row["sNRS2002"].ToString();
				}
				if(row["sFCOG"]!=null)
				{
					model.sFCOG=row["sFCOG"].ToString();
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
				if(row["sWeiZhi"]!=null)
				{
					model.sWeiZhi=row["sWeiZhi"].ToString();
				}
				if(row["sChuliFangShi"]!=null)
				{
					model.sChuliFangShi=row["sChuliFangShi"].ToString();
				}
				if(row["sjiLiang"]!=null)
				{
					model.sjiLiang=row["sjiLiang"].ToString();
				}
				if(row["sLiaoCheng"]!=null)
				{
					model.sLiaoCheng=row["sLiaoCheng"].ToString();
				}
				if(row["sLiaoXiaoPingFen"]!=null)
				{
					model.sLiaoXiaoPingFen=row["sLiaoXiaoPingFen"].ToString();
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
			strSql.Append("select ID,sBianMa,bFuZhuHuaLiao,sZhouQi,sFangAn,sTiBiaoMianJi,sShiJiJiLiang,sWBC,sHb,sPLT,sBMI,sNRS2002,sFCOG,bFuFa,sWeiZhi,sChuliFangShi,sjiLiang,sLiaoCheng,sLiaoXiaoPingFen ");
			strSql.Append(" FROM s3ShuHouFuZhu ");
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
			strSql.Append("select count(1) FROM s3ShuHouFuZhu ");
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
			strSql.Append(")AS Row, T.*  from s3ShuHouFuZhu T ");
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
			parameters[0].Value = "s3ShuHouFuZhu";
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

