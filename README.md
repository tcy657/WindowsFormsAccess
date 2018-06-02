# WindowsFormsAccess
WindowsFormsAccess

git常用命令
推送远程仓库 git push origin master

1 增加类定义代替数据库公共操作dll引用
2 替换一个sql变量

公共结构体
1   struct {
    int status; //
    int oid1; //sheet1
    int oid2; //sheet2
    int oid3; //sheet3
    int oid4; //sheet4
    int oid5; //sheet5
    int oid6; //sheet6
    };

【问题】
【待确认】sheet7中“术后病理分期”应为”术后病理分析“？ 11:54 2018/6/2
【待完成】是或否转换为true和false
【待完成】查询功能
【待完成】delete待增加其他Sheet的动作
【待完成】所有的下拉框禁止输入，只能选择
【待完成】增加try-catch捕获错误
【待完成】sheet7未实现
【待完成】excel导出datagridview功能
    ——https://jingyan.baidu.com/article/a24b33cd0682cd19fe002bb0.html C# 怎么导出dataGridView中的值到Excel
    --** https://zhidao.baidu.com/question/1817909972118765668.html c#如何把datagridview导出到excel
    --*** https://blog.csdn.net/u011981242/article/details/51083335 C# DataGridView导出Excel的两种经典方法
    ——https://blog.csdn.net/licl19870605/article/details/5260795  C#实现Access导入导出Excel
    --https://blog.csdn.net/angel20082008/article/details/51749780 C# 讲解五种导出access数据到Excel文件格式中
【待完成】全局“刷新”按键功能待完善
【优化】增加日志打印，记录操作步骤和出错信息
【优化】将detail的dataGridView操作按键统一，放在Tabcontrol2控件旁边。 22:15 2018/5/27
【优化】output()都用outputLabel()
【优化】sheet页的禁用和使能  23:20 2018-5-30
【优化】美化界面，菜单/工具栏/状态栏/右键（可选）
【优化，界面】分组/分块，增默认值
【优化】切换到sheet7时，禁用“保存”按键
【优化】sheet7新建后不禁用控件，其他禁用。
【优化】
【优化】
【优化】
【优化】字段类型是否准确，如时间，选日期的话可以用控件，鼠标就可以完成操作
1 sheet7有100多个字段，不好维护，建议拆分多个sheet页
2 sheet2字段疗程、剂量、方案等重复
3 sheet3、sheet4中住院号与sheet1中重复，没必要显示？
4 sheet3、sheet4中省略号“……”代表什么意思？ 
5 字段太多，界面开发已完成，进入后期核对数据准确性阶段了，最好给出一份样本数据   

【注意事项】
4 新增Sheet页流程
	1）数据库业务层代码，增加/删除/修改
	2）操作页面按键代码，
	3）总页面代码。
		（1）表头 --对应数据表增加
9 重要基准参考：https://blog.csdn.net/bcbobo21cn/article/details/52201955
在窗体中更新的方法
    private void button3_Click(object sender, EventArgs e)  
    {  
        if (dataGridView1.SelectedRows.Count < 1 || dataGridView1.SelectedRows[0].Cells[1].Value == null)  
        {  
            MessageBox.Show("没有选中行。", "M营销");  
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
8 时间格式转换
     model.dRuYuanShiJian = dtp1time9Sheet1.Value;
     dtp1time9Sheet1.Value = Convert.ToDateTime(model.dRuYuanShiJian);
7 隐藏/删除()remove) tab页后，索引会发生变化。 20:12 2018/5/29
6 在同一份代码中，互相忽略SVN和GIT，可同时用这两者管理	20:11 2018/5/29
5 tabControl1对应表  -tabControl2 --未成功
index0 -首页            -- 2
index3 -员工基本信息，2  --3
index5 -3术后辅助化疗    --0
index6 -4随诊情况       --1
index7 -7               --6
index8 -6起病情况       --5

		
3 获取 object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //更新全局oid
2 dataGridView有绑定数据源后，设表头才有效。
1 数据库变量使用横线-做为字段名，生成的类文件编译报错。
    ——变量命名只能用字母、数字、下划线    
2 用python处理生成的数据库文件
3 数据库操作类中出现"int?"，未影响编译和运行。 -原因待确定。    