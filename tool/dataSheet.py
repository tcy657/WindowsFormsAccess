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
  
  resultPath = rootDir + "DAL\\"
  if  os.path.exists(resultPath):
    delete_file_folder(resultPath)
  os.makedirs(resultPath)
  
  flag1 = False #在类定义后，符号{后定义类
                #插入新构造函数
  
  list = os.listdir(rootDir)
  for i in range(0,len(list)):
         filePath = os.path.join(rootDir,list[i])
         if os.path.isfile(filePath) and filePath.endswith('.cs'): #只操作cs文件
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
                           className = className.strip()  #去掉空格和换行符
                           writeFile.write(sLine)
                           flag1 = True #在符号{后插入创建类
                       elif True == flag1:
                           if '{' in  sLine:
                                writeFile.write(sLine)
                                writeFile.write('       private AccessHelper DbHelperOleDb;\r\n') #定义类
                                writeFile.write('       public ' + className +'(string dbPath)\r\n')  #带参数的构造函数，预留
                                writeFile.write('       {\r\n')
                                writeFile.write('            DbHelperOleDb = new AccessHelper(dbPath);\r\n')
                                writeFile.write('       }\r\n')
                                flag1 = False #在符号{后插入创建类
                       elif '{}' in  sLine: #在构造函数中，实例化类
                                writeFile.write('       {\r\n')
                                writeFile.write('            DbHelperOleDb = new AccessHelper();\r\n')
                                writeFile.write('       }\r\n')
                       else:
                           writeFile.write(sLine)

  #time.sleep(1)
  a=input("输入任意内容退出！")
  sys.exit(0)
