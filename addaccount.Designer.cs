namespace 图书馆管理系统
{
    partial class addaccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAllow = new System.Windows.Forms.ComboBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btCancle = new System.Windows.Forms.Button();
            this.btEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "权  限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "密  码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "账户名";
            // 
            // cbAllow
            // 
            this.cbAllow.FormattingEnabled = true;
            this.cbAllow.Items.AddRange(new object[] {
            "管理员",
            "普通用户"});
            this.cbAllow.Location = new System.Drawing.Point(174, 122);
            this.cbAllow.Name = "cbAllow";
            this.cbAllow.Size = new System.Drawing.Size(147, 23);
            this.cbAllow.TabIndex = 3;
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(174, 70);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(147, 25);
            this.tbPwd.TabIndex = 2;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(174, 30);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(147, 25);
            this.tbUserName.TabIndex = 1;
            // 
            // btCancle
            // 
            this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancle.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btCancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancle.Location = new System.Drawing.Point(246, 180);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 33);
            this.btCancle.TabIndex = 5;
            this.btCancle.Text = "取  消";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // btEnter
            // 
            this.btEnter.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btEnter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnter.Location = new System.Drawing.Point(86, 180);
            this.btEnter.Name = "btEnter";
            this.btEnter.Size = new System.Drawing.Size(75, 33);
            this.btEnter.TabIndex = 4;
            this.btEnter.Text = "确  定";
            this.btEnter.UseVisualStyleBackColor = true;
            this.btEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // addaccount
            // 
            this.AcceptButton = this.btEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.CancelButton = this.btCancle;
            this.ClientSize = new System.Drawing.Size(401, 239);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAllow);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btEnter);
            this.Name = "addaccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加账户";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAllow;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btCancle;
        private System.Windows.Forms.Button btEnter;
    }
}