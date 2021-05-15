// UFE30_DatabaseDemo.h : main header file for the UFE30_DATABASEDEMO application
//

#if !defined(AFX_UFE30_DATABASEDEMO_H__8CD71C53_E7D6_4140_9E24_622B39970579__INCLUDED_)
#define AFX_UFE30_DATABASEDEMO_H__8CD71C53_E7D6_4140_9E24_622B39970579__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CUFE30_DatabaseDemoApp:
// See UFE30_DatabaseDemo.cpp for the implementation of this class
//

class CUFE30_DatabaseDemoApp : public CWinApp
{
public:
	CUFE30_DatabaseDemoApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUFE30_DatabaseDemoApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CUFE30_DatabaseDemoApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_UFE30_DATABASEDEMO_H__8CD71C53_E7D6_4140_9E24_622B39970579__INCLUDED_)
