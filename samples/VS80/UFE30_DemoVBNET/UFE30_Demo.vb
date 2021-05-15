Imports System.IO
Imports Suprema

Public Class UFE30_Demo
    '==========================================================================='
    Private m_ScannerManager As UFScannerManager
    Private m_Matcher As UFMatcher = Nothing
    Private m_strError As String
    Private m_template As Byte()()
    Private m_template_size As Integer()

    Private m_template1 As Byte()()
    Private m_template_size1 As Integer()
    Private m_template2 As Byte()()
    Private m_template_size2 As Integer()
    Private m_template_num As Integer
    Private m_UserID As String()
    Private m_quality As Integer
    Private m_nType As Integer
    '
    Private Const MAX_TEMPLATE_SIZE As Integer = 1024
    Private Const MAX_TEMPLATE_NUM As Integer = 50

    Private Const MAX_USERID_SIZE As Integer = 10
    Private Const MAX_TEMPLATE_INPUT_NUM As Integer = 4
    Private Const MAX_TEMPLATE_OUTPUT_NUM As Integer = 2

    Private Const FINGERDATA_COL_SERIAL As Integer = 0
    Private Const FINGERDATA_COL_USERID As Integer = 1
    Private Const FINGERDATA_COL_TEMPLATE1 As Integer = 2
    Private Const FINGERDATA_COL_TEMPLATE2 As Integer = 3

    Private Sub UFE30_Demo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_template1 = New Byte(MAX_TEMPLATE_NUM)() {}
        m_template2 = New Byte(MAX_TEMPLATE_NUM)() {}
        For i As Integer = 0 To MAX_TEMPLATE_NUM - 1
            m_template1(i) = New Byte(MAX_TEMPLATE_SIZE) {}
            m_template2(i) = New Byte(MAX_TEMPLATE_SIZE) {}
        Next
        m_template_size1 = New Integer(MAX_TEMPLATE_NUM) {}
        m_template_size2 = New Integer(MAX_TEMPLATE_NUM) {}
        m_template_num = 0

        m_UserID = New String(MAX_TEMPLATE_NUM) {}

		m_ScannerManager = New UFScannerManager(Me)
        cbQuality.SelectedIndex = 5

        m_quality = 40

        lvFingerDataList.Columns.Add("Serial", 50, HorizontalAlignment.Left)
        lvFingerDataList.Columns.Add("UserID", 60, HorizontalAlignment.Left)
        lvFingerDataList.Columns.Add("Template1", 80, HorizontalAlignment.Left)
        lvFingerDataList.Columns.Add("Template2", 80, HorizontalAlignment.Left)

        rbtnOneTemplateNormal.Checked = True

    End Sub

    Private Sub UFE30_Demo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        btnUninit_Click(sender, e)
    End Sub

    '==========================================================================='
    Private Sub AddRow(ByVal Serial As Integer, ByVal UserID As String, ByVal bTemplate1 As Boolean, ByVal bTemplate2 As Boolean)
        Dim listItem As ListViewItem
        listItem = lvFingerDataList.Items.Add(Convert.ToString(Serial))
        listItem.SubItems.Add(UserID)
        If (bTemplate1) Then
            listItem.SubItems.Add("O")
        Else
            listItem.SubItems.Add("X")
        End If
        If (bTemplate2) Then
            listItem.SubItems.Add("O")
        Else
            listItem.SubItems.Add("X")
        End If
    End Sub

    Private Sub UpdateFingerDataList()
        lvFingerDataList.Items.Clear()
        Dim i As Integer

        For i = 0 To m_template_num - 1
            AddRow(i, m_UserID(i), (m_template_size1(i) <> 0), (m_template_size2(i) <> 0))
        Next
    End Sub

    '==========================================================================='
    Private Sub GetScannerTypeString(ByVal ScannerType As UFS_SCANNER_TYPE, ByRef strScannerType As String)
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
            strScannerType = "Error"
        End If
    End Sub

    Private Function GetCurrentScanner(ByRef Scanner As UFScanner) As Boolean
        Scanner = m_ScannerManager.Scanners(lbScannerList.SelectedIndex)
        If (Not Equals(Scanner, Nothing)) Then
            Return True
        Else
            tbxMessage.AppendText("Selected Scanner is not connected" & vbNewLine)
            Return False
        End If
    End Function

    Private Sub GetCurrentScannerSettings()
        Dim Scanner As UFScanner = Nothing
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        ' Unit of timeout is millisecond
        cbTimeout.SelectedIndex = Scanner.Timeout / 1000

        nudBrightness.Minimum = 0
        nudBrightness.Maximum = 255
        nudBrightness.Value = Scanner.Brightness

        nudSensitivity.Minimum = 0
        nudSensitivity.Maximum = 7
        nudSensitivity.Value = Scanner.Sensitivity

        cbDetectCore.Checked = Scanner.DetectCore
    End Sub

    Private Sub GetMatcherSettings(ByRef Matcher As UFMatcher)
        ' Security level ranges from 1 to 7
        cbSecurityLevel.SelectedIndex = Matcher.SecurityLevel - 1

        cbFastMode.Checked = Matcher.FastMode
    End Sub

    Private Sub DrawCapturedImage(ByRef Scanner As UFScanner)
        Dim g As Graphics = pbImageFrame.CreateGraphics()
        Dim rect As Rectangle = New Rectangle(0, 0, pbImageFrame.Width, pbImageFrame.Height)
        'Dim Resolution As Integer
        Try
            '
            Scanner.DrawCaptureImageBuffer(g, rect, cbDetectCore.Checked)
            '
            'Dim bitmap As Bitmap = Nothing
            'Scanner.GetCaptureImageBuffer(bitmap, Resolution)
            'pbImageFrame.Image = bitmap
        Finally
            g.Dispose()
        End Try
    End Sub
    '==========================================================================='

    '==========================================================================='
    Private Sub lbScannerList_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbScannerList.SelectedValueChanged
        GetCurrentScannerSettings()
    End Sub

    Private Sub cbTimeout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTimeout.SelectedIndexChanged
        Dim Scanner As UFScanner = Nothing
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If
        ' Unit of timeout is millisecond
        Scanner.Timeout = cbTimeout.SelectedIndex * 1000
    End Sub

    Private Sub nudBrightness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudBrightness.ValueChanged
        Dim Scanner As UFScanner = Nothing
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If
        Scanner.Brightness = nudBrightness.Value
    End Sub

    Private Sub nudSensitivity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSensitivity.ValueChanged
        Dim Scanner As UFScanner = Nothing
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If
        Scanner.Sensitivity = nudSensitivity.Value
    End Sub

    Private Sub cbDetectCore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDetectCore.CheckedChanged
        Dim Scanner As UFScanner = Nothing
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If
        Scanner.DetectCore = cbDetectCore.Checked
    End Sub

    Private Sub cbSecurityLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSecurityLevel.SelectedIndexChanged
        If (Not Equals(Nothing, m_Matcher)) Then
            ' Security level ranges from 1 to 7
            m_Matcher.SecurityLevel = cbSecurityLevel.SelectedIndex + 1
        End If
    End Sub
    Private Sub cbScanTemplateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbScanTemplateType.SelectedIndexChanged

        If (m_template_num > 0 And m_nType <> cbScanTemplateType.SelectedIndex) Then
            tbxMessage.AppendText("It is not allowed to mix template format" & vbNewLine & "Please remove all templates if you want to use other template format" & vbNewLine)
            cbScanTemplateType.SelectedIndex = m_nType
            Exit Sub
        End If

        m_nType = cbScanTemplateType.SelectedIndex

        ' template type 2001,2002,2003
        Dim Scanner As UFScanner = Nothing
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If
        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                Scanner.nTemplateType = 2001
            Case 1
                Scanner.nTemplateType = 2002
            Case 2
                Scanner.nTemplateType = 2003

        End Select

    End Sub

    Private Sub cbFastMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFastMode.CheckedChanged
        If (Not Equals(Nothing, m_Matcher)) Then
            m_Matcher.FastMode = cbFastMode.Checked
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tbxMessage.Clear()
    End Sub
    '==========================================================================='

    '==========================================================================='
    Private Sub UpdateScannerList()
        Dim nScannerNumber As Integer = Nothing

        nScannerNumber = m_ScannerManager.Scanners.Count

        lbScannerList.Items.Clear()

        For i As Integer = 0 To nScannerNumber - 1
            Dim Scanner As UFScanner
            Dim ScannerType As UFS_SCANNER_TYPE = Nothing
            Dim strScannerType As String = Nothing
            Dim strID As String = Nothing
            Dim str_tmp As String = Nothing

            Scanner = m_ScannerManager.Scanners(i)

            tbxMessage.AppendText("Scanner " & i & " serial: " & Scanner.Serial & vbNewLine)

            ScannerType = Scanner.ScannerType
            strID = Scanner.ID
            GetScannerTypeString(ScannerType, strScannerType)

            str_tmp = i & ": " & strScannerType & " " & strID
            lbScannerList.Items.Add(str_tmp)
        Next

        If (nScannerNumber > 0) Then
            lbScannerList.SetSelected(0, True)
            GetCurrentScannerSettings()
        End If
    End Sub

    Private Sub ScannerEvent(ByVal sender As Object, ByVal e As UFScannerManagerScannerEventArgs)
        If (e.SensorOn) Then
            UpdateScannerList()
        Else
            UpdateScannerList()
        End If
    End Sub
    '==========================================================================='

    '==========================================================================='
    Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '==========================================================================='
        ' Initilize scanners
        '==========================================================================='
        Dim ufs_res As UFS_STATUS
        Dim nScannerNumber As Integer

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufs_res = m_ScannerManager.Init()
        Windows.Forms.Cursor.Current = Me.Cursor
        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner Init: OK" & vbNewLine)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner Init: " & m_strError & vbNewLine)
            Exit Sub
        End If

        AddHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent

        nScannerNumber = m_ScannerManager.Scanners.Count
        tbxMessage.AppendText("UFScanner GetScannerNumber: " & nScannerNumber & vbNewLine)

        UpdateScannerList()
        If (cbScanTemplateType.SelectedIndex = -1) Then
            cbScanTemplateType.SelectedIndex = 1
            m_nType = 1
        End If

        '==========================================================================='

        '==========================================================================='
        ' Create one matcher
        '==========================================================================='
        m_Matcher = New UFMatcher()

        If (m_Matcher.InitResult = UFM_STATUS.OK) Then
            tbxMessage.AppendText("UFMatcher Init: OK" & vbNewLine)
        Else
            UFMatcher.GetErrorString(m_Matcher.InitResult, m_strError)
            tbxMessage.AppendText("UFMatcher Init: " & m_strError & vbNewLine)
        End If

        GetMatcherSettings(m_Matcher)
        '==========================================================================='

        cbScanTemplateType.SelectedIndex = 0
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ufs_res As UFS_STATUS

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufs_res = m_ScannerManager.Update()
        Windows.Forms.Cursor.Current = Me.Cursor

        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner Update: OK" & vbNewLine)
            UpdateScannerList()
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner Update: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnUninit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '==========================================================================='
        ' Uninit scanners
        '==========================================================================='
        Dim ufs_res As UFS_STATUS

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufs_res = m_ScannerManager.Uninit()
        Windows.Forms.Cursor.Current = Me.Cursor

        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner Uninit: OK" & vbNewLine)
            RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent
            lbScannerList.Items.Clear()
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner Uninit: " & m_strError & vbNewLine)
        End If

        pbImageFrame.Image = Nothing
        '==========================================================================='
    End Sub

    Private Delegate Sub _UpdatePictureBox(ByRef pbox As PictureBox, ByRef image As Bitmap)

    Public Sub UpdatePictureBox(ByRef pbox As PictureBox, ByRef image As Bitmap)
        If (pbox.InvokeRequired) Then
            Dim del As _UpdatePictureBox = New _UpdatePictureBox(AddressOf UpdatePictureBox)
            ' Call the function in the correct thread
            Dim params() As Object = New Object(1) {pbox, image}
            BeginInvoke(del, params)
        Else
            ' We are in the correct thread, so assign the image
            pbox.Image = image
        End If
    End Sub

    Public Function CaptureEvent(ByVal sender As Object, ByVal e As UFScannerCaptureEventArgs) As Integer
        ' We cannot use pbImageFrame.Image directly from the different thread,
        ' so we use UpdatePictureBox() to update PictureBox indirectly
        UpdatePictureBox(pbImageFrame, e.ImageFrame)
        Return 1
    End Function

    Private Sub btnStartCapturing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        AddHandler Scanner.CaptureEvent, AddressOf CaptureEvent
        ufs_res = Scanner.StartCapturing()
        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner StartCapturing: OK" & vbNewLine)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner StartCapturing: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnAutoCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        AddHandler Scanner.CaptureEvent, AddressOf CaptureEvent
        ufs_res = Scanner.StartAutoCapture()
        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner StartAutoCapture: OK" & vbNewLine)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner StartAutoCapture: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnAbortCapturing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        ufs_res = Scanner.AbortCapturing()
        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner AbortCapturing: OK" & vbNewLine)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner AbortCapturing: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnCaptureSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufs_res = Scanner.CaptureSingleImage()
        Windows.Forms.Cursor.Current = Me.Cursor

        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner CaptureSingleImage: OK" & vbNewLine)
            DrawCapturedImage(Scanner)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        Scanner.TemplateSize = MAX_TEMPLATE_SIZE
        Scanner.DetectCore = cbDetectCore.Checked

        Dim Template As Byte() = New Byte(MAX_TEMPLATE_SIZE) {}
        Dim TemplateSize As Integer = Nothing
        Dim EnrollQuality As Integer = Nothing

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, TemplateSize, EnrollQuality)
        Windows.Forms.Cursor.Current = Me.Cursor

        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner ExtractEx: OK" & vbNewLine)
            DrawCapturedImage(Scanner)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner ExtractEx: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnEnroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        Dim EnrollQuality As Integer = Nothing
        Dim EnrollMode As Integer = Nothing
        Dim template_enrolled As Long
        Dim fingeron As Long

        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                Scanner.nTemplateType = 2001

            Case 1
                Scanner.nTemplateType = 2002

            Case 2
                Scanner.nTemplateType = 2003

        End Select

        If (rbtnOneTemplateAdvanced.Checked) Then
            EnrollMode = 1
        Else
            EnrollMode = 2
        End If

        template_enrolled = 0

        Dim udlg As UFE30_UserInfo = New UFE30_UserInfo()

        tbxMessage.AppendText("Input user data" & vbNewLine)
        udlg.ShowDialog(Me)
        If (udlg.DialogResult <> Windows.Forms.DialogResult.OK) Then
            tbxMessage.AppendText("User data input is cancelled by user" & vbNewLine)
            Exit Sub
        End If

        Me.Refresh()

        'Enroll Template with Non-Advanced-Extraction   
        If (rbtnOneTemplateNormal.Checked Or rbtnOneTemplateNormal2.Checked) Then
            Scanner.ClearCaptureImageBuffer()
            tbxMessage.AppendText("Place Finger" & vbNewLine)

            While True
                ufs_res = Scanner.CaptureSingleImage()
                If (ufs_res <> UFS_STATUS.OK) Then
                    UFScanner.GetErrorString(ufs_res, m_strError)
                    tbxMessage.AppendText("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
                    Exit Sub
                End If

                If (m_template_num + 1 = MAX_TEMPLATE_NUM) Then
                    tbxMessage.AppendText("Template memory is full" & vbNewLine)
                    Exit Sub
                End If


                If (template_enrolled = 0) Then
                    ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, m_template1(m_template_num), m_template_size1(m_template_num), EnrollQuality)
                Else
                    ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, m_template2(m_template_num), m_template_size2(m_template_num), EnrollQuality)
                End If

                DrawCapturedImage(Scanner)

                If (ufs_res = UFS_STATUS.OK) Then
                    If (EnrollQuality < m_quality) Then
                        tbxMessage.AppendText("Too low quality [Q:" & EnrollQuality & "]" & vbNewLine)
                    Else
                        m_UserID(m_template_num) = udlg.tbxUserID.Text
                        template_enrolled = template_enrolled + 1
                        tbxMessage.AppendText("Enrollment is succeed (No." & m_template_num & ") [Q:" & EnrollQuality & "]" & vbNewLine)

                        If (rbtnOneTemplateNormal.Checked = True) Then
                            m_template_num = m_template_num + 1
                            UpdateFingerDataList()
                            Exit While
                        ElseIf (rbtnOneTemplateNormal2.Checked = True And template_enrolled = 2) Then
                            m_template_num = m_template_num + 1
                            UpdateFingerDataList()
                            Exit While
                        Else
                            tbxMessage.AppendText("Remove finger" & vbNewLine)
                            While True
                                fingeron = Scanner.IsFingerOn
                                If (fingeron = 0) Then
                                    tbxMessage.AppendText("Place a finger" & vbCrLf)
                                    Exit While
                                End If
                            End While
                        End If
                    End If
                Else
                    UFScanner.GetErrorString(ufs_res, m_strError)
                    tbxMessage.AppendText("UFScanner Extract: " & m_strError & vbNewLine)
                End If
            End While

            'Enroll with Advanced-Extraction
        Else
            Dim dlg As UFE30_Enroll = New UFE30_Enroll()

            dlg.hScanner = Scanner
            dlg.tbxUserID.Text = udlg.tbxUserID.Text
            dlg.m_output_num = EnrollMode
            dlg.m_quality = m_quality

            dlg.ShowDialog(Me)
            If (dlg.DialogResult <> Windows.Forms.DialogResult.OK) Then
                tbxMessage.AppendText("Fingerprint enroll is cancelled by user" & vbNewLine)
                Exit Sub
            End If

            If (dlg.m_EnrollTemplateSize_output(0) <> 0) Then
                If (m_template_num + 1 = MAX_TEMPLATE_NUM) Then
                    tbxMessage.AppendText("Template memory is full" & vbNewLine)
                Else
                    'Enroll 1 Template
                    If (EnrollMode = 1) Then
                        System.Array.Copy(dlg.m_EnrollTemplate_output(0), 0, m_template1(m_template_num), 0, dlg.m_EnrollTemplateSize_output(0))
                        m_template_size1(m_template_num) = dlg.m_EnrollTemplateSize_output(0)
                        m_UserID(m_template_num) = udlg.tbxUserID.Text
                        'Enroll 2 Template
                    Else
                        System.Array.Copy(dlg.m_EnrollTemplate_output(0), 0, m_template1(m_template_num), 0, dlg.m_EnrollTemplateSize_output(0))
                        m_template_size1(m_template_num) = dlg.m_EnrollTemplateSize_output(0)

                        System.Array.Copy(dlg.m_EnrollTemplate_output(1), 0, m_template2(m_template_num), 0, dlg.m_EnrollTemplateSize_output(1))
                        m_template_size2(m_template_num) = dlg.m_EnrollTemplateSize_output(1)
                        m_UserID(m_template_num) = udlg.tbxUserID.Text

                    End If
                    tbxMessage.AppendText("Enrollment is succeed (No." & m_template_num & ")" & vbNewLine)
                    m_template_num = m_template_num + 1
                End If
                UpdateFingerDataList()
            Else
                tbxMessage.AppendText("Enrollment is failed" & vbNewLine)
            End If

            Scanner.Timeout = cbTimeout.SelectedIndex * 1000
        End If
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        Dim ufm_res As UFM_STATUS
        Dim Template As Byte() = New Byte(MAX_TEMPLATE_SIZE) {}
        Dim TemplateSize As Integer = Nothing
        Dim EnrollQuality As Integer = Nothing
        Dim VerifySucceed As Boolean = Nothing
        Dim SelectID As Integer

        If (lvFingerDataList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            SelectID = Convert.ToInt32(lvFingerDataList.SelectedItems(0).SubItems(FINGERDATA_COL_SERIAL).Text)
        End If

        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        tbxMessage.AppendText("Verify with serial: " & SelectID & vbNewLine)

        Scanner.ClearCaptureImageBuffer()

        tbxMessage.AppendText("Place Finger" & vbNewLine)

        ufs_res = Scanner.CaptureSingleImage()
        If (ufs_res <> UFS_STATUS.OK) Then
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
            Exit Sub
        End If

        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                Scanner.nTemplateType = 2001
            Case 1
                Scanner.nTemplateType = 2002
            Case 2
                Scanner.nTemplateType = 2003

        End Select

        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, TemplateSize, EnrollQuality)
        If (ufs_res = UFS_STATUS.OK) Then
            DrawCapturedImage(Scanner)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner ExtractEx: " & m_strError & vbNewLine)
        End If

        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                m_Matcher.nTemplateType = 2001
            Case 1
                m_Matcher.nTemplateType = 2002
            Case 2
                m_Matcher.nTemplateType = 2003

        End Select


        ufm_res = m_Matcher.Verify(Template, TemplateSize, m_template1(SelectID), m_template_size1(SelectID), VerifySucceed)
        If (ufs_res <> UFS_STATUS.OK) Then
            UFMatcher.GetErrorString(ufm_res, m_strError)
            tbxMessage.AppendText("UFMatcher Verify: " & m_strError & vbNewLine)
        End If

        If (VerifySucceed) Then
            tbxMessage.AppendText("Verification succeed (Serial." & (SelectID) & ") (ID." + m_UserID(SelectID) + ")" & vbNewLine)
        Else
            If (m_template_size2(SelectID) <> 0) Then
                ufm_res = m_Matcher.Verify(Template, TemplateSize, m_template2(SelectID), m_template_size2(SelectID), VerifySucceed)
                If (ufs_res <> UFS_STATUS.OK) Then
                    UFMatcher.GetErrorString(ufm_res, m_strError)
                    tbxMessage.AppendText("UFMatcher Verify: " & m_strError & vbNewLine)
                End If

                If (VerifySucceed) Then
                    tbxMessage.AppendText("Verification succeed (Serial." & (SelectID) & ") (ID." + m_UserID(SelectID) + ")" & vbNewLine)
                Else
                    tbxMessage.AppendText("Verification failed" & vbNewLine)
                End If
            Else
                tbxMessage.AppendText("Verification failed" & vbNewLine)
            End If
        End If
    End Sub

    Private Sub btnIdentify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        Dim ufm_res As UFM_STATUS
        Dim Template As Byte() = New Byte(MAX_TEMPLATE_SIZE) {}
        Dim TemplateSize As Integer = Nothing
        Dim EnrollQuality As Integer = Nothing
        Dim MatchIndex As Integer = Nothing

        Dim template_all As Byte()()
        Dim templateSize_all As Integer()
        Dim nindex As Integer()
        Dim j As Integer = 0
        Dim nMaxTemplateNum As Integer = 0

        template_all = New Byte(MAX_TEMPLATE_NUM * 2)() {}
        templateSize_all = New Integer(MAX_TEMPLATE_NUM * 2) {}
        nindex = New Integer(MAX_TEMPLATE_NUM * 2) {}

        For i As Integer = 0 To (m_template_num * 2) - 1
            template_all(i) = New Byte(MAX_TEMPLATE_SIZE) {}
            templateSize_all(i) = 0
        Next


        For i As Integer = 0 To (m_template_num * 2) - 1
            If (i < m_template_num) Then
                If (m_template_size1(i) <> 0) Then
                    System.Array.Copy(m_template1(i), 0, template_all(j), 0, m_template_size1(i))
                    templateSize_all(j) = m_template_size1(i)
                    nindex(j) = i
                    j = j + 1
                End If
            Else
                If (m_template_size2(i - m_template_num) <> 0) Then
                    System.Array.Copy(m_template2(i - m_template_num), 0, template_all(j), 0, m_template_size2(i - m_template_num))
                    templateSize_all(j) = m_template_size2(i - m_template_num)
                    nindex(j) = i - m_template_num
                    j = j + 1
                End If
            End If

        Next

        nMaxTemplateNum = j

        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If
        Scanner.ClearCaptureImageBuffer()

        tbxMessage.AppendText("Place Finger" & vbNewLine)

        ufs_res = Scanner.CaptureSingleImage()
        If (ufs_res <> UFS_STATUS.OK) Then
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
            Exit Sub
        End If

        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                Scanner.nTemplateType = 2001
            Case 1
                Scanner.nTemplateType = 2002
            Case 2
                Scanner.nTemplateType = 2003

        End Select

        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, TemplateSize, EnrollQuality)
        If (ufs_res = UFS_STATUS.OK) Then
            DrawCapturedImage(Scanner)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner ExtractEx: " & m_strError & vbNewLine)
        End If

        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                m_Matcher.nTemplateType = 2001
            Case 1
                m_Matcher.nTemplateType = 2002
            Case 2
                m_Matcher.nTemplateType = 2003

        End Select

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufm_res = m_Matcher.Identify(Template, TemplateSize, template_all, templateSize_all, nMaxTemplateNum, 5000, MatchIndex)
        Windows.Forms.Cursor.Current = Me.Cursor
        If (ufs_res <> UFS_STATUS.OK) Then
            UFMatcher.GetErrorString(ufm_res, m_strError)
            tbxMessage.AppendText("UFMatcher Identify: " & m_strError & vbNewLine)
            Exit Sub
        End If

        If (MatchIndex <> -1) Then
            tbxMessage.AppendText("Identification succeed Match Index." & MatchIndex & " (Match Serial." & nindex(MatchIndex) Mod nMaxTemplateNum & ") (ID." & m_UserID(nindex(MatchIndex)) & ")" & vbNewLine)
        Else
            tbxMessage.AppendText("Identification failed" & vbNewLine)
        End If
    End Sub

    Private Sub btnSaveTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Serial As Integer

        If (lvFingerDataList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvFingerDataList.SelectedItems(0).SubItems(FINGERDATA_COL_SERIAL).Text)
        End If

        Dim dlg As SaveFileDialog = New SaveFileDialog()
        dlg.Filter = "Template files (*.tmp)|*.tmp"
        dlg.DefaultExt = "tmp"
        Dim res As DialogResult = dlg.ShowDialog()
        If (res <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If

        Dim fs As FileStream = File.Create(dlg.FileName)
        fs.Write(m_template1(Serial), 0, m_template_size1(Serial))
        fs.Close()

        If (m_template_size2(Serial) <> 0) Then
            dlg.Filter = "Template files (*.tmp)|*.tmp"
            dlg.DefaultExt = "tmp"
            res = dlg.ShowDialog()
            If (res <> Windows.Forms.DialogResult.OK) Then
                Exit Sub
            End If

            fs = File.Create(dlg.FileName)
            fs.Write(m_template2(Serial), 0, m_template_size2(Serial))
            fs.Close()
        End If

        tbxMessage.AppendText("Selected template is saved" & vbNewLine)
    End Sub

    Private Sub btnSaveImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS

        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        Dim dlg As SaveFileDialog = New SaveFileDialog()
        dlg.Filter = "Bitmap files (*.bmp)|*.bmp"
        dlg.DefaultExt = "bmp"
        Dim res As DialogResult = dlg.ShowDialog()
        If (res <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If

        ufs_res = Scanner.SaveCaptureImageBufferToBMP(dlg.FileName)
        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner Image Buffer is saved to " & dlg.FileName & vbNewLine)
        End If

    End Sub

    Private Sub btnUpdateTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Scanner As UFScanner = Nothing
        Dim ufs_res As UFS_STATUS
        Dim Template As Byte() = New Byte(MAX_TEMPLATE_SIZE) {}
        Dim TemplateSize As Integer
        Dim EnrollQuality As Integer = Nothing
        Dim EnrollMode As Integer = Nothing
        Dim Serial As Integer
        Dim template_enrolled As Integer
        Dim fingeron As Integer

        If (lvFingerDataList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvFingerDataList.SelectedItems(0).SubItems(FINGERDATA_COL_SERIAL).Text)
        End If

        If (GetCurrentScanner(Scanner) = False) Then
            Exit Sub
        End If

        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                Scanner.nTemplateType = 2001

            Case 1
                Scanner.nTemplateType = 2002

            Case 2
                Scanner.nTemplateType = 2003

        End Select

        If (rbtnOneTemplateAdvanced.Checked) Then
            EnrollMode = 1
        Else
            EnrollMode = 2
        End If

        template_enrolled = 0

        'Update Template with Non-Advanced-Extraction   
        If (rbtnOneTemplateNormal.Checked Or rbtnOneTemplateNormal2.Checked) Then
            Scanner.ClearCaptureImageBuffer()
            tbxMessage.AppendText("Place Finger" & vbNewLine)

            While True
                ufs_res = Scanner.CaptureSingleImage()
                If (ufs_res <> UFS_STATUS.OK) Then
                    UFScanner.GetErrorString(ufs_res, m_strError)
                    tbxMessage.AppendText("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
                    Exit Sub
                End If

                ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, TemplateSize, EnrollQuality)

                DrawCapturedImage(Scanner)

                If (ufs_res = UFS_STATUS.OK) Then
                    If (EnrollQuality < m_quality) Then
                        tbxMessage.AppendText("Too low quality [Q:" & EnrollQuality & "]" & vbNewLine)
                    Else
                        If (rbtnOneTemplateNormal.Checked) Then
                            System.Array.Clear(m_template2(Serial), 0, MAX_TEMPLATE_SIZE)
                            m_template_size2(Serial) = 0

                            System.Array.Clear(m_template1(Serial), 0, MAX_TEMPLATE_SIZE)
                            System.Array.Copy(Template, 0, m_template1(Serial), 0, TemplateSize)
                            m_template_size1(Serial) = TemplateSize
                            tbxMessage.AppendText("Update success (Serial." & Serial & ") [Q:" & EnrollQuality & "]" & vbNewLine)
                            UpdateFingerDataList()
                            Exit While
                        ElseIf (rbtnOneTemplateNormal2.Checked And template_enrolled = 1) Then
                            System.Array.Clear(m_template2(Serial), 0, MAX_TEMPLATE_SIZE)
                            System.Array.Copy(Template, 0, m_template2(Serial), 0, TemplateSize)
                            m_template_size2(Serial) = TemplateSize
                            tbxMessage.AppendText("Second template update success (Serial." & Serial & ") [Q:" & EnrollQuality & "]" & vbNewLine)
                            UpdateFingerDataList()
                            Exit While
                        Else
                            template_enrolled = template_enrolled + 1
                            System.Array.Clear(m_template1(Serial), 0, MAX_TEMPLATE_SIZE)
                            System.Array.Copy(Template, 0, m_template1(Serial), 0, TemplateSize)
                            m_template_size1(Serial) = TemplateSize
                            tbxMessage.AppendText("First template update success (Serial." & Serial & ") [Q:" & EnrollQuality & "]" & vbNewLine)
                            tbxMessage.AppendText("Remove finger" & vbNewLine)

                            While True
                                fingeron = Scanner.IsFingerOn
                                If (fingeron = 0) Then
                                    tbxMessage.AppendText("Place a finger" & vbCrLf)
                                    Exit While
                                End If
                            End While
                        End If

                    End If
                Else
                    UFScanner.GetErrorString(ufs_res, m_strError)
                    tbxMessage.AppendText("UFScanner Extract: " & m_strError & vbNewLine)
                End If
            End While

            'Update with Advanced-Extraction
        Else
            Dim dlg As UFE30_Enroll = New UFE30_Enroll()

            dlg.hScanner = Scanner
            dlg.tbxUserID.Text = m_UserID(Serial)
            dlg.m_output_num = EnrollMode
            dlg.m_quality = m_quality

            dlg.ShowDialog(Me)
            If (dlg.DialogResult <> Windows.Forms.DialogResult.OK) Then
                tbxMessage.AppendText("FIngerprint update is cancelled by user" & vbNewLine)
                Exit Sub
            End If

            If (dlg.m_EnrollTemplateSize_output(0) <> 0) Then
                'Update 1 Template
                If (EnrollMode = 1) Then
                    System.Array.Clear(m_template2(Serial), 0, MAX_TEMPLATE_SIZE)
                    m_template_size2(Serial) = 0

                    System.Array.Clear(m_template1(Serial), 0, MAX_TEMPLATE_SIZE)
                    System.Array.Copy(dlg.m_EnrollTemplate_output(0), 0, m_template1(Serial), 0, dlg.m_EnrollTemplateSize_output(0))
                    m_template_size1(Serial) = dlg.m_EnrollTemplateSize_output(0)
                    'Update 2 Template
                Else
                    System.Array.Clear(m_template1(Serial), 0, MAX_TEMPLATE_SIZE)
                    System.Array.Copy(dlg.m_EnrollTemplate_output(0), 0, m_template1(Serial), 0, dlg.m_EnrollTemplateSize_output(0))
                    m_template_size1(Serial) = dlg.m_EnrollTemplateSize_output(0)
                    System.Array.Clear(m_template2(Serial), 0, MAX_TEMPLATE_SIZE)
                    System.Array.Copy(dlg.m_EnrollTemplate_output(1), 0, m_template2(Serial), 0, dlg.m_EnrollTemplateSize_output(1))
                    m_template_size2(Serial) = dlg.m_EnrollTemplateSize_output(1)
                End If
                tbxMessage.AppendText("FIngerprint update is succeed (Serial." & Serial & ")" & vbNewLine)

                UpdateFingerDataList()
            Else
                tbxMessage.AppendText("Fingerprint update is failed" & vbNewLine)
            End If

            Scanner.Timeout = cbTimeout.SelectedIndex * 1000
        End If

    End Sub

    Private Sub btnDeleteTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Serial As Integer

        If (lvFingerDataList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvFingerDataList.SelectedItems(0).SubItems(FINGERDATA_COL_SERIAL).Text)
        End If

        For i As Integer = Serial To m_template_num - 1
            System.Array.Clear(m_template1(i), 0, MAX_TEMPLATE_SIZE)
            System.Array.Copy(m_template1(i + 1), 0, m_template1(i), 0, m_template_size1(i + 1))
            m_template_size1(i) = m_template_size1(i + 1)

            System.Array.Clear(m_template2(i), 0, MAX_TEMPLATE_SIZE)
            System.Array.Copy(m_template2(i + 1), 0, m_template2(i), 0, m_template_size2(i + 1))
            m_template_size2(i) = m_template_size2(i + 1)

            m_UserID(i) = m_UserID(i + 1)
        Next

        System.Array.Clear(m_template1(m_template_num - 1), 0, MAX_TEMPLATE_SIZE)
        System.Array.Clear(m_template2(m_template_num - 1), 0, MAX_TEMPLATE_SIZE)
        m_template_size1(m_template_num - 1) = 0
        m_template_size2(m_template_num - 1) = 0
        m_UserID(m_template_num - 1) = Nothing

        m_template_num = m_template_num - 1

        UpdateFingerDataList()

    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i As Integer = 0 To MAX_TEMPLATE_NUM - 1
            System.Array.Clear(m_template1(i), 0, MAX_TEMPLATE_SIZE)
            m_template_size1(i) = 0
            System.Array.Clear(m_template2(i), 0, MAX_TEMPLATE_SIZE)
            m_template_size2(i) = 0
            m_UserID(i) = Nothing
        Next

        m_template_num = 0

        UpdateFingerDataList()
    End Sub
    '==========================================================================='

    Private Sub cbQuality_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbQuality.SelectedIndexChanged
        m_quality = 100 - ((cbQuality.SelectedIndex + 1) * 10)
        If (cbQuality.SelectedIndex = 9) Then
            m_quality = 0
        End If

    End Sub
End Class
