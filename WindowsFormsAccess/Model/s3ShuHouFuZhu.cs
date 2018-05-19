﻿/**  版本信息模板在安装目录下，可自行修改。
* s3ShuHouFuZhu.cs
*
* 功 能： N/A
* 类 名： s3ShuHouFuZhu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/19 12:22:48   N/A    初版
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
	/// s3ShuHouFuZhu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class s3ShuHouFuZhu
	{
		public s3ShuHouFuZhu()
		{}
		#region Model
		private int _id;
		private string _sbianma;
		private bool _bfuzhuhualiao= false;
		private string _szhouqi;
		private string _sfangan;
		private string _stibiaomianji;
		private string _sshijijiliang;
		private string _swbc;
		private string _shb;
		private string _splt;
		private string _sbmi;
		private string _snrs2002;
		private string _sfcog;
		private bool _bfufa= false;
		private string _sweizhi;
		private string _schulifangshi;
		private string _sjiliang;
		private string _sliaocheng;
		private string _sliaoxiaopingfen;
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
		public bool bFuZhuHuaLiao
		{
			set{ _bfuzhuhualiao=value;}
			get{return _bfuzhuhualiao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sZhouQi
		{
			set{ _szhouqi=value;}
			get{return _szhouqi;}
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
		public string sTiBiaoMianJi
		{
			set{ _stibiaomianji=value;}
			get{return _stibiaomianji;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sShiJiJiLiang
		{
			set{ _sshijijiliang=value;}
			get{return _sshijijiliang;}
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
		public string sPLT
		{
			set{ _splt=value;}
			get{return _splt;}
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
		public string sFCOG
		{
			set{ _sfcog=value;}
			get{return _sfcog;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bFuFa
		{
			set{ _bfufa=value;}
			get{return _bfufa;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sWeiZhi
		{
			set{ _sweizhi=value;}
			get{return _sweizhi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sChuliFangShi
		{
			set{ _schulifangshi=value;}
			get{return _schulifangshi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sjiLiang
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
		public string sLiaoXiaoPingFen
		{
			set{ _sliaoxiaopingfen=value;}
			get{return _sliaoxiaopingfen;}
		}
		#endregion Model

	}
}
