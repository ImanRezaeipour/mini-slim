// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__6272702E_6592_404B_BF6A_D6BD0A62D045__INCLUDED_)
#define AFX_STDAFX_H__6272702E_6592_404B_BF6A_D6BD0A62D045__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

// Win2000, WinMe:	WINVER >= 0x0500
// Win98:			WINVER >= 0x0410
// Win95, NT4.0:	WINVER >= 0x0400
// Do not support Win95, NT4.0
#define WINVER 0x040A

#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__6272702E_6592_404B_BF6A_D6BD0A62D045__INCLUDED_)
