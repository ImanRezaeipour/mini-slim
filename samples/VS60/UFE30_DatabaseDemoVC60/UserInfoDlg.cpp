// UserInfoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "UFE30_DatabaseDemo.h"
#include "UserInfoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CUserInfoDlg dialog


CUserInfoDlg::CUserInfoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUserInfoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUserInfoDlg)
	m_strUserID = _T("UserID");
	m_nFingerIndex = 0;
	m_strMemo = _T("Memo");
	//}}AFX_DATA_INIT
}


void CUserInfoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUserInfoDlg)
	DDX_Text(pDX, IDC_USERID, m_strUserID);
	DDV_MaxChars(pDX, m_strUserID, 50);
	DDX_Text(pDX, IDC_FINGERINDEX, m_nFingerIndex);
	DDV_MinMaxInt(pDX, m_nFingerIndex, 0, 9);
	DDX_Text(pDX, IDC_MEMO, m_strMemo);
	DDV_MaxChars(pDX, m_strMemo, 100);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CUserInfoDlg, CDialog)
	//{{AFX_MSG_MAP(CUserInfoDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUserInfoDlg message handlers
