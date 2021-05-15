// UFE30_DatabaseDemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "UFE30_DatabaseDemo.h"
#include "UFE30_DatabaseDemoDlg.h"
//
#include "UserInfoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CUFE30_DatabaseDemoDlg dialog

CUFE30_DatabaseDemoDlg::CUFE30_DatabaseDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUFE30_DatabaseDemoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUFE30_DatabaseDemoDlg)
	m_nType = 0;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CUFE30_DatabaseDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUFE30_DatabaseDemoDlg)
	DDX_Control(pDX, IDC_IMAGE_FRAME, m_ctlImageFrame);
	DDX_Control(pDX, IDC_TYPE, m_ctlType);
	DDX_Control(pDX, IDC_DATABASE_LIST, m_ctlDatabaseList);
	DDX_Control(pDX, IDC_MESSAGE_EDIT, m_ctlMessageEdit);
	DDX_CBIndex(pDX, IDC_TYPE, m_nType);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CUFE30_DatabaseDemoDlg, CDialog)
	//{{AFX_MSG_MAP(CUFE30_DatabaseDemoDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_CLEAR_MESSAGE, OnClearMessage)
	ON_BN_CLICKED(IDC_INIT, OnInit)
	ON_BN_CLICKED(IDC_UNINIT, OnUninit)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_ENROLL, OnEnroll)
	ON_BN_CLICKED(IDC_DELETE_ALL, OnDeleteAll)
	ON_BN_CLICKED(IDC_SELECTION_DELETE, OnSelectionDelete)
	ON_BN_CLICKED(IDC_SELECTION_UPDATE_USERINFO, OnSelectionUpdateUserinfo)
	ON_BN_CLICKED(IDC_SELECTION_UPDATE_TEMPLATE, OnSelectionUpdateTemplate)
	ON_BN_CLICKED(IDC_SELECTION_VERIFY, OnSelectionVerify)
	ON_BN_CLICKED(IDC_IDENTIFY, OnIdentify)
	ON_WM_SHOWWINDOW()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUFE30_DatabaseDemoDlg message handlers

BOOL CUFE30_DatabaseDemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	//
	m_hScanner = NULL;
	m_hMatcher = NULL;
	m_hDatabase = NULL;

	m_ctlDatabaseList.SetExtendedStyle(m_ctlDatabaseList.GetExtendedStyle()|LVS_EX_FULLROWSELECT|LVS_EX_GRIDLINES);
	m_ctlDatabaseList.InsertColumn(DATABASE_COL_SERIAL,			"Serial",		LVCFMT_LEFT, 50);
	m_ctlDatabaseList.InsertColumn(DATABASE_COL_USERID,			"UserID",		LVCFMT_LEFT, 60);
	m_ctlDatabaseList.InsertColumn(DATABASE_COL_FINGERINDEX,	"FingerIndex",	LVCFMT_LEFT, 80);
	m_ctlDatabaseList.InsertColumn(DATABASE_COL_TEMPLATE1,		"Template1",	LVCFMT_LEFT, 80);
	m_ctlDatabaseList.InsertColumn(DATABASE_COL_TEMPLATE2,		"Template2",	LVCFMT_LEFT, 80);
	m_ctlDatabaseList.InsertColumn(DATABASE_COL_MEMO,			"Memo",			LVCFMT_LEFT, 60);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CUFE30_DatabaseDemoDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	OnUninit();
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CUFE30_DatabaseDemoDlg::OnPaint() 
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
		//dltpdlssdfljewfjpsdjf;sdjf;sldkf;sdkf;sdlfsdfjuwefnlsbxicbuxklsdf u32n4sdfsdfsdfsdfrtdkfgj
		//LSI 100514
		if (m_hScanner) {
			CRect rect;
			CDC* pDC = m_ctlImageFrame.GetDC();

			m_ctlImageFrame.GetClientRect(&rect);
		    rect.DeflateRect(1, 1);
			UFS_DrawCaptureImageBuffer(m_hScanner, pDC->m_hDC, rect.left, rect.top, rect.right, rect.bottom, TRUE);

			ReleaseDC(pDC);
		}

		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CUFE30_DatabaseDemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}


/////////////////////////////////////////////////////////////////////////////
void CUFE30_DatabaseDemoDlg::AddMessage(char* szData, ...)
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

void CUFE30_DatabaseDemoDlg::OnClearMessage() 
{
	m_message.Empty();
	m_ctlMessageEdit.SetWindowText(m_message);	
}

void CUFE30_DatabaseDemoDlg::AddRow(int nSerial, char* szUserID, int nFingerIndex, BOOL bTemplate1, BOOL bTemplate2, char* szMemo)
{
	int nIndex;
	char str_tmp[256];
	
	sprintf(str_tmp, "%d", nSerial);
	nIndex = m_ctlDatabaseList.InsertItem(m_ctlDatabaseList.GetItemCount(), str_tmp);
	m_ctlDatabaseList.SetItemText(nIndex, 1, szUserID);
	sprintf(str_tmp, "%d", nFingerIndex);
	m_ctlDatabaseList.SetItemText(nIndex, 2, str_tmp);
	m_ctlDatabaseList.SetItemText(nIndex, 3, (bTemplate1) ? "O" : "X");
	m_ctlDatabaseList.SetItemText(nIndex, 4, (bTemplate2) ? "O" : "X");
	m_ctlDatabaseList.SetItemText(nIndex, 5, szMemo);
}

void CUFE30_DatabaseDemoDlg::UpdateDatabaseList()
{
	if (m_hDatabase == NULL) {
		return;
	}

	UFD_STATUS ufd_res;
	int nDataNumber;
	int i;

	ufd_res = UFD_GetDataNumber(m_hDatabase, &nDataNumber); 
	if (ufd_res == UFD_OK) {
		AddMessage("UFD_GetDataNumber: %d\r\n", nDataNumber);
	} else {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_GetDataNumber: %s\r\n", m_strError);
		return;
	}

	m_ctlDatabaseList.DeleteAllItems();

	for (i = 0; i < nDataNumber; i++) {
		ufd_res = UFD_GetDataByIndex(m_hDatabase, i,
			&m_nSerial, m_szUserID, &m_nFingerIndex, m_Template1, &m_nTemplate1Size, m_Template2, &m_nTemplate2Size, m_szMemo);
		if (ufd_res != UFD_OK) {
			UFD_GetErrorString(ufd_res, m_strError);
			AddMessage("UFD_GetDataByIndex: %s\r\n", m_strError);
			return;
		}

		AddRow(m_nSerial, m_szUserID, m_nFingerIndex, (m_nTemplate1Size != 0), (m_nTemplate2Size != 0), m_szMemo);
	}
}
/////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////
void CUFE30_DatabaseDemoDlg::OnInit() 
{
	/////////////////////////////////////////////////////////////////////////////
	// Initilize scanner module
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

	ufs_res = UFS_GetScannerNumber(&nScannerNumber);
	if (ufs_res == UFS_OK) {
		AddMessage("UFS_GetScannerNumber: %d\r\n", nScannerNumber);
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_GetScannerNumber: %s\r\n", m_strError);
		return;
	}

	if (nScannerNumber == 0) {
		AddMessage("There's no available scanner\r\n");
		return;
	} else {
		AddMessage("First scanner will be used\r\n");
	}

	ufs_res = UFS_GetScannerHandle(0, &m_hScanner);
	if (ufs_res != UFS_OK) {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_GetScannerHandle: %s\r\n", m_strError);
		return;
	}
	/////////////////////////////////////////////////////////////////////////////
	
	/////////////////////////////////////////////////////////////////////////////
	// Open database
	/////////////////////////////////////////////////////////////////////////////
	UFD_STATUS ufd_res;

	// Generate connection string
	CString szDataSource;
	CString szConnection;
	/*
	szDataSource = "UFDatabase.mdb";
	/*/
	AddMessage("Select a database file\r\n");
	szDataSource = "UFDatabase.mdb";
	CFileDialog dlg(FALSE, "mdb", szDataSource, NULL, "Database Files (*.mdb)|*.mdb");
	if (dlg.DoModal() != IDOK) {
		AddMessage("DB selection is cancelled by user\r\n");
		return;
	}
	szDataSource = dlg.GetPathName();
	//*/
	szConnection.Format(TEXT("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%s;"), szDataSource);

	ufd_res = UFD_Open(szConnection, NULL, NULL, &m_hDatabase);
	if (ufd_res == UFD_OK) {
		AddMessage("UFD_Open: OK\r\n");
	} else {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_Open: %s\r\n", m_strError);
		return;
	}

	UpdateDatabaseList();
	/////////////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////////////
	// Create matcher
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
	/////////////////////////////////////////////////////////////////////////////
}

void CUFE30_DatabaseDemoDlg::OnUninit() 
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
	} else {
		UFS_GetErrorString(ufs_res, m_strError);
		AddMessage("UFS_Uninit: %s\r\n", m_strError);
	}

	m_hScanner = NULL;
	/////////////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////////////
	// Close database
	/////////////////////////////////////////////////////////////////////////////
	UFD_STATUS ufd_res;

	if (m_hDatabase != NULL) {
		ufd_res = UFD_Close(m_hDatabase);
		if (ufd_res == UFD_OK) {
			AddMessage("UFD_Close: OK\r\n");
		} else {
			UFD_GetErrorString(ufd_res, m_strError);
			AddMessage("UFD_Close: %s\r\n", m_strError);
		}
		m_hDatabase = NULL;
	}

	m_ctlDatabaseList.DeleteAllItems();
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

BOOL CUFE30_DatabaseDemoDlg::ExtractTemplate(unsigned char* pTemplate, int* pnTemplateSize)
{
	UFS_STATUS ufs_res;
	int nEnrollQuality;

	UFS_ClearCaptureImageBuffer(m_hScanner);

	AddMessage("Place a finger\r\n");

    while (TRUE) {
		ufs_res = UFS_CaptureSingleImage(m_hScanner);
		if (ufs_res != UFS_OK) {
			UFS_GetErrorString(ufs_res, m_strError);
			AddMessage("UFS_CaptureSingleImage: %s\r\n", m_strError);
			return FALSE;
		}

		ufs_res = UFS_ExtractEx(m_hScanner, MAX_TEMPLATE_SIZE, pTemplate, pnTemplateSize, &nEnrollQuality);
		if (ufs_res == UFS_OK) {
			AddMessage("UFS_Extract: OK\r\n");
			break;
		} else {
			UFS_GetErrorString(ufs_res, m_strError);
			AddMessage("UFS_Extract: %s\r\n", m_strError);
		}
	}

	return TRUE;
}

void CUFE30_DatabaseDemoDlg::OnEnroll() 
{
	switch (m_nType) {
	case 0:
		UFS_SetTemplateType(m_hScanner, UFS_TEMPLATE_TYPE_SUPREMA);
		AddMessage("Current scanner,UFS_SetTemplateType: SUPREMA TYPE \r\n");
		break;
	case 1:
		UFS_SetTemplateType(m_hScanner, UFS_TEMPLATE_TYPE_ISO19794_2);
		AddMessage("Current scanner,UFS_SetTemplateType: ISO_19794_2 TYPE \r\n");
		break;
	case 2:
		UFS_SetTemplateType(m_hScanner, UFS_TEMPLATE_TYPE_ANSI378);
		AddMessage("Current scanner,UFS_SetTemplateType: ANSI378 TYPE \r\n");
		break;
	}
	
	if (!ExtractTemplate(m_Template1, &m_nTemplate1Size)) {
		return;
	}

	Invalidate(FALSE);

	/////////////////////////////////////////////////////////////////////////////
	CUserInfoDlg dlg;
	UFD_STATUS ufd_res;

	AddMessage("Input user data\r\n");
	if (dlg.DoModal() != IDOK) {
		AddMessage("User data input is cancelled by user\r\n");
		return;
	}
	

	ufd_res = UFD_AddData(m_hDatabase, dlg.m_strUserID, dlg.m_nFingerIndex, m_Template1, m_nTemplate1Size, NULL, 0, dlg.m_strMemo);
	if (ufd_res != UFD_OK) {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_AddData: %s\r\n", m_strError);
	}
	else {
		((CComboBox*)GetDlgItem(IDC_TYPE))->EnableWindow(FALSE);
	}
		
	UpdateDatabaseList();
	/////////////////////////////////////////////////////////////////////////////	
}

void CUFE30_DatabaseDemoDlg::OnDeleteAll() 
{
	UFD_STATUS ufd_res;

	ufd_res = UFD_RemoveAllData(m_hDatabase);
	if (ufd_res == UFD_OK) {
		AddMessage("UFD_RemoveAllData: OK\r\n");
		UpdateDatabaseList();
	} else {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_RemoveAllData: %s\r\n", m_strError);
	}
}

void CUFE30_DatabaseDemoDlg::OnIdentify() 
{
	UFD_STATUS ufd_res;
	UFM_STATUS ufm_res;
	// Input finger data
	unsigned char Template[MAX_TEMPLATE_SIZE];
	int nTemplateSize;
	// DB data
	unsigned char** ppDBTemplate = NULL;
	int* pnDBTemplateSize = NULL;
	int* pnDBSerial = NULL;
	int nDBTemplateNum;
	//
	int nMatchIndex;
	int i;

	ufd_res = UFD_GetTemplateNumber(m_hDatabase, &nDBTemplateNum);
	if (ufd_res != UFD_OK) {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_GetTemplateNumber: %s\r\n", m_strError);
		return;
	}
	
	/////////////////////////////////////////////////////////////////////////////	
	// Allocate DB data
	/////////////////////////////////////////////////////////////////////////////
	ppDBTemplate = (unsigned char**)malloc(nDBTemplateNum * sizeof(unsigned char**));
	pnDBTemplateSize = (int*)malloc(nDBTemplateNum * sizeof(int*));
	pnDBSerial = (int*)malloc(nDBTemplateNum * sizeof(int*));
	for (i = 0; i < nDBTemplateNum; i++) {
		ppDBTemplate[i] = (unsigned char*)malloc(MAX_TEMPLATE_SIZE * sizeof(unsigned char*));
	}
	/////////////////////////////////////////////////////////////////////////////	

	ufd_res = UFD_GetTemplateListWithSerial(m_hDatabase, ppDBTemplate, pnDBTemplateSize, pnDBSerial);
	if (ufd_res != UFD_OK) {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_GetTemplateListWithSerial: %s\r\n", m_strError);
		goto errret;
	}	

	if (!ExtractTemplate(Template, &nTemplateSize)) {
		goto errret;
	}
	
	ufm_res = UFM_Identify(m_hMatcher, Template, nTemplateSize, ppDBTemplate, pnDBTemplateSize, nDBTemplateNum, 5000, &nMatchIndex);
	if (ufm_res != UFD_OK) {
		UFM_GetErrorString(ufm_res, m_strError);
		AddMessage("UFM_Identify: %s\r\n", m_strError);
		return;
	}	

	if (nMatchIndex != -1) {
        AddMessage("Identification succeed (Serial = %d)\r\n", pnDBSerial[nMatchIndex]);
	} else {
		AddMessage("Identification failed\r\n");
	}

errret:
	/////////////////////////////////////////////////////////////////////////////	
	// Free DB data
	/////////////////////////////////////////////////////////////////////////////
	if (ppDBTemplate != NULL) {
		for (i = 0; i < nDBTemplateNum; i++) {
			free(ppDBTemplate[i]);
		}
		free(ppDBTemplate);
	}
	if (pnDBTemplateSize != NULL) {
		free(pnDBTemplateSize);
	}
	if (pnDBSerial != NULL) {
		free(pnDBSerial);
	}
	/////////////////////////////////////////////////////////////////////////////	
}

void CUFE30_DatabaseDemoDlg::OnSelectionDelete() 
{
	UFD_STATUS ufd_res;
	int nSelected;
	int nSerial;

	nSelected = m_ctlDatabaseList.GetSelectionMark();
	if (nSelected == -1) {
		AddMessage("Select data\r\n");
		return;
	} else {
		nSerial = atoi(m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_SERIAL));
	}

	ufd_res = UFD_RemoveDataBySerial(m_hDatabase, nSerial);
	if (ufd_res == UFD_OK) {
		AddMessage("UFD_RemoveDataBySerial: OK\r\n");
		UpdateDatabaseList();
	} else {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_RemoveDataBySerial: %s\r\n", m_strError);
	}
}

void CUFE30_DatabaseDemoDlg::OnSelectionUpdateUserinfo() 
{
	CUserInfoDlg dlg;
	UFD_STATUS ufd_res;
	int nSelected;
	int nSerial;

	nSelected = m_ctlDatabaseList.GetSelectionMark();
	if (nSelected == -1) {
		AddMessage("Select data\r\n");
		return;
	} else {
		nSerial = atoi(m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_SERIAL));
		dlg.m_strUserID = m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_USERID);
		dlg.m_nFingerIndex = atoi(m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_FINGERINDEX));
		dlg.m_strMemo = m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_MEMO);
	}

	AddMessage("Update user data\r\n");
	AddMessage("UserID and FingerIndex will not be updated\r\n");
	if (dlg.DoModal() != IDOK) {
		AddMessage("User data input is cancelled by user\r\n");
		return;
	}

	ufd_res = UFD_UpdateDataBySerial(m_hDatabase, nSerial, NULL, 0, NULL, 0, dlg.m_strMemo);
	if (ufd_res == UFD_OK) {
		AddMessage("UFD_UpdateDataBySerial: OK\r\n");
		UpdateDatabaseList();
	} else {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_UpdateDataBySerial: %s\r\n", m_strError);
	}
}

void CUFE30_DatabaseDemoDlg::OnSelectionUpdateTemplate() 
{
	UFD_STATUS ufd_res;
	int nSelected;
	int nSerial;

	nSelected = m_ctlDatabaseList.GetSelectionMark();
	if (nSelected == -1) {
		AddMessage("Select data\r\n");
		return;
	} else {
		nSerial = atoi(m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_SERIAL));
	}

	if (!ExtractTemplate(m_Template1, &m_nTemplate1Size)) {
		return;
	}

	ufd_res = UFD_UpdateDataBySerial(m_hDatabase, nSerial, m_Template1, m_nTemplate1Size, NULL, 0, NULL);
	if (ufd_res == UFD_OK) {
		AddMessage("UFD_UpdateDataBySerial: OK\r\n");
		UpdateDatabaseList();
	} else {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_UpdateDataBySerial: %s\r\n", m_strError);
	}	
}

void CUFE30_DatabaseDemoDlg::OnSelectionVerify() 
{
	UFD_STATUS ufd_res;
	UFM_STATUS ufm_res;
	int nSelected;
	int nSerial;
	// Input finger data
	unsigned char Template[MAX_TEMPLATE_SIZE];
	int nTemplateSize;
	//
	int bVerifySucceed;

	nSelected = m_ctlDatabaseList.GetSelectionMark();
	if (nSelected == -1) {
		AddMessage("Select data\r\n");
		return;
	} else {
		nSerial = atoi(m_ctlDatabaseList.GetItemText(nSelected, DATABASE_COL_SERIAL));
	}

	ufd_res = UFD_GetDataBySerial(m_hDatabase, nSerial, 
		m_szUserID, &m_nFingerIndex, m_Template1, &m_nTemplate1Size, m_Template2, &m_nTemplate2Size, m_szMemo);
	if (ufd_res != UFD_OK) {
		UFD_GetErrorString(ufd_res, m_strError);
		AddMessage("UFD_UpdateDataBySerial: %s\r\n", m_strError);
		return;
	}	

	if (!ExtractTemplate(Template, &nTemplateSize)) {
		return;
	}
	
	ufm_res = UFM_Verify(m_hMatcher, Template, nTemplateSize, m_Template1, m_nTemplate1Size, &bVerifySucceed);
	if (ufm_res != UFD_OK) {
		UFM_GetErrorString(ufm_res, m_strError);
		AddMessage("UFM_Verify: %s\r\n", m_strError);
		return;
	}	

	if (bVerifySucceed) {
        AddMessage("Verification succeed (Serial = %d)\r\n", nSerial);
	} else {
		AddMessage("Verification failed\r\n");
	}
}
/////////////////////////////////////////////////////////////////////////////

void CUFE30_DatabaseDemoDlg::OnShowWindow(BOOL bShow, UINT nStatus) 
{
	CDialog::OnShowWindow(bShow, nStatus);
	
	// TODO: Add your message handler code here
	Invalidate(TRUE);
	
}

