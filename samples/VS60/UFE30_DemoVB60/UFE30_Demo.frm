VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.1#0"; "MSCOMCTL.OCX"
Begin VB.Form UFE30_Demo 
   BorderStyle     =   1  '단일 고정
   Caption         =   "Suprema PC SDK Demo (VB 6.0)"
   ClientHeight    =   7815
   ClientLeft      =   9225
   ClientTop       =   3915
   ClientWidth     =   11310
   LinkTopic       =   "UFE30_Demo"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   521
   ScaleMode       =   3  '픽셀
   ScaleWidth      =   754
   StartUpPosition =   2  '화면 가운데
   Begin VB.ComboBox cbQuality 
      Height          =   300
      ItemData        =   "UFE30_Demo.frx":0000
      Left            =   10080
      List            =   "UFE30_Demo.frx":0022
      TabIndex        =   44
      Top             =   4680
      Width           =   795
   End
   Begin VB.OptionButton obtnEnroll2 
      Caption         =   "2-Template"
      Height          =   180
      Left            =   7320
      TabIndex        =   43
      Top             =   4800
      Width           =   1455
   End
   Begin VB.CommandButton btnDeleteTemplate 
      Caption         =   "Delete Template"
      Height          =   255
      Left            =   9000
      TabIndex        =   39
      Top             =   6600
      Width           =   1695
   End
   Begin VB.CommandButton btnUpdateTemplate 
      Caption         =   "Update Template"
      Height          =   255
      Left            =   7200
      TabIndex        =   38
      Top             =   6600
      Width           =   1695
   End
   Begin VB.CommandButton btnDeleteAll 
      Caption         =   "Delete All"
      Height          =   255
      Left            =   9000
      TabIndex        =   37
      Top             =   6240
      Width           =   1695
   End
   Begin VB.OptionButton obtnADEnroll2 
      Caption         =   "2-Template Advanced"
      Height          =   180
      Left            =   7320
      TabIndex        =   36
      Top             =   5280
      Width           =   2295
   End
   Begin VB.OptionButton obtnAdEnroll1 
      Caption         =   "1-Template Advanced"
      Height          =   180
      Left            =   7320
      TabIndex        =   35
      Top             =   5040
      Width           =   6120
   End
   Begin VB.OptionButton obtnEnroll 
      Caption         =   "1-Template"
      Height          =   180
      Left            =   7320
      TabIndex        =   34
      Top             =   4560
      Width           =   1455
   End
   Begin VB.ComboBox cbType 
      Height          =   300
      ItemData        =   "UFE30_Demo.frx":0051
      Left            =   8880
      List            =   "UFE30_Demo.frx":005E
      Style           =   2  '드롭다운 목록
      TabIndex        =   33
      Top             =   5760
      Width           =   1455
   End
   Begin VB.Frame Frame1 
      Caption         =   "Scanner Parameters"
      Height          =   1635
      Left            =   120
      TabIndex        =   23
      Top             =   2280
      Width           =   2895
      Begin VB.CheckBox cbDetectCore 
         Caption         =   "DetectCore"
         Height          =   255
         Left            =   120
         TabIndex        =   29
         Top             =   1260
         Width           =   1590
      End
      Begin VB.ComboBox cbTimeout 
         Height          =   300
         ItemData        =   "UFE30_Demo.frx":007F
         Left            =   1200
         List            =   "UFE30_Demo.frx":0095
         TabIndex        =   28
         Top             =   240
         Width           =   675
      End
      Begin VB.TextBox tbBrightness 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1042
            SubFormatType   =   1
         EndProperty
         Height          =   285
         Left            =   1380
         TabIndex        =   27
         Text            =   "0"
         Top             =   600
         Width           =   420
      End
      Begin VB.TextBox tbSensitivity 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1042
            SubFormatType   =   1
         EndProperty
         Height          =   270
         Left            =   1380
         TabIndex        =   26
         Text            =   "0"
         Top             =   960
         Width           =   420
      End
      Begin MSComCtl2.UpDown udSensitivity 
         Height          =   270
         Left            =   1800
         TabIndex        =   24
         Top             =   960
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   476
         _Version        =   393216
         BuddyControl    =   "tbSensitivity"
         BuddyDispid     =   196622
         OrigLeft        =   1920
         OrigTop         =   960
         OrigRight       =   2160
         OrigBottom      =   1215
         Max             =   7
         SyncBuddy       =   -1  'True
         BuddyProperty   =   65547
         Enabled         =   -1  'True
      End
      Begin MSComCtl2.UpDown tdBrightness 
         Height          =   285
         Left            =   1800
         TabIndex        =   25
         Top             =   600
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   503
         _Version        =   393216
         BuddyControl    =   "tbBrightness"
         BuddyDispid     =   196621
         OrigLeft        =   1920
         OrigTop         =   600
         OrigRight       =   2160
         OrigBottom      =   855
         Max             =   255
         SyncBuddy       =   -1  'True
         BuddyProperty   =   65547
         Enabled         =   -1  'True
      End
      Begin VB.Label Label2 
         Caption         =   "Timeout"
         Height          =   195
         Left            =   180
         TabIndex        =   32
         Top             =   300
         Width           =   855
      End
      Begin VB.Label Label3 
         Caption         =   "Brightness"
         Height          =   255
         Left            =   180
         TabIndex        =   31
         Top             =   600
         Width           =   975
      End
      Begin VB.Label Label4 
         Caption         =   "Sensitivity"
         Height          =   255
         Left            =   180
         TabIndex        =   30
         Top             =   960
         Width           =   975
      End
   End
   Begin MSComctlLib.ListView lvFingerDataList 
      Height          =   3735
      Left            =   6720
      TabIndex        =   22
      Top             =   120
      Width           =   4455
      _ExtentX        =   7858
      _ExtentY        =   6588
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.CommandButton btnSaveImage 
      Caption         =   "Save Image"
      Height          =   375
      Left            =   1680
      TabIndex        =   19
      Top             =   5640
      Width           =   1215
   End
   Begin VB.CommandButton btnSaveTemplate 
      Caption         =   "Save Template"
      Height          =   255
      Left            =   9000
      TabIndex        =   18
      Top             =   6960
      Width           =   1695
   End
   Begin VB.Frame Frame3 
      Caption         =   "Match"
      Height          =   2055
      Left            =   3120
      TabIndex        =   10
      Top             =   4080
      Width           =   3375
      Begin VB.ComboBox cbSecurityLevel 
         Height          =   300
         ItemData        =   "UFE30_Demo.frx":00AC
         Left            =   1500
         List            =   "UFE30_Demo.frx":00C5
         TabIndex        =   21
         Top             =   360
         Width           =   1635
      End
      Begin VB.CommandButton btnIdentify 
         Caption         =   "Identify"
         Height          =   315
         Left            =   1740
         TabIndex        =   17
         Top             =   1440
         Width           =   1395
      End
      Begin VB.CommandButton btnVerify 
         Caption         =   "Verify"
         Height          =   315
         Left            =   1740
         TabIndex        =   16
         Top             =   960
         Width           =   1395
      End
      Begin VB.CheckBox cbFastMode 
         Caption         =   "Fast Mode"
         Height          =   195
         Left            =   240
         TabIndex        =   15
         Top             =   1080
         Width           =   1275
      End
      Begin VB.Label Label8 
         Caption         =   "Security Level"
         Height          =   255
         Left            =   120
         TabIndex        =   20
         Top             =   480
         Width           =   1215
      End
   End
   Begin VB.ListBox lbScannerList 
      Height          =   1320
      Left            =   120
      TabIndex        =   7
      Top             =   780
      Width           =   2895
   End
   Begin VB.PictureBox pbImageFrame 
      Appearance      =   0  '평면
      ForeColor       =   &H80000008&
      Height          =   3735
      Left            =   3120
      ScaleHeight     =   247
      ScaleMode       =   3  '픽셀
      ScaleWidth      =   223
      TabIndex        =   6
      Top             =   120
      Width           =   3375
   End
   Begin VB.CommandButton btnEnroll 
      Caption         =   "Enroll"
      Height          =   255
      Left            =   7200
      TabIndex        =   5
      Top             =   6240
      Width           =   1695
   End
   Begin VB.CommandButton btnClear 
      Caption         =   "Clear"
      Height          =   1215
      Left            =   5760
      TabIndex        =   4
      Top             =   6240
      Width           =   735
   End
   Begin VB.TextBox txtMessage 
      Height          =   1215
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   2  '수직
      TabIndex        =   3
      Top             =   6240
      Width           =   5535
   End
   Begin VB.CommandButton btnUninit 
      Caption         =   "Uninit"
      Height          =   315
      Left            =   2040
      TabIndex        =   2
      Top             =   120
      Width           =   855
   End
   Begin VB.CommandButton btnUpdate 
      Caption         =   "Update"
      Height          =   315
      Left            =   1080
      TabIndex        =   1
      Top             =   120
      Width           =   855
   End
   Begin VB.CommandButton btnInit 
      Caption         =   "Init"
      Height          =   315
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   855
   End
   Begin VB.Frame Frame2 
      Caption         =   "Enroll"
      Height          =   2055
      Left            =   120
      TabIndex        =   9
      Top             =   4080
      Width           =   2895
      Begin VB.CommandButton btnAutoCapture 
         Caption         =   "Auto Capture"
         Height          =   315
         Left            =   120
         TabIndex        =   46
         Top             =   1080
         Width           =   1455
      End
      Begin VB.CommandButton btnAbortCapturing 
         Caption         =   "Abort"
         Height          =   315
         Left            =   1620
         TabIndex        =   14
         Top             =   360
         Width           =   1155
      End
      Begin VB.CommandButton btnStartCapturing 
         Caption         =   "Strat Capturing"
         Height          =   315
         Left            =   120
         TabIndex        =   13
         Top             =   360
         Width           =   1455
      End
      Begin VB.CommandButton btnExtract 
         Caption         =   "Extract"
         Height          =   315
         Left            =   1620
         TabIndex        =   12
         Top             =   720
         Width           =   1155
      End
      Begin VB.CommandButton btnCaptureSingle 
         Caption         =   "Capture Single"
         Height          =   315
         Left            =   120
         TabIndex        =   11
         Top             =   720
         Width           =   1455
      End
   End
   Begin MSComDlg.CommonDialog cdFileDialog 
      Left            =   0
      Top             =   6780
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame Frame4 
      Caption         =   "Enroll Mode"
      Height          =   1215
      Left            =   7200
      TabIndex        =   40
      Top             =   4320
      Width           =   2535
   End
   Begin VB.Frame Frame5 
      Caption         =   "Template"
      Height          =   3375
      Left            =   6840
      TabIndex        =   41
      Top             =   4080
      Width           =   4215
      Begin VB.Label Label6 
         Caption         =   "Quality"
         Height          =   255
         Left            =   3240
         TabIndex        =   45
         Top             =   360
         Width           =   855
      End
      Begin VB.Label Label5 
         Caption         =   "Template type"
         Height          =   255
         Left            =   720
         TabIndex        =   42
         Top             =   1680
         Width           =   1335
      End
   End
   Begin VB.Label Label1 
      Caption         =   "Scanner List"
      Height          =   255
      Left            =   120
      TabIndex        =   8
      Top             =   600
      Width           =   1335
   End
End
Attribute VB_Name = "UFE30_Demo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Option Base 0


Const MAX_TEMPLATE_SIZE As Long = 1024
Const MAX_TEMPLATE_NUM As Long = 50
Const MAX_USERID_SIZE As Long = 10
Const MAX_TEMPLATE_INPUT_NUM As Long = 4
Const MAX_TEMPLATE_OUTPUT_NUM As Long = 2

Const FINGERLIST_COL_SERIAL As Long = 0
Const FINGERLIST_COL_USERID As Long = 1
Const FINGERLIST_COL_TEMPLATE1 As Long = 2
Const FINGERLIST_COL_TEMPLATE2 As Long = 3

Private m_hMatcher As Long
Private m_strError As String
Private m_template1(MAX_TEMPLATE_SIZE - 1, MAX_TEMPLATE_NUM - 1) As Byte
Private m_templateSize1(MAX_TEMPLATE_NUM - 1) As Long
Private m_template2(MAX_TEMPLATE_SIZE - 1, MAX_TEMPLATE_NUM - 1) As Byte
Private m_templateSize2(MAX_TEMPLATE_NUM - 1) As Long
Private m_template_num As Long
Private m_quality As Long
Private m_enrolltemplate(MAX_TEMPLATE_SIZE - 1, MAX_TEMPLATE_OUTPUT_NUM - 1) As Byte
Private m_enrolltemplateSize(MAX_TEMPLATE_OUTPUT_NUM - 1) As Long
Private m_UserID(MAX_TEMPLATE_NUM - 1) As String
Private m_TemplateType As Long
Public FormEnd As Long

Private Declare Sub CopyMemory Lib "Kernel32.dll" Alias "RtlMoveMemory" (ByRef Destination As Any, ByRef Source As Any, ByVal Length As Long)
Private Declare Sub Sleep Lib "Kernel32.dll" (ByVal dwMilliseconds As Long)


'==========================================================================='
Private Sub Form_Load()
    m_hMatcher = 0
    m_template_num = 0
    
    cbType.ListIndex = 0
    m_TemplateType = 0
       
    lvFingerDataList.ColumnHeaders.Add , , "Serial", 50, lvwColumnLeft
    lvFingerDataList.ColumnHeaders.Add , , "UserID", 60, lvwColumnLeft
    lvFingerDataList.ColumnHeaders.Add , , "Template1", 80, lvwColumnLeft
    lvFingerDataList.ColumnHeaders.Add , , "Template2", 80, lvwColumnLeft
    
    obtnEnroll.value = True
    
    m_quality = 40
    
    FormEnd = 0
    
    Dim i As Long

    For i = 0 To MAX_TEMPLATE_NUM - 1
        m_templateSize1(i) = 0
        m_templateSize2(i) = 0
    Next
    
End Sub

Private Sub Form_Terminate()
    FormEnd = 1
    Dim hScanner As Long
    GetCurrentScannerHandle (hScanner)
    UFS_AbortCapturing (hScanner)
    Sleep (300)
    btnUninit_Click
    Sleep (300)
End Sub

Private Sub pbImageFrame_Paint()
    Dim hScanner As Long
    
    If (GetCurrentScannerHandle(hScanner)) Then
        Dim ufs_res As Long
        ufs_res = UFS_DrawCaptureImageBuffer(hScanner, pbImageFrame.hDC, pbImageFrame.ScaleLeft, pbImageFrame.ScaleTop, pbImageFrame.ScaleLeft + pbImageFrame.ScaleWidth, pbImageFrame.ScaleTop + pbImageFrame.ScaleHeight, 1)
    End If
End Sub
'==========================================================================='


'==========================================================================='
Public Sub AddMessage(ByVal text As String)
    txtMessage.SelStart = Len(txtMessage.text)
    txtMessage.SelText = text
    txtMessage.Refresh
End Sub

Private Sub btnClear_Click()
    txtMessage.text = ""
End Sub

Public Sub AddRow(ByVal Serial As Long, ByVal UserID As String, ByVal bTemplate1 As Boolean, ByVal bTemplate2 As Boolean)
    With lvFingerDataList.ListItems.Add(, , Serial)
        .ListSubItems.Add , , UserID
        If (bTemplate1) Then
            .ListSubItems.Add , , "O"
        Else
            .ListSubItems.Add , , "X"
        End If
        If (bTemplate2) Then
            .ListSubItems.Add , , "O"
        Else
            .ListSubItems.Add , , "X"
        End If
    End With
End Sub

Public Sub UpdateFingerDataList()
            
    lvFingerDataList.ListItems.Clear
    Dim i As Long

    For i = 0 To m_template_num - 1
        AddRow i, m_UserID(i), (m_templateSize1(i) <> 0), (m_templateSize2(i) <> 0)
    Next
End Sub
'==========================================================================='

Private Sub GetScannerTypeString(ByVal ScannerType As Long, ByRef strScannerType As String)
    If (ScannerType = UFS_SCANNER_TYPE.SFR200) Then
        strScannerType = "SFR200"
    ElseIf (ScannerType = UFS_SCANNER_TYPE.SFR300) Then
        strScannerType = "SFR300"
    ElseIf (ScannerType = UFS_SCANNER_TYPE.SFR300v2) Then
        strScannerType = "SFR300v2"
    ElseIf (ScannerType = UFS_SCANNER_TYPE.SFR500) Then
        strScannerType = "BioMini Plus"
    ElseIf (ScannerType = UFS_SCANNER_TYPE.SFR600) Then
        strScannerType = "BioMini Slim"
    Else
        strScannerType = "ERROR"
    End If
End Sub

Private Function GetCurrentScannerHandle(ByRef hScanner As Long) As Boolean
    Dim nCurScannerIndex As Long
    Dim ufs_res As UFS_STATUS
    
    nCurScannerIndex = lbScannerList.ListIndex
    ufs_res = UFS_GetScannerHandle(nCurScannerIndex, hScanner)
    If (ufs_res = UFS_STATUS.OK) Then
        GetCurrentScannerHandle = True
        Exit Function
    Else
        GetCurrentScannerHandle = False
        Exit Function
    End If
End Function
    
Private Sub GetCurrentScannerSettings()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim value As Long
    
    If (GetCurrentScannerHandle(hScanner) = False) Then
        Exit Sub
    End If
    
    ' Unit of timeout is millisecond
    ufs_res = UFS_GetParameter(hScanner, UFS_PARAM.TIMEOUT, value)
    cbTimeout.ListIndex = value / 1000
    
    ufs_res = UFS_GetParameter(hScanner, UFS_PARAM.BRIGHTNESS, value)
    tbBrightness.text = value
    
    ufs_res = UFS_GetParameter(hScanner, UFS_PARAM.SENSITIVITY, value)
    tbSensitivity.text = value

    ufs_res = UFS_GetParameter(hScanner, UFS_PARAM.DETECT_CORE, value)
    cbDetectCore.value = value
    
    cbQuality.ListIndex = 5
End Sub
    
Private Sub GetMatcherSettings(ByVal hMatcher As Long)
    Dim ufm_res As UFM_STATUS
    Dim value As Long
    
    ' Security level ranges from 1 to 7
    ufm_res = UFM_GetParameter(hMatcher, UFM_PARAM.SECURITY_LEVEL, value)
    cbSecurityLevel.ListIndex = value - 1
    
    ufm_res = UFM_GetParameter(hMatcher, UFM_PARAM.FAST_MODE, value)
    cbFastMode.value = value
End Sub

Private Sub lbScannerList_Click()
    GetCurrentScannerSettings
End Sub

Private Sub cbTimeout_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim value As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
    End If
    ' Unit of timeout is millisecond
    value = cbTimeout.ListIndex * 1000
    ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.TIMEOUT, value)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetParameter(UFS_PARAM.TIMEOUT): " & m_strError & vbCrLf)
    End If
End Sub

Private Sub tbBrightness_Change()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim value As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
    End If
    value = tbBrightness.text
    
    If (value > 255) Then
        value = 255
        tbBrightness.text = 255
    ElseIf (value < 0) Then
        value = 0
        tbBrightness.text = 0
    End If
    
    ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.BRIGHTNESS, value)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetParameter(UFS_PARAM.BRIGHTNESS): " & m_strError & vbCrLf)
    End If
End Sub

Private Sub tbSensitivity_Change()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim value As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
    End If
    value = tbSensitivity.text
    
    If (value > 7) Then
        value = 7
        tbSensitivity.text = 7
    ElseIf (value < 0) Then
        value = 0
        tbSensitivity.text = 0
    End If
    
    
    ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.SENSITIVITY, value)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetParameter(UFS_PARAM.SENSITIVITY): " & m_strError & vbCrLf)
    End If
End Sub
Private Sub cbQuality_Click()
    m_quality = 100 - ((cbQuality.ListIndex + 1) * 10)
    If (cbQuality.ListIndex = 9) Then
        m_quality = 0
    End If
End Sub

Private Sub cbDetectCore_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
    End If
    ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.DETECT_CORE, cbDetectCore.value)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetParameter(UFS_PARAM.DETECT_CORE): " & m_strError & vbCrLf)
    End If
End Sub

Private Sub cbSecurityLevel_Click()
    Dim ufm_res As UFM_STATUS
    
    ' Security level ranges from 1 to 7
    ufm_res = UFM_SetParameter(m_hMatcher, UFM_PARAM.SECURITY_LEVEL, cbSecurityLevel.ListIndex + 1)
    If (ufm_res <> UFM_STATUS.OK) Then
        UFM_GetErrorString ufm_res, m_strError
        AddMessage ("UFM_SetParameter(UFM_PARAM.SECURITY_LEVEL): " & m_strError & vbCrLf)
    End If
End Sub

Private Sub cbFastMode_Click()
    Dim ufm_res As UFM_STATUS
    
    ufm_res = UFM_SetParameter(m_hMatcher, UFM_PARAM.FAST_MODE, cbFastMode.value)
    If (ufm_res <> UFM_STATUS.OK) Then
        UFM_GetErrorString ufm_res, m_strError
        AddMessage ("UFM_SetParameter(UFM_PARAM.FAST_MODE): " & m_strError & vbCrLf)
    End If
End Sub
'==========================================================================='


'==========================================================================='
Public Sub UpdateScannerList()
    Dim ufs_res As UFS_STATUS
    Dim nScannerNumber As Long
    Dim i As Long

    ufs_res = UFS_GetScannerNumber(nScannerNumber)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFScanner GetScannerNumber: " & m_strError & vbCrLf)
        Exit Sub
    End If

    lbScannerList.Clear

    For i = 0 To nScannerNumber - 1
        Dim hScanner As Long
        Dim ScannerType As Long
        Dim strScannerType As String
        Dim strSerial As String
        Dim strID As String
        Dim str_tmp As String

        ufs_res = UFS_GetScannerHandle(i, hScanner)
        If (ufs_res <> UFS_STATUS.OK) Then
            Exit For
        End If

        ufs_res = UFS_GetParameter_B(hScanner, UFS_PARAM.Serial, strSerial)
        AddMessage ("Scanner " & i & " serial: " & strSerial & vbCrLf)

        UFS_GetScannerType hScanner, ScannerType
        UFS_GetScannerID hScanner, strID
        GetScannerTypeString ScannerType, strScannerType

        str_tmp = i & ": " & strScannerType & " " & strID
        lbScannerList.AddItem (str_tmp)
    Next

    If (nScannerNumber > 0) Then
        lbScannerList.ListIndex = 0
        GetCurrentScannerSettings
    End If
End Sub

Private Sub btnInit_Click()
    '==========================================================================='
    ' Initilize scanners
    '==========================================================================='
    Dim ufs_res As UFS_STATUS
    Dim ScannerNumber As Long
    
    Screen.MousePointer = vbHourglass
    ufs_res = UFS_Init()
    Screen.MousePointer = vbDefault
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_Init: OK" & vbCrLf)
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_Init: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    ufs_res = UFS_SetScannerCallback(AddressOf ScannerProc, 0)
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_SetScannerCallback: OK" & vbCrLf)
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetScannerCallback: " & m_strError & vbCrLf)
        Exit Sub
    End If
     
    ufs_res = UFS_GetScannerNumber(ScannerNumber)
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_GetScannerNumber: " & ScannerNumber & vbCrLf)
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_GetScannerNumber: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    UpdateScannerList
    '==========================================================================='
    
    '==========================================================================='
    ' Create matcher
    '==========================================================================='
    Dim ufm_res As UFM_STATUS

    ufm_res = UFM_Create(m_hMatcher)
    If (ufm_res = UFM_STATUS.OK) Then
        AddMessage ("UFM_Create: OK" & vbCrLf)
    Else
        UFM_GetErrorString ufm_res, m_strError
        AddMessage ("UFM_Create: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    GetMatcherSettings (m_hMatcher)
    '==========================================================================='
End Sub

Private Sub btnUpdate_Click()
    Dim ufs_res As UFM_STATUS
    
    Screen.MousePointer = vbHourglass
    ufs_res = UFS_Update()
    Screen.MousePointer = vbDefault
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_Update: OK" & vbCrLf)
        UpdateScannerList
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_Update: " & m_strError & vbCrLf)
    End If
End Sub

Private Sub btnUninit_Click()
    '==========================================================================='
    ' Uninit scanners
    '==========================================================================='
    Dim ufs_res As UFM_STATUS
    
    Screen.MousePointer = vbHourglass
    ufs_res = UFS_Uninit()
    Screen.MousePointer = vbDefault
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_Uninit: OK" & vbCrLf)
        lbScannerList.Clear
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_Uninit: " & m_strError & vbCrLf)
    End If
    '==========================================================================='
    
    '==========================================================================='
    ' Delete matcher
    '==========================================================================='
    If (m_hMatcher <> 0) Then
        Dim ufm_res As UFM_STATUS

        ufm_res = UFM_Delete(m_hMatcher)
        If (ufm_res = UFM_STATUS.OK) Then
            AddMessage ("UFM_Delete: OK" & vbCrLf)
        Else
            UFM_GetErrorString ufm_res, m_strError
            AddMessage ("UFM_Delete: " & m_strError & vbCrLf)
        End If
        m_hMatcher = 0
    End If
    '==========================================================================='
End Sub

Private Sub btnStartCapturing_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
    
    ufs_res = UFS_StartCapturing(hScanner, AddressOf CaptureProc, 0)
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_StartCapturing: OK" & vbCrLf)
        pbImageFrame.Refresh
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_StartCapturing: " & m_strError & vbCrLf)
    End If
End Sub

Private Sub btnAutoCapture_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
    
    ufs_res = UFS_StartAutoCapture(hScanner, AddressOf CaptureProc, 0)
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_StartAutoCapture: OK" & vbCrLf)
        pbImageFrame.Refresh
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_StartAutoCapture: " & m_strError & vbCrLf)
    End If
End Sub

Private Sub btnAbortCapturing_Click()
    Dim ufs_res As UFM_STATUS
    Dim hScanner As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
    
    ufs_res = UFS_AbortCapturing(hScanner)
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_AbortCapturing: OK" & vbCrLf)
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_AbortCapturing: " & m_strError & vbCrLf)
    End If
End Sub

Private Sub btnCaptureSingle_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long

    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If

    AddMessage ("Place your finger" & vbCrLf)
    
    Screen.MousePointer = vbHourglass
    ufs_res = UFS_CaptureSingleImage(hScanner)
    Screen.MousePointer = vbDefault
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_CaptureSingleImage: OK" & vbCrLf)
        pbImageFrame.Refresh
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_CaptureSingleImage: " & m_strError & vbCrLf)
    End If
End Sub

Private Sub btnExtract_Click()
    Dim hScanner As Long
    Dim ufs_res As UFS_STATUS
    Dim value As Long

    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
    value = MAX_TEMPLATE_SIZE
    UFS_SetParameter hScanner, UFS_PARAM.TEMPLATE_SIZE, value
    value = cbDetectCore.value
    UFS_SetParameter hScanner, UFS_PARAM.DETECT_CORE, value
    
    If (cbType.ListIndex = 0) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ANSI378
    End If
    
    Dim Template(MAX_TEMPLATE_SIZE - 1) As Byte
    Dim TemplateSize As Long
    Dim EnrollQuality As Long
 
    Screen.MousePointer = vbHourglass
    ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template(0), TemplateSize, EnrollQuality)
    Screen.MousePointer = vbDefault
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("UFS_ExtractEx: OK" & vbCrLf)
        pbImageFrame.Refresh
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_ExtractEx: " & m_strError & vbCrLf)
    End If
End Sub

Private Sub btnEnroll_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim EnrollQuality As Long
    Dim EnrollMode As Long
    Dim i As Long
    Dim value As Long
    Dim template_enrolled As Long
    Dim fingeron As Long

    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If

    AddMessage ("Place your finger" & vbCrLf)
    
    If (cbType.ListIndex = 0) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ANSI378
    End If
    
    If (obtnAdEnroll1 = True) Then
        EnrollMode = 1
    Else
        EnrollMode = 2
    End If
    
    template_enrolled = 0
       
    AddMessage ("Input user data" & vbCrLf)
    UFE30_User_Info.SetAdd
    UFE30_User_Info.Show vbModal
    If (Not UFE30_User_Info.DialogResult) Then
        AddMessage ("User data input is cancelled by user" & vbCrLf)
        Exit Sub
    End If
    
    Me.Refresh
        
    'Enroll Template with Non-Advanced-Extraction
    If (obtnEnroll = True Or obtnEnroll2 = True) Then
        UFS_ClearCaptureImageBuffer (hScanner)
        AddMessage ("Place a finger" & vbCrLf)
        
        Do
            ufs_res = UFS_CaptureSingleImage(hScanner)
            If (ufs_res <> UFS_STATUS.OK) Then
                UFS_GetErrorString ufs_res, m_strError
                AddMessage ("UFS_CaptureSingleImage: " & m_strError & vbCrLf)
                Exit Sub
            End If
            
            If (m_template_num + 1 = MAX_TEMPLATE_NUM) Then
                AddMessage ("Template memory is full" & vbCrLf)
                Exit Sub
            End If
            
            If (template_enrolled = 0) Then
                ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, m_template1(0, m_template_num), m_templateSize1(m_template_num), EnrollQuality)
            Else
                ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, m_template2(0, m_template_num), m_templateSize2(m_template_num), EnrollQuality)
            End If
            
            pbImageFrame.Refresh
            
            If ufs_res = UFS_STATUS.OK Then
                If (EnrollQuality < m_quality) Then
                    AddMessage ("Template Quality is too low" & vbCrLf)
                Else
                    m_UserID(m_template_num) = UFE30_User_Info.txtUserID
                    template_enrolled = template_enrolled + 1
                    AddMessage ("Enrollment success (No." & m_template_num & ") [Q:" & EnrollQuality & "]" & vbCrLf)
                    
                    If (obtnEnroll = True) Then
                        m_template_num = m_template_num + 1
                        UpdateFingerDataList
                        Exit Do
                    ElseIf (obtnEnroll2 = True And template_enrolled = 2) Then
                        m_template_num = m_template_num + 1
                        UpdateFingerDataList
                        Exit Do
                    Else
                        AddMessage ("Remove finger" & vbCrLf)
                        Do
                            ufs_res = UFS_IsFingerOn(hScanner, fingeron)
                            If (fingeron = 0) Then
                                AddMessage ("Place a finger" & vbCrLf)
                                Exit Do
                            End If
                        Loop While 1
                    End If
                End If
            Else
                UFS_GetErrorString ufs_res, m_strError
                AddMessage ("UFS_ExtractEx: " & m_strError & vbCrLf)
            End If
        Loop While 1
    'Enroll with Advanced-Extraction
    Else
        For i = 0 To EnrollMode - 1
            Call CopyMemory(ByVal VarPtr(m_enrolltemplate(0, i)), 0, MAX_TEMPLATE_SIZE - 1)
            m_enrolltemplateSize(i) = 0
        Next
        
        UFE30_Enroll.m_hScanner = hScanner
        UFE30_Enroll.txtUserID = UFE30_User_Info.txtUserID
        UFE30_Enroll.OutputNum = EnrollMode
        UFE30_Enroll.Quality = m_quality
        
        UFE30_Enroll.Show vbModal
        If (Not UFE30_Enroll.DialogResult) Then
            AddMessage ("Fingerprint enrollment is cancelled by user" & vbCrLf)
            Exit Sub
        End If
        
        For i = 0 To EnrollMode - 1
            UFE30_Enroll.GetOutputTemplate ByVal VarPtr(m_enrolltemplate(0, i)), m_enrolltemplateSize(i), i
        Next
        
        If (m_enrolltemplateSize(0) <> 0) Then
            If (m_template_num + 1 = MAX_TEMPLATE_NUM) Then
                AddMessage ("Template memory is full" & vbCrLf)
            Else
                'Enroll 1-Template
                If (obtnAdEnroll1 = True) Then
                    Call CopyMemory(ByVal VarPtr(m_template1(0, m_template_num)), ByVal VarPtr(m_enrolltemplate(0, 0)), m_enrolltemplateSize(0))
                    m_templateSize1(m_template_num) = m_enrolltemplateSize(0)
                    m_UserID(m_template_num) = UFE30_User_Info.txtUserID
                'Enroll 2-Template
                Else
                    Call CopyMemory(ByVal VarPtr(m_template1(0, m_template_num)), ByVal VarPtr(m_enrolltemplate(0, 0)), m_enrolltemplateSize(0))
                    m_templateSize1(m_template_num) = m_enrolltemplateSize(0)
                    
                    Call CopyMemory(ByVal VarPtr(m_template2(0, m_template_num)), ByVal VarPtr(m_enrolltemplate(0, 1)), m_enrolltemplateSize(1))
                    m_templateSize2(m_template_num) = m_enrolltemplateSize(1)
                    
                    m_UserID(m_template_num) = UFE30_User_Info.txtUserID
                End If

                AddMessage ("Enrollment is succeed (No." & m_template_num & ")" & vbCrLf)
                m_template_num = m_template_num + 1
            End If
            UpdateFingerDataList
        Else
            AddMessage ("Enrollment is failed" & vbCrLf)
        End If
        
        value = cbTimeout.ListIndex * 1000
        ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.TIMEOUT, value)
        If (ufs_res <> UFS_STATUS.OK) Then
            ufs_res = UFS_GetErrorString(ufs_res, m_strError)
            AddMessage ("UFS_SetParameter(UFS_PARAM_TIMEOUT): " & m_strError & vbCrLf)
        End If
        
    End If
End Sub

Private Sub btnVerify_Click()
    Dim hScanner As Long
    Dim ufs_res As UFS_STATUS
    Dim ufm_res As UFM_STATUS
    Dim Template(MAX_TEMPLATE_SIZE - 1) As Byte
    Dim TemplateSize As Long
    Dim EnrollQuality As Long
    Dim VerifySucceed As Long
    Dim SelectID As Integer

    If (Not lvFingerDataList.SelectedItem.Selected) Then
        AddMessage ("Select data" & vbNewLine)
        Exit Sub
    Else
        SelectID = Val(lvFingerDataList.SelectedItem.text)
    End If
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
    
    If (cbType.ListIndex = 0) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ANSI378
    End If
    
    AddMessage ("Verify with serial: " & SelectID & vbCrLf)
    
    UFS_ClearCaptureImageBuffer (hScanner)

    AddMessage ("Place your finger" & vbCrLf)
    
    ufs_res = UFS_CaptureSingleImage(hScanner)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_CaptureSingleImage: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template(0), TemplateSize, EnrollQuality)
    If ufs_res = UFS_STATUS.OK Then
        pbImageFrame.Refresh
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_ExtractEx: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    If (cbType.ListIndex = 0) Then
        UFM_SetTemplateType m_hMatcher, UFM_TEMPLATE_TYPE.UFM_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFM_SetTemplateType m_hMatcher, UFM_TEMPLATE_TYPE.UFM_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFM_SetTemplateType m_hMatcher, UFM_TEMPLATE_TYPE.UFM_TEMPLATE_TYPE_ANSI378
    End If
    
    ufm_res = UFM_Verify(m_hMatcher, Template(0), TemplateSize, m_template1(0, SelectID), m_templateSize1(SelectID), VerifySucceed)
    If ufm_res <> UFM_STATUS.OK Then
        UFM_GetErrorString ufm_res, m_strError
        AddMessage ("UFM_Verify: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    If (VerifySucceed) Then
        AddMessage ("Verification succeed (Serial." & (SelectID) & ") (ID." & m_UserID(SelectID) & ")" & vbCrLf)
    Else
        If (m_templateSize2(SelectID) <> 0) Then
            AddMessage ("Verification succeed (Serial." & (SelectID) & ") (ID." & m_UserID(SelectID) & ")" & vbCrLf)
            If (ufs_res <> UFS_STATUS.OK) Then
                UFM_GetErrorString ufm_res, m_strError
                AddMessage ("UFMatcher Verify: " & m_strError & vbCrLf)
            End If
             
            If (VerifySucceed) Then
                AddMessage ("Verification succeed (No." & (SelectID) & ")" & vbCrLf)
            Else
                AddMessage ("Verification failed" & vbCrLf)
            End If
        Else
            AddMessage ("Verification failed" & vbCrLf)
        End If
    End If
End Sub

Private Sub btnIdentify_Click()
    Dim hScanner As Long
    Dim ufs_res As UFS_STATUS
    Dim ufm_res As UFM_STATUS
    Dim Template(MAX_TEMPLATE_SIZE - 1) As Byte
    Dim TemplateSize As Long
    Dim EnrollQuality As Long
    Dim MatchIndex As Long
    
    Dim template_all(MAX_TEMPLATE_SIZE - 1, (MAX_TEMPLATE_NUM * 2) - 1) As Byte
    Dim templateSize_all((MAX_TEMPLATE_NUM * 2) - 1) As Long
    Dim nindex((MAX_TEMPLATE_NUM * 2) - 1) As Long
    Dim j As Long
    Dim i As Long
    Dim nMaxTemplateNum As Long
    
    j = 0
    nMaxTemplateNum = 0

    For i = 0 To (m_template_num * 2) - 1
        If (i < m_template_num) Then
            If (m_templateSize1(i) <> 0) Then
                Call CopyMemory(ByVal VarPtr(template_all(0, j)), ByVal VarPtr(m_template1(0, i)), m_templateSize1(i))
                templateSize_all(j) = m_templateSize1(i)
                nindex(j) = i
                j = j + 1
            End If
        Else
            If (m_templateSize2(i - m_template_num) <> 0) Then
                Call CopyMemory(ByVal VarPtr(template_all(0, j)), ByVal VarPtr(m_template2(0, i - m_template_num)), m_templateSize2(i - m_template_num))
                templateSize_all(j) = m_templateSize2(i - m_template_num)
                nindex(j) = i - m_template_num
                j = j + 1
            End If
        End If
    Next

    nMaxTemplateNum = j
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
    
    If (cbType.ListIndex = 0) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ANSI378
    End If
    
    UFS_ClearCaptureImageBuffer (hScanner)

    AddMessage ("Place your finger" & vbCrLf)
    
    ufs_res = UFS_CaptureSingleImage(hScanner)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_CaptureSingleImage: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template(0), TemplateSize, EnrollQuality)
    If ufs_res = UFS_STATUS.OK Then
        pbImageFrame.Refresh
    Else
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_ExtractEx: " & m_strError & vbCrLf)
        Exit Sub
    End If
    
    ' Make template pointer array to pass two dimensional template data
    Dim template_ptr((MAX_TEMPLATE_NUM * 2) - 1) As Long
    For i = 0 To nMaxTemplateNum - 1
        template_ptr(i) = VarPtr(template_all(0, i))
    Next
    
    If (cbType.ListIndex = 0) Then
        UFM_SetTemplateType m_hMatcher, UFM_TEMPLATE_TYPE.UFM_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFM_SetTemplateType m_hMatcher, UFM_TEMPLATE_TYPE.UFM_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFM_SetTemplateType m_hMatcher, UFM_TEMPLATE_TYPE.UFM_TEMPLATE_TYPE_ANSI378
    End If
    
    ufm_res = UFM_Identify(m_hMatcher, Template(0), TemplateSize, template_ptr(0), templateSize_all(0), nMaxTemplateNum, 5000, MatchIndex)
    If ufm_res <> UFM_STATUS.OK Then
        UFM_GetErrorString ufm_res, m_strError
        AddMessage ("UFM_Identify: " & m_strError & vbCrLf)
        Exit Sub
    End If
   
    If (MatchIndex <> -1) Then
        AddMessage ("Identification succeed (Match Index." & MatchIndex & ") (Serial." & nindex(MatchIndex) Mod nMaxTemplateNum & ") (ID." & m_UserID(nindex(MatchIndex)) & ")" & vbCrLf)
    Else
        AddMessage ("Identification failed" & vbCrLf)
    End If
End Sub

Private Sub btnSaveTemplate_Click()
    Dim filenum As Integer
    Dim i As Long
        
    Dim Serial As Integer

    If (Not lvFingerDataList.SelectedItem.Selected) Then
        AddMessage ("Select data" & vbNewLine)
        Exit Sub
    Else
        Serial = Val(lvFingerDataList.SelectedItem.text)
    End If
    
    cdFileDialog.Filter = "Template Files (*.tmp)|*.tmp"
    cdFileDialog.DefaultExt = "tmp"
    cdFileDialog.Flags = cdlOFNHideReadOnly Or cdlOFNPathMustExist Or cdlOFNOverwritePrompt Or cdlOFNNoReadOnlyReturn
    cdFileDialog.ShowSave
    
    If (cdFileDialog.FileName = "") Then
        AddMessage ("Input file name is cancelled" & vbNewLine)
        Exit Sub
    End If
    
    filenum = FreeFile()
    Open cdFileDialog.FileName For Binary As #filenum
    For i = 0 To m_templateSize1(Serial)
        Put #filenum, , m_template1(i, Serial)
    Next
    Close #filenum
    
    If (m_templateSize2(Serial) <> 0) Then
        cdFileDialog.Filter = "Template Files (*.tmp)|*.tmp"
        cdFileDialog.DefaultExt = "tmp"
        cdFileDialog.Flags = cdlOFNHideReadOnly Or cdlOFNPathMustExist Or cdlOFNOverwritePrompt Or cdlOFNNoReadOnlyReturn
        cdFileDialog.ShowSave
        
        If (cdFileDialog.FileName = "") Then
            AddMessage ("Input file name is cancelled" & vbNewLine)
            Exit Sub
        End If
    
        filenum = FreeFile()
        Open cdFileDialog.FileName For Binary As #filenum
        For i = 0 To m_templateSize2(Serial)
            Put #filenum, , m_template2(i, Serial)
        Next
        Close #filenum
    End If
End Sub

Private Sub btnSaveImage_Click()
    Dim hScanner As Long
    Dim ufs_res As UFS_STATUS
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If
        
    cdFileDialog.Filter = "Bitmap Files (*.bmp)|*.bmp"
    cdFileDialog.DefaultExt = "bmp"
    cdFileDialog.Flags = cdlOFNHideReadOnly Or cdlOFNPathMustExist Or cdlOFNOverwritePrompt Or cdlOFNNoReadOnlyReturn
    cdFileDialog.ShowSave
    
    If (cdFileDialog.FileName = "") Then
        AddMessage ("Input file name is cancelled" & vbNewLine)
        Exit Sub
    End If
    
    ufs_res = UFS_SaveCaptureImageBufferToBMP(hScanner, cdFileDialog.FileName)
    If (ufs_res = UFS_STATUS.OK) Then
        AddMessage ("Captured image is saved" & vbCrLf)
    End If
End Sub

Private Sub btnDeleteAll_Click()

    Dim i As Long
    For i = 0 To MAX_TEMPLATE_NUM - 1
        
        Call CopyMemory(ByVal VarPtr(m_template1(0, i)), 0, MAX_TEMPLATE_SIZE)
        m_templateSize1(i) = 0
         
        Call CopyMemory(ByVal VarPtr(m_template2(0, i)), 0, MAX_TEMPLATE_SIZE)
        m_templateSize2(i) = 0
        
        m_UserID(i) = ""
    Next

    m_template_num = 0

    UpdateFingerDataList

End Sub

Private Sub btnDeleteTemplate_Click()
    Dim Serial As Long
    Dim i As Long
    
    If (Not lvFingerDataList.SelectedItem.Selected) Then
        AddMessage ("Select data" & vbNewLine)
        Exit Sub
    Else
        Serial = Val(lvFingerDataList.SelectedItem.text)
    End If

    For i = Serial To m_template_num - 1
        Call CopyMemory(ByVal VarPtr(m_template1(0, i)), 0, MAX_TEMPLATE_SIZE)
        Call CopyMemory(ByVal VarPtr(m_template1(0, i)), ByVal VarPtr(m_template1(0, i + 1)), m_templateSize1(i + 1))
        m_templateSize1(i) = m_templateSize1(i + 1)

        Call CopyMemory(ByVal VarPtr(m_template2(0, i)), 0, MAX_TEMPLATE_SIZE)
        Call CopyMemory(ByVal VarPtr(m_template2(0, i)), ByVal VarPtr(m_template2(0, i + 1)), m_templateSize2(i + 1))
        m_templateSize2(i) = m_templateSize2(i + 1)

        m_UserID(i) = m_UserID(i + 1)
    Next

    Call CopyMemory(ByVal VarPtr(m_template1(0, m_template_num - 1)), 0, MAX_TEMPLATE_SIZE)
    Call CopyMemory(ByVal VarPtr(m_template2(0, m_template_num - 1)), 0, MAX_TEMPLATE_SIZE)
    
    m_templateSize1(m_template_num - 1) = 0
    m_templateSize2(m_template_num - 1) = 0
    m_UserID(m_template_num - 1) = ""

    m_template_num = m_template_num - 1

    UpdateFingerDataList
End Sub

Private Sub btnUpdateTemplate_Click()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim Template(MAX_TEMPLATE_SIZE - 1) As Byte
    Dim TemplateSize As Long
    Dim EnrollQuality As Long
    Dim EnrollMode As Long
    Dim i As Long
    Dim value As Long
    Dim Serial As Long
    Dim template_enrolled As Long
    Dim fingeron As Long
    
    If (Not lvFingerDataList.SelectedItem.Selected) Then
        AddMessage ("Select data" & vbNewLine)
        Exit Sub
    Else
        Serial = Val(lvFingerDataList.SelectedItem.text)
    End If

    If (GetCurrentScannerHandle(hScanner) <> True) Then
        Exit Sub
    End If

    AddMessage ("Place your finger" & vbCrLf)
    
    If (cbType.ListIndex = 0) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_SUPREMA
    ElseIf (cbType.ListIndex = 1) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ISO19794_2
    ElseIf (cbType.ListIndex = 2) Then
        UFS_SetTemplateType hScanner, UFS_TEMPLATE_TYPE.UFS_TEMPLATE_TYPE_ANSI378
    End If
    
    If (obtnAdEnroll1 = True) Then
        EnrollMode = 1
    Else
        EnrollMode = 2
    End If
    
    template_enrolled = 0
            
    'Update Template with Non-Advanced-Extraction
    If (obtnEnroll = True Or obtnEnroll2 = True) Then
        UFS_ClearCaptureImageBuffer (hScanner)
        AddMessage ("Place a finger" & vbCrLf)
        
        Do
            ufs_res = UFS_CaptureSingleImage(hScanner)
            If (ufs_res <> UFS_STATUS.OK) Then
                UFS_GetErrorString ufs_res, m_strError
                AddMessage ("UFS_CaptureSingleImage: " & m_strError & vbCrLf)
                Exit Sub
            End If
            
            ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template(0), TemplateSize, EnrollQuality)
            
            pbImageFrame.Refresh
            
            If ufs_res = UFS_STATUS.OK Then
                If (EnrollQuality < m_quality) Then
                    AddMessage ("Template Quality is too low" & vbCrLf)
                Else
                    If (obtnEnroll = True) Then
                        Call CopyMemory(ByVal VarPtr(m_template2(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                        m_templateSize2(Serial) = 0
                        
                        Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                        Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), ByVal VarPtr(Template(0)), TemplateSize)
                        m_templateSize1(Serial) = TemplateSize
                        AddMessage ("Update success (Serial." & Serial & ") [Q:" & EnrollQuality & "]" & vbCrLf)
                        UpdateFingerDataList
                        Exit Do
                    ElseIf (obtnEnroll2 = True And template_enrolled = 1) Then
                        Call CopyMemory(ByVal VarPtr(m_template2(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                        Call CopyMemory(ByVal VarPtr(m_template2(0, Serial)), ByVal VarPtr(Template(0)), TemplateSize)
                        m_templateSize2(Serial) = TemplateSize
                        AddMessage ("Second template update success (Serial." & Serial & ") [Q:" & EnrollQuality & "]" & vbCrLf)
                        UpdateFingerDataList
                        Exit Do
                    Else
                        template_enrolled = template_enrolled + 1
                        Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                        Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), ByVal VarPtr(Template(0)), TemplateSize)
                        m_templateSize1(Serial) = TemplateSize
                        AddMessage ("First template update success (Serial." & Serial & ") [Q:" & EnrollQuality & "]" & vbCrLf)
                        AddMessage ("Remove finger" & vbCrLf)
                        Do
                            ufs_res = UFS_IsFingerOn(hScanner, fingeron)
                            If (fingeron = 0) Then
                                AddMessage ("Place a finger" & vbCrLf)
                                Exit Do
                            End If
                        Loop While 1
                    End If
                End If
            Else
                UFS_GetErrorString ufs_res, m_strError
                AddMessage ("UFS_ExtractEx: " & m_strError & vbCrLf)
            End If
        Loop While 1
    'Update with Advanced-Extraction
    Else
        For i = 0 To EnrollMode - 1
            Call CopyMemory(ByVal VarPtr(m_enrolltemplate(0, i)), 0, MAX_TEMPLATE_SIZE - 1)
            m_enrolltemplateSize(i) = 0
        Next
        
        UFE30_Enroll.m_hScanner = hScanner
        UFE30_Enroll.txtUserID = m_UserID(Serial)
        UFE30_Enroll.OutputNum = EnrollMode
        UFE30_Enroll.Quality = m_quality
        
        UFE30_Enroll.Show vbModal
        If (Not UFE30_Enroll.DialogResult) Then
            AddMessage ("Fingerprint update is cancelled by user" & vbCrLf)
            Exit Sub
        End If
        
        For i = 0 To EnrollMode - 1
            UFE30_Enroll.GetOutputTemplate ByVal VarPtr(m_enrolltemplate(0, i)), m_enrolltemplateSize(i), i
        Next
        
        If (m_enrolltemplateSize(0) <> 0) Then
            'Update 1-Template
            If (obtnAdEnroll1 = True) Then
                Call CopyMemory(ByVal VarPtr(m_template2(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                m_templateSize2(Serial) = 0
                
                Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), ByVal VarPtr(m_enrolltemplate(0, 0)), m_enrolltemplateSize(0))
                m_templateSize1(Serial) = m_enrolltemplateSize(0)
            'Update 2-Template
            Else
                Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                Call CopyMemory(ByVal VarPtr(m_template1(0, Serial)), ByVal VarPtr(m_enrolltemplate(0, 0)), m_enrolltemplateSize(0))
                m_templateSize1(Serial) = m_enrolltemplateSize(0)
                
                Call CopyMemory(ByVal VarPtr(m_template2(0, Serial)), 0, MAX_TEMPLATE_SIZE)
                Call CopyMemory(ByVal VarPtr(m_template2(0, Serial)), ByVal VarPtr(m_enrolltemplate(0, 1)), m_enrolltemplateSize(1))
                m_templateSize2(Serial) = m_enrolltemplateSize(1)
            End If

            AddMessage ("Updating is succeed (No." & Serial & ")" & vbCrLf)

            UpdateFingerDataList
        Else
            AddMessage ("Updating is failed" & vbCrLf)
        End If
        
        value = cbTimeout.ListIndex * 1000
        ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.TIMEOUT, value)
        If (ufs_res <> UFS_STATUS.OK) Then
            ufs_res = UFS_GetErrorString(ufs_res, m_strError)
            AddMessage ("UFS_SetParameter(UFS_PARAM_TIMEOUT): " & m_strError & vbCrLf)
        End If
        
    End If

End Sub

Private Sub cbType_Click()
    If (cbType.ListIndex <> m_TemplateType And m_template_num > 0) Then
        AddMessage ("It is not allowed to mix template format" & vbCrLf & "Please remove all templates if you want to use other template format" & vbCrLf)
        cbType.ListIndex = m_TemplateType
    Else
        m_TemplateType = cbType.ListIndex
    End If
End Sub
'==========================================================================='


Private Sub tdBrightness_Change()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim value As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
    End If
    value = tbBrightness.text
    
    If (value > 255) Then
        value = 255
        tbBrightness.text = 255
    ElseIf (value < 0) Then
        value = 0
        tbBrightness.text = 0
    End If
    
    ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.BRIGHTNESS, value)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetParameter(UFS_PARAM.BRIGHTNESS): " & m_strError & vbCrLf)
    End If

End Sub

Private Sub udSensitivity_Change()
    Dim ufs_res As UFS_STATUS
    Dim hScanner As Long
    Dim value As Long
    
    If (GetCurrentScannerHandle(hScanner) <> True) Then
    End If
    value = tbSensitivity.text
    
    If (value > 7) Then
        value = 7
        tbSensitivity.text = 7
    ElseIf (value < 0) Then
        value = 0
        tbSensitivity.text = 0
    End If
    
    ufs_res = UFS_SetParameter(hScanner, UFS_PARAM.SENSITIVITY, value)
    If (ufs_res <> UFS_STATUS.OK) Then
        UFS_GetErrorString ufs_res, m_strError
        AddMessage ("UFS_SetParameter(UFS_PARAM.SENSITIVITY): " & m_strError & vbCrLf)
    End If
End Sub
