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
    class DoctorDAO : IDisposable
    {
        MySqlConnection conn;

        public DoctorDAO()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public DataTable GetAll()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            string sql = $@"select DOCTOR_CODE, SUBJECT_CODE, DOCTOR_NAME, DOCTOR_PICTURE, DOCTOR_INTRODUCTION
                            from doctor;";

            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(dt);

            return dt;
        }

        public DataTable GetDocList()
        {
            string sql = $@"select DOCTOR_CODE, SUBJECT_CODE, DOCTOR_NAME
                            from doctor";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetDocInfo(string docCode)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            string sql = $@"select SUBJECT_CODE, DOCTOR_NAME, DOCTOR_PICTURE, DOCTOR_INTRODUCTION
                            from doctor
                            where DOCTOR_CODE = @docCode;";

            da.SelectCommand = new MySqlCommand(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@docCode", docCode);

            da.Fill(dt);

            return dt;
        }


        public bool InsertImageBLOB(int docID, byte[] imgData)
        {
            string sql = @"update doctor
                            set DOCTOR_PICTURE = @imgData
                            where DOCTOR_CODE = @docID;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@docID", docID);
            cmd.Parameters.AddWithValue("@imgData", imgData);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }
    }
}
