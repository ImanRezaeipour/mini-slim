VERSION 5.00
Begin VB.Form UserInfoForm 
   BorderStyle     =   3  '크기 고정 대화 상자
   Caption         =   "User Info"
   ClientHeight    =   3240
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3795
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3240
   ScaleWidth      =   3795
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows 기본값
   Begin VB.CommandButton btnCancel 
      Cancel          =   -1  'True
      Caption         =   "Cancel"
      Height          =   315
      Left            =   1980
      TabIndex        =   7
      Top             =   2760
      Width           =   1635
   End
   Begin VB.CommandButton btnOK 
      Caption         =   "OK"
      Height          =   315
      Left            =   180
      TabIndex        =   6
      Top             =   2760
      Width           =   1635
   End
   Begin VB.TextBox txtMemo 
      Height          =   1575
      Left            =   1440
      MultiLine       =   -1  'True
      TabIndex        =   5
      Top             =   1020
      Width           =   2175
   End
   Begin VB.TextBox txtFingerIndex 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   1042
         SubFormatType   =   1
      EndProperty
      Height          =   330
      Left            =   1440
      MaxLength       =   1
      TabIndex        =   4
      Top             =   600
      Width           =   555
   End
   Begin VB.TextBox txtUserID 
      Height          =   330
      Left            =   1440
      MaxLength       =   50
      TabIndex        =   3
      Top             =   180
      Width           =   2055
   End
   Begin VB.Label Label3 
      Alignment       =   1  '오른쪽 맞춤
      Caption         =   "Memo"
      Height          =   255
      Left            =   420
      TabIndex        =   2
      Top             =   1080
      Width           =   795
   End
   Begin VB.Label Label2 
      Alignment       =   1  '오른쪽 맞춤
      Caption         =   "FingerIndex"
      Height          =   195
      Left            =   180
      TabIndex        =   1
      Top             =   660
      Width           =   1035
   End
   Begin VB.Label Label1 
      Alignment       =   1  '오른쪽 맞춤
      Caption         =   "UserID"
      Height          =   195
      Left            =   360
      TabIndex        =   0
      Top             =   240
      Width           =   855
   End
End
Attribute VB_Name = "UserInfoForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Option Base 0


Public DialogResult As Boolean


Public Sub SetAdd()
    DialogResult = False
    txtUserID = "UserID"
    txtFingerIndex = "0"
    txtMemo = "Memo"
    
    txtUserID.Enabled = True
    txtFingerIndex.Enabled = True
End Sub

Public Sub SetUpdate()
    DialogResult = False
    txtUserID = "UserID"
    txtFingerIndex = "0"
    txtMemo = "Memo"
    
    txtUserID.Enabled = False
    txtFingerIndex.Enabled = False
End Sub

Private Sub btnOK_Click()
    DialogResult = True
    Me.Hide
End Sub

Private Sub btnCancel_Click()
    DialogResult = False
    Me.Hide
End Sub

Private Sub Form_Load()
    SetAdd
End Sub
