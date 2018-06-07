/**  版本信息模板在安装目录下，可自行修改。
* ycyx.cs
*
* 功 能： N/A
* 类 名： ycyx
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/7 9:41:36   N/A    初版
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
	/// ycyx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ycyx
	{
		public ycyx()
		{}
		#region Model
		private int _id;
		private int? _fwhm;
		private int? _khmc;
		private int? _gsdq;
		private string _dqpp;
		private int? _dqtc;
		private int? _dqzt;
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
		public int? fwhm
		{
			set{ _fwhm=value;}
			get{return _fwhm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? khmc
		{
			set{ _khmc=value;}
			get{return _khmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gsdq
		{
			set{ _gsdq=value;}
			get{return _gsdq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dqpp
		{
			set{ _dqpp=value;}
			get{return _dqpp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dqtc
		{
			set{ _dqtc=value;}
			get{return _dqtc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dqzt
		{
			set{ _dqzt=value;}
			get{return _dqzt;}
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

