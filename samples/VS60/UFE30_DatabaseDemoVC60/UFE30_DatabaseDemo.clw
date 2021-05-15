; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CUFE30_DatabaseDemoDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "UFE30_DatabaseDemo.h"

ClassCount=4
Class1=CUFE30_DatabaseDemoApp
Class2=CUFE30_DatabaseDemoDlg
Class3=CAboutDlg

ResourceCount=5
Resource1=IDD_ABOUTBOX (English (U.S.))
Resource2=IDR_MAINFRAME
Resource3=IDD_UFE30_DATABASEDEMO_DIALOG
Resource4=IDD_USER_INFO (English (U.S.))
Class4=CUserInfoDlg
Resource5=IDD_UFE30_DATABASEDEMO_DIALOG (English (U.S.))

[CLS:CUFE30_DatabaseDemoApp]
Type=0
HeaderFile=UFE30_DatabaseDemo.h
ImplementationFile=UFE30_DatabaseDemo.cpp
Filter=N

[CLS:CUFE30_DatabaseDemoDlg]
Type=0
HeaderFile=UFE30_DatabaseDemoDlg.h
ImplementationFile=UFE30_DatabaseDemoDlg.cpp
Filter=D
BaseClass=CDialog
VirtualFilter=dWC
LastObject=CUFE30_DatabaseDemoDlg

[CLS:CAboutDlg]
Type=0
HeaderFile=UFE30_DatabaseDemoDlg.h
ImplementationFile=UFE30_DatabaseDemoDlg.cpp
Filter=D

[DLG:IDD_UFE30_DATABASEDEMO_DIALOG]
Type=1
ControlCount=3
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,static,1342308352
Class=CUFE30_DatabaseDemoDlg

[DLG:IDD_UFE30_DATABASEDEMO_DIALOG (English (U.S.))]
Type=1
Class=CUFE30_DatabaseDemoDlg
ControlCount=16
Control1=IDC_INIT,button,1342242816
Control2=IDC_UNINIT,button,1342242816
Control3=IDC_MESSAGE_EDIT,edit,1352728644
Control4=IDC_CLEAR_MESSAGE,button,1342242816
Control5=IDC_ENROLL,button,1342242816
Control6=IDC_IDENTIFY,button,1342242816
Control7=IDC_DATABASE_LIST,SysListView32,1350631429
Control8=IDC_STATIC,button,1342177287
Control9=IDC_SELECTION_DELETE,button,1342242816
Control10=IDC_SELECTION_UPDATE_USERINFO,button,1342251008
Control11=IDC_SELECTION_UPDATE_TEMPLATE,button,1342251008
Control12=IDC_SELECTION_VERIFY,button,1342242816
Control13=IDC_DELETE_ALL,button,1342242816
Control14=IDC_IMAGE_FRAME,static,1342177287
Control15=IDC_STATIC,static,1342308352
Control16=IDC_TYPE,combobox,1344339971

[DLG:IDD_ABOUTBOX (English (U.S.))]
Type=1
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_USER_INFO (English (U.S.))]
Type=1
Class=CUserInfoDlg
ControlCount=8
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_USERID,edit,1350635648
Control4=IDC_STATIC,static,1342308352
Control5=IDC_STATIC,static,1342308352
Control6=IDC_FINGERINDEX,edit,1350643840
Control7=IDC_STATIC,static,1342308352
Control8=IDC_MEMO,edit,1350635524

[CLS:CUserInfoDlg]
Type=0
HeaderFile=UserInfoDlg.h
ImplementationFile=UserInfoDlg.cpp
BaseClass=CDialog
Filter=D
LastObject=IDC_USERID
VirtualFilter=dWC

