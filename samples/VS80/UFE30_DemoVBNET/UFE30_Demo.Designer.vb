<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFE30_Demo
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
        Dim btnUpdate As System.Windows.Forms.Button
        Dim btnSaveImage As System.Windows.Forms.Button
        Dim btnSaveTemplate As System.Windows.Forms.Button
        Dim btnIdentify As System.Windows.Forms.Button
        Dim btnVerify As System.Windows.Forms.Button
        Dim btnCaptureSingle As System.Windows.Forms.Button
        Dim btnAbortCapturing As System.Windows.Forms.Button
        Dim btnEnroll As System.Windows.Forms.Button
        Dim btnExtract As System.Windows.Forms.Button
        Dim btnStartCapturing As System.Windows.Forms.Button
        Dim btnClear As System.Windows.Forms.Button
        Dim btnUninit As System.Windows.Forms.Button
        Dim btnInit As System.Windows.Forms.Button
        Dim btnDeleteTemplate As System.Windows.Forms.Button
        Dim btnUpdateTemplate As System.Windows.Forms.Button
        Dim btnDeleteAll As System.Windows.Forms.Button
        Dim btnAutoCapture As System.Windows.Forms.Button
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.cbFastMode = New System.Windows.Forms.CheckBox
        Me.cbSecurityLevel = New System.Windows.Forms.ComboBox
        Me.label6 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cbDetectCore = New System.Windows.Forms.CheckBox
        Me.nudSensitivity = New System.Windows.Forms.NumericUpDown
        Me.nudBrightness = New System.Windows.Forms.NumericUpDown
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.cbTimeout = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.cbScanTemplateType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbScannerList = New System.Windows.Forms.ListBox
        Me.label1 = New System.Windows.Forms.Label
        Me.pbImageFrame = New System.Windows.Forms.PictureBox
        Me.tbxMessage = New System.Windows.Forms.TextBox
        Me.lvFingerDataList = New System.Windows.Forms.ListView
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.cbQuality = New System.Windows.Forms.ComboBox
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.rbtnOneTemplateNormal2 = New System.Windows.Forms.RadioButton
        Me.rbtnOneTemplateNormal = New System.Windows.Forms.RadioButton
        Me.rbtnTwoTemplateNormal = New System.Windows.Forms.RadioButton
        Me.rbtnOneTemplateAdvanced = New System.Windows.Forms.RadioButton
        btnUpdate = New System.Windows.Forms.Button
        btnSaveImage = New System.Windows.Forms.Button
        btnSaveTemplate = New System.Windows.Forms.Button
        btnIdentify = New System.Windows.Forms.Button
        btnVerify = New System.Windows.Forms.Button
        btnCaptureSingle = New System.Windows.Forms.Button
        btnAbortCapturing = New System.Windows.Forms.Button
        btnEnroll = New System.Windows.Forms.Button
        btnExtract = New System.Windows.Forms.Button
        btnStartCapturing = New System.Windows.Forms.Button
        btnClear = New System.Windows.Forms.Button
        btnUninit = New System.Windows.Forms.Button
        btnInit = New System.Windows.Forms.Button
        btnDeleteTemplate = New System.Windows.Forms.Button
        btnUpdateTemplate = New System.Windows.Forms.Button
        btnDeleteAll = New System.Windows.Forms.Button
        btnAutoCapture = New System.Windows.Forms.Button
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.nudSensitivity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImageFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox5.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        btnUpdate.Location = New System.Drawing.Point(77, 12)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New System.Drawing.Size(60, 24)
        btnUpdate.TabIndex = 31
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        AddHandler btnUpdate.Click, AddressOf Me.btnUpdate_Click
        '
        'btnSaveImage
        '
        btnSaveImage.Location = New System.Drawing.Point(79, 108)
        btnSaveImage.Name = "btnSaveImage"
        btnSaveImage.Size = New System.Drawing.Size(103, 23)
        btnSaveImage.TabIndex = 30
        btnSaveImage.Text = "Save Image"
        btnSaveImage.UseVisualStyleBackColor = True
        AddHandler btnSaveImage.Click, AddressOf Me.btnSaveImage_Click
        '
        'btnSaveTemplate
        '
        btnSaveTemplate.Location = New System.Drawing.Point(142, 193)
        btnSaveTemplate.Name = "btnSaveTemplate"
        btnSaveTemplate.Size = New System.Drawing.Size(113, 20)
        btnSaveTemplate.TabIndex = 29
        btnSaveTemplate.Text = "Save Template"
        btnSaveTemplate.UseVisualStyleBackColor = True
        AddHandler btnSaveTemplate.Click, AddressOf Me.btnSaveTemplate_Click
        '
        'btnIdentify
        '
        btnIdentify.Location = New System.Drawing.Point(126, 106)
        btnIdentify.Name = "btnIdentify"
        btnIdentify.Size = New System.Drawing.Size(96, 20)
        btnIdentify.TabIndex = 15
        btnIdentify.Text = "Identify"
        btnIdentify.UseVisualStyleBackColor = True
        AddHandler btnIdentify.Click, AddressOf Me.btnIdentify_Click
        '
        'btnVerify
        '
        btnVerify.Location = New System.Drawing.Point(126, 78)
        btnVerify.Name = "btnVerify"
        btnVerify.Size = New System.Drawing.Size(96, 20)
        btnVerify.TabIndex = 13
        btnVerify.Text = "Verify"
        btnVerify.UseVisualStyleBackColor = True
        AddHandler btnVerify.Click, AddressOf Me.btnVerify_Click
        '
        'btnCaptureSingle
        '
        btnCaptureSingle.Location = New System.Drawing.Point(8, 52)
        btnCaptureSingle.Name = "btnCaptureSingle"
        btnCaptureSingle.Size = New System.Drawing.Size(96, 20)
        btnCaptureSingle.TabIndex = 14
        btnCaptureSingle.Text = "Capture Single"
        btnCaptureSingle.UseVisualStyleBackColor = True
        AddHandler btnCaptureSingle.Click, AddressOf Me.btnCaptureSingle_Click
        '
        'btnAbortCapturing
        '
        btnAbortCapturing.Location = New System.Drawing.Point(108, 24)
        btnAbortCapturing.Name = "btnAbortCapturing"
        btnAbortCapturing.Size = New System.Drawing.Size(74, 20)
        btnAbortCapturing.TabIndex = 13
        btnAbortCapturing.Text = "Abort"
        btnAbortCapturing.UseVisualStyleBackColor = True
        AddHandler btnAbortCapturing.Click, AddressOf Me.btnAbortCapturing_Click
        '
        'btnEnroll
        '
        btnEnroll.Location = New System.Drawing.Point(23, 139)
        btnEnroll.Name = "btnEnroll"
        btnEnroll.Size = New System.Drawing.Size(113, 20)
        btnEnroll.TabIndex = 12
        btnEnroll.Text = "Enroll"
        btnEnroll.UseVisualStyleBackColor = True
        AddHandler btnEnroll.Click, AddressOf Me.btnEnroll_Click
        '
        'btnExtract
        '
        btnExtract.Location = New System.Drawing.Point(108, 52)
        btnExtract.Name = "btnExtract"
        btnExtract.Size = New System.Drawing.Size(72, 20)
        btnExtract.TabIndex = 11
        btnExtract.Text = "Extract"
        btnExtract.UseVisualStyleBackColor = True
        AddHandler btnExtract.Click, AddressOf Me.btnExtract_Click
        '
        'btnStartCapturing
        '
        btnStartCapturing.Location = New System.Drawing.Point(8, 24)
        btnStartCapturing.Name = "btnStartCapturing"
        btnStartCapturing.Size = New System.Drawing.Size(96, 20)
        btnStartCapturing.TabIndex = 10
        btnStartCapturing.Text = "Start Capturing"
        btnStartCapturing.UseVisualStyleBackColor = True
        AddHandler btnStartCapturing.Click, AddressOf Me.btnStartCapturing_Click
        '
        'btnClear
        '
        btnClear.Location = New System.Drawing.Point(393, 421)
        btnClear.Name = "btnClear"
        btnClear.Size = New System.Drawing.Size(44, 68)
        btnClear.TabIndex = 22
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        AddHandler btnClear.Click, AddressOf Me.btnClear_Click
        '
        'btnUninit
        '
        btnUninit.Location = New System.Drawing.Point(141, 12)
        btnUninit.Name = "btnUninit"
        btnUninit.Size = New System.Drawing.Size(60, 24)
        btnUninit.TabIndex = 20
        btnUninit.Text = "Uninit"
        btnUninit.UseVisualStyleBackColor = True
        AddHandler btnUninit.Click, AddressOf Me.btnUninit_Click
        '
        'btnInit
        '
        btnInit.Location = New System.Drawing.Point(13, 12)
        btnInit.Name = "btnInit"
        btnInit.Size = New System.Drawing.Size(60, 24)
        btnInit.TabIndex = 19
        btnInit.Text = "Init"
        btnInit.UseVisualStyleBackColor = True
        AddHandler btnInit.Click, AddressOf Me.btnInit_Click
        '
        'btnDeleteTemplate
        '
        btnDeleteTemplate.Location = New System.Drawing.Point(142, 167)
        btnDeleteTemplate.Name = "btnDeleteTemplate"
        btnDeleteTemplate.Size = New System.Drawing.Size(113, 20)
        btnDeleteTemplate.TabIndex = 22
        btnDeleteTemplate.Text = "Delete Template"
        btnDeleteTemplate.UseVisualStyleBackColor = True
        AddHandler btnDeleteTemplate.Click, AddressOf Me.btnDeleteTemplate_Click
        '
        'btnUpdateTemplate
        '
        btnUpdateTemplate.Location = New System.Drawing.Point(23, 167)
        btnUpdateTemplate.Name = "btnUpdateTemplate"
        btnUpdateTemplate.Size = New System.Drawing.Size(113, 20)
        btnUpdateTemplate.TabIndex = 21
        btnUpdateTemplate.Text = "Update Template"
        btnUpdateTemplate.UseVisualStyleBackColor = True
        AddHandler btnUpdateTemplate.Click, AddressOf Me.btnUpdateTemplate_Click
        '
        'btnDeleteAll
        '
        btnDeleteAll.Location = New System.Drawing.Point(142, 139)
        btnDeleteAll.Name = "btnDeleteAll"
        btnDeleteAll.Size = New System.Drawing.Size(113, 20)
        btnDeleteAll.TabIndex = 20
        btnDeleteAll.Text = "Delete All"
        btnDeleteAll.UseVisualStyleBackColor = True
        AddHandler btnDeleteAll.Click, AddressOf Me.btnDeleteAll_Click
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(btnIdentify)
        Me.groupBox3.Controls.Add(btnVerify)
        Me.groupBox3.Controls.Add(Me.cbFastMode)
        Me.groupBox3.Controls.Add(Me.cbSecurityLevel)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Location = New System.Drawing.Point(209, 272)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(228, 138)
        Me.groupBox3.TabIndex = 28
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Match"
        '
        'cbFastMode
        '
        Me.cbFastMode.AutoSize = True
        Me.cbFastMode.Location = New System.Drawing.Point(12, 67)
        Me.cbFastMode.Name = "cbFastMode"
        Me.cbFastMode.Size = New System.Drawing.Size(84, 16)
        Me.cbFastMode.TabIndex = 7
        Me.cbFastMode.Text = "Fast Mode"
        Me.cbFastMode.UseVisualStyleBackColor = True
        '
        'cbSecurityLevel
        '
        Me.cbSecurityLevel.FormattingEnabled = True
        Me.cbSecurityLevel.Items.AddRange(New Object() {"1 (FAR1/100)", "2 (1/1,000)", "3 (1/10,000)", "4*(1/100,000)", "5 (1/1,000,000)", "6 (1/10,000,000)", "7 (1/100,000,000)"})
        Me.cbSecurityLevel.Location = New System.Drawing.Point(96, 20)
        Me.cbSecurityLevel.Name = "cbSecurityLevel"
        Me.cbSecurityLevel.Size = New System.Drawing.Size(120, 20)
        Me.cbSecurityLevel.TabIndex = 13
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(8, 24)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(85, 12)
        Me.label6.TabIndex = 13
        Me.label6.Text = "Security Level"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(btnAutoCapture)
        Me.groupBox2.Controls.Add(btnCaptureSingle)
        Me.groupBox2.Controls.Add(btnAbortCapturing)
        Me.groupBox2.Controls.Add(btnExtract)
        Me.groupBox2.Controls.Add(btnSaveImage)
        Me.groupBox2.Controls.Add(btnStartCapturing)
        Me.groupBox2.Location = New System.Drawing.Point(12, 272)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(188, 138)
        Me.groupBox2.TabIndex = 27
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Use Scanner"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cbDetectCore)
        Me.groupBox1.Controls.Add(Me.nudSensitivity)
        Me.groupBox1.Controls.Add(Me.nudBrightness)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.cbTimeout)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Location = New System.Drawing.Point(13, 148)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(188, 116)
        Me.groupBox1.TabIndex = 26
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Scanner Parameters"
        '
        'cbDetectCore
        '
        Me.cbDetectCore.AutoSize = True
        Me.cbDetectCore.Location = New System.Drawing.Point(8, 90)
        Me.cbDetectCore.Name = "cbDetectCore"
        Me.cbDetectCore.Size = New System.Drawing.Size(90, 16)
        Me.cbDetectCore.TabIndex = 6
        Me.cbDetectCore.Text = "Detect Core"
        Me.cbDetectCore.UseVisualStyleBackColor = True
        '
        'nudSensitivity
        '
        Me.nudSensitivity.Location = New System.Drawing.Point(92, 62)
        Me.nudSensitivity.Name = "nudSensitivity"
        Me.nudSensitivity.Size = New System.Drawing.Size(48, 21)
        Me.nudSensitivity.TabIndex = 5
        '
        'nudBrightness
        '
        Me.nudBrightness.Location = New System.Drawing.Point(92, 38)
        Me.nudBrightness.Name = "nudBrightness"
        Me.nudBrightness.Size = New System.Drawing.Size(48, 21)
        Me.nudBrightness.TabIndex = 4
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(8, 66)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(62, 12)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Sensitivity"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(8, 42)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(65, 12)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Brightness"
        '
        'cbTimeout
        '
        Me.cbTimeout.FormattingEnabled = True
        Me.cbTimeout.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5*"})
        Me.cbTimeout.Location = New System.Drawing.Point(76, 15)
        Me.cbTimeout.Name = "cbTimeout"
        Me.cbTimeout.Size = New System.Drawing.Size(48, 20)
        Me.cbTimeout.TabIndex = 1
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(8, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(51, 12)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Timeout"
        '
        'cbScanTemplateType
        '
        Me.cbScanTemplateType.FormattingEnabled = True
        Me.cbScanTemplateType.Items.AddRange(New Object() {"suprema", "iso19794_2", "ansi378"})
        Me.cbScanTemplateType.Location = New System.Drawing.Point(117, 111)
        Me.cbScanTemplateType.Name = "cbScanTemplateType"
        Me.cbScanTemplateType.Size = New System.Drawing.Size(90, 20)
        Me.cbScanTemplateType.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 12)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "template type"
        '
        'lbScannerList
        '
        Me.lbScannerList.FormattingEnabled = True
        Me.lbScannerList.ItemHeight = 12
        Me.lbScannerList.Location = New System.Drawing.Point(13, 64)
        Me.lbScannerList.Name = "lbScannerList"
        Me.lbScannerList.Size = New System.Drawing.Size(188, 76)
        Me.lbScannerList.TabIndex = 25
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 44)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(76, 12)
        Me.label1.TabIndex = 24
        Me.label1.Text = "Scanner List"
        '
        'pbImageFrame
        '
        Me.pbImageFrame.BackColor = System.Drawing.SystemColors.Control
        Me.pbImageFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbImageFrame.Location = New System.Drawing.Point(209, 12)
        Me.pbImageFrame.Name = "pbImageFrame"
        Me.pbImageFrame.Size = New System.Drawing.Size(228, 252)
        Me.pbImageFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImageFrame.TabIndex = 23
        Me.pbImageFrame.TabStop = False
        '
        'tbxMessage
        '
        Me.tbxMessage.Location = New System.Drawing.Point(13, 421)
        Me.tbxMessage.Multiline = True
        Me.tbxMessage.Name = "tbxMessage"
        Me.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxMessage.Size = New System.Drawing.Size(376, 68)
        Me.tbxMessage.TabIndex = 21
        Me.tbxMessage.WordWrap = False
        '
        'lvFingerDataList
        '
        Me.lvFingerDataList.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvFingerDataList.FullRowSelect = True
        Me.lvFingerDataList.GridLines = True
        Me.lvFingerDataList.Location = New System.Drawing.Point(452, 12)
        Me.lvFingerDataList.MultiSelect = False
        Me.lvFingerDataList.Name = "lvFingerDataList"
        Me.lvFingerDataList.Size = New System.Drawing.Size(282, 252)
        Me.lvFingerDataList.TabIndex = 33
        Me.lvFingerDataList.UseCompatibleStateImageBehavior = False
        Me.lvFingerDataList.View = System.Windows.Forms.View.Details
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.label5)
        Me.groupBox5.Controls.Add(Me.cbQuality)
        Me.groupBox5.Controls.Add(Me.groupBox4)
        Me.groupBox5.Controls.Add(btnDeleteTemplate)
        Me.groupBox5.Controls.Add(btnEnroll)
        Me.groupBox5.Controls.Add(btnSaveTemplate)
        Me.groupBox5.Controls.Add(btnUpdateTemplate)
        Me.groupBox5.Controls.Add(btnDeleteAll)
        Me.groupBox5.Controls.Add(Me.cbScanTemplateType)
        Me.groupBox5.Controls.Add(Me.Label8)
        Me.groupBox5.Location = New System.Drawing.Point(452, 272)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(282, 217)
        Me.groupBox5.TabIndex = 34
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Template"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(211, 23)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(44, 12)
        Me.label5.TabIndex = 31
        Me.label5.Text = "Quality"
        '
        'cbQuality
        '
        Me.cbQuality.FormattingEnabled = True
        Me.cbQuality.Items.AddRange(New Object() {"90", "80", "70", "60", "50", "40*", "30", "20", "10", "None"})
        Me.cbQuality.Location = New System.Drawing.Point(213, 41)
        Me.cbQuality.Name = "cbQuality"
        Me.cbQuality.Size = New System.Drawing.Size(59, 20)
        Me.cbQuality.TabIndex = 30
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.rbtnOneTemplateNormal2)
        Me.groupBox4.Controls.Add(Me.rbtnOneTemplateNormal)
        Me.groupBox4.Controls.Add(Me.rbtnTwoTemplateNormal)
        Me.groupBox4.Controls.Add(Me.rbtnOneTemplateAdvanced)
        Me.groupBox4.Location = New System.Drawing.Point(14, 14)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(184, 85)
        Me.groupBox4.TabIndex = 26
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Enroll Mode"
        '
        'rbtnOneTemplateNormal2
        '
        Me.rbtnOneTemplateNormal2.AutoSize = True
        Me.rbtnOneTemplateNormal2.Location = New System.Drawing.Point(18, 30)
        Me.rbtnOneTemplateNormal2.Name = "rbtnOneTemplateNormal2"
        Me.rbtnOneTemplateNormal2.Size = New System.Drawing.Size(88, 16)
        Me.rbtnOneTemplateNormal2.TabIndex = 26
        Me.rbtnOneTemplateNormal2.TabStop = True
        Me.rbtnOneTemplateNormal2.Text = "2-Template"
        Me.rbtnOneTemplateNormal2.UseVisualStyleBackColor = True
        '
        'rbtnOneTemplateNormal
        '
        Me.rbtnOneTemplateNormal.AutoSize = True
        Me.rbtnOneTemplateNormal.Location = New System.Drawing.Point(18, 14)
        Me.rbtnOneTemplateNormal.Name = "rbtnOneTemplateNormal"
        Me.rbtnOneTemplateNormal.Size = New System.Drawing.Size(88, 16)
        Me.rbtnOneTemplateNormal.TabIndex = 25
        Me.rbtnOneTemplateNormal.TabStop = True
        Me.rbtnOneTemplateNormal.Text = "1-Template"
        Me.rbtnOneTemplateNormal.UseVisualStyleBackColor = True
        '
        'rbtnTwoTemplateNormal
        '
        Me.rbtnTwoTemplateNormal.AutoSize = True
        Me.rbtnTwoTemplateNormal.Location = New System.Drawing.Point(18, 64)
        Me.rbtnTwoTemplateNormal.Name = "rbtnTwoTemplateNormal"
        Me.rbtnTwoTemplateNormal.Size = New System.Drawing.Size(148, 16)
        Me.rbtnTwoTemplateNormal.TabIndex = 24
        Me.rbtnTwoTemplateNormal.TabStop = True
        Me.rbtnTwoTemplateNormal.Text = "2-Template Advanced"
        Me.rbtnTwoTemplateNormal.UseVisualStyleBackColor = True
        '
        'rbtnOneTemplateAdvanced
        '
        Me.rbtnOneTemplateAdvanced.AutoSize = True
        Me.rbtnOneTemplateAdvanced.Location = New System.Drawing.Point(18, 47)
        Me.rbtnOneTemplateAdvanced.Name = "rbtnOneTemplateAdvanced"
        Me.rbtnOneTemplateAdvanced.Size = New System.Drawing.Size(148, 16)
        Me.rbtnOneTemplateAdvanced.TabIndex = 23
        Me.rbtnOneTemplateAdvanced.TabStop = True
        Me.rbtnOneTemplateAdvanced.Text = "1-Template Advanced"
        Me.rbtnOneTemplateAdvanced.UseVisualStyleBackColor = True
        '
        'btnAutoCapture
        '
        btnAutoCapture.Location = New System.Drawing.Point(9, 78)
        btnAutoCapture.Name = "btnAutoCapture"
        btnAutoCapture.Size = New System.Drawing.Size(96, 20)
        btnAutoCapture.TabIndex = 31
        btnAutoCapture.Text = "Auto Capture"
        btnAutoCapture.UseVisualStyleBackColor = True
        AddHandler btnAutoCapture.Click, AddressOf Me.btnAutoCapture_Click
        '
        'UFE30_Demo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(746, 503)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.lvFingerDataList)
        Me.Controls.Add(btnUpdate)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.lbScannerList)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pbImageFrame)
        Me.Controls.Add(btnClear)
        Me.Controls.Add(Me.tbxMessage)
        Me.Controls.Add(btnUninit)
        Me.Controls.Add(btnInit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "UFE30_Demo"
        Me.Text = "Suprema PC SDK Demo (VB.NET)"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.nudSensitivity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImageFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents cbFastMode As System.Windows.Forms.CheckBox
    Private WithEvents cbSecurityLevel As System.Windows.Forms.ComboBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cbDetectCore As System.Windows.Forms.CheckBox
    Private WithEvents nudSensitivity As System.Windows.Forms.NumericUpDown
    Private WithEvents nudBrightness As System.Windows.Forms.NumericUpDown
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cbTimeout As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents lbScannerList As System.Windows.Forms.ListBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents pbImageFrame As System.Windows.Forms.PictureBox
    Private WithEvents tbxMessage As System.Windows.Forms.TextBox
    Private WithEvents cbScanTemplateType As System.Windows.Forms.ComboBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents lvFingerDataList As System.Windows.Forms.ListView
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents rbtnOneTemplateNormal As System.Windows.Forms.RadioButton
    Private WithEvents rbtnTwoTemplateNormal As System.Windows.Forms.RadioButton
    Private WithEvents rbtnOneTemplateAdvanced As System.Windows.Forms.RadioButton
    Private WithEvents rbtnOneTemplateNormal2 As System.Windows.Forms.RadioButton
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents cbQuality As System.Windows.Forms.ComboBox

End Class
