@echo off
setlocal enabledelayedexpansion
:: ����download�ļ��е����ݵ���ǰĿ¼
xcopy /y /i /e "%~dp0download\*" "%~dp0"
:: ɾ��download�ļ���
rmdir /s /q "%~dp0download"
:: �ر��������еĽ���
for /f "tokens=2 delims=," %%a in ('tasklist ^| find /i "SREmulator.GUI.exe"') do (taskkill /f /pid %%a)
:: ������Ϻ�����
start "" "%~dp0SREmulator.GUI.exe"
endlocal