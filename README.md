# WindowsFormsAccess
git��������
����Զ�ֿ̲� git push origin master

1 �����ඨ��������ݿ⹫������dll����
2 �滻һ��sql����

�����⡿
������ɡ����е��������ֹ���룬ֻ��ѡ��
*�ݴ�try,����try-catch�������
*ʹ���ĵ�

���Ż���״̬����ʾ��Ϊ�Ѻ�
���Ż���������־��ӡ����¼��������ͳ�����Ϣ
���Ż���ɾ���û�������Ϣʱ����֧�ֶ���ɾ����ֻ��ɾ����һ��
���Ż������桿����/�ֿ飬��Ĭ��ֵ
���Ż�����¼��֤
*�˵���/������
���Ż���sheet��ʱ��ʹ�ÿؼ��������ı���
�����⡿�������ʱ������ COM �๤���� CLSID Ϊ {00024500-0000-0000-C000-000000000046} �����ʱʧ�ܣ�ԭ���ǳ������´���: 80040154��
���Ż���dateTimePicker�ؼ�ͬʱ����ʱ������ڡ� https://jingyan.baidu.com/article/6fb756ec9e6215241858fbbd.html
���Ż����ֶ������Ƿ�׼ȷ����ʱ�䣬ѡ���ڵĻ������ÿؼ������Ϳ�����ɲ���
1 sheet7��100����ֶΣ�����ά���������ֶ��sheetҳ
2 sheet2�ֶ��Ƴ̡��������������ظ�
3 sheet3��sheet4��סԺ����sheet1���ظ���û��Ҫ��ʾ��
4 sheet3��sheet4��ʡ�Ժš�����������ʲô��˼�� 
5 �ֶ�̫�࣬���濪������ɣ�������ں˶�����׼ȷ�Խ׶��ˣ���ø���һ����������   
����ȷ�ϡ�sheet7�С���������ڡ�ӦΪ��������������� 11:54 2018/6/2

��ע�����
13 �����ṹ��
   struct {
    int status; //
    int oid1; //sheet1
    int oid2; //sheet2
    int oid3; //sheet3
    int oid4; //sheet4
    int oid5; //sheet5
    int oid6; //sheet6
    };

12 excel����datagridview����
    ����https://jingyan.baidu.com/article/a24b33cd0682cd19fe002bb0.html C# ��ô����dataGridView�е�ֵ��Excel
    --** https://zhidao.baidu.com/question/1817909972118765668.html c#��ΰ�datagridview������excel
    --*** https://blog.csdn.net/u011981242/article/details/51083335 C# DataGridView����Excel�����־��䷽��
    --https://bbs.csdn.net/topics/392069817 Excel������sheet
    ����https://blog.csdn.net/licl19870605/article/details/5260795  C#ʵ��Access���뵼��Excel
    --https://blog.csdn.net/angel20082008/article/details/51749780 C# �������ֵ���access���ݵ�Excel�ļ���ʽ��
4 ����Sheetҳ����
	1�����ݿ�ҵ�����룬����/ɾ��/�޸�
	2������ҳ�水�����룬
	3����ҳ����롣
		��1����ͷ --��Ӧ���ݱ�����
11 �̶����ڴ�С����ֹ�Դ��ڵ����ɵ����ˡ�
   1)�ҵ���FormBorderStyle��ѡ���ѡ���б���ѡ��FixedDialog���������Ϳ���
   2�����ش��ڵ���󻯺���С����ť��ѡ���С�MaximizeBox����MinimizeBox�����޸ġ�false����
10 sql = " where sProID in (select CONVERT(varchar(100), iSN) from ccmGroup where sCPXBH='" + dlArea2.SelectedValue + "')"
9 ��Ҫ��׼�ο���https://blog.csdn.net/bcbobo21cn/article/details/52201955
�ڴ����и��µķ���
    private void button3_Click(object sender, EventArgs e)  
    {  
        if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)  
        {  
            MessageBox.Show("û��ѡ���С�", "MӪ��");  
            return;  
        }  
        //f3.Owner = this;  
        DataTable dt = new DataTable();  
        object oid = dataGridView1.SelectedRows[0].Cells[0].Value;  
        string sql = "select * from ycyx where ID=" + oid;  
        dt = achelp.GetDataTableFromDB(sql);  
        f3 = new Form3();  
        f3.id = int.Parse(oid.ToString());  
        //f3.id = 2;  
        f3.Text1 = dt.Rows[0][1].ToString();  
        f3.Text2 = dt.Rows[0][2].ToString();  
        f3.Text3 = dt.Rows[0][3].ToString();  
        f3.Text4 = dt.Rows[0][4].ToString();  
        f3.Text5 = dt.Rows[0][5].ToString();  
        f3.Text6 = dt.Rows[0][6].ToString();  
      
        f3.ShowDialog();  
          
    }  
8 ʱ���ʽת��
     model.dRuYuanShiJian = dtp1time9Sheet1.Value;
     dtp1time9Sheet1.Value = Convert.ToDateTime(model.dRuYuanShiJian);
7 ����/ɾ��()remove) tabҳ�������ᷢ���仯�� 20:12 2018/5/29
6 ��ͬһ�ݴ����У��������SVN��GIT����ͬʱ�������߹���	20:11 2018/5/29
3 ��ȡ object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //����ȫ��oid
2 dataGridView�а�����Դ�����ͷ����Ч��
1 ���ݿ����ʹ�ú���-��Ϊ�ֶ��������ɵ����ļ����뱨��
    ������������ֻ������ĸ�����֡��»���    
2 ��python�������ɵ����ݿ��ļ�
3 ���ݿ�������г���"int?"��δӰ���������С� -ԭ���ȷ����    