@echo off
echo ��ӭʹ��vbsת��Ϊexe���ߣ�
echo ��һ����ɾ����exe�ļ�
DEL /F /A /Q  "..\outputBin\WindowsFormsAccess.exe"
DEL /F /A /Q  "..\outputBin\version"
rem DEL /F /A /Q ..\otnm_output\*
rem RD /s /q   ..\otnm_output\forSetupFactory
rem 
rem echo �ڶ���������shell�ļ���
rem MD ..\otnm_output\forSetupFactory
rem xcopy "..\src\source" "..\otnm_output\forSetupFactory\source\"  /s /e /h
rem xcopy "..\src\tools" "..\otnm_output\forSetupFactory\tools\"  /s /e /h
rem xcopy "..\src\ZEBOS_source" "..\otnm_output\forSetupFactory\ZEBOS_source\"  /s /e /h
rem xcopy "..\src\ini" "..\otnm_output\forSetupFactory\ini\"  /s /e /h
rem copy "..\src\*" "..\otnm_output\"
rem 
rem echo ����(1)����vbs������exe�ļ�...
rem 
rem echo ����(2)����python������exe�ļ�... 
rem rd /s /q build
rem del /s /q *.spec
rem 
rem copy "..\src\tools\compare_mode_line.py"  .\compare_mode_line.py
rem python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compare_mode_line.py --distpath ../otnm_output/forSetupFactory/tools/
rem copy "..\src\tools\compResultVbs.py"  .\compResultVbs.py
rem python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compResultVbs.py --distpath ../otnm_output/forSetupFactory/tools/
rem copy "..\src\tools\compResultTxt.py"  .\compResultTxt.py
rem python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compResultTxt.py --distpath ../otnm_output/forSetupFactory/tools/
rem copy "..\src\compJobs_xRun_py.py"  .\compJobs_xRun.py
rem python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compJobs_xRun.py --distpath ../otnm_output/
rem copy "..\src\jobs.py"  .\jobs.py
rem python %pyinstaller%  -F  -c --icon="otnm_clear.ico" jobs.py --distpath ../otnm_output/
rem 
rem rd /s /q build
rem del /s /q *.spec
rem del /s /q *.py
rem 
rem echo ���Ĳ���ɾ�������ļ�
rem DEL /F /A /Q ..\otnm_output\jobs.vbs
rem DEL /F /A /Q ..\otnm_output\otnmClear.xml
rem DEL /F /A /Q ..\otnm_output\compJobs_xRun_py.py
rem DEL /F /A /Q ..\otnm_output\jobs.py
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\checkList\check_line.vbs
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compare_mode_line.py
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultVbs.py
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultTxt.py

echo ���Ĳ�������version�ļ�
echo ����ʱ�䣺%date%-%time%  > ..\outputBin\version

echo ���岽������ͼ�ν���
copy "..\WindowsFormsAccess\bin\Release\WindowsFormsAccess.exe" "..\outputBin\"

echo ����������ʾ���ɵ��ļ�
dir ..\outputBin\

echo vbsת��������5����˳���
@ping 127.0.0.1 -n 5 >nul