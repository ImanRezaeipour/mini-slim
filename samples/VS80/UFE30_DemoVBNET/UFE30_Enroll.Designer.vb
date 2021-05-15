<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFE30_Enroll
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbxUserID = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.tbxMessage = New System.Windows.Forms.TextBox
        Me.pbImageFrame = New System.Windows.Forms.PictureBox
        Me.textBox1 = New System.Windows.Forms.TextBox
        CType(Me.pbImageFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbxUserID
        '
        Me.tbxUserID.Location = New System.Drawing.Point(267, 92)
        Me.tbxUserID.Name = "tbxUserID"
        Me.tbxUserID.ReadOnly = True
        Me.tbxUserID.Size = New System.Drawing.Size(100, 21)
        Me.tbxUserID.TabIndex = 16
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(219, 95)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(42, 12)
        Me.label1.TabIndex = 15
        Me.label1.Text = "UserID"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(318, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(74, 18)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(219, 207)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(76, 18)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'tbxMessage
        '
        Me.tbxMessage.Location = New System.Drawing.Point(12, 235)
        Me.tbxMessage.Multiline = True
        Me.tbxMessage.Name = "tbxMessage"
        Me.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxMessage.Size = New System.Drawing.Size(390, 68)
        Me.tbxMessage.TabIndex = 12
        Me.tbxMessage.WordWrap = False
        '
        'pbImageFrame
        '
        Me.pbImageFrame.BackColor = System.Drawing.SystemColors.Control
        Me.pbImageFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbImageFrame.Location = New System.Drawing.Point(12, 12)
        Me.pbImageFrame.Name = "pbImageFrame"
        Me.pbImageFrame.Size = New System.Drawing.Size(201, 213)
        Me.pbImageFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImageFrame.TabIndex = 11
        Me.pbImageFrame.TabStop = False
        '
        'textBox1
        '
        Me.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBox1.Location = New System.Drawing.Point(219, 12)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(185, 80)
        Me.textBox1.TabIndex = 17
        Me.textBox1.Text = "Template extraction process " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is running." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Check blew message box and Input you" & _
            "r fingerprint 4 times"
        '
        'UFE30_Enroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 315)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.tbxUserID)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tbxMessage)
        Me.Controls.Add(Me.pbImageFrame)
        Me.Name = "UFE30_Enroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "UFE30_Enroll"
        CType(Me.pbImageFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents tbxMessage As System.Windows.Forms.TextBox
    Private WithEvents pbImageFrame As System.Windows.Forms.PictureBox
    Public WithEvents tbxUserID As System.Windows.Forms.TextBox
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
End Class
