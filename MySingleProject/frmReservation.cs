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
    public partial class frmReservation : Form
    {
        PatientDTO User;
        DataTable commDt;
        DataTable docDt;
        DataTable timeTableDt;
        string dow;

        BindingList<object> timeList = new BindingList<object>();

        public frmReservation()
        {
            InitializeComponent();
        }

        private void frmReservation_Load(object sender, EventArgs e)
        {
            frmMain main = (frmMain)this.MdiParent;
            User = main.User;

            txtPNum.Text = User.PCode;
            txtPNum.Enabled = false;
            txtName.Text = User.PName;
            txtName.Enabled = false;

            CommonCodeDAO commdb = new CommonCodeDAO();
            string[] category = { "subject", "appointM" };
            commDt = commdb.GetCommonCodeList(category);
            commdb.Dispose();

            DoctorDAO doctorDb = new DoctorDAO();
            docDt = doctorDb.GetDocList();
            doctorDb.Dispose();

            DataTable subDt = commDt;
            subDt.DefaultView.RowFilter = string.Format($"[CATEGORY] = 'subject'");
            cboSubject.DisplayMember = "DETAIL";
            cboSubject.ValueMember = "CODE";
            cboSubject.DataSource = subDt;

            cboDocName.DisplayMember = "DOCTOR_NAME";
            cboDocName.ValueMember = "DOCTOR_CODE";
            cboDocName.Text = "---";
            cboDocName.Enabled = false;

            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(14);
            dateTimePicker1.Enabled = false;
            cboAppoTime.Enabled = false;

            cboSubject.SelectedIndexChanged += cboSubject_SelectedIndexChanged;
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboDocName.Enabled)
                cboDocName.Enabled = true;

            docDt.DefaultView.RowFilter = string.Format($"[SUBJECT_CODE] = '{cboSubject.SelectedValue}'");
            cboDocName.DataSource = docDt;
        }

        private void cboDocName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dateTimePicker1.Enabled)
                dateTimePicker1.Enabled = true;

            CommonCodeDAO dao = new CommonCodeDAO();
            timeTableDt = dao.GetTimeTable(Convert.ToString(cboDocName.SelectedValue.ToString()));
            dao.Dispose();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!cboAppoTime.Enabled)
                cboAppoTime.Enabled = true;

            timeList.Clear();
            dow = InputFormUtil.GetDow(dateTimePicker1.Value.ToString("dddd"));


            AppointmentDAO dao = new AppointmentDAO();
            DataSet ds = dao.CheckAvailableTime(dateTimePicker1.Value.Date, cboDocName.SelectedValue.ToString(), User.PCode);
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

            if(cboAppoTime.Enabled)
                cboAppoTime.SelectedIndex = 0;
        }

        private void btnC_Click(object sender, EventArgs e) //유효성 검증 미구현
        {
            Appointment_hisDTO dto = new Appointment_hisDTO
            {
                PatientCode = int.Parse(User.PCode),
                DoctorCode = Convert.ToInt32(cboDocName.SelectedValue),
                AppointDate = dateTimePicker1.Value.Date,
                AppointTimeH = Convert.ToInt16((cboAppoTime.SelectedValue.ToString()).Split('-')[0]),
                AppointTimeM = (cboAppoTime.SelectedValue.ToString()).Split('-')[1]
            };

            AppointmentDAO dao = new AppointmentDAO();
            string appoCode = dao.Insert(dto);

            if (string.IsNullOrWhiteSpace(appoCode))
            {
                MessageBox.Show("진료 예약에 실패했습니다. 다시 시도해주세요.");
                return;
            }

            MessageBox.Show($@"진료 예약이 완료되었습니다.
예약코드:  {appoCode}
진료과:    {cboSubject.Text}
의사:      {cboDocName.Text}
예약일:    {dateTimePicker1.Value.ToString("yyyy년 MM dd일")}
예약 시간: {cboAppoTime.Text}");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}



