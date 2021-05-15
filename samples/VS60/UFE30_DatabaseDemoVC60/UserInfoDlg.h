#if !defined(AFX_USERINFODLG_H__920F8609_AFB0_400D_85E2_7469B83E41BB__INCLUDED_)
#define AFX_USERINFODLG_H__920F8609_AFB0_400D_85E2_7469B83E41BB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// UserInfoDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CUserInfoDlg dialog

class CUserInfoDlg : public CDialog
{
// Construction
public:
	CUserInfoDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CUserInfoDlg)
	enum { IDD = IDD_USER_INFO };
	CString	m_strUserID;
	int		m_nFingerIndex;
	CString	m_strMemo;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUserInfoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CUserInfoDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_USERINFODLG_H__920F8609_AFB0_400D_85E2_7469B83E41BB__INCLUDED_)
