Attribute VB_Name = "UFE30_Module"
Const MAX_TEMPLATE_SIZE As Long = 1024

Const GOOD_TEMPLATE_SCORE As Long = 85
Const MAX_TEMPLATE_INPUT_NUM  As Long = 4
Const MAX_TEMPLATE_OUTPUT_NUM As Long = 2
Private Template(MAX_TEMPLATE_SIZE - 1) As Byte

Private EnrollTemplate_input(MAX_TEMPLATE_SIZE - 1, MAX_TEMPLATE_INPUT_NUM - 1) As Byte
Private EnrollTemplateSize_input(MAX_TEMPLATE_INPUT_NUM - 1) As Long
Private EnrollTemplate_output(MAX_TEMPLATE_SIZE - 1, MAX_TEMPLATE_OUTPUT_NUM - 1) As Byte
Private EnrollTemplateSize_output(MAX_TEMPLATE_OUTPUT_NUM - 1) As Long

Private template_inptr(MAX_TEMPLATE_INPUT_NUM - 1) As Long
Private template_outptr(MAX_TEMPLATE_OUTPUT_NUM - 1) As Long


Function ScannerProc(ByVal szScannerID As String, ByVal bSensorOn As Long, ByVal pParam As Long) As Long
    If (bSensorOn = 1) Then
        UFE30_Demo.AddMessage ("Scanner ID = (" & szScannerID & ") is connected." & vbCrLf)
    Else
        UFE30_Demo.AddMessage ("Scanner ID = (" & szScannerID & ") is disconnected." & vbCrLf)
    End If
    UFE30_Demo.UpdateScannerList
    ScannerProc = 1
End Function

Function CaptureProc(ByVal hScanner As Long, ByVal bFingerOn As Long, _
                     ByVal pImage As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal nResolution As Long, _
                     ByVal pParam As Long) As Long
    UFE30_Demo.pbImageFrame.Refresh
    
    If (UFE30_Demo.FormEnd = 1) Then
        CaptureProc = 0
        Exit Function
    End If
    
    CaptureProc = 1
End Function

Function EnrollProc(ByVal hScanner As Long, ByVal bFingerOn As Long, _
                     ByVal pImage As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal nResolution As Long, _
                     ByVal pParam As Long) As Long
    
    Dim ufs_res As UFS_STATUS
    Dim TemplateSize As Long
    Dim EnrollQuality As Long
    Dim strError As String
    Dim i As Long
    Dim j As Long
    
    EnrollProc = 1
    
    For i = 0 To MAX_TEMPLATE_SIZE - 1
        Template(i) = 0
    Next
    
    If (UFE30_Enroll.TryExtract <> True) Then
        If (bFingerOn = 0) Then
            UFE30_Enroll.TryExtract = True
            UFE30_Enroll.FingerCheck = False
            UFE30_Enroll.AddMessage ("Place your finger" & vbCrLf)
        Else
            If (UFE30_Enroll.FingerCheck <> True) Then
                UFE30_Enroll.AddMessage ("Remove your fingerprint from scanner" & vbCrLf)
                UFE30_Enroll.FingerCheck = True
            End If
        End If
        
        UFE30_Enroll.pbImageFrame.Refresh
        EnrollProc = 1
    End If
        
    If (bFingerOn = 1 And UFE30_Enroll.TryExtract = True) Then
         ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, EnrollTemplate_input(0, UFE30_Enroll.ExtractNum), TemplateSize, EnrollQuality)
         EnrollTemplateSize_input(UFE30_Enroll.ExtractNum) = TemplateSize
         If ufs_res = UFS_STATUS.OK Then
            If (EnrollQuality < UFE30_Enroll.Quality) Then
                UFE30_Enroll.AddMessage ("Template Quality is too low" & vbCrLf)
            Else
                UFE30_Enroll.ExtractNum = UFE30_Enroll.ExtractNum + 1
                UFE30_Enroll.AddMessage ("UFS_Extract: OK (" & UFE30_Enroll.ExtractNum & "/4)" & vbCrLf)
                UFE30_Enroll.TryExtract = False
                
                If (UFE30_Enroll.ExtractNum = MAX_TEMPLATE_INPUT_NUM) Then
                    
                    For i = 0 To MAX_TEMPLATE_INPUT_NUM - 1
                        template_inptr(i) = VarPtr(EnrollTemplate_input(0, i))
                    Next
                                     
                    For i = 0 To MAX_TEMPLATE_OUTPUT_NUM - 1
                        template_outptr(i) = VarPtr(EnrollTemplate_output(0, i))
                    Next
                    
                    ufs_res = UFS_SelectTemplateEx(hScanner, MAX_TEMPLATE_SIZE, template_inptr(0), EnrollTemplateSize_input(0), 4, template_outptr(0), EnrollTemplateSize_output(0), UFE30_Enroll.OutputNum)
                                        
                    If (ufs_res = UFS_OK) Then
                        UFE30_Enroll.AddMessage ("Extraction process is succeed" & vbCrLf)
                        UFE30_Enroll.btnOK.Enabled = True
                        If (UFE30_Enroll.OutputNum = 1) Then
                            UFE30_Enroll.SetOutputTemplate EnrollTemplate_output, EnrollTemplateSize_output(0), 0
                        ElseIf (UFE30_Enroll.OutputNum = 2) Then
                            UFE30_Enroll.SetOutputTemplate EnrollTemplate_output, EnrollTemplateSize_output(0), 0
                            UFE30_Enroll.SetOutputTemplate EnrollTemplate_output, EnrollTemplateSize_output(1), 1
                        Else
                            UFE30_Enroll.AddMessage ("template output number is not correct" & vbCrLf)
                        End If
                        
                        UFE30_Enroll.btnCancel.Enabled = True
                        UFE30_Enroll.btnOK.Enabled = True

                    Else
                        UFE30_Enroll.AddMessage ("Extraction process is faild" & vbCrLf)
                    End If
                    
                    UFE30_Enroll.pbImageFrame.Refresh
                    EnrollProc = 0
                End If
                
            End If
         Else
            UFS_GetErrorString ufs_res, strError
            UFE30_Enroll.AddMessage ("UFS_Extract: " & strError & vbCrLf)
         End If
    End If
    
    If (UFE30_Enroll.FormEnd = 1) Then
        EnrollProc = 0
        Exit Function
    End If
    
    If (UFE30_Enroll.FormEnd = 0) Then
        UFE30_Enroll.pbImageFrame.Refresh
    End If
    
End Function



