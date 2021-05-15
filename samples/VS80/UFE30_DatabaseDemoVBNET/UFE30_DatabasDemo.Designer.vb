<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFE30_DatabaseDemo
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
        Me.btnClear = New System.Windows.Forms.Button
        Me.tbxMessage = New System.Windows.Forms.TextBox
        Me.lvDatabaseList = New System.Windows.Forms.ListView
        Me.btnDeleteAll = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSelectionVerify = New System.Windows.Forms.Button
        Me.btnSelectionUpdateTemplate = New System.Windows.Forms.Button
        Me.btnSelectionUpdateUserInfo = New System.Windows.Forms.Button
        Me.btnSelectionDelete = New System.Windows.Forms.Button
        Me.btnIdentify = New System.Windows.Forms.Button
        Me.btnEnroll = New System.Windows.Forms.Button
        Me.btnUninit = New System.Windows.Forms.Button
        Me.btnInit = New System.Windows.Forms.Button
        Me.pbImageFrame = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbScanTemplateType = New System.Windows.Forms.ComboBox
        Me.groupBox1.SuspendLayout()
        CType(Me.pbImageFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = ""
        Me.btnClear.Location = New System.Drawing.Point(719, 320)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(48, 84)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'tbxMessage
        '
        Me.tbxMessage.Location = New System.Drawing.Point(102, 320)
        Me.tbxMessage.Multiline = True
        Me.tbxMessage.Name = "tbxMessage"
        Me.tbxMessage.Size = New System.Drawing.Size(609, 84)
        Me.tbxMessage.TabIndex = 16
        '
        'lvDatabaseList
        '
        Me.lvDatabaseList.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvDatabaseList.FullRowSelect = True
        Me.lvDatabaseList.GridLines = True
        Me.lvDatabaseList.Location = New System.Drawing.Point(347, 12)
        Me.lvDatabaseList.MultiSelect = False
        Me.lvDatabaseList.Name = "lvDatabaseList"
        Me.lvDatabaseList.Size = New System.Drawing.Size(420, 296)
        Me.lvDatabaseList.TabIndex = 15
        Me.lvDatabaseList.UseCompatibleStateImageBehavior = False
        Me.lvDatabaseList.View = System.Windows.Forms.View.Details
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.AccessibleDescription = ""
        Me.btnDeleteAll.Location = New System.Drawing.Point(12, 152)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(84, 24)
        Me.btnDeleteAll.TabIndex = 14
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnSelectionVerify)
        Me.groupBox1.Controls.Add(Me.btnSelectionUpdateTemplate)
        Me.groupBox1.Controls.Add(Me.btnSelectionUpdateUserInfo)
        Me.groupBox1.Controls.Add(Me.btnSelectionDelete)
        Me.groupBox1.Location = New System.Drawing.Point(12, 208)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(84, 168)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Selection"
        '
        'btnSelectionVerify
        '
        Me.btnSelectionVerify.AccessibleDescription = ""
        Me.btnSelectionVerify.Location = New System.Drawing.Point(8, 136)
        Me.btnSelectionVerify.Name = "btnSelectionVerify"
        Me.btnSelectionVerify.Size = New System.Drawing.Size(68, 24)
        Me.btnSelectionVerify.TabIndex = 8
        Me.btnSelectionVerify.Text = "Verify"
        Me.btnSelectionVerify.UseVisualStyleBackColor = True
        '
        'btnSelectionUpdateTemplate
        '
        Me.btnSelectionUpdateTemplate.AccessibleDescription = ""
        Me.btnSelectionUpdateTemplate.Location = New System.Drawing.Point(8, 92)
        Me.btnSelectionUpdateTemplate.Name = "btnSelectionUpdateTemplate"
        Me.btnSelectionUpdateTemplate.Size = New System.Drawing.Size(68, 40)
        Me.btnSelectionUpdateTemplate.TabIndex = 7
        Me.btnSelectionUpdateTemplate.Text = "Update Template"
        Me.btnSelectionUpdateTemplate.UseVisualStyleBackColor = True
        '
        'btnSelectionUpdateUserInfo
        '
        Me.btnSelectionUpdateUserInfo.AccessibleDescription = ""
        Me.btnSelectionUpdateUserInfo.Location = New System.Drawing.Point(8, 48)
        Me.btnSelectionUpdateUserInfo.Name = "btnSelectionUpdateUserInfo"
        Me.btnSelectionUpdateUserInfo.Size = New System.Drawing.Size(68, 40)
        Me.btnSelectionUpdateUserInfo.TabIndex = 6
        Me.btnSelectionUpdateUserInfo.Text = "Update User Info"
        Me.btnSelectionUpdateUserInfo.UseVisualStyleBackColor = True
        '
        'btnSelectionDelete
        '
        Me.btnSelectionDelete.AccessibleDescription = ""
        Me.btnSelectionDelete.Location = New System.Drawing.Point(8, 20)
        Me.btnSelectionDelete.Name = "btnSelectionDelete"
        Me.btnSelectionDelete.Size = New System.Drawing.Size(68, 24)
        Me.btnSelectionDelete.TabIndex = 5
        Me.btnSelectionDelete.Text = "Delete"
        Me.btnSelectionDelete.UseVisualStyleBackColor = True
        '
        'btnIdentify
        '
        Me.btnIdentify.AccessibleDescription = ""
        Me.btnIdentify.Location = New System.Drawing.Point(12, 112)
        Me.btnIdentify.Name = "btnIdentify"
        Me.btnIdentify.Size = New System.Drawing.Size(84, 24)
        Me.btnIdentify.TabIndex = 12
        Me.btnIdentify.Text = "Identify"
        Me.btnIdentify.UseVisualStyleBackColor = True
        '
        'btnEnroll
        '
        Me.btnEnroll.AccessibleDescription = ""
        Me.btnEnroll.Location = New System.Drawing.Point(12, 84)
        Me.btnEnroll.Name = "btnEnroll"
        Me.btnEnroll.Size = New System.Drawing.Size(84, 24)
        Me.btnEnroll.TabIndex = 11
        Me.btnEnroll.Text = "Enroll"
        Me.btnEnroll.UseVisualStyleBackColor = True
        '
        'btnUninit
        '
        Me.btnUninit.AccessibleDescription = ""
        Me.btnUninit.Location = New System.Drawing.Point(12, 40)
        Me.btnUninit.Name = "btnUninit"
        Me.btnUninit.Size = New System.Drawing.Size(84, 24)
        Me.btnUninit.TabIndex = 10
        Me.btnUninit.Text = "Uninit"
        Me.btnUninit.UseVisualStyleBackColor = True
        '
        'btnInit
        '
        Me.btnInit.AccessibleDescription = ""
        Me.btnInit.Location = New System.Drawing.Point(12, 12)
        Me.btnInit.Name = "btnInit"
        Me.btnInit.Size = New System.Drawing.Size(84, 24)
        Me.btnInit.TabIndex = 9
        Me.btnInit.Text = "Init"
        Me.btnInit.UseVisualStyleBackColor = True
        '
        'pbImageFrame
        '
        Me.pbImageFrame.Location = New System.Drawing.Point(102, 12)
        Me.pbImageFrame.Name = "pbImageFrame"
        Me.pbImageFrame.Size = New System.Drawing.Size(228, 252)
        Me.pbImageFrame.TabIndex = 18
        Me.pbImageFrame.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 12)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Template Type"
        '
        'cbScanTemplateType
        '
        Me.cbScanTemplateType.FormattingEnabled = True
        Me.cbScanTemplateType.Items.AddRange(New Object() {"suprema", "iso19479_2", "ansi378"})
        Me.cbScanTemplateType.Location = New System.Drawing.Point(207, 277)
        Me.cbScanTemplateType.Name = "cbScanTemplateType"
        Me.cbScanTemplateType.Size = New System.Drawing.Size(122, 20)
        Me.cbScanTemplateType.TabIndex = 20
        '
        'UFE30_DatabaseDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(779, 417)
        Me.Controls.Add(Me.cbScanTemplateType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbImageFrame)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.tbxMessage)
        Me.Controls.Add(Me.lvDatabaseList)
        Me.Controls.Add(Me.btnDeleteAll)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnIdentify)
        Me.Controls.Add(Me.btnEnroll)
        Me.Controls.Add(Me.btnUninit)
        Me.Controls.Add(Me.btnInit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "UFE30_DatabaseDemo"
        Me.Text = "Suprema PC SDK Database Demo (VB .NET)"
        Me.groupBox1.ResumeLayout(False)
        CType(Me.pbImageFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClear As System.Windows.Forms.Button
    Private WithEvents tbxMessage As System.Windows.Forms.TextBox
    Private WithEvents lvDatabaseList As System.Windows.Forms.ListView
    Private WithEvents btnDeleteAll As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnSelectionVerify As System.Windows.Forms.Button
    Private WithEvents btnSelectionUpdateTemplate As System.Windows.Forms.Button
    Private WithEvents btnSelectionUpdateUserInfo As System.Windows.Forms.Button
    Private WithEvents btnSelectionDelete As System.Windows.Forms.Button
    Private WithEvents btnIdentify As System.Windows.Forms.Button
    Private WithEvents btnEnroll As System.Windows.Forms.Button
    Private WithEvents btnUninit As System.Windows.Forms.Button
    Private WithEvents btnInit As System.Windows.Forms.Button
    Friend WithEvents pbImageFrame As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbScanTemplateType As System.Windows.Forms.ComboBox

End Class
