namespace Suprema
{
    partial class UFE30_Enroll
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImageFrame = new System.Windows.Forms.PictureBox();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUserID = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImageFrame
            // 
            this.pbImageFrame.BackColor = System.Drawing.SystemColors.Control;
            this.pbImageFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageFrame.Location = new System.Drawing.Point(12, 12);
            this.pbImageFrame.Name = "pbImageFrame";
            this.pbImageFrame.Size = new System.Drawing.Size(201, 212);
            this.pbImageFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageFrame.TabIndex = 5;
            this.pbImageFrame.TabStop = false;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(12, 234);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessage.Size = new System.Drawing.Size(390, 68);
            this.tbxMessage.TabIndex = 6;
            this.tbxMessage.WordWrap = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(303, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 18);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(221, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 18);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "UserID";
            // 
            // tbxUserID
            // 
            this.tbxUserID.Location = new System.Drawing.Point(267, 97);
            this.tbxUserID.Name = "tbxUserID";
            this.tbxUserID.ReadOnly = true;
            this.tbxUserID.Size = new System.Drawing.Size(100, 21);
            this.tbxUserID.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(219, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(185, 80);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Template extraction process \r\nis running.\r\n\r\nCheck blew message box and Input you" +
                "r fingerprint 4 times";
            // 
            // UFE30_Enroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 314);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbxUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.pbImageFrame);
            this.Name = "UFE30_Enroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UFE30_Enroll";
            this.Load += new System.EventHandler(this.UFE30_Enroll_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UFE30_Enroll_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImageFrame;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxUserID;
        private System.Windows.Forms.TextBox textBox1;
    }
}