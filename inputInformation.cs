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
    public partial class inputInformation : Form
    {
        public inputInformation()
        {
            InitializeComponent();
        }
        
        private void 借阅信息录入_Load(object sender, EventArgs e)
        {
            dtpBorrowDate.MaxDate = DateTime.Now;
            dtpReturnDate.MinDate = DateTime.Now;
        }
        private MainForm main_fomr = new MainForm();
        private void button1_Click(object sender, EventArgs e)
        {
                Borrow(tbBorrowID.Text, tbBorrowNum.Text, tbBorrowName.Text, cbBorrowGender.Text,
                dtpBorrowDate.Value, dtpReturnDate.Value, tbBorrowText.Text);
                main_fomr.IsBorrwo("是", $"{tbBorrowNum.Text}");
                tbBorrowID.Clear();
                tbBorrowNum.Clear();
                tbBorrowName.Clear();
                cbBorrowGender.SelectedText = "";
                dtpBorrowDate.Value = dtpBorrowDate.MaxDate;
                dtpReturnDate.Value = dtpReturnDate.MinDate;
                tbBorrowText.Clear();
         }
        public void Borrow(string id,string num,string name,string gender,DateTime borrowdate,DateTime returndate
            ,string text)
        {
            DataSet data_set = new DataSet();
            SqlConnection sql_connection = main_fomr.Sql_conection();
            try
            {
                sql_connection.Open();
                string adapterStr = "insert 借阅表 (身份证号,编号,姓名,性别,借阅日期,应还日期,备注)values" +
                    $"('{id}','{num}','{name}','{gender}'," +
                    $"'{borrowdate}','{returndate}','{text}')";
                SqlDataAdapter sql_adapter = new SqlDataAdapter(adapterStr,sql_connection);
                sql_adapter.Fill(data_set,"借阅表");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
        }

        private void btStorageClear_Click(object sender, EventArgs e)
        {
            tbBorrowID.Clear();
            tbBorrowNum.Clear();
            tbBorrowName.Clear();
            cbBorrowGender.SelectedText = "";
            dtpBorrowDate.Value = dtpBorrowDate.MaxDate;
            dtpReturnDate.Value = dtpReturnDate.MinDate;
            tbBorrowText.Clear();
        }
    }
}
