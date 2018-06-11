@echo off
echo 欢迎使用vbs转换为exe工具！
echo 第一步，删除旧exe文件
DEL /F /A /Q  "..\outputBin\WindowsFormsAccess.exe"
DEL /F /A /Q  "..\outputBin\version"
rem DEL /F /A /Q ..\otnm_output\*
rem RD /s /q   ..\otnm_output\forSetupFactory
rem 
rem echo 第二步，拷贝shell文件夹
rem MD ..\otnm_output\forSetupFactory
rem xcopy "..\src\source" "..\otnm_output\forSetupFactory\source\"  /s /e /h
rem xcopy "..\src\tools" "..\otnm_output\forSetupFactory\tools\"  /s /e /h
rem xcopy "..\src\ZEBOS_source" "..\otnm_output\forSetupFactory\ZEBOS_source\"  /s /e /h
rem xcopy "..\src\ini" "..\otnm_output\forSetupFactory\ini\"  /s /e /h
rem copy "..\src\*" "..\otnm_output\"
rem 
rem echo 第三(1)步，vbs生成新exe文件...
rem 
rem echo 第三(2)步，python生成新exe文件... 
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
rem echo 第四步，删除多余文件
rem DEL /F /A /Q ..\otnm_output\jobs.vbs
rem DEL /F /A /Q ..\otnm_output\otnmClear.xml
rem DEL /F /A /Q ..\otnm_output\compJobs_xRun_py.py
rem DEL /F /A /Q ..\otnm_output\jobs.py
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\checkList\check_line.vbs
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compare_mode_line.py
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultVbs.py
rem DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultTxt.py

echo 第四步，生成version文件
echo 编译时间：%date%-%time%  > ..\outputBin\version

echo 第五步，拷贝图形界面
copy "..\WindowsFormsAccess\bin\Release\WindowsFormsAccess.exe" "..\outputBin\"

echo 第六步，显示生成的文件
dir ..\outputBin\

echo vbs转换结束！5秒后退出！
@ping 127.0.0.1 -n 5 >nul