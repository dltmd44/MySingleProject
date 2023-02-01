using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySingleProject
{
    class InputFormUtil
    {
        public static bool CheckEmptyInput(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Visible == false)
                    continue;

                if (ctrl is TextBox txtBox)
                {
                    if (string.IsNullOrWhiteSpace(txtBox.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckEmptyInput(Panel frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Visible == false)
                    continue;

                if (ctrl is TextBox txtBox)
                {
                    if (string.IsNullOrWhiteSpace(txtBox.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string CheckInputValid(Form frm, ccTextBox txtPwd, ccTextBox txtPwdChk, ccTextBox txtPNum)
        {
            if (!CheckEmptyInput(frm))
                return "모든 항목을 입력해 주세요.";

            if (txtPwd.Text.Length < 8)
                return "비밀번호는 8글자 이상이어야 합니다.";

            if (txtPwd.Text != txtPwdChk.Text)
                return "비밀번호가 일치하지 않습니다.";

            if (txtPNum.Text.Replace("-", "").Length < 9)
                return "전화번호가 유효하지 않습니다.";

            return null;
        }

        public static string GetDow(string str)
        {
            switch (str)
            {
                case "월요일":
                    return "MON";
                case "화요일":
                    return "TUE";
                case "수요일":
                    return "WED";
                case "목요일":
                    return "THU";
                case "금요일":
                    return "FRI";
                case "토요일":
                    return "SAT";
                default:
                    return "SUN";
            }
        }

        public static void SetAppoTimeCbo(int n, DataTable dt, BindingList<object> timeList) //1은 오전, 0은 오후
        {
            bool appointed = false;
            for (int i = (2 + 7 * n); i < (6 + 7 * n); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string temp = $"{i}시 {15 * j}분";
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        if (dt.Rows[k][0].Equals(temp))
                            appointed = true;
                        break;
                    }

                    if (appointed)
                    {
                        appointed = false;
                        continue;
                    }
                    timeList.Add(new { Text = temp, Value = $"{i}-{15 * j}" });
                }
            }
        }
    }
}
