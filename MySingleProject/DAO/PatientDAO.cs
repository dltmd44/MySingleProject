using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace MySingleProject
{
    class PatientDAO : IDisposable
    {
        MySqlConnection conn;

        public PatientDAO()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            //conn.Open();
        }
        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public PatientDTO Login(string id, string pwd)
        {
            string sql = $@"select PATIENT_CODE, PATIENT_NAME, PATIENT_BIRTH, PATIENT_PHONE, ID
                            from patient
                            where ID = @id and PWD = @pwd and deleted = 0";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@PWD", pwd);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            PatientDTO user = null;
            if (reader.Read())
            {
                user = new PatientDTO
                {
                    PCode = reader["PATIENT_CODE"].ToString(),
                    PName = reader["PATIENT_NAME"].ToString(),
                    PBirthday = Convert.ToDateTime(reader["PATIENT_BIRTH"]),
                    PPhoneNum = reader["PATIENT_PHONE"].ToString(),
                    PId = reader["ID"].ToString(),
                };
            }

            return user;
        }

        public bool CheckIdOverlap(string id)
        {
            string sql = @"select count(*)
                            from patient
                            where ID = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            bool result = Convert.ToBoolean(cmd.ExecuteScalar());
            conn.Close();

            return result;
        }
        
        public bool SignUp(PatientDTO dto)
        {
            string sql = $@"insert into patient(PATIENT_NAME, PATIENT_BIRTH, PATIENT_GENDER, PATIENT_PHONE, ID, PWD)
                        values(@PATIENT_NAME, @PATIENT_BIRTH, @PATIENT_GENDER, @PATIENT_PHONE, @ID, @PWD)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PATIENT_NAME", dto.PName);
            cmd.Parameters.AddWithValue("@PATIENT_BIRTH", dto.PBirthday);
            cmd.Parameters.AddWithValue("@PATIENT_GENDER", dto.PGender);
            cmd.Parameters.AddWithValue("@PATIENT_PHONE", dto.PPhoneNum);
            cmd.Parameters.AddWithValue("@ID", dto.PId);
            cmd.Parameters.AddWithValue("@PWD", dto.PPwd);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }

        public string FindId(string name, string phone, DateTime birth)
        {
            string sql = @"select ID
                            from patient
                            where PATIENT_NAME = @name and PATIENT_BIRTH = @birth
                                and PATIENT_PHONE = @phone and DELETED = 0";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@birth", birth);
            cmd.Parameters.AddWithValue("@phone", phone);

            conn.Open();
            string id = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();

            if (string.IsNullOrWhiteSpace(id))
                return null;

            return id;
        }

        public bool CheckFindPwdInfo(string name, string phone, DateTime birth, string id)
        {
            string sql = @"select count(*)
                            from patient
                            where PATIENT_NAME = @name and PATIENT_BIRTH = @birth
	                            and PATIENT_PHONE = @phone and ID = @id and DELETED = 0";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@birth", birth);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            bool result = Convert.ToBoolean(cmd.ExecuteScalar());
            conn.Close();

            return result;
        }

        public bool ResetPwd(string name, string phone, DateTime birth, string id, string pwd)
        {
            string sql = @"update patient
                            set PWD = @pwd
                            where PATIENT_NAME = @name and PATIENT_BIRTH = @birth 
                                and PATIENT_PHONE = @phone and ID = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@birth", birth);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@id", id);
            
            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }

        public bool Update(string pCode, string name, string pwd, DateTime birth, string phone)
        {
            string sql = $@"update patient
                            set PATIENT_NAME = @name, PATIENT_BIRTH = @birth, PATIENT_PHONE = @phone, PWD = @pwd
                            where PATIENT_CODE = @pCode";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@birth", birth);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.Parameters.AddWithValue("@pCode", pCode);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }

        public bool Delete(string id)
        {
            string sql = $@"update patient
                            set DELETED = b'1'
                            where ID = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();
            conn.Close();

            return (iRowAffect > 0);
        }
    }
}
