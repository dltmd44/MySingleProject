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
    public partial class frmSignUp : Form
    {
        public PatientDTO PatientInfo {
            get
            {
                return new PatientDTO
                {
                    PId = txtId.Text,
                    PPwd = txtPwd.Text,
                    PName = txtName.Text,
                    PBirthday = dateTimePicker1.Value,
                    PPhoneNum = txtPNum.Text.Replace("-", "")
                };
            }
        }
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            txtId.TextType = txtPwd.TextType = txtPwdChk.TextType = InputTextType.IdPwd;
            txtPNum.TextType = InputTextType.PNum;

            dateTimePicker1.MaxDate = DateTime.Today;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!InputFormUtil.CheckEmptyInput(this))
            {
                MessageBox.Show("모든 항목을 입력해 주세요.");
                return;
            }

            if(txtId.Text.Length < 6)
            {
                MessageBox.Show("아이디는 6글자 이상이어야 합니다.");
                return;
            }

            PatientDAO dao = new PatientDAO();
            if (dao.CheckIdOverlap(txtId.Text))
            {
                MessageBox.Show("이미 존재하거나 탈퇴한 회원의 ID입니다.\n다른 아이디를 입력해 주세요.");
                dao.Dispose();
                return;
            }
            dao.Dispose();

            string msg = InputFormUtil.CheckInputValid(this, txtPwd, txtPwdChk, txtPNum);
            if (!string.IsNullOrWhiteSpace(msg))
            {
                MessageBox.Show(msg);
                return;
            }

            if (MessageBox.Show("입력하신 정보로 회원가입을 진행하시겠습니까?", "회원가입 확인", MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }   
    }
}
