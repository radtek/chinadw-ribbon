;NSIS Modern User Interface version 1.70
;Multilingual Example Script
;Written by Joost Verburg

;--------------------------------
;Include Modern UI

  !include "MUI.nsh"

;--------------------------------
;General

  ;Name and file
  Name "��� ��������������"
  OutFile "GRECB_upd.exe"

  SetCompressor /SOLID lzma
  SilentInstall silent

  ;Default installation folder
  InstallDir "C:\BSB\GRECB"
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\BSB\GRECB\ARM_User" ""

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Language Selection Dialog Settings

  ;Remember the installer language
  !define MUI_LANGDLL_REGISTRY_ROOT "HKCU" 
  !define MUI_LANGDLL_REGISTRY_KEY "Software\BSB\GRECB\ARM_User" 
  !define MUI_LANGDLL_REGISTRY_VALUENAME "Installer Language"

;--------------------------------
;Pages

;  !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Contrib\Modern UI\License.txt"
;  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"
  !insertmacro MUI_LANGUAGE "Russian"

;--------------------------------
;Reserve Files
  
  ;These files should be inserted before other files in the data block
  ;Keep these lines before any File command
  ;Only for solid compression (by default, solid compression is enabled for BZIP2 and LZMA)
  
  !insertmacro MUI_RESERVEFILE_LANGDLL

;--------------------------------
;Installer Sections

Section "Dummy Section" SecDummy

  SetOutPath "$INSTDIR"
  
  ;ADD YOUR OWN FILES HERE...
  File ..\bin\Debug\ARM_User.exe.config
  File ..\bin\Debug\ARM_User.exe
  File ..\bin\Debug\*.dll
  File ..\UpdateApp.exe
  
  CreateDirectory "$SMPROGRAMS\BSB\GRECB\User"
  CreateShortCut "$SMPROGRAMS\BSB\GRECB\User\��� ������������.lnk" "$INSTDIR\ARM_User.exe" "" "" 0 SW_SHOWMAXIMIZED 
  CreateShortCut "$SMPROGRAMS\BSB\GRECB\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  
  CreateShortCut "$DESKTOP\��� ��������������.lnk" "$INSTDIR\ARM_User.exe" "" "" 0 SW_SHOWMAXIMIZED 
 
  ;Store installation folder
  WriteRegStr HKCU "Software\BSB\GRECB\ARM_User" "" $INSTDIR
  
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\BSB_GRECB" "DisplayName" "��� ������������"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\BSB_GRECB" "UninstallString" '"$INSTDIR\Uninstall.exe"'

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Installer Functions

Function .onInit

  !insertmacro MUI_LANGDLL_DISPLAY

FunctionEnd

;--------------------------------
;Descriptions

  ;USE A LANGUAGE STRING IF YOU WANT YOUR DESCRIPTIONS TO BE LANGAUGE SPECIFIC

  ;Assign descriptions to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} "A test section."
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

 
;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
  Delete "$SMPROGRAMS\BSB\GRECB\User\*.*"
  RMDir "$SMPROGRAMS\BSB\GRECB\User"
  Delete "$SMPROGRAMS\BSB\GRECB"
  RMDir "$SMPROGRAMS\BSB\GRECB"
  
  Delete "$DESKTOP\��� ��������������.lnk"
  Delete "$DESKTOP\��� ��������������.lnk"
  Delete "$INSTDIR\*.*"

  DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\BSB_GRECB"
  DeleteRegKey HKCU "Software\BSB\GRECB\ARM_User"
  DeleteRegKey /ifempty HKCU "Software\BSB\GRECB"	

SectionEnd

;--------------------------------
;Uninstaller Functions

Function un.onInit

  !insertmacro MUI_UNGETLANGUAGE
  
FunctionEnd