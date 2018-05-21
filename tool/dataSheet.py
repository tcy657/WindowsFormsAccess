# -*- coding:gb2312 -*-
import time
import logging
import random
import os
import threading
import sys
import getpass
import re
import string
import datetime
import traceback
import codecs

#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#�ݹ�ɾ��·�����ļ����ļ���
def delete_file_folder(src):
  '''delete files and folders'''
  if os.path.isfile(src): #��Ϊ�ļ�
    os.remove(src)
  elif os.path.isdir(src): #��Ϊ���ļ���
    for item in os.listdir(src):
        itemsrc=os.path.join(src,item)
        delete_file_folder(itemsrc)
    os.rmdir(src)
#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#############################################################################################
#def main():
if __name__ == "__main__":
  #����DALĿ¼�£�����DAL�ļ���
  #����0 
  rootDir = os.path.dirname(os.path.realpath(sys.argv[0] )) +'\\' #��ȡ·��,����D:/FHBD/xx/
  if not os.path.exists(rootDir):
    print('�����˳�����·�������ڣ�' + rootDir)
    sys.exit(1) 
  
  resultPath = rootDir + "DAL\\"
  if  os.path.exists(resultPath):
    delete_file_folder(resultPath)
  os.makedirs(resultPath)
  
  flag1 = False #���ඨ��󣬷���{������
                #�����¹��캯��
  
  list = os.listdir(rootDir)
  for i in range(0,len(list)):
         filePath = os.path.join(rootDir,list[i])
         if os.path.isfile(filePath) and filePath.endswith('.cs'): #ֻ����cs�ļ�
            fileName = os.path.basename(filePath) 
            with codecs.open(filePath, 'r', 'utf-8') as r:
                print(filePath)
                lines = r.readlines()
                with codecs.open(resultPath + fileName,'w', 'utf-8') as writeFile:
                    for sLine in lines:
                       if 'DbHelperSQL' in sLine:
                           writeFile.write(sLine.replace('DbHelperSQL','DbHelperOleDb'))
                       elif 'public partial class' in sLine:
                           className = sLine.split(' ')[-1]  #Users
                           className = className.strip()  #ȥ���ո�ͻ��з�
                           writeFile.write(sLine)
                           flag1 = True #�ڷ���{����봴����
                       elif True == flag1:
                           if '{' in  sLine:
                                writeFile.write(sLine)
                                writeFile.write('       private AccessHelper DbHelperOleDb;\r\n') #������
                                writeFile.write('       public ' + className +'(string dbPath)\r\n')  #�������Ĺ��캯����Ԥ��
                                writeFile.write('       {\r\n')
                                writeFile.write('            DbHelperOleDb = new AccessHelper(dbPath);\r\n')
                                writeFile.write('       }\r\n')
                                flag1 = False #�ڷ���{����봴����
                       elif '{}' in  sLine: #�ڹ��캯���У�ʵ������
                                writeFile.write('       {\r\n')
                                writeFile.write('            DbHelperOleDb = new AccessHelper();\r\n')
                                writeFile.write('       }\r\n')
                       else:
                           writeFile.write(sLine)

  #time.sleep(1)
  a=input("�������������˳���")
  sys.exit(0)
