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
    public partial class returnInput : Form
    {
        public returnInput()
        {
            InitializeComponent();
        }

        private inputInformation input_information = new inputInformation();
        private MainForm main_fomr = new MainForm();
        private void btStorageInput_Click(object sender, EventArgs e)
        {
            input_information.Borrow(textBox4.Text,textBox1.Text, textBox7.Text,cbReturnGender.Text
                ,dateTimePicker1.Value,dateTimePicker2.Value, comboBox1.Text,DateTime.Now,textBox5.Text);
            main_fomr.IsBorrwo("否", $"{textBox1.Text}");
            textBox4.Clear();
            textBox1.Clear();
            textBox7.Clear();
            cbReturnGender.SelectedText="";
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            dateTimePicker2.Value = dateTimePicker2.MinDate;
            comboBox1.SelectedText = "";
            textBox5.Clear();         
        }

        private void returnInput_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Now;
            textBox5.Text = "(备注里只能输入20以内的字符)";
        }

        private void btStorageClear_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox1.Clear();
            textBox7.Clear();
            cbReturnGender.SelectedText = "";
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            dateTimePicker2.Value = dateTimePicker2.MinDate;
            textBox5.Clear();
        }

        private void btReturnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
