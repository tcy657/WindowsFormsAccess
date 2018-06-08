# -*- coding:gb2312 -*-
import time
import logging
import shutil
import random
import os
import time
import sys

#get username
import getpass

#get pid, 2016/8/9 18:45:00
import re
import string

#get new testLog, 2016/8/10 14:51:29
import datetime

#打印异常，2016/10/18
import traceback

#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#获取脚本文件的当前路径，类D:\FHATP\
def cur_file_dir():
  try:
     #获取脚本路径
     path = sys.path[0]
     path = path + '\\'
     #print(path +'123')
     #判断为脚本文件还是py2exe编译后的文件;
     #1) py脚本文件，则返回脚本的目录,如D:\FHATP
     #2) py2exe编译后的exe，则返回EXE文件路径,如D:\FHATP\xx.exe
     if os.path.isdir(path):
         return path
     elif os.path.isfile(path):
         return os.path.dirname(path)
  except Exception:
    exstr = traceback.format_exc()
    print( "cur_file_dir(), error!" + '\n' + exstr)
    pass  #空语句 do nothing 
    return 0 #不存在 
#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#def main():
if __name__ == "__main__":
 try:  
  #检查4，工具根目录下完整性清单
  arrOtnmListAll =["WindowsFormsAccess.exe",           
  "version",
  "forSetupFactory\\dataBase\\linChuang.accdb",
  "forSetupFactory\\doc",
  "forSetupFactory\\images\\1.gif",
  "forSetupFactory\\images\\2.gif",
  "forSetupFactory\\images\\3.gif",
  "forSetupFactory\\images\\4.gif",
  "forSetupFactory\\images\\5.gif",
  "forSetupFactory\\images\\6.gif",
  "forSetupFactory\\ini\\config.xml",
  "forSetupFactory\\log" ]  

  #获取根目录工作路径
  rootPath = cur_file_dir() #类似D:/jenkins/workspace/xx/
  outputBinPath =rootPath +"..\\outputBin\\"
  print('根目录路径-' + rootPath)

  print("检查根目录下工具的完整性")
  sameFlag=True  #文件是否完整，是-True; 否-false
  for fileComp in arrOtnmListAll: #检查文件是否存在
       fileCompPath =outputBinPath +fileComp; 
       if not os.path.exists(fileCompPath):   #arrOtnmListAll(i)是否存在
           sameFlag=False #文件不存在
           break

  if False == sameFlag: #文件缺失，程序退出！
       print("关键文件缺失，程序退出！\n--" +fileComp) 
       #tkMessageBox.showinfo(title=u'配置对比提示!', message=u"关键文件缺失，程序退出！--" +fileCompPath)
       logging.shutdown()
       sys.exit(1)  #退出
  print("根目录下工具的完整性检查通过，可以打包!")
  
  a=input("输入任意内容退出！")
  sys.exit(1)  #退出
 except Exception:
    exstr = traceback.format_exc()
    print( "main(), error!" + '\n' + exstr)
    pass  #空语句 do nothing 