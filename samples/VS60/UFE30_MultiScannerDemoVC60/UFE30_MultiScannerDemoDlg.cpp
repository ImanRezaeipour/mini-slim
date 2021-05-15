// UFE30_MultiScannerDemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "UFE30_MultiScannerDemo.h"
#include "UFE30_MultiScannerDemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CUFE30_MultiScannerDemoDlg dialog

CUFE30_MultiScannerDemoDlg::CUFE30_MultiScannerDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUFE30_MultiScannerDemoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUFE30_MultiScannerDemoDlg)
	m_strScannerID[0] = _T("");
	m_strScannerID[1] = _T("");
	m_strScannerID[2] = _T("");
	m_strScannerID[3] = _T("");
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CUFE30_MultiScannerDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUFE30_MultiScannerDemoDlg)
	DDX_Control(pDX, IDC_IMAGE_FRAME_1, m_ctlImageFrame[0]);
	DDX_Control(pDX, IDC_IMAGE_FRAME_2, m_ctlImageFrame[1]);
	DDX_Control(pDX, IDC_IMAGE_FRAME_3, m_ctlImageFrame[2]);
	DDX_Control(pDX, IDC_IMAGE_FRAME_4, m_ctlImageFrame[3]);
	DDX_Control(pDX, IDC_MESSAGE_EDIT, m_ctlMessageEdit);
	DDX_Text(pDX, IDC_SCANNER_ID_1, m_strScannerID[0]);
	DDX_Text(pDX, IDC_SCANNER_ID_2, m_strScannerID[1]);
	DDX_Text(pDX, IDC_SCANNER_ID_3, m_strScannerID[2]);
	DDX_Text(pDX, IDC_SCANNER_ID_4, m_strScannerID[3]);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CUFE30_MultiScannerDemoDlg, CDialog)
	//{{AFX_MSG_MAP(CUFE30_MultiScannerDemoDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_CLEAR_MESSAGE, OnClearMessage)
	ON_BN_CLICKED(IDC_INIT, OnInit)
	ON_BN_CLICKED(IDC_UNINIT, OnUninit)
	ON_BN_CLICKED(IDC_ENROLL_1, OnEnroll1)
	ON_BN_CLICKED(IDC_ENROLL_2, OnEnroll2)
	ON_BN_CLICKED(IDC_ENROLL_3, OnEnroll3)
	ON_BN_CLICKED(IDC_ENROLL_4, OnEnroll4)
	ON_BN_CLICKED(IDC_IDENTIFY_1, OnIdentify1)
	ON_BN_CLICKED(IDC_IDENTIFY_2, OnIdentify2)
	ON_BN_CLICKED(IDC_IDENTIFY_3, OnIdentify3)
	ON_BN_CLICKED(IDC_IDENTIFY_4, OnIdentify4)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUFE30_MultiScannerDemoDlg message handlers

BOOL CUFE30_MultiScannerDemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	int i, j;
	for (j = 0; j < 4; j++) {
		m_hScanner[j] = NULL;
		m_hMatcher[j] = NULL;

		for (i = 0; i < MAX_TEMPLATE_NUM; i++) {
			m_template[j][i] = (unsigned char*)malloc(MAX_TEMPLATE_SIZE);
			memset(m_template[j][i], 0, MAX_TEMPLATE_SIZE);
			m_template_size[j][i] = 0;
		}
		m_template_num[j] = 0;
	}
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CUFE30_MultiScannerDemoDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	int i, j;
	for (j = 0; j < 4; j++) {
		for (i = 0; i < MAX_TEMPLATE_NUM; i++) {
			free(m_template[j][i]);
		}
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CUFE30_MultiScannerDemoDlg::OnPaint() 
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

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CUFE30_MultiScannerDemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

/////////////////////////////////////////////////////////////////////////////
void CUFE30_MultiScannerDemoDlg::AddMessage(char* szData, ...)
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

void CUFE30_MultiScannerDemoDlg::OnClearMessage() 
{
	m_message.Empty();
	m_ctlMessageEdit.SetWindowText(m_message);
}

void CUFE30_MultiScannerDemoDlg::GetScannerTypeString(int nScannerType, char* strScannerType)
{
	switch (nScannerType) {
	case UFS_SCANNER_TYPE_SFR200:
		sprintf(strScannerType, "SFR200");
		break;
	case UFS_SCANNER_TYPE_SFR300:
		sprintf(strScannerType, "SFR300");
		break;
	case UFS_SCANNER_TYPE_SFR300v2:
		sprintf(strScannerType, "SFR300v2");
		break;
	case UFS_SCANNER_TYPE_SFR500:
		sprintf(strScannerType, "BioMini_Plus");
		break;
	case UFS_SCANNER_TYPE_SFR600:
		sprintf(strScannerType, "BioMini_Slim");
		break;
	default:
		sprintf(strScannerType, "Error");
		break;
	}
}
/////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////
void CUFE30_MultiScannerDemoDlg::OnInit() 
{
	/////////////////////////////////////////////////////////////////////////////
	// Initilize scanners and matchers
	/////////////////////////////////////////////////////////////////////////////
	UFS_STATUS ufs_res;
	UFM_STATUS ufm_res;
	int nScannerNumber;
	int i;

	BeginWaitCursor();
	ufs_res = UFS_Init();
	EndWaitCursor();
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_Init: OK\r\n");
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Init: %s\r\n", m_strError);
		return;
	}

	ufs_res = UFS_GetScannerNumber(&nScannerNumber);
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_GetScannerNumber: %d\r\n", nScannerNumber);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_GetScannerNumber: %s\r\n", m_strError);
	}

	if (nScannerNumber == 0) {
		return;
	}

	for (i = 0; i < nScannerNumber; i++) {
		// Only first 4 scanners will be used
		if (i >= 4) {
			break;
		}

		int nScannerType;
		char strScannerType[64];
		char strID[64];
		char str_tmp[256];

		UFS_GetScannerHandle(i, &m_hScanner[i]);
		UFS_GetScannerType(m_hScanner[i], &nScannerType);
		UFS_GetScannerID(m_hScanner[i], strID);
		GetScannerTypeString(nScannerType, strScannerType);

		sprintf(str_tmp, "%d: %s %s", i, strScannerType, strID);
		m_strScannerID[i].Format("%d: %s %s", i, strScannerType, strID);

		ufm_res = UFM_Create(&m_hMatcher[i]);
		if (ufm_res == UFM_OK) {
			AddMessage("UFM_Create: OK\r\n");
		} else {
			UFM_GetErrorString(ufm_res, m_strError);
			AddMessage("UFM_Create: %s\r\n", m_strError);
			return;
		}

		m_bIsScannerBusy[i] = FALSE;
	}

	UpdateData(FALSE);
	Invalidate(FALSE);
	/////////////////////////////////////////////////////////////////////////////
}

void CUFE30_MultiScannerDemoDlg::OnUninit() 
{
	/////////////////////////////////////////////////////////////////////////////
	// Uninit scanners
	/////////////////////////////////////////////////////////////////////////////
	UFS_STATUS ufs_res;

	BeginWaitCursor();
	ufs_res = UFS_Uninit();
	EndWaitCursor();

	if (ufs_res == UFS_OK) {
		AddMessage("UFS_Uninit: OK\r\n");
		m_strScannerID[0] = "";
		m_strScannerID[1] = "";
		m_strScannerID[2] = "";
		m_strScannerID[3] = "";
		UpdateData(FALSE);
		Invalidate(TRUE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Uninit: %s\r\n", m_strError);
	}
	/////////////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////////////
	// Delete matchers
	/////////////////////////////////////////////////////////////////////////////
	UFM_STATUS ufm_res;
	int i;

	for (i = 0; i < 4; i++) {
		if (m_hMatcher[i] != NULL) {
			ufm_res = UFM_Delete(m_hMatcher[i]);
			if (ufm_res == UFM_OK) {
				AddMessage("UFM_Delete: OK\r\n");
			} else {
				UFM_GetErrorString(ufm_res, m_strError);
				AddMessage("UFM_Delete: %s\r\n", m_strError);
			}
			m_hMatcher[i] = NULL;
		}
	}
	/////////////////////////////////////////////////////////////////////////////	
}

/////////////////////////////////////////////////////////////////////////////	
// Enroll Thread Functions
/////////////////////////////////////////////////////////////////////////////	
typedef struct {
	int nScannerIdx;
	CUFE30_MultiScannerDemoDlg* pDlg;
} EnrollParam;

UINT EnrollThread(LPVOID pParam) {
    EnrollParam* pEnrollParam = (EnrollParam*)pParam;
	int nScannerIdx = pEnrollParam->nScannerIdx;
	CUFE30_MultiScannerDemoDlg* pDlg = pEnrollParam->pDlg;
	UFS_STATUS ufs_res;
	int nEnrollQuality;
	int i;

	pDlg->AddMessage("Scanner %d: Place Finger\r\n", nScannerIdx);

    for (i = 0;; i++) {
		ufs_res = UFS_CaptureSingleImage(pDlg->m_hScanner[nScannerIdx]);
		if (ufs_res != UFS_OK) {
			UFS_GetErrorString(ufs_res, pDlg->m_strError);
			pDlg->AddMessage("Scanner %d: UFS_CaptureSingleImage: %s\r\n", nScannerIdx, pDlg->m_strError);
	        goto errret;
		}

		ufs_res = UFS_ExtractEx(pDlg->m_hScanner[nScannerIdx], MAX_TEMPLATE_SIZE, pDlg->m_template[nScannerIdx][pDlg->m_template_num[nScannerIdx]], &pDlg->m_template_size[nScannerIdx][pDlg->m_template_num[nScannerIdx]], &nEnrollQuality);
		if (ufs_res == UFS_OK) {
			pDlg->AddMessage("Scanner %d: UFS_Extract: OK\r\n", nScannerIdx);
			pDlg->Invalidate(FALSE);

			CRect rect;
			pDlg->m_ctlImageFrame[nScannerIdx].GetClientRect(&rect);
			rect.DeflateRect(1, 1);
			UFS_DrawCaptureImageBuffer(pDlg->m_hScanner[nScannerIdx], pDlg->m_ctlImageFrame[nScannerIdx].GetDC()->m_hDC, rect.left, rect.top, rect.right, rect.bottom, TRUE);

			break;
		} else {
			UFS_GetErrorString(ufs_res, pDlg->m_strError);
			pDlg->AddMessage("Scanner %d: UFS_Extract: %s\r\n", nScannerIdx, pDlg->m_strError);
		}
	}

    if (nEnrollQuality < 2 * 10 + 30 ) {
		pDlg->AddMessage("Scanner %d: Too low quality [Q:%d]\r\n", nScannerIdx, nEnrollQuality);
        goto errret;
    }

	pDlg->AddMessage("Scanner %d: Enrollment success (No.%d) [Q:%d]\r\n", nScannerIdx, pDlg->m_template_num[nScannerIdx]+1, nEnrollQuality);

    if (pDlg->m_template_num[nScannerIdx]+1 == MAX_TEMPLATE_NUM) {
		pDlg->AddMessage("Scanner %d: Template memory is full\r\n", nScannerIdx);
    } else {
		pDlg->m_template_num[nScannerIdx]++;
	}

errret:
	free(pEnrollParam);
	pDlg->m_bIsScannerBusy[nScannerIdx] = FALSE;

	return 1;
}

void CUFE30_MultiScannerDemoDlg::StartEnrollThread(int nScannerIdx)
{
	if (m_bIsScannerBusy[nScannerIdx]) {
		AddMessage("Scanner %d: Scanner is busy\r\n", nScannerIdx);
		return;
	} else {
		AddMessage("Scanner %d: Start enrollment\r\n", nScannerIdx);
	}

	m_bIsScannerBusy[nScannerIdx] = TRUE;

	EnrollParam* pEnrollParam;
	pEnrollParam = (EnrollParam*)malloc(sizeof(EnrollParam));
	pEnrollParam->nScannerIdx = nScannerIdx;
	pEnrollParam->pDlg = this;

	AfxBeginThread(EnrollThread, (LPVOID)pEnrollParam);
}

void CUFE30_MultiScannerDemoDlg::OnEnroll1() 
{
	StartEnrollThread(0);
}

void CUFE30_MultiScannerDemoDlg::OnEnroll2() 
{
	StartEnrollThread(1);
}

void CUFE30_MultiScannerDemoDlg::OnEnroll3() 
{
	StartEnrollThread(2);
}

void CUFE30_MultiScannerDemoDlg::OnEnroll4() 
{
	StartEnrollThread(3);
}
/////////////////////////////////////////////////////////////////////////////	
/////////////////////////////////////////////////////////////////////////////	

/////////////////////////////////////////////////////////////////////////////
// Identify Thread Functions
/////////////////////////////////////////////////////////////////////////////
typedef struct {
	int nScannerIdx;
	CUFE30_MultiScannerDemoDlg* pDlg;
} IdentifyParam;

UINT IdentifyThread(LPVOID pParam) {
    IdentifyParam* pIdentifyParam = (IdentifyParam*)pParam;
	int nScannerIdx = pIdentifyParam->nScannerIdx;
	CUFE30_MultiScannerDemoDlg* pDlg = pIdentifyParam->pDlg;
	UFS_STATUS ufs_res;
	UFM_STATUS ufm_res;
	unsigned char Template[MAX_TEMPLATE_SIZE];
	int TemplateSize;
	int nEnrollQuality;
	int nMatchIndex;
	int i;

	pDlg->AddMessage("Scanner %d: Place Finger\r\n", nScannerIdx);

	UFS_ClearCaptureImageBuffer(pDlg->m_hScanner[nScannerIdx]);

    for (i = 0;; i++) {
		ufs_res = UFS_CaptureSingleImage(pDlg->m_hScanner[nScannerIdx]);
		if (ufs_res != UFS_OK) {
			UFS_GetErrorString(ufs_res, pDlg->m_strError);
			pDlg->AddMessage("Scanner %d: UFS_CaptureSingleImage: %s\r\n", nScannerIdx, pDlg->m_strError);
	        goto errret;
		}

		ufs_res = UFS_ExtractEx(pDlg->m_hScanner[nScannerIdx], MAX_TEMPLATE_SIZE, Template, &TemplateSize, &nEnrollQuality);
		if (ufs_res == UFS_OK) {
			pDlg->AddMessage("Scanner %d: UFS_Extract: OK\r\n", nScannerIdx);
			pDlg->Invalidate(FALSE);

			CRect rect;
			pDlg->m_ctlImageFrame[nScannerIdx].GetClientRect(&rect);
			rect.DeflateRect(1, 1);
			UFS_DrawCaptureImageBuffer(pDlg->m_hScanner[nScannerIdx], pDlg->m_ctlImageFrame[nScannerIdx].GetDC()->m_hDC, rect.left, rect.top, rect.right, rect.bottom, TRUE);

			break;
		} else {
			UFS_GetErrorString(ufs_res, pDlg->m_strError);
			pDlg->AddMessage("Scanner %d: UFS_Extract: %s\r\n", nScannerIdx, pDlg->m_strError);
		}
	}

	ufm_res = UFM_Identify(pDlg->m_hMatcher[nScannerIdx], Template, TemplateSize, pDlg->m_template[nScannerIdx], pDlg->m_template_size[nScannerIdx], pDlg->m_template_num[nScannerIdx], 5000, &nMatchIndex);
	if (ufm_res != UFM_OK) {
		UFM_GetErrorString(ufm_res, pDlg->m_strError);
		pDlg->AddMessage("Scanner %d: UFM_Identify: %s\r\n", nScannerIdx, pDlg->m_strError);
		goto errret;
	}

	if (nMatchIndex != -1) {
        pDlg->AddMessage("Scanner %d: Identification succeed (No.%d)\r\n", nScannerIdx, nMatchIndex+1);
	} else {
		pDlg->AddMessage("Scanner %d: Identification failed\r\n", nScannerIdx);
	}


errret:
	free(pIdentifyParam);
	pDlg->m_bIsScannerBusy[nScannerIdx] = FALSE;

	return 1;
}

void CUFE30_MultiScannerDemoDlg::StartIdentifyThread(int nScannerIdx)
{
	if (m_bIsScannerBusy[nScannerIdx]) {
		AddMessage("Scanner %d: Scanner is busy\r\n", nScannerIdx);
		return;
	} else {
		AddMessage("Scanner %d: Start identification\r\n", nScannerIdx);
	}

	m_bIsScannerBusy[nScannerIdx] = TRUE;

	IdentifyParam* pIdentifyParam;
	pIdentifyParam = (IdentifyParam*)malloc(sizeof(IdentifyParam));
	pIdentifyParam->nScannerIdx = nScannerIdx;
	pIdentifyParam->pDlg = this;

	AfxBeginThread(IdentifyThread, (LPVOID)pIdentifyParam);
}

void CUFE30_MultiScannerDemoDlg::OnIdentify1() 
{
	StartIdentifyThread(0);
}

void CUFE30_MultiScannerDemoDlg::OnIdentify2() 
{
	StartIdentifyThread(1);
}

void CUFE30_MultiScannerDemoDlg::OnIdentify3() 
{
	StartIdentifyThread(2);
}

void CUFE30_MultiScannerDemoDlg::OnIdentify4() 
{
	StartIdentifyThread(3);
}
/////////////////////////////////////////////////////////////////////////////	
/////////////////////////////////////////////////////////////////////////////	

/////////////////////////////////////////////////////////////////////////////
