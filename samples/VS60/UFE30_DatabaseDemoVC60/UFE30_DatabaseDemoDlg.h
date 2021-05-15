// UFE30_DatabaseDemoDlg.h : header file
//

#if !defined(AFX_UFE30_DATABASEDEMODLG_H__C26096C4_FCD2_407E_80A7_176598E003FE__INCLUDED_)
#define AFX_UFE30_DATABASEDEMODLG_H__C26096C4_FCD2_407E_80A7_176598E003FE__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


#include "UFScanner.h"
#include "UFMatcher.h"
#include "UFDatabase.h"


#define MAX_USERID_SIZE				50
#define MAX_TEMPLATE_SIZE			1024
#define MAX_MEMO_SIZE				100
//
#define DATABASE_COL_SERIAL			0
#define DATABASE_COL_USERID			1
#define DATABASE_COL_FINGERINDEX	2
#define DATABASE_COL_TEMPLATE1		3
#define DATABASE_COL_TEMPLATE2		4
#define DATABASE_COL_MEMO			5


/////////////////////////////////////////////////////////////////////////////
// CUFE30_DatabaseDemoDlg dialog

class CUFE30_DatabaseDemoDlg : public CDialog
{
// Construction
public:
	CUFE30_DatabaseDemoDlg(CWnd* pParent = NULL);	// standard constructor

	void AddMessage(char* szData, ...);
	void AddRow(int nSerial, char* szUserID, int nFingerIndex, BOOL bTemplate1, BOOL bTemplate2, char* szMemo);
	void UpdateDatabaseList();
	BOOL ExtractTemplate(unsigned char* pTemplate, int* pnTemplateSize);

	CString m_message;

	HUFScanner m_hScanner;
	HUFDatabase m_hDatabase;
	HUFMatcher m_hMatcher;

	char m_strError[128];

	int m_nSerial;
	char m_szUserID[MAX_USERID_SIZE];
	int m_nFingerIndex;
	unsigned char m_Template1[MAX_TEMPLATE_SIZE];
	int m_nTemplate1Size;
	unsigned char m_Template2[MAX_TEMPLATE_SIZE];
	int m_nTemplate2Size;
	char m_szMemo[MAX_MEMO_SIZE];

// Dialog Data
	//{{AFX_DATA(CUFE30_DatabaseDemoDlg)
	enum { IDD = IDD_UFE30_DATABASEDEMO_DIALOG };
	CStatic	m_ctlImageFrame;
	CComboBox	m_ctlType;
	CListCtrl	m_ctlDatabaseList;
	CEdit	m_ctlMessageEdit;
	int		m_nType;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUFE30_DatabaseDemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CUFE30_DatabaseDemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClearMessage();
	afx_msg void OnInit();
	afx_msg void OnUninit();
	afx_msg void OnDestroy();
	afx_msg void OnEnroll();
	afx_msg void OnDeleteAll();
	afx_msg void OnSelectionDelete();
	afx_msg void OnSelectionUpdateUserinfo();
	afx_msg void OnSelectionUpdateTemplate();
	afx_msg void OnSelectionVerify();
	afx_msg void OnIdentify();
	afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_UFE30_DATABASEDEMODLG_H__C26096C4_FCD2_407E_80A7_176598E003FE__INCLUDED_)
