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
    public partial class addaccount : Form
    {
        public addaccount()
        {
            InitializeComponent();
        }
        private MainForm main_form = new MainForm();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql_connection = main_form.Sql_conection();
            try
            {
                sql_connection.Open();
                string insertStr = "insert 管理员信息表 (username,pwd,权限) values" +
                    $"('{tbUserName.Text}','{tbPwd.Text}','{cbAllow.Text}')";
                SqlCommand sql_command = new SqlCommand(insertStr,sql_connection);
                sql_command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
            tbUserName.Clear();
            tbPwd.Clear();
            cbAllow.Text = "";
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            tbUserName.Clear();
            tbPwd.Clear();
            this.Close();
        }
    }
}
