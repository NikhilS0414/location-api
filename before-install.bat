REM Install Internet Information Server (IIS).
c:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command Import-Module -Name ServerManager
c:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command Install-WindowsFeature Web-Server
