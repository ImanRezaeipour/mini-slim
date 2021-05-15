VERSION 5.00
Begin VB.Form UFE30_Enroll 
   Caption         =   "Enroll"
   ClientHeight    =   5085
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6855
   LinkTopic       =   "Form1"
   ScaleHeight     =   5085
   ScaleWidth      =   6855
   StartUpPosition =   1  '소유자 가운데
   Begin VB.TextBox Text1 
      BackColor       =   &H8000000F&
      BorderStyle     =   0  '없음
      Height          =   1095
      Left            =   3480
      MultiLine       =   -1  'True
      TabIndex        =   6
      Text            =   "UFE30_Enroll.frx":0000
      Top             =   240
      Width           =   2895
   End
   Begin VB.PictureBox pbImageFrame 
      Appearance      =   0  '평면
      ForeColor       =   &H80000008&
      Height          =   3015
      Left            =   360
      ScaleHeight     =   199
      ScaleMode       =   3  '픽셀
      ScaleWidth      =   183
      TabIndex        =   5
      Top             =   240
      Width           =   2775
   End
   Begin VB.TextBox txtUserID 
      Enabled         =   0   'False
      Height          =   270
      Left            =   4440
      TabIndex        =   4
      Text            =   "Text1"
      Top             =   1560
      Width           =   1695
   End
   Begin VB.TextBox txtMessage 
      Height          =   1095
      Left            =   360
      MultiLine       =   -1  'True
      ScrollBars      =   2  '수직
      TabIndex        =   2
      Top             =   3480
      Width           =   6015
   End
   Begin VB.CommandButton btnCancel 
      Caption         =   "Cancel"
      Height          =   375
      Left            =   5040
      TabIndex        =   1
      Top             =   2760
      Width           =   1335
   End
   Begin VB.CommandButton btnOK 
      Caption         =   "OK"
      Height          =   375
      Left            =   3480
      TabIndex        =   0
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label Label1 
      Caption         =   "User ID:"
      Height          =   255
      Left            =   3480
      TabIndex        =   3
      Top             =   1560
      Width           =   735
   End
End
Attribute VB_Name = "UFE30_Enroll"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Option Base 0

Const MAX_TEMPLATE_INPUT_NUM  As Long = 4
Const MAX_TEMPLATE_OUTPUT_NUM As Long = 2
Const MAX_TEMPLATE_SIZE As Long = 1024

Public DialogResult As Boolean
Public TryExtract As Boolean
Public FingerCheck As Boolean
Public ExtractNum As Long
Public OutputNum As Long
Public m_hScanner As Long
Public FormEnd As Long
Public Quality As Long

Private m_EnrollTemplate_output(MAX_TEMPLATE_SIZE - 1, MAX_TEMPLATE_OUTPUT_NUM - 1) As Byte
Private m_EnrollTemplateSize_output(MAX_TEMPLATE_OUTPUT_NUM - 1) As Long

Private Declare Sub CopyMemory Lib "Kernel32.dll" Alias "RtlMoveMemory" (ByRef Destination As Any, ByRef Source As Any, ByVal Length As Long)
Private Declare Sub Sleep Lib "Kernel32.dll" (ByVal dwMilliseconds As Long)

'==========================================================================='
Public Sub AddMessage(ByVal text As String)
    txtMessage.SelStart = Len(txtMessage.text)
    txtMessage.SelText = text
    txtMessage.Refresh
End Sub

Public Sub GetOutputTemplate(ByVal Template As Long, ByRef TemplateSize As Long, ByVal index As Long)
    Call CopyMemory(ByVal Template, ByVal VarPtr(m_EnrollTemplate_output(0, index)), m_EnrollTemplateSize_output(index))
    TemplateSize = m_EnrollTemplateSize_output(index)
End Sub

Public Sub SetOutputTemplate(ByRef Template() As Byte, ByVal TemplateSize As Long, ByVal index As Long)
    Dim i As Long
    For i = 0 To TemplateSize
        m_EnrollTemplate_output(i, index) = Template(i, index)
    Next
    m_EnrollTemplateSize_output(index) = TemplateSize
End Sub


Private Sub Form_Activate()
    Dim i As Long
    Dim value As Long
    Dim ufs_res As UFS_STATUS
    value = 0
    ExtractNum = 0
    TryExtract = True
    FingerCheck = False
    FormEnd = 0
        
    For i = 0 To MAX_TEMPLATE_OUTPUT_NUM - 1
        Call CopyMemory(ByVal VarPtr(m_EnrollTemplate_output(0, i)), 0, MAX_TEMPLATE_SIZE)
        m_EnrollTemplateSize_output(i) = 0
    Next
    
    AddMessage ("Advanced Enroll is started. Place your finger" & vbCrLf)

    ufs_res = UFS_ClearCaptureImageBuffer(m_hScanner)
    ufs_res = UFS_SetParameter(m_hScanner, UFS_PARAM.TIMEOUT, value)
    ufs_res = UFS_StartCapturing(m_hScanner, AddressOf EnrollProc, 0)
End Sub


Private Sub btnOK_Click()
    Dim ufs_res As UFS_STATUS
    ufs_res = UFS_AbortCapturing(m_hScanner)
    Dim pbCapturing As Long
    Dim i As Long
    
    FormEnd = 1
    
    Sleep (100)
    
    DialogResult = True
    Me.Hide
End Sub

Private Sub btnCancel_Click()
    Dim ufs_res As UFS_STATUS
    ufs_res = UFS_AbortCapturing(m_hScanner)
    Dim pbCapturing As Long
    Dim i As Long
    
    FormEnd = 1
    
    Sleep (100)
    
    DialogResult = False
    Me.Hide
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Dim ufs_res As UFS_STATUS
    ufs_res = UFS_AbortCapturing(m_hScanner)
    FormEnd = 1
    
    Sleep (100)
    
    DialogResult = False
End Sub

Private Sub pbImageFrame_Paint()
    Dim ufs_res As Long
    ufs_res = UFS_DrawCaptureImageBuffer(m_hScanner, pbImageFrame.hDC, pbImageFrame.ScaleLeft, pbImageFrame.ScaleTop, pbImageFrame.ScaleLeft + pbImageFrame.ScaleWidth, pbImageFrame.ScaleTop + pbImageFrame.ScaleHeight, 0)
End Sub
