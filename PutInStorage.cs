using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆管理系统
{
    public partial class PutInStorage : Form
    {
        public PutInStorage()
        {
            InitializeComponent();
        }
        private SqlConnection Sql_connection()
        {
            string connectionStr = "server=.;user=sa;pwd=sqlwxg;database=图书馆管理系统";
            SqlConnection sql_connection = new SqlConnection(connectionStr);
            return sql_connection;
        }
        private bool IsError = true;
        private void InputStorage()
        {
            SqlConnection sql_connection = Sql_connection();
            try
            {
                sql_connection.Open();
                string commandStr = "insert 图书信息表 (编号,书名,作者,出版社,价格,来源,是否借出,种类,入库时间,备注) values" +
                    $"('{tbStorageID.Text}','{tbStorageBookName.Text}','{tbStorageAuthor.Text}','{tbPublishHouse.Text}'," +
                    $"'{Convert.ToDecimal(tbStoragePrice.Text)}','{cbSource.Text}','{cbIsLoan.Text}','{cbType.Text}'," +
                    $"'{dtpStorageDate.Value}','{tbStorageRemark.Text}')";
                SqlCommand sql_command = new SqlCommand(commandStr, sql_connection);
                sql_command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("价格为必填项，请输入有效数字", "录入错误提示");
                tbStoragePrice.Focus();
                IsError = false;
            }
            finally
            {
                sql_connection.Close();
            }

        }
        private void PutInStorage_Load(object sender, EventArgs e)
        {
            tbStorageRemark.Text = "(备注里只能输入20以内的字符)";
            dtpStorageDate.MaxDate = DateTime.Now;
        }

        private void btStorageInput_Click(object sender, EventArgs e)
        {

            InputStorage();

            if (IsError)
            {
                tbStorageID.Clear();
                tbStorageBookName.Clear();
                tbStorageAuthor.Clear();
                tbPublishHouse.Clear();
                tbStoragePrice.Clear();
                cbSource.SelectedItem = false;
                cbIsLoan.SelectedItem = false;
                cbType.SelectedItem = false;
                dtpStorageDate.Value = dtpStorageDate.MaxDate;
                tbStorageRemark.Clear();
                tbStorageID.Focus();
            }
            else
            {
                tbStoragePrice.Clear();
                IsError = true;
            }
        }

        private void btStorageClear_Click(object sender, EventArgs e)
        {
            tbStorageID.Clear();
            tbStorageBookName.Clear();
            tbStorageAuthor.Clear();
            tbPublishHouse.Clear();
            tbStoragePrice.Clear();
            cbSource.SelectedItem = false;
            cbIsLoan.SelectedItem = false;
            cbType.SelectedItem = false;
            dtpStorageDate.Value = dtpStorageDate.MaxDate;
            tbStorageRemark.Clear();
        }
    }
}
