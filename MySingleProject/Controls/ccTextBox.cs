using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MySingleProject
{
    public enum InputTextType { Common, IdPwd, PNum}
    public partial class ccTextBox : TextBox
    {
        public InputTextType TextType { get; set; }

        public ccTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void ccTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 스페이스바는 무시
            if (e.KeyChar == 32)
            {
                e.Handled = true;
                return;
            }

            //백스페이스, 탭, 엔터 정상 작동
            if (e.KeyChar == 8 || e.KeyChar == 9)
                return;
                
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                return;
            }

            //Common 영어, 숫자, 한글
            //IdPwd 영어, 숫자, 특수문자
            //PNum 숫자, '-'
            if (this.TextType == InputTextType.Common)
            {
                if (char.IsSymbol(e.KeyChar))
                    e.Handled = true;
                return;
            }

            else if(this.TextType == InputTextType.PNum)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 45)
                    e.Handled = true;
            }
        }

        //NoKor 한글 입력 제한
        private void ccTextBox_Leave(object sender, EventArgs e)
        {
            if (this.TextType != InputTextType.IdPwd)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(this.Text))
                return;

            Regex regex = new Regex(@"[a-zA-Z0-9!@\#$%&]");
            for (int i = 0; i < this.Text.Length; i++)
            {
                bool ismatch = regex.IsMatch(this.Text[i].ToString());
                if (!ismatch)
                {
                    MessageBox.Show("!, @, #, $, %, &을 제외한 특수문자 또는 한글은 입력할 수 없습니다.");
                    this.Text = "";
                    this.Focus();
                }
            }
        }
    }
}
