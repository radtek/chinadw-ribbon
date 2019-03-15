; #######################################################################################
; # This NSIS script was generated by Visual & Installer for MS Visual Studio           #
; # Visual & Installer (c) 2012 - 2018 unSigned, s. r. o. All Rights Reserved.          #
; # Visit http://www.visual-installer.com/ for more details.                            #
; #######################################################################################

; NSIS Modern User Interface

; Include Modern UI
!include "MUI2.nsh"

; General

  ; Name and output file
  Name "Setup"
  OutFile "Output\Setup.exe"

  ; Default installation folder
  InstallDir "$LOCALAPPDATA\Setup"
  
  ; Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Setup" ""

  ; Request application privileges for Windows Vista/7/8/10
  RequestExecutionLevel user

; --------------------------------
; Interface Settings

  !define MUI_ABORTWARNING

; --------------------------------
; Pages

  !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
; --------------------------------
; Languages
 
  !insertmacro MUI_LANGUAGE "English"

; --------------------------------
; Installer Sections

Section "Setup" SecDummy

  SetOutPath "$INSTDIR"
  
  ; ADD YOUR OWN FILES HERE...
  File "Script.nsi"
  
  ; Store installation folder
  WriteRegStr HKCU "Software\Setup" "" $INSTDIR
  
  ; Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

; --------------------------------
; Descriptions

  ; Language strings
  LangString DESC_SecDummy ${LANG_ENGLISH} "A Setup section."

  ; Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

; --------------------------------
; Uninstaller Section

Section "Uninstall"

  ; ADD YOUR OWN FILES HERE...

  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\Setup"

SectionEnd
