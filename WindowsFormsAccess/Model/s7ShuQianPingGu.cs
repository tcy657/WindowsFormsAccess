/**  版本信息模板在安装目录下，可自行修改。
* s7ShuQianPingGu.cs
*
* 功 能： N/A
* 类 名： s7ShuQianPingGu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/22 19:46:19   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：湘竹科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// s7ShuQianPingGu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s7ShuQianPingGu
	{
		public s7ShuQianPingGu()
		{}
		#region Model
		private int _id;
		private string _sbianhao;
		private bool _bwoyuanbingjian= false;
		private string _sresult;
		private string _sbinglihao;
		private bool _bwoyuanct= false;
		private string _szhongliudaxiao;
		private string _sjubuqinfang;
		private bool _blinbajiezhuanyi= false;
		private bool _bzhuanyi= false;
		private string _sbuwei;
		private bool _bwoyuanmri= false;
		private string _smrizhongliudaxiao;
		private string _smrijubuqinfang;
		private bool _bmrilinbajiezhuanyi= false;
		private bool _bmrizhuanyi= false;
		private string _smribuwei;
		private bool _bpet= false;
		private string _spetzhongliudaxiao;
		private string _spetjubuqinfang;
		private string _sdaixieqiangdu;
		private string _slinbazhuanyi;
		private string _bpetzhuanyi;
		private string _spetbuwei;
		private string _szhuanyibuweidaixieqd;
		private string _sct;
		private string _scn;
		private string _scm;
		private string _swbc;
		private string _shb;
		private string _salb;
		private string _scea;
		private string _sca125;
		private string _sca199;
		private string _sca724;
		private string _safp;
		private bool _bgengzhu= false;
		private bool _bchuxie= false;
		private bool _bchuankong= false;
		private string _sbmi;
		private string _snrs2002;
		private string _stengtongpingfen;
		private string _secog;
		private string _sxingongneng;
		private string _sfeigongneng;
		private string _sshengongneng;
		private string _sgangongneng;
		private string _sningxiegongneng;
		private bool _bjizhenshoushu= false;
		private DateTime? _dshoushuriqi;
		private string _sqiangjingkaifu;
		private string _sshushi;
		private string _sshoushutime;
		private DateTime? _dkaifuwenhetime;
		private string _szhongliujutiweizhi;
		private bool _blianheqizhuangqiechu= false;
		private string _schuxieliang;
		private string _sfuqiangwuruan;
		private string _sfushenshang;
		private bool _byingyangguan= false;
		private bool _bzaolou= false;
		private bool _bshuzhongbingli= false;
		private string _sresult2;
		private string _sqiechuqingkong;
		private string _slinbajieqingshao;
		private string _steshushuoming;
		private bool _beras= false;
		private bool _bicujianhu= false;
		private string _sjianhutime;
		private DateTime? _djinshuishijian;
		private DateTime? _dtongqitime;
		private DateTime? _dpaibiantime;
		private DateTime? _dfutonghuanjietime;
		private DateTime? _dniaoguanbachutime;
		private DateTime? _dyinliuguanbachutime;
		private DateTime? _dxiachuangtime;
		private DateTime? _djinshi;
		private bool _bchangneiyingyang= false;
		private DateTime? _dchangneiyingyangzhichitime;
		private DateTime? _dtpntime;
		private string _sshuhouchuxue;
		private string _sfuqiangganruan;
		private string _sqiekouganruan;
		private string _swenhekoulou;
		private string _schanggenzhu;
		private string _sweitan;
		private string _sfeibufanruan;
		private string _sdidanbaixuezheng;
		private string _sweiguantuochu;
		private string _syingyangguantuochu;
		private string _szaokoubingfazheng;
		private bool _b2thshoushu= false;
		private DateTime? _dshoushutime;
		private string _sshoushufangshi;
		private string _sjiejuewenti;
		private string _sshuhoubinglizhengduan;
		private string _sfenhuachengdu;
		private string _sjinrunshendu;
		private string _smaiguanaishuan;
		private string _sshenjingqinfang;
		private string _saijiejie;
		private string _szonglinbajieshu;
		private string _szhuanyilinbajieshu;
		private string _smsi;
		private string _sher_2;
		private string _sp53;
		private string _ski_67;
		private string _sk_ras;
		private string _sn_ras;
		private string _sshouhoubinglifenqi;
		private string _smsiquezheng;
		private string _sjiyinjiance;
		private DateTime? _dchuyuantime;
		private string _schuyuanqingkong;
		private string _syiliaofeiyong;
		private string _iuserid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sBianHao
		{
			set{ _sbianhao=value;}
			get{return _sbianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bWoYuanBingJian
		{
			set{ _bwoyuanbingjian=value;}
			get{return _bwoyuanbingjian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sResult
		{
			set{ _sresult=value;}
			get{return _sresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sBingLiHao
		{
			set{ _sbinglihao=value;}
			get{return _sbinglihao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bWoYuanCT
		{
			set{ _bwoyuanct=value;}
			get{return _bwoyuanct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhongLiuDaXiao
		{
			set{ _szhongliudaxiao=value;}
			get{return _szhongliudaxiao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sJuBuQinFang
		{
			set{ _sjubuqinfang=value;}
			get{return _sjubuqinfang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bLinBaJieZhuanYi
		{
			set{ _blinbajiezhuanyi=value;}
			get{return _blinbajiezhuanyi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bZhuanYi
		{
			set{ _bzhuanyi=value;}
			get{return _bzhuanyi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sBuWei
		{
			set{ _sbuwei=value;}
			get{return _sbuwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bWoYuanMRI
		{
			set{ _bwoyuanmri=value;}
			get{return _bwoyuanmri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMRIZhongliuDaXiao
		{
			set{ _smrizhongliudaxiao=value;}
			get{return _smrizhongliudaxiao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMRIJuBuQinFang
		{
			set{ _smrijubuqinfang=value;}
			get{return _smrijubuqinfang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bMRILinBaJieZhuanYi
		{
			set{ _bmrilinbajiezhuanyi=value;}
			get{return _bmrilinbajiezhuanyi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bMRIZhuanYi
		{
			set{ _bmrizhuanyi=value;}
			get{return _bmrizhuanyi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMRIBuWei
		{
			set{ _smribuwei=value;}
			get{return _smribuwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bPET
		{
			set{ _bpet=value;}
			get{return _bpet;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPETZhongLiuDaXiao
		{
			set{ _spetzhongliudaxiao=value;}
			get{return _spetzhongliudaxiao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPETJuBuQinFang
		{
			set{ _spetjubuqinfang=value;}
			get{return _spetjubuqinfang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sDaiXieQiangDu
		{
			set{ _sdaixieqiangdu=value;}
			get{return _sdaixieqiangdu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLinBaZhuanYi
		{
			set{ _slinbazhuanyi=value;}
			get{return _slinbazhuanyi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bPETZhuanYi
		{
			set{ _bpetzhuanyi=value;}
			get{return _bpetzhuanyi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPETBuWei
		{
			set{ _spetbuwei=value;}
			get{return _spetbuwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhuanYiBuWeiDaiXieQD
		{
			set{ _szhuanyibuweidaixieqd=value;}
			get{return _szhuanyibuweidaixieqd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCT
		{
			set{ _sct=value;}
			get{return _sct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCN
		{
			set{ _scn=value;}
			get{return _scn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCM
		{
			set{ _scm=value;}
			get{return _scm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sWBC
		{
			set{ _swbc=value;}
			get{return _swbc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHb
		{
			set{ _shb=value;}
			get{return _shb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sALB
		{
			set{ _salb=value;}
			get{return _salb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCEA
		{
			set{ _scea=value;}
			get{return _scea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCA125
		{
			set{ _sca125=value;}
			get{return _sca125;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCA199
		{
			set{ _sca199=value;}
			get{return _sca199;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCA724
		{
			set{ _sca724=value;}
			get{return _sca724;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sAFP
		{
			set{ _safp=value;}
			get{return _safp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bGengZhu
		{
			set{ _bgengzhu=value;}
			get{return _bgengzhu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bChuXie
		{
			set{ _bchuxie=value;}
			get{return _bchuxie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bChuanKong
		{
			set{ _bchuankong=value;}
			get{return _bchuankong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sBMI
		{
			set{ _sbmi=value;}
			get{return _sbmi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sNRS2002
		{
			set{ _snrs2002=value;}
			get{return _snrs2002;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sTengTongPingFen
		{
			set{ _stengtongpingfen=value;}
			get{return _stengtongpingfen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sECOG
		{
			set{ _secog=value;}
			get{return _secog;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sXinGongNeng
		{
			set{ _sxingongneng=value;}
			get{return _sxingongneng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFeiGongNeng
		{
			set{ _sfeigongneng=value;}
			get{return _sfeigongneng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShenGongNeng
		{
			set{ _sshengongneng=value;}
			get{return _sshengongneng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sGanGongNeng
		{
			set{ _sgangongneng=value;}
			get{return _sgangongneng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sNingXieGongneng
		{
			set{ _sningxiegongneng=value;}
			get{return _sningxiegongneng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bJiZhenShouShu
		{
			set{ _bjizhenshoushu=value;}
			get{return _bjizhenshoushu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dShouShuRiqi
		{
			set{ _dshoushuriqi=value;}
			get{return _dshoushuriqi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sQiangjingKaiFu
		{
			set{ _sqiangjingkaifu=value;}
			get{return _sqiangjingkaifu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShuShi
		{
			set{ _sshushi=value;}
			get{return _sshushi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShouShuTime
		{
			set{ _sshoushutime=value;}
			get{return _sshoushutime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dKaiFuWenHeTime
		{
			set{ _dkaifuwenhetime=value;}
			get{return _dkaifuwenhetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhongLiuJuTiWeiZhi
		{
			set{ _szhongliujutiweizhi=value;}
			get{return _szhongliujutiweizhi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bLianHeQiZhuangQieChu
		{
			set{ _blianheqizhuangqiechu=value;}
			get{return _blianheqizhuangqiechu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sChuXieLiang
		{
			set{ _schuxieliang=value;}
			get{return _schuxieliang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFuQiangWuRuan
		{
			set{ _sfuqiangwuruan=value;}
			get{return _sfuqiangwuruan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFuShenShang
		{
			set{ _sfushenshang=value;}
			get{return _sfushenshang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bYingYangGuan
		{
			set{ _byingyangguan=value;}
			get{return _byingyangguan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bZaoLou
		{
			set{ _bzaolou=value;}
			get{return _bzaolou;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bShuZhongBingLi
		{
			set{ _bshuzhongbingli=value;}
			get{return _bshuzhongbingli;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sResult2
		{
			set{ _sresult2=value;}
			get{return _sresult2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sQieChuQingkong
		{
			set{ _sqiechuqingkong=value;}
			get{return _sqiechuqingkong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLinBaJieQingShao
		{
			set{ _slinbajieqingshao=value;}
			get{return _slinbajieqingshao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sTeShuShuoMing
		{
			set{ _steshushuoming=value;}
			get{return _steshushuoming;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bERAS
		{
			set{ _beras=value;}
			get{return _beras;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bICUJianHu
		{
			set{ _bicujianhu=value;}
			get{return _bicujianhu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sJianHuTime
		{
			set{ _sjianhutime=value;}
			get{return _sjianhutime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dJinShuiShiJian
		{
			set{ _djinshuishijian=value;}
			get{return _djinshuishijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dTongQiTime
		{
			set{ _dtongqitime=value;}
			get{return _dtongqitime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dPaiBianTime
		{
			set{ _dpaibiantime=value;}
			get{return _dpaibiantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dFuTongHuanJieTime
		{
			set{ _dfutonghuanjietime=value;}
			get{return _dfutonghuanjietime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dNiaoGuanBaChuTime
		{
			set{ _dniaoguanbachutime=value;}
			get{return _dniaoguanbachutime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dYinLiuGuanBaChuTime
		{
			set{ _dyinliuguanbachutime=value;}
			get{return _dyinliuguanbachutime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dXiaChuangTime
		{
			set{ _dxiachuangtime=value;}
			get{return _dxiachuangtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dJinShi
		{
			set{ _djinshi=value;}
			get{return _djinshi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bChangNeiYingYang
		{
			set{ _bchangneiyingyang=value;}
			get{return _bchangneiyingyang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dChangNeiYingYangZhiChiTime
		{
			set{ _dchangneiyingyangzhichitime=value;}
			get{return _dchangneiyingyangzhichitime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dTPNtime
		{
			set{ _dtpntime=value;}
			get{return _dtpntime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShuHouChuXue
		{
			set{ _sshuhouchuxue=value;}
			get{return _sshuhouchuxue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFuQiangGanRuan
		{
			set{ _sfuqiangganruan=value;}
			get{return _sfuqiangganruan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sQieKouGanRuan
		{
			set{ _sqiekouganruan=value;}
			get{return _sqiekouganruan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sWenHeKouLou
		{
			set{ _swenhekoulou=value;}
			get{return _swenhekoulou;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sChangGenZhu
		{
			set{ _schanggenzhu=value;}
			get{return _schanggenzhu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sWeiTan
		{
			set{ _sweitan=value;}
			get{return _sweitan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFeiBuFanRuan
		{
			set{ _sfeibufanruan=value;}
			get{return _sfeibufanruan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sDiDanBaiXueZheng
		{
			set{ _sdidanbaixuezheng=value;}
			get{return _sdidanbaixuezheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sWEiGuanTuoChu
		{
			set{ _sweiguantuochu=value;}
			get{return _sweiguantuochu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sYingYangGuanTuoChu
		{
			set{ _syingyangguantuochu=value;}
			get{return _syingyangguantuochu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZaoKouBingFaZheng
		{
			set{ _szaokoubingfazheng=value;}
			get{return _szaokoubingfazheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool b2thShouShu
		{
			set{ _b2thshoushu=value;}
			get{return _b2thshoushu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dShouShuTime
		{
			set{ _dshoushutime=value;}
			get{return _dshoushutime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShouShuFangShi
		{
			set{ _sshoushufangshi=value;}
			get{return _sshoushufangshi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sJieJueWenTi
		{
			set{ _sjiejuewenti=value;}
			get{return _sjiejuewenti;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShuHouBingLiZhengDuan
		{
			set{ _sshuhoubinglizhengduan=value;}
			get{return _sshuhoubinglizhengduan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFenHuaChengDu
		{
			set{ _sfenhuachengdu=value;}
			get{return _sfenhuachengdu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sJinRunShenDu
		{
			set{ _sjinrunshendu=value;}
			get{return _sjinrunshendu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMaiGuanAiShuan
		{
			set{ _smaiguanaishuan=value;}
			get{return _smaiguanaishuan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShenJingQinFang
		{
			set{ _sshenjingqinfang=value;}
			get{return _sshenjingqinfang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sAiJieJie
		{
			set{ _saijiejie=value;}
			get{return _saijiejie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZongLinBaJieShu
		{
			set{ _szonglinbajieshu=value;}
			get{return _szonglinbajieshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhuanyiLinBaJieShu
		{
			set{ _szhuanyilinbajieshu=value;}
			get{return _szhuanyilinbajieshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMSI
		{
			set{ _smsi=value;}
			get{return _smsi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHER_2
		{
			set{ _sher_2=value;}
			get{return _sher_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sP53
		{
			set{ _sp53=value;}
			get{return _sp53;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sKi_67
		{
			set{ _ski_67=value;}
			get{return _ski_67;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sK_RAS
		{
			set{ _sk_ras=value;}
			get{return _sk_ras;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sN_RAS
		{
			set{ _sn_ras=value;}
			get{return _sn_ras;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShouHouBingLiFenQi
		{
			set{ _sshouhoubinglifenqi=value;}
			get{return _sshouhoubinglifenqi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMSIQueZheng
		{
			set{ _smsiquezheng=value;}
			get{return _smsiquezheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sJiYinJianCe
		{
			set{ _sjiyinjiance=value;}
			get{return _sjiyinjiance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dChuYuanTime
		{
			set{ _dchuyuantime=value;}
			get{return _dchuyuantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sChuYuanQingKong
		{
			set{ _schuyuanqingkong=value;}
			get{return _schuyuanqingkong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sYiLiaoFeiYong
		{
			set{ _syiliaofeiyong=value;}
			get{return _syiliaofeiyong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iUserID
		{
			set{ _iuserid=value;}
			get{return _iuserid;}
		}
		#endregion Model

	}
}

