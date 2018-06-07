using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility; //引入命名空间

namespace WindowsFormsAccess
{
    public partial class FormSheet7 : Form
    {
        private Maticsoft.Model.s7ShuQianPingGu ms7ShuQianPingGu = new Maticsoft.Model.s7ShuQianPingGu();
        private Maticsoft.DAL.s7ShuQianPingGu dos7ShuQianPingGu = new Maticsoft.DAL.s7ShuQianPingGu();

        #region 公用方法/变量
        int gOid = 0; //全局oid，记录Users的ID号, s1
        int gFlagAdd7 = 0; //默认为查看，其他值则为新增

        //日志输出函数

        //日志输出函数,label
        private void outputLabel(string log)
        {
            try
            {
                //添加日志
                this.toolStripStatusLabel2.Text = log;
                //save2FileTime(autoBackupLogPath, log);  //日志记录到文件
            }//try
            catch
            {
                ; //不处理。
            }
        }

        //初始化
        private void initDo()
        {
            //当前用户
            toolStripStatusLabel1.Text = "当前用户：管理员";
            toolStripStatusLabel2.Text = "| 一定成功，加油！";          

        }

        //根据“true/false”转换为汉字(hanzi)“是/否”
        public string bool2HanZi(bool stringBool)
        {
            string ret = "是";
            if (false == stringBool) { ret = "否"; }
            return ret;
        }
        //根据汉字(hanzi)“是/否”转换为“true/false”
        public bool hanZi2Bool(string stringBin)
        {
            bool ret = true; //
            if ("否" == stringBin) { ret = false; }
            return ret;
        }

        /// <summary>
        ///延时
        /// </summary>
        /// <param name="delayTime"></param>
        /// <returns></returns>
        public static bool Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        #endregion 公用方法

        
        public FormSheet7()
        {
            InitializeComponent();
        }

        #region 控件值可读写
        private int iid = 0;
        private int iiUserID = 0;
  
        public int lOid  //local id
        {
            get { return this.iid; }
            set { this.iid = value; }
        }

        public int iUserID  //iUserID
        {
            get { return this.iiUserID; }
            set { this.iiUserID = value; }
        }

        public string Text1
        {
            get { return this.comboBox17.Text; }
            set { this.comboBox17.Text = value; }
        }

        public string Text2
        {
            get { return this.textBox44.Text; }
            set { this.textBox44.Text = value; }
        }

        public string Text3
        {
            get { return this.textBox45.Text; }
            set { this.textBox45.Text = value; }
        }

        public string Text4
        {
            get { return this.comboBox13.Text; }
            set { this.comboBox13.Text = value; }
        }

        public string Text5
        {
            get { return this.comboBox15.Text; }
            set { this.comboBox15.Text = value; }
        }

        public string Text6
        {
            get { return this.comboBox16.Text; }
            set { this.comboBox16.Text = value; }
        }

        public string Text7
        {
            get { return this.textBox48.Text; }
            set { this.textBox48.Text = value; }
        }

        public string Text8
        {
            get { return this.textBox50.Text; }
            set { this.textBox50.Text = value; }
        }

        public string Text9
        {
            get { return this.textBox78.Text; }
            set { this.textBox78.Text = value; }
        }

        public string Text10
        {
            get { return this.textBox79.Text; }
            set { this.textBox79.Text = value; }
        }

        public string Text11
        {
            get { return this.textBox13.Text; }
            set { this.textBox13.Text = value; }
        }

        public string Text12
        {
            get { return this.textBox14.Text; }
            set { this.textBox14.Text = value; }
        }

        public string Text13
        {
            get { return this.comboBox4.Text; }
            set { this.comboBox4.Text = value; }
        }

        public string Text14
        {
            get { return this.textBox15.Text; }
            set { this.textBox15.Text = value; }
        }

        public string Text15
        {
            get { return this.textBox16.Text; }
            set { this.textBox16.Text = value; }
        }

        public string Text16
        {
            get { return this.textBox18.Text; }
            set { this.textBox18.Text = value; }
        }

        public string Text17
        {
            get { return this.comboBox6.Text; }
            set { this.comboBox6.Text = value; }
        }

        public string Text18
        {
            get { return this.textBox20.Text; }
            set { this.textBox20.Text = value; }
        }

        public string Text19
        {
            get { return this.textBox22.Text; }
            set { this.textBox22.Text = value; }
        }

        public string Text20
        {
            get { return this.textBox23.Text; }
            set { this.textBox23.Text = value; }
        }

        public string Text21
        {
            get { return this.comboBox10.Text; }
            set { this.comboBox10.Text = value; }
        }

        public string Text22
        {
            get { return this.textBox24.Text; }
            set { this.textBox24.Text = value; }
        }

        public string Text23
        {
            get { return this.textBox25.Text; }
            set { this.textBox25.Text = value; }
        }

        public string Text24
        {
            get { return this.textBox26.Text; }
            set { this.textBox26.Text = value; }
        }

        public string Text25
        {
            get { return this.textBox29.Text; }
            set { this.textBox29.Text = value; }
        }

        public string Text26
        {
            get { return this.textBox35.Text; }
            set { this.textBox35.Text = value; }
        }

        public string Text27
        {
            get { return this.textBox36.Text; }
            set { this.textBox36.Text = value; }
        }

        public string Text28
        {
            get { return this.textBox37.Text; }
            set { this.textBox37.Text = value; }
        }

        public string Text29
        {
            get { return this.textBox39.Text; }
            set { this.textBox39.Text = value; }
        }

        public string Text30
        {
            get { return this.textBox40.Text; }
            set { this.textBox40.Text = value; }
        }

        public string Text31
        {
            get { return this.textBox41.Text; }
            set { this.textBox41.Text = value; }
        }

        public string Text32
        {
            get { return this.comboBox11.Text; }
            set { this.comboBox11.Text = value; }
        }

        public string Text33
        {
            get { return this.textBox42.Text; }
            set { this.textBox42.Text = value; }
        }

        public string Text34
        {
            get { return this.textBox7.Text; }
            set { this.textBox7.Text = value; }
        }

        public string Text35
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }

        public string Text36
        {
            get { return this.textBox53.Text; }
            set { this.textBox53.Text = value; }
        }

        public string Text37
        {
            get { return this.comboBox24.Text; }
            set { this.comboBox24.Text = value; }
        }

        public string Text38
        {
            get { return this.textBox76.Text; }
            set { this.textBox76.Text = value; }
        }

        public string Text39
        {
            get { return this.comboBox21.Text; }
            set { this.comboBox21.Text = value; }
        }

        public string Text40
        {
            get { return this.comboBox1.Text; }
            set { this.comboBox1.Text = value; }
        }

        public string Text41
        {
            get { return this.textBox2.Text; }
            set { this.textBox2.Text = value; }
        }

        public string Text42
        {
            get { return this.textBox3.Text; }
            set { this.textBox3.Text = value; }
        }

        public string Text43
        {
            get { return this.comboBox42.Text; }
            set { this.comboBox42.Text = value; }
        }

        public string Text44
        {
            get { return this.comboBox2.Text; }
            set { this.comboBox2.Text = value; }
        }

        public string Text45
        {
            get { return this.textBox5.Text; }
            set { this.textBox5.Text = value; }
        }

        public string Text46
        {
            get { return this.textBox6.Text; }
            set { this.textBox6.Text = value; }
        }

        public string Text47
        {
            get { return this.comboBox41.Text; }
            set { this.comboBox41.Text = value; }
        }

        public string Text48
        {
            get { return this.textBox73.Text; }
            set { this.textBox73.Text = value; }
        }

        public string Text49
        {
            get { return this.comboBox18.Text; }
            set { this.comboBox18.Text = value; }
        }

        public string Text50
        {
            get { return this.textBox11.Text; }
            set { this.textBox11.Text = value; }
        }

        public string Text51
        {
            get { return this.textBox69.Text; }
            set { this.textBox69.Text = value; }
        }

        public string Text52
        {
            get { return this.comboBox43.Text; }
            set { this.comboBox43.Text = value; }
        }

        public string Text53
        {
            get { return this.textBox71.Text; }
            set { this.textBox71.Text = value; }
        }

        public string Text54
        {
            get { return this.comboBox25.Text; }
            set { this.comboBox25.Text = value; }
        }

        public string Text55
        {
            get { return this.textBox8.Text; }
            set { this.textBox8.Text = value; }
        }

        public string Text56
        {
            get { return this.textBox9.Text; }
            set { this.textBox9.Text = value; }
        }

        public string Text57
        {
            get { return this.textBox10.Text; }
            set { this.textBox10.Text = value; }
        }

        public string Text58
        {
            get { return this.textBox54.Text; }
            set { this.textBox54.Text = value; }
        }

        public string Text59
        {
            get { return this.textBox55.Text; }
            set { this.textBox55.Text = value; }
        }

        public string Text60
        {
            get { return this.textBox56.Text; }
            set { this.textBox56.Text = value; }
        }

        public string Text61
        {
            get { return this.textBox60.Text; }
            set { this.textBox60.Text = value; }
        }

        public string Text62
        {
            get { return this.textBox61.Text; }
            set { this.textBox61.Text = value; }
        }

        public string Text63
        {
            get { return this.textBox62.Text; }
            set { this.textBox62.Text = value; }
        }

        public string Text64
        {
            get { return this.textBox63.Text; }
            set { this.textBox63.Text = value; }
        }

        public string Text65
        {
            get { return this.textBox64.Text; }
            set { this.textBox64.Text = value; }
        }

        public string Text66
        {
            get { return this.textBox65.Text; }
            set { this.textBox65.Text = value; }
        }

        public string Text67
        {
            get { return this.comboBox3.Text; }
            set { this.comboBox3.Text = value; }
        }

        public string Text68
        {
            get { return this.comboBox19.Text; }
            set { this.comboBox19.Text = value; }
        }

        public string Text69
        {
            get { return this.comboBox5.Text; }
            set { this.comboBox5.Text = value; }
        }

        public string Text70
        {
            get { return this.comboBox20.Text; }
            set { this.comboBox20.Text = value; }
        }

        public string Text71
        {
            get { return this.comboBox22.Text; }
            set { this.comboBox22.Text = value; }
        }

        public string Text72
        {
            get { return this.comboBox23.Text; }
            set { this.comboBox23.Text = value; }
        }

        public string Text73
        {
            get { return this.comboBox26.Text; }
            set { this.comboBox26.Text = value; }
        }

        public string Text74
        {
            get { return this.comboBox27.Text; }
            set { this.comboBox27.Text = value; }
        }

        public string Text75
        {
            get { return this.comboBox28.Text; }
            set { this.comboBox28.Text = value; }
        }

        public string Text76
        {
            get { return this.comboBox9.Text; }
            set { this.comboBox9.Text = value; }
        }

        public string Text77
        {
            get { return this.comboBox29.Text; }
            set { this.comboBox29.Text = value; }
        }

        public string Text78
        {
            get { return this.textBox12.Text; }
            set { this.textBox12.Text = value; }
        }

        public string Text79
        {
            get { return this.textBox17.Text; }
            set { this.textBox17.Text = value; }
        }

        public string Text80
        {
            get { return this.textBox19.Text; }
            set { this.textBox19.Text = value; }
        }

        public string Text81
        {
            get { return this.comboBox7.Text; }
            set { this.comboBox7.Text = value; }
        }

        public string Text82
        {
            get { return this.comboBox8.Text; }
            set { this.comboBox8.Text = value; }
        }

        public string Text83
        {
            get { return this.comboBox12.Text; }
            set { this.comboBox12.Text = value; }
        }

        public string Text84
        {
            get { return this.comboBox30.Text; }
            set { this.comboBox30.Text = value; }
        }

        public string Text85
        {
            get { return this.comboBox31.Text; }
            set { this.comboBox31.Text = value; }
        }

        public string Text86
        {
            get { return this.comboBox32.Text; }
            set { this.comboBox32.Text = value; }
        }

        public string Text87
        {
            get { return this.comboBox14.Text; }
            set { this.comboBox14.Text = value; }
        }

        public string Text88
        {
            get { return this.textBox21.Text; }
            set { this.textBox21.Text = value; }
        }

        public string Text89
        {
            get { return this.comboBox33.Text; }
            set { this.comboBox33.Text = value; }
        }

        public string Text90
        {
            get { return this.comboBox34.Text; }
            set { this.comboBox34.Text = value; }
        }

        public string Text91
        {
            get { return this.textBox30.Text; }
            set { this.textBox30.Text = value; }
        }

        public string Text92
        {
            get { return this.textBox27.Text; }
            set { this.textBox27.Text = value; }
        }

        public string Text93
        {
            get { return this.textBox31.Text; }
            set { this.textBox31.Text = value; }
        }

        public string Text94
        {
            get { return this.textBox32.Text; }
            set { this.textBox32.Text = value; }
        }

        public string Text95
        {
            get { return this.textBox33.Text; }
            set { this.textBox33.Text = value; }
        }

        public string Text96
        {
            get { return this.textBox34.Text; }
            set { this.textBox34.Text = value; }
        }

        public string Text97
        {
            get { return this.textBox38.Text; }
            set { this.textBox38.Text = value; }
        }

        public string Text98
        {
            get { return this.comboBox35.Text; }
            set { this.comboBox35.Text = value; }
        }

        public string Text99
        {
            get { return this.comboBox36.Text; }
            set { this.comboBox36.Text = value; }
        }

        public string Text100
        {
            get { return this.comboBox37.Text; }
            set { this.comboBox37.Text = value; }
        }

        public string Text101
        {
            get { return this.textBox28.Text; }
            set { this.textBox28.Text = value; }
        }

        public string Text102
        {
            get { return this.textBox43.Text; }
            set { this.textBox43.Text = value; }
        }

        public string Text103
        {
            get { return this.textBox46.Text; }
            set { this.textBox46.Text = value; }
        }

        public string Text104
        {
            get { return this.textBox47.Text; }
            set { this.textBox47.Text = value; }
        }

        public string Text105
        {
            get { return this.textBox49.Text; }
            set { this.textBox49.Text = value; }
        }

        public string Text106
        {
            get { return this.textBox51.Text; }
            set { this.textBox51.Text = value; }
        }

        public string Text107
        {
            get { return this.textBox52.Text; }
            set { this.textBox52.Text = value; }
        }

        public string Text108
        {
            get { return this.textBox57.Text; }
            set { this.textBox57.Text = value; }
        }

        public string Text109
        {
            get { return this.textBox59.Text; }
            set { this.textBox59.Text = value; }
        }

        public string Text110
        {
            get { return this.textBox67.Text; }
            set { this.textBox67.Text = value; }
        }

        public string Text111
        {
            get { return this.comboBox38.Text; }
            set { this.comboBox38.Text = value; }
        }

        public string Text112
        {
            get { return this.comboBox39.Text; }
            set { this.comboBox39.Text = value; }
        }

        public string Text113
        {
            get { return this.comboBox40.Text; }
            set { this.comboBox40.Text = value; }
        }

        public string Text114
        {
            get { return this.textBox58.Text; }
            set { this.textBox58.Text = value; }
        }

        #endregion
             

        #region 读写数据库方法
        //基本信息-更新；
        private bool updateSheet7()
        {
            bool result = false; //返回值
            try
            {
                if (textBox53.Text == "") //编号不能为空
                {
                    MessageBox.Show("编号不能为空");
                    return false;
                }

                //更新
                ms7ShuQianPingGu.ID = lOid;  //gOid7
                ms7ShuQianPingGu.iUserID = iUserID; //gOid.ToString();  

                ms7ShuQianPingGu.sBianHao = this.Text36;
                ms7ShuQianPingGu.bWoYuanBingJian = hanZi2Bool(this.Text37);
                ms7ShuQianPingGu.sResult = this.Text38;
                ms7ShuQianPingGu.sBingLiHao = this.Text35;
                ms7ShuQianPingGu.bWoYuanCT = hanZi2Bool(this.Text1);
                ms7ShuQianPingGu.sZhongLiuDaXiao = this.Text41;
                ms7ShuQianPingGu.sJuBuQinFang = this.Text42;
                ms7ShuQianPingGu.bLinBaJieZhuanYi = hanZi2Bool(this.Text43);
                ms7ShuQianPingGu.bZhuanYi = hanZi2Bool(this.Text40);
                ms7ShuQianPingGu.sBuWei = this.Text34;
                ms7ShuQianPingGu.bWoYuanMRI = hanZi2Bool(this.Text39);
                ms7ShuQianPingGu.sMRIZhongliuDaXiao = this.Text45;
                ms7ShuQianPingGu.sMRIJuBuQinFang = this.Text46;
                ms7ShuQianPingGu.bMRILinBaJieZhuanYi = hanZi2Bool(this.Text47);
                ms7ShuQianPingGu.bMRIZhuanYi = hanZi2Bool(this.Text44);
                ms7ShuQianPingGu.sMRIBuWei = this.Text48;
                ms7ShuQianPingGu.bPET = hanZi2Bool(this.Text54);
                ms7ShuQianPingGu.sPETZhongLiuDaXiao = this.Text50;
                ms7ShuQianPingGu.sPETJuBuQinFang = this.Text51;
                ms7ShuQianPingGu.sDaiXieQiangDu = this.Text55;
                ms7ShuQianPingGu.sLinBaZhuanYi = this.Text52;
                ms7ShuQianPingGu.bPETZhuanYi = this.Text49;
                ms7ShuQianPingGu.sPETBuWei = this.Text53;
                ms7ShuQianPingGu.sZhuanYiBuWeiDaiXieQD = this.Text56;
                ms7ShuQianPingGu.sCT = this.Text57;
                ms7ShuQianPingGu.sCN = this.Text54;
                ms7ShuQianPingGu.sCM = this.Text64;
                ms7ShuQianPingGu.sWBC = this.Text59;
                ms7ShuQianPingGu.sHb = this.Text65;
                ms7ShuQianPingGu.sALB = this.Text60;
                ms7ShuQianPingGu.sCEA = this.Text61;
                ms7ShuQianPingGu.sCA125 = this.Text62;
                ms7ShuQianPingGu.sCA199 = this.Text66;
                ms7ShuQianPingGu.sCA724 = this.Text63;
                ms7ShuQianPingGu.sAFP = this.Text20;
                ms7ShuQianPingGu.bGengZhu = hanZi2Bool(this.Text32);
                ms7ShuQianPingGu.bChuXie = hanZi2Bool(this.Text67);
                ms7ShuQianPingGu.bChuanKong = hanZi2Bool(this.Text68);
                ms7ShuQianPingGu.sBMI = this.Text11;
                ms7ShuQianPingGu.sNRS2002 = this.Text29;
                ms7ShuQianPingGu.sTengTongPingFen = this.Text30;
                ms7ShuQianPingGu.sECOG = this.Text33;
                ms7ShuQianPingGu.sXinGongNeng = this.Text19;
                ms7ShuQianPingGu.sFeiGongNeng = this.Text12;
                ms7ShuQianPingGu.sShenGongNeng = this.Text18;
                ms7ShuQianPingGu.sGanGongNeng = this.Text110;
                ms7ShuQianPingGu.sNingXieGongneng = this.Text109;
                ms7ShuQianPingGu.bJiZhenShouShu = hanZi2Bool(this.Text17);
                ms7ShuQianPingGu.sShouShuRiqi = this.Text114;
                ms7ShuQianPingGu.sQiangjingKaiFu = this.Text69;
                ms7ShuQianPingGu.sShuShi = this.Text31;
                ms7ShuQianPingGu.sShouShuTime = this.Text28;
                ms7ShuQianPingGu.sKaiFuWenHeTime = this.Text27;
                ms7ShuQianPingGu.sZhongLiuJuTiWeiZhi = this.Text16;
                ms7ShuQianPingGu.bLianHeQiZhuangQieChu = hanZi2Bool(this.Text70);
                ms7ShuQianPingGu.sChuXieLiang = this.Text26;
                ms7ShuQianPingGu.sFuQiangWuRuan = this.Text71;
                ms7ShuQianPingGu.sFuShenShang = this.Text21;
                ms7ShuQianPingGu.bYingYangGuan = hanZi2Bool(this.Text13);
                ms7ShuQianPingGu.bZaoLou = hanZi2Bool(this.Text72);
                ms7ShuQianPingGu.bShuZhongBingLi = hanZi2Bool(this.Text73);
                ms7ShuQianPingGu.sResult2 = this.Text77;
                ms7ShuQianPingGu.sQieChuQingkong = this.Text74;
                ms7ShuQianPingGu.sLinBaJieQingShao = this.Text75;
                ms7ShuQianPingGu.sTeShuShuoMing = this.Text78;
                ms7ShuQianPingGu.bERAS = hanZi2Bool(this.Text76);
                ms7ShuQianPingGu.bICUJianHu = hanZi2Bool(this.Text77);
                ms7ShuQianPingGu.sJianHuTime = this.Text37;
                ms7ShuQianPingGu.sJinShuiShiJian = this.Text14;
                ms7ShuQianPingGu.sTongQiTime = this.Text24;
                ms7ShuQianPingGu.sPaiBianTime = this.Text80;
                ms7ShuQianPingGu.sFuTongHuanJieTime = this.Text6;
                ms7ShuQianPingGu.sNiaoGuanBaChuTime = this.Text23;
                ms7ShuQianPingGu.sYinLiuGuanBaChuTime = this.Text15;
                ms7ShuQianPingGu.sXiaChuangTime = this.Text9;
                ms7ShuQianPingGu.sJinShi = this.Text10;
                ms7ShuQianPingGu.bChangNeiYingYang = hanZi2Bool(this.Text113);
                ms7ShuQianPingGu.sChangNeiYingYangZhiChiTime = this.Text1;
                ms7ShuQianPingGu.sTPNtime = this.Text2;
                ms7ShuQianPingGu.sShuHouChuXue = this.Text81;
                ms7ShuQianPingGu.sFuQiangGanRuan = this.Text82;
                ms7ShuQianPingGu.sQieKouGanRuan = this.Text84;
                ms7ShuQianPingGu.sWenHeKouLou = this.Text85;
                ms7ShuQianPingGu.sChangGenZhu = this.Text86;
                ms7ShuQianPingGu.sWeiTan = this.Text5;
                ms7ShuQianPingGu.sFeiBuFanRuan = this.Text83;
                ms7ShuQianPingGu.sDiDanBaiXueZheng = this.Text8;
                ms7ShuQianPingGu.sWEiGuanTuoChu = this.Text98;
                ms7ShuQianPingGu.sYingYangGuanTuoChu = this.Text90;
                ms7ShuQianPingGu.sZaoKouBingFaZheng = this.Text87;
                ms7ShuQianPingGu.b2thShouShu = hanZi2Bool(this.Text4);
                ms7ShuQianPingGu.sShouShuTime2 = this.Text88;
                ms7ShuQianPingGu.sShouShuFangShi = this.Text7;
                ms7ShuQianPingGu.sJieJueWenTi = this.Text3;
                ms7ShuQianPingGu.sShuHouBingLiZhengDuan = this.Text102;
                ms7ShuQianPingGu.sFenHuaChengDu = this.Text101;
                ms7ShuQianPingGu.sJinRunShenDu = this.Text91;
                ms7ShuQianPingGu.sMaiGuanAiShuan = this.Text100;
                ms7ShuQianPingGu.sShenJingQinFang = this.Text99;
                ms7ShuQianPingGu.sAiJieJie = this.Text98;
                ms7ShuQianPingGu.sZongLinBaJieShu = this.Text104;
                ms7ShuQianPingGu.sZhuanyiLinBaJieShu = this.Text93;
                ms7ShuQianPingGu.sMSI = this.Text92;
                ms7ShuQianPingGu.sHER_2 = this.Text106;
                ms7ShuQianPingGu.sP53 = this.Text103;
                ms7ShuQianPingGu.sKi_67 = this.Text105;
                ms7ShuQianPingGu.sK_RAS = this.Text95;
                ms7ShuQianPingGu.sN_RAS = this.Text94;
                ms7ShuQianPingGu.sShouHouBingLiFenQi = this.Text107;
                ms7ShuQianPingGu.sMSIQueZheng = this.Text111;
                ms7ShuQianPingGu.sJiYinJianCe = this.Text112;
                ms7ShuQianPingGu.sChuYuanTime = this.Text97;
                ms7ShuQianPingGu.sChuYuanQingKong = this.Text96;
                ms7ShuQianPingGu.sYiLiaoFeiYong = this.Text108;

                bool ret = false;
                if (false == dos7ShuQianPingGu.Exists(lOid)) //若无记录，则点击保存也视为增加
                {
                    ret = dos7ShuQianPingGu.Add(ms7ShuQianPingGu);
                    
                }
                else  //更新
                {
                    ret = dos7ShuQianPingGu.Update(ms7ShuQianPingGu);
                }

                               

                if (true == ret) //显示
                {
                    outputLabel("Sheet7更新成功");
                    result = true;
                }
                else
                {
                    outputLabel("Sheet7更新失败");
                    result = false;
                }
            }
            catch (Exception ex)
            {
                outputLabel("Sheet7更新失败，" + ex.Message);
                return false;
            }

            if (0 == lOid) //新建后则禁用“新建”按键，防止“新建”后，连续两次点击“保存”则存为两条
            {
                buttonUpdate.Enabled = false;
            }

            return result;
        }
        #endregion
        //保存
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updateSheet7();

            //foreach (Control i in groupBox1.Controls)  //清空和禁用
            //{
            //    if (i is TextBox)
            //    {
            //        i.Text = "";
            //        i.Enabled = false;
            //    }
            //    else if (i is ComboBox)
            //    {
            //        i.Text = "";
            //        i.Enabled = false;
            //    }
            //}

            outputLabel("保存成功");
            

        }
        //取消
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //新建
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            foreach (Control i in groupBox1.Controls)  //清空和使能
                   {
                       if (i is TextBox)
                       {
                           i.Text = "";
                           i.Enabled = true;
                       }
                       else if (i is ComboBox)
                       {
                           i.Text = "";
                           i.Enabled = true;
                       }
                   }
            lOid = 0; //恢复默认值, iUserID不变

            outputLabel("新建成功");

        }

        private void FormSheet7_Load(object sender, EventArgs e)
        {
            initDo();
        }

    }
}
