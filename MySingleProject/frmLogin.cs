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
    public partial class frmLogin : Form
    {
        bool state = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtId.TextType = txtPwd.TextType = txtId_F.TextType = InputTextType.IdPwd;
            txtName.TextType = InputTextType.Common;
            txtPhone.TextType = InputTextType.PNum;

            HidePnl();

            txtName.Text = "이아파";
            dateTimePicker1.Value = Convert.ToDateTime("1997-02-01").Date;
            txtPhone.Text = "01012345678";
        }

        private void button1_Click(object sender, EventArgs e) //로그인 버튼
        {
            if (!InputFormUtil.CheckEmptyInput(this))
            {
                MessageBox.Show("모든 항목들을 입력해 주세요.");
                return;
            }

            PatientDAO dao = new PatientDAO();
            PatientDTO user = dao.Login(txtId.Text, txtPwd.Text);

            if(user == null)
            {
                MessageBox.Show("아이디또는 비밀번호를 잘못 입력했습니다.\n입력하신 내용을 다시 확인해주세요.");
                return;
            }

            frmMain main = (frmMain)this.Owner;
            main.User = user;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) //로그인 취소 버튼
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //회원가입
        {
            frmSignUp pop = new frmSignUp();
            if (pop.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            PatientDAO dao = new PatientDAO();
            bool result = dao.SignUp(pop.PatientInfo);
            dao.Dispose();

            if (result)
            {
                MessageBox.Show("회원가입이 완료되었습니다.");
            }
            else
                MessageBox.Show("회원가입중 오류가 발생했습니다.\n다시 시도하여 주십시오.");
        }

        private void linklblFId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPnl();

            label6.Visible = false;
            txtId_F.Enabled = false;
            txtId_F.Visible = false;

            state = false;
        } //아이디 찾기

        private void linklblFPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPnl();

            label6.Visible = true;
            txtId_F.Enabled = true;
            txtId_F.Visible = true;

            state = true;
        } //비밀번호 찾기

        private void ShowPnl()
        {
            pnlFindIdPwd.Enabled = true;
            pnlFindIdPwd.Visible = true;
            txtId.Enabled = false;
            txtPwd.Enabled = false;
            txtId.Visible = false;
            txtPwd.Visible = false;
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            btnFind.Enabled = true;
            btnFindCancel.Enabled = true;
            txtName.Focus();
        }

        private void HidePnl()
        {
            pnlFindIdPwd.Enabled = false;
            pnlFindIdPwd.Visible = false;
            txtId.Enabled = true;
            txtPwd.Enabled = true;
            txtId.Visible = true;
            txtPwd.Visible = true;
            btnOk.Enabled = true;
            btnCancel.Enabled = true;
            btnFind.Enabled = false;
            btnFindCancel.Enabled = false;
            txtId.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e) //--진행중--아이디/비밀번호 찾기 버튼
        {
            if (!InputFormUtil.CheckEmptyInput(pnlFindIdPwd))
            {
                MessageBox.Show("모든 항목들을 입력해 주세요.");
                return;
            }
            
            if (state)
            {
                string id = FindId();
                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("입력하신 정보와 일치하는 ID가 없습니다.\n다시 시도해 주세요.");
                    return; 
                }

                MessageBox.Show($"{txtName.Text}님의 아이디는 {id} 입니다.");
            }
            else
            {
                if (!CheckFinePwd())
                {
                    MessageBox.Show("입력하신 정보와 일치하는 사용자가 없습니다.\n다시 시도해 주세요.");
                    return;
                }

                string pwd = ResetPwd();
                if (string.IsNullOrWhiteSpace(pwd))
                {
                    MessageBox.Show("비밀번호 재설정 중 오류가 발생했습니다.\n다시 시도해 주세요.");
                }

                MessageBox.Show($"{txtName.Text}님의 비밀번호가 {pwd} 로 변경되었습니다.\n비밀번호를 꼭 재설정 해 주세요.");
            }
        }

        private string FindId()
        {
            PatientDAO dao = new PatientDAO();
            string id = dao.FindId(txtName.Text, txtPhone.Text.Replace("-", ""), dateTimePicker1.Value.Date);
            return id;
        }

        private bool CheckFinePwd()
        {
            PatientDAO dao = new PatientDAO();
            bool result = dao.CheckFindPwdInfo(txtName.Text, txtPhone.Text.Replace("-", ""), dateTimePicker1.Value.Date, txtId_F.Text);
            return result;
        }

        private string ResetPwd()
        {
            // 정보 유효성 확인
            // 비밀번호 생성
            // update, 출력
            string pwd = SetPassword();
            PatientDAO dao = new PatientDAO();

            bool result = dao.ResetPwd(txtName.Text, txtPhone.Text.Replace("-", ""), dateTimePicker1.Value.Date, txtId_F.Text, pwd);
            dao.Dispose();

            if (!result)
                return null;

            return pwd;
        }

        private void btnFindCancel_Click(object sender, EventArgs e) //아이디/비밀번호 찾기 취소
        {
            HidePnl();
        }

        private string SetPassword()
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 8; i++)
            {
                int temp = rnd.Next(0, 36); //0~35난수 0~9(숫자) 10~35(영어대문자 , A:65)
                if (temp < 10)
                    sb.Append(temp);
                else
                    sb.Append((char)(temp + 55));
            }
            return sb.ToString();
        }
    }
}
