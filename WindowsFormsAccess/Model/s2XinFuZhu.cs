/**  版本信息模板在安装目录下，可自行修改。
* s2XinFuZhu.cs
*
* 功 能： N/A
* 类 名： s2XinFuZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/7 9:41:22   N/A    初版
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
	/// s2XinFuZhu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s2XinFuZhu
	{
		public s2XinFuZhu()
		{}
		#region Model
		private int _id;
		private string _sbianma;
		private bool _bxinfuzhu= false;
		private string _szhuyuanhao;
		private string _sfangan;
		private string _sjiliang;
		private string _sliaocheng;
		private string _sliaoxiaopingjia;
		private string _sfangliaofangan;
		private string _sfangliaoliaocheng;
		private bool _bshuqian2thbingjian= false;
		private string _sresult;
		private bool _bxinfuzhufangliao= false;
		private int? _iuserid;
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
		public string sBianMa
		{
			set{ _sbianma=value;}
			get{return _sbianma;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bXinFuZhu
		{
			set{ _bxinfuzhu=value;}
			get{return _bxinfuzhu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhuYuanHao
		{
			set{ _szhuyuanhao=value;}
			get{return _szhuyuanhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFangAn
		{
			set{ _sfangan=value;}
			get{return _sfangan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sJiLiang
		{
			set{ _sjiliang=value;}
			get{return _sjiliang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLiaoCheng
		{
			set{ _sliaocheng=value;}
			get{return _sliaocheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLiaoXiaoPingJia
		{
			set{ _sliaoxiaopingjia=value;}
			get{return _sliaoxiaopingjia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFangLiaoFangAn
		{
			set{ _sfangliaofangan=value;}
			get{return _sfangliaofangan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sFangLiaoLiaoCheng
		{
			set{ _sfangliaoliaocheng=value;}
			get{return _sfangliaoliaocheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bShuQian2thBingJian
		{
			set{ _bshuqian2thbingjian=value;}
			get{return _bshuqian2thbingjian;}
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
		public bool bXinFuZhuFangLiao
		{
			set{ _bxinfuzhufangliao=value;}
			get{return _bxinfuzhufangliao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iUserID
		{
			set{ _iuserid=value;}
			get{return _iuserid;}
		}
		#endregion Model

	}
}

