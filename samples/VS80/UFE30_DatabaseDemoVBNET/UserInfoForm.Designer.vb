<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInfoForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button
        Me.tbxMemo = New System.Windows.Forms.TextBox
        Me.tbxFingerIndex = New System.Windows.Forms.TextBox
        Me.tbxUserID = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(12, 180)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(108, 20)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'tbxMemo
        '
        Me.tbxMemo.Location = New System.Drawing.Point(96, 68)
        Me.tbxMemo.MaxLength = 100
        Me.tbxMemo.Multiline = True
        Me.tbxMemo.Name = "tbxMemo"
        Me.tbxMemo.Size = New System.Drawing.Size(144, 100)
        Me.tbxMemo.TabIndex = 11
        '
        'tbxFingerIndex
        '
        Me.tbxFingerIndex.Location = New System.Drawing.Point(96, 40)
        Me.tbxFingerIndex.MaxLength = 1
        Me.tbxFingerIndex.Name = "tbxFingerIndex"
        Me.tbxFingerIndex.Size = New System.Drawing.Size(40, 21)
        Me.tbxFingerIndex.TabIndex = 10
        '
        'tbxUserID
        '
        Me.tbxUserID.Location = New System.Drawing.Point(96, 12)
        Me.tbxUserID.MaxLength = 50
        Me.tbxUserID.Name = "tbxUserID"
        Me.tbxUserID.Size = New System.Drawing.Size(96, 21)
        Me.tbxUserID.TabIndex = 9
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(40, 72)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 12)
        Me.label3.TabIndex = 8
        Me.label3.Text = "Memo"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 44)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(71, 12)
        Me.label2.TabIndex = 7
        Me.label2.Text = "FingerIndex"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(40, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(42, 12)
        Me.label1.TabIndex = 6
        Me.label1.Text = "UserID"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(132, 180)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 20)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'UserInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(254, 211)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tbxMemo)
        Me.Controls.Add(Me.tbxFingerIndex)
        Me.Controls.Add(Me.tbxUserID)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserInfoForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents tbxMemo As System.Windows.Forms.TextBox
    Public WithEvents tbxFingerIndex As System.Windows.Forms.TextBox
    Public WithEvents tbxUserID As System.Windows.Forms.TextBox

End Class
