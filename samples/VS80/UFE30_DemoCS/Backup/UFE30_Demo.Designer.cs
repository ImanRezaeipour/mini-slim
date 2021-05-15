namespace Suprema
{
    partial class UFE30_Demo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnInit;
            System.Windows.Forms.Button btnUninit;
            System.Windows.Forms.Button btnClear;
            System.Windows.Forms.Button btnStartCapturing;
            System.Windows.Forms.Button btnExtract;
            System.Windows.Forms.Button btnEnroll;
            System.Windows.Forms.Button btnVerify;
            System.Windows.Forms.Button btnIdentify;
            System.Windows.Forms.Button btnSaveTemplate;
            System.Windows.Forms.Button btnSaveImage;
            System.Windows.Forms.Button btnAbortCapturing;
            System.Windows.Forms.Button btnCaptureSingle;
            System.Windows.Forms.Button btnUpdate;
            System.Windows.Forms.Button btnDeleteAll;
            System.Windows.Forms.Button btnUpdateTemplate;
            System.Windows.Forms.Button btnDeleteTemplate;
            System.Windows.Forms.Button btnAutoCapture;
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.pbImageFrame = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbScannerList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDetectCore = new System.Windows.Forms.CheckBox();
            this.nudSensitivity = new System.Windows.Forms.NumericUpDown();
            this.nudBrightness = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTimeout = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbScanTemplateType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbFastMode = new System.Windows.Forms.CheckBox();
            this.cbSecurityLevel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvFingerDataList = new System.Windows.Forms.ListView();
            this.rbtnOneTemplateAdvanced = new System.Windows.Forms.RadioButton();
            this.rbtnTwoTemplateNormal = new System.Windows.Forms.RadioButton();
            this.rbtnOneTemplateNormal = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnOneTemplateNormal2 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            btnInit = new System.Windows.Forms.Button();
            btnUninit = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            btnStartCapturing = new System.Windows.Forms.Button();
            btnExtract = new System.Windows.Forms.Button();
            btnEnroll = new System.Windows.Forms.Button();
            btnVerify = new System.Windows.Forms.Button();
            btnIdentify = new System.Windows.Forms.Button();
            btnSaveTemplate = new System.Windows.Forms.Button();
            btnSaveImage = new System.Windows.Forms.Button();
            btnAbortCapturing = new System.Windows.Forms.Button();
            btnCaptureSingle = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDeleteAll = new System.Windows.Forms.Button();
            btnUpdateTemplate = new System.Windows.Forms.Button();
            btnDeleteTemplate = new System.Windows.Forms.Button();
            btnAutoCapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            btnInit.Location = new System.Drawing.Point(12, 12);
            btnInit.Name = "btnInit";
            btnInit.Size = new System.Drawing.Size(60, 24);
            btnInit.TabIndex = 0;
            btnInit.Text = "Init";
            btnInit.UseVisualStyleBackColor = true;
            btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnUninit
            // 
            btnUninit.Location = new System.Drawing.Point(140, 12);
            btnUninit.Name = "btnUninit";
            btnUninit.Size = new System.Drawing.Size(60, 24);
            btnUninit.TabIndex = 1;
            btnUninit.Text = "Uninit";
            btnUninit.UseVisualStyleBackColor = true;
            btnUninit.Click += new System.EventHandler(this.btnUninit_Click);
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(392, 421);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(44, 68);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStartCapturing
            // 
            btnStartCapturing.Location = new System.Drawing.Point(8, 24);
            btnStartCapturing.Name = "btnStartCapturing";
            btnStartCapturing.Size = new System.Drawing.Size(96, 20);
            btnStartCapturing.TabIndex = 10;
            btnStartCapturing.Text = "Start Capturing";
            btnStartCapturing.UseVisualStyleBackColor = true;
            btnStartCapturing.Click += new System.EventHandler(this.btnStartCapturing_Click);
            // 
            // btnExtract
            // 
            btnExtract.Location = new System.Drawing.Point(108, 52);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new System.Drawing.Size(72, 20);
            btnExtract.TabIndex = 11;
            btnExtract.Text = "Extract";
            btnExtract.UseVisualStyleBackColor = true;
            btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new System.Drawing.Point(23, 139);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new System.Drawing.Size(113, 20);
            btnEnroll.TabIndex = 12;
            btnEnroll.Text = "Enroll";
            btnEnroll.UseVisualStyleBackColor = true;
            btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnVerify
            // 
            btnVerify.Location = new System.Drawing.Point(120, 74);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new System.Drawing.Size(96, 20);
            btnVerify.TabIndex = 13;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnIdentify
            // 
            btnIdentify.Location = new System.Drawing.Point(120, 105);
            btnIdentify.Name = "btnIdentify";
            btnIdentify.Size = new System.Drawing.Size(96, 20);
            btnIdentify.TabIndex = 15;
            btnIdentify.Text = "Identify";
            btnIdentify.UseVisualStyleBackColor = true;
            btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnSaveTemplate
            // 
            btnSaveTemplate.Location = new System.Drawing.Point(142, 193);
            btnSaveTemplate.Name = "btnSaveTemplate";
            btnSaveTemplate.Size = new System.Drawing.Size(114, 20);
            btnSaveTemplate.TabIndex = 16;
            btnSaveTemplate.Text = "Save Template";
            btnSaveTemplate.UseVisualStyleBackColor = true;
            btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // btnSaveImage
            // 
            btnSaveImage.Location = new System.Drawing.Point(78, 103);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new System.Drawing.Size(104, 22);
            btnSaveImage.TabIndex = 17;
            btnSaveImage.Text = "Save Image";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnAbortCapturing
            // 
            btnAbortCapturing.Location = new System.Drawing.Point(108, 24);
            btnAbortCapturing.Name = "btnAbortCapturing";
            btnAbortCapturing.Size = new System.Drawing.Size(74, 20);
            btnAbortCapturing.TabIndex = 13;
            btnAbortCapturing.Text = "Abort";
            btnAbortCapturing.UseVisualStyleBackColor = true;
            btnAbortCapturing.Click += new System.EventHandler(this.btnAbortCapturing_Click);
            // 
            // btnCaptureSingle
            // 
            btnCaptureSingle.Location = new System.Drawing.Point(8, 53);
            btnCaptureSingle.Name = "btnCaptureSingle";
            btnCaptureSingle.Size = new System.Drawing.Size(96, 20);
            btnCaptureSingle.TabIndex = 14;
            btnCaptureSingle.Text = "Capture Single";
            btnCaptureSingle.UseVisualStyleBackColor = true;
            btnCaptureSingle.Click += new System.EventHandler(this.btnCaptureSingle_Click);
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(76, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(60, 24);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new System.Drawing.Point(142, 139);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new System.Drawing.Size(113, 20);
            btnDeleteAll.TabIndex = 20;
            btnDeleteAll.Text = "Delete All";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnUpdateTemplate
            // 
            btnUpdateTemplate.Location = new System.Drawing.Point(23, 167);
            btnUpdateTemplate.Name = "btnUpdateTemplate";
            btnUpdateTemplate.Size = new System.Drawing.Size(113, 20);
            btnUpdateTemplate.TabIndex = 21;
            btnUpdateTemplate.Text = "Update Template";
            btnUpdateTemplate.UseVisualStyleBackColor = true;
            btnUpdateTemplate.Click += new System.EventHandler(this.btnUpdateTemplate_Click);
            // 
            // btnDeleteTemplate
            // 
            btnDeleteTemplate.Location = new System.Drawing.Point(142, 167);
            btnDeleteTemplate.Name = "btnDeleteTemplate";
            btnDeleteTemplate.Size = new System.Drawing.Size(113, 20);
            btnDeleteTemplate.TabIndex = 22;
            btnDeleteTemplate.Text = "Delete Template";
            btnDeleteTemplate.UseVisualStyleBackColor = true;
            btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(10, 421);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessage.Size = new System.Drawing.Size(376, 68);
            this.tbxMessage.TabIndex = 2;
            this.tbxMessage.WordWrap = false;
            // 
            // pbImageFrame
            // 
            this.pbImageFrame.BackColor = System.Drawing.SystemColors.Control;
            this.pbImageFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageFrame.Location = new System.Drawing.Point(208, 12);
            this.pbImageFrame.Name = "pbImageFrame";
            this.pbImageFrame.Size = new System.Drawing.Size(228, 252);
            this.pbImageFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageFrame.TabIndex = 4;
            this.pbImageFrame.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Scanner List";
            // 
            // lbScannerList
            // 
            this.lbScannerList.FormattingEnabled = true;
            this.lbScannerList.ItemHeight = 12;
            this.lbScannerList.Location = new System.Drawing.Point(12, 64);
            this.lbScannerList.Name = "lbScannerList";
            this.lbScannerList.Size = new System.Drawing.Size(188, 64);
            this.lbScannerList.TabIndex = 6;
            this.lbScannerList.SelectedValueChanged += new System.EventHandler(this.lbScannerList_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDetectCore);
            this.groupBox1.Controls.Add(this.nudSensitivity);
            this.groupBox1.Controls.Add(this.nudBrightness);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTimeout);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 116);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scanner Parameters";
            // 
            // cbDetectCore
            // 
            this.cbDetectCore.AutoSize = true;
            this.cbDetectCore.Location = new System.Drawing.Point(5, 91);
            this.cbDetectCore.Name = "cbDetectCore";
            this.cbDetectCore.Size = new System.Drawing.Size(90, 16);
            this.cbDetectCore.TabIndex = 6;
            this.cbDetectCore.Text = "Detect Core";
            this.cbDetectCore.UseVisualStyleBackColor = true;
            this.cbDetectCore.CheckedChanged += new System.EventHandler(this.cbDetectCore_CheckedChanged);
            // 
            // nudSensitivity
            // 
            this.nudSensitivity.Location = new System.Drawing.Point(90, 61);
            this.nudSensitivity.Name = "nudSensitivity";
            this.nudSensitivity.Size = new System.Drawing.Size(48, 21);
            this.nudSensitivity.TabIndex = 5;
            this.nudSensitivity.ValueChanged += new System.EventHandler(this.nudSensitivity_ValueChanged);
            // 
            // nudBrightness
            // 
            this.nudBrightness.Location = new System.Drawing.Point(90, 37);
            this.nudBrightness.Name = "nudBrightness";
            this.nudBrightness.Size = new System.Drawing.Size(48, 21);
            this.nudBrightness.TabIndex = 4;
            this.nudBrightness.ValueChanged += new System.EventHandler(this.nudBrightness_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sensitivity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Brightness";
            // 
            // cbTimeout
            // 
            this.cbTimeout.FormattingEnabled = true;
            this.cbTimeout.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5*"});
            this.cbTimeout.Location = new System.Drawing.Point(76, 14);
            this.cbTimeout.Name = "cbTimeout";
            this.cbTimeout.Size = new System.Drawing.Size(48, 20);
            this.cbTimeout.TabIndex = 1;
            this.cbTimeout.SelectedIndexChanged += new System.EventHandler(this.cbTimeout_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Timeout";
            // 
            // cbScanTemplateType
            // 
            this.cbScanTemplateType.FormattingEnabled = true;
            this.cbScanTemplateType.Items.AddRange(new object[] {
            "suprema",
            "iso19794_2",
            "ansi378"});
            this.cbScanTemplateType.Location = new System.Drawing.Point(117, 111);
            this.cbScanTemplateType.Name = "cbScanTemplateType";
            this.cbScanTemplateType.Size = new System.Drawing.Size(90, 20);
            this.cbScanTemplateType.TabIndex = 13;
            this.cbScanTemplateType.SelectedIndexChanged += new System.EventHandler(this.cbScanTemplateType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "template type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(btnAutoCapture);
            this.groupBox2.Controls.Add(btnCaptureSingle);
            this.groupBox2.Controls.Add(btnAbortCapturing);
            this.groupBox2.Controls.Add(btnExtract);
            this.groupBox2.Controls.Add(btnSaveImage);
            this.groupBox2.Controls.Add(btnStartCapturing);
            this.groupBox2.Location = new System.Drawing.Point(12, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 133);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Use Scanner";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(btnIdentify);
            this.groupBox3.Controls.Add(btnVerify);
            this.groupBox3.Controls.Add(this.cbFastMode);
            this.groupBox3.Controls.Add(this.cbSecurityLevel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(208, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 133);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Match";
            // 
            // cbFastMode
            // 
            this.cbFastMode.AutoSize = true;
            this.cbFastMode.Location = new System.Drawing.Point(5, 52);
            this.cbFastMode.Name = "cbFastMode";
            this.cbFastMode.Size = new System.Drawing.Size(84, 16);
            this.cbFastMode.TabIndex = 7;
            this.cbFastMode.Text = "Fast Mode";
            this.cbFastMode.UseVisualStyleBackColor = true;
            this.cbFastMode.CheckedChanged += new System.EventHandler(this.cbFastMode_CheckedChanged);
            // 
            // cbSecurityLevel
            // 
            this.cbSecurityLevel.FormattingEnabled = true;
            this.cbSecurityLevel.Items.AddRange(new object[] {
            "1 (FAR1/100)",
            "2 (1/1,000)",
            "3 (1/10,000)",
            "4*(1/100,000)",
            "5 (1/1,000,000)",
            "6 (1/10,000,000)",
            "7 (1/100,000,000)"});
            this.cbSecurityLevel.Location = new System.Drawing.Point(96, 20);
            this.cbSecurityLevel.Name = "cbSecurityLevel";
            this.cbSecurityLevel.Size = new System.Drawing.Size(120, 20);
            this.cbSecurityLevel.TabIndex = 13;
            this.cbSecurityLevel.SelectedIndexChanged += new System.EventHandler(this.cbSecurityLevel_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Security Level";
            // 
            // lvFingerDataList
            // 
            this.lvFingerDataList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFingerDataList.FullRowSelect = true;
            this.lvFingerDataList.GridLines = true;
            this.lvFingerDataList.Location = new System.Drawing.Point(450, 12);
            this.lvFingerDataList.MultiSelect = false;
            this.lvFingerDataList.Name = "lvFingerDataList";
            this.lvFingerDataList.Size = new System.Drawing.Size(282, 252);
            this.lvFingerDataList.TabIndex = 19;
            this.lvFingerDataList.UseCompatibleStateImageBehavior = false;
            this.lvFingerDataList.View = System.Windows.Forms.View.Details;
            // 
            // rbtnOneTemplateAdvanced
            // 
            this.rbtnOneTemplateAdvanced.AutoSize = true;
            this.rbtnOneTemplateAdvanced.Location = new System.Drawing.Point(18, 48);
            this.rbtnOneTemplateAdvanced.Name = "rbtnOneTemplateAdvanced";
            this.rbtnOneTemplateAdvanced.Size = new System.Drawing.Size(148, 16);
            this.rbtnOneTemplateAdvanced.TabIndex = 23;
            this.rbtnOneTemplateAdvanced.TabStop = true;
            this.rbtnOneTemplateAdvanced.Text = "1-Template Advanced";
            this.rbtnOneTemplateAdvanced.UseVisualStyleBackColor = true;
            // 
            // rbtnTwoTemplateNormal
            // 
            this.rbtnTwoTemplateNormal.AutoSize = true;
            this.rbtnTwoTemplateNormal.Location = new System.Drawing.Point(18, 65);
            this.rbtnTwoTemplateNormal.Name = "rbtnTwoTemplateNormal";
            this.rbtnTwoTemplateNormal.Size = new System.Drawing.Size(148, 16);
            this.rbtnTwoTemplateNormal.TabIndex = 24;
            this.rbtnTwoTemplateNormal.TabStop = true;
            this.rbtnTwoTemplateNormal.Text = "2-Template Advanced";
            this.rbtnTwoTemplateNormal.UseVisualStyleBackColor = true;
            // 
            // rbtnOneTemplateNormal
            // 
            this.rbtnOneTemplateNormal.AutoSize = true;
            this.rbtnOneTemplateNormal.Location = new System.Drawing.Point(18, 14);
            this.rbtnOneTemplateNormal.Name = "rbtnOneTemplateNormal";
            this.rbtnOneTemplateNormal.Size = new System.Drawing.Size(88, 16);
            this.rbtnOneTemplateNormal.TabIndex = 25;
            this.rbtnOneTemplateNormal.TabStop = true;
            this.rbtnOneTemplateNormal.Text = "1-Template";
            this.rbtnOneTemplateNormal.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnOneTemplateNormal2);
            this.groupBox4.Controls.Add(this.rbtnOneTemplateNormal);
            this.groupBox4.Controls.Add(this.rbtnTwoTemplateNormal);
            this.groupBox4.Controls.Add(this.rbtnOneTemplateAdvanced);
            this.groupBox4.Location = new System.Drawing.Point(17, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 85);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Enroll Mode";
            // 
            // rbtnOneTemplateNormal2
            // 
            this.rbtnOneTemplateNormal2.AutoSize = true;
            this.rbtnOneTemplateNormal2.Location = new System.Drawing.Point(18, 31);
            this.rbtnOneTemplateNormal2.Name = "rbtnOneTemplateNormal2";
            this.rbtnOneTemplateNormal2.Size = new System.Drawing.Size(88, 16);
            this.rbtnOneTemplateNormal2.TabIndex = 26;
            this.rbtnOneTemplateNormal2.TabStop = true;
            this.rbtnOneTemplateNormal2.Text = "2-Template";
            this.rbtnOneTemplateNormal2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cbQuality);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(btnDeleteTemplate);
            this.groupBox5.Controls.Add(btnUpdateTemplate);
            this.groupBox5.Controls.Add(btnDeleteAll);
            this.groupBox5.Controls.Add(btnEnroll);
            this.groupBox5.Controls.Add(btnSaveTemplate);
            this.groupBox5.Controls.Add(this.cbScanTemplateType);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(450, 272);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(282, 217);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Template";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quality";
            // 
            // cbQuality
            // 
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "90",
            "80",
            "70",
            "60",
            "50",
            "40*",
            "30",
            "20",
            "10",
            "None"});
            this.cbQuality.Location = new System.Drawing.Point(217, 41);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(59, 20);
            this.cbQuality.TabIndex = 7;
            this.cbQuality.SelectedIndexChanged += new System.EventHandler(this.cbQuality_SelectedIndexChanged);
            // 
            // btnAutoCapture
            // 
            btnAutoCapture.Location = new System.Drawing.Point(8, 79);
            btnAutoCapture.Name = "btnAutoCapture";
            btnAutoCapture.Size = new System.Drawing.Size(96, 20);
            btnAutoCapture.TabIndex = 18;
            btnAutoCapture.Text = "Auto Capture";
            btnAutoCapture.UseVisualStyleBackColor = true;
            btnAutoCapture.Click += new System.EventHandler(this.btnAutoCapture_Click);
            // 
            // UFE30_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(746, 500);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lvFingerDataList);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbScannerList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImageFrame);
            this.Controls.Add(btnClear);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(btnUninit);
            this.Controls.Add(btnInit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UFE30_Demo";
            this.Text = "Suprema PC SDK Demo (VC#)";
            this.Load += new System.EventHandler(this.UFE30_Demo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UFE30_Demo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.PictureBox pbImageFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbScannerList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudBrightness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTimeout;
        private System.Windows.Forms.NumericUpDown nudSensitivity;
        private System.Windows.Forms.CheckBox cbDetectCore;
		private System.Windows.Forms.CheckBox cbFastMode;
		private System.Windows.Forms.ComboBox cbSecurityLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbScanTemplateType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvFingerDataList;
        private System.Windows.Forms.RadioButton rbtnOneTemplateAdvanced;
        private System.Windows.Forms.RadioButton rbtnTwoTemplateNormal;
        private System.Windows.Forms.RadioButton rbtnOneTemplateNormal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtnOneTemplateNormal2;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.Label label5;


    }
}

