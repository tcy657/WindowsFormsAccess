# WindowsFormsAccess
git常用命令
推送远程仓库 git push origin master

1 增加类定义代替数据库公共操作dll引用
2 替换一个sql变量

【问题】
【优化】提供两个写日志的函数，一个专门写错误，界面太窄
【优化】增加锁屏的功能
【优化】增加登录帐号修改功能

*容错try,增加try-catch捕获错误
导excel的sheet页带上字母
	提供初始数据库
【优化，急】限制只打开一个窗口
【优化，急】非功能问题不改，不增加

【优化】Tab页增加颜色
【优化】tab1使用按键代替标签页，区别tab2
【优化】增加日志打印，记录操作步骤和出错信息
【优化】删除用户基本信息时，不支持多条删除。只能删除第一条
【优化，界面】分组/分块，增默认值
*菜单栏/工具栏
【优化】sheet的时间使用控件，代替文本框
【问题】点击导出时，检索 COM 类工厂中 CLSID 为 {00024500-0000-0000-C000-000000000046} 的组件时失败，原因是出现以下错误: 80040154。
【优化】dateTimePicker控件同时设置时间和日期。 https://jingyan.baidu.com/article/6fb756ec9e6215241858fbbd.html
【优化】字段类型是否准确，如时间，选日期的话可以用控件，鼠标就可以完成操作
1 sheet7有100多个字段，不好维护，建议拆分多个sheet页
2 sheet2字段疗程、剂量、方案等重复
3 sheet3、sheet4中住院号与sheet1中重复，没必要显示？
4 sheet3、sheet4中省略号“……”代表什么意思？
5 字段太多，界面开发已完成，进入后期核对数据准确性阶段了，最好给出一份样本数据
【待确认】sheet7中“术后病理分期”应为”术后病理分析“？ 11:54 2018/6/2

【注意事项】
17 如何让表编号从1开始？
    ——选择该表，复制-粘贴，另存为新表。“粘贴选项”选择只粘贴结构。就得到编号从1开始的新表。
    ——删除原表，重命名新表为原表。
    3）最后对数据库执行压缩命令。
16 access数据库删除数据后文件大小不变，为什么？
    ——因为你没有对数据重新进行清理。三个方法：
    1）打开MDB文件手动压缩。文件->管理->压缩和修复数据库。
    2）打开MDB后，在工具-选项-常规中勾上“关闭时压缩”，则会自动压缩。
    3）先建立一个同名空白数据库，放在另一个文件夹下。
       接着打开该空白数据库，导入原数据库全部有用的对象
      （包括：表、窗体、查询、模块、页、宏，无用的不要导入）
15 //步骤5，自动更新编译时间，指示版本号
            string ver = "ver" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); //获取程序集的版本号, V1.0
            string timeComp = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString();    //获取程序集的最后编译时间，日期+时间
            //string timeComp = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToShortDateString();  //编译日期,
            toolTip1.SetToolTip(lblVersion, ver + ", SVNxx, by cytao@fiberhome.com" + ", " + timeComp);              //ver 1.0.2, SVN41, by cytao@fiberhome.com, 2016.4

14 【不成功】清空access时，因没有truncate这样的语句的，你这种必须分2句话
    delete from 表
    alter table 表 alter column id counter(1,1)
13 公共结构体
   struct {
    int status; //
    int oid1; //sheet1
    int oid2; //sheet2
    int oid3; //sheet3
    int oid4; //sheet4
    int oid5; //sheet5
    int oid6; //sheet6
    };

12 excel导出datagridview功能
    ——https://jingyan.baidu.com/article/a24b33cd0682cd19fe002bb0.html C# 怎么导出dataGridView中的值到Excel
    --** https://zhidao.baidu.com/question/1817909972118765668.html c#如何把datagridview导出到excel
    --*** https://blog.csdn.net/u011981242/article/details/51083335 C# DataGridView导出Excel的两种经典方法
    --https://bbs.csdn.net/topics/392069817 Excel创建多sheet
    ——https://blog.csdn.net/licl19870605/article/details/5260795  C#实现Access导入导出Excel
    --https://blog.csdn.net/angel20082008/article/details/51749780 C# 讲解五种导出access数据到Excel文件格式中
4 新增Sheet页流程
	1）数据库业务层代码，增加/删除/修改
	2）操作页面按键代码，
	3）总页面代码。
		（1）表头 --对应数据表增加
11 固定窗口大小，禁止对窗口的自由调整了。
   1)找到【FormBorderStyle】选项，在选项列表中选择【FixedDialog】，这样就可以
   2）隐藏窗口的最大化和最小化按钮，选项中【MaximizeBox】【MinimizeBox】都修改【false】。
10 sql = " where sProID in (select CONVERT(varchar(100), iSN) from ccmGroup where sCPXBH='" + dlArea2.SelectedValue + "')"
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
3 获取 object oid = dataGridView1.SelectedRows[0].Cells[0].Value;
            gOid = Convert.ToInt32(oid);  //更新全局oid
2 dataGridView有绑定数据源后，设表头才有效。
1 数据库变量使用横线-做为字段名，生成的类文件编译报错。
    ——变量命名只能用字母、数字、下划线
2 用python处理生成的数据库文件
3 数据库操作类中出现"int?"，未影响编译和运行。 -原因待确定。