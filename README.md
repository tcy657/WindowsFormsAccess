# WindowsFormsAccess
WindowsFormsAccess

git��������
����Զ�ֿ̲� git push origin master

1 �����ඨ��������ݿ⹫������dll����
2 �滻һ��sql����

�����ṹ��
1   struct {
    int status; //
    int oid1; //sheet1
    int oid2; //sheet2
    int oid3; //sheet3
    int oid4; //sheet4
    int oid5; //sheet5
    int oid6; //sheet6
    };

�����⡿
����ȷ�ϡ�sheet7�С���������ڡ�ӦΪ��������������� 11:54 2018/6/2
������ɡ��ǻ��ת��Ϊtrue��false
������ɡ���ѯ����
������ɡ�delete����������Sheet�Ķ���
������ɡ����е��������ֹ���룬ֻ��ѡ��
������ɡ�����try-catch�������
������ɡ�sheet7δʵ��
������ɡ�excel����datagridview����
    ����https://jingyan.baidu.com/article/a24b33cd0682cd19fe002bb0.html C# ��ô����dataGridView�е�ֵ��Excel
    --** https://zhidao.baidu.com/question/1817909972118765668.html c#��ΰ�datagridview������excel
    --*** https://blog.csdn.net/u011981242/article/details/51083335 C# DataGridView����Excel�����־��䷽��
    ����https://blog.csdn.net/licl19870605/article/details/5260795  C#ʵ��Access���뵼��Excel
    --https://blog.csdn.net/angel20082008/article/details/51749780 C# �������ֵ���access���ݵ�Excel�ļ���ʽ��
������ɡ�ȫ�֡�ˢ�¡��������ܴ�����
���Ż���������־��ӡ����¼��������ͳ�����Ϣ
���Ż������桿����/�ֿ飬��Ĭ��ֵ
���Ż���ɾ���û�������Ϣʱ����֧�ֶ���ɾ����ֻ��ɾ����һ��
��ѯ�����3��
����
�����Զ�
�˵���
������/״̬��/�Ҽ�����ѡ��
�ݴ�try
��־
��������/����
�����⡿�������ʱ������ COM �๤���� CLSID Ϊ {00024500-0000-0000-C000-000000000046} �����ʱʧ�ܣ�ԭ���ǳ������´���: 80040154��
���Ż����ֶ������Ƿ�׼ȷ����ʱ�䣬ѡ���ڵĻ������ÿؼ������Ϳ�����ɲ���
1 sheet7��100����ֶΣ�����ά���������ֶ��sheetҳ
2 sheet2�ֶ��Ƴ̡��������������ظ�
3 sheet3��sheet4��סԺ����sheet1���ظ���û��Ҫ��ʾ��
4 sheet3��sheet4��ʡ�Ժš�����������ʲô��˼�� 
5 �ֶ�̫�࣬���濪������ɣ�������ں˶�����׼ȷ�Խ׶��ˣ���ø���һ����������   

��ע�����
4 ����Sheetҳ����
	1�����ݿ�ҵ�����룬����/ɾ��/�޸�
	2������ҳ�水�����룬
	3����ҳ����롣
		��1����ͷ --��Ӧ���ݱ�����
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
5 tabControl1��Ӧ��  -tabControl2 --δ�ɹ�
index0 -��ҳ            -- 2
index3 -Ա��������Ϣ��2  --3
index5 -3����������    --0
index6 -4�������       --1
index7 -7               --6
index8 -6�����       --5

		
3 ��ȡ object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //����ȫ��oid
2 dataGridView�а�����Դ�����ͷ����Ч��
1 ���ݿ����ʹ�ú���-��Ϊ�ֶ��������ɵ����ļ����뱨��
    ������������ֻ������ĸ�����֡��»���    
2 ��python�������ɵ����ݿ��ļ�
3 ���ݿ�������г���"int?"��δӰ���������С� -ԭ���ȷ����    