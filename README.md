# WindowsFormsAccess
WindowsFormsAccess

git常用命令
推送远程仓库 git push origin master


1 增加类定义代替数据库公共操作dll引用
2 替换一个sql变量
3 增加一个GetModelByUserID()的方法

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
1 sheet7有100多个字段，不好维护，建议拆分多个sheet页
2 sheet2字段疗程、剂量、方案等重复
3 sheet3、sheet4中住院号与sheet1中重复，没必要显示？
4 sheet3、sheet4中省略号“……”代表什么意思？ 
5 字段太多，界面开发已完成，进入后期核对数据准确性阶段了，最好给出一份样本数据   

【注意事项】
1 数据库变量使用横线-做为字段名，生成的类文件编译报错。
    ——变量命名只能用字母、数字、下划线    
2 用python处理生成的数据库文件
3 数据库操作类中出现"int?"，未影响编译和运行。 -原因待确定。    