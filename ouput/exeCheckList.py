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

#��ӡ�쳣��2016/10/18
import traceback

#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#��ȡ�ű��ļ��ĵ�ǰ·������D:\FHATP\
def cur_file_dir():
  try:
     #��ȡ�ű�·��
     path = sys.path[0]
     path = path + '\\'
     #print(path +'123')
     #�ж�Ϊ�ű��ļ�����py2exe�������ļ�;
     #1) py�ű��ļ����򷵻ؽű���Ŀ¼,��D:\FHATP
     #2) py2exe������exe���򷵻�EXE�ļ�·��,��D:\FHATP\xx.exe
     if os.path.isdir(path):
         return path
     elif os.path.isfile(path):
         return os.path.dirname(path)
  except Exception:
    exstr = traceback.format_exc()
    print( "cur_file_dir(), error!" + '\n' + exstr)
    pass  #����� do nothing 
    return 0 #������ 
#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#def main():
if __name__ == "__main__":
 try:  
  #���4�����߸�Ŀ¼���������嵥
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

  #��ȡ��Ŀ¼����·��
  rootPath = cur_file_dir() #����D:/jenkins/workspace/xx/
  outputBinPath =rootPath +"..\\outputBin\\"
  print('��Ŀ¼·��-' + rootPath)

  print("����Ŀ¼�¹��ߵ�������")
  sameFlag=True  #�ļ��Ƿ���������-True; ��-false
  for fileComp in arrOtnmListAll: #����ļ��Ƿ����
       fileCompPath =outputBinPath +fileComp; 
       if not os.path.exists(fileCompPath):   #arrOtnmListAll(i)�Ƿ����
           sameFlag=False #�ļ�������
           break

  if False == sameFlag: #�ļ�ȱʧ�������˳���
       print("�ؼ��ļ�ȱʧ�������˳���\n--" +fileComp) 
       #tkMessageBox.showinfo(title=u'���öԱ���ʾ!', message=u"�ؼ��ļ�ȱʧ�������˳���--" +fileCompPath)
       logging.shutdown()
       sys.exit(1)  #�˳�
  print("��Ŀ¼�¹��ߵ������Լ��ͨ�������Դ��!")
  
  a=input("�������������˳���")
  sys.exit(1)  #�˳�
 except Exception:
    exstr = traceback.format_exc()
    print( "main(), error!" + '\n' + exstr)
    pass  #����� do nothing 