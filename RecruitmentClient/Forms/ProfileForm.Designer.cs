namespace RecruitmentClient.Forms
{
    partial class ProfileForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
			this.labelSurname = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.labelFatherName = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelPhoneStart = new System.Windows.Forms.Label();
			this.labelBirthday = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.buttonQuestionnairе = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonApply = new Guna.UI2.WinForms.Guna2GradientButton();
			this.textBoxSurname = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxName = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxFatherName = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxPhone1 = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxPhone2 = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxPhone3 = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxEmail = new Guna.UI2.WinForms.Guna2TextBox();
			this.dateTimePickerBirthday = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.SuspendLayout();
			// 
			// labelSurname
			// 
			this.labelSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSurname.AutoSize = true;
			this.labelSurname.BackColor = System.Drawing.Color.Transparent;
			this.labelSurname.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelSurname.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSurname.ForeColor = System.Drawing.Color.Black;
			this.labelSurname.Location = new System.Drawing.Point(126, 25);
			this.labelSurname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSurname.Name = "labelSurname";
			this.labelSurname.Size = new System.Drawing.Size(157, 32);
			this.labelSurname.TabIndex = 0;
			this.labelSurname.Text = "Прізвище:";
			this.labelSurname.Click += new System.EventHandler(this.LabelSurname_Click);
			// 
			// labelName
			// 
			this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelName.AutoSize = true;
			this.labelName.BackColor = System.Drawing.Color.Transparent;
			this.labelName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelName.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.ForeColor = System.Drawing.Color.Black;
			this.labelName.Location = new System.Drawing.Point(204, 85);
			this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(79, 32);
			this.labelName.TabIndex = 2;
			this.labelName.Text = "І’мя:";
			this.labelName.Click += new System.EventHandler(this.LabelName_Click);
			// 
			// labelFatherName
			// 
			this.labelFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFatherName.AutoSize = true;
			this.labelFatherName.BackColor = System.Drawing.Color.Transparent;
			this.labelFatherName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelFatherName.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFatherName.ForeColor = System.Drawing.Color.Black;
			this.labelFatherName.Location = new System.Drawing.Point(93, 145);
			this.labelFatherName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFatherName.Name = "labelFatherName";
			this.labelFatherName.Size = new System.Drawing.Size(190, 32);
			this.labelFatherName.TabIndex = 4;
			this.labelFatherName.Text = "По-батькові:";
			this.labelFatherName.Click += new System.EventHandler(this.LabelFatherName_Click);
			// 
			// labelPhone
			// 
			this.labelPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPhone.AutoSize = true;
			this.labelPhone.BackColor = System.Drawing.Color.Transparent;
			this.labelPhone.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelPhone.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPhone.ForeColor = System.Drawing.Color.Black;
			this.labelPhone.Location = new System.Drawing.Point(25, 205);
			this.labelPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(258, 32);
			this.labelPhone.TabIndex = 6;
			this.labelPhone.Text = "Номер телефону:";
			this.labelPhone.Click += new System.EventHandler(this.LabelPhone_Click);
			// 
			// labelPhoneStart
			// 
			this.labelPhoneStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPhoneStart.AutoSize = true;
			this.labelPhoneStart.BackColor = System.Drawing.Color.Transparent;
			this.labelPhoneStart.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPhoneStart.ForeColor = System.Drawing.Color.Black;
			this.labelPhoneStart.Location = new System.Drawing.Point(283, 207);
			this.labelPhoneStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPhoneStart.Name = "labelPhoneStart";
			this.labelPhoneStart.Size = new System.Drawing.Size(64, 28);
			this.labelPhoneStart.TabIndex = 7;
			this.labelPhoneStart.Text = "+380";
			// 
			// labelBirthday
			// 
			this.labelBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBirthday.AutoSize = true;
			this.labelBirthday.BackColor = System.Drawing.Color.Transparent;
			this.labelBirthday.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelBirthday.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBirthday.ForeColor = System.Drawing.Color.Black;
			this.labelBirthday.Location = new System.Drawing.Point(11, 265);
			this.labelBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelBirthday.Name = "labelBirthday";
			this.labelBirthday.Size = new System.Drawing.Size(272, 32);
			this.labelBirthday.TabIndex = 11;
			this.labelBirthday.Text = "Дата народження:";
			this.labelBirthday.Click += new System.EventHandler(this.LabelBirthday_Click);
			// 
			// labelEmail
			// 
			this.labelEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEmail.AutoSize = true;
			this.labelEmail.BackColor = System.Drawing.Color.Transparent;
			this.labelEmail.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelEmail.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEmail.ForeColor = System.Drawing.Color.Black;
			this.labelEmail.Location = new System.Drawing.Point(172, 327);
			this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(111, 32);
			this.labelEmail.TabIndex = 13;
			this.labelEmail.Text = "E-mail:";
			this.labelEmail.Click += new System.EventHandler(this.LabelEmail_Click);
			// 
			// buttonQuestionnairе
			// 
			this.buttonQuestionnairе.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonQuestionnairе.Animated = true;
			this.buttonQuestionnairе.BackColor = System.Drawing.Color.Transparent;
			this.buttonQuestionnairе.BorderRadius = 7;
			this.buttonQuestionnairе.BorderThickness = 1;
			this.buttonQuestionnairе.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonQuestionnairе.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonQuestionnairе.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonQuestionnairе.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonQuestionnairе.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonQuestionnairе.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonQuestionnairе.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonQuestionnairе.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonQuestionnairе.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonQuestionnairе.ForeColor = System.Drawing.Color.Black;
			this.buttonQuestionnairе.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonQuestionnairе.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonQuestionnairе.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonQuestionnairе.Location = new System.Drawing.Point(12, 416);
			this.buttonQuestionnairе.Name = "buttonQuestionnairе";
			this.buttonQuestionnairе.PressedColor = System.Drawing.Color.White;
			this.buttonQuestionnairе.PressedDepth = 20;
			this.buttonQuestionnairе.Size = new System.Drawing.Size(175, 40);
			this.buttonQuestionnairе.TabIndex = 15;
			this.buttonQuestionnairе.TabStop = false;
			this.buttonQuestionnairе.Text = "Анкета";
			this.buttonQuestionnairе.Click += new System.EventHandler(this.ButtonQuestionnaire_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Animated = true;
			this.buttonApply.BackColor = System.Drawing.Color.Transparent;
			this.buttonApply.BorderRadius = 7;
			this.buttonApply.BorderThickness = 1;
			this.buttonApply.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApply.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonApply.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonApply.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonApply.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonApply.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonApply.ForeColor = System.Drawing.Color.Black;
			this.buttonApply.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonApply.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonApply.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonApply.Location = new System.Drawing.Point(616, 416);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.PressedColor = System.Drawing.Color.White;
			this.buttonApply.PressedDepth = 20;
			this.buttonApply.Size = new System.Drawing.Size(175, 40);
			this.buttonApply.TabIndex = 16;
			this.buttonApply.TabStop = false;
			this.buttonApply.Text = "Застосувати";
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// textBoxSurname
			// 
			this.textBoxSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSurname.Animated = true;
			this.textBoxSurname.AutoScroll = true;
			this.textBoxSurname.BackColor = System.Drawing.Color.Transparent;
			this.textBoxSurname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxSurname.BorderRadius = 10;
			this.textBoxSurname.BorderThickness = 2;
			this.textBoxSurname.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxSurname.DefaultText = "";
			this.textBoxSurname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxSurname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxSurname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxSurname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxSurname.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSurname.ForeColor = System.Drawing.Color.Black;
			this.textBoxSurname.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxSurname.Location = new System.Drawing.Point(288, 23);
			this.textBoxSurname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxSurname.MaxLength = 64;
			this.textBoxSurname.Name = "textBoxSurname";
			this.textBoxSurname.PasswordChar = '\0';
			this.textBoxSurname.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxSurname.PlaceholderText = "";
			this.textBoxSurname.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxSurname.SelectedText = "";
			this.textBoxSurname.Size = new System.Drawing.Size(235, 36);
			this.textBoxSurname.TabIndex = 1;
			this.textBoxSurname.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Animated = true;
			this.textBoxName.AutoScroll = true;
			this.textBoxName.BackColor = System.Drawing.Color.Transparent;
			this.textBoxName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxName.BorderRadius = 10;
			this.textBoxName.BorderThickness = 2;
			this.textBoxName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxName.DefaultText = "";
			this.textBoxName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxName.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxName.ForeColor = System.Drawing.Color.Black;
			this.textBoxName.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxName.Location = new System.Drawing.Point(288, 83);
			this.textBoxName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxName.MaxLength = 64;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.PasswordChar = '\0';
			this.textBoxName.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxName.PlaceholderText = "";
			this.textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxName.SelectedText = "";
			this.textBoxName.Size = new System.Drawing.Size(235, 36);
			this.textBoxName.TabIndex = 3;
			this.textBoxName.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// textBoxFatherName
			// 
			this.textBoxFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFatherName.Animated = true;
			this.textBoxFatherName.AutoScroll = true;
			this.textBoxFatherName.BackColor = System.Drawing.Color.Transparent;
			this.textBoxFatherName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxFatherName.BorderRadius = 10;
			this.textBoxFatherName.BorderThickness = 2;
			this.textBoxFatherName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxFatherName.DefaultText = "";
			this.textBoxFatherName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxFatherName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxFatherName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxFatherName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxFatherName.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxFatherName.ForeColor = System.Drawing.Color.Black;
			this.textBoxFatherName.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxFatherName.Location = new System.Drawing.Point(288, 143);
			this.textBoxFatherName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxFatherName.MaxLength = 64;
			this.textBoxFatherName.Name = "textBoxFatherName";
			this.textBoxFatherName.PasswordChar = '\0';
			this.textBoxFatherName.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxFatherName.PlaceholderText = "";
			this.textBoxFatherName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxFatherName.SelectedText = "";
			this.textBoxFatherName.Size = new System.Drawing.Size(235, 36);
			this.textBoxFatherName.TabIndex = 5;
			this.textBoxFatherName.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// textBoxPhone1
			// 
			this.textBoxPhone1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPhone1.Animated = true;
			this.textBoxPhone1.AutoScroll = true;
			this.textBoxPhone1.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPhone1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPhone1.BorderRadius = 8;
			this.textBoxPhone1.BorderThickness = 2;
			this.textBoxPhone1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPhone1.DefaultText = "";
			this.textBoxPhone1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPhone1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPhone1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPhone1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPhone1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPhone1.ForeColor = System.Drawing.Color.Black;
			this.textBoxPhone1.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPhone1.Location = new System.Drawing.Point(352, 203);
			this.textBoxPhone1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPhone1.MaxLength = 3;
			this.textBoxPhone1.Name = "textBoxPhone1";
			this.textBoxPhone1.PasswordChar = '\0';
			this.textBoxPhone1.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPhone1.PlaceholderText = "";
			this.textBoxPhone1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPhone1.SelectedText = "";
			this.textBoxPhone1.Size = new System.Drawing.Size(58, 36);
			this.textBoxPhone1.TabIndex = 8;
			this.textBoxPhone1.TextChanged += new System.EventHandler(this.TextBoxPhone_TextChanged);
			this.textBoxPhone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPhone_KeyPress);
			// 
			// textBoxPhone2
			// 
			this.textBoxPhone2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPhone2.Animated = true;
			this.textBoxPhone2.AutoScroll = true;
			this.textBoxPhone2.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPhone2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPhone2.BorderRadius = 8;
			this.textBoxPhone2.BorderThickness = 2;
			this.textBoxPhone2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPhone2.DefaultText = "";
			this.textBoxPhone2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPhone2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPhone2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPhone2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPhone2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPhone2.ForeColor = System.Drawing.Color.Black;
			this.textBoxPhone2.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPhone2.Location = new System.Drawing.Point(416, 203);
			this.textBoxPhone2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPhone2.MaxLength = 3;
			this.textBoxPhone2.Name = "textBoxPhone2";
			this.textBoxPhone2.PasswordChar = '\0';
			this.textBoxPhone2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPhone2.PlaceholderText = "";
			this.textBoxPhone2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPhone2.SelectedText = "";
			this.textBoxPhone2.Size = new System.Drawing.Size(58, 36);
			this.textBoxPhone2.TabIndex = 9;
			this.textBoxPhone2.TextChanged += new System.EventHandler(this.TextBoxPhone_TextChanged);
			this.textBoxPhone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPhone_KeyPress);
			// 
			// textBoxPhone3
			// 
			this.textBoxPhone3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPhone3.Animated = true;
			this.textBoxPhone3.AutoScroll = true;
			this.textBoxPhone3.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPhone3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPhone3.BorderRadius = 8;
			this.textBoxPhone3.BorderThickness = 2;
			this.textBoxPhone3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPhone3.DefaultText = "";
			this.textBoxPhone3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPhone3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPhone3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPhone3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPhone3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPhone3.ForeColor = System.Drawing.Color.Black;
			this.textBoxPhone3.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPhone3.Location = new System.Drawing.Point(480, 203);
			this.textBoxPhone3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPhone3.MaxLength = 3;
			this.textBoxPhone3.Name = "textBoxPhone3";
			this.textBoxPhone3.PasswordChar = '\0';
			this.textBoxPhone3.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPhone3.PlaceholderText = "";
			this.textBoxPhone3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPhone3.SelectedText = "";
			this.textBoxPhone3.Size = new System.Drawing.Size(58, 36);
			this.textBoxPhone3.TabIndex = 10;
			this.textBoxPhone3.TextChanged += new System.EventHandler(this.TextBoxPhone_TextChanged);
			this.textBoxPhone3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPhone_KeyPress);
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxEmail.Animated = true;
			this.textBoxEmail.AutoScroll = true;
			this.textBoxEmail.BackColor = System.Drawing.Color.Transparent;
			this.textBoxEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxEmail.BorderRadius = 10;
			this.textBoxEmail.BorderThickness = 2;
			this.textBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxEmail.DefaultText = "";
			this.textBoxEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxEmail.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxEmail.ForeColor = System.Drawing.Color.Black;
			this.textBoxEmail.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxEmail.Location = new System.Drawing.Point(288, 326);
			this.textBoxEmail.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxEmail.MaxLength = 64;
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.PasswordChar = '\0';
			this.textBoxEmail.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxEmail.PlaceholderText = "";
			this.textBoxEmail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxEmail.SelectedText = "";
			this.textBoxEmail.Size = new System.Drawing.Size(350, 34);
			this.textBoxEmail.TabIndex = 14;
			this.textBoxEmail.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// dateTimePickerBirthday
			// 
			this.dateTimePickerBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePickerBirthday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.dateTimePickerBirthday.BorderRadius = 10;
			this.dateTimePickerBirthday.BorderThickness = 2;
			this.dateTimePickerBirthday.Checked = true;
			this.dateTimePickerBirthday.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dateTimePickerBirthday.FillColor = System.Drawing.Color.White;
			this.dateTimePickerBirthday.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerBirthday.ForeColor = System.Drawing.Color.Black;
			this.dateTimePickerBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Long;
			this.dateTimePickerBirthday.Location = new System.Drawing.Point(288, 263);
			this.dateTimePickerBirthday.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dateTimePickerBirthday.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
			this.dateTimePickerBirthday.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dateTimePickerBirthday.Size = new System.Drawing.Size(300, 36);
			this.dateTimePickerBirthday.TabIndex = 12;
			this.dateTimePickerBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.dateTimePickerBirthday.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			// 
			// ProfileForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(803, 478);
			this.Controls.Add(this.dateTimePickerBirthday);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.textBoxPhone3);
			this.Controls.Add(this.textBoxPhone2);
			this.Controls.Add(this.textBoxPhone1);
			this.Controls.Add(this.textBoxFatherName);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.textBoxSurname);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.buttonQuestionnairе);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelBirthday);
			this.Controls.Add(this.labelPhoneStart);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelFatherName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelSurname);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "ProfileForm";
			this.Text = "Профіль";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProfileForm_FormClosed);
			this.Load += new System.EventHandler(this.ProfileForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelFatherName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelPhoneStart;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelEmail;
		private Guna.UI2.WinForms.Guna2GradientButton buttonQuestionnairе;
		private Guna.UI2.WinForms.Guna2GradientButton buttonApply;
		private Guna.UI2.WinForms.Guna2TextBox textBoxSurname;
		private Guna.UI2.WinForms.Guna2TextBox textBoxName;
		private Guna.UI2.WinForms.Guna2TextBox textBoxFatherName;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPhone1;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPhone2;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPhone3;
		private Guna.UI2.WinForms.Guna2TextBox textBoxEmail;
		private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerBirthday;
	}
}