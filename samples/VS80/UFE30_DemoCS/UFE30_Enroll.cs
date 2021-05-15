using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Suprema
{
    public partial class UFE30_Enroll : Form
    {
        UFScanner m_Scanner;
        
        byte[][] m_EnrollTemplate_input;
        int[] m_EnrollTemplateSize_input;
	    byte[][] m_EnrollTemplate_output;
	    int[] m_EnrollTemplateSize_output;

        int m_extract_num;
	    int m_output_num;
        int m_quality;
	    bool m_try_extract;
	    bool m_bFingerCheck;

        const int MAX_TEMPLATE_INPUT_NUM = 4;
        const int MAX_TEMPLATE_OUTPUT_NUM = 2;
        const int MAX_TEMPLATE_SIZE = 1024;

        delegate void SetTextMessageCallback(string s);

        private void SetTextMessage(string text)
        {

            if (this.tbxMessage.InvokeRequired)
            {
                SetTextMessageCallback d = new SetTextMessageCallback(SetTextMessage);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbxMessage.AppendText(text);
            }
        }

        public string UserID
        {
            get
            {
                return tbxUserID.Text;
            }
            set
            {
                tbxUserID.Text = value;
            }
        }

        public UFScanner hScanner
        {
            get
            {
                return m_Scanner;
            }
            set
            {
                m_Scanner = value;
            }
        }

        public int OutputNum
        {
            get
            {
                return m_output_num;
            }
            set
            {
                m_output_num = value;
            }
        }

        public int Quality
        {
            get
            {
                return m_quality;
            }
            set
            {
                m_quality = value;
            }
        }

        public byte[][] EnrollTemplateInput
        {
            get
            {
                return m_EnrollTemplate_input;
            }
            set
            {
                m_EnrollTemplate_input = value;
            }
        }

        public int[] EnrollTemplateInputSize
        {
            get
            {
                return m_EnrollTemplateSize_input;
            }
            set
            {
                m_EnrollTemplateSize_input = value;
            }
        }

        public byte[][] EnrollTemplateOutput
        {
            get
            {
                return m_EnrollTemplate_output;
            }
            set
            {
                m_EnrollTemplate_output = value;
            }
        }

        public int[] EnrollTemplateOutputSize
        {
            get
            {
                return m_EnrollTemplateSize_output;
            }
            set
            {
                m_EnrollTemplateSize_output = value;
            }
        }

        private delegate void _UpdatePictureBox(PictureBox pbox, Bitmap image);

        public void UpdatePictureBox(PictureBox pbox, Image image)
        {
            if (pbox.InvokeRequired)
            {
                _UpdatePictureBox del = new _UpdatePictureBox(UpdatePictureBox);
                // Call the function in the correct thread
                BeginInvoke(del, new object[] { pbox, image });
            }
            else
            {
                // We are in the correct thread, so assign the image
                pbox.Image = image;
            }
        }

        public int EnrollEvent(object sender, UFScannerCaptureEventArgs e)
        {
            byte[] Template;
	        int TemplateSize;
	        int nEnrollQuality;
	        UFS_STATUS ufs_res;
            string strError;

            Template = new byte[MAX_TEMPLATE_SIZE];

            if (!m_try_extract)
            {
		        if(!e.FingerOn) {
                    m_try_extract = true;
                    m_bFingerCheck = false;
                    SetTextMessage("Place your finger\r\n");
		        }
		        else {
                    if (!m_bFingerCheck)
                    {
                        SetTextMessage("Remove your fingerprint from scanner\r\n");
                        m_bFingerCheck = true;
			        }
		        }

                UpdatePictureBox(pbImageFrame, e.ImageFrame);
		        return 1;
	        }

            if (e.FingerOn && m_try_extract)
            {
                ufs_res = m_Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template, out TemplateSize, out nEnrollQuality);
                if (ufs_res == UFS_STATUS.OK)
                {
                    if (nEnrollQuality < m_quality) {
                        SetTextMessage("Template Quality is too low\r\n");
			        }
			        else {
                        System.Array.Copy(Template, 0, m_EnrollTemplate_input[m_extract_num], 0, TemplateSize);
				        m_EnrollTemplateSize_input[m_extract_num] = TemplateSize;
                        m_extract_num++;
                        SetTextMessage("UFS_Extract: OK (" + m_extract_num + "/4)\r\n");
				        m_try_extract = false;

				        if(m_extract_num == MAX_TEMPLATE_INPUT_NUM) {
					        ufs_res = m_Scanner.SelectTemplateEx(MAX_TEMPLATE_SIZE, m_EnrollTemplate_input, m_EnrollTemplateSize_input, 4, m_EnrollTemplate_output, m_EnrollTemplateSize_output, m_output_num);
                            if (ufs_res == UFS_STATUS.OK)
                            {
                                SetTextMessage("Extraction process is succeed\r\n");
						        if(m_output_num == 1) {
                                    // output template number is 1
						        } else if (m_output_num == 2) {
                                    // output template number is 2
						        } else {
                                    SetTextMessage("template output number is not correct\r\n");
						        }
					        } else {
                                SetTextMessage("Extraction process is faild\r\n");
					        }
                            UpdatePictureBox(pbImageFrame, e.ImageFrame);
					        return 0;
				        }
			        }
		        } 
		        else {
                    UFScanner.GetErrorString(ufs_res, out strError);
                    SetTextMessage("UFS_Extract:" + strError + "\r\n");
		        }
	        }

            UpdatePictureBox(pbImageFrame, e.ImageFrame);
             
            return 1;
        }

        public UFE30_Enroll()
        {
            InitializeComponent();
        }

        private void UFE30_Enroll_Load(object sender, EventArgs e)
        {
            UFS_STATUS ufs_res;
            string strError;
           
            m_extract_num = 0;
            m_try_extract = true;
            m_bFingerCheck = false;

            int i;

            m_EnrollTemplate_input = new byte[MAX_TEMPLATE_INPUT_NUM][];
            m_EnrollTemplateSize_input = new int[MAX_TEMPLATE_INPUT_NUM];
            for (i = 0; i < MAX_TEMPLATE_INPUT_NUM; i++)
            {
                m_EnrollTemplate_input[i] = new byte[MAX_TEMPLATE_SIZE];
                m_EnrollTemplateSize_input[i] = 0;
            }

            m_EnrollTemplate_output = new byte[m_output_num][];
            m_EnrollTemplateSize_output = new int[m_output_num];
            for (i = 0; i < m_output_num; i++)
            {
                m_EnrollTemplate_output[i] = new byte[MAX_TEMPLATE_SIZE];
                m_EnrollTemplateSize_output[i] = 0;
            }

            tbxMessage.AppendText("Advanced Enroll is started. Place your finger\r\n");

            m_Scanner.ClearCaptureImageBuffer();

            m_Scanner.Timeout = 0;

            m_Scanner.CaptureEvent += new UFS_CAPTURE_PROC(EnrollEvent);
            ufs_res = m_Scanner.StartCapturing();
            if (ufs_res == UFS_STATUS.OK)
            {
                tbxMessage.AppendText("UFScanner StartCapturing: OK\r\n");
            }
            else
            {
                UFScanner.GetErrorString(ufs_res, out strError);
                tbxMessage.AppendText("UFScanner StartCapturing: " + strError + "\r\n");
            }
        }

        private void UFE30_Enroll_FormClosing(object sender, FormClosingEventArgs e)
        {
            UFS_STATUS ufs_res;

            ufs_res = m_Scanner.AbortCapturing();

            m_Scanner.CaptureEvent -= EnrollEvent;

            while (true)
            {
                if (m_Scanner.IsCapturing)
                    System.Threading.Thread.Sleep(10);
                else
                    break;
            }
        }
    }
}