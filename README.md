# WindowsFormsAccess
WindowsFormsAccess

git��������
����Զ�ֿ̲� git push origin master

1 �����ඨ��������ݿ⹫������dll����
2 �滻һ��sql����
3 ����һ��GetModelByUserID()�ķ���

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

sheet5�ļ�������δʵ��
excel��������
ȫ�֡�ˢ�¡��������ܴ�����
���Ż�����detail��dataGridView��������ͳһ������Tabcontrol2�ؼ��Աߡ� 22:15 2018/5/27
���Ż�����������tabcontrol������δ���  23:01 2018/5/27
delete����������Sheet�Ķ���
���Ż���
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
5 tabControl1��Ӧ��  -tabControl2
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