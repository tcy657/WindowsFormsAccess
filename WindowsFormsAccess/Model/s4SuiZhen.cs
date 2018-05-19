/**  版本信息模板在安装目录下，可自行修改。
* s4SuiZhen.cs
*
* 功 能： N/A
* 类 名： s4SuiZhen
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 12:22:49   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// s4SuiZhen:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s4SuiZhen
	{
		public s4SuiZhen()
		{}
		#region Model
		private int _id;
		private string _sbianhao;
		private string _ssuizhencishu;
		private DateTime? _dsuizhentime;
		private string _szhuyuanhao;
		private string _sct;
		private string _smri;
		private string _sneijing;
		private string _spet;
		private DateTime? _bfufa;
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
		public string sSuiZhenCiShu
		{
			set{ _ssuizhencishu=value;}
			get{return _ssuizhencishu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dSuiZhenTime
		{
			set{ _dsuizhentime=value;}
			get{return _dsuizhentime;}
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
		public string sCT
		{
			set{ _sct=value;}
			get{return _sct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMRI
		{
			set{ _smri=value;}
			get{return _smri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sNeiJing
		{
			set{ _sneijing=value;}
			get{return _sneijing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPET
		{
			set{ _spet=value;}
			get{return _spet;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? bFuFa
		{
			set{ _bfufa=value;}
			get{return _bfufa;}
		}
		#endregion Model

	}
}

