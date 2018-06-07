/**  版本信息模板在安装目录下，可自行修改。
* s0Login.cs
*
* 功 能： N/A
* 类 名： s0Login
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/7 9:41:20   N/A    初版
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
	/// s0Login:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s0Login
	{
		public s0Login()
		{}
		#region Model
		private int _id;
		private string _sname;
		private string _spwd;
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
		public string sName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPwd
		{
			set{ _spwd=value;}
			get{return _spwd;}
		}
		#endregion Model

	}
}

