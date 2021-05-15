VERSION 5.00
Begin VB.Form UFE30_User_Info 
   Caption         =   "User Info"
   ClientHeight    =   1860
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4020
   LinkTopic       =   "Form1"
   ScaleHeight     =   1860
   ScaleWidth      =   4020
   StartUpPosition =   1  '소유자 가운데
   Begin VB.CommandButton btnCancel 
      Caption         =   "Cancel"
      Height          =   255
      Left            =   2160
      TabIndex        =   3
      Top             =   1200
      Width           =   1335
   End
   Begin VB.CommandButton btnOK 
      Caption         =   "OK"
      Height          =   255
      Left            =   480
      TabIndex        =   2
      Top             =   1200
      Width           =   1335
   End
   Begin VB.TextBox txtUserID 
      Height          =   270
      Left            =   1440
      MaxLength       =   10
      TabIndex        =   1
      Text            =   "Text1"
      Top             =   480
      Width           =   1575
   End
   Begin VB.Label Label1 
      Caption         =   "User ID"
      Height          =   255
      Left            =   600
      TabIndex        =   0
      Top             =   480
      Width           =   735
   End
End
Attribute VB_Name = "UFE30_User_Info"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Option Base 0


Public DialogResult As Boolean


Public Sub SetAdd()
    DialogResult = False
    txtUserID = ""
    
    txtUserID.Enabled = True
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

