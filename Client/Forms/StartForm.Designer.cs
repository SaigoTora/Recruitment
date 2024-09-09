namespace RecruitmentUser.Forms
{
    partial class StartForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.labelLogin = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.buttonRegister2 = new System.Windows.Forms.Button();
			this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.textBoxPassword2 = new System.Windows.Forms.TextBox();
			this.labelPassword2 = new System.Windows.Forms.Label();
			this.buttonBack = new System.Windows.Forms.Button();
			this.labelRegister1 = new System.Windows.Forms.Label();
			this.pictureBoxTheme = new System.Windows.Forms.PictureBox();
			this.pictureBoxShowPwd = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPwd)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLogin.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLogin.ForeColor = System.Drawing.Color.Black;
			this.textBoxLogin.Location = new System.Drawing.Point(145, 12);
			this.textBoxLogin.MaxLength = 16;
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(225, 36);
			this.textBoxLogin.TabIndex = 2;
			// 
			// labelLogin
			// 
			this.labelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelLogin.AutoSize = true;
			this.labelLogin.BackColor = System.Drawing.Color.Transparent;
			this.labelLogin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLogin.ForeColor = System.Drawing.Color.Black;
			this.labelLogin.Location = new System.Drawing.Point(40, 14);
			this.labelLogin.Name = "labelLogin";
			this.labelLogin.Size = new System.Drawing.Size(99, 32);
			this.labelLogin.TabIndex = 1;
			this.labelLogin.Text = "Логін:";
			this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPassword.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
			this.textBoxPassword.Location = new System.Drawing.Point(145, 90);
			this.textBoxPassword.MaxLength = 16;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(225, 36);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.Tag = "Pwd";
			// 
			// labelPassword
			// 
			this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPassword.AutoSize = true;
			this.labelPassword.BackColor = System.Drawing.Color.Transparent;
			this.labelPassword.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPassword.ForeColor = System.Drawing.Color.Black;
			this.labelPassword.Location = new System.Drawing.Point(12, 92);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(127, 32);
			this.labelPassword.TabIndex = 3;
			this.labelPassword.Text = "Пароль:";
			// 
			// buttonRegister2
			// 
			this.buttonRegister2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRegister2.AutoSize = true;
			this.buttonRegister2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonRegister2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRegister2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRegister2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonRegister2.Location = new System.Drawing.Point(397, 259);
			this.buttonRegister2.Name = "buttonRegister2";
			this.buttonRegister2.Size = new System.Drawing.Size(175, 40);
			this.buttonRegister2.TabIndex = 11;
			this.buttonRegister2.Text = "Продовжити";
			this.buttonRegister2.UseVisualStyleBackColor = false;
			this.buttonRegister2.Visible = false;
			this.buttonRegister2.Click += new System.EventHandler(this.ButtonRegister2_Click);
			// 
			// checkBoxRememberMe
			// 
			this.checkBoxRememberMe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxRememberMe.AutoSize = true;
			this.checkBoxRememberMe.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxRememberMe.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxRememberMe.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxRememberMe.ForeColor = System.Drawing.Color.Black;
			this.checkBoxRememberMe.Location = new System.Drawing.Point(12, 174);
			this.checkBoxRememberMe.Name = "checkBoxRememberMe";
			this.checkBoxRememberMe.Size = new System.Drawing.Size(339, 27);
			this.checkBoxRememberMe.TabIndex = 8;
			this.checkBoxRememberMe.Text = "Запам’ятати мене на цьому ПК:";
			this.checkBoxRememberMe.UseVisualStyleBackColor = false;
			this.checkBoxRememberMe.CheckedChanged += new System.EventHandler(this.CheckBoxRememberMe_CheckedChanged);
			// 
			// buttonLogin
			// 
			this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLogin.AutoSize = true;
			this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLogin.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonLogin.Location = new System.Drawing.Point(397, 259);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(175, 40);
			this.buttonLogin.TabIndex = 9;
			this.buttonLogin.Text = "Вхід";
			this.buttonLogin.UseVisualStyleBackColor = false;
			this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
			// 
			// textBoxPassword2
			// 
			this.textBoxPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPassword2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPassword2.ForeColor = System.Drawing.Color.Black;
			this.textBoxPassword2.Location = new System.Drawing.Point(255, 168);
			this.textBoxPassword2.MaxLength = 16;
			this.textBoxPassword2.Name = "textBoxPassword2";
			this.textBoxPassword2.PasswordChar = '*';
			this.textBoxPassword2.Size = new System.Drawing.Size(225, 36);
			this.textBoxPassword2.TabIndex = 6;
			this.textBoxPassword2.Tag = "Pwd";
			this.textBoxPassword2.Visible = false;
			// 
			// labelPassword2
			// 
			this.labelPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPassword2.AutoSize = true;
			this.labelPassword2.BackColor = System.Drawing.Color.Transparent;
			this.labelPassword2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPassword2.ForeColor = System.Drawing.Color.Black;
			this.labelPassword2.Location = new System.Drawing.Point(12, 170);
			this.labelPassword2.Name = "labelPassword2";
			this.labelPassword2.Size = new System.Drawing.Size(237, 32);
			this.labelPassword2.TabIndex = 5;
			this.labelPassword2.Text = "Підтвердження:";
			this.labelPassword2.Visible = false;
			// 
			// buttonBack
			// 
			this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonBack.AutoSize = true;
			this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(97)))));
			this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonBack.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonBack.Location = new System.Drawing.Point(12, 259);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(175, 40);
			this.buttonBack.TabIndex = 12;
			this.buttonBack.Text = "Назад";
			this.buttonBack.UseVisualStyleBackColor = false;
			this.buttonBack.Visible = false;
			this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
			// 
			// labelRegister1
			// 
			this.labelRegister1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelRegister1.AutoSize = true;
			this.labelRegister1.BackColor = System.Drawing.Color.Transparent;
			this.labelRegister1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelRegister1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRegister1.ForeColor = System.Drawing.Color.Black;
			this.labelRegister1.Location = new System.Drawing.Point(12, 279);
			this.labelRegister1.Name = "labelRegister1";
			this.labelRegister1.Size = new System.Drawing.Size(172, 23);
			this.labelRegister1.TabIndex = 10;
			this.labelRegister1.Text = "Зареєструватись";
			this.labelRegister1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelRegister1.Click += new System.EventHandler(this.LabelRegister1_Click);
			this.labelRegister1.MouseEnter += new System.EventHandler(this.LabelRegister1_MouseEnter);
			this.labelRegister1.MouseLeave += new System.EventHandler(this.LabelRegister1_MouseLeave);
			// 
			// pictureBoxTheme
			// 
			this.pictureBoxTheme.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxTheme.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxTheme.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTheme.Image")));
			this.pictureBoxTheme.Location = new System.Drawing.Point(537, 8);
			this.pictureBoxTheme.Name = "pictureBoxTheme";
			this.pictureBoxTheme.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxTheme.TabIndex = 47;
			this.pictureBoxTheme.TabStop = false;
			this.pictureBoxTheme.Click += new System.EventHandler(this.PictureBoxTheme_Click);
			// 
			// pictureBoxShowPwd
			// 
			this.pictureBoxShowPwd.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxShowPwd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxShowPwd.Image = global::RecruitmentUser.Properties.Resources.eyeClB;
			this.pictureBoxShowPwd.Location = new System.Drawing.Point(376, 94);
			this.pictureBoxShowPwd.Name = "pictureBoxShowPwd";
			this.pictureBoxShowPwd.Size = new System.Drawing.Size(28, 28);
			this.pictureBoxShowPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxShowPwd.TabIndex = 43;
			this.pictureBoxShowPwd.TabStop = false;
			this.pictureBoxShowPwd.Click += new System.EventHandler(this.PictureBoxShowPwd_Click);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			this.ClientSize = new System.Drawing.Size(584, 311);
			this.Controls.Add(this.pictureBoxTheme);
			this.Controls.Add(this.pictureBoxShowPwd);
			this.Controls.Add(this.labelRegister1);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.textBoxPassword2);
			this.Controls.Add(this.labelPassword2);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.checkBoxRememberMe);
			this.Controls.Add(this.buttonRegister2);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.labelLogin);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "StartForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вхід";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
			this.Load += new System.EventHandler(this.StartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPwd)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonRegister2;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxPassword2;
        private System.Windows.Forms.Label labelPassword2;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelRegister1;
        private System.Windows.Forms.PictureBox pictureBoxShowPwd;
        private System.Windows.Forms.PictureBox pictureBoxTheme;
    }
}