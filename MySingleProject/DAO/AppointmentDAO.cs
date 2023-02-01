using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySingleProject
{
    class AppointmentDAO : IDisposable
    {
        MySqlConnection conn;

        public AppointmentDAO()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private string GetAppointCode()
        {
            string sql = $@"select concat(right(date_format(now(), '%Y%m%d'), 6),
                                    lpad((select count(*) + 1
				                        from appointment_his 
				                        where left(APPOINT_CODE, 6) = right(date_format(curdate(), '%y%m%d'), 6)), 4, '0'))";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            string value = cmd.ExecuteScalar().ToString();
            conn.Close();
            return value;
        }

        public string Insert(Appointment_hisDTO dto)
        {
            string appointCode = GetAppointCode();
            string sql = $@"
                insert into appointment_his(APPOINT_CODE, PATIENT_CODE, DOCTOR_CODE, APPOINT_DATE, APPOINT_TIME_H, APPOINT_TIME_M)
                value (@appointment_no,
		        @pcode, @dcode, @date, @hour, @minCode);";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@appointment_no", appointCode);
            cmd.Parameters.AddWithValue("@pcode", dto.PatientCode);
            cmd.Parameters.AddWithValue("@dcode", dto.DoctorCode);
            cmd.Parameters.AddWithValue("@date", dto.AppointDate);
            cmd.Parameters.AddWithValue("@hour", dto.AppointTimeH);
            cmd.Parameters.AddWithValue("@minCode", dto.AppointTimeM);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            if (iRowAffect > 0)
                return appointCode;
            else
                return null;
        }

        public DataSet CheckAvailableTime(DateTime appoDate, string docCode, string pCode)
        {
            DataSet ds = new DataSet();
            string sql = @"select concat(APPOINT_TIME_H, '시 ',  APPOINT_TIME_M, '분') time
                            from appointment_his
                            where APPOINT_DATE = @appoDate and DOCTOR_CODE = @docCode and APPOINT_STAT = 'A201';

                            select concat(APPOINT_TIME_H, '시 ',  APPOINT_TIME_M, '분') time
                            from appointment_his
                            where APPOINT_DATE = @appoDate and PATIENT_CODE = @pCode and APPOINT_STAT = 'A201';";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@appoDate", appoDate);
            da.SelectCommand.Parameters.AddWithValue("@docCode", docCode);
            da.SelectCommand.Parameters.AddWithValue("@pCode", pCode);
            da.Fill(ds);

            return ds;
        }

        public DataTable FindAppoList(string pCode)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT APPOINT_CODE, DETAIL, a.DOCTOR_CODE DOCTOR_CODE, DOCTOR_NAME, APPOINT_DATE, APPOINT_TIME_H, APPOINT_TIME_M, concat(APPOINT_TIME_H, '시 ',  APPOINT_TIME_M, '분') time
                            FROM (select DOCTOR_CODE, SUBJECT_CODE, DOCTOR_NAME from doctor) d inner join appointment_his a on a.DOCTOR_CODE = d.DOCTOR_CODE
                                            inner join commoncode c on d.SUBJECT_CODE = c.CODE
                            WHERE PATIENT_CODE = @pCode and APPOINT_STAT = 'A201'
                            order by APPOINT_CODE";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@pcode", pCode);
            da.Fill(dt);

            return dt;
        }

        public DataTable FindHisByDocCode(string dCode)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT APPOINT_CODE, PATIENT_CODE, DOCTOR_CODE, APPOINT_DATE, APPOINT_TIME_H, 
                                    APPOINT_TIME_M, APPOINT_STAT, APPOINT_MOMENT, DIAGNOSIS_TIME, DIAGNOSIS_DETAIL
                            FROM appointment_his
                            WHERE DOCTOR_CODE = @pcode;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@dcode", dCode);

            da.Fill(dt);

            return dt;
        }

        public bool Update(string aCode, DateTime date, string time)
        {
            string sql = $@"
                update appointment_his
                set APPOINT_DATE=@date, APPOINT_TIME_H = @h, APPOINT_TIME_M = @m
                where APPOINT_CODE = @aCode";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@aCode", aCode);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@h", time.Split('-')[0]);
            cmd.Parameters.AddWithValue("@m", time.Split('-')[1]);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }

        public bool Delete(string aCode)
        {
            string sql = $@"
                update appointment_his
                set APPOINT_STAT = 'A202'
                where APPOINT_CODE = @aCode";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@aCode", aCode);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }

        public DataTable GetUserAppoHistory(string pCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string sql = @"select APPOINT_CODE, APPOINT_MOMENT, APPOINT_DATE, concat(APPOINT_TIME_H, '시 ',  APPOINT_TIME_M, '분') time, 
                                DETAIL, DOCTOR_NAME, (select DETAIL from commoncode where CODE = a.APPOINT_STAT) APPOINT_STAT, DIAGNOSIS_DETAIL        
                            from (select DOCTOR_CODE, SUBJECT_CODE, DOCTOR_NAME from doctor) d 
                                inner join (select * from appointment_his where APPOINT_DATE between @fromDate and @toDate) a on a.DOCTOR_CODE = d.DOCTOR_CODE       
				                inner join (select * from commoncode where PCODE in ('A1', 'A2')) c on d.SUBJECT_CODE = c.CODE
                            where PATIENT_CODE= @pCode";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@pCode", pCode);
            da.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            da.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
            da.Fill(dt);

            return dt;
        }
    }
}
