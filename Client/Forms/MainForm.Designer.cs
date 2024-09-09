namespace RecruitmentUser.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.buttonProfile = new System.Windows.Forms.Button();
			this.panelUp = new System.Windows.Forms.Panel();
			this.pictureBoxLine = new System.Windows.Forms.PictureBox();
			this.pictureBoxTheme = new System.Windows.Forms.PictureBox();
			this.pictureBoxPasswordChange = new System.Windows.Forms.PictureBox();
			this.pictureBoxExit = new System.Windows.Forms.PictureBox();
			this.flp_Menu = new System.Windows.Forms.FlowLayoutPanel();
			this.labelVacancy = new System.Windows.Forms.Label();
			this.labelApplication = new System.Windows.Forms.Label();
			this.labelInterview = new System.Windows.Forms.Label();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelVacancy = new System.Windows.Forms.Panel();
			this.buttonVacancy = new System.Windows.Forms.Button();
			this.labelDatePublicationV = new System.Windows.Forms.Label();
			this.labelSalaryV = new System.Windows.Forms.Label();
			this.labelPositionDescriptionV = new System.Windows.Forms.Label();
			this.labelPositionV = new System.Windows.Forms.Label();
			this.panelApplication = new System.Windows.Forms.Panel();
			this.pictureBoxApplication = new System.Windows.Forms.PictureBox();
			this.buttonReasonRejectionA = new System.Windows.Forms.Button();
			this.labelStatusA = new System.Windows.Forms.Label();
			this.labelDateSubmissionA = new System.Windows.Forms.Label();
			this.labelPositionA = new System.Windows.Forms.Label();
			this.panelInterview = new System.Windows.Forms.Panel();
			this.pictureBoxInterview = new System.Windows.Forms.PictureBox();
			this.labelStatusI = new System.Windows.Forms.Label();
			this.labelDateEventI = new System.Windows.Forms.Label();
			this.labelPositionI = new System.Windows.Forms.Label();
			this.labelEmpty = new System.Windows.Forms.Label();
			this.textBoxPositionSearch = new System.Windows.Forms.TextBox();
			this.comboBoxDate = new System.Windows.Forms.ComboBox();
			this.panelSalarySearch = new System.Windows.Forms.Panel();
			this.textBoxMaxSalarySearch = new System.Windows.Forms.TextBox();
			this.labelSalarySearch2 = new System.Windows.Forms.Label();
			this.labelSalarySearch = new System.Windows.Forms.Label();
			this.textBoxMinSalarySearch = new System.Windows.Forms.TextBox();
			this.comboBoxSort = new System.Windows.Forms.ComboBox();
			this.panelSearch = new System.Windows.Forms.Panel();
			this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
			this.pictureBoxUp = new System.Windows.Forms.PictureBox();
			this.pictureBoxDown = new System.Windows.Forms.PictureBox();
			this.pictureBoxRefresh = new System.Windows.Forms.PictureBox();
			this.panelUp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasswordChange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
			this.flp_Menu.SuspendLayout();
			this.flpMain.SuspendLayout();
			this.panelVacancy.SuspendLayout();
			this.panelApplication.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxApplication)).BeginInit();
			this.panelInterview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInterview)).BeginInit();
			this.panelSalarySearch.SuspendLayout();
			this.panelSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonProfile
			// 
			this.buttonProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonProfile.AutoEllipsis = true;
			this.buttonProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonProfile.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonProfile.Location = new System.Drawing.Point(1165, 7);
			this.buttonProfile.Name = "buttonProfile";
			this.buttonProfile.Size = new System.Drawing.Size(200, 36);
			this.buttonProfile.TabIndex = 0;
			this.buttonProfile.TabStop = false;
			this.buttonProfile.Text = "Профіль";
			this.buttonProfile.UseVisualStyleBackColor = false;
			this.buttonProfile.Click += new System.EventHandler(this.ButtonProfile_Click);
			// 
			// panelUp
			// 
			this.panelUp.BackColor = System.Drawing.Color.Transparent;
			this.panelUp.Controls.Add(this.pictureBoxLine);
			this.panelUp.Controls.Add(this.pictureBoxTheme);
			this.panelUp.Controls.Add(this.pictureBoxPasswordChange);
			this.panelUp.Controls.Add(this.pictureBoxExit);
			this.panelUp.Controls.Add(this.buttonProfile);
			this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelUp.Location = new System.Drawing.Point(0, 0);
			this.panelUp.Name = "panelUp";
			this.panelUp.Size = new System.Drawing.Size(1377, 70);
			this.panelUp.TabIndex = 3;
			// 
			// pictureBoxLine
			// 
			this.pictureBoxLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxLine.BackColor = System.Drawing.Color.Black;
			this.pictureBoxLine.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBoxLine.Location = new System.Drawing.Point(974, 60);
			this.pictureBoxLine.Name = "pictureBoxLine";
			this.pictureBoxLine.Size = new System.Drawing.Size(400, 2);
			this.pictureBoxLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxLine.TabIndex = 47;
			this.pictureBoxLine.TabStop = false;
			// 
			// pictureBoxTheme
			// 
			this.pictureBoxTheme.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxTheme.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxTheme.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTheme.Image")));
			this.pictureBoxTheme.Location = new System.Drawing.Point(12, 10);
			this.pictureBoxTheme.Name = "pictureBoxTheme";
			this.pictureBoxTheme.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxTheme.TabIndex = 46;
			this.pictureBoxTheme.TabStop = false;
			this.pictureBoxTheme.Click += new System.EventHandler(this.PictureBoxTheme_Click);
			// 
			// pictureBoxPasswordChange
			// 
			this.pictureBoxPasswordChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxPasswordChange.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxPasswordChange.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxPasswordChange.Image = global::RecruitmentUser.Properties.Resources.keyB;
			this.pictureBoxPasswordChange.Location = new System.Drawing.Point(1115, 10);
			this.pictureBoxPasswordChange.Name = "pictureBoxPasswordChange";
			this.pictureBoxPasswordChange.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxPasswordChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPasswordChange.TabIndex = 45;
			this.pictureBoxPasswordChange.TabStop = false;
			this.pictureBoxPasswordChange.Click += new System.EventHandler(this.ButtonPasswordChange_Click);
			// 
			// pictureBoxExit
			// 
			this.pictureBoxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxExit.Image = global::RecruitmentUser.Properties.Resources.exit;
			this.pictureBoxExit.Location = new System.Drawing.Point(1070, 10);
			this.pictureBoxExit.Name = "pictureBoxExit";
			this.pictureBoxExit.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxExit.TabIndex = 44;
			this.pictureBoxExit.TabStop = false;
			this.pictureBoxExit.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// flp_Menu
			// 
			this.flp_Menu.BackColor = System.Drawing.Color.Transparent;
			this.flp_Menu.Controls.Add(this.labelVacancy);
			this.flp_Menu.Controls.Add(this.labelApplication);
			this.flp_Menu.Controls.Add(this.labelInterview);
			this.flp_Menu.Dock = System.Windows.Forms.DockStyle.Left;
			this.flp_Menu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flp_Menu.ForeColor = System.Drawing.Color.Black;
			this.flp_Menu.Location = new System.Drawing.Point(0, 70);
			this.flp_Menu.Name = "flp_Menu";
			this.flp_Menu.Padding = new System.Windows.Forms.Padding(10, 15, 15, 15);
			this.flp_Menu.Size = new System.Drawing.Size(210, 641);
			this.flp_Menu.TabIndex = 4;
			// 
			// labelVacancy
			// 
			this.labelVacancy.AutoSize = true;
			this.labelVacancy.BackColor = System.Drawing.Color.Transparent;
			this.labelVacancy.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVacancy.ForeColor = System.Drawing.Color.Black;
			this.labelVacancy.Location = new System.Drawing.Point(12, 15);
			this.labelVacancy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 15);
			this.labelVacancy.Name = "labelVacancy";
			this.labelVacancy.Size = new System.Drawing.Size(126, 32);
			this.labelVacancy.TabIndex = 1;
			this.labelVacancy.Text = "Вакансії";
			this.labelVacancy.Click += new System.EventHandler(this.LabelVAI_Click);
			// 
			// labelApplication
			// 
			this.labelApplication.AutoSize = true;
			this.labelApplication.BackColor = System.Drawing.Color.Transparent;
			this.labelApplication.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelApplication.ForeColor = System.Drawing.Color.Black;
			this.labelApplication.Location = new System.Drawing.Point(12, 62);
			this.labelApplication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 15);
			this.labelApplication.Name = "labelApplication";
			this.labelApplication.Size = new System.Drawing.Size(112, 32);
			this.labelApplication.TabIndex = 2;
			this.labelApplication.Text = "Заявки";
			this.labelApplication.Click += new System.EventHandler(this.LabelVAI_Click);
			// 
			// labelInterview
			// 
			this.labelInterview.AutoSize = true;
			this.labelInterview.BackColor = System.Drawing.Color.Transparent;
			this.labelInterview.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelInterview.ForeColor = System.Drawing.Color.Black;
			this.labelInterview.Location = new System.Drawing.Point(12, 109);
			this.labelInterview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 15);
			this.labelInterview.Name = "labelInterview";
			this.labelInterview.Size = new System.Drawing.Size(161, 32);
			this.labelInterview.TabIndex = 3;
			this.labelInterview.Text = "Співбесіди";
			this.labelInterview.Click += new System.EventHandler(this.LabelVAI_Click);
			// 
			// flpMain
			// 
			this.flpMain.AutoScroll = true;
			this.flpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
			this.flpMain.Controls.Add(this.panelVacancy);
			this.flpMain.Controls.Add(this.panelApplication);
			this.flpMain.Controls.Add(this.panelInterview);
			this.flpMain.Controls.Add(this.labelEmpty);
			this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpMain.Location = new System.Drawing.Point(210, 180);
			this.flpMain.Margin = new System.Windows.Forms.Padding(0);
			this.flpMain.Name = "flpMain";
			this.flpMain.Size = new System.Drawing.Size(1167, 531);
			this.flpMain.TabIndex = 6;
			this.flpMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PanelMain_Scroll);
			this.flpMain.Resize += new System.EventHandler(this.FlpMain_Resize);
			// 
			// panelVacancy
			// 
			this.panelVacancy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelVacancy.BackColor = System.Drawing.Color.White;
			this.panelVacancy.Controls.Add(this.buttonVacancy);
			this.panelVacancy.Controls.Add(this.labelDatePublicationV);
			this.panelVacancy.Controls.Add(this.labelSalaryV);
			this.panelVacancy.Controls.Add(this.labelPositionDescriptionV);
			this.panelVacancy.Controls.Add(this.labelPositionV);
			this.panelVacancy.Location = new System.Drawing.Point(0, 3);
			this.panelVacancy.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panelVacancy.Name = "panelVacancy";
			this.panelVacancy.Size = new System.Drawing.Size(1134, 168);
			this.panelVacancy.TabIndex = 12;
			this.panelVacancy.Visible = false;
			// 
			// buttonVacancy
			// 
			this.buttonVacancy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonVacancy.AutoSize = true;
			this.buttonVacancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonVacancy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonVacancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonVacancy.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonVacancy.Location = new System.Drawing.Point(12, 124);
			this.buttonVacancy.Name = "buttonVacancy";
			this.buttonVacancy.Size = new System.Drawing.Size(150, 35);
			this.buttonVacancy.TabIndex = 4;
			this.buttonVacancy.Text = "Перейти";
			this.buttonVacancy.UseVisualStyleBackColor = false;
			// 
			// labelDatePublicationV
			// 
			this.labelDatePublicationV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatePublicationV.BackColor = System.Drawing.Color.Transparent;
			this.labelDatePublicationV.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDatePublicationV.ForeColor = System.Drawing.Color.Black;
			this.labelDatePublicationV.Location = new System.Drawing.Point(610, 140);
			this.labelDatePublicationV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDatePublicationV.Name = "labelDatePublicationV";
			this.labelDatePublicationV.Size = new System.Drawing.Size(522, 25);
			this.labelDatePublicationV.TabIndex = 5;
			this.labelDatePublicationV.Text = "Опубліковано";
			this.labelDatePublicationV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelSalaryV
			// 
			this.labelSalaryV.AutoSize = true;
			this.labelSalaryV.BackColor = System.Drawing.Color.Transparent;
			this.labelSalaryV.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSalaryV.ForeColor = System.Drawing.Color.Black;
			this.labelSalaryV.Location = new System.Drawing.Point(5, 63);
			this.labelSalaryV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalaryV.Name = "labelSalaryV";
			this.labelSalaryV.Size = new System.Drawing.Size(143, 32);
			this.labelSalaryV.TabIndex = 3;
			this.labelSalaryV.Text = "Зарплата";
			// 
			// labelPositionDescriptionV
			// 
			this.labelPositionDescriptionV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPositionDescriptionV.AutoEllipsis = true;
			this.labelPositionDescriptionV.BackColor = System.Drawing.Color.Transparent;
			this.labelPositionDescriptionV.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPositionDescriptionV.ForeColor = System.Drawing.Color.Black;
			this.labelPositionDescriptionV.Location = new System.Drawing.Point(477, 3);
			this.labelPositionDescriptionV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPositionDescriptionV.Name = "labelPositionDescriptionV";
			this.labelPositionDescriptionV.Size = new System.Drawing.Size(655, 57);
			this.labelPositionDescriptionV.TabIndex = 2;
			this.labelPositionDescriptionV.Text = resources.GetString("labelPositionDescriptionV.Text");
			// 
			// labelPositionV
			// 
			this.labelPositionV.AutoEllipsis = true;
			this.labelPositionV.BackColor = System.Drawing.Color.Transparent;
			this.labelPositionV.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPositionV.ForeColor = System.Drawing.Color.Black;
			this.labelPositionV.Location = new System.Drawing.Point(5, 3);
			this.labelPositionV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPositionV.Name = "labelPositionV";
			this.labelPositionV.Size = new System.Drawing.Size(440, 32);
			this.labelPositionV.TabIndex = 1;
			this.labelPositionV.Text = "Посада";
			// 
			// panelApplication
			// 
			this.panelApplication.BackColor = System.Drawing.Color.White;
			this.panelApplication.Controls.Add(this.pictureBoxApplication);
			this.panelApplication.Controls.Add(this.buttonReasonRejectionA);
			this.panelApplication.Controls.Add(this.labelStatusA);
			this.panelApplication.Controls.Add(this.labelDateSubmissionA);
			this.panelApplication.Controls.Add(this.labelPositionA);
			this.panelApplication.Location = new System.Drawing.Point(0, 177);
			this.panelApplication.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panelApplication.Name = "panelApplication";
			this.panelApplication.Size = new System.Drawing.Size(1134, 107);
			this.panelApplication.TabIndex = 13;
			this.panelApplication.Visible = false;
			// 
			// pictureBoxApplication
			// 
			this.pictureBoxApplication.BackColor = System.Drawing.Color.Black;
			this.pictureBoxApplication.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxApplication.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxApplication.Name = "pictureBoxApplication";
			this.pictureBoxApplication.Size = new System.Drawing.Size(5, 107);
			this.pictureBoxApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxApplication.TabIndex = 47;
			this.pictureBoxApplication.TabStop = false;
			// 
			// buttonReasonRejectionA
			// 
			this.buttonReasonRejectionA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(29)))), ((int)(((byte)(52)))));
			this.buttonReasonRejectionA.Cursor = System.Windows.Forms.Cursors.Help;
			this.buttonReasonRejectionA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonReasonRejectionA.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonReasonRejectionA.Location = new System.Drawing.Point(300, 60);
			this.buttonReasonRejectionA.Name = "buttonReasonRejectionA";
			this.buttonReasonRejectionA.Size = new System.Drawing.Size(230, 35);
			this.buttonReasonRejectionA.TabIndex = 3;
			this.buttonReasonRejectionA.Text = "Причина відмови";
			this.buttonReasonRejectionA.UseVisualStyleBackColor = false;
			// 
			// labelStatusA
			// 
			this.labelStatusA.AutoSize = true;
			this.labelStatusA.BackColor = System.Drawing.Color.Transparent;
			this.labelStatusA.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatusA.ForeColor = System.Drawing.Color.Black;
			this.labelStatusA.Location = new System.Drawing.Point(10, 63);
			this.labelStatusA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStatusA.Name = "labelStatusA";
			this.labelStatusA.Size = new System.Drawing.Size(105, 32);
			this.labelStatusA.TabIndex = 2;
			this.labelStatusA.Text = "Статус";
			// 
			// labelDateSubmissionA
			// 
			this.labelDateSubmissionA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDateSubmissionA.BackColor = System.Drawing.Color.Transparent;
			this.labelDateSubmissionA.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateSubmissionA.ForeColor = System.Drawing.Color.Black;
			this.labelDateSubmissionA.Location = new System.Drawing.Point(610, 80);
			this.labelDateSubmissionA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDateSubmissionA.Name = "labelDateSubmissionA";
			this.labelDateSubmissionA.Size = new System.Drawing.Size(522, 25);
			this.labelDateSubmissionA.TabIndex = 4;
			this.labelDateSubmissionA.Text = "Дата і час подачі";
			this.labelDateSubmissionA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelPositionA
			// 
			this.labelPositionA.AutoEllipsis = true;
			this.labelPositionA.BackColor = System.Drawing.Color.Transparent;
			this.labelPositionA.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPositionA.ForeColor = System.Drawing.Color.Black;
			this.labelPositionA.Location = new System.Drawing.Point(10, 3);
			this.labelPositionA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPositionA.Name = "labelPositionA";
			this.labelPositionA.Size = new System.Drawing.Size(370, 32);
			this.labelPositionA.TabIndex = 1;
			this.labelPositionA.Text = "Посада";
			// 
			// panelInterview
			// 
			this.panelInterview.BackColor = System.Drawing.Color.White;
			this.panelInterview.Controls.Add(this.pictureBoxInterview);
			this.panelInterview.Controls.Add(this.labelStatusI);
			this.panelInterview.Controls.Add(this.labelDateEventI);
			this.panelInterview.Controls.Add(this.labelPositionI);
			this.panelInterview.Location = new System.Drawing.Point(0, 290);
			this.panelInterview.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panelInterview.Name = "panelInterview";
			this.panelInterview.Size = new System.Drawing.Size(1134, 107);
			this.panelInterview.TabIndex = 14;
			this.panelInterview.Visible = false;
			// 
			// pictureBoxInterview
			// 
			this.pictureBoxInterview.BackColor = System.Drawing.Color.Black;
			this.pictureBoxInterview.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxInterview.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxInterview.Name = "pictureBoxInterview";
			this.pictureBoxInterview.Size = new System.Drawing.Size(5, 107);
			this.pictureBoxInterview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxInterview.TabIndex = 48;
			this.pictureBoxInterview.TabStop = false;
			// 
			// labelStatusI
			// 
			this.labelStatusI.AutoSize = true;
			this.labelStatusI.BackColor = System.Drawing.Color.Transparent;
			this.labelStatusI.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatusI.ForeColor = System.Drawing.Color.Black;
			this.labelStatusI.Location = new System.Drawing.Point(10, 63);
			this.labelStatusI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStatusI.Name = "labelStatusI";
			this.labelStatusI.Size = new System.Drawing.Size(105, 32);
			this.labelStatusI.TabIndex = 2;
			this.labelStatusI.Text = "Статус";
			// 
			// labelDateEventI
			// 
			this.labelDateEventI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDateEventI.BackColor = System.Drawing.Color.Transparent;
			this.labelDateEventI.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateEventI.ForeColor = System.Drawing.Color.Black;
			this.labelDateEventI.Location = new System.Drawing.Point(606, 80);
			this.labelDateEventI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDateEventI.Name = "labelDateEventI";
			this.labelDateEventI.Size = new System.Drawing.Size(526, 25);
			this.labelDateEventI.TabIndex = 3;
			this.labelDateEventI.Text = "Дата і час проведення";
			this.labelDateEventI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelPositionI
			// 
			this.labelPositionI.AutoEllipsis = true;
			this.labelPositionI.BackColor = System.Drawing.Color.Transparent;
			this.labelPositionI.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPositionI.ForeColor = System.Drawing.Color.Black;
			this.labelPositionI.Location = new System.Drawing.Point(10, 3);
			this.labelPositionI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPositionI.Name = "labelPositionI";
			this.labelPositionI.Size = new System.Drawing.Size(370, 32);
			this.labelPositionI.TabIndex = 1;
			this.labelPositionI.Text = "Посада";
			// 
			// labelEmpty
			// 
			this.labelEmpty.AutoSize = true;
			this.labelEmpty.BackColor = System.Drawing.Color.Transparent;
			this.labelEmpty.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEmpty.ForeColor = System.Drawing.Color.Black;
			this.labelEmpty.Location = new System.Drawing.Point(2, 400);
			this.labelEmpty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelEmpty.Name = "labelEmpty";
			this.labelEmpty.Padding = new System.Windows.Forms.Padding(12);
			this.labelEmpty.Size = new System.Drawing.Size(361, 62);
			this.labelEmpty.TabIndex = 9;
			this.labelEmpty.Text = "Нічого не знайдено";
			this.labelEmpty.Visible = false;
			// 
			// textBoxPositionSearch
			// 
			this.textBoxPositionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPositionSearch.BackColor = System.Drawing.Color.White;
			this.textBoxPositionSearch.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Italic);
			this.textBoxPositionSearch.Location = new System.Drawing.Point(844, 9);
			this.textBoxPositionSearch.MaxLength = 64;
			this.textBoxPositionSearch.Name = "textBoxPositionSearch";
			this.textBoxPositionSearch.Size = new System.Drawing.Size(275, 33);
			this.textBoxPositionSearch.TabIndex = 6;
			this.textBoxPositionSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPositionSearch_KeyDown);
			this.textBoxPositionSearch.Leave += new System.EventHandler(this.TextBoxPositionSearch_Leave);
			// 
			// comboBoxDate
			// 
			this.comboBoxDate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDate.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDate.ForeColor = System.Drawing.Color.Black;
			this.comboBoxDate.FormattingEnabled = true;
			this.comboBoxDate.Items.AddRange(new object[] {
            "За останні три дні",
            "За останній тиждень",
            "За останній місяць",
            "За останні три місяці",
            "За останній рік",
            "За весь час"});
			this.comboBoxDate.Location = new System.Drawing.Point(408, 9);
			this.comboBoxDate.Name = "comboBoxDate";
			this.comboBoxDate.Size = new System.Drawing.Size(253, 33);
			this.comboBoxDate.TabIndex = 5;
			this.comboBoxDate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDate_SelectedIndexChanged);
			// 
			// panelSalarySearch
			// 
			this.panelSalarySearch.Controls.Add(this.textBoxMaxSalarySearch);
			this.panelSalarySearch.Controls.Add(this.labelSalarySearch2);
			this.panelSalarySearch.Controls.Add(this.labelSalarySearch);
			this.panelSalarySearch.Controls.Add(this.textBoxMinSalarySearch);
			this.panelSalarySearch.Location = new System.Drawing.Point(202, 55);
			this.panelSalarySearch.Name = "panelSalarySearch";
			this.panelSalarySearch.Size = new System.Drawing.Size(375, 53);
			this.panelSalarySearch.TabIndex = 37;
			// 
			// textBoxMaxSalarySearch
			// 
			this.textBoxMaxSalarySearch.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Italic);
			this.textBoxMaxSalarySearch.Location = new System.Drawing.Point(275, 8);
			this.textBoxMaxSalarySearch.MaxLength = 6;
			this.textBoxMaxSalarySearch.Name = "textBoxMaxSalarySearch";
			this.textBoxMaxSalarySearch.Size = new System.Drawing.Size(90, 33);
			this.textBoxMaxSalarySearch.TabIndex = 10;
			this.textBoxMaxSalarySearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSalarySearch_KeyPress);
			this.textBoxMaxSalarySearch.Leave += new System.EventHandler(this.TextBoxMaxSalarySearch_Leave);
			// 
			// labelSalarySearch2
			// 
			this.labelSalarySearch2.AutoSize = true;
			this.labelSalarySearch2.Font = new System.Drawing.Font("Georgia", 20.25F);
			this.labelSalarySearch2.ForeColor = System.Drawing.Color.Black;
			this.labelSalarySearch2.Location = new System.Drawing.Point(233, 7);
			this.labelSalarySearch2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalarySearch2.Name = "labelSalarySearch2";
			this.labelSalarySearch2.Size = new System.Drawing.Size(37, 31);
			this.labelSalarySearch2.TabIndex = 9;
			this.labelSalarySearch2.Text = "\t—";
			// 
			// labelSalarySearch
			// 
			this.labelSalarySearch.AutoSize = true;
			this.labelSalarySearch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSalarySearch.ForeColor = System.Drawing.Color.Black;
			this.labelSalarySearch.Location = new System.Drawing.Point(-5, 9);
			this.labelSalarySearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalarySearch.Name = "labelSalarySearch";
			this.labelSalarySearch.Size = new System.Drawing.Size(138, 29);
			this.labelSalarySearch.TabIndex = 7;
			this.labelSalarySearch.Text = "Зарплата:";
			// 
			// textBoxMinSalarySearch
			// 
			this.textBoxMinSalarySearch.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Italic);
			this.textBoxMinSalarySearch.Location = new System.Drawing.Point(138, 8);
			this.textBoxMinSalarySearch.MaxLength = 6;
			this.textBoxMinSalarySearch.Name = "textBoxMinSalarySearch";
			this.textBoxMinSalarySearch.Size = new System.Drawing.Size(90, 33);
			this.textBoxMinSalarySearch.TabIndex = 8;
			this.textBoxMinSalarySearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSalarySearch_KeyPress);
			this.textBoxMinSalarySearch.Leave += new System.EventHandler(this.TextBoxMinSalarySearch_Leave);
			// 
			// comboBoxSort
			// 
			this.comboBoxSort.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSort.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSort.ForeColor = System.Drawing.Color.Black;
			this.comboBoxSort.FormattingEnabled = true;
			this.comboBoxSort.Items.AddRange(new object[] {
            "За датою",
            "За алфавітом",
            "За зарплатою"});
			this.comboBoxSort.Location = new System.Drawing.Point(202, 9);
			this.comboBoxSort.Name = "comboBoxSort";
			this.comboBoxSort.Size = new System.Drawing.Size(173, 33);
			this.comboBoxSort.TabIndex = 4;
			this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSort_SelectedIndexChanged);
			// 
			// panelSearch
			// 
			this.panelSearch.BackColor = System.Drawing.Color.Transparent;
			this.panelSearch.Controls.Add(this.pictureBoxSearch);
			this.panelSearch.Controls.Add(this.pictureBoxUp);
			this.panelSearch.Controls.Add(this.pictureBoxDown);
			this.panelSearch.Controls.Add(this.pictureBoxRefresh);
			this.panelSearch.Controls.Add(this.comboBoxSort);
			this.panelSearch.Controls.Add(this.panelSalarySearch);
			this.panelSearch.Controls.Add(this.comboBoxDate);
			this.panelSearch.Controls.Add(this.textBoxPositionSearch);
			this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSearch.Location = new System.Drawing.Point(210, 70);
			this.panelSearch.Name = "panelSearch";
			this.panelSearch.Size = new System.Drawing.Size(1167, 110);
			this.panelSearch.TabIndex = 5;
			this.panelSearch.Visible = false;
			// 
			// pictureBoxSearch
			// 
			this.pictureBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSearch.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxSearch.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBoxSearch.Image = global::RecruitmentUser.Properties.Resources.loupeB;
			this.pictureBoxSearch.Location = new System.Drawing.Point(1125, 10);
			this.pictureBoxSearch.Name = "pictureBoxSearch";
			this.pictureBoxSearch.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxSearch.TabIndex = 44;
			this.pictureBoxSearch.TabStop = false;
			this.pictureBoxSearch.Click += new System.EventHandler(this.PictureBoxSearch_Click);
			// 
			// pictureBoxUp
			// 
			this.pictureBoxUp.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxUp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxUp.Image = global::RecruitmentUser.Properties.Resources.arrowUpB;
			this.pictureBoxUp.Location = new System.Drawing.Point(112, 12);
			this.pictureBoxUp.Name = "pictureBoxUp";
			this.pictureBoxUp.Size = new System.Drawing.Size(28, 28);
			this.pictureBoxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxUp.TabIndex = 43;
			this.pictureBoxUp.TabStop = false;
			this.pictureBoxUp.Click += new System.EventHandler(this.ButtonUp_Click);
			// 
			// pictureBoxDown
			// 
			this.pictureBoxDown.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxDown.Image = global::RecruitmentUser.Properties.Resources.arrowDownB;
			this.pictureBoxDown.Location = new System.Drawing.Point(72, 12);
			this.pictureBoxDown.Name = "pictureBoxDown";
			this.pictureBoxDown.Size = new System.Drawing.Size(28, 28);
			this.pictureBoxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxDown.TabIndex = 42;
			this.pictureBoxDown.TabStop = false;
			this.pictureBoxDown.Click += new System.EventHandler(this.ButtonDown_Click);
			// 
			// pictureBoxRefresh
			// 
			this.pictureBoxRefresh.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxRefresh.Image = global::RecruitmentUser.Properties.Resources.refreshB;
			this.pictureBoxRefresh.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxRefresh.Name = "pictureBoxRefresh";
			this.pictureBoxRefresh.Size = new System.Drawing.Size(28, 28);
			this.pictureBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxRefresh.TabIndex = 41;
			this.pictureBoxRefresh.TabStop = false;
			this.pictureBoxRefresh.Click += new System.EventHandler(this.PictureBoxRefresh_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(1377, 711);
			this.Controls.Add(this.flpMain);
			this.Controls.Add(this.panelSearch);
			this.Controls.Add(this.flp_Menu);
			this.Controls.Add(this.panelUp);
			this.MinimumSize = new System.Drawing.Size(1225, 450);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Головна";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.panelUp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasswordChange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
			this.flp_Menu.ResumeLayout(false);
			this.flp_Menu.PerformLayout();
			this.flpMain.ResumeLayout(false);
			this.flpMain.PerformLayout();
			this.panelVacancy.ResumeLayout(false);
			this.panelVacancy.PerformLayout();
			this.panelApplication.ResumeLayout(false);
			this.panelApplication.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxApplication)).EndInit();
			this.panelInterview.ResumeLayout(false);
			this.panelInterview.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInterview)).EndInit();
			this.panelSalarySearch.ResumeLayout(false);
			this.panelSalarySearch.PerformLayout();
			this.panelSearch.ResumeLayout(false);
			this.panelSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.FlowLayoutPanel flp_Menu;
        private System.Windows.Forms.Label labelVacancy;
        private System.Windows.Forms.Label labelApplication;
        private System.Windows.Forms.Label labelInterview;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.TextBox textBoxPositionSearch;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.Panel panelSalarySearch;
        private System.Windows.Forms.TextBox textBoxMaxSalarySearch;
        private System.Windows.Forms.Label labelSalarySearch2;
        private System.Windows.Forms.Label labelSalarySearch;
        private System.Windows.Forms.TextBox textBoxMinSalarySearch;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.PictureBox pictureBoxRefresh;
        private System.Windows.Forms.PictureBox pictureBoxDown;
        private System.Windows.Forms.PictureBox pictureBoxUp;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxPasswordChange;
        private System.Windows.Forms.PictureBox pictureBoxTheme;
        private System.Windows.Forms.PictureBox pictureBoxLine;
        private System.Windows.Forms.Panel panelVacancy;
        private System.Windows.Forms.Button buttonVacancy;
        private System.Windows.Forms.Label labelDatePublicationV;
        private System.Windows.Forms.Label labelSalaryV;
        private System.Windows.Forms.Label labelPositionDescriptionV;
        private System.Windows.Forms.Label labelPositionV;
        private System.Windows.Forms.Panel panelApplication;
        private System.Windows.Forms.Button buttonReasonRejectionA;
        private System.Windows.Forms.Label labelStatusA;
        private System.Windows.Forms.Label labelDateSubmissionA;
        private System.Windows.Forms.Label labelPositionA;
        private System.Windows.Forms.Panel panelInterview;
        private System.Windows.Forms.Label labelStatusI;
        private System.Windows.Forms.Label labelDateEventI;
        private System.Windows.Forms.Label labelPositionI;
        private System.Windows.Forms.PictureBox pictureBoxApplication;
        private System.Windows.Forms.PictureBox pictureBoxInterview;
    }
}

