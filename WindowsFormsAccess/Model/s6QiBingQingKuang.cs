/**  版本信息模板在安装目录下，可自行修改。
* s6QiBingQingKuang.cs
*
* 功 能： N/A
* 类 名： s6QiBingQingKuang
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/22 19:46:18   N/A    初版
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
	/// s6QiBingQingKuang:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s6QiBingQingKuang
	{
		public s6QiBingQingKuang()
		{}
		#region Model
		private int _id;
		private string _sbianma;
		private string _szhongliubuwei;
		private string _sshoufazhengzhuang;
		private DateTime? _dtime;
		private DateTime? _dchubuzhengduantime;
		private string _sresult;
		private string _szhenduanyijiu;
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
		public string sBianMa
		{
			set{ _sbianma=value;}
			get{return _sbianma;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhongLiuBuWei
		{
			set{ _szhongliubuwei=value;}
			get{return _szhongliubuwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShouFaZhengZhuang
		{
			set{ _sshoufazhengzhuang=value;}
			get{return _sshoufazhengzhuang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dTime
		{
			set{ _dtime=value;}
			get{return _dtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dChuBuZhengDuanTime
		{
			set{ _dchubuzhengduantime=value;}
			get{return _dchubuzhengduantime;}
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
		public string sZhenDuanYiJiu
		{
			set{ _szhenduanyijiu=value;}
			get{return _szhenduanyijiu;}
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

