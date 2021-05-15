Imports Suprema

Public Class UFE30_DatabaseDemo
    Private m_ScannerManager As UFScannerManager
    Private m_Scanner As UFScanner
    Private m_Matcher As UFMatcher
    Private m_Database As UFDatabase
    Private m_strError As String
    Private m_Serial As Integer
    Private m_UserID As String
    Private m_FingerIndex As Integer
    Private m_Template1 As Byte()
    Private m_Template1Size As Integer
    Private m_Template2 As Byte()
    Private m_Template2Size As Integer
    Private m_Memo As String
    '
    Private Const MAX_USERID_SIZE As Integer = 50
    Private Const MAX_TEMPLATE_SIZE As Integer = 1024
    Private Const MAX_MEMO_SIZE As Integer = 100
    '
    Private Const DATABASE_COL_SERIAL As Integer = 0
    Private Const DATABASE_COL_USERID As Integer = 1
    Private Const DATABASE_COL_FINGERINDEX As Integer = 2
    Private Const DATABASE_COL_TEMPLATE1 As Integer = 3
    Private Const DATABASE_COL_TEMPLATE2 As Integer = 4
    Private Const DATABASE_COL_MEMO As Integer = 5

    '==========================================================================='
    Private Sub UFE30_DatabaseDemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_ScannerManager = New UFScannerManager(Me)
        m_Scanner = Nothing
        m_Matcher = Nothing
        m_Database = Nothing

        m_Template1 = New Byte(MAX_TEMPLATE_SIZE) {}
        m_Template2 = New Byte(MAX_TEMPLATE_SIZE) {}

        lvDatabaseList.Columns.Add("Serial", 50, HorizontalAlignment.Left)
        lvDatabaseList.Columns.Add("UserID", 60, HorizontalAlignment.Left)
        lvDatabaseList.Columns.Add("FingerIndex", 80, HorizontalAlignment.Left)
        lvDatabaseList.Columns.Add("Template1", 80, HorizontalAlignment.Left)
        lvDatabaseList.Columns.Add("Template2", 80, HorizontalAlignment.Left)
        lvDatabaseList.Columns.Add("Memo", 60, HorizontalAlignment.Left)

        cbScanTemplateType.SelectedIndex = 0
    End Sub

    Private Sub UFE30_DatabaseDemo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        btnUninit_Click(sender, e)
    End Sub
    '==========================================================================='

    '==========================================================================='
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        tbxMessage.Clear()
    End Sub

    Private Sub AddRow(ByVal Serial As Integer, ByVal UserID As String, ByVal FingerIndex As Integer, ByVal bTemplate1 As Boolean, ByVal bTemplate2 As Boolean, ByVal Memo As String)
        Dim listItem As ListViewItem
        listItem = lvDatabaseList.Items.Add(Convert.ToString(Serial))
        listItem.SubItems.Add(UserID)
        listItem.SubItems.Add(Convert.ToString(FingerIndex))
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
        listItem.SubItems.Add(Memo)
    End Sub

    Private Sub DrawCapturedImage(ByRef Scanner As UFScanner)
        Dim g As Graphics = pbImageFrame.CreateGraphics()
        Dim rect As Rectangle = New Rectangle(0, 0, pbImageFrame.Width, pbImageFrame.Height)
        Dim Resolution As Integer
        Try
            '
            Scanner.DrawCaptureImageBuffer(g, rect, False)
            '
            'Dim bitmap As Bitmap = Nothing
            'Scanner.GetCaptureImageBuffer(bitmap, Resolution)
            'pbImageFrame.Image = bitmap
        Finally
            g.Dispose()
        End Try
    End Sub

    Private Sub UpdateDatabaseList()
        If (Equals(m_Database, Nothing)) Then
            Exit Sub
        End If

        Dim ufd_res As UFD_STATUS
        Dim DataNumber As Integer
        Dim i As Integer

        ufd_res = m_Database.GetDataNumber(DataNumber)
        If (ufd_res = UFD_STATUS.OK) Then
            tbxMessage.AppendText("UFDatabase GetDataNumber: " & DataNumber & vbNewLine)
        Else
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase GetDataNumber: " & m_strError & vbNewLine)
            Exit Sub
        End If

        lvDatabaseList.Items.Clear()

        For i = 0 To DataNumber - 1
            ufd_res = m_Database.GetDataByIndex(i, m_Serial, m_UserID, m_FingerIndex, m_Template1, m_Template1Size, m_Template2, m_Template2Size, m_Memo)
            If (ufd_res <> UFD_STATUS.OK) Then
                UFDatabase.GetErrorString(ufd_res, m_strError)
                tbxMessage.AppendText("UFDatabase GetDataByIndex: " & m_strError & vbNewLine)
                Exit Sub
            End If

            AddRow(m_Serial, m_UserID, m_FingerIndex, (m_Template1Size <> 0), (m_Template2Size <> 0), m_Memo)
        Next
    End Sub
    '==========================================================================='

    '==========================================================================='
    Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
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

        nScannerNumber = m_ScannerManager.Scanners.Count
        tbxMessage.AppendText("UFScanner GetScannerNumber: " & nScannerNumber & vbNewLine)

        If (nScannerNumber = 0) Then
            tbxMessage.AppendText("There's no available scanner" & vbNewLine)
            Exit Sub
        Else
            tbxMessage.AppendText("First scanner will be used" & vbNewLine)
        End If

        m_Scanner = m_ScannerManager.Scanners(0)
        '==========================================================================='

        '==========================================================================='
        ' Open database
        '==========================================================================='
        Dim ufd_res As UFD_STATUS

        m_Database = New UFDatabase()

        ' Generate connection string
        Dim DataSource As String
        Dim Connection As String
        '
        'DataSource = "UFDatabase.mdb"
        '
        tbxMessage.AppendText("Select a database file" & vbNewLine)
        Dim dlg As OpenFileDialog = New OpenFileDialog()
        dlg.FileName = "UFDatabase.mdb"
        dlg.Filter = "Database Files (*.mdb)|*.mdb"
        dlg.DefaultExt = "mdb"
        Dim res As DialogResult = dlg.ShowDialog()
        If (res <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If
        DataSource = dlg.FileName
        '
        Connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DataSource & ";"

        ' Open database
        ufd_res = m_Database.Open(Connection, "", "")
        If (ufd_res = UFD_STATUS.OK) Then
            tbxMessage.AppendText("UFDatabase Open: OK" & vbNewLine)
        Else
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase Open: " & m_strError & vbNewLine)
            Exit Sub
        End If

        UpdateDatabaseList()
        '==========================================================================='

        '==========================================================================='
        ' Create matcher
        '==========================================================================='
        m_Matcher = New UFMatcher()

        If (m_Matcher.InitResult = UFM_STATUS.OK) Then
            tbxMessage.AppendText("UFMatcher Init: OK" & vbNewLine)
        Else
            UFMatcher.GetErrorString(m_Matcher.InitResult, m_strError)
            tbxMessage.AppendText("UFMatcher Init: " & m_strError & vbNewLine)
        End If
        '==========================================================================='
    End Sub

    Private Sub btnUninit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUninit.Click
        '==========================================================================='
        ' Uninit scanner module
        '==========================================================================='
        Dim ufs_res As UFS_STATUS

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufs_res = m_ScannerManager.Uninit()
        Windows.Forms.Cursor.Current = Me.Cursor

        If (ufs_res = UFS_STATUS.OK) Then
            tbxMessage.AppendText("UFScanner Uninit: OK" & vbNewLine)
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            tbxMessage.AppendText("UFScanner Uninit: " & m_strError & vbNewLine)
        End If
        '==========================================================================='

        '==========================================================================='
        ' Close database
        '==========================================================================='
        If (Not Equals(m_Database, Nothing)) Then
            Dim ufd_res As UFD_STATUS

            ' Close database
            ufd_res = m_Database.Close()
            If (ufd_res = UFD_STATUS.OK) Then
                tbxMessage.AppendText("UFDatabase Close: OK" & vbNewLine)
            Else
                UFDatabase.GetErrorString(ufd_res, m_strError)
                tbxMessage.AppendText("UFDatabase Close: " & m_strError & vbNewLine)
            End If
        End If

        lvDatabaseList.Items.Clear()
        '==========================================================================='
    End Sub

    Private Function ExtractTemplate(ByRef Template As Byte(), ByRef TemplateSize As Integer) As Boolean
        Dim ufs_res As UFS_STATUS
        Dim EnrollQuality As Integer

        m_Scanner.ClearCaptureImageBuffer()

        tbxMessage.AppendText("Place Finger" & vbNewLine)

        TemplateSize = 0
        Do
            ufs_res = m_Scanner.CaptureSingleImage()
            If (ufs_res <> UFS_STATUS.OK) Then
                UFScanner.GetErrorString(ufs_res, m_strError)
                tbxMessage.AppendText("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
                ExtractTemplate = False
                Exit Function
            End If

            DrawCapturedImage(m_Scanner)

            ufs_res = m_Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, TemplateSize, EnrollQuality)
            If (ufs_res = UFS_STATUS.OK) Then
                tbxMessage.AppendText("UFScanner Extract: OK" & vbNewLine)
                Exit Do
            Else
                UFScanner.GetErrorString(ufs_res, m_strError)
                tbxMessage.AppendText("UFScanner Extract: " & m_strError & vbNewLine)
            End If
        Loop

        ExtractTemplate = True
    End Function

    Private Sub btnEnroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnroll.Click
        If (Not ExtractTemplate(m_Template1, m_Template1Size)) Then
            Exit Sub
        End If

        Dim dlg As UserInfoForm = New UserInfoForm(False)
        Dim ufd_res As UFD_STATUS

        tbxMessage.AppendText("Input user data" & vbNewLine)
        dlg.ShowDialog(Me)
        If (dlg.DialogResult <> Windows.Forms.DialogResult.OK) Then
            tbxMessage.AppendText("User data input is cancelled by user" & vbNewLine)
            Exit Sub
        End If

        ufd_res = m_Database.AddData(dlg.tbxUserID.Text, Convert.ToInt32(dlg.tbxFingerIndex.Text), m_Template1, m_Template1Size, Nothing, 0, dlg.tbxMemo.Text)
        If (ufd_res <> UFD_STATUS.OK) Then
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase AddData: " & m_strError & vbNewLine)
        Else
            cbScanTemplateType.Enabled = False
        End If

        UpdateDatabaseList()
    End Sub

    Private Sub btnIdentify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdentify.Click
        Dim ufd_res As UFD_STATUS
        Dim ufm_res As UFM_STATUS
        ' Input finger data
        Dim Template As Byte() = New Byte(MAX_TEMPLATE_SIZE) {}
        Dim TemplateSize As Integer
        ' DB data
        Dim DBTemplate As Byte()() = Nothing
        Dim DBTemplateSize As Integer() = Nothing
        Dim DBSerial As Integer() = Nothing
        Dim DBTemplateNum As Integer
        '
        Dim MatchIndex As Integer

        ufd_res = m_Database.GetTemplateListWithSerial(DBTemplate, DBTemplateSize, DBTemplateNum, DBSerial)
        If (ufd_res <> UFD_STATUS.OK) Then
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFD_GetTemplateListWithSerial: " + m_strError + vbNewLine)
            Exit Sub
        End If

        If (Not ExtractTemplate(Template, TemplateSize)) Then
            Exit Sub
        End If

        DrawCapturedImage(m_Scanner)

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ufm_res = m_Matcher.Identify(Template, TemplateSize, DBTemplate, DBTemplateSize, DBTemplateNum, 5000, MatchIndex)
        Windows.Forms.Cursor.Current = Me.Cursor
        If (ufm_res <> UFM_STATUS.OK) Then
            UFMatcher.GetErrorString(ufm_res, m_strError)
            tbxMessage.AppendText("UFMatcher Identify: " & m_strError & vbNewLine)
            Exit Sub
        End If

        If (MatchIndex <> -1) Then
            tbxMessage.AppendText("Identification succeed (Serial = " & DBSerial(MatchIndex) & ")" & vbNewLine)
        Else
            tbxMessage.AppendText("Identification failed" & vbNewLine)
        End If
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim ufd_res As UFD_STATUS

        ufd_res = m_Database.RemoveAllData()
        If (ufd_res = UFD_STATUS.OK) Then
            tbxMessage.AppendText("UFDatabase RemoveAllData: OK" & vbNewLine)
            UpdateDatabaseList()
        Else
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase RemoveAllData: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnSelectionDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectionDelete.Click
        Dim ufd_res As UFD_STATUS
        Dim Serial As Integer

        If (lvDatabaseList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_SERIAL).Text)
        End If

        ufd_res = m_Database.RemoveDataBySerial(Serial)
        If (ufd_res = UFD_STATUS.OK) Then
            tbxMessage.AppendText("UFDatabase RemoveDataBySerial: OK" & vbNewLine)
            UpdateDatabaseList()
        Else
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase RemoveDataBySerial: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnSelectionUpdateUserInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectionUpdateUserInfo.Click
        Dim dlg As UserInfoForm = New UserInfoForm(True)
        Dim ufd_res As UFD_STATUS
        Dim Serial As Integer

        If (lvDatabaseList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_SERIAL).Text)
            dlg.tbxUserID.Text = lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_USERID).Text
            dlg.tbxFingerIndex.Text = Convert.ToInt32(lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_FINGERINDEX).Text)
            dlg.tbxMemo.Text = lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_MEMO).Text
        End If

        tbxMessage.AppendText("Update user data" & vbNewLine)
        tbxMessage.AppendText("UserID and FingerIndex will not be updated" & vbNewLine)
        dlg.ShowDialog(Me)
        If (dlg.DialogResult <> Windows.Forms.DialogResult.OK) Then
            tbxMessage.AppendText("User data input is cancelled by user" & vbNewLine)
            Exit Sub
        End If

        ufd_res = m_Database.UpdateDataBySerial(Serial, Nothing, 0, Nothing, 0, dlg.tbxMemo.Text)
        If (ufd_res = UFD_STATUS.OK) Then
            tbxMessage.AppendText("UFD_UpdateDataBySerial: OK" & vbNewLine)
            UpdateDatabaseList()
        Else
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase UpdateDataBySerial: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnSelectionUpdateTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectionUpdateTemplate.Click
        Dim ufd_res As UFD_STATUS
        Dim Serial As Integer

        If (lvDatabaseList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_SERIAL).Text)
        End If

        If (Not ExtractTemplate(m_Template1, m_Template1Size)) Then
            Exit Sub
        End If

        DrawCapturedImage(m_Scanner)

        ufd_res = m_Database.UpdateDataBySerial(Serial, m_Template1, m_Template1Size, Nothing, 0, vbNullString)
        If (ufd_res = UFD_STATUS.OK) Then
            tbxMessage.AppendText("UFD_UpdateDataBySerial: OK" & vbNewLine)
            UpdateDatabaseList()
        Else
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase UpdateDataBySerial: " & m_strError & vbNewLine)
        End If
    End Sub

    Private Sub btnSelectionVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectionVerify.Click
        Dim ufd_res As UFD_STATUS
        Dim ufm_res As UFM_STATUS
        Dim Serial As Integer
        ' Input finger data
        Dim Template As Byte() = New Byte(MAX_TEMPLATE_SIZE) {}
        Dim TemplateSize As Integer
        '
        Dim VerifySucceed As Boolean

        If (lvDatabaseList.SelectedIndices.Count = 0) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        Else
            Serial = Convert.ToInt32(lvDatabaseList.SelectedItems(0).SubItems(DATABASE_COL_SERIAL).Text)
        End If

        ufd_res = m_Database.GetDataBySerial(Serial, m_UserID, m_FingerIndex, m_Template1, m_Template1Size, m_Template2, m_Template2Size, m_Memo)
        If (ufd_res <> UFD_STATUS.OK) Then
            UFDatabase.GetErrorString(ufd_res, m_strError)
            tbxMessage.AppendText("UFDatabase UpdateDataBySerial: " & m_strError & vbNewLine)
            Exit Sub
        End If

        If (Not ExtractTemplate(Template, TemplateSize)) Then
            Exit Sub
        End If

        DrawCapturedImage(m_Scanner)

        ufm_res = m_Matcher.Verify(Template, TemplateSize, m_Template1, m_Template1Size, VerifySucceed)
        If (ufm_res <> UFM_STATUS.OK) Then
            UFMatcher.GetErrorString(ufm_res, m_strError)
            tbxMessage.AppendText("UFMatcher Verify: " + m_strError + vbNewLine)
            Exit Sub
        End If

        If (VerifySucceed) Then
            tbxMessage.AppendText("Verification succeed (Serial = " & Serial & ")" & vbNewLine)
        Else
            tbxMessage.AppendText("Verification failed" & vbNewLine)
        End If
    End Sub
    '==========================================================================='

    Private Sub cbScanTemplateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbScanTemplateType.SelectedIndexChanged
        ' template type 2001,2002,2003

        If (m_Scanner Is Nothing) Then
            tbxMessage.AppendText("Select data" & vbNewLine)
            Exit Sub
        End If


        Select Case cbScanTemplateType.SelectedIndex

            Case 0
                m_Scanner.nTemplateType = 2001
                m_Matcher.nTemplateType = 2001
            Case 1
                m_Scanner.nTemplateType = 2002
                m_Matcher.nTemplateType = 2002
            Case 2
                m_Scanner.nTemplateType = 2003
                m_Matcher.nTemplateType = 2003

        End Select
    End Sub
End Class
