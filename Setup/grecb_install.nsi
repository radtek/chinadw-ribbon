;NSIS Modern User Interface version 1.70
;Multilingual Example Script
;Written by Joost Verburg

;--------------------------------
;Include Modern UI

  !include "MUI.nsh"

;--------------------------------
;General

  ;Name and file
  Name "АРМ «Пользователь»"
  OutFile "Setup.exe"

  SetCompressor /SOLID lzma
  
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
  File ..\bin\x64\Debug\ARM_User.exe.config
  File ..\bin\x64\Debug\ARM_User.exe  
  File ..\bin\x64\Debug\*.dll
  File ..\bin\x64\Debug\Xml\*.xml
  File ..\UpdateApp.exe
  
  CreateShortCut "C:\BSB\GRECB\Xml\MsgPanel_DEFAULT.xml" "$INSTDIR\MsgPanel_DEFAULT.xml"
  CreateShortCut "C:\BSB\GRECB\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  CreateShortCut "$DESKTOP\АРМ «Пользователь».lnk" "$INSTDIR\ARM_User.exe" "" "" 0 SW_SHOWMAXIMIZED 
 
  ;Store installation folder
  WriteRegStr HKCU "Software\BSB\GRECB\ARM_User" "" $INSTDIR
  
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\BSB_GRECB" "DisplayName" "ARM_User"
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
  Delete "C:\BSB\GRECB"
  RMDir "C:\BSB\GRECB"
  
  Delete "$DESKTOP\АРМ «Пользователь».lnk"
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