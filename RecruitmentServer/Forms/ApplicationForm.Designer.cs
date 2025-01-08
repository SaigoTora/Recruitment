namespace RecruitmentServer.Forms
{
    partial class ApplicationForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
			this.labelDatePublication = new System.Windows.Forms.Label();
			this.labelAdditionalInfoTitle = new System.Windows.Forms.Label();
			this.labelScores = new System.Windows.Forms.Label();
			this.applicationStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.recruitmentDBDataSet = new RecruitmentServer.RecruitmentDB();
			this.application_StatusTableAdapter = new RecruitmentServer.RecruitmentDBTableAdapters.Application_StatusTableAdapter();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelReason = new System.Windows.Forms.Label();
			this.labelDate = new System.Windows.Forms.Label();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.labelHours = new System.Windows.Forms.Label();
			this.labelMinutes = new System.Windows.Forms.Label();
			this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			this.panelInterview = new System.Windows.Forms.Panel();
			this.dateTimePickerInterview = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.richTextBoxReason = new Guna.UI2.WinForms.Guna2TextBox();
			this.buttonVacancy = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonCandidate = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonReasonRejection = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonApply = new Guna.UI2.WinForms.Guna2GradientButton();
			this.textBoxPosition = new Guna.UI2.WinForms.Guna2TextBox();
			this.comboBoxDecision = new Guna.UI2.WinForms.Guna2ComboBox();
			this.richTextBoxAdditionalInfo = new Guna.UI2.WinForms.Guna2TextBox();
			((System.ComponentModel.ISupportInitialize)(this.applicationStatusBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
			this.panelInterview.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelDatePublication
			// 
			this.labelDatePublication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatePublication.BackColor = System.Drawing.Color.Transparent;
			this.labelDatePublication.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDatePublication.ForeColor = System.Drawing.Color.Black;
			this.labelDatePublication.Location = new System.Drawing.Point(601, 80);
			this.labelDatePublication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDatePublication.Name = "labelDatePublication";
			this.labelDatePublication.Size = new System.Drawing.Size(532, 25);
			this.labelDatePublication.TabIndex = 4;
			this.labelDatePublication.Tag = "";
			this.labelDatePublication.Text = "Дата і час подачі";
			this.labelDatePublication.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelAdditionalInfoTitle
			// 
			this.labelAdditionalInfoTitle.AutoSize = true;
			this.labelAdditionalInfoTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelAdditionalInfoTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAdditionalInfoTitle.ForeColor = System.Drawing.Color.Black;
			this.labelAdditionalInfoTitle.Location = new System.Drawing.Point(12, 132);
			this.labelAdditionalInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAdditionalInfoTitle.Name = "labelAdditionalInfoTitle";
			this.labelAdditionalInfoTitle.Size = new System.Drawing.Size(542, 32);
			this.labelAdditionalInfoTitle.TabIndex = 2;
			this.labelAdditionalInfoTitle.Text = "Додаткова інформація від кандидата:";
			// 
			// labelScores
			// 
			this.labelScores.AutoSize = true;
			this.labelScores.BackColor = System.Drawing.Color.Transparent;
			this.labelScores.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScores.ForeColor = System.Drawing.Color.Black;
			this.labelScores.Location = new System.Drawing.Point(12, 72);
			this.labelScores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelScores.Name = "labelScores";
			this.labelScores.Size = new System.Drawing.Size(83, 32);
			this.labelScores.TabIndex = 1;
			this.labelScores.Text = "Бали";
			// 
			// applicationStatusBindingSource
			// 
			this.applicationStatusBindingSource.DataMember = "Application_Status";
			this.applicationStatusBindingSource.DataSource = this.recruitmentDBDataSet;
			// 
			// recruitmentDBDataSet
			// 
			this.recruitmentDBDataSet.DataSetName = "RecruitmentDBDataSet";
			this.recruitmentDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// application_StatusTableAdapter
			// 
			this.application_StatusTableAdapter.ClearBeforeFill = true;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoSize = true;
			this.labelStatus.BackColor = System.Drawing.Color.Transparent;
			this.labelStatus.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.ForeColor = System.Drawing.Color.Black;
			this.labelStatus.Location = new System.Drawing.Point(539, 440);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(106, 29);
			this.labelStatus.TabIndex = 10;
			this.labelStatus.Text = "Статус:";
			// 
			// labelReason
			// 
			this.labelReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReason.AutoSize = true;
			this.labelReason.BackColor = System.Drawing.Color.Transparent;
			this.labelReason.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelReason.ForeColor = System.Drawing.Color.Black;
			this.labelReason.Location = new System.Drawing.Point(602, 132);
			this.labelReason.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(264, 32);
			this.labelReason.TabIndex = 6;
			this.labelReason.Text = "Причина відмови:";
			this.labelReason.Visible = false;
			// 
			// labelDate
			// 
			this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDate.AutoSize = true;
			this.labelDate.BackColor = System.Drawing.Color.Transparent;
			this.labelDate.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDate.ForeColor = System.Drawing.Color.Black;
			this.labelDate.Location = new System.Drawing.Point(5, 11);
			this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(316, 32);
			this.labelDate.TabIndex = 0;
			this.labelDate.Tag = "fixedPosition";
			this.labelDate.Text = "Дата і час співбесіди:";
			// 
			// numericUpDownHours
			// 
			this.numericUpDownHours.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownHours.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownHours.Location = new System.Drawing.Point(7, 104);
			this.numericUpDownHours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.numericUpDownHours.Name = "numericUpDownHours";
			this.numericUpDownHours.Size = new System.Drawing.Size(60, 36);
			this.numericUpDownHours.TabIndex = 2;
			this.numericUpDownHours.Tag = "fixedPosition";
			this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelHours
			// 
			this.labelHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHours.AutoSize = true;
			this.labelHours.BackColor = System.Drawing.Color.Transparent;
			this.labelHours.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHours.ForeColor = System.Drawing.Color.Black;
			this.labelHours.Location = new System.Drawing.Point(72, 117);
			this.labelHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(50, 23);
			this.labelHours.TabIndex = 3;
			this.labelHours.Tag = "fixedPosition";
			this.labelHours.Text = "год.";
			// 
			// labelMinutes
			// 
			this.labelMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMinutes.AutoSize = true;
			this.labelMinutes.BackColor = System.Drawing.Color.Transparent;
			this.labelMinutes.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMinutes.ForeColor = System.Drawing.Color.Black;
			this.labelMinutes.Location = new System.Drawing.Point(210, 117);
			this.labelMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelMinutes.Name = "labelMinutes";
			this.labelMinutes.Size = new System.Drawing.Size(39, 23);
			this.labelMinutes.TabIndex = 5;
			this.labelMinutes.Tag = "fixedPosition";
			this.labelMinutes.Text = "хв.";
			// 
			// numericUpDownMinutes
			// 
			this.numericUpDownMinutes.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownMinutes.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownMinutes.Location = new System.Drawing.Point(145, 104);
			this.numericUpDownMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numericUpDownMinutes.Name = "numericUpDownMinutes";
			this.numericUpDownMinutes.Size = new System.Drawing.Size(60, 36);
			this.numericUpDownMinutes.TabIndex = 4;
			this.numericUpDownMinutes.Tag = "fixedPosition";
			this.numericUpDownMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// panelInterview
			// 
			this.panelInterview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panelInterview.BackColor = System.Drawing.Color.Transparent;
			this.panelInterview.Controls.Add(this.dateTimePickerInterview);
			this.panelInterview.Controls.Add(this.labelDate);
			this.panelInterview.Controls.Add(this.labelMinutes);
			this.panelInterview.Controls.Add(this.labelHours);
			this.panelInterview.Controls.Add(this.numericUpDownHours);
			this.panelInterview.Controls.Add(this.numericUpDownMinutes);
			this.panelInterview.Location = new System.Drawing.Point(601, 121);
			this.panelInterview.Name = "panelInterview";
			this.panelInterview.Size = new System.Drawing.Size(532, 226);
			this.panelInterview.TabIndex = 5;
			this.panelInterview.Tag = "needToMoveParentDown";
			this.panelInterview.Visible = false;
			// 
			// dateTimePickerInterview
			// 
			this.dateTimePickerInterview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePickerInterview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.dateTimePickerInterview.BorderRadius = 10;
			this.dateTimePickerInterview.BorderThickness = 2;
			this.dateTimePickerInterview.Checked = true;
			this.dateTimePickerInterview.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dateTimePickerInterview.FillColor = System.Drawing.Color.White;
			this.dateTimePickerInterview.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerInterview.ForeColor = System.Drawing.Color.Black;
			this.dateTimePickerInterview.Format = System.Windows.Forms.DateTimePickerFormat.Long;
			this.dateTimePickerInterview.Location = new System.Drawing.Point(7, 51);
			this.dateTimePickerInterview.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dateTimePickerInterview.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerInterview.Name = "dateTimePickerInterview";
			this.dateTimePickerInterview.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.dateTimePickerInterview.Size = new System.Drawing.Size(300, 36);
			this.dateTimePickerInterview.TabIndex = 1;
			this.dateTimePickerInterview.Tag = "fixedPosition";
			this.dateTimePickerInterview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.dateTimePickerInterview.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			// 
			// richTextBoxReason
			// 
			this.richTextBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxReason.Animated = true;
			this.richTextBoxReason.BackColor = System.Drawing.Color.Transparent;
			this.richTextBoxReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.richTextBoxReason.BorderRadius = 12;
			this.richTextBoxReason.BorderThickness = 2;
			this.richTextBoxReason.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.richTextBoxReason.DefaultText = "";
			this.richTextBoxReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.richTextBoxReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.richTextBoxReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.richTextBoxReason.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxReason.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxReason.HoverState.BorderColor = System.Drawing.Color.Black;
			this.richTextBoxReason.Location = new System.Drawing.Point(608, 172);
			this.richTextBoxReason.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.richTextBoxReason.MaxLength = 2048;
			this.richTextBoxReason.Multiline = true;
			this.richTextBoxReason.Name = "richTextBoxReason";
			this.richTextBoxReason.PasswordChar = '\0';
			this.richTextBoxReason.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.richTextBoxReason.PlaceholderText = "";
			this.richTextBoxReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.richTextBoxReason.SelectedText = "";
			this.richTextBoxReason.Size = new System.Drawing.Size(525, 225);
			this.richTextBoxReason.TabIndex = 7;
			this.richTextBoxReason.TabStop = false;
			this.richTextBoxReason.TextOffset = new System.Drawing.Point(3, 0);
			this.richTextBoxReason.Visible = false;
			// 
			// buttonVacancy
			// 
			this.buttonVacancy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonVacancy.Animated = true;
			this.buttonVacancy.BackColor = System.Drawing.Color.Transparent;
			this.buttonVacancy.BorderRadius = 7;
			this.buttonVacancy.BorderThickness = 1;
			this.buttonVacancy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonVacancy.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonVacancy.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonVacancy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonVacancy.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonVacancy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonVacancy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonVacancy.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonVacancy.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonVacancy.ForeColor = System.Drawing.Color.Black;
			this.buttonVacancy.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonVacancy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonVacancy.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonVacancy.Location = new System.Drawing.Point(18, 433);
			this.buttonVacancy.Name = "buttonVacancy";
			this.buttonVacancy.PressedColor = System.Drawing.Color.White;
			this.buttonVacancy.PressedDepth = 20;
			this.buttonVacancy.Size = new System.Drawing.Size(175, 40);
			this.buttonVacancy.TabIndex = 8;
			this.buttonVacancy.TabStop = false;
			this.buttonVacancy.Text = "Вакансія";
			this.buttonVacancy.Click += new System.EventHandler(this.ButtonVacancy_Click);
			// 
			// buttonCandidate
			// 
			this.buttonCandidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCandidate.Animated = true;
			this.buttonCandidate.BackColor = System.Drawing.Color.Transparent;
			this.buttonCandidate.BorderRadius = 7;
			this.buttonCandidate.BorderThickness = 1;
			this.buttonCandidate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCandidate.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonCandidate.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonCandidate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCandidate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCandidate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonCandidate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonCandidate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonCandidate.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonCandidate.ForeColor = System.Drawing.Color.Black;
			this.buttonCandidate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonCandidate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonCandidate.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonCandidate.Location = new System.Drawing.Point(251, 433);
			this.buttonCandidate.Name = "buttonCandidate";
			this.buttonCandidate.PressedColor = System.Drawing.Color.White;
			this.buttonCandidate.PressedDepth = 20;
			this.buttonCandidate.Size = new System.Drawing.Size(175, 40);
			this.buttonCandidate.TabIndex = 9;
			this.buttonCandidate.TabStop = false;
			this.buttonCandidate.Text = "Кандидат";
			this.buttonCandidate.Click += new System.EventHandler(this.ButtonCandidate_Click);
			// 
			// buttonReasonRejection
			// 
			this.buttonReasonRejection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReasonRejection.Animated = true;
			this.buttonReasonRejection.BackColor = System.Drawing.Color.Transparent;
			this.buttonReasonRejection.BorderRadius = 7;
			this.buttonReasonRejection.BorderThickness = 1;
			this.buttonReasonRejection.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonReasonRejection.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonReasonRejection.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonReasonRejection.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonReasonRejection.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonReasonRejection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonReasonRejection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
			this.buttonReasonRejection.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonReasonRejection.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonReasonRejection.ForeColor = System.Drawing.Color.Black;
			this.buttonReasonRejection.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonReasonRejection.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
			this.buttonReasonRejection.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			this.buttonReasonRejection.Location = new System.Drawing.Point(908, 433);
			this.buttonReasonRejection.Name = "buttonReasonRejection";
			this.buttonReasonRejection.PressedColor = System.Drawing.Color.White;
			this.buttonReasonRejection.PressedDepth = 20;
			this.buttonReasonRejection.Size = new System.Drawing.Size(230, 40);
			this.buttonReasonRejection.TabIndex = 12;
			this.buttonReasonRejection.TabStop = false;
			this.buttonReasonRejection.Text = "Причина відмови";
			this.buttonReasonRejection.Visible = false;
			this.buttonReasonRejection.Click += new System.EventHandler(this.ButtonReasonRejection_Click);
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
			this.buttonApply.Location = new System.Drawing.Point(963, 433);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.PressedColor = System.Drawing.Color.White;
			this.buttonApply.PressedDepth = 20;
			this.buttonApply.Size = new System.Drawing.Size(175, 40);
			this.buttonApply.TabIndex = 13;
			this.buttonApply.TabStop = false;
			this.buttonApply.Text = "Застосувати";
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.Animated = true;
			this.textBoxPosition.AutoScroll = true;
			this.textBoxPosition.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPosition.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPosition.BorderRadius = 10;
			this.textBoxPosition.BorderThickness = 0;
			this.textBoxPosition.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPosition.DefaultText = "";
			this.textBoxPosition.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPosition.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPosition.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPosition.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPosition.FillColor = System.Drawing.SystemColors.ControlLight;
			this.textBoxPosition.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPosition.ForeColor = System.Drawing.Color.Black;
			this.textBoxPosition.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPosition.Location = new System.Drawing.Point(12, 12);
			this.textBoxPosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPosition.MaxLength = 64;
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.PasswordChar = '\0';
			this.textBoxPosition.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPosition.PlaceholderText = "";
			this.textBoxPosition.ReadOnly = true;
			this.textBoxPosition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPosition.SelectedText = "";
			this.textBoxPosition.Size = new System.Drawing.Size(1124, 40);
			this.textBoxPosition.TabIndex = 0;
			this.textBoxPosition.TabStop = false;
			this.textBoxPosition.Tag = "";
			this.textBoxPosition.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// comboBoxDecision
			// 
			this.comboBoxDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDecision.Animated = true;
			this.comboBoxDecision.BackColor = System.Drawing.Color.Transparent;
			this.comboBoxDecision.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.comboBoxDecision.BorderRadius = 10;
			this.comboBoxDecision.BorderThickness = 2;
			this.comboBoxDecision.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDecision.DataSource = this.applicationStatusBindingSource;
			this.comboBoxDecision.DisplayMember = "status";
			this.comboBoxDecision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBoxDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDecision.FillColor = System.Drawing.Color.LightGray;
			this.comboBoxDecision.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.comboBoxDecision.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.comboBoxDecision.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDecision.ForeColor = System.Drawing.Color.Black;
			this.comboBoxDecision.FormattingEnabled = true;
			this.comboBoxDecision.IntegralHeight = false;
			this.comboBoxDecision.ItemHeight = 30;
			this.comboBoxDecision.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.comboBoxDecision.Location = new System.Drawing.Point(650, 437);
			this.comboBoxDecision.MaxDropDownItems = 15;
			this.comboBoxDecision.MaxLength = 64;
			this.comboBoxDecision.Name = "comboBoxDecision";
			this.comboBoxDecision.Size = new System.Drawing.Size(250, 36);
			this.comboBoxDecision.TabIndex = 11;
			this.comboBoxDecision.Tag = "fixedPosition";
			this.comboBoxDecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.comboBoxDecision.ValueMember = "id";
			this.comboBoxDecision.DropDown += new System.EventHandler(this.ComboBox_DropDown);
			this.comboBoxDecision.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDecision_SelectedIndexChanged);
			this.comboBoxDecision.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
			// 
			// richTextBoxAdditionalInfo
			// 
			this.richTextBoxAdditionalInfo.Animated = true;
			this.richTextBoxAdditionalInfo.BackColor = System.Drawing.Color.Transparent;
			this.richTextBoxAdditionalInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.richTextBoxAdditionalInfo.BorderRadius = 12;
			this.richTextBoxAdditionalInfo.BorderThickness = 0;
			this.richTextBoxAdditionalInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.richTextBoxAdditionalInfo.DefaultText = "";
			this.richTextBoxAdditionalInfo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.richTextBoxAdditionalInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.richTextBoxAdditionalInfo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.richTextBoxAdditionalInfo.FillColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxAdditionalInfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxAdditionalInfo.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxAdditionalInfo.HoverState.BorderColor = System.Drawing.Color.Black;
			this.richTextBoxAdditionalInfo.Location = new System.Drawing.Point(12, 172);
			this.richTextBoxAdditionalInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.richTextBoxAdditionalInfo.MaxLength = 2048;
			this.richTextBoxAdditionalInfo.Multiline = true;
			this.richTextBoxAdditionalInfo.Name = "richTextBoxAdditionalInfo";
			this.richTextBoxAdditionalInfo.PasswordChar = '\0';
			this.richTextBoxAdditionalInfo.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.richTextBoxAdditionalInfo.PlaceholderText = "";
			this.richTextBoxAdditionalInfo.ReadOnly = true;
			this.richTextBoxAdditionalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.richTextBoxAdditionalInfo.SelectedText = "";
			this.richTextBoxAdditionalInfo.Size = new System.Drawing.Size(525, 225);
			this.richTextBoxAdditionalInfo.TabIndex = 3;
			this.richTextBoxAdditionalInfo.TabStop = false;
			this.richTextBoxAdditionalInfo.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// ApplicationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1150, 500);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.richTextBoxAdditionalInfo);
			this.Controls.Add(this.comboBoxDecision);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.buttonCandidate);
			this.Controls.Add(this.buttonVacancy);
			this.Controls.Add(this.labelReason);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.labelDatePublication);
			this.Controls.Add(this.labelAdditionalInfoTitle);
			this.Controls.Add(this.labelScores);
			this.Controls.Add(this.panelInterview);
			this.Controls.Add(this.buttonReasonRejection);
			this.Controls.Add(this.richTextBoxReason);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ApplicationForm";
			this.Text = "Заявка";
			this.Load += new System.EventHandler(this.ApplicationForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.applicationStatusBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
			this.panelInterview.ResumeLayout(false);
			this.panelInterview.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDatePublication;
        private System.Windows.Forms.Label labelAdditionalInfoTitle;
        private System.Windows.Forms.Label labelScores;
        private RecruitmentDB recruitmentDBDataSet;
        private System.Windows.Forms.BindingSource applicationStatusBindingSource;
        private RecruitmentDBTableAdapters.Application_StatusTableAdapter application_StatusTableAdapter;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.Panel panelInterview;
		private Guna.UI2.WinForms.Guna2GradientButton buttonVacancy;
		private Guna.UI2.WinForms.Guna2GradientButton buttonCandidate;
		private Guna.UI2.WinForms.Guna2GradientButton buttonReasonRejection;
		private Guna.UI2.WinForms.Guna2GradientButton buttonApply;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPosition;
		private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerInterview;
		private Guna.UI2.WinForms.Guna2ComboBox comboBoxDecision;
		private Guna.UI2.WinForms.Guna2TextBox richTextBoxAdditionalInfo;
		private Guna.UI2.WinForms.Guna2TextBox richTextBoxReason;
	}
}