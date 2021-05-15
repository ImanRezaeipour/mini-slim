// UFE30_UserInfoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ufe30_demo.h"
#include "UFE30_UserInfoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CUFE30_UserInfoDlg dialog


CUFE30_UserInfoDlg::CUFE30_UserInfoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUFE30_UserInfoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUFE30_UserInfoDlg)
	m_strUserID = _T("");
	//}}AFX_DATA_INIT
}


void CUFE30_UserInfoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUFE30_UserInfoDlg)
	DDX_Text(pDX, IDC_USER_ID, m_strUserID);
	DDV_MaxChars(pDX, m_strUserID, 10);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CUFE30_UserInfoDlg, CDialog)
	//{{AFX_MSG_MAP(CUFE30_UserInfoDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUFE30_UserInfoDlg message handlers
