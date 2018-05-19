/**  版本信息模板在安装目录下，可自行修改。
* file.cs
*
* 功 能： N/A
* 类 名： file
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 12:22:46   N/A    初版
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
	/// file:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class file
	{
		public file()
		{}
		#region Model
		private int _id;
		private string _sfilename;
		private int? _iuserid;
		private string _stype;
		private byte[] _sfilestream;
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
		public string sFileName
		{
			set{ _sfilename=value;}
			get{return _sfilename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iUserID
		{
			set{ _iuserid=value;}
			get{return _iuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sType
		{
			set{ _stype=value;}
			get{return _stype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] sFileStream
		{
			set{ _sfilestream=value;}
			get{return _sfilestream;}
		}
		#endregion Model

	}
}

