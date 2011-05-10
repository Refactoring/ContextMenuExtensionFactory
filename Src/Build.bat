@echo off
%windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe ContextMenuExtensionFactory.sln /t:Build /p:Configuration=Release
pause
