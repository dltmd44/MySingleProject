using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySingleProject
{
    public partial class frmReservationHistory : Form
    {
        string pCode;
        public frmReservationHistory()
        {
            InitializeComponent();
        }

        private void frmReservationHistory_Load(object sender, EventArgs e)
        {
            frmMain main = (frmMain)this.MdiParent;
            pCode = main.User.PCode;

            dateTimePicker2.MaxDate = DateTime.Now.Date.AddDays(14);
            DateTimePickerInit();

            DataGridViewUtil.SetInitDataGridView(dataGridView1);

            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "예약코드", "APPOINT_CODE", align: DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "예약일", "APPOINT_MOMENT",  colWidth : 170);
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "진료(예약)일자", "APPOINT_DATE", colWidth: 90);
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "진료(예약)시간", "time", colWidth: 90);
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "진료과", "DETAIL");
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "의사명", "DOCTOR_NAME", colWidth: 73);
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "예약\n상태", "APPOINT_STAT", colWidth: 87, align: DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextBoxColumn(dataGridView1, "진단", "DIAGNOSIS_DETAIL", visible: false);
            
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void LoadData(int i)
        {
            AppointmentDAO db = new AppointmentDAO();
            DataTable dt = db.GetUserAppoHistory(pCode, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            db.Dispose();

            switch (i) 
            {
                case 0:
                    break;
                case 1:
                    dt.DefaultView.RowFilter = string.Format($"[APPOINT_STAT] = '예약'");
                    break;
                case 2:
                    dt.DefaultView.RowFilter = string.Format($"[APPOINT_STAT] = '예약 취소'");
                    break;
                default:
                    dt.DefaultView.RowFilter = string.Format($"[APPOINT_STAT] = '진료 완료'");
                    break;
            }

            dataGridView1.DataSource = dt;
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.Date;
            dateTimePicker1.Value = dateTimePicker2.Value.Date.AddMonths(-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.Date;
            dateTimePicker1.Value = dateTimePicker2.Value.Date.AddMonths(-3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.Date;
            dateTimePicker1.Value = dateTimePicker2.Value.Date.AddMonths(-6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTimePickerInit();
        }

        private void DateTimePickerInit()
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(14);
        }

        private void button5_Click(object sender, EventArgs e) //검색
        {
            LoadData(0);
        }

        private void button6_Click(object sender, EventArgs e) //예약중 검색
        {
            LoadData(1);
        }

        private void button8_Click(object sender, EventArgs e) //예약 취소 검색
        {
            LoadData(2);
        }

        private void button7_Click(object sender, EventArgs e) //진료 완료 검색
        {
            LoadData(3);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtACode.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtSubject.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            txtDoc.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            string text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
            txtDetail.Text = Regex.Replace(text, "(?<!\r)\n", "\r\n");
        }
    }
}
