import com.suprema.ufe33.BioMiniJniSDK;

import javax.swing.JScrollPane;
import javax.swing.SwingUtilities;
import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Image;
import java.awt.Rectangle;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.io.*;

import javax.swing.*;

import java.awt.Graphics;
import javax.swing.JComboBox;
import java.awt.image.BufferedImage;
import java.awt.image.renderable.ParameterBlock;

import javax.swing.JTextField;
import javax.swing.JList;
import javax.swing.JLabel;
import javax.swing.border.*;
import java.awt.*;

public class demoUFEJavaJNI extends JFrame {
	
	/**
	 * @param args
	 */
	private static final long serialVersionUID = 1L;

	private JPanel jContentPane = null;  

	private JButton jButton_ufe_init = null;

	private JList jList = null;

	private JOptionPane jOptionPane = null; 

	private JButton jButton_caputure_single = null;
		
        long[] hMatcher = new long[1];
	
	private JTextField jTextField_status = null;

	private JButton jButton_update = null;

	private JButton jButton_Uninit = null;

	private JList jList1_scanner_list = null;

	private JComboBox jComboBox_timeout = null;

	private JLabel jLabel_timeout = null;

	private JLabel jLabel_brightness = null;

	private JLabel jLabel_sense = null;

	private JButton jButton_start_capturing = null;

	private JButton jButton_abort = null;

	private JButton jButton_extractor = null;

	private JLabel jLabel_enroll = null;

	private JComboBox jComboBox_enroll = null;

	private JLabel jLabel_parameter = null;
	
	private JPanel jContentPane1 = null;

	private JList jList_msg_log = null;

	private JLabel jLabel_sense1 = null;

	private JLabel jLabel_match = null;

	private JLabel jLabel_security_levle = null;

	private JComboBox jComboBox_security_level = null;

	private JCheckBox jCheckBox_fastmode = null;

	private JLabel jLabel_enrollid = null;

	private JComboBox jComboBox_enrollid = null;
        
        private JLabel jLabel_detect_fake = null;

        private JComboBox jComboBox_detect_fake = null;

	private JButton jButton_verity = null;

	private JButton jButton_Identify = null;

	private JButton jButton_enroll = null;

	private JButton jButton_save_tmp = null;

	private JButton jButton_save_img = null;

	private JLabel jLabel_scanner_list = null;

	private JButton jButton_clear = null;

	public Image fingerImg =null;

	private ImagePanel imgPanel = null;
	
	private int nScannerNumber=0;
		
	private DefaultListModel listModel;  //  @jve:decl-index=0:visual-constraint="518,17"
	
	private DefaultListModel listLogModel;  //  @jve:decl-index=0:visual-constraint="507,84"
	
	private JScrollPane listScrollPane=null;
	
	private JScrollPane logScrollPane=null;
		
	public int nC=0;
	
	private int nInitFlag=0;
	
	private int nCaptureFlag=0;
	
	private byte[][] byteTemplateArray= null;
	
	private int[]   intTemplateSizeArray=null;
	
	private int nTemplateCnt =0;
	
	private int nLogListCnt =0;
	
	private  String[] strTemplateArray=null;
	
	private int nSecurityLevel =0;

        private int nDetectFake =2;
	
	private int nFastMode=0;
		
	public final int MAX_TEMPLATE_SIZE=1024;

        BioMiniJniSDK p = null;

        static demoUFEJavaJNI pMainInstance;

	/**************************************/

	/**
	 * This method initializes jButton_ufe_init	
	 * 	
	 * @return javax.swing.JButton	
	 */
	
		
	public void MsgBox(String log)
	{
		JOptionPane.showMessageDialog(null,log);
	}
	
	public void setStatusMsg(String log)
	{
		getJTextField_status().setText("");
		getJTextField_status().setText(log);
		
		log=nLogListCnt+":"+log;
		listLogModel.insertElementAt(log, nLogListCnt);
		nLogListCnt++;
	}
	
	public void initArray(int nArrayCnt,int nMaxTemplateSize)
	{
		if(byteTemplateArray!=null){
			byteTemplateArray=null;
			
		}
		
		if(intTemplateSizeArray!=null){
			intTemplateSizeArray=null;
			
		}
		
		byteTemplateArray= new byte[nArrayCnt][MAX_TEMPLATE_SIZE];
		
		intTemplateSizeArray=new int[nArrayCnt];
	
	}
	
	public void initVariable(int nFlag)
	{
		
		if(nFlag==1){ //UFS_Init\//
			nInitFlag = 1;
		}else{
			nInitFlag = 0;
		}
		
		nCaptureFlag=0;
		
		nLogListCnt =0;
		
		listLogModel.clear();
		
		String szComboItem =null;
		for(int i=0;i<6;i++){
			szComboItem=String.valueOf(i);
			jComboBox_timeout.insertItemAt(szComboItem, i);
		}
		
		jComboBox_timeout.setSelectedIndex(5);
		
		///////////////////////////////////////////////////
		szComboItem =null;
		
		for(int i=0;i<256;i++){
			szComboItem=String.valueOf(i);
			jComboBox_bri.insertItemAt(szComboItem, i);
		}
		jComboBox_bri.setSelectedIndex(100); //100		
				
		/////////////////////////////////////////////////
		szComboItem =null;
		
		for(int i=0;i<8;i++){
			szComboItem=String.valueOf(i);
			jComboBox_sens.insertItemAt(szComboItem, i);
		}
		jComboBox_sens.setSelectedIndex(4); //4
		
		/////////////////////////////////////////////////
		szComboItem =null;
		for(int i=0;i<6;i++){
			szComboItem=String.valueOf((i*10));
			jComboBox_enroll.insertItemAt(szComboItem, i);
		}
		jComboBox_enroll.setSelectedIndex(5);

                szComboItem =null;
		for(int i=0;i<4;i++){
			szComboItem=String.valueOf(i);
			jComboBox_detect_fake.insertItemAt(szComboItem, i);
		}
		jComboBox_detect_fake.setSelectedIndex(2);
		
		///////////////////////////////////////////////
		jComboBox_ScanType.insertItemAt("suprema*", 0);
		jComboBox_ScanType.insertItemAt("iso_19794_2", 1);
		jComboBox_ScanType.insertItemAt("ansi378", 2);
		jComboBox_ScanType.setSelectedIndex(0); 
		///////////////////////////////////////////////
		jComboBox_MatchType.insertItemAt("suprema*", 0);
		jComboBox_MatchType.insertItemAt("iso_19794_2", 1);
		jComboBox_MatchType.insertItemAt("ansi378", 2);
		jComboBox_MatchType.setSelectedIndex(0); 
		///////////////////////////////////////////////
		szComboItem =null;
		int nTempRate =10;
		for(int i=1;i<8;i++){
			szComboItem=String.valueOf(i);
			if(i==1){
				szComboItem = szComboItem+"(FAR "+1+"/"+nTempRate*10+")";
			}else{
				szComboItem = szComboItem+"("+1+"/"+nTempRate*10+")";
			}
			jComboBox_security_level.insertItemAt(szComboItem, i-1);
			nTempRate=nTempRate*10;
		}
		jComboBox_security_level.setSelectedIndex(4); //7

                long[] hScanner = new long[1];
		int index = 0;
		p.UFS_GetScannerHandle(index, hScanner);
		
		int[] pValue = new int[1];

                pValue[0] = 5000;
		
		int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_TIMEOUT,pValue);
		if(nRes==0){
			setStatusMsg("Change combox-timeout,201(timeout) value is "+pValue[0]);
		}else{
			setStatusMsg("Change combox-timeout,change parameter value fail! code: "+nRes);
		}
		
		pValue[0] = 100;
		nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_BRIGHTNESS,pValue);
		if(nRes==0){
			setStatusMsg("Change combox-brightness,202 value is "+pValue[0]);
		}else{
			setStatusMsg("Change combox-brightness,change parameter value fail! code: "+nRes);
		}

                pValue[0] = 2;
                nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_DETECT_FAKE,pValue);
		if(nRes==0){
			setStatusMsg("Change combox-detect_fake,312(fake detect) value is "+pValue[0]);
		}else{
			setStatusMsg("Change combox-detect_fake,change parameter value fail! code: "+nRes);
		}
		
		pValue[0] = 4;
		nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_SENSITIVITY,pValue);
		if(nRes==0){
			setStatusMsg("Change combox-sensitivity,203 value is "+pValue[0]);
		}else{
			setStatusMsg("Change combox-sensitivity,change parameter value fail! code: "+nRes);
		}
	
		nRes = p.UFS_SetTemplateType(hScanner[0],p.UFS_TEMPLATE_TYPE_SUPREMA); //2001 Suprema type
		if(nRes==0){
			setStatusMsg("Change combox-Scan TemplateType:2001");
		}else{
			setStatusMsg("Change combox-Scan TemplateType,change parameter value fail! code: "+nRes);
		}
	}
	
	public int getScannerNumber()
	{
		int nRes =0;
		int[] nNumber= new int[1];
		
		nRes = p.UFS_GetScannerNumber(nNumber);
				
		if(nRes ==0){
			
				System.out.println("UFS_GetScannerNumber() res value is "+nRes);			
										
				System.out.println("UFS_GetScannerNumber()reference value is(scanner number) "+ nNumber[0]);
				setStatusMsg("get Scanner number success,scanner number is "+nNumber[0]);
				
				return nNumber[0]; //scanner count
		}
		
		return 0;
	}
	
	public void drawCurrentFingerImage() 
	{
		/*test draw image*/
		int[] Resolution = new int[1];
		int[] Height     = new int[1];
		int[] Width      = new int[1];
		long[] hScanner = new long[1];
		
		hScanner=GetCurrentScannerHandle();
		
		p.UFS_GetCaptureImageBufferInfo(hScanner[0], Width, Height, Resolution);
		
		byte[] pImageData = new byte[Width[0]*Height[0]];
		
		p.UFS_GetCaptureImageBuffer(hScanner[0],pImageData);
				
		imgPanel.drawFingerImage(Width[0],Height[0],pImageData);
	}
	
	 public void UpdateScannerList()
	{
		
		int nSelectedIdx =0;
		int nRes =0;
		long[] hTempScanner = new long[1];
		long[] hScanner = new long[1];
		int[] Type = new int[1];

		byte[] bScannerId = new byte[512];
		
		String szListLog = null;
		int nNumber=0;
		
		System.out.println("==update Scanner list==");
		
		int[] Number = new int[1];
		
		nRes = p.UFS_GetScannerNumber(Number);
				
		if(nRes ==0){
			
				System.out.println("UFS_GetScannerNumber() res value is "+nRes);
			
				nNumber = Number[0];
		}else{
			
			return;
		}
		
		if(nNumber<=0){
			
			if(listModel.getSize()>0){
				listModel.clear();
				System.out.println("list clear");
			}
			return;
		}
		
				
		if(listModel.getSize()>0){
			listModel.clear();
			System.out.println("list clear");
		}
				    
	    for(int j=0;j<nNumber;j++){
	    	nRes = p.UFS_GetScannerHandle(j,hTempScanner);
	    	hScanner=null;
			hScanner = hTempScanner;
			
			if(nRes ==0 && hScanner!=null){
												 
				nRes = p.UFS_GetScannerID(hScanner[0],bScannerId);
								
				nRes=p.UFS_GetScannerType(hScanner[0], Type);
                                
                                String szId = new String(bScannerId);
					
				szListLog= "ID : " +szId + "Type : "+Type;
					
				listModel.insertElementAt(szListLog, j);
					
			}
	    }
						
		nSelectedIdx = jList1_scanner_list.getSelectedIndex(); 
	    if (nSelectedIdx == -1) {
	    	nSelectedIdx = 0;
	    }
		
	    jList1_scanner_list.setSelectedIndex(nSelectedIdx);
	    jList1_scanner_list.ensureIndexIsVisible(nSelectedIdx);
	}

        public void captureCallback(int bFingerOn, byte[] pImage, int nWidth, int nHeight, int nResolution) {
		nC ++;
			/*
			System.out.println(nC+"==========================================");  //
			System.out.println("==>captureProc calle scanner:"+hScanner);  //
			System.out.println(" fingerOn:"+bFingerOn);  //
			System.out.println("width: "+nWidth);
			System.out.println("height: "+nHeight);
			System.out.println("resolution: "+nResolution);
			System.out.println("void * pParam  value is "+pParam.getValue());
			System.out.println(nC+"==========================================");  //
			*/
			pMainInstance.drawCurrentFingerImage();

			/*
			jFingerInfo.setText("");
			jFingerInfo.setText("width:"+nWidth + " height:"+nHeight+" resolution:"+nResolution);
			*/

			//MsgBox("call"+nC); //exception error==> SDK work thread(UFS_Capture_Thread) while loop �� try ,catch
	}

	public void scannerCallback(char[] szScannerID, int bSensorOn) {
		nC ++;

			System.out.println(nC+"==========================================");  //
			//System.out.println("==>ScanProc calle scannerID:"+szScannerId);  //
			System.out.println("sensoron value is "+bSensorOn);
			System.out.println("void * pParam  value is "+bSensorOn);
			System.out.println(nC+"==========================================");  //

			pMainInstance.UpdateScannerList();
	}
	

	private JComboBox jComboBox_bri = null;

	private JComboBox jComboBox_sens = null;

	private JTextField jFingerInfo = null;

	private JList jList1 = null;

	private JComboBox jComboBox_ScanType = null;

	private JComboBox jComboBox_MatchType = null;

	private JLabel jLabel = null;

	private JLabel jLabel1 = null;
	
	public int testCallScanProcCallback()
	{
		int nRes =0;

                // Set the callback function name for getting Scanner Plug event.
		nRes = p.UFS_SetScannerCallback("scannerCallback");
		if(nRes==0){
			System.out.println("==>UFS_SetScannerCallback pScanProc ..."+ "scannerCallback");
			
		}
		return nRes;
	}
	
	public int testCallStartCapturing()
	{
		int nRes =0;
		
		long[] hScanner = new long[1];
								
		hScanner=GetCurrentScannerHandle();
		
		if(hScanner!=null){

			System.out.println("UFS_StartCapturing,get current scanner handle success! : "+hScanner);

			setStatusMsg("get Scanner handle success pointer:"+hScanner);
			
		}else{

			System.out.println("UFS_StartCapturing,GetScannerHandle fail!!");
			
			setStatusMsg("UFS_StartCapturing,get Scanner handle fail!!");
			
			return 0;
		}

                // Set the callback function name for getting captured frame and the information as second parameter
		nRes = p.UFS_StartCapturing(hScanner[0], "captureCallback");
		
		if(nRes ==0){
				setStatusMsg("UFS_StartCapturing success!!");
				System.out.println("UFS_StartCapturing success!!");
				nCaptureFlag=1;
		}else{
				setStatusMsg("UFS_StartCapturing fail!! code:"+nRes);
		}
		
		return nRes;
	}
	
	
	public long[] GetCurrentScannerHandle()
	{
		long[] hScanner = new long[1];
		int nRes =0;
		int[] nNumber = new int[1];
		
//		�Ʒ� success!!//
		nRes = p.UFS_GetScannerNumber(nNumber);
		
		if(nRes==0){
			
			if(nNumber[0] <=0){
				
				return null;
			}
			
		}else{
			
			return null;
		}
				
		int index = jList1_scanner_list.getSelectedIndex(); 
	    if (index == -1) { 
	        index = 0;
	    } else {
	    	
	    }
	    	    	    
	  	    
	    jList1_scanner_list.setSelectedIndex(index);
	    jList1_scanner_list.ensureIndexIsVisible(index);

		nRes = p.UFS_GetScannerHandle(index,hScanner);
		
		if(nRes ==0 && hScanner!=null){
			return hScanner;
		}
		return null;
	}

	public void getCurrentScannerInfo()
	{
		/*
		 * PARAMETER value
		 * for scanner
		 * 201 : timeout
		 * 202 : brightness
		 * 203 : sensitivity
		 * 204 : serial 
		 * 
		 * for extracting
		 * 301 : detect core
		 * 302 : template size
		 * 311 : use sif
		 */
		
		long[] hScanner = new long[1];
		int nRes =0;
		int[] nNumber = new int[1];
		
		nRes = p.UFS_GetScannerNumber(nNumber);
		
		if(nRes==0){
			
			if(nNumber[0] <=0){
				
				return ;
			}
			
		}else{
			
			return ;
		}
	
		int index = jList1_scanner_list.getSelectedIndex(); 
	    if (index == -1) { 
	        index = 0;
	    } else {
	    	
	    }
	  	    
	    jList1_scanner_list.setSelectedIndex(index);
	    jList1_scanner_list.ensureIndexIsVisible(index);

		nRes = p.UFS_GetScannerHandle(index,hScanner);
		
		if(nRes ==0 && hScanner!=null){
			
//			getParameter
			int[] pValue = new int[1];
			int nSelectedIdx=0;
			nRes = p.UFS_GetParameter(hScanner[0],201,pValue);
			System.out.println("===>UFS_GetParameter ,201(timeout) value is "+pValue[0]);
			
			if(nRes==0 && jComboBox_timeout.getItemCount()>0){
				
				for(int i=0;i<6;i++){
					
					nSelectedIdx = Integer.parseInt((String)(jComboBox_timeout.getItemAt(i)));
					
					if(nSelectedIdx == (pValue[0]/1000)){
						
						jComboBox_timeout.setSelectedIndex(i);
						
						break;
					}
					
					
				}

			}
			
			nRes = p.UFS_GetParameter(hScanner[0],202,pValue);
			System.out.println("===>UFS_GetParameter ,202(brightness) value is "+pValue[0]);
			
			if(nRes==0 && jComboBox_bri.getItemCount()>0){
				
				for(int i=0;i<256;i++){
					
					nSelectedIdx = Integer.parseInt((String)(jComboBox_bri.getItemAt(i)));
					
					if(nSelectedIdx ==pValue[0]){
						
						jComboBox_bri.setSelectedIndex(i);
						
						break;
					}
				}
			}

                        nRes = p.UFS_GetParameter(hScanner[0],312,pValue);
			System.out.println("===>UFS_GetParameter ,312(detect_fake) value is "+pValue[0]);

			if(nRes==0 && jComboBox_detect_fake.getItemCount()>0){

				for(int i=0;i<4;i++){

					nSelectedIdx = Integer.parseInt((String)(jComboBox_detect_fake.getItemAt(i)));

					if(nSelectedIdx == pValue[0]){

						jComboBox_detect_fake.setSelectedIndex(i);

						break;
					}


				}

			}
			
			nRes = p.UFS_GetParameter(hScanner[0],203,pValue);
			System.out.println("===>UFS_GetParameter ,203(sensitivity) value is "+pValue[0]);
			if(nRes==0 && jComboBox_sens.getItemCount()>0){
				
				for(int i=0;i<8;i++){
					
					nSelectedIdx = Integer.parseInt((String)(jComboBox_sens.getItemAt(i)));
					
					if(nSelectedIdx ==pValue[0]){
						
						jComboBox_sens.setSelectedIndex(i);
						
						break;
					}
				}
			}
			
		}
		
		return;
	}
	
	static public String DateConvert(String dateType) {
		String dateTime = null;

		try {
			SimpleDateFormat sd = new SimpleDateFormat(dateType); //java.text..
			dateTime = sd.format(new Date());                     //java.util.
		} catch (Exception ex) {
			
		}
		return dateTime;
	}	
	
	
	public int CaptureSingle() 
	{
		
		int nRes =0;
		long[] hScanner = new long[1];
			
		System.out.println("call GetCurrentScannerHandle()");
		
		hScanner=GetCurrentScannerHandle();
		
		if(hScanner!=null){

			System.out.println("GetScannerHandle return hScanner pointer: "+hScanner);

			setStatusMsg("get Scanner handle success pointer:"+hScanner);
			
		}else{

			System.out.println("GetScannerHandle fail!!");
			
			setStatusMsg("get Scanner handle fail!!");
			
			return -1;
		}
		
		setStatusMsg("Start single image capturing");
		
		nRes = p.UFS_CaptureSingleImage(hScanner[0]);
		
		if(nRes==0){
					System.out.println("==>UFS_CaptureSingleImage return value is.."+nRes);		
					
					nCaptureFlag=1;
					
					drawCurrentFingerImage();
					
		}else{
			
			setStatusMsg("SingleImage fail!! code:"+nRes);
						
			byte[] refErr = new byte[512];
			
			nRes = p.UFS_GetErrorString(nRes,refErr);
                        String strErr = new String(refErr);
			if(nRes ==0){
				System.out.println("==>UFS_GetErrorString err is "+strErr);
			}
			
			MsgBox("caputure single img fail!!");
		}
		
		return nRes;
	}	
	
	private JButton getJButton_ufe_init() {
		if (jButton_ufe_init == null) {
			jButton_ufe_init = new JButton();
			jButton_ufe_init.setBounds(new Rectangle(15, 15, 65, 21));
			jButton_ufe_init.setText("Init");
			
			jButton_ufe_init.addActionListener(new java.awt.event.ActionListener() {
			
				public void actionPerformed(java.awt.event.ActionEvent e) {
						
						if(nInitFlag!=0){
							
							MsgBox("already init..");
							
							return;
						}                                             
						
						nCaptureFlag=0;
												
						int nRes =0;
						
						nRes = p.UFS_Init();
						
						if(nRes ==0){
							
							System.out.println("UFS_Init() success!!");
							
							nInitFlag=1;
							
							getJTextField_status().setText("UFS_Init() success,nInitFlag value set 1");
							MsgBox("Scanner Init success!!");

                                                        /*
                                                         * This Function MUST be operated properly before setcallback and after initialization for using callback functions.
                                                         */
                                                        p.UFS_SetClassName("demoUFEJavaJNI");
	
							nRes = testCallScanProcCallback();
							
							if(nRes==0){
								
								setStatusMsg("==>UFS_SetScannerCallback pScanProc ...");
								
								int[] refNumber = new int[1];
								nRes = p.UFS_GetScannerNumber(refNumber);
								
								if(nRes ==0){
									nScannerNumber = refNumber[0];
									setStatusMsg("UFS_GetScannerNumber() scanner number :"+ nScannerNumber);
									
            								nRes = p.UFM_Create(hMatcher);
									
									if(nRes==0){
										
										UpdateScannerList(); //list upate ==> getcurrentscannerhandle�� list�� ������//
										System.out.println("after upadtelist");
										initVariable(1);
										System.out.println("after initVariable");
										initArray(100,1024); //array size,template size

																			
										//security level (1~7)

                                                                                int[] refValue = new int[1];
										
										nRes = p.UFM_GetParameter(hMatcher[0],302,refValue); //302 : security level :UFM_
										
										if(nRes==0){
											nSecurityLevel = refValue[0];//
											setStatusMsg("get security level,302(security) value is "+nSecurityLevel);
										}else{
											setStatusMsg("get security level fail! code: "+nRes);
											MsgBox("get security level fail! code: "+nRes);
										}
										
										if(nRes==0 && jComboBox_security_level.getItemCount()>0){
											for(int i=0;i<6;i++){
												
												if(i ==nSecurityLevel-1){ //i : list index(zero based) ,refValue
													jComboBox_security_level.setSelectedIndex(i);
													break;
												}
											}
										}
										
										//fast mode
                                                                                int[] refFastMode = new int[1];

										nRes = p.UFM_SetParameter(hMatcher[0],p.UFM_PARAM_FAST_MODE,refFastMode);

										if(nRes==0){
											nFastMode = refFastMode[0];
											setStatusMsg("get fastmode,301(fastmode) value is "+nFastMode);
											//MsgBox("get fastmode,301(fastmode) value is "+refFastMode.getValue());

										}else{
											setStatusMsg("get fastmode value fail! code: "+nRes);
											MsgBox("get fastmode value fail! code: "+nRes);
										}
										if(nFastMode==1){
											jCheckBox_fastmode.setSelected(true);
										}
										
										int  nSelectedIdx = jComboBox_MatchType.getSelectedIndex();

										if(hMatcher!=null){
											switch(nSelectedIdx){
											
												case	0:
													nRes = p.UFM_SetTemplateType(hMatcher[0],p.UFM_TEMPLATE_TYPE_SUPREMA); //2001 Suprema type
													
													break;
												case	1:
													nRes = p.UFM_SetTemplateType(hMatcher[0],p.UFM_TEMPLATE_TYPE_ISO19794_2); //2002 iso type
													
													break;
												case	2:
													nRes = p.UFM_SetTemplateType(hMatcher[0],p.UFM_TEMPLATE_TYPE_ANSI378); //2003 ansi type
													
													break;	
											}
										}
																														
									}else{
									
										setStatusMsg("UFM_Create fail!! code :"+nRes);
										
										return;
									}
									
								}else{
									MsgBox("GetScannerNumber fail!! code :"+nRes);
									setStatusMsg("GetScannerNumber fail!! code :"+nRes);
									return;
									
								}
								
							}else{
								
								setStatusMsg("UFS_SetScannerCallback() fail,code :"+ nRes);
								
							}
							
						}
						
						if(nRes!=0){
							System.out.println("Init() fail!!");
							setStatusMsg("Init fail!! return code:"+nRes);
							MsgBox("Scanner Init fail!!");
						}
					
					}
			});
			
		}
		return jButton_ufe_init;
	}
	/*�߰�*/
	private ImagePanel getImagePanel() {
		if (imgPanel == null) {
			imgPanel = new ImagePanel();
			imgPanel.setLayout(null);
			
			imgPanel.setBounds(new Rectangle(260, 17, 270, 310));

		}
		return imgPanel;
	}
	
	/**
	 * This method initializes jList	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJList() {
		if (jList == null) {

			jList = new JList();
			jList.setBounds(new Rectangle(417, 19, 0, 0));
		}
		return jList;
	}
	
		
	/**
	 * This method initializes jButton_caputure_single	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_caputure_single() {
		if (jButton_caputure_single == null) {
			jButton_caputure_single = new JButton();
			jButton_caputure_single.setBounds(new Rectangle(16, 369, 129, 20));
			jButton_caputure_single.setText("Capture single");
			
			jButton_caputure_single.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e)  {
					//System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					
					if(nInitFlag==1){
						int nRes = CaptureSingle();
						String log = null;
						log="capture single image,return value is "+nRes;
						setStatusMsg(log);
						drawCurrentFingerImage();

					}else{
						MsgBox("initiate!");
					}
				}
			});
			
			
		}
		return jButton_caputure_single;
	}

	/**
	 * This method initializes jTextField_status	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextField_status() {
		if (jTextField_status == null) {
			jTextField_status = new JTextField();
			jTextField_status.setBounds(new Rectangle(1, 554, 498, 16));
		}
		return jTextField_status;
	}
	/**
	 * This method initializes jButton_update	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_update() {
		if (jButton_update == null) {
			jButton_update = new JButton();
			jButton_update.setBounds(new Rectangle(91, 15, 76, 21));
			jButton_update.setText("Update");
			
			jButton_update.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()

					int nRes = p.UFS_Update();
						
					if(nRes ==0){
													
					}else{
						
					}
				}
			});
		}
		return jButton_update;
	}

	/**
	 * This method initializes jButton_Uninit	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_Uninit() {
		if (jButton_Uninit == null) {
			jButton_Uninit = new JButton();
			jButton_Uninit.setBounds(new Rectangle(181, 15, 72, 21));
			jButton_Uninit.setText("Uninit");
			
			jButton_Uninit.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					
					
					
					int nRes = p.UFS_Uninit();
						
					if(nRes ==0){
							
						setStatusMsg("UFS_Uninit sucess!!");
							
						nRes = p.UFM_Delete(hMatcher[0]);
															
						nInitFlag=0;
							
						MsgBox("UFS_Uninit success!");
						
						
							
					}else{
							setStatusMsg("UFS_Uninit fail!!");
					}
	
				}
			});
		}
		return jButton_Uninit;
	}

	/**
	 * This method initializes jList1_scanner_list	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJList1_scanner_list() {
		
		if (jList1_scanner_list == null) {
			
			listModel = new DefaultListModel();
			
	        jList1_scanner_list = new JList(listModel);
	        
	        jList1_scanner_list.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
	        
	        jList1_scanner_list.setSelectedIndex(0);

	        jList1_scanner_list.setVisibleRowCount(5); 
	       
	        jList1_scanner_list.setBounds(new Rectangle(15, 66, 234, 103));
	        
	        listScrollPane = new JScrollPane(jList1_scanner_list);
	        
	        listScrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED);
	        listScrollPane.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED);
	      	        
	        jList1_scanner_list.setVisible(true);
	        jList1_scanner_list.addListSelectionListener(new javax.swing.event.ListSelectionListener() {
				
	        	public void valueChanged(javax.swing.event.ListSelectionEvent e) {
					
	        		getCurrentScannerInfo();
				
	        	}
			});
	       
		}
		return jList1_scanner_list;
	}

	/**
	 * This method initializes jComboBox_timeout	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_timeout() {
		if (jComboBox_timeout == null) {
			jComboBox_timeout = new JComboBox();
			jComboBox_timeout.setBounds(new Rectangle(80, 195, 50, 23));
				
			jComboBox_timeout.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
					jComboBox_timeout = (JComboBox)e.getSource();
			        int  nSelectedIdx = Integer.parseInt((String)(jComboBox_timeout.getSelectedItem()));
			        
			        //set parameter
			        
			        int[] pValue = new int[1];
					pValue[0] = nSelectedIdx*1000;
					
					long[] hScanner = new long[1];
															
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
					
						int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_TIMEOUT,pValue); //201 : timeout parameter
						if(nRes==0){
							setStatusMsg("Change combox-timeout,201(timeout) value is "+pValue[0]);
						}else{
							setStatusMsg("Change combox-timeout,change parameter value fail! code: "+nRes);
						}
					}else{
						
						setStatusMsg("getCurrentScannerHandle fail!! in ChangeComboBox-timeout");
					}
					
				}
			});
						
		}
		return jComboBox_timeout;
	}
        
        private JComboBox getJComboBox_detect_fake() {
		if (jComboBox_detect_fake == null) {
			jComboBox_detect_fake = new JComboBox(); 
			jComboBox_detect_fake.setBounds(new Rectangle(210, 195, 46, 18));
				
			jComboBox_detect_fake.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
					jComboBox_detect_fake = (JComboBox)e.getSource();
			        int  nSelectedIdx = Integer.parseInt((String)(jComboBox_detect_fake.getSelectedItem()));
			        
			        //set parameter
			        
			        int[] pValue = new int[1];
					pValue[0] = nSelectedIdx;
					
					long[] hScanner = new long[1];
															
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
					
						int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_DETECT_FAKE,pValue); //312 : detect_fake parameter
						if(nRes==0){
							setStatusMsg("Change combox-detect_fake,312(detect_fake) value is "+pValue[0]);
						}else{
							setStatusMsg("Change combox-detect_fake,change parameter value fail! code: "+nRes);
						}
					}else{
						
						setStatusMsg("getCurrentScannerHandle fail!! in ChangeComboBox-detect_fake");
					}
					
				}
			});
						
		}
		return jComboBox_detect_fake;
	}


	/**
	 * This method initializes jButton_start_capturing	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_start_capturing() {
		if (jButton_start_capturing == null) {
			jButton_start_capturing = new JButton();
			jButton_start_capturing.setBounds(new Rectangle(16, 343, 130, 20));
			jButton_start_capturing.setText("Start capturing");
			
			jButton_start_capturing.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
										
					if(nInitFlag==1){
						
						testCallStartCapturing();
					
					}else{
						MsgBox("initiate!");
					}
				}
			});
		}
		return jButton_start_capturing;
	}

	/**
	 * This method initializes jButton_abort	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_abort() {
		if (jButton_abort == null) {
			jButton_abort = new JButton();
			jButton_abort.setBounds(new Rectangle(151, 343, 89, 20));
			jButton_abort.setText("abort");
			
			jButton_abort.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
					long[] hScanner = new long[1];
					
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
					
						int nRes = p.UFS_AbortCapturing(hScanner[0]);
						
						if(nRes==0){
							setStatusMsg("UFS_UFS_AbortCapturing success!!");
						}else{
							setStatusMsg("UFS_UFS_AbortCapturing fail!! code:"+nRes);
						}
					}else{
						setStatusMsg("UFS_UFS_AbortCapturing fail!! get current scanner handle fail!");
					}
				}
			});
		}
		return jButton_abort;
	}

	/**
	 * This method initializes jButton_extractor	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_extractor() {
		if (jButton_extractor == null) {
			jButton_extractor = new JButton();
			jButton_extractor.setBounds(new Rectangle(151, 369, 89, 20));
			jButton_extractor.setText("extract");
			
			jButton_extractor.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
					long[] hScanner = new long[1];
					
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
											
						byte[] bTemplate = new byte[MAX_TEMPLATE_SIZE];
						
						int[] refTemplateSize = new int[1];
						
						int[] refTemplateQuality = new int[1];
						
						int nRes;
						int  nSelectedIdx = jComboBox_ScanType.getSelectedIndex();
						
						switch(nSelectedIdx){
						
							case	0:
								nRes = p.UFS_SetTemplateType(hScanner[0],2001); //2001 Suprema type
								break;
							case	1:
								nRes = p.UFS_SetTemplateType(hScanner[0],2002); //2002 iso type
								break;
							case	2:
								nRes = p.UFS_SetTemplateType(hScanner[0],2003); //2003 ansi type
								break;	
						}
						
						
						nRes = p.UFS_ExtractEx(hScanner[0],MAX_TEMPLATE_SIZE,bTemplate,refTemplateSize,refTemplateQuality);
						
						
						if(nRes==0){
							
							setStatusMsg("UFS_ExtractEx success!! size:"+refTemplateSize[0]+"quality:"+refTemplateQuality[0]);

						}else{
							setStatusMsg("UFS_ExtractEx fail!! code:"+nRes);
							
							byte[] refErr = new byte[512];
							nRes = p.UFS_GetErrorString(nRes,refErr);
                                                        String strErr = new String(refErr);
							
							if(nRes ==0){
								setStatusMsg("==>UFS_GetErrorString err is "+strErr);
							}
						}
					}else{
						setStatusMsg("UFS_ExtractEx fail!! get current scanner handle fail!");
					}
				}
			});
			
			
		}
		return jButton_extractor;
	}

	/**
	 * This method initializes jComboBox_enroll	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_enroll() {
		if (jComboBox_enroll == null) {
			jComboBox_enroll = new JComboBox();
			jComboBox_enroll.setBounds(new Rectangle(129, 406, 46, 16));
						
			jComboBox_enroll.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
			        int  nSelectedIdx = Integer.parseInt((String)(jComboBox_enroll.getSelectedItem()));
			        
			        setStatusMsg("jComboBox_enroll selected :"+nSelectedIdx);
					
				}
			});
			
		}
		return jComboBox_enroll;
	}

	/**
	 * This method initializes jList_msg_log	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJList_msg_log() {
		if (jList_msg_log == null) {
			
			/*add*/
			listLogModel = new DefaultListModel();
			jList_msg_log = new JList(listLogModel);
			
			jList_msg_log.setBounds(new Rectangle(13, 476, 406, 66));
			
			jList_msg_log.setAutoscrolls(true);
			jList_msg_log.addListSelectionListener(new javax.swing.event.ListSelectionListener() {
						public void valueChanged(javax.swing.event.ListSelectionEvent e) {
							System.out.println("valueChanged()"); // TODO Auto-generated Event stub valueChanged()
						}
					});
		}
		return jList_msg_log;
	}

	/**
	 * This method initializes jComboBox_security_level	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_security_level() {
		if (jComboBox_security_level == null) {
			jComboBox_security_level = new JComboBox();
			jComboBox_security_level.setBounds(new Rectangle(353, 345, 121, 18));
						
			jComboBox_security_level.addActionListener(new java.awt.event.ActionListener() {
			
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
					int nSelectedIdx = jComboBox_security_level.getSelectedIndex(); 
					if (nSelectedIdx == -1) {
						return;
				    }
					
					//MsgBox("selected Idx:"+nSelectedIdx);
					
			        int[] pValue = new int[1];
					pValue[0] = nSelectedIdx+1;
					
										
					int nRes = p.UFM_SetParameter(hMatcher[0],p.UFM_PARAM_SECURITY_LEVEL,pValue); //302 : security level :UFM_
					if(nRes==0){
						setStatusMsg("Change combox-security level,302(security) value is "+pValue[0]);
					}else{
						setStatusMsg("Change combox-security level,change parameter value fail! code: "+nRes);
					}
					
				}
			});

		}
		return jComboBox_security_level;
	}

	/**
	 * This method initializes jCheckBox_fastmode	
	 * 	
	 * @return javax.swing.JCheckBox	
	 */
	private JCheckBox getJCheckBox_fastmode() {
		if (jCheckBox_fastmode == null) {
			jCheckBox_fastmode = new JCheckBox();
			jCheckBox_fastmode.setBounds(new Rectangle(262, 384, 91, 24));
			jCheckBox_fastmode.setText("Fast mode");
			
			
			jCheckBox_fastmode.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
						if(nInitFlag==0){
							MsgBox("initiate!");
							return;
						}
			
						int[] pValue = new int[1];
						long[] hScanner = new long[1];
						hScanner=GetCurrentScannerHandle();
						
						if(hScanner==null){
							setStatusMsg("getCurrentScannerHandle fail!! in checkbox-fastmode");
							return ;
						}
						 
						if(jCheckBox_fastmode.isSelected()){
			
						        //set parameter
								 
							    pValue[0] = 1;
																
								int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_USE_SIF,pValue); //301 : fast mode
								
								if(nRes==0){
										setStatusMsg("Change checkbox-fastmode core,301 value is "+pValue[0]);
								}else{
										setStatusMsg("Change checkbox-fastmode core,change parameter value fail! code: "+nRes);
								}
						
						}else{
			
						        //set parameter
								 
							    pValue[0] = 0;
																
								int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_USE_SIF,pValue); //301 : FAST mode
								
								if(nRes==0){
									setStatusMsg("Change checkbox-fastmode core,301 value is "+pValue[0]);
								}else{
									setStatusMsg("Change checkbox-fastmode core,change parameter value fail! code: "+nRes);
								}
						}
			
				}
			});
			
		}
		return jCheckBox_fastmode;
	}

	/**
	 * This method initializes jComboBox_enrollid	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_enrollid() {
		if (jComboBox_enrollid == null) {
			jComboBox_enrollid = new JComboBox();
			jComboBox_enrollid.setBounds(new Rectangle(315, 414, 59, 23));
			
			jComboBox_enrollid.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
			        int  nSelectedIdx = Integer.parseInt((String)(jComboBox_enrollid.getSelectedItem()));
			       					
				}
			});
	
		}
		return jComboBox_enrollid;
	}

	/**
	 * This method initializes jButton_verity	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_verity() {
		if (jButton_verity == null) {
			jButton_verity = new JButton();
			jButton_verity.setBounds(new Rectangle(393, 396, 83, 19));
			jButton_verity.setText("Verify");
			
			jButton_verity.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
								
					int nSelectedIdx = jComboBox_enrollid.getSelectedIndex(); 
				    
					if (nSelectedIdx == -1) {
				    	MsgBox("selet enroll id");
						return;
				    }
				   // MsgBox(" enroll id:"+nSelectedIdx + " place a finger");
				    
				    long[] hScanner =null;
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner==null){
						setStatusMsg("getCurrentScannerHandle fail!! ");
						return ;
					}
				    
					p.UFS_ClearCaptureImageBuffer(hScanner[0]);

				    setStatusMsg("Place a finger");
				    
					int nRes = p.UFS_CaptureSingleImage(hScanner[0]);
					
					if(nRes!=0){
						setStatusMsg("caputure single image fail!! "+nRes);
						return ;
					}
				
					byte[] bTemplate = new byte[MAX_TEMPLATE_SIZE];
					int[] refTemplateSize = new int[1];
					
					int[] refTemplateQuality = new int[1];
					
					int[] refVerify = new int[1];
					
					nRes = p.UFS_ExtractEx(hScanner[0],MAX_TEMPLATE_SIZE,bTemplate,refTemplateSize,refTemplateQuality);
					
					if(nRes==0){
						try{

							nRes = p.UFM_Verify(hMatcher[0], bTemplate, refTemplateSize[0], byteTemplateArray[nSelectedIdx], intTemplateSizeArray[nSelectedIdx], refVerify);//byte[][]
							
							if (nRes==0) {
								if(refVerify[0]==1){
									setStatusMsg("verify success!! enroll_id: "+(nSelectedIdx+1));
									MsgBox("verify success!! enroll_id: "+(nSelectedIdx+1));
									
								}else{
									setStatusMsg("verify fail!! enroll_id: "+(nSelectedIdx+1));
									MsgBox("verify fail!! enroll_id: "+(nSelectedIdx+1));
								}
							}else{
								setStatusMsg("verify fail!! "+nRes);
															
								byte[] refErr = new byte[512];
								nRes = p.UFM_GetErrorString(nRes,refErr);
                                                                String strErr = new String(refErr);
								if(nRes ==0){
									setStatusMsg("==>UFM_GetErrorString err is "+strErr);
									MsgBox("==>UFM_GetErrorString err is "+strErr);
								}
								
							}
						}catch(Exception ex){
							
						}
						
					}else{
						setStatusMsg("extract template fail!! "+nRes);
						
					}
				}
			});
			
		}
		return jButton_verity;
	}

	/**
	 * This method initializes jButton_Identify	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_Identify() {
		if (jButton_Identify == null) {
			jButton_Identify = new JButton();
			jButton_Identify.setBounds(new Rectangle(393, 421, 83, 20));
			jButton_Identify.setText("Identify");
			
			jButton_Identify.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
								
					long[] hScanner = new long[1];
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner==null){
						setStatusMsg("getCurrentScannerHandle fail!! ");
						return ;
					}
				    
					p.UFS_ClearCaptureImageBuffer(hScanner[0]);

				    setStatusMsg("Place a finger");
				    
					int nRes = p.UFS_CaptureSingleImage(hScanner[0]);
					
					if(nRes!=0){
						setStatusMsg("caputure single image fail!! "+nRes);
						return;
					}
				
					byte[] bTemplate = new byte[1024];
					
					int[] refTemplateSize = new int[1];
					int[] refTemplateQuality = new int[1];
										
					nRes = p.UFS_ExtractEx(hScanner[0],MAX_TEMPLATE_SIZE,bTemplate,refTemplateSize,refTemplateQuality);
					
					if(nRes==0){

						p.UFM_IdentifyInit(hMatcher[0], bTemplate, refTemplateSize[0]);

						int nMatchResult=0;
						int[] refIdentifyRes = new int[1];
						int i=0;
						
						for(i=0;i<nTemplateCnt;i++){
							
							nRes = p.UFM_IdentifyNext(hMatcher[0], byteTemplateArray[i], intTemplateSizeArray[i], refIdentifyRes);
							
							if (nRes==0) {
								if(refIdentifyRes[0]==1){
									setStatusMsg("Identfy success!!  match index number:"+(i+1));
									MsgBox("Identfy success!! index number:" + (i+1));
									nMatchResult=1;
									break; 
								}else{
									
								}
							}
						}
							
						if(nMatchResult!=1){
							MsgBox("Identfy fail!!");
						}

					}else{
						setStatusMsg("extract template fail!! "+nRes);
						MsgBox("Identfy fail!!");
						return;
					}
					
				}
			});
			
		}
		return jButton_Identify;
	}

	/**
	 * This method initializes jButton_enroll	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_enroll() {
		if (jButton_enroll == null) {
			jButton_enroll = new JButton();
			jButton_enroll.setBounds(new Rectangle(147, 442, 92, 20));
			jButton_enroll.setText("Enroll");
			
			jButton_enroll.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
					long[] hScanner = new long[1];
										
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
						
						int nRes = p.UFS_ClearCaptureImageBuffer(hScanner[0]);
						
						setStatusMsg("place a finger");
						
						nRes = p.UFS_CaptureSingleImage(hScanner[0]);
						
						setStatusMsg("capture single image");
						
						if(nRes ==0 ){
							
							byte[] bTemplate = new byte[MAX_TEMPLATE_SIZE];
							
							int[] refTemplateSize = new int[1];

							int[] refTemplateQuality = new int[1];
							try{							
								nRes = p.UFS_ExtractEx(hScanner[0],MAX_TEMPLATE_SIZE,bTemplate,refTemplateSize,refTemplateQuality);
								
								if(nRes==0){
								
									setStatusMsg("save template file template size:"+refTemplateSize[0]+" quality:"+refTemplateQuality[0]);
	
									int  nSelectedValue = Integer.parseInt((String)(jComboBox_enroll.getSelectedItem()));
									
									if(refTemplateQuality[0]<nSelectedValue){
										MsgBox("template quality < "+nSelectedValue);
										return;
									}
									
										if(nTemplateCnt>99){
											setStatusMsg("template queue full!! limited 100 template, now "+nTemplateCnt);
											MsgBox("template queue full!! limited 100 template, now "+nTemplateCnt);
											return;
										}
										
										int tempsize = refTemplateSize[0];
									
										System.arraycopy(bTemplate,0,byteTemplateArray[nTemplateCnt],0,refTemplateSize[0]);//byte[][]
																																				
										intTemplateSizeArray[nTemplateCnt]=refTemplateSize[0];
										
										setStatusMsg("eroll template array idx:"+nTemplateCnt + " template size:"+intTemplateSizeArray[nTemplateCnt]);
										
										nTemplateCnt++;
										
										drawCurrentFingerImage();
											
										String szComboData =null;
										szComboData=String.valueOf(nTemplateCnt);	
										
										jComboBox_enrollid.insertItemAt(szComboData,nTemplateCnt-1);
										
										jComboBox_enrollid.setSelectedIndex(nTemplateCnt-1);
										
										nCaptureFlag=1;
								
								}else{
									
								}
							}catch(Exception ex){
								
								//MsgBox("exception err:"+ex.getMessage());
							}
						}
			
					
						
					}else{
					 // scanner pointer  null	
					}
					
				}
			});
				
		}
		return jButton_enroll;
	}

	/**
	 * This method initializes jButton_save_tmp	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_save_tmp() {
		if (jButton_save_tmp == null) {
			jButton_save_tmp = new JButton();
			jButton_save_tmp.setBounds(new Rectangle(262, 443, 114, 21));
			jButton_save_tmp.setText("save template");
			
			
			jButton_save_tmp.addActionListener(new java.awt.event.ActionListener() {
				
				public void actionPerformed(java.awt.event.ActionEvent e) {
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
										
					int nSelectedIdx = jComboBox_enrollid.getSelectedIndex(); 
				    
					if (nSelectedIdx == -1) {
				    	MsgBox("enroll finger");
						return;
				    }
				    //MsgBox("idx:"+nSelectedIdx);
																					
					File file = null;
					String szPath = null;
						
					JFileChooser fc = new JFileChooser();
																		
					int returnVal = fc.showSaveDialog(demoUFEJavaJNI.this);

				    if (returnVal == JFileChooser.APPROVE_OPTION) {
				    	file = fc.getSelectedFile();
				            //This is where a real application would open the file.
				        setStatusMsg("saved: " + file.getName() );
				    } else {
				       setStatusMsg("saved command cancelled by user");
				       return;
				    }

				    szPath=file.getAbsolutePath();
						
				    //MsgBox(szPath);
    
							try
							{
																
								byte[] filebA = new byte[intTemplateSizeArray[nSelectedIdx]]; 
																						
								//array copy: (src,offset,target,offset,copy size)
								System.arraycopy(byteTemplateArray[nSelectedIdx],0,filebA,0,intTemplateSizeArray[nSelectedIdx]);//byte[][]
								//byteTemplateArray.getPointer().read(0,filebA,nTemplateCnt*MAX_TEMPLATE_SIZE,intTemplateSizeArray[nSelectedIdx]);
								
								RandomAccessFile rf = new RandomAccessFile (szPath, "rw");
								
								rf.write(filebA);
								rf.close();
								
								setStatusMsg("write template success,filename is "+szPath);
								MsgBox("write template success,filename is "+szPath);
								
							}
							catch (Exception ex)
							{
								MsgBox("save template file fail!! :"+ex.getMessage());
								setStatusMsg("write template fail err : "+ex.getMessage());
							}
			
				}
			});
			
		}
		return jButton_save_tmp;
	}

	/**
	 * This method initializes jButton_save_img	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_save_img() {
		if (jButton_save_img == null) {
			jButton_save_img = new JButton();
			jButton_save_img.setBounds(new Rectangle(380, 443, 106, 21));
			jButton_save_img.setText("save image");
			
			
			jButton_save_img.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}

					if(nCaptureFlag==0){
						return;
					}
					
					long[] hScanner = null;
					String szPath =null;
					
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
						
						File file = null;
						
						JFileChooser fc = new JFileChooser();
																		
						int returnVal = fc.showSaveDialog(demoUFEJavaJNI.this);

				        if (returnVal == JFileChooser.APPROVE_OPTION) {
				            file = fc.getSelectedFile();
				            //This is where a real application would open the file.
				            setStatusMsg("saved: " + file.getName() );
				        } else {
				            setStatusMsg("saved command cancelled by user");
				            return;
				        }

				        szPath=file.getAbsolutePath();
						
				        MsgBox(szPath);
						
						//int nRes = p.UFS_SaveCaptureImageBufferToBMP(hScanner[0],szPath );
                                        int nRes = p.UFS_SaveCaptureImageBufferTo19794_4(hScanner[0],szPath );
                                       

						if (nRes== 0) {
							
							MsgBox("Captured image is saved\r\n");
							
						}else{
							
						}
						
					}else{
						
					}

				}
			});
			
			
		}
		return jButton_save_img;
	}

	/**
	 * This method initializes jButton_clear	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButton_clear() {
		if (jButton_clear == null) {
			jButton_clear = new JButton();
			jButton_clear.setBounds(new Rectangle(422, 481, 66, 58));
			jButton_clear.setText("clear");
				
			jButton_clear.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					listLogModel.clear();
					nLogListCnt=0;
					
					/*test draw image*/
					int[] Resolution = new int[1];
					int[] Height     = new int[1];
					int[] Width      = new int[1];
					long[] hScanner = new long[1];
					
					hScanner=GetCurrentScannerHandle();
					
					int nRes = p.UFS_GetCaptureImageBufferInfo(hScanner[0], Width, Height, Resolution);
					
					byte[] pImageData = new byte[Width[0]*Height[0]];
					
					nRes = p.UFS_GetCaptureImageBuffer(hScanner[0],pImageData);
					
					/********image draw test *********/
					imgPanel.drawFingerImage(Width[0],Height[0],pImageData);
						
			     }
			});
		}
		return jButton_clear;
	}

	/**
	 * This method initializes jComboBox_bri	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_bri() {
		if (jComboBox_bri == null) {
			jComboBox_bri = new JComboBox();
			jComboBox_bri.setBounds(new Rectangle(80, 221, 50, 23));
			
						
			jComboBox_bri.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}
					
			        int  nSelectedIdx = Integer.parseInt((String)(jComboBox_bri.getSelectedItem()));
			        
			       // MsgBox("jComboBox_bri selected idx:"+nSelectedIdx);
			        
			        //set parameter
			        
			        int[] pValue = new int[1];
					pValue[0] = nSelectedIdx;
					
					long[] hScanner = new long[1];
															
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
					
						int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_BRIGHTNESS,pValue); //202 : birghtness parameter
						if(nRes==0){
							setStatusMsg("Change combox-brightness,202(brightness) value is "+pValue[0]);
						}else{
							setStatusMsg("Change combox-brightness,change parameter value fail! code: "+nRes);
						}
					}else{
						
						setStatusMsg("getCurrentScannerHandle fail!! in ChangeComboBox-brightness");
					}
					
				}
			});
			
		}
		return jComboBox_bri;
	}

	/**
	 * This method initializes jComboBox_sens	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	
	private JComboBox getJComboBox_sens() {
		if (jComboBox_sens == null) {
			jComboBox_sens = new JComboBox();
			jComboBox_sens.setBounds(new Rectangle(80, 248, 50, 23));
				
			jComboBox_sens.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					
					if(nInitFlag==0){
						MsgBox("initiate!");
						return;
					}

			        int  nSelectedIdx = Integer.parseInt((String)(jComboBox_sens.getSelectedItem()));
			        
			       // MsgBox("jComboBox_sens selected idx:"+nSelectedIdx);
					
			        //set parameter
			        
			        int[] pValue = new int[1];
					pValue[0] = nSelectedIdx;
					
                                        long[] hScanner = new long[1];
															
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
					
						int nRes = p.UFS_SetParameter(hScanner[0],p.UFS_PARAM_SENSITIVITY,pValue); //203 : sensitivity parameter
						if(nRes==0){
							setStatusMsg("Change combox-sensitivity,203(sensitivity) value is "+pValue[0]);
						}else{
							setStatusMsg("Change combox-sensitivity,change parameter value fail! code: "+nRes);
						}
					}else{
						
						setStatusMsg("getCurrentScannerHandle fail!! in ChangeComboBox-sensitivity");
					}
				}
			});

		}
		return jComboBox_sens;
	}

	/**
	 * This method initializes jFingerInfo	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJFingerInfo() {
		if (jFingerInfo == null) {
			jFingerInfo = new JTextField();
			jFingerInfo.setBounds(new Rectangle(262, 283, 202, 18));
			jFingerInfo.setBounds(new Rectangle(267, 279, 202, 18));
		}
		return jFingerInfo;
	}

	/**
	 * This method initializes jComboBox_ScanType	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_ScanType() {
		if (jComboBox_ScanType == null) {
			jComboBox_ScanType = new JComboBox();
			jComboBox_ScanType.setBounds(new Rectangle(108, 285, 112, 20));
			jComboBox_ScanType.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					
					int  nSelectedIdx = jComboBox_ScanType.getSelectedIndex();
					int nRes;
					long[] hScanner = new long[1];
					hScanner=GetCurrentScannerHandle();
					
					if(hScanner!=null){
						switch(nSelectedIdx){
						
							case	0:
								nRes = p.UFS_SetTemplateType(hScanner[0],2001); //2001 Suprema type
								break;
							case	1:
								nRes = p.UFS_SetTemplateType(hScanner[0],2002); //2002 iso type
								break;
							case	2:
								nRes = p.UFS_SetTemplateType(hScanner[0],2003); //2003 ansi type
								break;	
						}
					}
				}
			});
		}
		return jComboBox_ScanType;
	}

	/**
	 * This method initializes jComboBox_MatchType	
	 * 	
	 * @return javax.swing.JComboBox	
	 */
	private JComboBox getJComboBox_MatchType() {
		if (jComboBox_MatchType == null) {
			jComboBox_MatchType = new JComboBox();
			jComboBox_MatchType.setBounds(new Rectangle(354, 369, 119, 19));
			jComboBox_MatchType.addActionListener(new java.awt.event.ActionListener() {
				public void actionPerformed(java.awt.event.ActionEvent e) {
					System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					
					int  nSelectedIdx = jComboBox_MatchType.getSelectedIndex();
					int nRes;
										
					if(hMatcher!=null){
						switch(nSelectedIdx){
						
							case	0:
								nRes = p.UFM_SetTemplateType(hMatcher[0],2001); //2001 Suprema type
								
								break;
							case	1:
								nRes = p.UFM_SetTemplateType(hMatcher[0],2002); //2002 iso type
								
								break;
							case	2:
								nRes = p.UFM_SetTemplateType(hMatcher[0],2003); //2003 ansi type
								
								break;	
						}
					}
				}
			});
		}
		return jComboBox_MatchType;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				demoUFEJavaJNI thisClass = new demoUFEJavaJNI();
				thisClass.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
				thisClass.setVisible(true);
                                pMainInstance = thisClass;
			}
		});
	}

	/**
	 * This is the default constructor
	 */
	public demoUFEJavaJNI() {
		super();
                p = new BioMiniJniSDK();
		initialize();	
	}
	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize() {
		this.setSize(545, 621);
		this.setContentPane(getJContentPane());
		this.setTitle("Suprema PC SDK Demo (JAVA SWING)");
		this.setContentPane(getJContentPane());
        }

	class ImagePanel extends JPanel
	{
		//private PlanarImage image;
		private BufferedImage buffImage=null;
		
		private void drawFingerImage(int nWidth,int nHeight,byte[] buff) 
		{
			buffImage = new BufferedImage(nWidth, nHeight, BufferedImage.TYPE_BYTE_GRAY);
			buffImage.getRaster().setDataElements(0, 0, nWidth, nHeight, buff);
			
			Graphics g = buffImage.createGraphics();
			//g.drawImage(buffImage, 0, 0, nWidth, nHeight, null);
                        g.drawImage(buffImage, 0, 0, imgPanel.getWidth(), imgPanel.getHeight(), imgPanel);
			g.dispose();
			repaint();
		}
				
                public void paint(Graphics g)
		{
                    g.drawImage(buffImage, 0, 0, this);
		}

	}
	/**
	 * This method initializes jContentPane
	 * 
	 * @return javax.swing.JPanel
	 */
	private JPanel getJContentPane() {
		if (jContentPane == null) {
			jLabel1 = new JLabel();
			jLabel1.setBounds(new Rectangle(258, 373, 91, 13));
			jLabel1.setText("TemplateType");
			jLabel = new JLabel();
			jLabel.setBounds(new Rectangle(16, 286, 89, 21));
			jLabel.setText("TemplateType");
			jLabel_scanner_list = new JLabel();
			jLabel_scanner_list.setBounds(new Rectangle(15, 44, 72, 18));
			jLabel_scanner_list.setText("Scanner List");
			jLabel_enrollid = new JLabel();
			jLabel_enrollid.setBounds(new Rectangle(264, 416, 46, 18));
			jLabel_enrollid.setText("Enroll ID");
			jLabel_security_levle = new JLabel();
			jLabel_security_levle.setBounds(new Rectangle(262, 345, 80, 18));
			jLabel_security_levle.setText("Security Level");
			jLabel_match = new JLabel();
			jLabel_match.setBounds(new Rectangle(263, 327, 35, 18));
			jLabel_match.setText("Match");
			jLabel_sense1 = new JLabel();
			jLabel_sense1.setBounds(new Rectangle(17, 325, 106, 16));
			jLabel_sense1.setText("Enroll");
			jLabel_parameter = new JLabel();
			jLabel_parameter.setBounds(new Rectangle(13, 173, 111, 18));
			jLabel_parameter.setText("Scanner parameter");
			jLabel_enroll = new JLabel();
			jLabel_enroll.setBounds(new Rectangle(16, 406, 106, 16));
			jLabel_enroll.setText("Enroll Quallity (%s)");
			jLabel_sense = new JLabel();
			jLabel_sense.setBounds(new Rectangle(15, 248, 62, 18));
			jLabel_sense.setText("Sensitivity");
			jLabel_brightness = new JLabel();
			jLabel_brightness.setBounds(new Rectangle(15, 220, 62, 18));
			jLabel_brightness.setText("Birghtness");
			jLabel_timeout = new JLabel();
			jLabel_timeout.setBounds(new Rectangle(15, 197, 46, 18));
			jLabel_timeout.setText("Timeout");
                        jLabel_detect_fake = new JLabel();
			jLabel_detect_fake.setBounds(new Rectangle(135, 197, 70, 18));
			jLabel_detect_fake.setText("Fake Detect");
			jContentPane = new JPanel();
			
			jContentPane.setLayout(null);
			jContentPane.add(getJButton_ufe_init(), null);
			jContentPane.add(getJList(), null);
			jContentPane.add(getJButton_caputure_single(), null);
			jContentPane.add(getJTextField_status(), null);
			jContentPane.add(getJButton_update(), null);
			jContentPane.add(getJButton_Uninit(), null);
			jContentPane.add(getJComboBox_timeout(), null);
			jContentPane.add(jLabel_timeout, null);
                        jContentPane.add(getJComboBox_detect_fake(), null);
			jContentPane.add(jLabel_detect_fake, null);
			jContentPane.add(jLabel_brightness, null);
			jContentPane.add(jLabel_sense, null);
			jContentPane.add(getJButton_start_capturing(), null);
			jContentPane.add(getJButton_abort(), null);
			jContentPane.add(getJButton_extractor(), null);
			jContentPane.add(jLabel_enroll, null);
			jContentPane.add(getJComboBox_enroll(), null);
			jContentPane.add(jLabel_parameter, null);
			jContentPane.add(getJList_msg_log(), null);
			jContentPane.add(jLabel_sense1, null);
			jContentPane.add(jLabel_match, null);
			jContentPane.add(jLabel_security_levle, null);
			jContentPane.add(getJComboBox_security_level(), null);
			jContentPane.add(getJCheckBox_fastmode(), null);
			jContentPane.add(jLabel_enrollid, null);
			jContentPane.add(getJComboBox_enrollid(), null);
			jContentPane.add(getJButton_verity(), null);
			jContentPane.add(getJButton_Identify(), null);
			jContentPane.add(getJButton_enroll(), null);
			jContentPane.add(getJButton_save_tmp(), null);
			jContentPane.add(getJButton_save_img(), null);
			jContentPane.add(jLabel_scanner_list, null);
			jContentPane.add(getJButton_clear(), null);
			jContentPane.add(getImagePanel(),null);
			jContentPane.add(getJList1_scanner_list(), null);
			jContentPane.add(listScrollPane,null);
			jContentPane.add(getJComboBox_bri(), null);
			jContentPane.add(getJComboBox_sens(), null);
			jContentPane.add(getJFingerInfo(), null);
			jContentPane.add(getJComboBox_ScanType(), null);
			jContentPane.add(getJComboBox_MatchType(), null);
			jContentPane.add(jLabel, null);
			jContentPane.add(jLabel1, null);
			
		}
		return jContentPane;
	}

}  //  @jve:decl-index=0:visual-constraint="6,-4"
