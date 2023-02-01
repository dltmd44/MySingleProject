
namespace MySingleProject
{
    partial class frmLogin
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linklblSignUp = new System.Windows.Forms.LinkLabel();
            this.linklblFPwd = new System.Windows.Forms.LinkLabel();
            this.linklblFId = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFindIdPwd = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnFindCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new MySingleProject.ccTextBox();
            this.txtId = new MySingleProject.ccTextBox();
            this.txtId_F = new MySingleProject.ccTextBox();
            this.txtPhone = new MySingleProject.ccTextBox();
            this.txtName = new MySingleProject.ccTextBox();
            this.pnlFindIdPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOk.Location = new System.Drawing.Point(34, 203);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "로그인";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(178, 203);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(79, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // linklblSignUp
            // 
            this.linklblSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linklblSignUp.AutoSize = true;
            this.linklblSignUp.Location = new System.Drawing.Point(12, 255);
            this.linklblSignUp.Name = "linklblSignUp";
            this.linklblSignUp.Size = new System.Drawing.Size(59, 15);
            this.linklblSignUp.TabIndex = 4;
            this.linklblSignUp.TabStop = true;
            this.linklblSignUp.Text = "회원 가입";
            this.linklblSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblSignUp_LinkClicked);
            // 
            // linklblFPwd
            // 
            this.linklblFPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblFPwd.AutoSize = true;
            this.linklblFPwd.Location = new System.Drawing.Point(229, 255);
            this.linklblFPwd.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.linklblFPwd.Name = "linklblFPwd";
            this.linklblFPwd.Size = new System.Drawing.Size(83, 15);
            this.linklblFPwd.TabIndex = 9;
            this.linklblFPwd.TabStop = true;
            this.linklblFPwd.Text = "비밀번호 찾기";
            this.linklblFPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblFPwd_LinkClicked);
            // 
            // linklblFId
            // 
            this.linklblFId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblFId.AutoSize = true;
            this.linklblFId.Location = new System.Drawing.Point(180, 255);
            this.linklblFId.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.linklblFId.Name = "linklblFId";
            this.linklblFId.Size = new System.Drawing.Size(43, 15);
            this.linklblFId.TabIndex = 5;
            this.linklblFId.TabStop = true;
            this.linklblFId.Text = "아이디";
            this.linklblFId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblFId_LinkClicked);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "/";
            // 
            // pnlFindIdPwd
            // 
            this.pnlFindIdPwd.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFindIdPwd.Controls.Add(this.txtId_F);
            this.pnlFindIdPwd.Controls.Add(this.label6);
            this.pnlFindIdPwd.Controls.Add(this.dateTimePicker1);
            this.pnlFindIdPwd.Controls.Add(this.label7);
            this.pnlFindIdPwd.Controls.Add(this.txtPhone);
            this.pnlFindIdPwd.Controls.Add(this.txtName);
            this.pnlFindIdPwd.Controls.Add(this.lbl1);
            this.pnlFindIdPwd.Controls.Add(this.btnFind);
            this.pnlFindIdPwd.Controls.Add(this.lbl2);
            this.pnlFindIdPwd.Controls.Add(this.btnFindCancel);
            this.pnlFindIdPwd.Location = new System.Drawing.Point(16, 22);
            this.pnlFindIdPwd.Name = "pnlFindIdPwd";
            this.pnlFindIdPwd.Size = new System.Drawing.Size(285, 219);
            this.pnlFindIdPwd.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(68, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 26);
            this.label6.TabIndex = 34;
            this.label6.Text = "ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(145, 94);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 29);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(55, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 26);
            this.label7.TabIndex = 32;
            this.label7.Text = "생년월일";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.Location = new System.Drawing.Point(68, 16);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(71, 26);
            this.lbl1.TabIndex = 28;
            this.lbl1.Text = "이름";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFind.Location = new System.Drawing.Point(18, 181);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 32);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "찾기";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.Location = new System.Drawing.Point(58, 56);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(81, 26);
            this.lbl2.TabIndex = 29;
            this.lbl2.Text = "전화번호";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnFindCancel
            // 
            this.btnFindCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindCancel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFindCancel.Location = new System.Drawing.Point(162, 181);
            this.btnFindCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindCancel.Name = "btnFindCancel";
            this.btnFindCancel.Size = new System.Drawing.Size(100, 32);
            this.btnFindCancel.TabIndex = 5;
            this.btnFindCancel.Text = "취소";
            this.btnFindCancel.UseVisualStyleBackColor = true;
            this.btnFindCancel.Click += new System.EventHandler(this.btnFindCancel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(69, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "비밀번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPwd.Location = new System.Drawing.Point(157, 130);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 29);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.TextType = MySingleProject.InputTextType.IdPwd;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtId.Location = new System.Drawing.Point(156, 67);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 29);
            this.txtId.TabIndex = 0;
            this.txtId.TextType = MySingleProject.InputTextType.IdPwd;
            // 
            // txtId_F
            // 
            this.txtId_F.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId_F.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtId_F.Location = new System.Drawing.Point(145, 135);
            this.txtId_F.Name = "txtId_F";
            this.txtId_F.Size = new System.Drawing.Size(100, 29);
            this.txtId_F.TabIndex = 3;
            this.txtId_F.TextType = MySingleProject.InputTextType.IdPwd;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPhone.Location = new System.Drawing.Point(145, 53);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 29);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.TextType = MySingleProject.InputTextType.PNum;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(145, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 29);
            this.txtName.TabIndex = 0;
            this.txtName.TextType = MySingleProject.InputTextType.Common;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(324, 279);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.pnlFindIdPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linklblFId);
            this.Controls.Add(this.linklblFPwd);
            this.Controls.Add(this.linklblSignUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnlFindIdPwd.ResumeLayout(false);
            this.pnlFindIdPwd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklblSignUp;
        private System.Windows.Forms.LinkLabel linklblFPwd;
        private System.Windows.Forms.LinkLabel linklblFId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFindIdPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnFindCancel;
        private ccTextBox txtPhone;
        private ccTextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private ccTextBox txtId;
        private ccTextBox txtPwd;
        private ccTextBox txtId_F;
        private System.Windows.Forms.Label label6;
    }
}

