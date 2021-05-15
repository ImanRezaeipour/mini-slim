// UFE30_DemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "UFE30_Demo.h"
#include "UFE30_DemoDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


/////////////////////////////////////////////////////////////////////////////
// CUFE30_DemoDlg dialog

CUFE30_DemoDlg::CUFE30_DemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUFE30_DemoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUFE30_DemoDlg)
	m_nBrightness = -1;
	m_nSensitivity = -1;
	m_bDetectCore = FALSE;
	m_nSecurityLevel = 4;
	m_nTimeout = -1;
	m_bFastMode = FALSE;
	m_nEnrollQuality = 1;
	m_nSelectID = -1;
	m_nDetectFake = -1;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CUFE30_DemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUFE30_DemoDlg)
	DDX_Control(pDX, IDC_ID, m_ctlID);
	DDX_Control(pDX, IDC_IMAGE_FRAME, m_ctlImageFrame);
	DDX_Control(pDX, IDC_MESSAGE_EDIT, m_ctlMessageEdit);
	DDX_Control(pDX, IDC_SCANNER_LIST, m_ctlScannerList);
	DDX_Text(pDX, IDC_BRIGHTNESS, m_nBrightness);
	DDV_MinMaxInt(pDX, m_nBrightness, -1, 255);
	DDX_Text(pDX, IDC_SENSITIVITY, m_nSensitivity);
	DDV_MinMaxInt(pDX, m_nSensitivity, -1, 7);
	DDX_Check(pDX, IDC_DETECT_CORE, m_bDetectCore);
	DDX_CBIndex(pDX, IDC_SECURITY_LEVEL, m_nSecurityLevel);
	DDX_CBIndex(pDX, IDC_TIMEOUT, m_nTimeout);
	DDX_Check(pDX, IDC_FAST_MODE, m_bFastMode);
	DDX_CBIndex(pDX, IDC_ENROLL_QUALITY, m_nEnrollQuality);
	DDX_CBIndex(pDX, IDC_ID, m_nSelectID);
	DDX_CBIndex(pDX, IDC_DETECT_FAKE, m_nDetectFake);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CUFE30_DemoDlg, CDialog)
	//{{AFX_MSG_MAP(CUFE30_DemoDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_LBN_SELCHANGE(IDC_SCANNER_LIST, OnSelchangeScannerList)
	ON_CBN_SELCHANGE(IDC_TIMEOUT, OnSelchangeTimeout)
	ON_EN_CHANGE(IDC_BRIGHTNESS, OnChangeBrightness)
	ON_EN_CHANGE(IDC_SENSITIVITY, OnChangeSensitivity)
	ON_BN_CLICKED(IDC_CLEAR_MESSAGE, OnClearMessage)
	ON_BN_CLICKED(IDC_INIT, OnInit)
	ON_BN_CLICKED(IDC_UNINIT, OnUninit)
	ON_BN_CLICKED(IDC_CAPTURE_SINGLE, OnCaptureSingle)
	ON_BN_CLICKED(IDC_EXTRACT, OnExtract)
	ON_BN_CLICKED(IDC_ENROLL, OnEnroll)
	ON_BN_CLICKED(IDC_DETECT_CORE, OnDetectCore)
	ON_CBN_SELCHANGE(IDC_ENROLL_QUALITY, OnSelchangeEnrollQuality)
	ON_BN_CLICKED(IDC_VERIFY, OnVerify)
	ON_CBN_SELCHANGE(IDC_ID, OnSelchangeId)
	ON_BN_CLICKED(IDC_IDENTIFY, OnIdentify)
	ON_CBN_SELCHANGE(IDC_SECURITY_LEVEL, OnSelchangeSecurityLevel)
	ON_BN_CLICKED(IDC_FAST_MODE, OnFastMode)
	ON_BN_CLICKED(IDC_SAVE_TEMPLATE, OnSaveTemplate)
	ON_BN_CLICKED(IDC_SAVE_IMAGE, OnSaveImage)
	ON_BN_CLICKED(IDC_START_CAPTURING, OnStartCapturing)
	ON_BN_CLICKED(IDC_ABORT_CAPTURING, OnAbortCapturing)
	ON_BN_CLICKED(IDC_UPDATE, OnUpdate)
	ON_MESSAGE(WM_UPDATE_SCANNER_LIST, OnUpdateScannerList)
	ON_WM_TIMER()
	ON_CBN_SELCHANGE(IDC_DETECT_FAKE, OnSelchangeDetectFake)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUFE30_DemoDlg message handlers

BOOL CUFE30_DemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	int i;
	for (i = 0; i < MAX_TEMPLATE_NUM; i++) {
		m_template[i] = (unsigned char*)malloc(MAX_TEMPLATE_SIZE);
		memset(m_template[i], 0, MAX_TEMPLATE_SIZE);
		m_template_size[i] = 0;
	}
	m_template_num = 0;

	m_hMatcher = NULL;

//	SetTimer(1, 2000, 0);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CUFE30_DemoDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	OnUninit();

	int i;
	for (i = 0; i < MAX_TEMPLATE_NUM; i++) {
		free(m_template[i]);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CUFE30_DemoDlg::OnPaint() 
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
		HUFScanner hScanner;
		if (GetCurrentScannerHandle(&hScanner)) {
			CRect rect;
			CDC* pDC = m_ctlImageFrame.GetDC();

			m_ctlImageFrame.GetClientRect(&rect);
		    rect.DeflateRect(1, 1);
			int nScannerType;
			UFS_GetScannerType(hScanner, &nScannerType);
			UFS_DrawCaptureImageBuffer(hScanner, pDC->m_hDC, rect.left, rect.top, rect.right, rect.bottom, TRUE);			

			ReleaseDC(pDC);
		}

		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CUFE30_DemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}


/////////////////////////////////////////////////////////////////////////////
void CUFE30_DemoDlg::AddMessage(char* szData, ...)
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

void CUFE30_DemoDlg::OnClearMessage() 
{
	m_message.Empty();
	m_ctlMessageEdit.SetWindowText(m_message);
}

void CUFE30_DemoDlg::GetScannerTypeString(int nScannerType, char* strScannerType)
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
		sprintf(strScannerType, "BioMini Plus");
		break;
	case UFS_SCANNER_TYPE_SFR600:
		sprintf(strScannerType, "BioMini Slim");
		break;
	default:
		sprintf(strScannerType, "Error");
		break;
	}
}

BOOL CUFE30_DemoDlg::GetCurrentScannerHandle(HUFScanner* phScanner)
{
	int nCurScannerIndex;
	UFS_STATUS ufs_res;

	nCurScannerIndex = m_ctlScannerList.GetCurSel();
	ufs_res = UFS_GetScannerHandle(nCurScannerIndex, phScanner);
	if (ufs_res == UFS_OK) {
		return TRUE;
	} else {
		return FALSE;
	}
}

void CUFE30_DemoDlg::GetCurrentScannerSettings()
{
	HUFScanner hScanner;
	int value;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}

	// Unit of timeout is millisecond
	UFS_GetParameter(hScanner, UFS_PARAM_TIMEOUT, &value);
	m_nTimeout = value / 1000;
    ((CComboBox*)GetDlgItem(IDC_TIMEOUT))->SetCurSel(m_nTimeout);

	UFS_GetParameter(hScanner, UFS_PARAM_BRIGHTNESS, &value);
    m_nBrightness = value;
    ((CSpinButtonCtrl*)GetDlgItem(IDC_BRIGHTNESS_SPIN))->SetRange(0, 255);

	UFS_GetParameter(hScanner, UFS_PARAM_SENSITIVITY, &value);
    m_nSensitivity = value;
    ((CSpinButtonCtrl*)GetDlgItem(IDC_SENSITIVITY_SPIN))->SetRange(0, 7);

	UFS_GetParameter(hScanner, UFS_PARAM_DETECT_CORE, &value);
	m_bDetectCore = value;

	UFS_GetParameter(hScanner, UFS_PARAM_DETECT_FAKE, &value);
	m_nDetectFake = value;

	// Default setting for LFD
	value = 15000;
	UFS_SetParameter(hScanner, UFS_PARAM_TIMEOUT, &value);
	m_nTimeout = value / 1000;

    m_nSensitivity = 7;
	UFS_SetParameter(hScanner, UFS_PARAM_SENSITIVITY, &m_nSensitivity);

	m_nDetectFake = 3;
	UFS_SetParameter(hScanner, UFS_PARAM_DETECT_FAKE, &m_nDetectFake);
	
	UpdateData(FALSE);
}

void CUFE30_DemoDlg::GetMatcherSettings(HUFMatcher hMatcher)
{
	int value;

	// Security level ranges from 1 to 7
	UFM_GetParameter(hMatcher, UFM_PARAM_SECURITY_LEVEL, &value);
	m_nSecurityLevel = value - 1;

	UFM_GetParameter(hMatcher, UFM_PARAM_FAST_MODE, &value);
	m_bFastMode = value;

	UpdateData(FALSE);
}

void CUFE30_DemoDlg::OnSelchangeScannerList() 
{
	GetCurrentScannerSettings();
}

void CUFE30_DemoDlg::OnSelchangeTimeout() 
{
    if (m_nTimeout == -1) {
		return;
	}

	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	int value;

    UpdateData(TRUE);

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	// Unit of timeout is millisecond
    value = m_nTimeout * 1000;
	ufs_res = UFS_SetParameter(hScanner, UFS_PARAM_TIMEOUT, &value);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_SetParameter(UFS_PARAM_TIMEOUT): %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnChangeBrightness() 
{
    if (m_nBrightness == -1) {
		return;
	}

	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	int value;

    UpdateData(TRUE);

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
    value = m_nBrightness;
	ufs_res = UFS_SetParameter(hScanner, UFS_PARAM_BRIGHTNESS, &value);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_SetParameter(UFS_PARAM_BRIGHTNESS): %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnChangeSensitivity() 
{
    if (m_nSensitivity == -1) {
		return;
	}

	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	int value;

    UpdateData(TRUE);

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
    value = m_nSensitivity;
	ufs_res = UFS_SetParameter(hScanner, UFS_PARAM_SENSITIVITY, &value);
	if (ufs_res != UFS_OK) {
		AddMessage("UFS_SetParameter(UFS_PARAM_SENSITIVITY): UFS_ERROR\r\n");
	}	
}

void CUFE30_DemoDlg::OnDetectCore() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	int value;

    UpdateData(TRUE);

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	value = m_bDetectCore;
	ufs_res = UFS_SetParameter(hScanner, UFS_PARAM_DETECT_CORE, &value);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_SetParameter(UFS_PARAM_DETECT_CORE): %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnSelchangeEnrollQuality() 
{
    UpdateData(TRUE);
}

void CUFE30_DemoDlg::OnSelchangeId() 
{
    UpdateData(TRUE);
}

void CUFE30_DemoDlg::OnSelchangeSecurityLevel() 
{
	UFM_STATUS ufm_res;
	int value;

    UpdateData(TRUE);

	// Security level ranges from 1 to 7
	value = m_nSecurityLevel + 1;
	ufm_res = UFM_SetParameter(m_hMatcher, UFM_PARAM_SECURITY_LEVEL, &value);
	if (ufm_res != UFM_OK) {
		UFM_GetErrorString(ufm_res, m_strError);
		AddMessage("UFM_SetParameter(UFM_PARAM_SECURITY_LEVEL): %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnFastMode() 
{
	UFM_STATUS ufm_res;
	int value;

    UpdateData(TRUE);

	value = m_bFastMode;
	ufm_res = UFM_SetParameter(m_hMatcher, UFM_PARAM_FAST_MODE, &value);
	if (ufm_res != UFM_OK) {
		UFM_GetErrorString(ufm_res, m_strError);
		AddMessage("UFM_SetParameter(UFM_PARAM_FAST_MODE): %s\r\n", m_strError);
	}	
}
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////////////
void CUFE30_DemoDlg::UpdateScannerList()
{
	UFS_STATUS ufs_res;
	int nScannerNumber;
	int i;

	ufs_res = UFS_GetScannerNumber(&nScannerNumber);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_GetScannerNumber: %s\r\n", m_strError);
		return;
	}

	m_ctlScannerList.ResetContent();

	for (i = 0; i < nScannerNumber; i++) {
		HUFScanner hScanner;
		int nScannerType;
		char strScannerType[64];
		char strID[64];
		char str_tmp[256];

		ufs_res = UFS_GetScannerHandle(i, &hScanner);
		if (ufs_res != UFS_OK) {
			continue;
		}
		UFS_GetScannerType(hScanner, &nScannerType);
		UFS_GetScannerID(hScanner, strID);
		GetScannerTypeString(nScannerType, strScannerType);

		sprintf(str_tmp, "%d: %s %s", i, strScannerType, strID);
		m_ctlScannerList.InsertString(i, str_tmp);

		// Adjust list box width
		{
			CDC* pDC = m_ctlScannerList.GetDC();
			CSize sz = pDC->GetTextExtent(str_tmp);
			if (sz.cx > m_ctlScannerList.GetHorizontalExtent()) {
				m_ctlScannerList.ReleaseDC(pDC);
				m_ctlScannerList.SetHorizontalExtent(sz.cx);
			} else {
				m_ctlScannerList.ReleaseDC(pDC);
			}
		}
	}

	if (nScannerNumber > 0) {
		m_ctlScannerList.SetCurSel(0);
		GetCurrentScannerSettings();
	}

	Invalidate(TRUE);
}

LRESULT CUFE30_DemoDlg::OnUpdateScannerList(WPARAM wParam, LPARAM lParam)
{
	UpdateScannerList();

	return 0;
}

int UFS_CALLBACK ScannerProc(const char* szScannerID, int bSensorOn, void* pParam)
{
	CUFE30_DemoDlg* pDlg = (CUFE30_DemoDlg*)pParam;

	if (bSensorOn) {
		// We cannot call UpdateData() directly from the different thread,
		// so we use PostMessage() to call UpdateScannerList() indirectly
		pDlg->PostMessage(WM_UPDATE_SCANNER_LIST, FALSE);
	} else {
		pDlg->PostMessage(WM_UPDATE_SCANNER_LIST, FALSE);
	}

	return 1;
}

void CUFE30_DemoDlg::OnInit() 
{
	/////////////////////////////////////////////////////////////////////////////
	// Initilize scanner module and get scanner list
	/////////////////////////////////////////////////////////////////////////////
	UFS_STATUS ufs_res;
	int nScannerNumber;

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

	ufs_res = UFS_SetScannerCallback(ScannerProc, (void*)this);
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_SetScannerCallback: OK\r\n");
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_SetScannerCallback: %s\r\n", m_strError);
		return;
	}

	ufs_res = UFS_GetScannerNumber(&nScannerNumber);
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_GetScannerNumber: %d\r\n", nScannerNumber);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_GetScannerNumber: %s\r\n", m_strError);
		return;
	}

	UpdateScannerList();

	Invalidate(TRUE);
	/////////////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////////////
	// Create one matcher
	/////////////////////////////////////////////////////////////////////////////
	UFM_STATUS ufm_res;

	ufm_res = UFM_Create(&m_hMatcher);
	if (ufm_res == UFM_OK) {
		AddMessage("UFM_Create: OK\r\n");
	} else {
		UFM_GetErrorString(ufm_res, m_strError);
		AddMessage("UFM_Create: %s\r\n", m_strError);
		return;
	}

	GetMatcherSettings(m_hMatcher);
	/////////////////////////////////////////////////////////////////////////////
}

void CUFE30_DemoDlg::OnUpdate() 
{
	UFS_STATUS ufs_res;

	BeginWaitCursor();
	ufs_res = UFS_Update();
	EndWaitCursor();

	if (ufs_res == UFS_OK) {
		AddMessage("UFS_Update: OK\r\n");
		UpdateScannerList();
		Invalidate(TRUE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Update: %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnUninit() 
{
	/////////////////////////////////////////////////////////////////////////////
	// Uninit scanner module
	/////////////////////////////////////////////////////////////////////////////
	UFS_STATUS ufs_res;

	BeginWaitCursor();
	ufs_res = UFS_Uninit();
	EndWaitCursor();

	if (ufs_res == UFS_OK) {
		AddMessage("UFS_Uninit: OK\r\n");
		m_ctlScannerList.ResetContent();
		Invalidate(TRUE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Uninit: %s\r\n", m_strError);
	}
	/////////////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////////////
	// Delete matcher
	/////////////////////////////////////////////////////////////////////////////
	if (m_hMatcher != NULL) {
		UFM_STATUS ufm_res;

		ufm_res = UFM_Delete(m_hMatcher);
		if (ufm_res == UFM_OK) {
			AddMessage("UFM_Delete: OK\r\n");
		} else {
			UFM_GetErrorString(ufm_res, m_strError);
			AddMessage("UFM_Delete: %s\r\n", m_strError);
		}
		m_hMatcher = NULL;
	}
	/////////////////////////////////////////////////////////////////////////////
}

int UFS_CALLBACK CaptureProc(HUFScanner hScanner, int bFingerOn, unsigned char* pImage, int nWidth, int nHeight, int nResolution, void* pParam)
{
	CUFE30_DemoDlg* dlg = (CUFE30_DemoDlg*)pParam;
	
	// Just redraw the capture buffer image using UFS_DrawCaptureImageBuffer() function in OnPaint()
	dlg->Invalidate(FALSE);
	
	// Test code: for checking fps
	dlg->m_frame_num++;

	return 1;
}

void CUFE30_DemoDlg::OnStartCapturing() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}

	// Test code: for checking fps
	m_frame_num = 0;

	ufs_res = UFS_StartCapturing(hScanner, CaptureProc, (void*)this);
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_StartCapturing: OK\r\n");
		Invalidate(FALSE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_StartCapturing: %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnAbortCapturing() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}

	ufs_res = UFS_AbortCapturing(hScanner);
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_AbortCapturing: OK\r\n");
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_AbortCapturing: %s\r\n", m_strError);
	}

	// Test code: for checking fps
	AddMessage("Current frame num: %d\r\n", m_frame_num);
}

void CUFE30_DemoDlg::OnCaptureSingle() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}

	AddMessage("Place a Finger\r\n");

	BeginWaitCursor();
	ufs_res = UFS_CaptureSingleImage(hScanner);
	EndWaitCursor();

	if (ufs_res == UFS_OK) {
		AddMessage("UFS_CaptureSingleImage: OK\r\n");
		Invalidate(FALSE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_CaptureSingleImage: %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnExtract() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	int value;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	value = MAX_TEMPLATE_SIZE;
	UFS_SetParameter(hScanner, UFS_PARAM_TEMPLATE_SIZE, &value);
	value = m_bDetectCore;
	UFS_SetParameter(hScanner, UFS_PARAM_DETECT_CORE, &value);

	unsigned char Template[MAX_TEMPLATE_SIZE];
	int TemplateSize;
	int nEnrollQuality;

	BeginWaitCursor();
	ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template, &TemplateSize, &nEnrollQuality);
	EndWaitCursor();

	if (ufs_res == UFS_OK) {
		AddMessage("UFS_Extract: OK\r\n");
		Invalidate(FALSE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Extract: %s\r\n", m_strError);
	}	
}

void CUFE30_DemoDlg::OnEnroll() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	int nEnrollQuality;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	UFS_ClearCaptureImageBuffer(hScanner);

	AddMessage("Place a finger\r\n");

    while (TRUE) {
		ufs_res = UFS_CaptureSingleImage(hScanner);
		if (ufs_res != UFS_OK) {
			UFS_GetErrorString(ufs_res, m_strError);
			AddMessage("UFS_CaptureSingleImage: %s\r\n", m_strError);
			return;
		}

		ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, m_template[m_template_num], &m_template_size[m_template_num], &nEnrollQuality);
		if (ufs_res == UFS_OK) {
			AddMessage("UFS_Extract: OK\r\n");
			Invalidate(FALSE);
			break;
		} else {
			UFS_GetErrorString(ufs_res, m_strError);
			AddMessage("UFS_Extract: %s\r\n", m_strError);
		}
	}

    if (nEnrollQuality < m_nEnrollQuality * 10 + 30 ) {
		AddMessage("Too low quality [Q:%d]\r\n", nEnrollQuality);
        return;
    }

	AddMessage("Enrollment success (No.%d) [Q:%d]\r\n", m_template_num+1, nEnrollQuality);

	/*
	// Check encrypt / decrypt function
	{
		UFS_STATUS ufs_res;
	    unsigned char Tmp1[MAX_TEMPLATE_SIZE];
	    unsigned char Tmp2[MAX_TEMPLATE_SIZE];
		int Tmp1Size;
		int Tmp2Size;
		Tmp1Size = MAX_TEMPLATE_SIZE;
		Tmp2Size = MAX_TEMPLATE_SIZE;
		ufs_res = UFS_EncryptTemplate(hScanner, m_template[m_template_num], m_template_size[m_template_num], Tmp1, &Tmp1Size);
		if (ufs_res != UFS_OK) {
			UFS_GetErrorString(ufs_res, m_strError);
			AddMessage("UFS_EncryptTemplate: %s\r\n", m_strError);
		}
		ufs_res = UFS_DecryptTemplate(hScanner, Tmp1, Tmp1Size, Tmp2, &Tmp2Size);
		if (ufs_res != UFS_OK) {
			UFS_GetErrorString(ufs_res, m_strError);
			AddMessage("UFS_DecryptTemplate: %s\r\n", m_strError);
		}
		int i;
		for (i = 0; i < Tmp1Size; i++) {
			if (m_template[m_template_num][i] != Tmp2[i]) {
				TRACE("unmatch: %d\r\n", i);
			}
		}
	}*/

	{
		CString str;
		str.Format("%d", m_template_num+1);
		m_ctlID.AddString(str);
	}
    if (m_template_num+1 == MAX_TEMPLATE_NUM) {
		AddMessage("Template memory is full\r\n");
    } else {
		m_template_num++;
	}
}

void CUFE30_DemoDlg::OnVerify() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	UFM_STATUS ufm_res;
	unsigned char Template[MAX_TEMPLATE_SIZE];
	int TemplateSize;
	int nEnrollQuality;
	int bVerifySucceed;

	if (m_nSelectID == -1) {
		AddMessage("Select Enroll ID\r\n");
		return;
	}

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	UFS_ClearCaptureImageBuffer(hScanner);

    AddMessage("Place a finger\r\n");

	ufs_res = UFS_CaptureSingleImage(hScanner);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_CaptureSingleImage: %s\r\n", m_strError);
		return;
	}

	ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template, &TemplateSize, &nEnrollQuality);
	if (ufs_res == UFS_OK) {
		Invalidate(FALSE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Extract: %s\r\n", m_strError);
		return;
	}

	ufm_res = UFM_Verify(m_hMatcher, Template, TemplateSize, m_template[m_nSelectID], m_template_size[m_nSelectID], &bVerifySucceed);
	if (ufm_res != UFM_OK) {
		UFM_GetErrorString(ufm_res, m_strError);
		AddMessage("UFM_Verify: %s\r\n", m_strError);
		return;
	}

	if (bVerifySucceed) {
        AddMessage("Verification succeed (No.%d)\r\n", m_nSelectID+1);
	} else {
		AddMessage("Verification failed\r\n");
	}
}

void CUFE30_DemoDlg::OnIdentify() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;
	UFM_STATUS ufm_res;
	unsigned char Template[MAX_TEMPLATE_SIZE];
	int TemplateSize;
	int nEnrollQuality;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	UFS_ClearCaptureImageBuffer(hScanner);

    AddMessage("Place a finger\r\n");

	ufs_res = UFS_CaptureSingleImage(hScanner);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_CaptureSingleImage: %s\r\n", m_strError);
		return;
	}

	ufs_res = UFS_ExtractEx(hScanner, MAX_TEMPLATE_SIZE, Template, &TemplateSize, &nEnrollQuality);
	if (ufs_res == UFS_OK) {
		Invalidate(FALSE);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Extract: %s\r\n", m_strError);
		return;
	}

	//*
	// Using UFM_Identify
	{
		int nMatchIndex;

		BeginWaitCursor();
		ufm_res = UFM_Identify(m_hMatcher, Template, TemplateSize, m_template, m_template_size, m_template_num, 5000, &nMatchIndex);
		//ufm_res = UFM_IdentifyMT(m_hMatcher, Template, TemplateSize, m_template, m_template_size, m_template_num, 5000, &nMatchIndex);
		EndWaitCursor();
		if (ufm_res != UFM_OK) {
			UFM_GetErrorString(ufm_res, m_strError);
			AddMessage("UFM_Identify: %s\r\n", m_strError);
			return;
		}

		if (nMatchIndex != -1) {
			AddMessage("Identification succeed (No.%d)\r\n", nMatchIndex+1);
		} else {
			AddMessage("Identification failed\r\n");
		}
	}
	/*/
	// Using UFM_IdentifyInit and UFM_IdentifyNext
	{
		int i;

		ufm_res = UFM_IdentifyInit(m_hMatcher, Template, TemplateSize);
		if (ufm_res != UFM_OK) {
			UFM_GetErrorString(ufm_res, m_strError);
			AddMessage("UFM_IdentifyInit: %s\r\n", m_strError);
			return;
		}
		for (i = 0; i < m_template_num; i++) {
			int bIdentifySucceed;
			ufm_res = UFM_IdentifyNext(m_hMatcher, m_template[i], m_template_size[i], &bIdentifySucceed);
			if (ufm_res != UFM_OK) {
				UFM_GetErrorString(ufm_res, m_strError);
				AddMessage("UFM_IdentifyNext: %s\r\n", m_strError);
				return;
			}
			if (bIdentifySucceed) {
				AddMessage("Identification succeed (No.%d)\r\n", i+1);
				break;
			}
		}
		if (i == m_template_num) {
			AddMessage("Identification failed\r\n");
		}
	}
	//*/
}

void CUFE30_DemoDlg::OnSaveTemplate() 
{
	if (m_nSelectID == -1) {
		AddMessage("Select Enroll ID\r\n");
		return;
	}

	CFileDialog dlg(FALSE, "tmp", NULL, NULL, "Template Files (*.tmp)|*.tmp");
	if (dlg.DoModal() != IDOK) {
		return;
	}

	FILE* fp;
	fp = fopen(dlg.GetPathName(), "wb");
	if (fp == NULL) {
		return;
	}
	fwrite(m_template[m_nSelectID], 1, m_template_size[m_nSelectID], fp);
	fclose(fp);

	AddMessage("Selected template is saved\r\n");
}

void CUFE30_DemoDlg::OnSaveImage() 
{
	CFileDialog dlg(FALSE, "bmp", NULL, NULL, "Bitmap Files (*.bmp)|*.bmp");
	if (dlg.DoModal() != IDOK) {
		return;
	}

	HUFScanner hScanner;
	UFS_STATUS ufs_res;

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	ufs_res = UFS_SaveCaptureImageBufferToBMP(hScanner, (char*)(LPCTSTR)dlg.GetPathName());
	if (ufs_res == UFS_OK) {
		AddMessage("Captured image is saved\r\n");
	}
}


void CUFE30_DemoDlg::OnSelchangeDetectFake() 
{
	HUFScanner hScanner;
	UFS_STATUS ufs_res;

    UpdateData(TRUE);

	if (!GetCurrentScannerHandle(&hScanner)) {
		return;
	}
	ufs_res = UFS_SetParameter(hScanner, UFS_PARAM_DETECT_FAKE, &m_nDetectFake);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_SetParameter(UFS_PARAM_DETECT_CORE): %s\r\n", m_strError);
	}
}
