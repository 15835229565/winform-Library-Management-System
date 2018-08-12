﻿using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int informationNum;
        private int returnNum;
        private int storageNum;
        public SqlConnection Sql_conection()
        {
            string connectionStr = "server=.;user=sa;pwd=sqlwxg;database=图书馆管理系统";
            SqlConnection sql_connection = new SqlConnection(connectionStr);
            return sql_connection;
        }
        public DataSet Data_set(string tableStr)
        {
            SqlConnection sql_connection = Sql_conection();
            DataSet data_set = new DataSet();

            try
            {
                sql_connection.Open();
                string adapterStr = $"select * from {tableStr}";
                SqlDataAdapter sql_adapter = new SqlDataAdapter(adapterStr, sql_connection);
                sql_adapter.Fill(data_set, $"{tableStr}");

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
            //label1.ForeColor = Color.Blue;
            //label6.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView2.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

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
            DataSet data_set = new DataSet();
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
            if (tbMainID.Text != "")
            {
                IdCardCheck_2("借阅表", "身份证号", tbMainID.Text);
            }
            else if (tbMainBookNum1.Text != "")
            {
                IdCardCheck_2("借阅表", "编号", tbMainBookNum1.Text);
            }
            else
            {
                dataGridView2.DataSource = Data_set("借阅表").Tables[0];
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Enabled = true;
            if (toolStripTextBox2.Text == "临时记录框")
            {
                toolStripTextBox2.Clear();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Enabled = false;
        }
        public void IsBorrwo(string borrowStr, string numStr)
        {
            DataSet data_set = new DataSet();
            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();
                string updateStr = $"update 图书信息表 set 是否借出='{borrowStr}' where 编号 ='{numStr}' ";
                SqlCommand sql_command = new SqlCommand(updateStr, sql_connection);
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
            DataSet data_set = new DataSet();
            try
            {
                sql_connection.Open();
                string adapterStr = $"select * from {table} where {column}='{idcard}'";
                SqlDataAdapter sql_adapter = new SqlDataAdapter(adapterStr, sql_connection);
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
        private void IdCardCheck_2(string table, string column, string idcard)
        {
            SqlConnection sql_connection = Sql_conection();
            DataSet data_set = new DataSet();
            try
            {
                sql_connection.Open();
                string adapterStr = $"select * from {table} where {column}='{idcard}'";
                SqlDataAdapter sql_adapter = new SqlDataAdapter(adapterStr, sql_connection);
                sql_adapter.Fill(data_set, $"{table}");
                dataGridView2.DataSource = data_set.Tables[0];
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
            tbMainID.Enabled = true;
            tbMainBookNum1.Clear();
            tbMainBookNum1.Enabled = true;
            tbMainBookNum2.Clear();
            tbMainBookNum2.Enabled = true;
            tbMainBookName1.Clear();
            tbMainBookName1.Enabled = true;
        }
        public void UpdateValues(string tablename, string columns, string id)
        {
            SqlConnection sql_connection = Sql_conection();
            try
            {
                sql_connection.Open();
                string updateStr = $"update {tablename} set {columns} where id = {id} ";
                SqlCommand sql_command = new SqlCommand(updateStr, sql_connection);
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string columns = dataGridView1.Columns[e.ColumnIndex].HeaderText + "=" +
                "'" + dataGridView1.CurrentCell.Value.ToString() + "'";
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


        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            GetAccount();
            if (IsHasRow)
            {
                for (int i = 0; i < maxAccountNum; i++)
                {

                    if ((string)usernameStr[i] == tbUser.Text && (string)pwdStr[i] == tbPwd.Text && (string)powerStr[i] == "管理员")
                    {
                        IsLoad = true;
                        MessageBox.Show($"欢迎管理员{tbUser.Text}登录", "登录提示");

                    }
                    else if ((string)usernameStr[i] == tbUser.Text && (string)pwdStr[i] == tbPwd.Text && (string)powerStr[i] == "普通用户")
                    {
                        IsLoad = true;
                        MessageBox.Show($"欢迎普通用户{tbUser.Text}登录", "登录提示");

                    }
                    if (IsLoad)
                    {
                        maxAccountNum = i + 1;
                    }

                }
                if (CheckPower(tbUser.Text) != "管理员")
                {
                    添加用户ToolStripMenuItem.Enabled = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView2.ReadOnly = true;
                }
                else
                {
                    添加用户ToolStripMenuItem.Enabled = true;
                    dataGridView1.ReadOnly = false;
                    dataGridView2.ReadOnly = false;
                }
            }
            else
            {
                IsLoad = true;
            }
            

            if (IsLoad)
            {
                panel1.Visible = false;
                menuStrip1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                bindingNavigator1.Visible = true;
                label6.Visible = true;
                this.MinimumSize = new Size(1000, 800);
                this.MaximumSize = this.MinimumSize;
                this.Size = MinimumSize;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Text = "图书馆简易管理系统";
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView2.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            else
            {
                MessageBox.Show("用户登录失败，请确认账户或密码是否输入有误", "登录提示");

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
                SqlCommand sql_command = new SqlCommand(selectStr, sql_connection);
                SqlDataReader sql_reader = sql_command.ExecuteReader();
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
                SqlCommand sql_command = new SqlCommand(selectStr, sql_connection);
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
    }
}