using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAccess
{
    public partial class FormSheet7 : Form
    {
        public FormSheet7()
        {
            InitializeComponent();
        }

        #region 控件值可读写
        private int iid;
        private string siUserID;
  
        public int lOid  //local id
        {
            get { return this.iid; }
            set { this.iid = value; }
        }

        public string iUserID  //iUserID
        {
            get { return this.siUserID; }
            set { this.siUserID = value; }
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

    }
}
