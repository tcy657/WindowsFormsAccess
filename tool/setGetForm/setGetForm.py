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

  filePath = 'config.ini'
  fileName = 'new.txt'
  i = 0; 
  #��ȡ�ؼ������ļ�
  with codecs.open(filePath, 'r', 'utf-8') as r:
      lines = r.readlines()
      #����������ؼ������ļ�
      with codecs.open(fileName,'w', 'utf-8') as writeFile:
          for sLine in lines:
                 i = i + 1
                 sLine = sLine.strip()  #ȥ���ո�ͻ��з�
                 writeFile.write('        public string Text' + str(i) +'\r\n')
                 writeFile.write('        {\r\n')
                 writeFile.write('            get { return ' + sLine + '.Text; }\r\n')
                 writeFile.write('            set { ' + sLine + '.Text = value; }\r\n')
                 writeFile.write('        }\r\n')
                 writeFile.write('\r\n') #��һ������

  #time.sleep(1)
  a=input("�������������˳���")
  sys.exit(0)
