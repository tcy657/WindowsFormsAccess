/**  版本信息模板在安装目录下，可自行修改。
* s7ShuQianPingGu.cs
*
* 功 能： N/A
* 类 名： s7ShuQianPingGu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 13:33:14   N/A    初版
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
	/// 数据访问类:s7ShuQianPingGu
	/// </summary>
	public partial class s7ShuQianPingGu
	{
		AccessHelper DbHelperOleDb = new AccessHelper();
        public s7ShuQianPingGu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sBianHao)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s7ShuQianPingGu");
			strSql.Append(" where sBianHao=@sBianHao ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianHao;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.s7ShuQianPingGu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s7ShuQianPingGu(");
			strSql.Append("sBianHao,bWoYuanBingJian,sResult,sBingLiHao,bWoYuanCT,sZhongLiuDaXiao,sJuBuQinFang,sLinBaJieZhuanYi,bZhuanYi,sBuWei,bWoYuanMRI,bPET,sDaiXieQiangDu,sLinBaZhuanYi,sZhuanYiBuWeiDaiXieQD,sCT,sCN,sCM,sWBC,sHb,sALB,sCEA,sCA125,sCA199,sCA724,sAFP,bGengZhu,bChuXie,bChuanKong,sBMI,sNRS2002,sTengTongPingFen,sECOG,sXinGongNeng,sFeiGongNeng,sShenGongNeng,sGanGongNeng,sNingXieGongneng,bJiZhenShouShu,dShouShuRiqi,sQiangjingKaiFu,sShuShi,sShouShuTime,dKaiFuWenHeTime,sZhongLiuJuTiWeiZhi,bLianHeQiZhuangQieChu,sChuXieLiang,sFuQiangWuRuan,sFuShenShang,bYingYangGuan,bZaoLou,bShuZhongBingLi,sResult2,sQieChuQingkong,sLinBaJieQingShao,sTeShuShuoMing,bERAS,bICUJianHu,sJianHuTime,dJinShuShiJian,dTongQiTime,dPaiBianTime,dFuTongHuanJieTime,dNiaoGuanBaChuTime,dYinLiuGuanBaChuTime,dXiaChuangTime,dJinShi,dChangNeiYingYang,dChangNeiYingYangZhiChiTime,dTPNtime,sShuHouChuXue,sFuQiangGanRuan,sQieKouGanRuan,sWenHeKouLou,sChangGenZhu,sWeiTan,sFeiBuFanRuan,sDiDanBaiXueZheng,sWEiGuanTuoChu,sYingYangGuanTuoChu,sZaoKouBingFaZheng,s2thShouShu,dShouShuTime,sShouShuFangShi,sJieJueWenTi,sShuHouBingLiZhengDuan,sFenHuaChengDu,sJinRunShenDu,sMaiGuanAiShuan,sShenJingQinFang,sAiJieJie,sZongLinBaJieShu,sZhuanyiLinBaJieShu,sMSI,sHER_2,sP53,sK_RAS,sShouHouBingLiFenQi,sMSIQueZheng,sJiYinJianCe,dChuYuanTime,sChuYuanQingKong,sYiLiaoFeiYong)");
			strSql.Append(" values (");
			strSql.Append("@sBianHao,@bWoYuanBingJian,@sResult,@sBingLiHao,@bWoYuanCT,@sZhongLiuDaXiao,@sJuBuQinFang,@sLinBaJieZhuanYi,@bZhuanYi,@sBuWei,@bWoYuanMRI,@bPET,@sDaiXieQiangDu,@sLinBaZhuanYi,@sZhuanYiBuWeiDaiXieQD,@sCT,@sCN,@sCM,@sWBC,@sHb,@sALB,@sCEA,@sCA125,@sCA199,@sCA724,@sAFP,@bGengZhu,@bChuXie,@bChuanKong,@sBMI,@sNRS2002,@sTengTongPingFen,@sECOG,@sXinGongNeng,@sFeiGongNeng,@sShenGongNeng,@sGanGongNeng,@sNingXieGongneng,@bJiZhenShouShu,@dShouShuRiqi,@sQiangjingKaiFu,@sShuShi,@sShouShuTime,@dKaiFuWenHeTime,@sZhongLiuJuTiWeiZhi,@bLianHeQiZhuangQieChu,@sChuXieLiang,@sFuQiangWuRuan,@sFuShenShang,@bYingYangGuan,@bZaoLou,@bShuZhongBingLi,@sResult2,@sQieChuQingkong,@sLinBaJieQingShao,@sTeShuShuoMing,@bERAS,@bICUJianHu,@sJianHuTime,@dJinShuShiJian,@dTongQiTime,@dPaiBianTime,@dFuTongHuanJieTime,@dNiaoGuanBaChuTime,@dYinLiuGuanBaChuTime,@dXiaChuangTime,@dJinShi,@dChangNeiYingYang,@dChangNeiYingYangZhiChiTime,@dTPNtime,@sShuHouChuXue,@sFuQiangGanRuan,@sQieKouGanRuan,@sWenHeKouLou,@sChangGenZhu,@sWeiTan,@sFeiBuFanRuan,@sDiDanBaiXueZheng,@sWEiGuanTuoChu,@sYingYangGuanTuoChu,@sZaoKouBingFaZheng,@s2thShouShu,@dShouShuTime,@sShouShuFangShi,@sJieJueWenTi,@sShuHouBingLiZhengDuan,@sFenHuaChengDu,@sJinRunShenDu,@sMaiGuanAiShuan,@sShenJingQinFang,@sAiJieJie,@sZongLinBaJieShu,@sZhuanyiLinBaJieShu,@sMSI,@sHER_2,@sP53,@sK_RAS,@sShouHouBingLiFenQi,@sMSIQueZheng,@sJiYinJianCe,@dChuYuanTime,@sChuYuanQingKong,@sYiLiaoFeiYong)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255),
					new OleDbParameter("@bWoYuanBingJian", OleDbType.Boolean,1),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@sBingLiHao", OleDbType.VarChar,255),
					new OleDbParameter("@bWoYuanCT", OleDbType.Boolean,1),
					new OleDbParameter("@sZhongLiuDaXiao", OleDbType.VarChar,255),
					new OleDbParameter("@sJuBuQinFang", OleDbType.VarChar,255),
					new OleDbParameter("@sLinBaJieZhuanYi", OleDbType.VarChar,255),
					new OleDbParameter("@bZhuanYi", OleDbType.Boolean,1),
					new OleDbParameter("@sBuWei", OleDbType.VarChar,255),
					new OleDbParameter("@bWoYuanMRI", OleDbType.Boolean,1),
					new OleDbParameter("@bPET", OleDbType.Boolean,1),
					new OleDbParameter("@sDaiXieQiangDu", OleDbType.VarChar,255),
					new OleDbParameter("@sLinBaZhuanYi", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuanYiBuWeiDaiXieQD", OleDbType.VarChar,255),
					new OleDbParameter("@sCT", OleDbType.VarChar,255),
					new OleDbParameter("@sCN", OleDbType.VarChar,255),
					new OleDbParameter("@sCM", OleDbType.VarChar,255),
					new OleDbParameter("@sWBC", OleDbType.VarChar,255),
					new OleDbParameter("@sHb", OleDbType.VarChar,255),
					new OleDbParameter("@sALB", OleDbType.VarChar,255),
					new OleDbParameter("@sCEA", OleDbType.VarChar,255),
					new OleDbParameter("@sCA125", OleDbType.VarChar,255),
					new OleDbParameter("@sCA199", OleDbType.VarChar,255),
					new OleDbParameter("@sCA724", OleDbType.VarChar,255),
					new OleDbParameter("@sAFP", OleDbType.VarChar,255),
					new OleDbParameter("@bGengZhu", OleDbType.Boolean,1),
					new OleDbParameter("@bChuXie", OleDbType.Boolean,1),
					new OleDbParameter("@bChuanKong", OleDbType.Boolean,1),
					new OleDbParameter("@sBMI", OleDbType.VarChar,255),
					new OleDbParameter("@sNRS2002", OleDbType.VarChar,255),
					new OleDbParameter("@sTengTongPingFen", OleDbType.VarChar,255),
					new OleDbParameter("@sECOG", OleDbType.VarChar,255),
					new OleDbParameter("@sXinGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sFeiGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sShenGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sGanGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sNingXieGongneng", OleDbType.VarChar,255),
					new OleDbParameter("@bJiZhenShouShu", OleDbType.Boolean,1),
					new OleDbParameter("@dShouShuRiqi", OleDbType.Date),
					new OleDbParameter("@sQiangjingKaiFu", OleDbType.VarChar,255),
					new OleDbParameter("@sShuShi", OleDbType.VarChar,255),
					new OleDbParameter("@sShouShuTime", OleDbType.VarChar,255),
					new OleDbParameter("@dKaiFuWenHeTime", OleDbType.Date),
					new OleDbParameter("@sZhongLiuJuTiWeiZhi", OleDbType.VarChar,255),
					new OleDbParameter("@bLianHeQiZhuangQieChu", OleDbType.Boolean,1),
					new OleDbParameter("@sChuXieLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sFuQiangWuRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sFuShenShang", OleDbType.VarChar,255),
					new OleDbParameter("@bYingYangGuan", OleDbType.Boolean,1),
					new OleDbParameter("@bZaoLou", OleDbType.Boolean,1),
					new OleDbParameter("@bShuZhongBingLi", OleDbType.Boolean,1),
					new OleDbParameter("@sResult2", OleDbType.VarChar,255),
					new OleDbParameter("@sQieChuQingkong", OleDbType.VarChar,255),
					new OleDbParameter("@sLinBaJieQingShao", OleDbType.VarChar,255),
					new OleDbParameter("@sTeShuShuoMing", OleDbType.VarChar,255),
					new OleDbParameter("@bERAS", OleDbType.Boolean,1),
					new OleDbParameter("@bICUJianHu", OleDbType.Boolean,1),
					new OleDbParameter("@sJianHuTime", OleDbType.VarChar,255),
					new OleDbParameter("@dJinShuShiJian", OleDbType.Date),
					new OleDbParameter("@dTongQiTime", OleDbType.Date),
					new OleDbParameter("@dPaiBianTime", OleDbType.Date),
					new OleDbParameter("@dFuTongHuanJieTime", OleDbType.Date),
					new OleDbParameter("@dNiaoGuanBaChuTime", OleDbType.Date),
					new OleDbParameter("@dYinLiuGuanBaChuTime", OleDbType.Date),
					new OleDbParameter("@dXiaChuangTime", OleDbType.Date),
					new OleDbParameter("@dJinShi", OleDbType.Date),
					new OleDbParameter("@dChangNeiYingYang", OleDbType.Date),
					new OleDbParameter("@dChangNeiYingYangZhiChiTime", OleDbType.Date),
					new OleDbParameter("@dTPNtime", OleDbType.Date),
					new OleDbParameter("@sShuHouChuXue", OleDbType.VarChar,255),
					new OleDbParameter("@sFuQiangGanRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sQieKouGanRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sWenHeKouLou", OleDbType.VarChar,255),
					new OleDbParameter("@sChangGenZhu", OleDbType.VarChar,255),
					new OleDbParameter("@sWeiTan", OleDbType.VarChar,255),
					new OleDbParameter("@sFeiBuFanRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sDiDanBaiXueZheng", OleDbType.VarChar,255),
					new OleDbParameter("@sWEiGuanTuoChu", OleDbType.VarChar,255),
					new OleDbParameter("@sYingYangGuanTuoChu", OleDbType.VarChar,255),
					new OleDbParameter("@sZaoKouBingFaZheng", OleDbType.VarChar,255),
					new OleDbParameter("@s2thShouShu", OleDbType.VarChar,255),
					new OleDbParameter("@dShouShuTime", OleDbType.Boolean,1),
					new OleDbParameter("@sShouShuFangShi", OleDbType.VarChar,255),
					new OleDbParameter("@sJieJueWenTi", OleDbType.VarChar,255),
					new OleDbParameter("@sShuHouBingLiZhengDuan", OleDbType.VarChar,255),
					new OleDbParameter("@sFenHuaChengDu", OleDbType.VarChar,255),
					new OleDbParameter("@sJinRunShenDu", OleDbType.VarChar,255),
					new OleDbParameter("@sMaiGuanAiShuan", OleDbType.VarChar,255),
					new OleDbParameter("@sShenJingQinFang", OleDbType.VarChar,255),
					new OleDbParameter("@sAiJieJie", OleDbType.VarChar,255),
					new OleDbParameter("@sZongLinBaJieShu", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuanyiLinBaJieShu", OleDbType.VarChar,255),
					new OleDbParameter("@sMSI", OleDbType.VarChar,255),
					new OleDbParameter("@sHER_2", OleDbType.VarChar,255),
					new OleDbParameter("@sP53", OleDbType.VarChar,255),
					new OleDbParameter("@sK_RAS", OleDbType.VarChar,255),
					new OleDbParameter("@sShouHouBingLiFenQi", OleDbType.VarChar,255),
					new OleDbParameter("@sMSIQueZheng", OleDbType.VarChar,255),
					new OleDbParameter("@sJiYinJianCe", OleDbType.VarChar,255),
					new OleDbParameter("@dChuYuanTime", OleDbType.Date),
					new OleDbParameter("@sChuYuanQingKong", OleDbType.VarChar,255),
					new OleDbParameter("@sYiLiaoFeiYong", OleDbType.VarChar,255)};
			parameters[0].Value = model.sBianHao;
			parameters[1].Value = model.bWoYuanBingJian;
			parameters[2].Value = model.sResult;
			parameters[3].Value = model.sBingLiHao;
			parameters[4].Value = model.bWoYuanCT;
			parameters[5].Value = model.sZhongLiuDaXiao;
			parameters[6].Value = model.sJuBuQinFang;
			parameters[7].Value = model.sLinBaJieZhuanYi;
			parameters[8].Value = model.bZhuanYi;
			parameters[9].Value = model.sBuWei;
			parameters[10].Value = model.bWoYuanMRI;
			parameters[11].Value = model.bPET;
			parameters[12].Value = model.sDaiXieQiangDu;
			parameters[13].Value = model.sLinBaZhuanYi;
			parameters[14].Value = model.sZhuanYiBuWeiDaiXieQD;
			parameters[15].Value = model.sCT;
			parameters[16].Value = model.sCN;
			parameters[17].Value = model.sCM;
			parameters[18].Value = model.sWBC;
			parameters[19].Value = model.sHb;
			parameters[20].Value = model.sALB;
			parameters[21].Value = model.sCEA;
			parameters[22].Value = model.sCA125;
			parameters[23].Value = model.sCA199;
			parameters[24].Value = model.sCA724;
			parameters[25].Value = model.sAFP;
			parameters[26].Value = model.bGengZhu;
			parameters[27].Value = model.bChuXie;
			parameters[28].Value = model.bChuanKong;
			parameters[29].Value = model.sBMI;
			parameters[30].Value = model.sNRS2002;
			parameters[31].Value = model.sTengTongPingFen;
			parameters[32].Value = model.sECOG;
			parameters[33].Value = model.sXinGongNeng;
			parameters[34].Value = model.sFeiGongNeng;
			parameters[35].Value = model.sShenGongNeng;
			parameters[36].Value = model.sGanGongNeng;
			parameters[37].Value = model.sNingXieGongneng;
			parameters[38].Value = model.bJiZhenShouShu;
			parameters[39].Value = model.dShouShuRiqi;
			parameters[40].Value = model.sQiangjingKaiFu;
			parameters[41].Value = model.sShuShi;
			parameters[42].Value = model.sShouShuTime;
			parameters[43].Value = model.dKaiFuWenHeTime;
			parameters[44].Value = model.sZhongLiuJuTiWeiZhi;
			parameters[45].Value = model.bLianHeQiZhuangQieChu;
			parameters[46].Value = model.sChuXieLiang;
			parameters[47].Value = model.sFuQiangWuRuan;
			parameters[48].Value = model.sFuShenShang;
			parameters[49].Value = model.bYingYangGuan;
			parameters[50].Value = model.bZaoLou;
			parameters[51].Value = model.bShuZhongBingLi;
			parameters[52].Value = model.sResult2;
			parameters[53].Value = model.sQieChuQingkong;
			parameters[54].Value = model.sLinBaJieQingShao;
			parameters[55].Value = model.sTeShuShuoMing;
			parameters[56].Value = model.bERAS;
			parameters[57].Value = model.bICUJianHu;
			parameters[58].Value = model.sJianHuTime;
			parameters[59].Value = model.dJinShuShiJian;
			parameters[60].Value = model.dTongQiTime;
			parameters[61].Value = model.dPaiBianTime;
			parameters[62].Value = model.dFuTongHuanJieTime;
			parameters[63].Value = model.dNiaoGuanBaChuTime;
			parameters[64].Value = model.dYinLiuGuanBaChuTime;
			parameters[65].Value = model.dXiaChuangTime;
			parameters[66].Value = model.dJinShi;
			parameters[67].Value = model.dChangNeiYingYang;
			parameters[68].Value = model.dChangNeiYingYangZhiChiTime;
			parameters[69].Value = model.dTPNtime;
			parameters[70].Value = model.sShuHouChuXue;
			parameters[71].Value = model.sFuQiangGanRuan;
			parameters[72].Value = model.sQieKouGanRuan;
			parameters[73].Value = model.sWenHeKouLou;
			parameters[74].Value = model.sChangGenZhu;
			parameters[75].Value = model.sWeiTan;
			parameters[76].Value = model.sFeiBuFanRuan;
			parameters[77].Value = model.sDiDanBaiXueZheng;
			parameters[78].Value = model.sWEiGuanTuoChu;
			parameters[79].Value = model.sYingYangGuanTuoChu;
			parameters[80].Value = model.sZaoKouBingFaZheng;
			parameters[81].Value = model.s2thShouShu;
			parameters[82].Value = model.dShouShuTime;
			parameters[83].Value = model.sShouShuFangShi;
			parameters[84].Value = model.sJieJueWenTi;
			parameters[85].Value = model.sShuHouBingLiZhengDuan;
			parameters[86].Value = model.sFenHuaChengDu;
			parameters[87].Value = model.sJinRunShenDu;
			parameters[88].Value = model.sMaiGuanAiShuan;
			parameters[89].Value = model.sShenJingQinFang;
			parameters[90].Value = model.sAiJieJie;
			parameters[91].Value = model.sZongLinBaJieShu;
			parameters[92].Value = model.sZhuanyiLinBaJieShu;
			parameters[93].Value = model.sMSI;
			parameters[94].Value = model.sHER_2;
			parameters[95].Value = model.sP53;
			parameters[96].Value = model.sK_RAS;
			parameters[97].Value = model.sShouHouBingLiFenQi;
			parameters[98].Value = model.sMSIQueZheng;
			parameters[99].Value = model.sJiYinJianCe;
			parameters[100].Value = model.dChuYuanTime;
			parameters[101].Value = model.sChuYuanQingKong;
			parameters[102].Value = model.sYiLiaoFeiYong;

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
		public bool Update(Maticsoft.Model.s7ShuQianPingGu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update s7ShuQianPingGu set ");
			strSql.Append("bWoYuanBingJian=@bWoYuanBingJian,");
			strSql.Append("sResult=@sResult,");
			strSql.Append("sBingLiHao=@sBingLiHao,");
			strSql.Append("bWoYuanCT=@bWoYuanCT,");
			strSql.Append("sZhongLiuDaXiao=@sZhongLiuDaXiao,");
			strSql.Append("sJuBuQinFang=@sJuBuQinFang,");
			strSql.Append("sLinBaJieZhuanYi=@sLinBaJieZhuanYi,");
			strSql.Append("bZhuanYi=@bZhuanYi,");
			strSql.Append("sBuWei=@sBuWei,");
			strSql.Append("bWoYuanMRI=@bWoYuanMRI,");
			strSql.Append("bPET=@bPET,");
			strSql.Append("sDaiXieQiangDu=@sDaiXieQiangDu,");
			strSql.Append("sLinBaZhuanYi=@sLinBaZhuanYi,");
			strSql.Append("sZhuanYiBuWeiDaiXieQD=@sZhuanYiBuWeiDaiXieQD,");
			strSql.Append("sCT=@sCT,");
			strSql.Append("sCN=@sCN,");
			strSql.Append("sCM=@sCM,");
			strSql.Append("sWBC=@sWBC,");
			strSql.Append("sHb=@sHb,");
			strSql.Append("sALB=@sALB,");
			strSql.Append("sCEA=@sCEA,");
			strSql.Append("sCA125=@sCA125,");
			strSql.Append("sCA199=@sCA199,");
			strSql.Append("sCA724=@sCA724,");
			strSql.Append("sAFP=@sAFP,");
			strSql.Append("bGengZhu=@bGengZhu,");
			strSql.Append("bChuXie=@bChuXie,");
			strSql.Append("bChuanKong=@bChuanKong,");
			strSql.Append("sBMI=@sBMI,");
			strSql.Append("sNRS2002=@sNRS2002,");
			strSql.Append("sTengTongPingFen=@sTengTongPingFen,");
			strSql.Append("sECOG=@sECOG,");
			strSql.Append("sXinGongNeng=@sXinGongNeng,");
			strSql.Append("sFeiGongNeng=@sFeiGongNeng,");
			strSql.Append("sShenGongNeng=@sShenGongNeng,");
			strSql.Append("sGanGongNeng=@sGanGongNeng,");
			strSql.Append("sNingXieGongneng=@sNingXieGongneng,");
			strSql.Append("bJiZhenShouShu=@bJiZhenShouShu,");
			strSql.Append("dShouShuRiqi=@dShouShuRiqi,");
			strSql.Append("sQiangjingKaiFu=@sQiangjingKaiFu,");
			strSql.Append("sShuShi=@sShuShi,");
			strSql.Append("sShouShuTime=@sShouShuTime,");
			strSql.Append("dKaiFuWenHeTime=@dKaiFuWenHeTime,");
			strSql.Append("sZhongLiuJuTiWeiZhi=@sZhongLiuJuTiWeiZhi,");
			strSql.Append("bLianHeQiZhuangQieChu=@bLianHeQiZhuangQieChu,");
			strSql.Append("sChuXieLiang=@sChuXieLiang,");
			strSql.Append("sFuQiangWuRuan=@sFuQiangWuRuan,");
			strSql.Append("sFuShenShang=@sFuShenShang,");
			strSql.Append("bYingYangGuan=@bYingYangGuan,");
			strSql.Append("bZaoLou=@bZaoLou,");
			strSql.Append("bShuZhongBingLi=@bShuZhongBingLi,");
			strSql.Append("sResult2=@sResult2,");
			strSql.Append("sQieChuQingkong=@sQieChuQingkong,");
			strSql.Append("sLinBaJieQingShao=@sLinBaJieQingShao,");
			strSql.Append("sTeShuShuoMing=@sTeShuShuoMing,");
			strSql.Append("bERAS=@bERAS,");
			strSql.Append("bICUJianHu=@bICUJianHu,");
			strSql.Append("sJianHuTime=@sJianHuTime,");
			strSql.Append("dJinShuShiJian=@dJinShuShiJian,");
			strSql.Append("dTongQiTime=@dTongQiTime,");
			strSql.Append("dPaiBianTime=@dPaiBianTime,");
			strSql.Append("dFuTongHuanJieTime=@dFuTongHuanJieTime,");
			strSql.Append("dNiaoGuanBaChuTime=@dNiaoGuanBaChuTime,");
			strSql.Append("dYinLiuGuanBaChuTime=@dYinLiuGuanBaChuTime,");
			strSql.Append("dXiaChuangTime=@dXiaChuangTime,");
			strSql.Append("dJinShi=@dJinShi,");
			strSql.Append("dChangNeiYingYang=@dChangNeiYingYang,");
			strSql.Append("dChangNeiYingYangZhiChiTime=@dChangNeiYingYangZhiChiTime,");
			strSql.Append("dTPNtime=@dTPNtime,");
			strSql.Append("sShuHouChuXue=@sShuHouChuXue,");
			strSql.Append("sFuQiangGanRuan=@sFuQiangGanRuan,");
			strSql.Append("sQieKouGanRuan=@sQieKouGanRuan,");
			strSql.Append("sWenHeKouLou=@sWenHeKouLou,");
			strSql.Append("sChangGenZhu=@sChangGenZhu,");
			strSql.Append("sWeiTan=@sWeiTan,");
			strSql.Append("sFeiBuFanRuan=@sFeiBuFanRuan,");
			strSql.Append("sDiDanBaiXueZheng=@sDiDanBaiXueZheng,");
			strSql.Append("sWEiGuanTuoChu=@sWEiGuanTuoChu,");
			strSql.Append("sYingYangGuanTuoChu=@sYingYangGuanTuoChu,");
			strSql.Append("sZaoKouBingFaZheng=@sZaoKouBingFaZheng,");
			strSql.Append("s2thShouShu=@s2thShouShu,");
			strSql.Append("dShouShuTime=@dShouShuTime,");
			strSql.Append("sShouShuFangShi=@sShouShuFangShi,");
			strSql.Append("sJieJueWenTi=@sJieJueWenTi,");
			strSql.Append("sShuHouBingLiZhengDuan=@sShuHouBingLiZhengDuan,");
			strSql.Append("sFenHuaChengDu=@sFenHuaChengDu,");
			strSql.Append("sJinRunShenDu=@sJinRunShenDu,");
			strSql.Append("sMaiGuanAiShuan=@sMaiGuanAiShuan,");
			strSql.Append("sShenJingQinFang=@sShenJingQinFang,");
			strSql.Append("sAiJieJie=@sAiJieJie,");
			strSql.Append("sZongLinBaJieShu=@sZongLinBaJieShu,");
			strSql.Append("sZhuanyiLinBaJieShu=@sZhuanyiLinBaJieShu,");
			strSql.Append("sMSI=@sMSI,");
			strSql.Append("sHER_2=@sHER_2,");
			strSql.Append("sP53=@sP53,");
			strSql.Append("sK_RAS=@sK_RAS,");
			strSql.Append("sShouHouBingLiFenQi=@sShouHouBingLiFenQi,");
			strSql.Append("sMSIQueZheng=@sMSIQueZheng,");
			strSql.Append("sJiYinJianCe=@sJiYinJianCe,");
			strSql.Append("dChuYuanTime=@dChuYuanTime,");
			strSql.Append("sChuYuanQingKong=@sChuYuanQingKong,");
			strSql.Append("sYiLiaoFeiYong=@sYiLiaoFeiYong");
			strSql.Append(" where sBianHao=@sBianHao ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@bWoYuanBingJian", OleDbType.Boolean,1),
					new OleDbParameter("@sResult", OleDbType.VarChar,255),
					new OleDbParameter("@sBingLiHao", OleDbType.VarChar,255),
					new OleDbParameter("@bWoYuanCT", OleDbType.Boolean,1),
					new OleDbParameter("@sZhongLiuDaXiao", OleDbType.VarChar,255),
					new OleDbParameter("@sJuBuQinFang", OleDbType.VarChar,255),
					new OleDbParameter("@sLinBaJieZhuanYi", OleDbType.VarChar,255),
					new OleDbParameter("@bZhuanYi", OleDbType.Boolean,1),
					new OleDbParameter("@sBuWei", OleDbType.VarChar,255),
					new OleDbParameter("@bWoYuanMRI", OleDbType.Boolean,1),
					new OleDbParameter("@bPET", OleDbType.Boolean,1),
					new OleDbParameter("@sDaiXieQiangDu", OleDbType.VarChar,255),
					new OleDbParameter("@sLinBaZhuanYi", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuanYiBuWeiDaiXieQD", OleDbType.VarChar,255),
					new OleDbParameter("@sCT", OleDbType.VarChar,255),
					new OleDbParameter("@sCN", OleDbType.VarChar,255),
					new OleDbParameter("@sCM", OleDbType.VarChar,255),
					new OleDbParameter("@sWBC", OleDbType.VarChar,255),
					new OleDbParameter("@sHb", OleDbType.VarChar,255),
					new OleDbParameter("@sALB", OleDbType.VarChar,255),
					new OleDbParameter("@sCEA", OleDbType.VarChar,255),
					new OleDbParameter("@sCA125", OleDbType.VarChar,255),
					new OleDbParameter("@sCA199", OleDbType.VarChar,255),
					new OleDbParameter("@sCA724", OleDbType.VarChar,255),
					new OleDbParameter("@sAFP", OleDbType.VarChar,255),
					new OleDbParameter("@bGengZhu", OleDbType.Boolean,1),
					new OleDbParameter("@bChuXie", OleDbType.Boolean,1),
					new OleDbParameter("@bChuanKong", OleDbType.Boolean,1),
					new OleDbParameter("@sBMI", OleDbType.VarChar,255),
					new OleDbParameter("@sNRS2002", OleDbType.VarChar,255),
					new OleDbParameter("@sTengTongPingFen", OleDbType.VarChar,255),
					new OleDbParameter("@sECOG", OleDbType.VarChar,255),
					new OleDbParameter("@sXinGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sFeiGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sShenGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sGanGongNeng", OleDbType.VarChar,255),
					new OleDbParameter("@sNingXieGongneng", OleDbType.VarChar,255),
					new OleDbParameter("@bJiZhenShouShu", OleDbType.Boolean,1),
					new OleDbParameter("@dShouShuRiqi", OleDbType.Date),
					new OleDbParameter("@sQiangjingKaiFu", OleDbType.VarChar,255),
					new OleDbParameter("@sShuShi", OleDbType.VarChar,255),
					new OleDbParameter("@sShouShuTime", OleDbType.VarChar,255),
					new OleDbParameter("@dKaiFuWenHeTime", OleDbType.Date),
					new OleDbParameter("@sZhongLiuJuTiWeiZhi", OleDbType.VarChar,255),
					new OleDbParameter("@bLianHeQiZhuangQieChu", OleDbType.Boolean,1),
					new OleDbParameter("@sChuXieLiang", OleDbType.VarChar,255),
					new OleDbParameter("@sFuQiangWuRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sFuShenShang", OleDbType.VarChar,255),
					new OleDbParameter("@bYingYangGuan", OleDbType.Boolean,1),
					new OleDbParameter("@bZaoLou", OleDbType.Boolean,1),
					new OleDbParameter("@bShuZhongBingLi", OleDbType.Boolean,1),
					new OleDbParameter("@sResult2", OleDbType.VarChar,255),
					new OleDbParameter("@sQieChuQingkong", OleDbType.VarChar,255),
					new OleDbParameter("@sLinBaJieQingShao", OleDbType.VarChar,255),
					new OleDbParameter("@sTeShuShuoMing", OleDbType.VarChar,255),
					new OleDbParameter("@bERAS", OleDbType.Boolean,1),
					new OleDbParameter("@bICUJianHu", OleDbType.Boolean,1),
					new OleDbParameter("@sJianHuTime", OleDbType.VarChar,255),
					new OleDbParameter("@dJinShuShiJian", OleDbType.Date),
					new OleDbParameter("@dTongQiTime", OleDbType.Date),
					new OleDbParameter("@dPaiBianTime", OleDbType.Date),
					new OleDbParameter("@dFuTongHuanJieTime", OleDbType.Date),
					new OleDbParameter("@dNiaoGuanBaChuTime", OleDbType.Date),
					new OleDbParameter("@dYinLiuGuanBaChuTime", OleDbType.Date),
					new OleDbParameter("@dXiaChuangTime", OleDbType.Date),
					new OleDbParameter("@dJinShi", OleDbType.Date),
					new OleDbParameter("@dChangNeiYingYang", OleDbType.Date),
					new OleDbParameter("@dChangNeiYingYangZhiChiTime", OleDbType.Date),
					new OleDbParameter("@dTPNtime", OleDbType.Date),
					new OleDbParameter("@sShuHouChuXue", OleDbType.VarChar,255),
					new OleDbParameter("@sFuQiangGanRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sQieKouGanRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sWenHeKouLou", OleDbType.VarChar,255),
					new OleDbParameter("@sChangGenZhu", OleDbType.VarChar,255),
					new OleDbParameter("@sWeiTan", OleDbType.VarChar,255),
					new OleDbParameter("@sFeiBuFanRuan", OleDbType.VarChar,255),
					new OleDbParameter("@sDiDanBaiXueZheng", OleDbType.VarChar,255),
					new OleDbParameter("@sWEiGuanTuoChu", OleDbType.VarChar,255),
					new OleDbParameter("@sYingYangGuanTuoChu", OleDbType.VarChar,255),
					new OleDbParameter("@sZaoKouBingFaZheng", OleDbType.VarChar,255),
					new OleDbParameter("@s2thShouShu", OleDbType.VarChar,255),
					new OleDbParameter("@dShouShuTime", OleDbType.Boolean,1),
					new OleDbParameter("@sShouShuFangShi", OleDbType.VarChar,255),
					new OleDbParameter("@sJieJueWenTi", OleDbType.VarChar,255),
					new OleDbParameter("@sShuHouBingLiZhengDuan", OleDbType.VarChar,255),
					new OleDbParameter("@sFenHuaChengDu", OleDbType.VarChar,255),
					new OleDbParameter("@sJinRunShenDu", OleDbType.VarChar,255),
					new OleDbParameter("@sMaiGuanAiShuan", OleDbType.VarChar,255),
					new OleDbParameter("@sShenJingQinFang", OleDbType.VarChar,255),
					new OleDbParameter("@sAiJieJie", OleDbType.VarChar,255),
					new OleDbParameter("@sZongLinBaJieShu", OleDbType.VarChar,255),
					new OleDbParameter("@sZhuanyiLinBaJieShu", OleDbType.VarChar,255),
					new OleDbParameter("@sMSI", OleDbType.VarChar,255),
					new OleDbParameter("@sHER_2", OleDbType.VarChar,255),
					new OleDbParameter("@sP53", OleDbType.VarChar,255),
					new OleDbParameter("@sK_RAS", OleDbType.VarChar,255),
					new OleDbParameter("@sShouHouBingLiFenQi", OleDbType.VarChar,255),
					new OleDbParameter("@sMSIQueZheng", OleDbType.VarChar,255),
					new OleDbParameter("@sJiYinJianCe", OleDbType.VarChar,255),
					new OleDbParameter("@dChuYuanTime", OleDbType.Date),
					new OleDbParameter("@sChuYuanQingKong", OleDbType.VarChar,255),
					new OleDbParameter("@sYiLiaoFeiYong", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255)};
			parameters[0].Value = model.bWoYuanBingJian;
			parameters[1].Value = model.sResult;
			parameters[2].Value = model.sBingLiHao;
			parameters[3].Value = model.bWoYuanCT;
			parameters[4].Value = model.sZhongLiuDaXiao;
			parameters[5].Value = model.sJuBuQinFang;
			parameters[6].Value = model.sLinBaJieZhuanYi;
			parameters[7].Value = model.bZhuanYi;
			parameters[8].Value = model.sBuWei;
			parameters[9].Value = model.bWoYuanMRI;
			parameters[10].Value = model.bPET;
			parameters[11].Value = model.sDaiXieQiangDu;
			parameters[12].Value = model.sLinBaZhuanYi;
			parameters[13].Value = model.sZhuanYiBuWeiDaiXieQD;
			parameters[14].Value = model.sCT;
			parameters[15].Value = model.sCN;
			parameters[16].Value = model.sCM;
			parameters[17].Value = model.sWBC;
			parameters[18].Value = model.sHb;
			parameters[19].Value = model.sALB;
			parameters[20].Value = model.sCEA;
			parameters[21].Value = model.sCA125;
			parameters[22].Value = model.sCA199;
			parameters[23].Value = model.sCA724;
			parameters[24].Value = model.sAFP;
			parameters[25].Value = model.bGengZhu;
			parameters[26].Value = model.bChuXie;
			parameters[27].Value = model.bChuanKong;
			parameters[28].Value = model.sBMI;
			parameters[29].Value = model.sNRS2002;
			parameters[30].Value = model.sTengTongPingFen;
			parameters[31].Value = model.sECOG;
			parameters[32].Value = model.sXinGongNeng;
			parameters[33].Value = model.sFeiGongNeng;
			parameters[34].Value = model.sShenGongNeng;
			parameters[35].Value = model.sGanGongNeng;
			parameters[36].Value = model.sNingXieGongneng;
			parameters[37].Value = model.bJiZhenShouShu;
			parameters[38].Value = model.dShouShuRiqi;
			parameters[39].Value = model.sQiangjingKaiFu;
			parameters[40].Value = model.sShuShi;
			parameters[41].Value = model.sShouShuTime;
			parameters[42].Value = model.dKaiFuWenHeTime;
			parameters[43].Value = model.sZhongLiuJuTiWeiZhi;
			parameters[44].Value = model.bLianHeQiZhuangQieChu;
			parameters[45].Value = model.sChuXieLiang;
			parameters[46].Value = model.sFuQiangWuRuan;
			parameters[47].Value = model.sFuShenShang;
			parameters[48].Value = model.bYingYangGuan;
			parameters[49].Value = model.bZaoLou;
			parameters[50].Value = model.bShuZhongBingLi;
			parameters[51].Value = model.sResult2;
			parameters[52].Value = model.sQieChuQingkong;
			parameters[53].Value = model.sLinBaJieQingShao;
			parameters[54].Value = model.sTeShuShuoMing;
			parameters[55].Value = model.bERAS;
			parameters[56].Value = model.bICUJianHu;
			parameters[57].Value = model.sJianHuTime;
			parameters[58].Value = model.dJinShuShiJian;
			parameters[59].Value = model.dTongQiTime;
			parameters[60].Value = model.dPaiBianTime;
			parameters[61].Value = model.dFuTongHuanJieTime;
			parameters[62].Value = model.dNiaoGuanBaChuTime;
			parameters[63].Value = model.dYinLiuGuanBaChuTime;
			parameters[64].Value = model.dXiaChuangTime;
			parameters[65].Value = model.dJinShi;
			parameters[66].Value = model.dChangNeiYingYang;
			parameters[67].Value = model.dChangNeiYingYangZhiChiTime;
			parameters[68].Value = model.dTPNtime;
			parameters[69].Value = model.sShuHouChuXue;
			parameters[70].Value = model.sFuQiangGanRuan;
			parameters[71].Value = model.sQieKouGanRuan;
			parameters[72].Value = model.sWenHeKouLou;
			parameters[73].Value = model.sChangGenZhu;
			parameters[74].Value = model.sWeiTan;
			parameters[75].Value = model.sFeiBuFanRuan;
			parameters[76].Value = model.sDiDanBaiXueZheng;
			parameters[77].Value = model.sWEiGuanTuoChu;
			parameters[78].Value = model.sYingYangGuanTuoChu;
			parameters[79].Value = model.sZaoKouBingFaZheng;
			parameters[80].Value = model.s2thShouShu;
			parameters[81].Value = model.dShouShuTime;
			parameters[82].Value = model.sShouShuFangShi;
			parameters[83].Value = model.sJieJueWenTi;
			parameters[84].Value = model.sShuHouBingLiZhengDuan;
			parameters[85].Value = model.sFenHuaChengDu;
			parameters[86].Value = model.sJinRunShenDu;
			parameters[87].Value = model.sMaiGuanAiShuan;
			parameters[88].Value = model.sShenJingQinFang;
			parameters[89].Value = model.sAiJieJie;
			parameters[90].Value = model.sZongLinBaJieShu;
			parameters[91].Value = model.sZhuanyiLinBaJieShu;
			parameters[92].Value = model.sMSI;
			parameters[93].Value = model.sHER_2;
			parameters[94].Value = model.sP53;
			parameters[95].Value = model.sK_RAS;
			parameters[96].Value = model.sShouHouBingLiFenQi;
			parameters[97].Value = model.sMSIQueZheng;
			parameters[98].Value = model.sJiYinJianCe;
			parameters[99].Value = model.dChuYuanTime;
			parameters[100].Value = model.sChuYuanQingKong;
			parameters[101].Value = model.sYiLiaoFeiYong;
			parameters[102].Value = model.ID;
			parameters[103].Value = model.sBianHao;

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
		public bool Delete(string sBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from s7ShuQianPingGu ");
			strSql.Append(" where sBianHao=@sBianHao ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianHao;

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
		public bool DeleteList(string sBianHaolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from s7ShuQianPingGu ");
			strSql.Append(" where sBianHao in ("+sBianHaolist + ")  ");
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
		public Maticsoft.Model.s7ShuQianPingGu GetModel(string sBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,sBianHao,bWoYuanBingJian,sResult,sBingLiHao,bWoYuanCT,sZhongLiuDaXiao,sJuBuQinFang,sLinBaJieZhuanYi,bZhuanYi,sBuWei,bWoYuanMRI,bPET,sDaiXieQiangDu,sLinBaZhuanYi,sZhuanYiBuWeiDaiXieQD,sCT,sCN,sCM,sWBC,sHb,sALB,sCEA,sCA125,sCA199,sCA724,sAFP,bGengZhu,bChuXie,bChuanKong,sBMI,sNRS2002,sTengTongPingFen,sECOG,sXinGongNeng,sFeiGongNeng,sShenGongNeng,sGanGongNeng,sNingXieGongneng,bJiZhenShouShu,dShouShuRiqi,sQiangjingKaiFu,sShuShi,sShouShuTime,dKaiFuWenHeTime,sZhongLiuJuTiWeiZhi,bLianHeQiZhuangQieChu,sChuXieLiang,sFuQiangWuRuan,sFuShenShang,bYingYangGuan,bZaoLou,bShuZhongBingLi,sResult2,sQieChuQingkong,sLinBaJieQingShao,sTeShuShuoMing,bERAS,bICUJianHu,sJianHuTime,dJinShuShiJian,dTongQiTime,dPaiBianTime,dFuTongHuanJieTime,dNiaoGuanBaChuTime,dYinLiuGuanBaChuTime,dXiaChuangTime,dJinShi,dChangNeiYingYang,dChangNeiYingYangZhiChiTime,dTPNtime,sShuHouChuXue,sFuQiangGanRuan,sQieKouGanRuan,sWenHeKouLou,sChangGenZhu,sWeiTan,sFeiBuFanRuan,sDiDanBaiXueZheng,sWEiGuanTuoChu,sYingYangGuanTuoChu,sZaoKouBingFaZheng,s2thShouShu,dShouShuTime,sShouShuFangShi,sJieJueWenTi,sShuHouBingLiZhengDuan,sFenHuaChengDu,sJinRunShenDu,sMaiGuanAiShuan,sShenJingQinFang,sAiJieJie,sZongLinBaJieShu,sZhuanyiLinBaJieShu,sMSI,sHER_2,sP53,sK_RAS,sShouHouBingLiFenQi,sMSIQueZheng,sJiYinJianCe,dChuYuanTime,sChuYuanQingKong,sYiLiaoFeiYong from s7ShuQianPingGu ");
			strSql.Append(" where sBianHao=@sBianHao ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@sBianHao", OleDbType.VarChar,255)			};
			parameters[0].Value = sBianHao;

			Maticsoft.Model.s7ShuQianPingGu model=new Maticsoft.Model.s7ShuQianPingGu();
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
		public Maticsoft.Model.s7ShuQianPingGu DataRowToModel(DataRow row)
		{
			Maticsoft.Model.s7ShuQianPingGu model=new Maticsoft.Model.s7ShuQianPingGu();
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
				if(row["bWoYuanBingJian"]!=null && row["bWoYuanBingJian"].ToString()!="")
				{
					if((row["bWoYuanBingJian"].ToString()=="1")||(row["bWoYuanBingJian"].ToString().ToLower()=="true"))
					{
						model.bWoYuanBingJian=true;
					}
					else
					{
						model.bWoYuanBingJian=false;
					}
				}
				if(row["sResult"]!=null)
				{
					model.sResult=row["sResult"].ToString();
				}
				if(row["sBingLiHao"]!=null)
				{
					model.sBingLiHao=row["sBingLiHao"].ToString();
				}
				if(row["bWoYuanCT"]!=null && row["bWoYuanCT"].ToString()!="")
				{
					if((row["bWoYuanCT"].ToString()=="1")||(row["bWoYuanCT"].ToString().ToLower()=="true"))
					{
						model.bWoYuanCT=true;
					}
					else
					{
						model.bWoYuanCT=false;
					}
				}
				if(row["sZhongLiuDaXiao"]!=null)
				{
					model.sZhongLiuDaXiao=row["sZhongLiuDaXiao"].ToString();
				}
				if(row["sJuBuQinFang"]!=null)
				{
					model.sJuBuQinFang=row["sJuBuQinFang"].ToString();
				}
				if(row["sLinBaJieZhuanYi"]!=null)
				{
					model.sLinBaJieZhuanYi=row["sLinBaJieZhuanYi"].ToString();
				}
				if(row["bZhuanYi"]!=null && row["bZhuanYi"].ToString()!="")
				{
					if((row["bZhuanYi"].ToString()=="1")||(row["bZhuanYi"].ToString().ToLower()=="true"))
					{
						model.bZhuanYi=true;
					}
					else
					{
						model.bZhuanYi=false;
					}
				}
				if(row["sBuWei"]!=null)
				{
					model.sBuWei=row["sBuWei"].ToString();
				}
				if(row["bWoYuanMRI"]!=null && row["bWoYuanMRI"].ToString()!="")
				{
					if((row["bWoYuanMRI"].ToString()=="1")||(row["bWoYuanMRI"].ToString().ToLower()=="true"))
					{
						model.bWoYuanMRI=true;
					}
					else
					{
						model.bWoYuanMRI=false;
					}
				}
				if(row["bPET"]!=null && row["bPET"].ToString()!="")
				{
					if((row["bPET"].ToString()=="1")||(row["bPET"].ToString().ToLower()=="true"))
					{
						model.bPET=true;
					}
					else
					{
						model.bPET=false;
					}
				}
				if(row["sDaiXieQiangDu"]!=null)
				{
					model.sDaiXieQiangDu=row["sDaiXieQiangDu"].ToString();
				}
				if(row["sLinBaZhuanYi"]!=null)
				{
					model.sLinBaZhuanYi=row["sLinBaZhuanYi"].ToString();
				}
				if(row["sZhuanYiBuWeiDaiXieQD"]!=null)
				{
					model.sZhuanYiBuWeiDaiXieQD=row["sZhuanYiBuWeiDaiXieQD"].ToString();
				}
				if(row["sCT"]!=null)
				{
					model.sCT=row["sCT"].ToString();
				}
				if(row["sCN"]!=null)
				{
					model.sCN=row["sCN"].ToString();
				}
				if(row["sCM"]!=null)
				{
					model.sCM=row["sCM"].ToString();
				}
				if(row["sWBC"]!=null)
				{
					model.sWBC=row["sWBC"].ToString();
				}
				if(row["sHb"]!=null)
				{
					model.sHb=row["sHb"].ToString();
				}
				if(row["sALB"]!=null)
				{
					model.sALB=row["sALB"].ToString();
				}
				if(row["sCEA"]!=null)
				{
					model.sCEA=row["sCEA"].ToString();
				}
				if(row["sCA125"]!=null)
				{
					model.sCA125=row["sCA125"].ToString();
				}
				if(row["sCA199"]!=null)
				{
					model.sCA199=row["sCA199"].ToString();
				}
				if(row["sCA724"]!=null)
				{
					model.sCA724=row["sCA724"].ToString();
				}
				if(row["sAFP"]!=null)
				{
					model.sAFP=row["sAFP"].ToString();
				}
				if(row["bGengZhu"]!=null && row["bGengZhu"].ToString()!="")
				{
					if((row["bGengZhu"].ToString()=="1")||(row["bGengZhu"].ToString().ToLower()=="true"))
					{
						model.bGengZhu=true;
					}
					else
					{
						model.bGengZhu=false;
					}
				}
				if(row["bChuXie"]!=null && row["bChuXie"].ToString()!="")
				{
					if((row["bChuXie"].ToString()=="1")||(row["bChuXie"].ToString().ToLower()=="true"))
					{
						model.bChuXie=true;
					}
					else
					{
						model.bChuXie=false;
					}
				}
				if(row["bChuanKong"]!=null && row["bChuanKong"].ToString()!="")
				{
					if((row["bChuanKong"].ToString()=="1")||(row["bChuanKong"].ToString().ToLower()=="true"))
					{
						model.bChuanKong=true;
					}
					else
					{
						model.bChuanKong=false;
					}
				}
				if(row["sBMI"]!=null)
				{
					model.sBMI=row["sBMI"].ToString();
				}
				if(row["sNRS2002"]!=null)
				{
					model.sNRS2002=row["sNRS2002"].ToString();
				}
				if(row["sTengTongPingFen"]!=null)
				{
					model.sTengTongPingFen=row["sTengTongPingFen"].ToString();
				}
				if(row["sECOG"]!=null)
				{
					model.sECOG=row["sECOG"].ToString();
				}
				if(row["sXinGongNeng"]!=null)
				{
					model.sXinGongNeng=row["sXinGongNeng"].ToString();
				}
				if(row["sFeiGongNeng"]!=null)
				{
					model.sFeiGongNeng=row["sFeiGongNeng"].ToString();
				}
				if(row["sShenGongNeng"]!=null)
				{
					model.sShenGongNeng=row["sShenGongNeng"].ToString();
				}
				if(row["sGanGongNeng"]!=null)
				{
					model.sGanGongNeng=row["sGanGongNeng"].ToString();
				}
				if(row["sNingXieGongneng"]!=null)
				{
					model.sNingXieGongneng=row["sNingXieGongneng"].ToString();
				}
				if(row["bJiZhenShouShu"]!=null && row["bJiZhenShouShu"].ToString()!="")
				{
					if((row["bJiZhenShouShu"].ToString()=="1")||(row["bJiZhenShouShu"].ToString().ToLower()=="true"))
					{
						model.bJiZhenShouShu=true;
					}
					else
					{
						model.bJiZhenShouShu=false;
					}
				}
				if(row["dShouShuRiqi"]!=null && row["dShouShuRiqi"].ToString()!="")
				{
					model.dShouShuRiqi=DateTime.Parse(row["dShouShuRiqi"].ToString());
				}
				if(row["sQiangjingKaiFu"]!=null)
				{
					model.sQiangjingKaiFu=row["sQiangjingKaiFu"].ToString();
				}
				if(row["sShuShi"]!=null)
				{
					model.sShuShi=row["sShuShi"].ToString();
				}
				if(row["sShouShuTime"]!=null)
				{
					model.sShouShuTime=row["sShouShuTime"].ToString();
				}
				if(row["dKaiFuWenHeTime"]!=null && row["dKaiFuWenHeTime"].ToString()!="")
				{
					model.dKaiFuWenHeTime=DateTime.Parse(row["dKaiFuWenHeTime"].ToString());
				}
				if(row["sZhongLiuJuTiWeiZhi"]!=null)
				{
					model.sZhongLiuJuTiWeiZhi=row["sZhongLiuJuTiWeiZhi"].ToString();
				}
				if(row["bLianHeQiZhuangQieChu"]!=null && row["bLianHeQiZhuangQieChu"].ToString()!="")
				{
					if((row["bLianHeQiZhuangQieChu"].ToString()=="1")||(row["bLianHeQiZhuangQieChu"].ToString().ToLower()=="true"))
					{
						model.bLianHeQiZhuangQieChu=true;
					}
					else
					{
						model.bLianHeQiZhuangQieChu=false;
					}
				}
				if(row["sChuXieLiang"]!=null)
				{
					model.sChuXieLiang=row["sChuXieLiang"].ToString();
				}
				if(row["sFuQiangWuRuan"]!=null)
				{
					model.sFuQiangWuRuan=row["sFuQiangWuRuan"].ToString();
				}
				if(row["sFuShenShang"]!=null)
				{
					model.sFuShenShang=row["sFuShenShang"].ToString();
				}
				if(row["bYingYangGuan"]!=null && row["bYingYangGuan"].ToString()!="")
				{
					if((row["bYingYangGuan"].ToString()=="1")||(row["bYingYangGuan"].ToString().ToLower()=="true"))
					{
						model.bYingYangGuan=true;
					}
					else
					{
						model.bYingYangGuan=false;
					}
				}
				if(row["bZaoLou"]!=null && row["bZaoLou"].ToString()!="")
				{
					if((row["bZaoLou"].ToString()=="1")||(row["bZaoLou"].ToString().ToLower()=="true"))
					{
						model.bZaoLou=true;
					}
					else
					{
						model.bZaoLou=false;
					}
				}
				if(row["bShuZhongBingLi"]!=null && row["bShuZhongBingLi"].ToString()!="")
				{
					if((row["bShuZhongBingLi"].ToString()=="1")||(row["bShuZhongBingLi"].ToString().ToLower()=="true"))
					{
						model.bShuZhongBingLi=true;
					}
					else
					{
						model.bShuZhongBingLi=false;
					}
				}
				if(row["sResult2"]!=null)
				{
					model.sResult2=row["sResult2"].ToString();
				}
				if(row["sQieChuQingkong"]!=null)
				{
					model.sQieChuQingkong=row["sQieChuQingkong"].ToString();
				}
				if(row["sLinBaJieQingShao"]!=null)
				{
					model.sLinBaJieQingShao=row["sLinBaJieQingShao"].ToString();
				}
				if(row["sTeShuShuoMing"]!=null)
				{
					model.sTeShuShuoMing=row["sTeShuShuoMing"].ToString();
				}
				if(row["bERAS"]!=null && row["bERAS"].ToString()!="")
				{
					if((row["bERAS"].ToString()=="1")||(row["bERAS"].ToString().ToLower()=="true"))
					{
						model.bERAS=true;
					}
					else
					{
						model.bERAS=false;
					}
				}
				if(row["bICUJianHu"]!=null && row["bICUJianHu"].ToString()!="")
				{
					if((row["bICUJianHu"].ToString()=="1")||(row["bICUJianHu"].ToString().ToLower()=="true"))
					{
						model.bICUJianHu=true;
					}
					else
					{
						model.bICUJianHu=false;
					}
				}
				if(row["sJianHuTime"]!=null)
				{
					model.sJianHuTime=row["sJianHuTime"].ToString();
				}
				if(row["dJinShuShiJian"]!=null && row["dJinShuShiJian"].ToString()!="")
				{
					model.dJinShuShiJian=DateTime.Parse(row["dJinShuShiJian"].ToString());
				}
				if(row["dTongQiTime"]!=null && row["dTongQiTime"].ToString()!="")
				{
					model.dTongQiTime=DateTime.Parse(row["dTongQiTime"].ToString());
				}
				if(row["dPaiBianTime"]!=null && row["dPaiBianTime"].ToString()!="")
				{
					model.dPaiBianTime=DateTime.Parse(row["dPaiBianTime"].ToString());
				}
				if(row["dFuTongHuanJieTime"]!=null && row["dFuTongHuanJieTime"].ToString()!="")
				{
					model.dFuTongHuanJieTime=DateTime.Parse(row["dFuTongHuanJieTime"].ToString());
				}
				if(row["dNiaoGuanBaChuTime"]!=null && row["dNiaoGuanBaChuTime"].ToString()!="")
				{
					model.dNiaoGuanBaChuTime=DateTime.Parse(row["dNiaoGuanBaChuTime"].ToString());
				}
				if(row["dYinLiuGuanBaChuTime"]!=null && row["dYinLiuGuanBaChuTime"].ToString()!="")
				{
					model.dYinLiuGuanBaChuTime=DateTime.Parse(row["dYinLiuGuanBaChuTime"].ToString());
				}
				if(row["dXiaChuangTime"]!=null && row["dXiaChuangTime"].ToString()!="")
				{
					model.dXiaChuangTime=DateTime.Parse(row["dXiaChuangTime"].ToString());
				}
				if(row["dJinShi"]!=null && row["dJinShi"].ToString()!="")
				{
					model.dJinShi=DateTime.Parse(row["dJinShi"].ToString());
				}
				if(row["dChangNeiYingYang"]!=null && row["dChangNeiYingYang"].ToString()!="")
				{
					model.dChangNeiYingYang=DateTime.Parse(row["dChangNeiYingYang"].ToString());
				}
				if(row["dChangNeiYingYangZhiChiTime"]!=null && row["dChangNeiYingYangZhiChiTime"].ToString()!="")
				{
					model.dChangNeiYingYangZhiChiTime=DateTime.Parse(row["dChangNeiYingYangZhiChiTime"].ToString());
				}
				if(row["dTPNtime"]!=null && row["dTPNtime"].ToString()!="")
				{
					model.dTPNtime=DateTime.Parse(row["dTPNtime"].ToString());
				}
				if(row["sShuHouChuXue"]!=null)
				{
					model.sShuHouChuXue=row["sShuHouChuXue"].ToString();
				}
				if(row["sFuQiangGanRuan"]!=null)
				{
					model.sFuQiangGanRuan=row["sFuQiangGanRuan"].ToString();
				}
				if(row["sQieKouGanRuan"]!=null)
				{
					model.sQieKouGanRuan=row["sQieKouGanRuan"].ToString();
				}
				if(row["sWenHeKouLou"]!=null)
				{
					model.sWenHeKouLou=row["sWenHeKouLou"].ToString();
				}
				if(row["sChangGenZhu"]!=null)
				{
					model.sChangGenZhu=row["sChangGenZhu"].ToString();
				}
				if(row["sWeiTan"]!=null)
				{
					model.sWeiTan=row["sWeiTan"].ToString();
				}
				if(row["sFeiBuFanRuan"]!=null)
				{
					model.sFeiBuFanRuan=row["sFeiBuFanRuan"].ToString();
				}
				if(row["sDiDanBaiXueZheng"]!=null)
				{
					model.sDiDanBaiXueZheng=row["sDiDanBaiXueZheng"].ToString();
				}
				if(row["sWEiGuanTuoChu"]!=null)
				{
					model.sWEiGuanTuoChu=row["sWEiGuanTuoChu"].ToString();
				}
				if(row["sYingYangGuanTuoChu"]!=null)
				{
					model.sYingYangGuanTuoChu=row["sYingYangGuanTuoChu"].ToString();
				}
				if(row["sZaoKouBingFaZheng"]!=null)
				{
					model.sZaoKouBingFaZheng=row["sZaoKouBingFaZheng"].ToString();
				}
				if(row["s2thShouShu"]!=null)
				{
					model.s2thShouShu=row["s2thShouShu"].ToString();
				}
				if(row["dShouShuTime"]!=null && row["dShouShuTime"].ToString()!="")
				{
					if((row["dShouShuTime"].ToString()=="1")||(row["dShouShuTime"].ToString().ToLower()=="true"))
					{
						model.dShouShuTime=true;
					}
					else
					{
						model.dShouShuTime=false;
					}
				}
				if(row["sShouShuFangShi"]!=null)
				{
					model.sShouShuFangShi=row["sShouShuFangShi"].ToString();
				}
				if(row["sJieJueWenTi"]!=null)
				{
					model.sJieJueWenTi=row["sJieJueWenTi"].ToString();
				}
				if(row["sShuHouBingLiZhengDuan"]!=null)
				{
					model.sShuHouBingLiZhengDuan=row["sShuHouBingLiZhengDuan"].ToString();
				}
				if(row["sFenHuaChengDu"]!=null)
				{
					model.sFenHuaChengDu=row["sFenHuaChengDu"].ToString();
				}
				if(row["sJinRunShenDu"]!=null)
				{
					model.sJinRunShenDu=row["sJinRunShenDu"].ToString();
				}
				if(row["sMaiGuanAiShuan"]!=null)
				{
					model.sMaiGuanAiShuan=row["sMaiGuanAiShuan"].ToString();
				}
				if(row["sShenJingQinFang"]!=null)
				{
					model.sShenJingQinFang=row["sShenJingQinFang"].ToString();
				}
				if(row["sAiJieJie"]!=null)
				{
					model.sAiJieJie=row["sAiJieJie"].ToString();
				}
				if(row["sZongLinBaJieShu"]!=null)
				{
					model.sZongLinBaJieShu=row["sZongLinBaJieShu"].ToString();
				}
				if(row["sZhuanyiLinBaJieShu"]!=null)
				{
					model.sZhuanyiLinBaJieShu=row["sZhuanyiLinBaJieShu"].ToString();
				}
				if(row["sMSI"]!=null)
				{
					model.sMSI=row["sMSI"].ToString();
				}
				if(row["sHER_2"]!=null)
				{
					model.sHER_2=row["sHER_2"].ToString();
				}
				if(row["sP53"]!=null)
				{
					model.sP53=row["sP53"].ToString();
				}
				if(row["sK_RAS"]!=null)
				{
					model.sK_RAS=row["sK_RAS"].ToString();
				}
				if(row["sShouHouBingLiFenQi"]!=null)
				{
					model.sShouHouBingLiFenQi=row["sShouHouBingLiFenQi"].ToString();
				}
				if(row["sMSIQueZheng"]!=null)
				{
					model.sMSIQueZheng=row["sMSIQueZheng"].ToString();
				}
				if(row["sJiYinJianCe"]!=null)
				{
					model.sJiYinJianCe=row["sJiYinJianCe"].ToString();
				}
				if(row["dChuYuanTime"]!=null && row["dChuYuanTime"].ToString()!="")
				{
					model.dChuYuanTime=DateTime.Parse(row["dChuYuanTime"].ToString());
				}
				if(row["sChuYuanQingKong"]!=null)
				{
					model.sChuYuanQingKong=row["sChuYuanQingKong"].ToString();
				}
				if(row["sYiLiaoFeiYong"]!=null)
				{
					model.sYiLiaoFeiYong=row["sYiLiaoFeiYong"].ToString();
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
			strSql.Append("select ID,sBianHao,bWoYuanBingJian,sResult,sBingLiHao,bWoYuanCT,sZhongLiuDaXiao,sJuBuQinFang,sLinBaJieZhuanYi,bZhuanYi,sBuWei,bWoYuanMRI,bPET,sDaiXieQiangDu,sLinBaZhuanYi,sZhuanYiBuWeiDaiXieQD,sCT,sCN,sCM,sWBC,sHb,sALB,sCEA,sCA125,sCA199,sCA724,sAFP,bGengZhu,bChuXie,bChuanKong,sBMI,sNRS2002,sTengTongPingFen,sECOG,sXinGongNeng,sFeiGongNeng,sShenGongNeng,sGanGongNeng,sNingXieGongneng,bJiZhenShouShu,dShouShuRiqi,sQiangjingKaiFu,sShuShi,sShouShuTime,dKaiFuWenHeTime,sZhongLiuJuTiWeiZhi,bLianHeQiZhuangQieChu,sChuXieLiang,sFuQiangWuRuan,sFuShenShang,bYingYangGuan,bZaoLou,bShuZhongBingLi,sResult2,sQieChuQingkong,sLinBaJieQingShao,sTeShuShuoMing,bERAS,bICUJianHu,sJianHuTime,dJinShuShiJian,dTongQiTime,dPaiBianTime,dFuTongHuanJieTime,dNiaoGuanBaChuTime,dYinLiuGuanBaChuTime,dXiaChuangTime,dJinShi,dChangNeiYingYang,dChangNeiYingYangZhiChiTime,dTPNtime,sShuHouChuXue,sFuQiangGanRuan,sQieKouGanRuan,sWenHeKouLou,sChangGenZhu,sWeiTan,sFeiBuFanRuan,sDiDanBaiXueZheng,sWEiGuanTuoChu,sYingYangGuanTuoChu,sZaoKouBingFaZheng,s2thShouShu,dShouShuTime,sShouShuFangShi,sJieJueWenTi,sShuHouBingLiZhengDuan,sFenHuaChengDu,sJinRunShenDu,sMaiGuanAiShuan,sShenJingQinFang,sAiJieJie,sZongLinBaJieShu,sZhuanyiLinBaJieShu,sMSI,sHER_2,sP53,sK_RAS,sShouHouBingLiFenQi,sMSIQueZheng,sJiYinJianCe,dChuYuanTime,sChuYuanQingKong,sYiLiaoFeiYong ");
			strSql.Append(" FROM s7ShuQianPingGu ");
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
			strSql.Append("select count(1) FROM s7ShuQianPingGu ");
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
				strSql.Append("order by T.sBianHao desc");
			}
			strSql.Append(")AS Row, T.*  from s7ShuQianPingGu T ");
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
			parameters[0].Value = "s7ShuQianPingGu";
			parameters[1].Value = "sBianHao";
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

