/**  版本信息模板在安装目录下，可自行修改。
* s3ShuHouFuZhu.cs
*
* 功 能： N/A
* 类 名： s3ShuHouFuZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/22 19:46:15   N/A    初版
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
	/// 数据访问类:s3ShuHouFuZhu
	/// </summary>
	public partial class s3ShuHouFuZhu
	{
       private AccessHelper DbHelperOleDb;
       public s3ShuHouFuZhu(string dbPath)
       {
            DbHelperOleDb = new AccessHelper(dbPath);
       }
		public s3ShuHouFuZhu()
       {
            DbHelperOleDb = new AccessHelper();
       }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "s3ShuHouFuZhu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s3ShuHouFuZhu");
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
		public bool Add(Maticsoft.Model.s3ShuHouFuZhu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s3ShuHouFuZhu(");
			strSql.Append("sBianMa,bFuZhuHuaLiao,sZhouQi,sFangAn,sTiBiaoMianJi,sShiJiJiLiang,sWBC,sHb,sPLT,sBMI,sNRS2002,sECOG,bFuCha,sCT,sMRI,sNeiJing,sPET,bFuFa,sWeiZhi,sChuliFangShi,sjiLiang,sLiaoCheng,sLiaoXiaoPingFen,iUserID,sZhuYuanHao,bBaXiangYaoWu,sYaoWuPinZhong,sJianCeResult)");
			strSql.Append(" values (");
			strSql.Append("@sBianMa,@bFuZhuHuaLiao,@sZhouQi,@sFangAn,@sTiBiaoMianJi,@sShiJiJiLiang,@sWBC,@sHb,@sPLT,@sBMI,@sNRS2002,@sECOG,@bFuCha,@sCT,@sMRI,@sNeiJing,@sPET,@bFuFa,@sWeiZhi,@sChuliFangShi,@sjiLiang,@sLiaoCheng,@sLiaoXiaoPingFen,@iUserID,@sZhuYuanHao,@bBaXiangYaoWu,@sYaoWuPinZhong,@sJianCeResult)");
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
					new OleDbParameter("@sECOG", OleDbType.VarChar,255),
					new OleDbParameter("@bFuCha", OleDbType.Boolean,1),
					new OleDbParameter("@sCT", OleDbType.VarChar,255),
					new OleDbParameter("@sMRI", OleDbType.VarChar,255),
					new OleDbParameter("@sNeiJing", OleDbType.VarChar,255),
					new OleDbParameter("@sPET", OleDbType.VarChar,255),
					new OleDbParameter("@bFuFa", OleDbType.Boolean,1),
					new OleDbParameter("@sWeiZhi", OleDbType.VarChar,255),
					new OleDbParameter("@sChuliFangShi", OleDbType.VarChar,255),
					new OleDbParameter("@sjiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoXiaoPingFen", OleDbType.VarChar,255),
					new OleDbParameter("@iUserID", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@bBaXiangYaoWu", OleDbType.Boolean,1),
					new OleDbParameter("@sYaoWuPinZhong", OleDbType.VarChar,255),
					new OleDbParameter("@sJianCeResult", OleDbType.VarChar,255)};
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
			parameters[11].Value = model.sECOG;
			parameters[12].Value = model.bFuCha;
			parameters[13].Value = model.sCT;
			parameters[14].Value = model.sMRI;
			parameters[15].Value = model.sNeiJing;
			parameters[16].Value = model.sPET;
			parameters[17].Value = model.bFuFa;
			parameters[18].Value = model.sWeiZhi;
			parameters[19].Value = model.sChuliFangShi;
			parameters[20].Value = model.sjiLiang;
			parameters[21].Value = model.sLiaoCheng;
			parameters[22].Value = model.sLiaoXiaoPingFen;
			parameters[23].Value = model.iUserID;
			parameters[24].Value = model.sZhuYuanHao;
			parameters[25].Value = model.bBaXiangYaoWu;
			parameters[26].Value = model.sYaoWuPinZhong;
			parameters[27].Value = model.sJianCeResult;

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
			strSql.Append("sBianMa=@sBianMa,");
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
			strSql.Append("sECOG=@sECOG,");
			strSql.Append("bFuCha=@bFuCha,");
			strSql.Append("sCT=@sCT,");
			strSql.Append("sMRI=@sMRI,");
			strSql.Append("sNeiJing=@sNeiJing,");
			strSql.Append("sPET=@sPET,");
			strSql.Append("bFuFa=@bFuFa,");
			strSql.Append("sWeiZhi=@sWeiZhi,");
			strSql.Append("sChuliFangShi=@sChuliFangShi,");
			strSql.Append("sjiLiang=@sjiLiang,");
			strSql.Append("sLiaoCheng=@sLiaoCheng,");
			strSql.Append("sLiaoXiaoPingFen=@sLiaoXiaoPingFen,");
			strSql.Append("iUserID=@iUserID,");
			strSql.Append("sZhuYuanHao=@sZhuYuanHao,");
			strSql.Append("bBaXiangYaoWu=@bBaXiangYaoWu,");
			strSql.Append("sYaoWuPinZhong=@sYaoWuPinZhong,");
			strSql.Append("sJianCeResult=@sJianCeResult");
			strSql.Append(" where ID=@ID");
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
					new OleDbParameter("@sECOG", OleDbType.VarChar,255),
					new OleDbParameter("@bFuCha", OleDbType.Boolean,1),
					new OleDbParameter("@sCT", OleDbType.VarChar,255),
					new OleDbParameter("@sMRI", OleDbType.VarChar,255),
					new OleDbParameter("@sNeiJing", OleDbType.VarChar,255),
					new OleDbParameter("@sPET", OleDbType.VarChar,255),
					new OleDbParameter("@bFuFa", OleDbType.Boolean,1),
					new OleDbParameter("@sWeiZhi", OleDbType.VarChar,255),
					new OleDbParameter("@sChuliFangShi", OleDbType.VarChar,255),
					new OleDbParameter("@sjiLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoCheng", OleDbType.VarChar,255),
					new OleDbParameter("@sLiaoXiaoPingFen", OleDbType.VarChar,255),
					new OleDbParameter("@iUserID", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuYuanHao", OleDbType.VarChar,255),
					new OleDbParameter("@bBaXiangYaoWu", OleDbType.Boolean,1),
					new OleDbParameter("@sYaoWuPinZhong", OleDbType.VarChar,255),
					new OleDbParameter("@sJianCeResult", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
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
			parameters[11].Value = model.sECOG;
			parameters[12].Value = model.bFuCha;
			parameters[13].Value = model.sCT;
			parameters[14].Value = model.sMRI;
			parameters[15].Value = model.sNeiJing;
			parameters[16].Value = model.sPET;
			parameters[17].Value = model.bFuFa;
			parameters[18].Value = model.sWeiZhi;
			parameters[19].Value = model.sChuliFangShi;
			parameters[20].Value = model.sjiLiang;
			parameters[21].Value = model.sLiaoCheng;
			parameters[22].Value = model.sLiaoXiaoPingFen;
			parameters[23].Value = model.iUserID;
			parameters[24].Value = model.sZhuYuanHao;
			parameters[25].Value = model.bBaXiangYaoWu;
			parameters[26].Value = model.sYaoWuPinZhong;
			parameters[27].Value = model.sJianCeResult;
			parameters[28].Value = model.ID;

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
			strSql.Append("delete from s3ShuHouFuZhu ");
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
			strSql.Append("delete from s3ShuHouFuZhu ");
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
		public Maticsoft.Model.s3ShuHouFuZhu GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianMa,bFuZhuHuaLiao,sZhouQi,sFangAn,sTiBiaoMianJi,sShiJiJiLiang,sWBC,sHb,sPLT,sBMI,sNRS2002,sECOG,bFuCha,sCT,sMRI,sNeiJing,sPET,bFuFa,sWeiZhi,sChuliFangShi,sjiLiang,sLiaoCheng,sLiaoXiaoPingFen,iUserID,sZhuYuanHao,bBaXiangYaoWu,sYaoWuPinZhong,sJianCeResult from s3ShuHouFuZhu ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

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
				if(row["sECOG"]!=null)
				{
					model.sECOG=row["sECOG"].ToString();
				}
				if(row["bFuCha"]!=null && row["bFuCha"].ToString()!="")
				{
					if((row["bFuCha"].ToString()=="1")||(row["bFuCha"].ToString().ToLower()=="true"))
					{
						model.bFuCha=true;
					}
					else
					{
						model.bFuCha=false;
					}
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
				if(row["iUserID"]!=null)
				{
					model.iUserID=row["iUserID"].ToString();
				}
				if(row["sZhuYuanHao"]!=null)
				{
					model.sZhuYuanHao=row["sZhuYuanHao"].ToString();
				}
				if(row["bBaXiangYaoWu"]!=null && row["bBaXiangYaoWu"].ToString()!="")
				{
					if((row["bBaXiangYaoWu"].ToString()=="1")||(row["bBaXiangYaoWu"].ToString().ToLower()=="true"))
					{
						model.bBaXiangYaoWu=true;
					}
					else
					{
						model.bBaXiangYaoWu=false;
					}
				}
				if(row["sYaoWuPinZhong"]!=null)
				{
					model.sYaoWuPinZhong=row["sYaoWuPinZhong"].ToString();
				}
				if(row["sJianCeResult"]!=null)
				{
					model.sJianCeResult=row["sJianCeResult"].ToString();
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
			strSql.Append("select ID,sBianMa,bFuZhuHuaLiao,sZhouQi,sFangAn,sTiBiaoMianJi,sShiJiJiLiang,sWBC,sHb,sPLT,sBMI,sNRS2002,sECOG,bFuCha,sCT,sMRI,sNeiJing,sPET,bFuFa,sWeiZhi,sChuliFangShi,sjiLiang,sLiaoCheng,sLiaoXiaoPingFen,iUserID,sZhuYuanHao,bBaXiangYaoWu,sYaoWuPinZhong,sJianCeResult ");
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
				strSql.Append("order by T.ID desc");
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

