// UFE30_MultiScannerDemoDlg.h : header file
//

#if !defined(AFX_UFE30_MULTISCANNERDEMODLG_H__548CC072_5608_4F7A_A4C4_F2AF68F425CB__INCLUDED_)
#define AFX_UFE30_MULTISCANNERDEMODLG_H__548CC072_5608_4F7A_A4C4_F2AF68F425CB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


#include "UFScanner.h"
#include "UFMatcher.h"


#define MAX_TEMPLATE_SIZE	1024
#define MAX_TEMPLATE_NUM	50


/////////////////////////////////////////////////////////////////////////////
// CUFE30_MultiScannerDemoDlg dialog

class CUFE30_MultiScannerDemoDlg : public CDialog
{
// Construction
public:
	CUFE30_MultiScannerDemoDlg(CWnd* pParent = NULL);	// standard constructor

	void AddMessage(char* szData, ...);
	void GetScannerTypeString(int nScannerType, char* strScannerType);
	void StartEnrollThread(int nScannerIdx);
	void StartIdentifyThread(int nScannerIdx);

	CString m_message;

	HUFScanner m_hScanner[4];
	HUFMatcher m_hMatcher[4];

	char m_strError[128];

    BYTE* m_template[4][MAX_TEMPLATE_NUM];
    int m_template_size[4][MAX_TEMPLATE_NUM];
    int m_template_num[4];
	BOOL m_bIsScannerBusy[4];

// Dialog Data
	//{{AFX_DATA(CUFE30_MultiScannerDemoDlg)
	enum { IDD = IDD_UFE30_MULTISCANNERDEMO_DIALOG };
	CStatic	m_ctlImageFrame[4];
	CEdit	m_ctlMessageEdit;
	CString	m_strScannerID[4];
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUFE30_MultiScannerDemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CUFE30_MultiScannerDemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClearMessage();
	afx_msg void OnInit();
	afx_msg void OnUninit();
	afx_msg void OnDestroy();
	afx_msg void OnEnroll1();
	afx_msg void OnEnroll2();
	afx_msg void OnEnroll3();
	afx_msg void OnEnroll4();
	afx_msg void OnIdentify1();
	afx_msg void OnIdentify2();
	afx_msg void OnIdentify3();
	afx_msg void OnIdentify4();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_UFE30_MULTISCANNERDEMODLG_H__548CC072_5608_4F7A_A4C4_F2AF68F425CB__INCLUDED_)
