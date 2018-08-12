using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆管理系统
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
        private MainForm main_form = new MainForm();
        private void account_Load(object sender, EventArgs e)
        {
            dataGridView3.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView3.DataSource = main_form.Data_set("管理员信息表").Tables[0];
            dataGridView3.DefaultCellStyle.ForeColor = Color.Red;
            dataGridView3.AlternatingRowsDefaultCellStyle.ForeColor = Color.Blue;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string columns = dataGridView3.Columns[e.ColumnIndex].HeaderText + "=" +
                "'" + dataGridView3.CurrentCell.Value.ToString() + "'";
            string id = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            main_form.UpdateValues("管理员信息表",columns,id);
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridView3.Rows[e.RowIndex].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells[0];
                    contextMenuStrip1.Show(Cursor.Position);
                }
                catch
                {
                }

            }
        }

        private void 删除账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您点击了删除按钮，请再次确认是否删除该行", "删除提示", MessageBoxButtons.YesNo);
     
                if (result == DialogResult.Yes)
                {
                    main_form.DeleteRow("管理员信息表", (int)dataGridView3.CurrentRow.Cells[0].Value);
                  

                }
                dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
        }
    }
}
