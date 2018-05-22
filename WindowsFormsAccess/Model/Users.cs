/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/22 19:46:22   N/A    初版
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
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private int _id;
		private string _sbianhao;
		private string _sbianma;
		private string _szhuyuanhao;
		private string _sname;
		private string _ssex;
		private string _iage;
		private string _szhiye;
		private DateTime? _druyuanshijian;
		private string _sphone;
		private string _sminzu;
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
		public string sBianMa
		{
			set{ _sbianma=value;}
			get{return _sbianma;}
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
		public string sName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSex
		{
			set{ _ssex=value;}
			get{return _ssex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iAge
		{
			set{ _iage=value;}
			get{return _iage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhiYe
		{
			set{ _szhiye=value;}
			get{return _szhiye;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dRuYuanShiJian
		{
			set{ _druyuanshijian=value;}
			get{return _druyuanshijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPhone
		{
			set{ _sphone=value;}
			get{return _sphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMinZu
		{
			set{ _sminzu=value;}
			get{return _sminzu;}
		}
		#endregion Model

	}
}

