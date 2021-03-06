; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{379F3E13-78D2-428A-9CF5-011DA9C7FFF7}
AppName=VPN Vision
AppVersion=1.0
;AppVerName=VPN Vision 1.0
AppPublisher=Pelgo Systems SAS
AppPublisherURL=http://www.vpnvision.com/
AppSupportURL=http://www.vpnvision.com/
AppUpdatesURL=http://www.vpnvision.com/
DefaultDirName={pf}\VPN Vision
DefaultGroupName=VPN Vision
DisableProgramGroupPage=yes
OutputBaseFilename=VPN_Vision_Install
SetupIconFile=C:\Amodifier_2015_10_23\Copie travail OK - release App OK\Source Code\vpn_vision\web.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Amodifier_2015_10_23\Copie travail OK - release App OK\Source Code\vpn_vision\bin\Debug\VPN Vision.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Amodifier_2015_10_23\Copie travail OK - release App OK\Source Code\vpn_vision\bin\Debug\tap-fixer.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\vpnvision\Desktop\setup compil\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\VPN Vision"; Filename: "{app}\VPN Vision.exe"
Name: "{group}\{cm:UninstallProgram,VPN Vision}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\VPN Vision"; Filename: "{app}\VPN Vision.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\VPN Vision"; Filename: "{app}\VPN Vision.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\VPN Vision.exe"; Description: "{cm:LaunchProgram,VPN Vision}"; Flags: nowait postinstall skipifsilent

