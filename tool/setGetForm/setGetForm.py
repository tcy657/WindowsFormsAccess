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
#递归删除路径下文件和文件夹
def delete_file_folder(src):
  '''delete files and folders'''
  if os.path.isfile(src): #若为文件
    os.remove(src)
  elif os.path.isdir(src): #若为子文件夹
    for item in os.listdir(src):
        itemsrc=os.path.join(src,item)
        delete_file_folder(itemsrc)
    os.rmdir(src)
#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#############################################################################################
#def main():
if __name__ == "__main__":
  #放在DAL目录下，生成DAL文件夹
  #步骤0 
  rootDir = os.path.dirname(os.path.realpath(sys.argv[0] )) +'\\' #获取路径,类似D:/FHBD/xx/
  if not os.path.exists(rootDir):
    print('程序退出，根路径不存在：' + rootDir)
    sys.exit(1) 

  filePath = 'config.ini'
  fileName = 'new.txt'
  i = 0; 
  #读取控件配置文件
  with codecs.open(filePath, 'r', 'utf-8') as r:
      lines = r.readlines()
      #遍历并保存控件属性文件
      with codecs.open(fileName,'w', 'utf-8') as writeFile:
          for sLine in lines:
                 i = i + 1
                 sLine = sLine.strip()  #去掉空格和换行符
                 writeFile.write('        public string Text' + str(i) +'\r\n')
                 writeFile.write('        {\r\n')
                 writeFile.write('            get { return ' + sLine + '.Text; }\r\n')
                 writeFile.write('            set { ' + sLine + '.Text = value; }\r\n')
                 writeFile.write('        }\r\n')
                 writeFile.write('\r\n') #留一个空行

  #time.sleep(1)
  a=input("输入任意内容退出！")
  sys.exit(0)
