; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CUFE30_DemoDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "ufe30_demo.h"
LastPage=0

ClassCount=5
Class1=CUFE30_DemoApp
Class2=CUFE30_DemoDlg

ResourceCount=6
Resource1=IDD_DIALOGBAR (English (U.S.))
Resource2=IDD_PROPPAGE_SMALL (English (U.S.))
Resource3=IDD_OLE_PROPPAGE_SMALL (English (U.S.))
Class3=CUFE30_EnrollDlg
Resource4=IDD_UFE30_ENROLL
Class4=CUFE30_UserInfo
Resource5=IDD_UFE30_USER_INFO
Class5=CUFE30_UserInfoDlg
Resource6=IDD_UFE30_DEMO_DIALOG (English (U.S.))

[CLS:CUFE30_DemoApp]
Type=0
BaseClass=CWinApp
HeaderFile=UFE30_Demo.h
ImplementationFile=UFE30_Demo.cpp
LastObject=CUFE30_DemoApp

[CLS:CUFE30_DemoDlg]
Type=0
BaseClass=CDialog
HeaderFile=UFE30_DemoDlg.h
ImplementationFile=UFE30_DemoDlg.cpp
LastObject=IDC_TYPE
Filter=D
VirtualFilter=dWC

[DLG:IDD_UFE30_DEMO_DIALOG]
Type=1
Class=CUFE30_DemoDlg

[DLG:IDD_UFE30_DEMO_DIALOG (English (U.S.))]
Type=1
Class=CUFE30_DemoDlg
ControlCount=47
Control1=IDC_INIT,button,1342242816
Control2=IDC_STATIC,button,1342177287
Control3=IDC_STATIC,button,1342177287
Control4=IDC_UPDATE,button,1342242816
Control5=IDC_UNINIT,button,1342242816
Control6=IDC_STATIC,static,1342308352
Control7=IDC_SCANNER_LIST,listbox,1353777409
Control8=IDC_STATIC,button,1342177287
Control9=IDC_STATIC,static,1342308352
Control10=IDC_TIMEOUT,combobox,1344339971
Control11=IDC_STATIC,static,1342308352
Control12=IDC_BRIGHTNESS,edit,1350631553
Control13=IDC_BRIGHTNESS_SPIN,msctls_updown32,1342177334
Control14=IDC_STATIC,static,1342308352
Control15=IDC_SENSITIVITY,edit,1350631553
Control16=IDC_SENSITIVITY_SPIN,msctls_updown32,1342177334
Control17=IDC_DETECT_CORE,button,1342242819
Control18=IDC_IMAGE_FRAME,static,1342177287
Control19=IDC_STATIC,button,1342177287
Control20=IDC_START_CAPTURING,button,1342242816
Control21=IDC_ABORT_CAPTURING,button,1342242816
Control22=IDC_CAPTURE_SINGLE,button,1342242816
Control23=IDC_EXTRACT,button,1342242816
Control24=IDC_ENROLL,button,1342242816
Control25=IDC_STATIC,button,1342177287
Control26=IDC_STATIC,static,1342308352
Control27=IDC_SECURITY_LEVEL,combobox,1344339971
Control28=IDC_FAST_MODE,button,1342242819
Control29=IDC_VERIFY,button,1342242816
Control30=IDC_IDENTIFY,button,1342242816
Control31=IDC_SAVE_TEMPLATE,button,1342242816
Control32=IDC_SAVE_IMAGE,button,1342242816
Control33=IDC_MESSAGE_EDIT,edit,1352728644
Control34=IDC_CLEAR_MESSAGE,button,1342242816
Control35=IDC_STATIC,static,1342308352
Control36=IDC_TYPE,combobox,1344339971
Control37=IDC_FINGERDATA_LIST,SysListView32,1350631429
Control38=IDC_ONE_TEMPLATE_NORMAL,button,1342308361
Control39=IDC_ONE_TEMPLATE_ADVANCED,button,1342177289
Control40=IDC_TWO_TEMPLATE_ADVANCED,button,1342177289
Control41=IDC_UPDATE_TEMPLATE,button,1342242816
Control42=IDC_DELETE_TEMPLATE,button,1342242816
Control43=IDC_DELETE_ALL_TEMPLATE,button,1342242816
Control44=IDC_TWO_TEMPLATE_ADVANCED2,button,1342177289
Control45=IDC_QUALITY,combobox,1344339971
Control46=IDC_STATIC,static,1342308352
Control47=IDC_AUTO_CAPTURE,button,1342242816

[DLG:IDD_PROPPAGE_SMALL (English (U.S.))]
Type=1
Class=?
ControlCount=1
Control1=IDC_STATIC,static,1342308352

[DLG:IDD_OLE_PROPPAGE_SMALL (English (U.S.))]
Type=1
Class=?
ControlCount=1
Control1=IDC_STATIC,static,1342308352

[DLG:IDD_DIALOGBAR (English (U.S.))]
Type=1
Class=?
ControlCount=1
Control1=IDC_STATIC,static,1342308352

[DLG:IDD_UFE30_ENROLL]
Type=1
Class=CUFE30_EnrollDlg
ControlCount=10
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_IMAGE_FRAME,static,1342177287
Control4=IDC_MESSAGE_EDIT,edit,1352728644
Control5=IDC_USER_ID,edit,1342244992
Control6=IDC_STATIC,static,1342308352
Control7=IDC_STATIC,static,1342308352
Control8=IDC_STATIC,static,1342308352
Control9=IDC_STATIC,static,1342308352
Control10=IDC_STATIC,static,1342308352

[CLS:CUFE30_EnrollDlg]
Type=0
HeaderFile=UFE30_EnrollDlg.h
ImplementationFile=UFE30_EnrollDlg.cpp
BaseClass=CDialog
Filter=D
LastObject=IDC_USER_ID
VirtualFilter=dWC

[DLG:IDD_UFE30_USER_INFO]
Type=1
Class=CUFE30_UserInfoDlg
ControlCount=4
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_USER_ID,edit,1350631552
Control4=IDC_STATIC,static,1342308352

[CLS:CUFE30_UserInfo]
Type=0
HeaderFile=UFE30_UserInfo.h
ImplementationFile=UFE30_UserInfo.cpp
BaseClass=CDialog
Filter=D
VirtualFilter=dWC

[CLS:CUFE30_UserInfoDlg]
Type=0
HeaderFile=UFE30_UserInfoDlg.h
ImplementationFile=UFE30_UserInfoDlg.cpp
BaseClass=CDialog
Filter=D
VirtualFilter=dWC
LastObject=IDC_USER_ID

