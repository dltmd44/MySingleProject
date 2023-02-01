using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySingleProject
{
    public class DataGridViewUtil
    {
        public static void SetInitDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersWidth = 20;
        }

        public static void AddGridTextBoxColumn(
            DataGridView dgv,
            string headerText,
            string propertyName,
            int colWidth = 100,
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
            bool visible = true,
            bool frosen = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = propertyName;
            col.HeaderText = headerText;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Alignment : 가운데정렬 (길이가 고정적인 경우)
            //Alignment : 왼쪽정렬 (길이가 가변적인 문자열인 경우)
            //Alignment : 오른쪽정렬 (길이가 가변적인 숫자인 경우, 돈, 수량 등)
            col.DataPropertyName = propertyName;
            col.DefaultCellStyle.Alignment = align;
            col.Width = colWidth;
            col.ReadOnly = true;
            col.Visible = visible;
            col.Frozen = frosen;

            dgv.Columns.Add(col);
        }
    }
}
