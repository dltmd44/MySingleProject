using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySingleProject
{
    public partial class frmMain : Form
    {
        public PatientDTO User { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void 신규예약ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<frmReservation>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Login())
                Application.Exit();

            userToolStripMenuItem.Text = User.PName + "님 ";
        }

        private bool Login()
        {
            //로그인창을 띄워서 로그인이 성공했을 때,
            this.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            frmLogin pop = new frmLogin();
            DialogResult result = pop.ShowDialog(this);

            if (result == DialogResult.None || result == DialogResult.Cancel)
                return false;

            //로그인한 사용자에 따라서 메뉴를 변경
            //if (CurrentUser.IsAdmin == "Y")
            //{
            //    adminMenu.Visible = true;
            //    userMenu.Visible = false;
            //    this.MainMenuStrip = adminMenu;
            //    UserMenuItem.Text = CurrentUser.Name + "님";
            //}
            //else
            //{
            //adminMenu.Visible = false;
            //userMenu.Visible = true;
            //this.MainMenuStrip = userMenu;
            //menuStrip1.Text = user.PName + "님 ";
            //menuStrip1.Text = "환자 님 ";
            //}

            this.Visible = true;
            return true;
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.User = null;
            Login();
        }
        private void OpenCreateForm<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Equals(typeof(T)))
                {
                    form.Activate();
                    form.BringToFront();
                    return;
                }
            }

            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 예약확인변경ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<frmReservationCheck>();
        }

        private void 예약진료내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<frmReservationHistory>();
        }

        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<frmChangeUserData>();
        }

        private void 병원정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<frmDoctorInfo>();
        }
    }
}
