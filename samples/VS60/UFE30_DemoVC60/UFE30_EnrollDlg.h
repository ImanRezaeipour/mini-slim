#if !defined(AFX_UFE30_ENROLLDLG_H__2CF312E7_187A_4442_8F2A_2B11121B19F6__INCLUDED_)
#define AFX_UFE30_ENROLLDLG_H__2CF312E7_187A_4442_8F2A_2B11121B19F6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// UFE30_EnrollDlg.h : header file
//

#include "UFScanner.h"

#define MAX_TEMPLATE_SIZE		1024
#define MAX_USERID_SIZE			10
#define MAX_TEMPLATE_INPUT_NUM	4
#define MAX_TEMPLATE_OUTPUT_NUM	2

/////////////////////////////////////////////////////////////////////////////
// CUFE30_EnrollDlg dialog

class CUFE30_EnrollDlg : public CDialog
{
// Construction
public:
	CUFE30_EnrollDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CUFE30_EnrollDlg)
	enum { IDD = IDD_UFE30_ENROLL };
	CStatic	m_ctlImageFrame;
	CEdit	m_ctlMessageEdit;
	CString	m_strUserID;
	//}}AFX_DATA

	void AddMessage(char* szData, ...);

	unsigned char* m_EnrollTemplate_input[MAX_TEMPLATE_INPUT_NUM];
	int m_EnrollTemplateSize_input[MAX_TEMPLATE_INPUT_NUM];
	unsigned char* m_EnrollTemplate_output[MAX_TEMPLATE_OUTPUT_NUM];
	int m_EnrollTemplateSize_output[MAX_TEMPLATE_OUTPUT_NUM];

	unsigned char** m_EnrollTemplate;
	int* m_EnrollTemplateSize;

	HUFScanner m_hScanner;

	int m_extract_num;
	int m_output_num;
	int m_try_extract;
	int m_bFingerCheck;
	int m_quality;

	CString m_message;
	char    m_strError[128];


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUFE30_EnrollDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CUFE30_EnrollDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnDestroy();
	afx_msg void OnPaint();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_UFE30_ENROLLDLG_H__2CF312E7_187A_4442_8F2A_2B11121B19F6__INCLUDED_)
