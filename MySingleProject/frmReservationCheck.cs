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
    public partial class frmReservationCheck : Form
    {
        PatientDTO User;
        DataTable appoList;
        DataTable timeTableDt;
        string dow;

        BindingList<object> timeList = new BindingList<object>();

        public frmReservationCheck()
        {
            InitializeComponent();
        }

        private void frmReservationCheck_Load(object sender, EventArgs e)
        {
            frmMain main = (frmMain)this.MdiParent;
            User = main.User;

            txtPNum.Text = User.PCode;
            txtPNum.Enabled = false;
            txtName.Text = User.PName;
            txtName.Enabled = false;

            AppointmentDAO adb = new AppointmentDAO();
            appoList = adb.FindAppoList(User.PCode);
            adb.Dispose();

            comboBox4.DisplayMember = "APPOINT_CODE";
            comboBox4.ValueMember = "APPOINT_CODE";
            comboBox4.DataSource = appoList;

            dateTimePicker1.Enabled = false;
            cboAppoTime.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCat.Text = appoList.Rows[comboBox4.SelectedIndex]["DETAIL"].ToString();
            txtCat.Enabled = false;
            txtDoc.Text = appoList.Rows[comboBox4.SelectedIndex]["DOCTOR_NAME"].ToString();
            txtDoc.Enabled = false;

            CommonCodeDAO cdb = new CommonCodeDAO();
            timeTableDt = cdb.GetTimeTable(appoList.Rows[comboBox4.SelectedIndex]["DOCTOR_CODE"].ToString());
            cdb.Dispose();

            //dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(14);
            dateTimePicker1.Value = Convert.ToDateTime(appoList.Rows[comboBox4.SelectedIndex]["APPOINT_DATE"]).Date;

            dateTimePicker1.Enabled = false;
            cboAppoTime.Enabled = false;
        }

        private void txtPNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!cboAppoTime.Enabled)
                cboAppoTime.Enabled = true;
            timeList.Clear();
            dow = InputFormUtil.GetDow(dateTimePicker1.Value.ToString("dddd"));
            AppointmentDAO dao = new AppointmentDAO();
            DataSet ds = dao.CheckAvailableTime(dateTimePicker1.Value.Date,
                appoList.Rows[comboBox4.SelectedIndex]["DOCTOR_CODE"].ToString(), User.PCode);
            ds.Tables[0].Merge(ds.Tables[1]);

            switch (timeTableDt.Rows[0][dow].ToString())
            {
                case "A301":
                    cboAppoTime.Text = "진료 없음";
                    cboAppoTime.Enabled = false;
                    break;
                case "A302":
                    InputFormUtil.SetAppoTimeCbo(1, ds.Tables[0], timeList);
                    break;
                case "A303":
                    InputFormUtil.SetAppoTimeCbo(0, ds.Tables[0], timeList);
                    break;
                default:
                    InputFormUtil.SetAppoTimeCbo(1, ds.Tables[0], timeList);
                    InputFormUtil.SetAppoTimeCbo(0, ds.Tables[0], timeList);
                    break;
            }

            cboAppoTime.DisplayMember = "Text";
            cboAppoTime.ValueMember = "Value";
            cboAppoTime.DataSource = timeList;
        }

        private void cboAppoTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            cboAppoTime.Enabled = true;
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            if (!dateTimePicker1.Enabled)
            {
                MessageBox.Show("수정된 내용이 없습니다.");
                return;
            }

            if(cboAppoTime.Text == "진료 없음")
            {
                return;
            }

            if (MessageBox.Show("입력하신 정보로 진료 일정을 수정하시겠습니까?", "진료 일정 수정 확인", MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            AppointmentDAO dao = new AppointmentDAO();
            bool result = dao.Update(comboBox4.Text, dateTimePicker1.Value.Date, cboAppoTime.SelectedValue.ToString());
            dao.Dispose();

            if (result)
            {
                MessageBox.Show("진료 일정 수정이 완료되었습니다.");
                this.Close();
            }
            else
            {
                MessageBox.Show("오류가 발생하였습니다. 다시 시도해 주세요.");
                return;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 진료의 예약을 취소하시겠습니까?", "진료 예약 취소 확인", MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            AppointmentDAO dao = new AppointmentDAO();
            bool result = dao.Delete(comboBox4.Text);
            dao.Dispose();

            if (result)
            {
                MessageBox.Show("진료 예약이 취소되었습니다.");
                this.Close();
            }
            else
            {
                MessageBox.Show("오류가 발생하였습니다. 다시 시도해 주세요.");
                return;
            }
        }
    }
}
