@echo off
echo ��ӭʹ��vbsת��Ϊexe���ߣ�
echo ��һ����ɾ����exe�ļ�
DEL /F /A /Q ..\otnm_output\*
RD /s /q   ..\otnm_output\forSetupFactory

echo �ڶ���������shell�ļ���
MD ..\otnm_output\forSetupFactory
xcopy "..\src\source" "..\otnm_output\forSetupFactory\source\"  /s /e /h
xcopy "..\src\tools" "..\otnm_output\forSetupFactory\tools\"  /s /e /h
xcopy "..\src\ZEBOS_source" "..\otnm_output\forSetupFactory\ZEBOS_source\"  /s /e /h
xcopy "..\src\ini" "..\otnm_output\forSetupFactory\ini\"  /s /e /h
copy "..\src\*" "..\otnm_output\"

echo ����(1)����vbs������exe�ļ�...
ScriptCryptor.exe "..\src\tools\checkList\check_line.vbs" "../otnm_output/forSetupFactory/tools/checkList/check_line.exe"

echo ����(2)����python������exe�ļ�... 
rd /s /q build
del /s /q *.spec

copy "..\src\tools\compare_mode_line.py"  .\compare_mode_line.py
python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compare_mode_line.py --distpath ../otnm_output/forSetupFactory/tools/
copy "..\src\tools\compResultVbs.py"  .\compResultVbs.py
python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compResultVbs.py --distpath ../otnm_output/forSetupFactory/tools/
copy "..\src\tools\compResultTxt.py"  .\compResultTxt.py
python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compResultTxt.py --distpath ../otnm_output/forSetupFactory/tools/
copy "..\src\compJobs_xRun_py.py"  .\compJobs_xRun.py
python %pyinstaller%  -F  -c --icon="otnm_clear.ico" compJobs_xRun.py --distpath ../otnm_output/
copy "..\src\jobs.py"  .\jobs.py
python %pyinstaller%  -F  -c --icon="otnm_clear.ico" jobs.py --distpath ../otnm_output/

rd /s /q build
del /s /q *.spec
del /s /q *.py

echo ���Ĳ���ɾ�������ļ�
DEL /F /A /Q ..\otnm_output\jobs.vbs
DEL /F /A /Q ..\otnm_output\otnmClear.xml
DEL /F /A /Q ..\otnm_output\compJobs_xRun_py.py
DEL /F /A /Q ..\otnm_output\jobs.py
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\checkList\check_line.vbs
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compare_mode_line.py
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultVbs.py
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultTxt.py

echo ���Ĳ�������version�ļ�
echo ����ʱ�䣺%date%-%time%  > ..\otnm_output\version

echo ���岽������ͼ�ν���
copy "..\src\�������������vbs�汾\�������������\bin\Release\�������������.exe" "..\otnm_output\"

echo ����������ʾ���ɵ��ļ�
dir ..\otnm_output\

echo vbsת��������5����˳���
@ping 127.0.0.1 -n 5 >nul