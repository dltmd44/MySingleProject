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
    public partial class frmChangeUserData : Form
    {
        PatientDTO User;

        public frmChangeUserData()
        {
            InitializeComponent();
        }

        private void frmChangeUserData_Load(object sender, EventArgs e)
        {
            frmMain main = (frmMain)this.MdiParent;
            User = main.User;

            txtUserNum.Text = User.PCode;
            txtUserNum.Enabled = false;
            txtUserID.Text = User.PId;
            txtUserID.Enabled = false;
            txtName.Text = User.PName;
            dateTimePicker1.Value = User.PBirthday;
            dateTimePicker1.MaxDate = DateTime.Today;
            txtPNum.Text = User.PPhoneNum;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            string msg = InputFormUtil.CheckInputValid(this, txtUserPwd, txtPwdChk, txtPNum);
            if (!string.IsNullOrWhiteSpace(msg))
            {
                MessageBox.Show(msg);
                return;
            }

            if (MessageBox.Show("입력하신 정보로 회원정보를 변경하시겠습니까?", "회원 정보 수정 확인", MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            string pnum = txtPNum.Text.Replace("-", "");
            PatientDAO dao = new PatientDAO();
            bool result = dao.Update(User.PCode, txtName.Text, txtUserPwd.Text, dateTimePicker1.Value.Date, pnum);
            dao.Dispose();
            if (result)
            {
                MessageBox.Show("정보 수정이 완료되었습니다.");
                frmMain main = (frmMain)this.MdiParent;
                main.User.PName = txtName.Text;
                main.User.PPwd = txtUserPwd.Text;
                main.User.PBirthday = dateTimePicker1.Value.Date;
                main.User.PPhoneNum = pnum;
                main.userToolStripMenuItem.Text = User.PName + "님 ";

                this.Close();
            }
            else
                MessageBox.Show("정보 수정 중 오류가 발생했습니다.\n다시 시도하여 주십시오.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 회원탈퇴 하시겠습니까?\n재가입 시 아이디를 재사용할 수 없습니다.", "회원 탈퇴 확인", MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            PatientDAO dao = new PatientDAO();
            bool result = dao.Delete(User.PId);
            dao.Dispose();

            if (result)
            {
                MessageBox.Show("회원탈퇴가 완료되었습니다.\n그동안 이용해주셔서 감사합니다.");
                Application.Restart();
            }
            else
                MessageBox.Show("정보 수정 중 오류가 발생했습니다.\n다시 시도하여 주십시오.");
        }
    }
}
