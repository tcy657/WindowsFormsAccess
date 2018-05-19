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

#打印异常，2016/10/18
import traceback

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

  #步骤0 获取测试用例套的路径
  strUser = getpass.getuser()  #获取当前登录用户名
  #获取当前路径，为更好地从图形化界面启动，本方法不使用。必须加参数才能运行，防止手工误启动。
  rootdir = os.path.dirname(os.path.realpath(sys.argv[0] )) +'\\' #类似D:/jenkins/xx/
  if not os.path.exists(rootdir):
    print('程序退出，根路径不存在：' + rootdir)
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
