// UFE30_DemoDlg.h : header file
//

#if !defined(AFX_UFE30_DEMODLG_H__D511C0D7_B1DD_49F6_A1B9_438492C8BD89__INCLUDED_)
#define AFX_UFE30_DEMODLG_H__D511C0D7_B1DD_49F6_A1B9_438492C8BD89__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


#include "UFScanner.h"
#include "UFMatcher.h"


#define MAX_TEMPLATE_SIZE		1024
#define MAX_TEMPLATE_NUM		50

#define WM_UPDATE_SCANNER_LIST	WM_APP + 0x10


/////////////////////////////////////////////////////////////////////////////
// CUFE30_DemoDlg dialog

class CUFE30_DemoDlg : public CDialog
{
// Construction
public:
	CUFE30_DemoDlg(CWnd* pParent = NULL);	// standard constructor

	void AddMessage(char* szData, ...);
	void GetScannerTypeString(int nScannerType, char* strScannerType);
	BOOL GetCurrentScannerHandle(HUFScanner* phScanner);
	void GetCurrentScannerSettings();
	void GetMatcherSettings(HUFMatcher hMatcher);
	void UpdateScannerList();

	CString m_message;
	
	HUFMatcher m_hMatcher;

	char m_strError[128];

    unsigned char* m_template[MAX_TEMPLATE_NUM];
    int m_template_size[MAX_TEMPLATE_NUM];
    int m_template_num;

	// Test code: for checking fps
	int m_frame_num;

// Dialog Data
	//{{AFX_DATA(CUFE30_DemoDlg)
	enum { IDD = IDD_UFE30_DEMO_DIALOG };
	CComboBox	m_ctlID;
	CStatic	m_ctlImageFrame;
	CEdit	m_ctlMessageEdit;
	CListBox	m_ctlScannerList;
	int		m_nBrightness;
	int		m_nSensitivity;
	BOOL	m_bDetectCore;
	int		m_nSecurityLevel;
	int		m_nTimeout;
	BOOL	m_bFastMode;
	int		m_nEnrollQuality;
	int		m_nSelectID;
	int		m_nDetectFake;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUFE30_DemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CUFE30_DemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDestroy();
	afx_msg void OnSelchangeScannerList();
	afx_msg void OnSelchangeTimeout();
	afx_msg void OnChangeBrightness();
	afx_msg void OnChangeSensitivity();
	afx_msg void OnClearMessage();
	afx_msg void OnInit();
	afx_msg void OnUninit();
	afx_msg void OnCaptureSingle();
	afx_msg void OnExtract();
	afx_msg void OnEnroll();
	afx_msg void OnDetectCore();
	afx_msg void OnSelchangeEnrollQuality();
	afx_msg void OnVerify();
	afx_msg void OnSelchangeId();
	afx_msg void OnIdentify();
	afx_msg void OnSelchangeSecurityLevel();
	afx_msg void OnFastMode();
	afx_msg void OnSaveTemplate();
	afx_msg void OnSaveImage();
	afx_msg void OnStartCapturing();
	afx_msg void OnAbortCapturing();
	afx_msg void OnUpdate();
	afx_msg LRESULT OnUpdateScannerList(WPARAM wParam, LPARAM lParam);
	afx_msg void OnSelchangeDetectFake();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_UFE30_DEMODLG_H__D511C0D7_B1DD_49F6_A1B9_438492C8BD89__INCLUDED_)
