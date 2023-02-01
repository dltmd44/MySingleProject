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
    class CommonCodeDAO : IDisposable
    {
        MySqlConnection conn;

        public CommonCodeDAO()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public DataTable GetCommonCode(string category)
        {
            DataTable dt = new DataTable();
            string sql = @"select CODE, CATEGORY, DETAIL
                            from commoncode
                            where CATEGORY = @category";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@category", category);
            da.Fill(dt);

            return dt;
        }

        public DataTable GetCommonCodeList(string[] category)
        {
            DataTable dt = new DataTable();
            string temp = "'" + string.Join("','", category) + "'";
            string sql = @"select CODE, CATEGORY, DETAIL
                            from commoncode
                            where CATEGORY in(" + temp + ");";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            return dt;
        }

        public DataTable GetTimeTable(string docCode)
        {
            DataTable dt = new DataTable();
            string sql = @"select DOCTOR_CODE, MON, TUE, WED, THU, FRI, SAT, SUN
                            from doctor_timetable
                            where DOCTOR_CODE = @docCode";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@docCode", docCode);
            da.Fill(dt);

            return dt;
        }

        //밑에는 PatientDAO가 어울릴듯



        //로그인을 성공하면, UserDTO에 데이터를 담아서 보내는 것이고,
        //로그인을 실패하면, null을 반환하는 메서드
        //public UserDTO GetLoginInfo(string uid, string pwd)
        //{
        //    UserDTO user = null;

        //    string sql = @"select userID, name, birthYear, pwd,
        //                      case when userID = 'BBK' then 'Y'
        //                      else 'N' end IsAdmin
        //                from usertbl
        //                where userID = @userid and pwd = @pwd";

        //    MySqlCommand cmd = new MySqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@userid", uid);
        //    cmd.Parameters.AddWithValue("@pwd", pwd);

        //    conn.Open();
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        user = new UserDTO
        //        {
        //            UserID = reader["userID"].ToString(),
        //            Name = reader["userID"].ToString(),
        //            Pwd = reader["pwd"].ToString(),
        //            BirthYear = Convert.ToInt32(reader["birthYear"]),
        //            Addr = reader["userID"].ToString()
        //        };
        //    }
        //    return user;
        //}


        //public bool IsValidFindPwd(string uid, string name, string email)
        //{
        //    string sql = @"select count(*)
        //                    from usertbl
        //                    where userID = @uid and name = @name and email = @email";

        //    MySqlCommand cmd = new MySqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@uid", uid);
        //    cmd.Parameters.AddWithValue("@name", name);
        //    cmd.Parameters.AddWithValue("@email", email);

        //    conn.Open();
        //    int cnt = Convert.ToInt32(cmd.ExecuteScalar());
        //    conn.Close();

        //    return (cnt > 0);
        //}

        //public bool UpdatePwd(string uid, string pwd)
        //{
        //    string sql = @"update usertbl
        //                    set pwd = @pwd
        //                    where userID = @uid";

        //    MySqlCommand cmd = new MySqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@uid", uid);
        //    cmd.Parameters.AddWithValue("@pwd", pwd);

        //    conn.Open();
        //    int iRowAffect = cmd.ExecuteNonQuery();
        //    conn.Close();

        //    return (iRowAffect > 0);
        //}
    }
}
