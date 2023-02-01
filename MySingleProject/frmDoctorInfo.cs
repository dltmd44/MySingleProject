using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySingleProject
{
    public partial class frmDoctorInfo : Form
    {
        DataTable docDt;
        DataTable commDt;
        bool eventEdded = false;

        public frmDoctorInfo()
        {
            InitializeComponent();
        }

        private void frmDoctorInfo_Load(object sender, EventArgs e)
        {
            lblSubject.Text = lblDocName.Text= "";
            dataGridView1.Rows.Add("시간", "월", "화", "수", "목", "금", "토", "일");
            dataGridView1.Rows.Add("오전");
            dataGridView1.Rows.Add("오후");

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 58;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 40;
            }
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White; dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonCodeDAO commdb = new CommonCodeDAO();
            commDt = commdb.GetCommonCode("subject");
            commdb.Dispose();

            DoctorDAO doctorDb = new DoctorDAO();
            docDt = doctorDb.GetDocList();
            doctorDb.Dispose();

            cboSubject.DisplayMember = "DETAIL";
            cboSubject.ValueMember = "CODE";
            cboSubject.DataSource = commDt;

            cboDocName.DisplayMember = "DOCTOR_NAME";
            cboDocName.ValueMember = "DOCTOR_CODE";
            cboDocName.Text = "---";
            cboDocName.Enabled = false;

            cboSubject.SelectedIndexChanged += cboSubject_SelectedIndexChanged;
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboDocName.Enabled)
                cboDocName.Enabled = true;

            docDt.DefaultView.RowFilter = string.Format($"[SUBJECT_CODE] = '{cboSubject.SelectedValue}'");
            cboDocName.DataSource = docDt;

            if (!eventEdded)
            {
                cboDocName.SelectedIndexChanged += cboDocName_SelectedIndexChanged;
                eventEdded = true;
            }

            lblSubject.Text = lblDocName.Text = txtDocIntroduction.Text = null;
            pictureBoxDoc.Image = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void cboDocName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSubject.Text = cboSubject.Text;
            lblDocName.Text = cboDocName.Text;

            DoctorDAO docDao = new DoctorDAO();
            DataTable infoDt =  docDao.GetDocInfo(cboDocName.SelectedValue.ToString());
            docDao.Dispose();

            CommonCodeDAO tblDao = new CommonCodeDAO();
            DataTable tblDt = tblDao.GetTimeTable(cboDocName.SelectedValue.ToString());
            tblDao.Dispose();   

            string text = infoDt.Rows[0]["DOCTOR_INTRODUCTION"].ToString();
            txtDocIntroduction.Text = Regex.Replace(text, "(?<!\r)\n", "\r\n");

            if (infoDt.Rows[0]["DOCTOR_PICTURE"] != DBNull.Value)
            {
                byte[] imgData = (byte[])(infoDt.Rows[0]["DOCTOR_PICTURE"]);
                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    pictureBoxDoc.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxDoc.Image = Image.FromFile("Images/noImage.png");
            }

            //시간표
            for (int i = 1; i < tblDt.Columns.Count; i++)
            {
                switch (tblDt.Rows[0][i].ToString())
                {
                    case "A301"://없
                        dataGridView1.Rows[1].Cells[i].Style.BackColor = Color.White;
                        dataGridView1.Rows[2].Cells[i].Style.BackColor = Color.White;
                        break;
                    case "A302"://전
                        dataGridView1.Rows[1].Cells[i].Style.BackColor = Color.DeepSkyBlue;
                        dataGridView1.Rows[2].Cells[i].Style.BackColor = Color.White;
                        break;
                    case "A303"://후
                        dataGridView1.Rows[1].Cells[i].Style.BackColor = Color.White;
                        dataGridView1.Rows[2].Cells[i].Style.BackColor = Color.DeepSkyBlue;
                        break;
                    default://종
                        dataGridView1.Rows[1].Cells[i].Style.BackColor = Color.DeepSkyBlue;
                        dataGridView1.Rows[2].Cells[i].Style.BackColor = Color.DeepSkyBlue;
                        break;
                }
            }
        }
    }
}
