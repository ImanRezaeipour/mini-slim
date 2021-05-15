namespace Suprema 
{
	partial class UFE30_DatabaseDemo 
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
		private void InitializeComponent() {
            this.btnInit = new System.Windows.Forms.Button();
            this.btnUninit = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectionVerify = new System.Windows.Forms.Button();
            this.btnSelectionUpdateTemplate = new System.Windows.Forms.Button();
            this.btnSelectionUpdateUserInfo = new System.Windows.Forms.Button();
            this.btnSelectionDelete = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.lvDatabaseList = new System.Windows.Forms.ListView();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pbImageFrame = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbScanTemplateType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.AccessibleDescription = "";
            this.btnInit.Location = new System.Drawing.Point(12, 12);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(84, 24);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnUninit
            // 
            this.btnUninit.AccessibleDescription = "";
            this.btnUninit.Location = new System.Drawing.Point(12, 40);
            this.btnUninit.Name = "btnUninit";
            this.btnUninit.Size = new System.Drawing.Size(84, 24);
            this.btnUninit.TabIndex = 1;
            this.btnUninit.Text = "Uninit";
            this.btnUninit.UseVisualStyleBackColor = true;
            this.btnUninit.Click += new System.EventHandler(this.btnUninit_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.AccessibleDescription = "";
            this.btnEnroll.Location = new System.Drawing.Point(12, 84);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(84, 24);
            this.btnEnroll.TabIndex = 2;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.AccessibleDescription = "";
            this.btnIdentify.Location = new System.Drawing.Point(12, 112);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(84, 24);
            this.btnIdentify.TabIndex = 3;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectionVerify);
            this.groupBox1.Controls.Add(this.btnSelectionUpdateTemplate);
            this.groupBox1.Controls.Add(this.btnSelectionUpdateUserInfo);
            this.groupBox1.Controls.Add(this.btnSelectionDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 168);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // btnSelectionVerify
            // 
            this.btnSelectionVerify.AccessibleDescription = "";
            this.btnSelectionVerify.Location = new System.Drawing.Point(8, 136);
            this.btnSelectionVerify.Name = "btnSelectionVerify";
            this.btnSelectionVerify.Size = new System.Drawing.Size(68, 24);
            this.btnSelectionVerify.TabIndex = 8;
            this.btnSelectionVerify.Text = "Verify";
            this.btnSelectionVerify.UseVisualStyleBackColor = true;
            this.btnSelectionVerify.Click += new System.EventHandler(this.btnSelectionVerify_Click);
            // 
            // btnSelectionUpdateTemplate
            // 
            this.btnSelectionUpdateTemplate.AccessibleDescription = "";
            this.btnSelectionUpdateTemplate.Location = new System.Drawing.Point(8, 92);
            this.btnSelectionUpdateTemplate.Name = "btnSelectionUpdateTemplate";
            this.btnSelectionUpdateTemplate.Size = new System.Drawing.Size(68, 40);
            this.btnSelectionUpdateTemplate.TabIndex = 7;
            this.btnSelectionUpdateTemplate.Text = "Update Template";
            this.btnSelectionUpdateTemplate.UseVisualStyleBackColor = true;
            this.btnSelectionUpdateTemplate.Click += new System.EventHandler(this.btnSelectionUpdateTemplate_Click);
            // 
            // btnSelectionUpdateUserInfo
            // 
            this.btnSelectionUpdateUserInfo.AccessibleDescription = "";
            this.btnSelectionUpdateUserInfo.Location = new System.Drawing.Point(8, 48);
            this.btnSelectionUpdateUserInfo.Name = "btnSelectionUpdateUserInfo";
            this.btnSelectionUpdateUserInfo.Size = new System.Drawing.Size(68, 40);
            this.btnSelectionUpdateUserInfo.TabIndex = 6;
            this.btnSelectionUpdateUserInfo.Text = "Update User Info";
            this.btnSelectionUpdateUserInfo.UseVisualStyleBackColor = true;
            this.btnSelectionUpdateUserInfo.Click += new System.EventHandler(this.btnSelectionUpdateUserInfo_Click);
            // 
            // btnSelectionDelete
            // 
            this.btnSelectionDelete.AccessibleDescription = "";
            this.btnSelectionDelete.Location = new System.Drawing.Point(8, 20);
            this.btnSelectionDelete.Name = "btnSelectionDelete";
            this.btnSelectionDelete.Size = new System.Drawing.Size(68, 24);
            this.btnSelectionDelete.TabIndex = 5;
            this.btnSelectionDelete.Text = "Delete";
            this.btnSelectionDelete.UseVisualStyleBackColor = true;
            this.btnSelectionDelete.Click += new System.EventHandler(this.btnSelectionDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.AccessibleDescription = "";
            this.btnDeleteAll.Location = new System.Drawing.Point(12, 152);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(84, 24);
            this.btnDeleteAll.TabIndex = 5;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // lvDatabaseList
            // 
            this.lvDatabaseList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvDatabaseList.FullRowSelect = true;
            this.lvDatabaseList.GridLines = true;
            this.lvDatabaseList.Location = new System.Drawing.Point(347, 12);
            this.lvDatabaseList.MultiSelect = false;
            this.lvDatabaseList.Name = "lvDatabaseList";
            this.lvDatabaseList.Size = new System.Drawing.Size(420, 296);
            this.lvDatabaseList.TabIndex = 6;
            this.lvDatabaseList.UseCompatibleStateImageBehavior = false;
            this.lvDatabaseList.View = System.Windows.Forms.View.Details;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(102, 320);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(609, 84);
            this.tbxMessage.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.AccessibleDescription = "";
            this.btnClear.Location = new System.Drawing.Point(719, 320);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 84);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pbImageFrame
            // 
            this.pbImageFrame.Location = new System.Drawing.Point(102, 12);
            this.pbImageFrame.Name = "pbImageFrame";
            this.pbImageFrame.Size = new System.Drawing.Size(228, 252);
            this.pbImageFrame.TabIndex = 9;
            this.pbImageFrame.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Template Type";
            // 
            // cbScanTemplateType
            // 
            this.cbScanTemplateType.BackColor = System.Drawing.Color.White;
            this.cbScanTemplateType.FormattingEnabled = true;
            this.cbScanTemplateType.Items.AddRange(new object[] {
            "suprema",
            "iso19479_2",
            "ansi378"});
            this.cbScanTemplateType.Location = new System.Drawing.Point(205, 276);
            this.cbScanTemplateType.Name = "cbScanTemplateType";
            this.cbScanTemplateType.Size = new System.Drawing.Size(124, 20);
            this.cbScanTemplateType.TabIndex = 11;
            this.cbScanTemplateType.SelectedIndexChanged += new System.EventHandler(this.bScanTemplateType_SelectedIndexChanged);
            // 
            // UFE30_DatabaseDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(779, 414);
            this.Controls.Add(this.cbScanTemplateType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImageFrame);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.lvDatabaseList);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnUninit);
            this.Controls.Add(this.btnInit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UFE30_DatabaseDemo";
            this.Text = "Suprema PC SDK Database Demo (VC#)";
            this.Load += new System.EventHandler(this.UFE30_DatabaseDemo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UFE30_DatabaseDemo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnInit;
		private System.Windows.Forms.Button btnUninit;
		private System.Windows.Forms.Button btnEnroll;
		private System.Windows.Forms.Button btnIdentify;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSelectionDelete;
		private System.Windows.Forms.Button btnSelectionVerify;
		private System.Windows.Forms.Button btnSelectionUpdateTemplate;
		private System.Windows.Forms.Button btnSelectionUpdateUserInfo;
		private System.Windows.Forms.Button btnDeleteAll;
		private System.Windows.Forms.ListView lvDatabaseList;
		private System.Windows.Forms.TextBox tbxMessage;
		private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pbImageFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbScanTemplateType;
	}
}

