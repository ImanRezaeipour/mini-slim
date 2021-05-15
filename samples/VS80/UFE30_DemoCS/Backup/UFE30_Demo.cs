using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Suprema;

namespace Suprema {
	public partial class UFE30_Demo : Form {
		//=========================================================================//
		UFScannerManager m_ScannerManager;
		UFMatcher m_Matcher;
		string m_strError;
		byte[][] m_template1;
		int[] m_template_size1;
        byte[][] m_template2;
        int[] m_template_size2;
        int m_template_num;
        string[] m_UserID;
        int m_quality;
        int m_nType;
		//
		const int MAX_TEMPLATE_SIZE = 1024;
		const int MAX_TEMPLATE_NUM	= 50;

        const int  MAX_USERID_SIZE          = 10;
        const int  MAX_TEMPLATE_INPUT_NUM	= 4;
        const int  MAX_TEMPLATE_OUTPUT_NUM	= 2;

        const int FINGERDATA_COL_SERIAL = 0;
        const int FINGERDATA_COL_USERID = 1;
        const int FINGERDATA_COL_TEMPLATE1 = 2;
        const int FINGERDATA_COL_TEMPLATE2 = 3;

		public UFE30_Demo() {
			InitializeComponent();
		}

		private void UFE30_Demo_Load(object sender, EventArgs e) {
			int i;

			// Set initial values
            cbSecurityLevel.SelectedIndex = 3;
            cbQuality.SelectedIndex = 5;

			m_template1 = new byte[MAX_TEMPLATE_NUM][];
            m_template2 = new byte[MAX_TEMPLATE_NUM][];
			for (i = 0; i < MAX_TEMPLATE_NUM; i++) {
				m_template1[i] = new byte[MAX_TEMPLATE_SIZE];
                m_template2[i] = new byte[MAX_TEMPLATE_SIZE];
			}
			m_template_size1 = new int[MAX_TEMPLATE_NUM];
            m_template_size2 = new int[MAX_TEMPLATE_NUM];

			m_template_num = 0;
            m_UserID = new string[MAX_TEMPLATE_NUM];

            m_quality = 40;

			m_ScannerManager = new UFScannerManager(this);

            lvFingerDataList.Columns.Add("Serial", 50, HorizontalAlignment.Left);
            lvFingerDataList.Columns.Add("UserID", 60, HorizontalAlignment.Left);
            lvFingerDataList.Columns.Add("Template1", 74, HorizontalAlignment.Left);
            lvFingerDataList.Columns.Add("Template2", 74, HorizontalAlignment.Left);

            rbtnOneTemplateNormal.Checked = true;
 		}

		private void UFE30_Demo_FormClosing(object sender, FormClosingEventArgs e) {
			btnUninit_Click(sender, e);
		}
		//=========================================================================//

		//=========================================================================//
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UFE30_Demo());
		}
		//=========================================================================//

		//=========================================================================//
        private void AddRow(int Serial, string UserID, bool bTemplate1, bool bTemplate2)
        {
            ListViewItem listItem = lvFingerDataList.Items.Add(Convert.ToString(Serial));
            listItem.SubItems.Add(UserID);
            listItem.SubItems.Add((bTemplate1) ? "O" : "X");
            listItem.SubItems.Add((bTemplate2) ? "O" : "X");
        }

        private void UpdateFingerDataList()
        {
            int i;

            lvFingerDataList.Items.Clear();

            for (i = 0; i < m_template_num; i++)
            {
                AddRow(i, m_UserID[i], (m_template_size1[i] != 0), (m_template_size2[i] != 0));
            }
        }

		private void GetScannerTypeString(UFS_SCANNER_TYPE ScannerType, out string strScannerType)
		{
			if (ScannerType == UFS_SCANNER_TYPE.SFR200) {
				strScannerType = "SFR200";
			} else if (ScannerType == UFS_SCANNER_TYPE.SFR300) {
				strScannerType = "SFR300";
			} else if (ScannerType == UFS_SCANNER_TYPE.SFR300v2) {
				strScannerType = "SFR300v2";
            } else if (ScannerType == UFS_SCANNER_TYPE.SFR500) {
                strScannerType = "BioMini Plus";
            } else if (ScannerType == UFS_SCANNER_TYPE.SFR600) {
                strScannerType = "BioMini SLIM";
            }
            else
            {
				strScannerType = "Error";
			}
		}

        private bool GetGetCurrentScanner(out UFScanner Scanner)
        {
			Scanner = m_ScannerManager.Scanners[lbScannerList.SelectedIndex];
			if (Scanner != null) {
				return true;
			} else {
				tbxMessage.AppendText("Selected Scanner is not connected\r\n");
				return false;
			}
        }

		private void GetCurrentScannerSettings()
		{
			UFScanner Scanner;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}
			
			// Unit of timeout is millisecond
			cbTimeout.SelectedIndex = Scanner.Timeout / 1000;

			nudBrightness.Minimum = 0;
			nudBrightness.Maximum = 255;
			nudBrightness.Value = Scanner.Brightness;

			nudSensitivity.Minimum = 0;
			nudSensitivity.Maximum = 7;
			nudSensitivity.Value = Scanner.Sensitivity;

			cbDetectCore.Checked = Scanner.DetectCore;
		}

		private void GetMatcherSettings(UFMatcher Matcher)
		{
			// Security level ranges from 1 to 7
			cbSecurityLevel.SelectedIndex = Matcher.SecurityLevel - 1;

			cbFastMode.Checked = Matcher.FastMode;
		}

		private void DrawCapturedImage(UFScanner Scanner)
		{
			Graphics g = pbImageFrame.CreateGraphics();
			Rectangle rect = new Rectangle(0, 0, pbImageFrame.Width, pbImageFrame.Height);
			try {
				//
                Scanner.DrawCaptureImageBuffer(g, rect, cbDetectCore.Checked);
				//
				//Bitmap bitmap;
				//int Resolution;
				//Scanner.GetCaptureImageBuffer(out bitmap, out Resolution);
				//pbImageFrame.Image = bitmap;
			}
			finally {
				g.Dispose();
			}
		}
		//=========================================================================//

		//=========================================================================//
		private void lbScannerList_SelectedValueChanged(object sender, EventArgs e) {
            GetCurrentScannerSettings();
		}

        private void cbTimeout_SelectedIndexChanged(object sender, EventArgs e) {
			UFScanner Scanner;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}
			// Unit of timeout is millisecond
            Scanner.Timeout = cbTimeout.SelectedIndex * 1000;
        }

        private void nudBrightness_ValueChanged(object sender, EventArgs e) {
			UFScanner Scanner;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}
            Scanner.Brightness = (int)nudBrightness.Value;
        }

        private void nudSensitivity_ValueChanged(object sender, EventArgs e) {
			UFScanner Scanner;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}
			Scanner.Sensitivity = (int)nudSensitivity.Value;
        }

        private void cbDetectCore_CheckedChanged(object sender, EventArgs e) {
			UFScanner Scanner;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}
			Scanner.DetectCore = cbDetectCore.Checked;
        }

		private void cbSecurityLevel_SelectedIndexChanged(object sender, EventArgs e) {
			if (m_Matcher != null) {
				// Security level ranges from 1 to 7
				m_Matcher.SecurityLevel = cbSecurityLevel.SelectedIndex + 1;
			}
		}

         private void cbScanTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_template_num > 0 && m_nType != cbScanTemplateType.SelectedIndex)
            {
                tbxMessage.AppendText("It is not allowed to mix template format \r\nPlease remove all templates if you want to use other template format\r\n");
                cbScanTemplateType.SelectedIndex = m_nType;
                return;
            }

            m_nType = cbScanTemplateType.SelectedIndex;
            
            UFScanner Scanner;
            if (!GetGetCurrentScanner(out Scanner))
            {
                return;
            }

            switch (this.cbScanTemplateType.SelectedIndex)
            {
                case 0:
                    Scanner.nTemplateType = 2001;
                    break;
                case 1:
                    Scanner.nTemplateType = 2002;
                    break;
                case 2:
                    Scanner.nTemplateType = 2003;
                    break;
                }
        }

 		private void cbFastMode_CheckedChanged(object sender, EventArgs e) {
			if (m_Matcher != null) {
				m_Matcher.FastMode = cbFastMode.Checked;
			}
		}

		private void btnClear_Click(object sender, EventArgs e) {
			tbxMessage.Clear();
		}
		//=========================================================================//

		//=========================================================================//
		private void UpdateScannerList()
		{
			int nScannerNumber;

			nScannerNumber = m_ScannerManager.Scanners.Count;

			lbScannerList.Items.Clear();

			for (int i = 0; i < nScannerNumber; i++) {
				UFScanner Scanner;
				UFS_SCANNER_TYPE ScannerType;
				string strScannerType;
				string strID;
				string str_tmp;

				Scanner = m_ScannerManager.Scanners[i];

				tbxMessage.AppendText("Scanner " + i + " serial: " + Scanner.Serial + "\r\n");

				ScannerType = Scanner.ScannerType;
				strID = Scanner.ID;
				GetScannerTypeString(ScannerType, out strScannerType);

				str_tmp = i + ": " + strScannerType + " " + strID;
				lbScannerList.Items.Add(str_tmp);
			}

			if (nScannerNumber > 0) {
				lbScannerList.SetSelected(0, true);
				GetCurrentScannerSettings();
			}
		}

		public void ScannerEvent(object sender, UFScannerManagerScannerEventArgs e)
		{
			if (e.SensorOn) {
				UpdateScannerList();
			} else {
				UpdateScannerList();
			}
		}

		private void btnInit_Click(object sender, EventArgs e) {
			//=========================================================================//
			// Initilize scanners
			//=========================================================================//
			UFS_STATUS ufs_res;
			int nScannerNumber;

			Cursor.Current = Cursors.WaitCursor;
			ufs_res = m_ScannerManager.Init();
			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner Init: OK\r\n");
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner Init: " + m_strError + "\r\n");
                Cursor.Current = this.Cursor;
				return;
			}
            
			m_ScannerManager.ScannerEvent += new UFS_SCANNER_PROC(ScannerEvent);

			nScannerNumber = m_ScannerManager.Scanners.Count;
			tbxMessage.AppendText("UFScanner GetScannerNumber: " + nScannerNumber + "\r\n");

			UpdateScannerList();
            
            if (cbScanTemplateType.SelectedIndex == -1) {
                cbScanTemplateType.SelectedIndex = 1;
                m_nType = 1;
            }
			//=========================================================================//
            
			//=========================================================================//
			// Create matcher
			//=========================================================================//
			m_Matcher = new UFMatcher();

            if (m_Matcher.InitResult == UFM_STATUS.OK)
                tbxMessage.AppendText("UFMatcher Init: OK\r\n");
            else
            {
                UFMatcher.GetErrorString(m_Matcher.InitResult, out m_strError);
                tbxMessage.AppendText("UFMatcher Init: " + m_strError + "\r\n");
            }	

			GetMatcherSettings(m_Matcher);
			//=========================================================================//
            Cursor.Current = this.Cursor;
		}

		private void btnUpdate_Click(object sender, EventArgs e) {
			UFS_STATUS ufs_res;

			Cursor.Current = Cursors.WaitCursor;
			ufs_res = m_ScannerManager.Update();
			Cursor.Current = this.Cursor;

			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner Update: OK\r\n");
				UpdateScannerList();
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner Update: " + m_strError + "\r\n");
			}	
		}

		private void btnUninit_Click(object sender, EventArgs e) {
			//=========================================================================//
			// Uninit Scanners
			//=========================================================================//
			UFS_STATUS ufs_res;
			
			Cursor.Current = Cursors.WaitCursor;
			ufs_res = m_ScannerManager.Uninit();
			Cursor.Current = this.Cursor;
			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner Uninit: OK\r\n");
				m_ScannerManager.ScannerEvent -= ScannerEvent;
				lbScannerList.Items.Clear();
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner Uninit: " + m_strError + "\r\n");
			}

			pbImageFrame.Image = null;
			//=========================================================================//
		}

		private delegate void _UpdatePictureBox(PictureBox pbox, Bitmap image);

		public void UpdatePictureBox(PictureBox pbox, Image image) 
		{
			if (pbox.InvokeRequired) {
				_UpdatePictureBox del = new _UpdatePictureBox(UpdatePictureBox);
				// Call the function in the correct thread
				BeginInvoke(del, new object[] { pbox, image });
			} else {
				// We are in the correct thread, so assign the image
				pbox.Image = image;
				//System.Threading.Thread.Sleep(100);
			}
		}

		public int CaptureEvent(object sender, UFScannerCaptureEventArgs e)
		{
			// We cannot use pbImageFrame.Image directly from the different thread,
			// so we use UpdatePictureBox() to update PictureBox indirectly
			UpdatePictureBox(pbImageFrame, e.ImageFrame);

            return 1;
		}

        private void btnStartCapturing_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}

			Scanner.CaptureEvent += new UFS_CAPTURE_PROC(CaptureEvent);
	        ufs_res = Scanner.StartCapturing();
	        if (ufs_res == UFS_STATUS.OK) {
		        tbxMessage.AppendText("UFScanner StartCapturing: OK\r\n");
	        } else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner StartCapturing: " + m_strError + "\r\n");
	        }
        }

        private void btnAutoCapture_Click(object sender, EventArgs e)
        {
            UFScanner Scanner;
            UFS_STATUS ufs_res;
            if (!GetGetCurrentScanner(out Scanner))
            {
                return;
            }

            Scanner.CaptureEvent += new UFS_CAPTURE_PROC(CaptureEvent);
            ufs_res = Scanner.StartAutoCapture();
            if (ufs_res == UFS_STATUS.OK)
            {
                tbxMessage.AppendText("UFScanner StartAutoCapture: OK\r\n");
            }
            else
            {
                UFScanner.GetErrorString(ufs_res, out m_strError);
                tbxMessage.AppendText("UFScanner StartAutoCapture: " + m_strError + "\r\n");
            }
        }

		private void btnAbortCapturing_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}

	        ufs_res = Scanner.AbortCapturing();
	        if (ufs_res == UFS_STATUS.OK) {
		        tbxMessage.AppendText("UFScanner AbortCapturing: OK\r\n");
	        } else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner AbortCapturing: " + m_strError + "\r\n");
	        }
		}

		private void btnCaptureSingle_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}

            Cursor.Current = Cursors.WaitCursor;
	        ufs_res = Scanner.CaptureSingleImage();
			Cursor.Current = this.Cursor;
            
	        if (ufs_res == UFS_STATUS.OK) {
		        tbxMessage.AppendText("UFScanner CaptureSingleImage: OK\r\n");
				DrawCapturedImage(Scanner);
	        } else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
	        }
		}

		private void btnExtract_Click(object sender, EventArgs e) {
            UFScanner Scanner;
			UFS_STATUS ufs_res;
			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}

			Scanner.TemplateSize = MAX_TEMPLATE_SIZE;
			Scanner.DetectCore = cbDetectCore.Checked;

			byte[] Template = new byte[MAX_TEMPLATE_SIZE];
			int TemplateSize;
			int EnrollQuality;

            Cursor.Current = Cursors.WaitCursor;
	        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, out TemplateSize, out EnrollQuality);
			Cursor.Current = this.Cursor;

			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner ExtractEx: OK\r\n");
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner ExtractEx: " + m_strError + "\r\n");
			}	
		}

		private void btnEnroll_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;
			int EnrollQuality;
            int EnrollMode;
            int template_enrolled = 0;
            bool fingeron;

			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}

            switch (this.cbScanTemplateType.SelectedIndex) {
                case 0:
                    Scanner.nTemplateType = 2001;
                    break;
                case 1:
                    Scanner.nTemplateType = 2002;
                    break;
                case 2:
                    Scanner.nTemplateType = 2003;
                    break;
            }

            EnrollMode = rbtnOneTemplateAdvanced.Checked ? 1 : 2;

            UFE30_UserInfo udlg = new UFE30_UserInfo();
  
            tbxMessage.AppendText("Input user data\r\n");

            if (udlg.ShowDialog(this) != DialogResult.OK) {
                tbxMessage.AppendText("User data input is cancelled by user\r\n");
                return;
            }

            Refresh();

            //Enroll Template with Non-Advanced-Extraction   
            if (rbtnOneTemplateNormal.Checked == true || rbtnOneTemplateNormal2.Checked == true) {
                Scanner.ClearCaptureImageBuffer();
                tbxMessage.AppendText("Place Finger\r\n");

                while (true) {
                    ufs_res = Scanner.CaptureSingleImage();
                    if (ufs_res != UFS_STATUS.OK) {
                        UFScanner.GetErrorString(ufs_res, out m_strError);
                        tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
                        return;
                    }

                    if (m_template_num + 1 == MAX_TEMPLATE_NUM) {
                        tbxMessage.AppendText("Template memory is full\r\n");
                        return;
                    }

                    if(template_enrolled == 0)
                        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, m_template1[m_template_num], out m_template_size1[m_template_num], out EnrollQuality);
                    else
                        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, m_template2[m_template_num], out m_template_size2[m_template_num], out EnrollQuality);

                    DrawCapturedImage(Scanner);

                    if (ufs_res == UFS_STATUS.OK) {
                        if (EnrollQuality < m_quality) {
                            tbxMessage.AppendText("Too low quality [Q:" + EnrollQuality + "]\r\n");
                        }
                        else {   
                            m_UserID[m_template_num] = udlg.UserID;
                            template_enrolled++;
                            tbxMessage.AppendText("Enrollment success (No." + m_template_num + ") [Q:" + EnrollQuality + "]\r\n");

                            if (rbtnOneTemplateNormal.Checked == true) {
                                m_template_num++;
                                UpdateFingerDataList();
                                break;
                            }
                            else if (rbtnOneTemplateNormal2.Checked == true && template_enrolled == 2) {
                                m_template_num++;
                                UpdateFingerDataList();
                                break;
                            }
                            else {
                                tbxMessage.AppendText("Remove finger\r\n");
                                while (true) {
                                    fingeron = Scanner.IsFingerOn;
                                    if (fingeron == false) {
                                        tbxMessage.AppendText("Place a finger\r\n");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        UFScanner.GetErrorString(ufs_res, out m_strError);
                        tbxMessage.AppendText("UFScanner Extract: " + m_strError + "\r\n");
                    }

                }
            }
            //Enroll with Advanced-Extraction
            else {
                UFE30_Enroll dlg = new UFE30_Enroll();

                dlg.hScanner = Scanner;
                dlg.UserID = udlg.UserID;
                dlg.OutputNum = EnrollMode;
                dlg.Quality = m_quality;

                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    tbxMessage.AppendText("Fingerprint enrollment is cancelled by user\r\n");
                    return;
                }

                if (dlg.EnrollTemplateOutputSize[0] != 0) {
		            if (m_template_num+1 == MAX_TEMPLATE_NUM) {
                        tbxMessage.AppendText("Template memory is full\r\n");
		            } else {
			            //Enroll 1-Template
			            if(EnrollMode == 1) {
                            System.Array.Copy(dlg.EnrollTemplateOutput[0], 0, m_template1[m_template_num], 0, dlg.EnrollTemplateOutputSize[0]);
                            m_template_size1[m_template_num] = dlg.EnrollTemplateOutputSize[0];
                            m_UserID[m_template_num] = udlg.UserID;
			            } 
			            //Enroll 2-Template
			            else {
                            System.Array.Copy(dlg.EnrollTemplateOutput[0], 0, m_template1[m_template_num], 0, dlg.EnrollTemplateOutputSize[0]);
                            m_template_size1[m_template_num] = dlg.EnrollTemplateOutputSize[0];
                            System.Array.Copy(dlg.EnrollTemplateOutput[1], 0, m_template2[m_template_num], 0, dlg.EnrollTemplateOutputSize[1]);
                            m_template_size2[m_template_num] = dlg.EnrollTemplateOutputSize[1];
                            m_UserID[m_template_num] = udlg.UserID;
			            }

                        tbxMessage.AppendText("Enrollment is succeed (No." + m_template_num + ")\r\n");
			            m_template_num++;
		            }
		            UpdateFingerDataList();
	            } else {
                    tbxMessage.AppendText("Enrollment is failed\r\n");
	            }
        		
                Scanner.Timeout = cbTimeout.SelectedIndex * 1000;
            }
        
		}

		private void btnVerify_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;
			UFM_STATUS ufm_res;
			byte[] Template = new byte[MAX_TEMPLATE_SIZE];
			int TemplateSize;
			int EnrollQuality;
			bool VerifySucceed;
            int Serial;

            if (lvFingerDataList.SelectedIndices.Count == 0) {
                tbxMessage.AppendText("Select data\r\n");
                return;
            }
            else {
                Serial = Convert.ToInt32(lvFingerDataList.SelectedItems[0].SubItems[FINGERDATA_COL_SERIAL].Text);
            }

			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}
            tbxMessage.AppendText("Verify with serial: " + Serial + "\r\n");

			Scanner.ClearCaptureImageBuffer();

			tbxMessage.AppendText("Place Finger\r\n");

			ufs_res = Scanner.CaptureSingleImage();
			if (ufs_res != UFS_STATUS.OK) {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
				return;
			}

            switch (this.cbScanTemplateType.SelectedIndex)
            {
                case 0:
                    Scanner.nTemplateType = 2001;
                    break;
                case 1:
                    Scanner.nTemplateType = 2002;
                    break;
                case 2:
                    Scanner.nTemplateType = 2003;
                    break;
            }

            ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, out TemplateSize, out EnrollQuality);
			if (ufs_res == UFS_STATUS.OK) {
				DrawCapturedImage(Scanner);
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner ExtractEx: " + m_strError + "\r\n");
				return;
			}

            switch (this.cbScanTemplateType.SelectedIndex) {
                case 0:
                    m_Matcher.nTemplateType = 2001;
                    break;
                case 1:
                    m_Matcher.nTemplateType = 2002;
                    break;
                case 2:
                    m_Matcher.nTemplateType = 2003;
                    break;
            }

            ufm_res = m_Matcher.Verify(Template, TemplateSize, m_template1[Serial], m_template_size1[Serial], out VerifySucceed);
			if (ufm_res != UFM_STATUS.OK) {
				UFMatcher.GetErrorString(ufm_res, out m_strError);
				tbxMessage.AppendText("UFMatcher Verify: " + m_strError + "\r\n");
				return;
			}

			if (VerifySucceed) {
                tbxMessage.AppendText("Verification succeed (Serial." + Serial + ") (ID." + m_UserID[Serial] + ")\r\n");
			} else {
                if (m_template_size2[Serial] != 0) {
                    ufm_res = m_Matcher.Verify(Template, TemplateSize, m_template2[Serial], m_template_size2[Serial], out VerifySucceed);
                    if (ufm_res != UFM_STATUS.OK) {
                        UFMatcher.GetErrorString(ufm_res, out m_strError);
                        tbxMessage.AppendText("UFMatcher Verify: " + m_strError + "\r\n");
                        return;
                    }

                    if (VerifySucceed) {
                        tbxMessage.AppendText("Verification succeed (Serial." + Serial + ") (ID." + m_UserID[Serial] + ")\r\n");
                    }
                    else {
                        tbxMessage.AppendText("Verification failed\r\n");
                    }
                }
                else {
                    tbxMessage.AppendText("Verification failed\r\n");
                }
			}
		}

		private void btnIdentify_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;
			UFM_STATUS ufm_res;
			byte[] Template = new byte[MAX_TEMPLATE_SIZE];
			int TemplateSize;
			int EnrollQuality;
			int MatchIndex;
            byte[][] template_all;
            int[] templateSize_all;
	        int[] nindex;
            int i, j = 0, nMaxTemplateNum = 0;

            template_all = new byte[MAX_TEMPLATE_NUM * 2][];
            templateSize_all = new int[MAX_TEMPLATE_NUM * 2];
            nindex = new int[MAX_TEMPLATE_NUM * 2];

            for (i = 0; i < m_template_num * 2; i++) {
                template_all[i] = new byte[MAX_TEMPLATE_SIZE];
		        templateSize_all[i] = 0;
	        }

            for (i = 0; i < m_template_num * 2; i++) {

                if (i < m_template_num) {
                    if (m_template_size1[i] != 0) {
                        System.Array.Copy(m_template1[i], 0, template_all[j], 0, m_template_size1[i]);
                        templateSize_all[j] = m_template_size1[i];
				        nindex[j] = i;
				        j++;
			        }
		        } else {
                    if (m_template_size2[i - m_template_num] != 0) {
                        System.Array.Copy(m_template2[i - m_template_num], 0, template_all[j], 0, m_template_size2[i - m_template_num]);
                        templateSize_all[j] = m_template_size2[i - m_template_num];
                        nindex[j] = i - m_template_num;
				        j++;
			        }
		        }
	        }

	        nMaxTemplateNum = j;

            if (!GetGetCurrentScanner(out Scanner)) {
                return;
            }
            Scanner.ClearCaptureImageBuffer();

			tbxMessage.AppendText("Place Finger\r\n");

			ufs_res = Scanner.CaptureSingleImage();
			if (ufs_res != UFS_STATUS.OK) {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
				return;
			}
            
            switch (this.cbScanTemplateType.SelectedIndex)
            {
                case 0:
                    Scanner.nTemplateType = 2001;
                    break;
                case 1:
                    Scanner.nTemplateType = 2002;
                    break;
                case 2:
                    Scanner.nTemplateType = 2003;
                    break;
            }

            ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, out TemplateSize, out EnrollQuality);
			if (ufs_res == UFS_STATUS.OK) {
				DrawCapturedImage(Scanner);
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner ExtractEx: " + m_strError + "\r\n");
				return;
			}

            switch (this.cbScanTemplateType.SelectedIndex)
            {
                case 0:
                    m_Matcher.nTemplateType = 2001;
                    break;
                case 1:
                    m_Matcher.nTemplateType = 2002;
                    break;
                case 2:
                    m_Matcher.nTemplateType = 2003;
                    break;
            }

			Cursor.Current = Cursors.WaitCursor;
			//*
            ufm_res = m_Matcher.Identify(Template, TemplateSize, template_all, templateSize_all, nMaxTemplateNum, 5000, out MatchIndex);
            //ufm_res = m_Matcher.IdentifyMT(Template, TemplateSize, template_all, templateSize_all, nMaxTemplateNum, 5000, out MatchIndex);
			/*/
			{
				byte[,] Template2 = new byte[m_template_num, MAX_TEMPLATE_SIZE];
				int i, j;
				for (j = 0; j < m_template_num; j++) {
					for (i = 0; i < m_template_size[j]; i++) {
						Template2[j,i] = m_template[j][i];
					}
				}
				ufm_res = m_Matcher.Identify(Template, TemplateSize, m_template, m_template_size, m_template_num, 5000, out MatchIndex);
			}
			//*/
			Cursor.Current = this.Cursor;
			if (ufm_res != UFM_STATUS.OK) {
				UFMatcher.GetErrorString(ufm_res, out m_strError);
				tbxMessage.AppendText("UFMatcher Identify: " + m_strError + "\r\n");
				return;
			}

			if (MatchIndex != -1) {
                tbxMessage.AppendText("Identification succeed (Match Index." + MatchIndex + ") (Match Serial." + nindex[MatchIndex] % nMaxTemplateNum + ") (ID." + m_UserID[nindex[MatchIndex]] + ")\r\n");
			} else {
				tbxMessage.AppendText("Identification failed\r\n");
			}
		}

		private void btnSaveTemplate_Click(object sender, EventArgs e) {
            int Serial;

            if (lvFingerDataList.SelectedIndices.Count == 0) {
                tbxMessage.AppendText("Select data\r\n");
                return;
            }
            else {
                Serial = Convert.ToInt32(lvFingerDataList.SelectedItems[0].SubItems[FINGERDATA_COL_SERIAL].Text);
            }

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Template files (*.tmp)|*.tmp";
			dlg.DefaultExt = "tmp";
			if (dlg.ShowDialog() != DialogResult.OK) {
				return;
			}

			using (FileStream fs = File.Create(dlg.FileName)) {
                fs.Write(m_template1[Serial], 0, m_template_size1[Serial]);
				fs.Close();
			}

            if (m_template_size2[Serial] != 0) {
                dlg.Filter = "Template files (*.tmp)|*.tmp";
                dlg.DefaultExt = "tmp";
                if (dlg.ShowDialog() != DialogResult.OK) {
                    return;
                }

                using (FileStream fs = File.Create(dlg.FileName)) {
                    fs.Write(m_template2[Serial], 0, m_template_size2[Serial]);
                    fs.Close();
                }
            }

            tbxMessage.AppendText("Selected template is saved\r\n");
		}

		private void btnSaveImage_Click(object sender, EventArgs e) {
			UFScanner Scanner;
			UFS_STATUS ufs_res;

			if (!GetGetCurrentScanner(out Scanner)) {
				return;
			}

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Bitmap files (*.bmp)|*.bmp";
			dlg.DefaultExt = "bmp";
			if (dlg.ShowDialog() != DialogResult.OK) {
				return;
			}

			ufs_res = Scanner.SaveCaptureImageBufferToBMP(dlg.FileName);
			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner Image Buffer is saved to " + dlg.FileName + "\r\n");
			}
		}

        private void btnUpdateTemplate_Click(object sender, EventArgs e)
        {
            UFScanner Scanner;
            UFS_STATUS ufs_res;
            byte[] Template = new byte[MAX_TEMPLATE_SIZE];
            int TemplateSize;
            int EnrollQuality;
            int EnrollMode;
            int Serial;
            int template_enrolled = 0;
            bool fingeron;

            if (lvFingerDataList.SelectedIndices.Count == 0) {
                tbxMessage.AppendText("Select data\r\n");
                return;
            }
            else {
                Serial = Convert.ToInt32(lvFingerDataList.SelectedItems[0].SubItems[FINGERDATA_COL_SERIAL].Text);
            }

            if (!GetGetCurrentScanner(out Scanner)) {
                return;
            }

            switch (this.cbScanTemplateType.SelectedIndex)
            {
                case 0:
                    Scanner.nTemplateType = 2001;
                    break;
                case 1:
                    Scanner.nTemplateType = 2002;
                    break;
                case 2:
                    Scanner.nTemplateType = 2003;
                    break;
            }

            EnrollMode = rbtnOneTemplateAdvanced.Checked ? 1 : 2;

            //Update Template with Non-Advanced-Extraction   
            if (rbtnOneTemplateNormal.Checked == true || rbtnOneTemplateNormal2.Checked == true) {
                Scanner.ClearCaptureImageBuffer();
                tbxMessage.AppendText("Place Finger\r\n");

                while (true) {
                    ufs_res = Scanner.CaptureSingleImage();
                    if (ufs_res != UFS_STATUS.OK) {
                        UFScanner.GetErrorString(ufs_res, out m_strError);
                        tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
                        return;
                    }

                    ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, out TemplateSize, out EnrollQuality);
                    DrawCapturedImage(Scanner);

                    if (ufs_res == UFS_STATUS.OK) {
                        if (EnrollQuality < m_quality) {
                            tbxMessage.AppendText("Too low quality [Q:" + EnrollQuality + "]\r\n");
                        }
                        else {
                            if (rbtnOneTemplateNormal.Checked == true)
                            {
                                System.Array.Clear(m_template2[Serial], 0, MAX_TEMPLATE_SIZE);
                                m_template_size2[Serial] = 0;

                                System.Array.Clear(m_template1[Serial], 0, MAX_TEMPLATE_SIZE);
                                System.Array.Copy(Template, 0, m_template1[Serial], 0, TemplateSize);
                                m_template_size1[Serial] = TemplateSize;

                                tbxMessage.AppendText("Update success (Serial." + Serial + ") [Q:" + EnrollQuality + "]\r\n");

                                UpdateFingerDataList();
                                break;
                            }
                            else if (rbtnOneTemplateNormal2.Checked == true && template_enrolled == 1) {
                                System.Array.Clear(m_template2[Serial], 0, MAX_TEMPLATE_SIZE);
                                System.Array.Copy(Template, 0, m_template2[Serial], 0, TemplateSize);
                                m_template_size2[Serial] = TemplateSize;
                                tbxMessage.AppendText("Second template update success (Serial." + Serial + ") [Q:" + EnrollQuality + "]\r\n");

                                UpdateFingerDataList();
                                break;
                            }
                            else {
                                template_enrolled++;
                                System.Array.Clear(m_template1[Serial], 0, MAX_TEMPLATE_SIZE);
                                System.Array.Copy(Template, 0, m_template1[Serial], 0, TemplateSize);
                                m_template_size1[Serial] = TemplateSize;
                                tbxMessage.AppendText("First template update success (Serial." + Serial + ") [Q:" + EnrollQuality + "]\r\n");

                                tbxMessage.AppendText("Remove finger\r\n");
                                while (true)
                                {
                                    fingeron = Scanner.IsFingerOn;
                                    if (fingeron == false) {
                                        tbxMessage.AppendText("Place a finger\r\n");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        UFScanner.GetErrorString(ufs_res, out m_strError);
                        tbxMessage.AppendText("UFScanner Extract: " + m_strError + "\r\n");
                    }
                }
            }
            //Update with Advanced-Extraction
            else {
                UFE30_Enroll dlg = new UFE30_Enroll();

                dlg.hScanner = Scanner;
                dlg.UserID = m_UserID[Serial];
                dlg.OutputNum = EnrollMode;
                dlg.Quality = m_quality;

                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    tbxMessage.AppendText("Fingerprint update is cancelled by user\r\n");
                    return;
                }

                if (dlg.EnrollTemplateOutputSize[0] != 0) {
                    //Update 1-Template
                    if (EnrollMode == 1) {
                        System.Array.Clear(m_template2[Serial], 0, MAX_TEMPLATE_SIZE);
                        m_template_size2[Serial] = 0;

                        System.Array.Clear(m_template1[Serial], 0, MAX_TEMPLATE_SIZE);
                        System.Array.Copy(dlg.EnrollTemplateOutput[0], 0, m_template1[Serial], 0, dlg.EnrollTemplateOutputSize[0]);
                        m_template_size1[Serial] = dlg.EnrollTemplateOutputSize[0];
                    }
                    //Update 2-Template
                    else {
                        System.Array.Clear(m_template1[Serial], 0, MAX_TEMPLATE_SIZE);
                        System.Array.Copy(dlg.EnrollTemplateOutput[0], 0, m_template1[Serial], 0, dlg.EnrollTemplateOutputSize[0]);
                        m_template_size1[Serial] = dlg.EnrollTemplateOutputSize[0];
                        System.Array.Clear(m_template2[Serial], 0, MAX_TEMPLATE_SIZE);
                        System.Array.Copy(dlg.EnrollTemplateOutput[1], 0, m_template2[Serial], 0, dlg.EnrollTemplateOutputSize[1]);
                        m_template_size2[Serial] = dlg.EnrollTemplateOutputSize[1];
                    }

                    tbxMessage.AppendText("Fingerprint update is succeed (Serial." + Serial + ")\r\n");
                    UpdateFingerDataList();
                }
                else {
                    tbxMessage.AppendText("Fingerprint update is failed\r\n");
                }

                Scanner.Timeout = cbTimeout.SelectedIndex * 1000;
            }

        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            int Serial;
            int i;

            if (lvFingerDataList.SelectedIndices.Count == 0) {
                tbxMessage.AppendText("Select data\r\n");
                return;
            }
            else {
                Serial = Convert.ToInt32(lvFingerDataList.SelectedItems[0].SubItems[FINGERDATA_COL_SERIAL].Text);
            }

            for (i = Serial; i < m_template_num - 1; i++) {
                System.Array.Clear(m_template1[i], 0, MAX_TEMPLATE_SIZE);
                System.Array.Copy(m_template1[i + 1], 0, m_template1[i], 0, m_template_size1[i + 1]);
                m_template_size1[i] = m_template_size1[i + 1];

                System.Array.Clear(m_template2[i], 0, MAX_TEMPLATE_SIZE);
                System.Array.Copy(m_template2[i + 1], 0, m_template2[i], 0, m_template_size2[i + 1]);
                m_template_size2[i] = m_template_size2[i + 1];

                m_UserID[i] = m_UserID[i + 1];
            }

            System.Array.Clear(m_template1[m_template_num - 1], 0, MAX_TEMPLATE_SIZE);
            System.Array.Clear(m_template2[m_template_num - 1], 0, MAX_TEMPLATE_SIZE);
            m_template_size1[m_template_num - 1] = 0;
            m_template_size2[m_template_num - 1] = 0;
            m_UserID[m_template_num - 1] = "";

            m_template_num--;

            UpdateFingerDataList();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < MAX_TEMPLATE_NUM; i++) {
                System.Array.Clear(m_template1[i], 0, MAX_TEMPLATE_SIZE);
                m_template_size1[i] = 0;
                System.Array.Clear(m_template2[i], 0, MAX_TEMPLATE_SIZE);
                m_template_size2[i] = 0;
                m_UserID[i] = null;
            }

            m_template_num = 0;

            UpdateFingerDataList();	
        }

        private void cbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_quality = 100 - ((cbQuality.SelectedIndex + 1) * 10);
            if (cbQuality.SelectedIndex == 9)
                m_quality = 0;
        }
		//=========================================================================//
	}
}