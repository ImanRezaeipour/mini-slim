// UFE30_EnrollDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ufe30_demo.h"
#include "UFE30_EnrollDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CUFE30_EnrollDlg dialog


CUFE30_EnrollDlg::CUFE30_EnrollDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUFE30_EnrollDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUFE30_EnrollDlg)
	m_strUserID = _T("");
	//}}AFX_DATA_INIT
}


void CUFE30_EnrollDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUFE30_EnrollDlg)
	DDX_Control(pDX, IDC_IMAGE_FRAME, m_ctlImageFrame);
	DDX_Control(pDX, IDC_MESSAGE_EDIT, m_ctlMessageEdit);
	DDX_Text(pDX, IDC_USER_ID, m_strUserID);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CUFE30_EnrollDlg, CDialog)
	//{{AFX_MSG_MAP(CUFE30_EnrollDlg)
	ON_WM_DESTROY()
	ON_WM_PAINT()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUFE30_EnrollDlg message handlers

/////////////////////////////////////////////////////////////////////////////
void CUFE30_EnrollDlg::AddMessage(char* szData, ...)
{
	#define MAX_BUF 1024
	char str_buf[MAX_BUF] = {0};

	va_list pArgList;
	va_start(pArgList, szData);
    _vsntprintf(str_buf, sizeof (str_buf), szData, pArgList);
	va_end(pArgList);

	m_message += str_buf;

	m_ctlMessageEdit.SetWindowText(m_message);
	m_ctlMessageEdit.LineScroll(m_ctlMessageEdit.GetLineCount());
}

int UFS_CALLBACK EnrollProc(HUFScanner hScanner, int bFingerOn, unsigned char* pImage, int nWidth, int nHeight, int nResolution, void* pParam)
{
	CUFE30_EnrollDlg* dlg = (CUFE30_EnrollDlg*)pParam;

	unsigned char Template[MAX_TEMPLATE_SIZE];
	int TemplateSize;
	int nEnrollQuality;
	UFS_STATUS ufs_res;

	if(!dlg->m_try_extract)	{
		if(!bFingerOn) {
			dlg->m_try_extract = TRUE;
			dlg->m_bFingerCheck = FALSE;
			dlg->AddMessage("Place your finger\r\n");
		}
		else {
			if(!dlg->m_bFingerCheck) {
				dlg->AddMessage("Remove your fingerprint from scanner\r\n");
				dlg->m_bFingerCheck = TRUE;
			}
		}

		dlg->Invalidate(FALSE);
		return 1;
	}

	if(bFingerOn && dlg->m_try_extract) {
		ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template, &TemplateSize, &nEnrollQuality);
		if (ufs_res == UFS_OK) {
			if(nEnrollQuality < dlg->m_quality) {
				dlg->AddMessage("Template Quality is too low\r\n");
			}
			else {
				memcpy(dlg->m_EnrollTemplate_input[dlg->m_extract_num], Template, TemplateSize);
				dlg->m_EnrollTemplateSize_input[dlg->m_extract_num] = TemplateSize;
				dlg->AddMessage("UFS_ExtractEx: OK (%d/4)\r\n", ++dlg->m_extract_num);
				dlg->m_try_extract = FALSE;

				if(dlg->m_extract_num == MAX_TEMPLATE_INPUT_NUM) {
					ufs_res = UFS_SelectTemplateEx(hScanner, MAX_TEMPLATE_SIZE, dlg->m_EnrollTemplate_input, dlg->m_EnrollTemplateSize_input, 4, dlg->m_EnrollTemplate_output, dlg->m_EnrollTemplateSize_output, dlg->m_output_num);
					if (ufs_res == UFS_OK) {
						dlg->AddMessage("Extraction process is succeed\r\n");
						if(dlg->m_output_num == 1) {
							memcpy(dlg->m_EnrollTemplate[0], dlg->m_EnrollTemplate_output[0], dlg->m_EnrollTemplateSize_output[0]);
							dlg->m_EnrollTemplateSize[0] = dlg->m_EnrollTemplateSize_output[0];
						} else if (dlg->m_output_num == 2) {
							memcpy(dlg->m_EnrollTemplate[0], dlg->m_EnrollTemplate_output[0], dlg->m_EnrollTemplateSize_output[0]);
							memcpy(dlg->m_EnrollTemplate[1], dlg->m_EnrollTemplate_output[1], dlg->m_EnrollTemplateSize_output[1]);
							dlg->m_EnrollTemplateSize[0] = dlg->m_EnrollTemplateSize_output[0];
							dlg->m_EnrollTemplateSize[1] = dlg->m_EnrollTemplateSize_output[1];
						} else {
							dlg->AddMessage("template output number is not correct\r\n");
						}
					} else {
						dlg->AddMessage("Extraction process is faild\r\n");
					}
					dlg->Invalidate(FALSE);
					return 0;
				}
			}
		} 
		else {
			UFS_GetErrorString(ufs_res, dlg->m_strError);
			dlg->AddMessage("UFS_ExtractEx:%s\r\n", dlg->m_strError);
		}
	}

	// Just redraw the capture buffer image using UFS_DrawCaptureImageBuffer() function in OnPaint()
	dlg->Invalidate(FALSE);
	
	return 1;
}

BOOL CUFE30_EnrollDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// TODO: Add extra initialization here
	int i;
	int value = 0;
	UFS_STATUS ufs_res;
	
	m_extract_num = 0;
	m_try_extract = TRUE;
	m_bFingerCheck = FALSE;

	for (i = 0; i < MAX_TEMPLATE_INPUT_NUM; i++) {
		m_EnrollTemplate_input[i] = (unsigned char*)malloc(MAX_TEMPLATE_SIZE);
		memset(m_EnrollTemplate_input[i], 0, MAX_TEMPLATE_SIZE);
		m_EnrollTemplateSize_input[i] = 0;
	}

	for (i = 0; i < MAX_TEMPLATE_OUTPUT_NUM; i++) {
		m_EnrollTemplate_output[i] = (unsigned char*)malloc(MAX_TEMPLATE_SIZE);
		memset(m_EnrollTemplate_output[i], 0, MAX_TEMPLATE_SIZE);
		m_EnrollTemplateSize_output[i] = 0;
	}

	AddMessage("Advanced Enroll is started. Place your finger\r\n");

	ufs_res = UFS_ClearCaptureImageBuffer(m_hScanner);
	//
	ufs_res = UFS_SetParameter(m_hScanner, UFS_PARAM_TIMEOUT, &value);
	//
	ufs_res = UFS_StartCapturing(m_hScanner, EnrollProc, (void*)this);
	
	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

void CUFE30_EnrollDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	UFS_STATUS ufs_res;
	int pbCapturing;
	int i;

	for (i = 0; i < MAX_TEMPLATE_INPUT_NUM; i++) {
		free(m_EnrollTemplate_input[i]);
	}

	for (i = 0; i < MAX_TEMPLATE_OUTPUT_NUM; i++) {
		free(m_EnrollTemplate_output[i]);
	}


	ufs_res = UFS_AbortCapturing(m_hScanner);

	while(1)
	{
		UFS_IsCapturing(m_hScanner, &pbCapturing);
		if(pbCapturing)
			Sleep(10);
		else
			break;
	}
}

void CUFE30_EnrollDlg::OnPaint() 
{
	if (IsIconic())	
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;
	} 
	else 
	{
		
		CRect rect;
		CDC* pDC = m_ctlImageFrame.GetDC();
		
		m_ctlImageFrame.GetClientRect(&rect);
		rect.DeflateRect(1, 1);
		UFS_DrawCaptureImageBuffer(m_hScanner, pDC->m_hDC, rect.left, rect.top, rect.right, rect.bottom, TRUE);
		
		ReleaseDC(pDC);
		
		CDialog::OnPaint();
	}
}
