
namespace MySingleProject
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.신규예약ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.예약확인변경ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회원정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.예약진료내역ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.병원정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그인ToolStripMenuItem,
            this.회원정보ToolStripMenuItem,
            this.병원정보ToolStripMenuItem,
            this.userToolStripMenuItem,
            this.로그아웃ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.신규예약ToolStripMenuItem,
            this.예약확인변경ToolStripMenuItem});
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.로그인ToolStripMenuItem.Text = "예약";
            // 
            // 신규예약ToolStripMenuItem
            // 
            this.신규예약ToolStripMenuItem.Name = "신규예약ToolStripMenuItem";
            this.신규예약ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.신규예약ToolStripMenuItem.Text = "신규 예약";
            this.신규예약ToolStripMenuItem.Click += new System.EventHandler(this.신규예약ToolStripMenuItem_Click);
            // 
            // 예약확인변경ToolStripMenuItem
            // 
            this.예약확인변경ToolStripMenuItem.Name = "예약확인변경ToolStripMenuItem";
            this.예약확인변경ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.예약확인변경ToolStripMenuItem.Text = "예약 확인/변경";
            this.예약확인변경ToolStripMenuItem.Click += new System.EventHandler(this.예약확인변경ToolStripMenuItem_Click);
            // 
            // 회원정보ToolStripMenuItem
            // 
            this.회원정보ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.예약진료내역ToolStripMenuItem,
            this.정보수정ToolStripMenuItem});
            this.회원정보ToolStripMenuItem.Name = "회원정보ToolStripMenuItem";
            this.회원정보ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.회원정보ToolStripMenuItem.Text = "회원 정보";
            // 
            // 예약진료내역ToolStripMenuItem
            // 
            this.예약진료내역ToolStripMenuItem.Name = "예약진료내역ToolStripMenuItem";
            this.예약진료내역ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.예약진료내역ToolStripMenuItem.Text = "예약/진료 내역";
            this.예약진료내역ToolStripMenuItem.Click += new System.EventHandler(this.예약진료내역ToolStripMenuItem_Click);
            // 
            // 정보수정ToolStripMenuItem
            // 
            this.정보수정ToolStripMenuItem.Name = "정보수정ToolStripMenuItem";
            this.정보수정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보수정ToolStripMenuItem.Text = "정보 수정";
            this.정보수정ToolStripMenuItem.Click += new System.EventHandler(this.정보수정ToolStripMenuItem_Click);
            // 
            // 병원정보ToolStripMenuItem
            // 
            this.병원정보ToolStripMenuItem.Name = "병원정보ToolStripMenuItem";
            this.병원정보ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.병원정보ToolStripMenuItem.Text = "의사 목록";
            this.병원정보ToolStripMenuItem.Click += new System.EventHandler(this.병원정보ToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.userToolStripMenuItem.Text = "XXX 님";
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "종합병원 예약 도우미";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 신규예약ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 예약확인변경ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 예약진료내역ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 병원정보ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
    }
}