# -*- coding: utf-8 -*-
#!c:/Program Files (x86)/Microsoft Visual Studio/Shared/Python37_64/python.exe  

import os
import sys
import re
import datetime
import subprocess

#사용법
#빌드전 이벤트에 아래 두 줄을 추가한다.
#cd $(ProjectDir)
#"c:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\python.exe" c:\source\개발모듈\version.py

def findcurrentbranch():
    # 현재의 branch를 찾는다.
    try:
        branches = subprocess.check_output('git branch', shell=True, stderr=subprocess.STDOUT, universal_newlines=True)
        print (f'branches:{branches}')
        for b in branches.split('\n'):
            if b.find('*') >= 0:
                curbranch = b[2:]
                print (f'current branch : {curbranch}')
        return '-' + curbranch
    except: 
        print ('No current branch')
        return ''


if __name__ == '__main__':
    dt = datetime.datetime.now()
#    dirname, filename = os.path.split(os.path.abspath(__file__))
    print(f"Current Path = {os.getcwd()}")

    curbranch = 'master'   
    curbranch = findcurrentbranch()
    
#   print(f"current dir = {dirname}")
#   os.chdir(dirname)
    f=open('Properties/AssemblyInfo.cs', mode='r', encoding="utf8")
    filedata = f.read()
    f.close()
 
    p = re.compile('AssemblyProduct\\("([0-9a-zA-Z]+)[0-9a-zA-Z\\-_ .]*"\\)')
    mo = p.search(filedata)
    if (mo != None):
        print(mo.group(1))
        
    filedata = p.sub(f'AssemblyProduct("{mo.group(1)}{curbranch}")', filedata)

 
    p = re.compile('AssemblyVersion\\("([0-9]+).[0-9.]*"\\)')
    mo = p.search(filedata)
#    if (mo != None):
#        print(mo.group(1))
        
    filedata = p.sub(f'AssemblyVersion("{mo.group(1)}.{dt.year%100}.{dt.month}{dt.day:02}.{dt.hour}{dt.minute:02}")', filedata)

    p = re.compile('AssemblyFileVersion\\("([0-9]+).[0-9.A-Za-z\\-_]*"\\)')
    mo = p.search(filedata)
#    if (mo != None):
#        print(mo.group())
    filedata = p.sub(f'AssemblyFileVersion("{mo.group(1)}.{dt.year%100}.{dt.month}{dt.day:02}.{dt.hour}{dt.minute:02}")', filedata)

    #print(filedata)
    f=open('Properties/AssemblyInfo.cs', mode='w', encoding="utf8")
    f.write(filedata)
    f.close()
