@echo off
echo 欢迎使用vbs转换为exe工具！
echo 第一步，删除旧exe文件
DEL /F /A /Q ..\otnm_output\*
RD /s /q   ..\otnm_output\forSetupFactory

echo 第二步，拷贝shell文件夹
MD ..\otnm_output\forSetupFactory
xcopy "..\src\source" "..\otnm_output\forSetupFactory\source\"  /s /e /h
xcopy "..\src\tools" "..\otnm_output\forSetupFactory\tools\"  /s /e /h
xcopy "..\src\ZEBOS_source" "..\otnm_output\forSetupFactory\ZEBOS_source\"  /s /e /h
xcopy "..\src\ini" "..\otnm_output\forSetupFactory\ini\"  /s /e /h
copy "..\src\*" "..\otnm_output\"

echo 第三(1)步，vbs生成新exe文件...
ScriptCryptor.exe "..\src\tools\checkList\check_line.vbs" "../otnm_output/forSetupFactory/tools/checkList/check_line.exe"

echo 第三(2)步，python生成新exe文件... 
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

echo 第四步，删除多余文件
DEL /F /A /Q ..\otnm_output\jobs.vbs
DEL /F /A /Q ..\otnm_output\otnmClear.xml
DEL /F /A /Q ..\otnm_output\compJobs_xRun_py.py
DEL /F /A /Q ..\otnm_output\jobs.py
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\checkList\check_line.vbs
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compare_mode_line.py
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultVbs.py
DEL /F /A /Q ..\otnm_output\forSetupFactory\tools\compResultTxt.py

echo 第四步，生成version文件
echo 编译时间：%date%-%time%  > ..\otnm_output\version

echo 第五步，拷贝图形界面
copy "..\src\配置清残留工具vbs版本\配置清残留工具\bin\Release\配置清残留工具.exe" "..\otnm_output\"

echo 第六步，显示生成的文件
dir ..\otnm_output\

echo vbs转换结束！5秒后退出！
@ping 127.0.0.1 -n 5 >nul