@echo off
set SOLUTIONDIR=%1
set OUTPUTFILE=%2
echo Starting Dependency check...
echo ^<?xml version="1.0" encoding="UTF-8"?^> > %OUTPUTFILE%
echo ^<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi"^> >> %OUTPUTFILE%
echo   ^<Fragment^> >> %OUTPUTFILE%
echo     ^<ComponentGroup Id="HarvestedDependancies" Directory="INSTALLFOLDER"^> >> %OUTPUTFILE%

for %%F in (%SOLUTIONDIR%rNascarApp\bin\Release\*.*) do (
   echo "-- Adding %%~nxF" 
    echo         ^<ComponentRef Id="%%~nxF"/^> >> %OUTPUTFILE%
)
echo     ^</ComponentGroup^> >> %OUTPUTFILE%
echo   ^</Fragment^> >> %OUTPUTFILE%
echo ^</Wix^> >> %OUTPUTFILE%
echo Dependency check done.