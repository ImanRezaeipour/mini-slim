Imports System.Windows.Forms

Public Class UserInfoForm
    Public Sub New(ByVal Update As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tbxUserID.Text = "UserID"
        tbxFingerIndex.Text = "0"
        tbxMemo.Text = "Memo"

        If (Update) Then
            tbxUserID.ReadOnly = True
            tbxFingerIndex.ReadOnly = True
        End If
    End Sub
End Class
