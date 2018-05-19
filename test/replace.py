# -*- coding:gb2312 -*-
import time
import logging
import random
import os
import time
import threading
import sys

#get username
import getpass
import re
import sys
import string

#get new testLog, 2016/8/10 14:51:29
import datetime

#��ӡ�쳣��2016/10/18
import traceback

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

  #����0 ��ȡ���������׵�·��
  strUser = getpass.getuser()  #��ȡ��ǰ��¼�û���
  #��ȡ��ǰ·����Ϊ���õش�ͼ�λ�������������������ʹ�á�����Ӳ����������У���ֹ�ֹ���������
  rootdir = os.path.dirname(os.path.realpath(sys.argv[0] )) +'\\' #����D:/jenkins/xx/
  if not os.path.exists(rootdir):
    print('�����˳�����·�������ڣ�' + rootdir)
    sys.exit(1) 
  
  resultPath = rootdir + "result\\"
  if  os.path.exists(resultPath):
    delete_file_folder(resultPath)
  os.makedirs(resultPath)
  
  list = os.listdir(rootdir)
  for i in range(0,len(list)):
         filePath = os.path.join(rootdir,list[i])
         if os.path.isfile(filePath) and 'cs' in filePath:
            fileName = os.path.basename(filePath) 
            with open(filePath, 'r') as r:
                pass
                lines = r.readlines()
                #with open(resultPath + fileName,'w') as w:
                #    for l in lines:
                #       if 'DbHelperSQL' in l:
                #           w.write(l.replace('DbHelperSQL','DbHelperOleDb'))
                #       else:
                #           w.write(l)

  time.sleep(1)
  sys.exit(0)
