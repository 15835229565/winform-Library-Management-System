using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆管理系统
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private DataSet data_set;
        private SqlCommand sql_command;
        private SqlDataReader sql_reader;
        private SqlDataAdapter sql_adapter;
        private int informationNum;
        private int returnNum;
        private int storageNum;
        private int AllPage;
        private int CurrentPage;
        private int PageRows = 21;
        private int RowValue = 0;
        private int AllRowsnum;
        private int startIndex = 0;

        public SqlConnection Sql_conection()
        {
            string connectionStr = "server=.;user=sa;pwd=sqlwxg;database=图书馆管理系统";
            SqlConnection sql_connection = new SqlConnection(connectionStr);
            return sql_connection;
        }
        private void GetPage(string tableStr1)
        {
            CurrentPage = RowValue / PageRows + 1;
            tbCurrentPage.Text = CurrentPage.ToString();

            data_set.Clear();
            sql_adapter.Fill(data_set, RowValue, PageRows, $"{tableStr1}");
            bindingSource1.DataSource = data_set.Tables[0];
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
        }
        public DataSet Data_set(string tableStr)
        {
            SqlConnection sql_connection = Sql_conection();
            data_set = new DataSet();

            try
            {
                sql_connection.Open();
                string adapterStr = $"select * from {tableStr}";
                sql_adapter = new SqlDataAdapter(adapterStr, sql_connection);
                sql_adapter.Fill(data_set, $"{tableStr}");
                AllRowsnum = data_set.Tables[0].Rows.Count;
                AllPage = (AllRowsnum % PageRows == 0) ? (AllRowsnum / PageRows) : (AllRowsnum / PageRows + 1);
                lbAllPage.Text = AllPage.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
            return data_set;
        }
        private void 归还录入ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("拿来练习用的\n图书馆管理简易系统", "关于软件");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult result = MessageBox.Show("请确定是否要退出该应用", "退出提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Visible = true;
            }
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            informationNum++;
            inputInformation input_Information = new inputInformation();
            input_Information.Text = $"借阅信息录入 {informationNum}";
            input_Information.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            returnNum++;
            returnInput return_Input = new returnInput();
            return_Input.Text = $"归还信息录入 {returnNum}";
            return_Input.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            storageNum++;
            PutInStorage putin_storage = new PutInStorage();
            putin_storage.Text = $"入库录入 {storageNum}";
            putin_storage.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            label6.Visible = false;
            bindingNavigator1.Visible = false;
            label1.Text = DateTime.Now.ToLongDateString();
            label6.Text = DateTime.Now.ToLongTimeString();
            dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView2.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView2.BackgroundColor = Color.AliceBlue;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            if (IsHasRows(result))
            {
                tbUser.Text = GetSaveAccount("username");
                tbPwd.Text = GetSaveAccount("pwd");
                if (tbPwd.Text=="password")
                {
                    tbPwd.Clear();
                }
            }
        }

        private void tbMainID_TextChanged(object sender, EventArgs e)
        {
            tbMainBookName1.Enabled = false;
            tbMainBookNum1.Enabled = false;
            tbMainBookNum2.Enabled = false;
            if (tbMainID.Text == "")
            {
                tbMainBookName1.Enabled = true;
                tbMainBookNum1.Enabled = true;
                tbMainBookNum2.Enabled = true;
            }
        }

        private void tbMainBookID1_TextChanged(object sender, EventArgs e)
        {
            tbMainID.Enabled = false;
            tbMainBookName1.Enabled = false;
            tbMainBookNum2.Enabled = false;
            if (tbMainBookNum1.Text == "")
            {
                tbMainID.Enabled = true;
                tbMainBookName1.Enabled = true;
                tbMainBookNum2.Enabled = true;
            }
        }

        private void tbMainBookName1_TextChanged(object sender, EventArgs e)
        {
            tbMainID.Enabled = false;
            tbMainBookNum1.Enabled = false;
            tbMainBookNum2.Enabled = false;
            if (tbMainBookName1.Text == "")
            {
                tbMainID.Enabled = true;
                tbMainBookNum1.Enabled = true;
                tbMainBookNum2.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label6.Text = DateTime.Now.ToLongTimeString();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            RowValue = 0;
            if (tbMainBookNum2.Text != "")
            {
                IdCardCheck_1("图书信息表", "编号", tbMainBookNum2.Text);

            }
            else if (tbMainBookName1.Text != "")
            {
                IdCardCheck_1("图书信息表", "书名", tbMainBookName1.Text);
            }
            else
            {
                dataGridView1.DataSource = Data_set("图书信息表").Tables[0];
                GetPage("图书信息表");
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch
            {

            }
        }
        public void DeleteRow(string deletetableStr, int deleteID)
        {
            SqlConnection sql_connection = Sql_conection();
            data_set = new DataSet();
            try
            {
                sql_connection.Open();
                string adapterStr = $"delete {deletetableStr} where id = '{deleteID}'";
                SqlDataAdapter sql_adapter = new SqlDataAdapter(adapterStr, sql_connection);
                sql_adapter.Fill(data_set, $"{deletetableStr}");
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

        private void 删除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您点击了删除按钮，请再次确认是否删除该行", "删除提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataGridView1.Visible)
                {
                    DeleteRow("图书信息表", (int)dataGridView1.CurrentRow.Cells[0].Value);
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    DeleteRow("借阅表", (int)dataGridView2.CurrentRow.Cells[0].Value);
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            RowValue = 0;
            if (tbMainID.Text != "")
            {
                IdCardCheck_1("借阅表", "身份证号", tbMainID.Text);
            }
            else if (tbMainBookNum1.Text != "")
            {
                IdCardCheck_1("借阅表", "编号", tbMainBookNum1.Text);
            }
            else
            {
                dataGridView2.DataSource = Data_set("借阅表").Tables[0];
                GetPage("借阅表");
            }
        }

        public void IsBorrwo(string borrowStr, string numStr)
        {
            data_set = new DataSet();
            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();
                string updateStr = $"update 图书信息表 set 是否借出='{borrowStr}' where 编号 ='{numStr}' ";
                sql_command = new SqlCommand(updateStr, sql_connection);
                sql_command.ExecuteScalar();
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

        private void tbMainBookNum2_TextChanged(object sender, EventArgs e)
        {
            tbMainID.Enabled = false;
            tbMainBookNum1.Enabled = false;
            tbMainBookName1.Enabled = false;
            if (tbMainBookNum2.Text == "")
            {
                tbMainID.Enabled = true;
                tbMainBookNum1.Enabled = true;
                tbMainBookName1.Enabled = true;
            }
        }
        private void IdCardCheck_1(string table, string column, string idcard)
        {
            SqlConnection sql_connection = Sql_conection();
            data_set = new DataSet();
            try
            {
                sql_connection.Open();
                string adapterStr = $"select * from {table} where {column}='{idcard}'";
                sql_adapter = new SqlDataAdapter(adapterStr, sql_connection);
                sql_adapter.Fill(data_set, $"{table}");
                dataGridView1.DataSource = data_set.Tables[0];
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
    
        private void button3_Click(object sender, EventArgs e)
        {
            tbMainID.Clear();
            //tbMainID.Enabled = true;
            tbMainBookNum1.Clear();
            //tbMainBookNum1.Enabled = true;
            tbMainBookNum2.Clear();
            //tbMainBookNum2.Enabled = true;
            tbMainBookName1.Clear();
            //tbMainBookName1.Enabled = true;
        }
        public void UpdateValues(string tablename, string columns, string id)
        {
            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();
                string updateStr = $"update {tablename} set {columns} where id = {id} ";
                sql_command = new SqlCommand(updateStr, sql_connection);
                sql_command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("价格不能为空，可以用0代替", "更改提示");
                dataGridView1.CurrentCell.Value = "0";
            }
            finally
            {
                sql_connection.Close();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            string columns = dataGridView1.Columns[e.ColumnIndex].HeaderText + "=" +
"'" + dataGridView1.CurrentCell.Value + "'";
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            UpdateValues("图书信息表", columns, id);
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                    dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[0];
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch
            {
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string columns = dataGridView2.Columns[e.ColumnIndex].HeaderText + "=" +
                "'" + dataGridView2.CurrentCell.Value.ToString() + "'";
            string id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            UpdateValues("借阅表", columns, id);
        }

        private void 添加账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addaccount add_account = new addaccount();
            add_account.Show();
        }

        private void 修改删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            account acc_ount = new account();
            acc_ount.Show();
        }
        private bool IsLoad = false;

        private int num = 0;
        private object[] usernameStr;
        private object[] pwdStr;
        private object[] powerStr;
        private int maxAccountNum = 30;//支持同时存在的账户总数量
        private void button2_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            WhichUser();
            if (IsLoad)
            {
                panel1.Visible = false;
                menuStrip1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                bindingNavigator1.Visible = true;
                label6.Visible = true;
                this.MinimumSize = new Size(1034, 776);
                this.MaximumSize = this.MinimumSize;
                this.Size = MinimumSize;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Text = "图书馆简易管理系统";
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView2.EditMode = DataGridViewEditMode.EditOnEnter;
                SaveAccount("username", tbUser.Text);
                if (cbSavePwd.Checked)
                {
                    SaveAccount("pwd", tbPwd.Text);
                }
                else
                {
                    SaveAccount("pwd","password");
                }
            }
            else
            {
                MessageBox.Show("用户登录失败\n请确认账户或密码\n是否输入有误", "登录提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);


            }
        }
        private void WhichUser()
        {
            GetAccount();
            if (IsHasRow)
            {
                for (int i = 0; i < maxAccountNum; i++)
                {
                    if ((string)usernameStr[i] == tbUser.Text && (string)pwdStr[i] == tbPwd.Text && (string)powerStr[i] == "管理员")
                    {
                        IsLoad = true;
                        MessageBox.Show($"欢迎管理员\n{tbUser.Text}登录", "登录提示");

                    }
                    else if ((string)usernameStr[i] == tbUser.Text && (string)pwdStr[i] == tbPwd.Text && (string)powerStr[i] == "普通用户")
                    {
                        IsLoad = true;
                        MessageBox.Show($"欢迎普通用户\n{tbUser.Text}登录", "登录提示");
                    }
                    if (IsLoad)
                    {
                        maxAccountNum = i + 1;
                    }
                }
                if (CheckPower(tbUser.Text) != "管理员")
                {
                    添加用户ToolStripMenuItem.Enabled = false;
                    删除选中行ToolStripMenuItem.Visible = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView2.ReadOnly = true;
                }
                else
                {
                    添加用户ToolStripMenuItem.Enabled = true;
                    删除选中行ToolStripMenuItem.Visible = true;
                    dataGridView1.ReadOnly = false;
                    dataGridView2.ReadOnly = false;
                }
            }
            else
            {
                IsLoad = true;
                MessageBox.Show("欢迎使用，检测到您当前未添加账户\n为了信息安全性，建议您及时添加账户信息","登录提示");
            }
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private bool IsHasRow;
        private void GetAccount()
        {
            SqlConnection sql_connection = Sql_conection();
            usernameStr = new object[maxAccountNum];
            pwdStr = new object[maxAccountNum];
            powerStr = new object[maxAccountNum];
            try
            {
                sql_connection.Open();
                string selectStr = $"select * from 管理员信息表";
                sql_command = new SqlCommand(selectStr, sql_connection);
                sql_reader = sql_command.ExecuteReader();
                IsHasRow = sql_reader.HasRows;
                while (sql_reader.Read())
                {
                    if (num < maxAccountNum)
                    {
                        usernameStr[num] = sql_reader[1];
                        pwdStr[num] = sql_reader[2];
                        powerStr[num] = sql_reader[3];
                        num++;
                    }
                }
                sql_reader.Close();
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
        private string power_Str;

        private string CheckPower(string powerStr)
        {

            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();
                string selectStr = $"select 权限 from 管理员信息表 where username='{powerStr}'";
                sql_command = new SqlCommand(selectStr, sql_connection);
                power_Str = (string)sql_command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
            return power_Str;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1, label3.Text.Length - 1) + label3.Text.Substring(0, 1);
            if (DateTime.Now.Second%2==0)
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.Blue;
            }
        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "上一页")
            {
                RowValue -= PageRows;
                startIndex -= PageRows;
                if (RowValue < 0)
                {
                    RowValue = 0;
                    startIndex = 0;
                    MessageBox.Show("当前已是第一页", "翻页提示");
                }
                if (dataGridView1.Visible)
                {
                    GetPage("图书信息表");
                }
                else
                {
                    GetPage("借阅表");
                }
            }
            if (e.ClickedItem.Text == "下一页")
            {
                RowValue += PageRows;
                startIndex += PageRows;
                if (RowValue >= AllRowsnum)
                {
                    RowValue -= PageRows;
                    startIndex -= PageRows;
                    MessageBox.Show("当前已是最后页", "翻页提示");
                }
                if (dataGridView1.Visible)
                {
                    GetPage("图书信息表");
                }
                else
                {
                    GetPage("借阅表");
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rec = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1 + startIndex).ToString(),
                dataGridView1.DefaultCellStyle.Font, rec, dataGridView1.DefaultCellStyle.ForeColor,
                dataGridView1.DefaultCellStyle.BackColor);
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rec = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y,
                dataGridView2.RowHeadersWidth, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1 + startIndex).ToString(),
                dataGridView2.DefaultCellStyle.Font, rec, dataGridView2.DefaultCellStyle.ForeColor,
                dataGridView2.DefaultCellStyle.BackColor);
        }

        private void tbPwd_TextChanged(object sender, EventArgs e)
        {
            tbPwd.PasswordChar = '*';
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("价格或日期更改后的格式有问题，请重新更改", "更改提示");
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("日期更改后的格式有问题，请重新更改", "更改提示");
        }

        private bool result = true;
        private void SaveAccount(string nameStr, string text)
        {
            SqlConnection sql_connection = Sql_conection();
            string changeStr = "";
            try
            {
                sql_connection.Open();
                if (IsHasRows(result))
                {
                    changeStr = $"update 账号记录 set {nameStr}='{text}'";
                }
                else
                {
                    changeStr = $"insert 账号记录 ({nameStr}) values ('{text}')";
                }
                sql_command = new SqlCommand(changeStr, sql_connection);
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

        }
        private string GetSaveAccount(string nameStr)
        {
            string str = "";

            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();

                string commandStr = $"select {nameStr} from 账号记录";
                sql_command = new SqlCommand(commandStr, sql_connection);
                str = (string)sql_command.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
            return str;
        }
        private bool IsHasRows(bool result)
        {
            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();
                string commandStr_1 = "select * from 账号记录";
                sql_command = new SqlCommand(commandStr_1, sql_connection);
                sql_reader = sql_command.ExecuteReader();
                result = sql_reader.HasRows;
                sql_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
            return result;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;                  
            this.MinimumSize = new Size(280, 334);
            this.MaximumSize = this.MinimumSize;
            this.Size = MinimumSize;
            this.Text = "登录窗口";
            tbUser.Clear();
            tbPwd.Clear();
            cbSavePwd.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("请确定是否要退出该应用", "退出提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Visible = true;
            }
        }
    }
}
