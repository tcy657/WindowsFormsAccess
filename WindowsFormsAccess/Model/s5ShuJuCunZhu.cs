/**  版本信息模板在安装目录下，可自行修改。
* s5ShuJuCunZhu.cs
*
* 功 能： N/A
* 类 名： s5ShuJuCunZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 12:22:50   N/A    初版
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
	/// s5ShuJuCunZhu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s5ShuJuCunZhu
	{
		public s5ShuJuCunZhu()
		{}
		#region Model
		private int _id;
		private string _sbianhao;
		private string _sct;
		private string _scigongzheng;
		private string _sbingli;
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
		public string sCT
		{
			set{ _sct=value;}
			get{return _sct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCiGongZheng
		{
			set{ _scigongzheng=value;}
			get{return _scigongzheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sBingLi
		{
			set{ _sbingli=value;}
			get{return _sbingli;}
		}
		#endregion Model

	}
}

