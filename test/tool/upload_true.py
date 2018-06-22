# -*- coding:gb2312 -*-
__author__ = 'dacxu'
__mail__ = 'xudacheng06.com'
__date__ = '2013-10-29'
__version = 1.0

import sys
import os
import json
import time
import datetime
from ftplib import FTP

_XFER_FILE = 'FILE'
_XFER_DIR = 'DIR'

class Xfer(object):
    '''''
    @note: upload local file or dirs recursively to ftp server
    '''
    def __init__(self):
        self.ftp = None

    def __del__(self):
        pass

    def setFtpParams(self, ip, uname, pwd, port = 21, timeout = 60):
        self.ip = ip
        self.uname = uname
        self.pwd = pwd
        self.port = port
        self.timeout = timeout
        self.exist = False #upload or not?

    def initEnv(self):
        if self.ftp is None:
            self.ftp = FTP()
            print '### connect ftp server: %s ...'%self.ip
            self.ftp.connect(self.ip, self.port, self.timeout)
            self.ftp.login(self.uname, self.pwd)
            print self.ftp.getwelcome()

    def clearEnv(self):
        if self.ftp:
            self.ftp.close()
            print '### disconnect ftp server: %s!'%self.ip
            self.ftp = None

    def uploadDir(self, localdir='./', remotedir='./'):
        if not os.path.isdir(localdir):
            return
        self.ftp.cwd(remotedir)
        for file in os.listdir(localdir):
            src = os.path.join(localdir, file)
            if os.path.isfile(src):
                self.uploadFile(src, file)
            elif os.path.isdir(src):
                try:
                    self.ftp.mkd(file)
                except:
                    sys.stderr.write('the dir is exists %s'%file)
                self.uploadDir(src, file)
        self.ftp.cwd('..')

    def uploadFile(self, localpath, remotepath=r'./'):
        if not os.path.isfile(localpath):
            return
        print '+++ upload %s to %s:%s'%(localpath, self.ip, remotepath)
        self.ftp.storbinary('STOR ' + remotepath, open(localpath, 'rb'))

    def __filetype(self, src):
        if os.path.isfile(src):
            index = src.rfind('\\')
            if index == -1:
                index = src.rfind('/')
            return _XFER_FILE, src[index+1:]
        elif os.path.isdir(src):
            return _XFER_DIR, ''

    def upload(self, src):
        filetype, filename = self.__filetype(src)

        self.initEnv()
        if filetype == _XFER_DIR:
            self.srcDir = src
            self.uploadDir(self.srcDir)
        elif filetype == _XFER_FILE:
            self.uploadFile(src, r'./test/' + filename)
        self.clearEnv()
    
    def ifUpload(self):  
        try:  
            self.initEnv()
            self.ftp.cwd(r'./test/8k/')
            self.ftp.cwd(r'./')
            self.exist = True
            self.clearEnv()
        except Exception,ex: 
            self.exist = False
            print "run 5 " + str(ex)
            self.clearEnv()
            return
            
def Caltime():
    date1=time.strftime("%H:%M:%S", time.localtime()) 
    date2=time.strptime(date2,"%Y-%m-%d %H:%M:%S")
    date1=datetime.datetime(date1[3],date1[4],date1[5])
    date2=datetime.datetime(date2[3],date2[4],date2[5])
    return date2-date1
    
#interval run 
def print_ts(message):  
    print "+ [%s] %s"%(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()), message)  
def run(interval):  
    #print_ts("-"*100)  
    #print_ts("Command %s"%command)  
    #print_ts("Starting every %s seconds."%interval)  
    #print_ts("-"*100)  
    while True:  
        try:  
            # sleep for the remaining seconds of interval  
            time_remaining = interval-time.time()%interval  
            print_ts("until %s (%s seconds)"%((time.ctime(time.time()+time_remaining)), time_remaining))  
            time.sleep(time_remaining)  
            print_ts("Starting command.")  
            main()
        except Exception, e:  
            print e

def main():            
    srcDir = r'Y:\project\20180508-access\wfsAccessSvn\WindowsFormsAccess\bin\Release\\'
    srcFile = r'Y:\project\20180508-access\wfsAccessSvn\WindowsFormsAccess\bin\Release\WindowsForms2.exe'
    srcFile2 = r'Y:\project\20180508-access\wfsAccessSvn\README2.md'
    srcFile3 = r'Y:\project\20180508-access\wfsAccessSvn\ouput\WindowsForms2.exe'
    xfer = Xfer()
    xfer.setFtpParams('ftp.xxx.com', 'name', 'pwd')
    
    xfer.ifUpload()
    if (False == xfer.exist):
         print "return"
         return
        
    #xfer.upload(srcDir)
    if os.path.exists(srcFile):
        xfer.upload(srcFile)
    if os.path.exists(srcFile2):
        xfer.upload(srcFile2)
    if os.path.exists(srcFile3):   #srcFile3存在才上传
        xfer.upload(srcFile3)        
if __name__ == '__main__':
    interval = 600 # 180s = 3min
    run(interval)