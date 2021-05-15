Imports Suprema

Public Class UFE30_Enroll
    Public hScanner As UFScanner = Nothing
    Public m_EnrollTemplate_input As Byte()()
    Public m_EnrollTemplateSize_input As Integer()
    Public m_EnrollTemplate_output As Byte()()
    Public m_EnrollTemplateSize_output As Integer()

    Public m_extract_num As Integer
    Public m_output_num As Integer
    Public m_try_extract As Boolean
    Public m_bFingerCheck As Boolean
    Public m_quality As Integer

    Private Const MAX_TEMPLATE_INPUT_NUM As Integer = 4
    Private Const MAX_TEMPLATE_OUTPUT_NUM As Integer = 2
    Private Const MAX_TEMPLATE_SIZE As Integer = 1024

    Private Delegate Sub _UpdatePictureBox(ByRef pbox As PictureBox, ByRef image As Bitmap)
    Private Delegate Sub _SetTextMessageCallback(ByRef text As TextBox, ByRef s As String)


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

    Public Sub SetTextMessageCallback(ByRef text As TextBox, ByRef s As String)
        If (text.InvokeRequired) Then
            Dim del As _SetTextMessageCallback = New _SetTextMessageCallback(AddressOf SetTextMessageCallback)
            ' Call the function in the correct thread
            Dim params() As Object = New Object(1) {text, s}
            BeginInvoke(del, params)
        Else
            ' We are in the correct thread, so assign the image
            text.AppendText(s)
        End If
    End Sub

    Public Function EnrollEvent(ByVal sender As Object, ByVal e As UFScannerCaptureEventArgs) As Integer
        Dim Template As Byte()
        Dim TemplateSize As Integer
        Dim nEnrollQuality As Integer
        Dim ufs_res As UFS_STATUS
        Dim strError As String = Nothing

        Template = New Byte(MAX_TEMPLATE_SIZE) {}

        If (Not m_try_extract) Then
            If (Not e.FingerOn) Then
                m_try_extract = True
                m_bFingerCheck = False
                SetTextMessageCallback(tbxMessage, "Place your finger" & vbNewLine)
            Else
                If (Not m_bFingerCheck) Then
                    SetTextMessageCallback(tbxMessage, "Remove your fingerprint from scanner" & vbNewLine)
                    m_bFingerCheck = True
                End If
            End If

            UpdatePictureBox(pbImageFrame, e.ImageFrame)
            Return 1
        End If


        If (e.FingerOn And m_try_extract) Then
            ufs_res = hScanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, TemplateSize, nEnrollQuality)
            If (ufs_res = UFS_STATUS.OK) Then
                If (nEnrollQuality < m_quality) Then
                    SetTextMessageCallback(tbxMessage, "Template Quality is too low" & vbNewLine)
                Else
                    System.Array.Copy(Template, 0, m_EnrollTemplate_input(m_extract_num), 0, TemplateSize)
                    m_EnrollTemplateSize_input(m_extract_num) = TemplateSize
                    m_extract_num = m_extract_num + 1
                    SetTextMessageCallback(tbxMessage, "UFS_Extract: OK (" & m_extract_num & "/4)" & vbNewLine)
                    m_try_extract = False

                    If (m_extract_num = MAX_TEMPLATE_INPUT_NUM) Then
                        ufs_res = hScanner.SelectTemplateEx(MAX_TEMPLATE_SIZE, m_EnrollTemplate_input, m_EnrollTemplateSize_input, 4, m_EnrollTemplate_output, m_EnrollTemplateSize_output, m_output_num)
                        If (ufs_res = UFS_STATUS.OK) Then

                            SetTextMessageCallback(tbxMessage, "Extraction process is succeed" & vbNewLine)
                            If (m_output_num = 1) Then
                                ' output template number is 1
                            ElseIf (m_output_num = 2) Then
                                ' output template number is 2
                            Else
                                SetTextMessageCallback(tbxMessage, "template output number is not correct" & vbNewLine)
                            End If
                        Else
                            SetTextMessageCallback(tbxMessage, "Extraction process is faild" & vbNewLine)
                        End If
                        UpdatePictureBox(pbImageFrame, e.ImageFrame)
                        Return 0
                    End If
                End If
            Else
                UFScanner.GetErrorString(ufs_res, strError)
                SetTextMessageCallback(tbxMessage, "UFS_Extract:" & strError & vbNewLine)
            End If
        End If

        UpdatePictureBox(pbImageFrame, e.ImageFrame)

        Return 1
    End Function

    Private Sub UFE30_Enroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ufs_res As UFS_STATUS
        Dim strError As String = Nothing

        m_extract_num = 0
        m_try_extract = True
        m_bFingerCheck = False

        m_EnrollTemplate_input = New Byte(MAX_TEMPLATE_INPUT_NUM)() {}
        m_EnrollTemplateSize_input = New Integer(MAX_TEMPLATE_INPUT_NUM) {}

        For i As Integer = 0 To MAX_TEMPLATE_INPUT_NUM - 1
            m_EnrollTemplate_input(i) = New Byte(MAX_TEMPLATE_SIZE) {}
            m_EnrollTemplateSize_input(i) = 0
        Next

        m_EnrollTemplate_output = New Byte([m_output_num])() {}
        m_EnrollTemplateSize_output = New Integer([m_output_num]) {}

        For i As Integer = 0 To m_output_num - 1
            m_EnrollTemplate_output(i) = New Byte(MAX_TEMPLATE_SIZE) {}
            m_EnrollTemplateSize_output(i) = 0
        Next

        tbxMessage.AppendText("Advanced Enroll is started. Place your finger" & vbNewLine)

        hScanner.ClearCaptureImageBuffer()

        hScanner.Timeout = 0

        AddHandler hScanner.CaptureEvent, AddressOf EnrollEvent
        ufs_res = hScanner.StartCapturing()
        If (ufs_res = UFS_STATUS.OK) Then

            tbxMessage.AppendText("UFScanner StartCapturing: OK" & vbNewLine)

        Else
            UFScanner.GetErrorString(ufs_res, strError)
            tbxMessage.AppendText("UFScanner StartCapturing: " & strError & vbNewLine)
        End If



    End Sub

    Private Sub UFE30_Enroll_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim ufs_res As UFS_STATUS = UFS_STATUS.ERROR

        ufs_res = hScanner.AbortCapturing()

        RemoveHandler hScanner.CaptureEvent, AddressOf EnrollEvent

        While (True)

            If (hScanner.IsCapturing) Then
                System.Threading.Thread.Sleep(10)
            Else
                Exit While
            End If
        End While


    End Sub
End Class