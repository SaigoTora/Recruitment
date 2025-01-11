namespace RecruitmentClient.Forms
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
			this.labelLogin = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.labelPassword2 = new System.Windows.Forms.Label();
			this.labelRegisterStart = new System.Windows.Forms.Label();
			this.pictureBoxTheme = new System.Windows.Forms.PictureBox();
			this.pictureBoxShowPwd = new System.Windows.Forms.PictureBox();
			this.buttonBack = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonLogin = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonRegisterContinue = new Guna.UI2.WinForms.Guna2GradientButton();
			this.textBoxLogin = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxPassword2 = new Guna.UI2.WinForms.Guna2TextBox();
			this.labelRememberMe = new System.Windows.Forms.Label();
			this.checkBoxRememberMe = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPwd)).BeginInit();
			this.SuspendLayout();
			// 
			// labelLogin
			// 
			this.labelLogin.AutoSize = true;
			this.labelLogin.BackColor = System.Drawing.Color.Transparent;
			this.labelLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelLogin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLogin.ForeColor = System.Drawing.Color.Black;
			this.labelLogin.Location = new System.Drawing.Point(40, 50);
			this.labelLogin.Name = "labelLogin";
			this.labelLogin.Size = new System.Drawing.Size(99, 32);
			this.labelLogin.TabIndex = 1;
			this.labelLogin.Text = "Логін:";
			this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelLogin.Click += new System.EventHandler(this.LabelLogin_Click);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.BackColor = System.Drawing.Color.Transparent;
			this.labelPassword.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelPassword.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPassword.ForeColor = System.Drawing.Color.Black;
			this.labelPassword.Location = new System.Drawing.Point(12, 128);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(127, 32);
			this.labelPassword.TabIndex = 3;
			this.labelPassword.Text = "Пароль:";
			this.labelPassword.Click += new System.EventHandler(this.LabelPassword_Click);
			// 
			// labelPassword2
			// 
			this.labelPassword2.AutoSize = true;
			this.labelPassword2.BackColor = System.Drawing.Color.Transparent;
			this.labelPassword2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelPassword2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPassword2.ForeColor = System.Drawing.Color.Black;
			this.labelPassword2.Location = new System.Drawing.Point(12, 206);
			this.labelPassword2.Name = "labelPassword2";
			this.labelPassword2.Size = new System.Drawing.Size(237, 32);
			this.labelPassword2.TabIndex = 6;
			this.labelPassword2.Text = "Підтвердження:";
			this.labelPassword2.Visible = false;
			this.labelPassword2.Click += new System.EventHandler(this.LabelPassword2_Click);
			// 
			// labelRegisterStart
			// 
			this.labelRegisterStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelRegisterStart.AutoSize = true;
			this.labelRegisterStart.BackColor = System.Drawing.Color.Transparent;
			this.labelRegisterStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelRegisterStart.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRegisterStart.ForeColor = System.Drawing.Color.Black;
			this.labelRegisterStart.Location = new System.Drawing.Point(12, 314);
			this.labelRegisterStart.Name = "labelRegisterStart";
			this.labelRegisterStart.Size = new System.Drawing.Size(172, 23);
			this.labelRegisterStart.TabIndex = 10;
			this.labelRegisterStart.Text = "Зареєструватись";
			this.labelRegisterStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelRegisterStart.Click += new System.EventHandler(this.LabelRegisterStart_Click);
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
			this.pictureBoxTheme.TabIndex = 0;
			this.pictureBoxTheme.TabStop = false;
			this.pictureBoxTheme.Click += new System.EventHandler(this.PictureBoxTheme_Click);
			// 
			// pictureBoxShowPwd
			// 
			this.pictureBoxShowPwd.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxShowPwd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxShowPwd.Image = global::RecruitmentClient.Properties.Resources.eyeClB;
			this.pictureBoxShowPwd.Location = new System.Drawing.Point(405, 130);
			this.pictureBoxShowPwd.Name = "pictureBoxShowPwd";
			this.pictureBoxShowPwd.Size = new System.Drawing.Size(28, 28);
			this.pictureBoxShowPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxShowPwd.TabIndex = 5;
			this.pictureBoxShowPwd.TabStop = false;
			this.pictureBoxShowPwd.Click += new System.EventHandler(this.PictureBoxShowPwd_Click);
			// 
			// buttonBack
			// 
			this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonBack.Animated = true;
			this.buttonBack.BackColor = System.Drawing.Color.Transparent;
			this.buttonBack.BorderRadius = 7;
			this.buttonBack.BorderThickness = 1;
			this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonBack.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonBack.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonBack.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonBack.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonBack.ForeColor = System.Drawing.Color.Black;
			this.buttonBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonBack.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonBack.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonBack.Location = new System.Drawing.Point(12, 294);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.PressedColor = System.Drawing.Color.White;
			this.buttonBack.PressedDepth = 20;
			this.buttonBack.Size = new System.Drawing.Size(175, 40);
			this.buttonBack.TabIndex = 12;
			this.buttonBack.TabStop = false;
			this.buttonBack.Text = "Назад";
			this.buttonBack.Visible = false;
			this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
			// 
			// buttonLogin
			// 
			this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLogin.Animated = true;
			this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
			this.buttonLogin.BorderRadius = 7;
			this.buttonLogin.BorderThickness = 1;
			this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonLogin.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonLogin.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonLogin.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonLogin.ForeColor = System.Drawing.Color.Black;
			this.buttonLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonLogin.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonLogin.Location = new System.Drawing.Point(397, 294);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.PressedColor = System.Drawing.Color.White;
			this.buttonLogin.PressedDepth = 20;
			this.buttonLogin.Size = new System.Drawing.Size(175, 40);
			this.buttonLogin.TabIndex = 11;
			this.buttonLogin.TabStop = false;
			this.buttonLogin.Text = "Вхід";
			this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
			// 
			// buttonRegisterContinue
			// 
			this.buttonRegisterContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRegisterContinue.Animated = true;
			this.buttonRegisterContinue.BackColor = System.Drawing.Color.Transparent;
			this.buttonRegisterContinue.BorderRadius = 7;
			this.buttonRegisterContinue.BorderThickness = 1;
			this.buttonRegisterContinue.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRegisterContinue.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonRegisterContinue.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonRegisterContinue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonRegisterContinue.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonRegisterContinue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonRegisterContinue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonRegisterContinue.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonRegisterContinue.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonRegisterContinue.ForeColor = System.Drawing.Color.Black;
			this.buttonRegisterContinue.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonRegisterContinue.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonRegisterContinue.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonRegisterContinue.Location = new System.Drawing.Point(397, 294);
			this.buttonRegisterContinue.Name = "buttonRegisterContinue";
			this.buttonRegisterContinue.PressedColor = System.Drawing.Color.White;
			this.buttonRegisterContinue.PressedDepth = 20;
			this.buttonRegisterContinue.Size = new System.Drawing.Size(175, 40);
			this.buttonRegisterContinue.TabIndex = 13;
			this.buttonRegisterContinue.TabStop = false;
			this.buttonRegisterContinue.Text = "Продовжити";
			this.buttonRegisterContinue.Visible = false;
			this.buttonRegisterContinue.Click += new System.EventHandler(this.ButtonRegisterContinue_Click);
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Animated = true;
			this.textBoxLogin.AutoScroll = true;
			this.textBoxLogin.BackColor = System.Drawing.Color.Transparent;
			this.textBoxLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxLogin.BorderRadius = 10;
			this.textBoxLogin.BorderThickness = 2;
			this.textBoxLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxLogin.DefaultText = "";
			this.textBoxLogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxLogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxLogin.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLogin.ForeColor = System.Drawing.Color.Black;
			this.textBoxLogin.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxLogin.Location = new System.Drawing.Point(145, 46);
			this.textBoxLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxLogin.MaxLength = 16;
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.PasswordChar = '\0';
			this.textBoxLogin.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxLogin.PlaceholderText = "";
			this.textBoxLogin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxLogin.SelectedText = "";
			this.textBoxLogin.Size = new System.Drawing.Size(250, 40);
			this.textBoxLogin.TabIndex = 2;
			this.textBoxLogin.TextOffset = new System.Drawing.Point(3, 0);
			this.textBoxLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxLogin_KeyDown);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Animated = true;
			this.textBoxPassword.AutoScroll = true;
			this.textBoxPassword.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPassword.BorderRadius = 10;
			this.textBoxPassword.BorderThickness = 2;
			this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPassword.DefaultText = "";
			this.textBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPassword.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
			this.textBoxPassword.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPassword.Location = new System.Drawing.Point(145, 124);
			this.textBoxPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPassword.MaxLength = 16;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPassword.PlaceholderText = "";
			this.textBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPassword.SelectedText = "";
			this.textBoxPassword.Size = new System.Drawing.Size(250, 40);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.TextOffset = new System.Drawing.Point(3, 0);
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPassword_KeyDown);
			// 
			// textBoxPassword2
			// 
			this.textBoxPassword2.Animated = true;
			this.textBoxPassword2.AutoScroll = true;
			this.textBoxPassword2.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPassword2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPassword2.BorderRadius = 10;
			this.textBoxPassword2.BorderThickness = 2;
			this.textBoxPassword2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPassword2.DefaultText = "";
			this.textBoxPassword2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPassword2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPassword2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPassword2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPassword2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPassword2.ForeColor = System.Drawing.Color.Black;
			this.textBoxPassword2.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPassword2.Location = new System.Drawing.Point(255, 204);
			this.textBoxPassword2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPassword2.MaxLength = 16;
			this.textBoxPassword2.Name = "textBoxPassword2";
			this.textBoxPassword2.PasswordChar = '*';
			this.textBoxPassword2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPassword2.PlaceholderText = "";
			this.textBoxPassword2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPassword2.SelectedText = "";
			this.textBoxPassword2.Size = new System.Drawing.Size(250, 40);
			this.textBoxPassword2.TabIndex = 7;
			this.textBoxPassword2.TextOffset = new System.Drawing.Point(3, 0);
			this.textBoxPassword2.Visible = false;
			this.textBoxPassword2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPassword2_KeyDown);
			// 
			// labelRememberMe
			// 
			this.labelRememberMe.AutoSize = true;
			this.labelRememberMe.BackColor = System.Drawing.Color.Transparent;
			this.labelRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelRememberMe.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRememberMe.ForeColor = System.Drawing.Color.Black;
			this.labelRememberMe.Location = new System.Drawing.Point(12, 210);
			this.labelRememberMe.Name = "labelRememberMe";
			this.labelRememberMe.Size = new System.Drawing.Size(320, 23);
			this.labelRememberMe.TabIndex = 8;
			this.labelRememberMe.Text = "Запам’ятати мене на цьому ПК:";
			this.labelRememberMe.Click += new System.EventHandler(this.LabelRememberMe_Click);
			// 
			// checkBoxRememberMe
			// 
			this.checkBoxRememberMe.Animated = true;
			this.checkBoxRememberMe.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxRememberMe.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.checkBoxRememberMe.CheckedState.BorderRadius = 2;
			this.checkBoxRememberMe.CheckedState.BorderThickness = 1;
			this.checkBoxRememberMe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.checkBoxRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxRememberMe.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxRememberMe.ForeColor = System.Drawing.Color.Transparent;
			this.checkBoxRememberMe.Location = new System.Drawing.Point(338, 213);
			this.checkBoxRememberMe.Name = "checkBoxRememberMe";
			this.checkBoxRememberMe.ShadowDecoration.BorderRadius = 2;
			this.checkBoxRememberMe.ShadowDecoration.Depth = 150;
			this.checkBoxRememberMe.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
			this.checkBoxRememberMe.Size = new System.Drawing.Size(17, 17);
			this.checkBoxRememberMe.TabIndex = 9;
			this.checkBoxRememberMe.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.checkBoxRememberMe.UncheckedState.BorderRadius = 2;
			this.checkBoxRememberMe.UncheckedState.BorderThickness = 1;
			this.checkBoxRememberMe.UncheckedState.FillColor = System.Drawing.Color.Silver;
			this.checkBoxRememberMe.UseTransparentBackground = true;
			this.checkBoxRememberMe.CheckedChanged += new System.EventHandler(this.CheckBoxRememberMe_CheckedChanged);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			this.ClientSize = new System.Drawing.Size(584, 356);
			this.Controls.Add(this.checkBoxRememberMe);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.pictureBoxTheme);
			this.Controls.Add(this.pictureBoxShowPwd);
			this.Controls.Add(this.labelRegisterStart);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelLogin);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.buttonRegisterContinue);
			this.Controls.Add(this.labelRememberMe);
			this.Controls.Add(this.labelPassword2);
			this.Controls.Add(this.textBoxPassword2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StartForm";
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
        private System.Windows.Forms.Label labelPassword2;
        private System.Windows.Forms.Label labelRegisterStart;
        private System.Windows.Forms.PictureBox pictureBoxShowPwd;
        private System.Windows.Forms.PictureBox pictureBoxTheme;
		private Guna.UI2.WinForms.Guna2GradientButton buttonBack;
		private Guna.UI2.WinForms.Guna2GradientButton buttonLogin;
		private Guna.UI2.WinForms.Guna2GradientButton buttonRegisterContinue;
		private Guna.UI2.WinForms.Guna2TextBox textBoxLogin;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPassword;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPassword2;
		private System.Windows.Forms.Label labelRememberMe;
		private Guna.UI2.WinForms.Guna2CustomCheckBox checkBoxRememberMe;
	}
}