namespace RecruitmentServer.Forms
{
	partial class InterviewForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterviewForm));
			this.labelDateEvent = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.interviewStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.recruitmentDBDataSet = new RecruitmentServer.RecruitmentDB();
			this.interview_StatusTableAdapter = new RecruitmentServer.RecruitmentDBTableAdapters.Interview_StatusTableAdapter();
			this.panelDate = new System.Windows.Forms.Panel();
			this.dateTimePickerInterview = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.labelDate = new System.Windows.Forms.Label();
			this.labelMinutes = new System.Windows.Forms.Label();
			this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			this.labelHours = new System.Windows.Forms.Label();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.buttonApplication = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonChangeDate = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonEmployee = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonChangeApply = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonApply = new Guna.UI2.WinForms.Guna2GradientButton();
			this.richTextBoxPosition = new Guna.UI2.WinForms.Guna2TextBox();
			this.comboBoxDecision = new Guna.UI2.WinForms.Guna2ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.interviewStatusBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			this.panelDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			this.SuspendLayout();
			// 
			// labelDateEvent
			// 
			this.labelDateEvent.BackColor = System.Drawing.Color.Transparent;
			this.labelDateEvent.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateEvent.ForeColor = System.Drawing.Color.Black;
			this.labelDateEvent.Location = new System.Drawing.Point(12, 72);
			this.labelDateEvent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDateEvent.Name = "labelDateEvent";
			this.labelDateEvent.Size = new System.Drawing.Size(724, 32);
			this.labelDateEvent.TabIndex = 1;
			this.labelDateEvent.Text = "Дата";
			this.labelDateEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.BackColor = System.Drawing.Color.Transparent;
			this.labelStatus.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.ForeColor = System.Drawing.Color.Black;
			this.labelStatus.Location = new System.Drawing.Point(12, 132);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(106, 29);
			this.labelStatus.TabIndex = 2;
			this.labelStatus.Text = "Статус:";
			// 
			// interviewStatusBindingSource
			// 
			this.interviewStatusBindingSource.DataMember = "Interview_Status";
			this.interviewStatusBindingSource.DataSource = this.recruitmentDBDataSet;
			// 
			// recruitmentDBDataSet
			// 
			this.recruitmentDBDataSet.DataSetName = "RecruitmentDBDataSet";
			this.recruitmentDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// interview_StatusTableAdapter
			// 
			this.interview_StatusTableAdapter.ClearBeforeFill = true;
			// 
			// panelDate
			// 
			this.panelDate.BackColor = System.Drawing.Color.Transparent;
			this.panelDate.Controls.Add(this.dateTimePickerInterview);
			this.panelDate.Controls.Add(this.labelDate);
			this.panelDate.Controls.Add(this.labelMinutes);
			this.panelDate.Controls.Add(this.numericUpDownMinutes);
			this.panelDate.Controls.Add(this.labelHours);
			this.panelDate.Controls.Add(this.numericUpDownHours);
			this.panelDate.Location = new System.Drawing.Point(8, 215);
			this.panelDate.Name = "panelDate";
			this.panelDate.Size = new System.Drawing.Size(358, 150);
			this.panelDate.TabIndex = 4;
			this.panelDate.Tag = "";
			this.panelDate.Visible = false;
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
			this.dateTimePickerInterview.Location = new System.Drawing.Point(8, 43);
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
			// labelDate
			// 
			this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDate.AutoSize = true;
			this.labelDate.BackColor = System.Drawing.Color.Transparent;
			this.labelDate.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDate.ForeColor = System.Drawing.Color.Black;
			this.labelDate.Location = new System.Drawing.Point(3, 3);
			this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(316, 32);
			this.labelDate.TabIndex = 0;
			this.labelDate.Tag = "fixedPosition";
			this.labelDate.Text = "Дата і час співбесіди:";
			// 
			// labelMinutes
			// 
			this.labelMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMinutes.AutoSize = true;
			this.labelMinutes.BackColor = System.Drawing.Color.Transparent;
			this.labelMinutes.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMinutes.ForeColor = System.Drawing.Color.Black;
			this.labelMinutes.Location = new System.Drawing.Point(211, 109);
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
			this.numericUpDownMinutes.Location = new System.Drawing.Point(146, 96);
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
			// labelHours
			// 
			this.labelHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHours.AutoSize = true;
			this.labelHours.BackColor = System.Drawing.Color.Transparent;
			this.labelHours.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHours.ForeColor = System.Drawing.Color.Black;
			this.labelHours.Location = new System.Drawing.Point(73, 109);
			this.labelHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(50, 23);
			this.labelHours.TabIndex = 3;
			this.labelHours.Tag = "fixedPosition";
			this.labelHours.Text = "год.";
			// 
			// numericUpDownHours
			// 
			this.numericUpDownHours.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownHours.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownHours.Location = new System.Drawing.Point(8, 96);
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
			// buttonApplication
			// 
			this.buttonApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonApplication.Animated = true;
			this.buttonApplication.BackColor = System.Drawing.Color.Transparent;
			this.buttonApplication.BorderRadius = 7;
			this.buttonApplication.BorderThickness = 1;
			this.buttonApplication.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplication.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonApplication.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonApplication.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonApplication.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonApplication.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonApplication.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonApplication.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonApplication.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonApplication.ForeColor = System.Drawing.Color.Black;
			this.buttonApplication.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonApplication.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonApplication.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonApplication.Location = new System.Drawing.Point(12, 203);
			this.buttonApplication.Name = "buttonApplication";
			this.buttonApplication.PressedColor = System.Drawing.Color.White;
			this.buttonApplication.PressedDepth = 20;
			this.buttonApplication.Size = new System.Drawing.Size(175, 40);
			this.buttonApplication.TabIndex = 5;
			this.buttonApplication.TabStop = false;
			this.buttonApplication.Text = "Заявка";
			this.buttonApplication.Click += new System.EventHandler(this.ButtonApplication_Click);
			// 
			// buttonChangeDate
			// 
			this.buttonChangeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonChangeDate.Animated = true;
			this.buttonChangeDate.BackColor = System.Drawing.Color.Transparent;
			this.buttonChangeDate.BorderRadius = 7;
			this.buttonChangeDate.BorderThickness = 1;
			this.buttonChangeDate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeDate.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonChangeDate.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonChangeDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangeDate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangeDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonChangeDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonChangeDate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonChangeDate.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonChangeDate.ForeColor = System.Drawing.Color.Black;
			this.buttonChangeDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonChangeDate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonChangeDate.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonChangeDate.Location = new System.Drawing.Point(245, 203);
			this.buttonChangeDate.Name = "buttonChangeDate";
			this.buttonChangeDate.PressedColor = System.Drawing.Color.White;
			this.buttonChangeDate.PressedDepth = 20;
			this.buttonChangeDate.Size = new System.Drawing.Size(200, 40);
			this.buttonChangeDate.TabIndex = 6;
			this.buttonChangeDate.TabStop = false;
			this.buttonChangeDate.Text = "Змінити дату";
			this.buttonChangeDate.Visible = false;
			this.buttonChangeDate.Click += new System.EventHandler(this.ButtonChangeDate_Click);
			// 
			// buttonEmployee
			// 
			this.buttonEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonEmployee.Animated = true;
			this.buttonEmployee.BackColor = System.Drawing.Color.Transparent;
			this.buttonEmployee.BorderRadius = 7;
			this.buttonEmployee.BorderThickness = 1;
			this.buttonEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonEmployee.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonEmployee.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonEmployee.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonEmployee.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonEmployee.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonEmployee.ForeColor = System.Drawing.Color.Black;
			this.buttonEmployee.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonEmployee.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonEmployee.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonEmployee.Location = new System.Drawing.Point(245, 203);
			this.buttonEmployee.Name = "buttonEmployee";
			this.buttonEmployee.PressedColor = System.Drawing.Color.White;
			this.buttonEmployee.PressedDepth = 20;
			this.buttonEmployee.Size = new System.Drawing.Size(200, 40);
			this.buttonEmployee.TabIndex = 7;
			this.buttonEmployee.TabStop = false;
			this.buttonEmployee.Text = "Співробітник";
			this.buttonEmployee.Visible = false;
			this.buttonEmployee.Click += new System.EventHandler(this.ButtonEmployee_Click);
			// 
			// buttonChangeApply
			// 
			this.buttonChangeApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeApply.Animated = true;
			this.buttonChangeApply.BackColor = System.Drawing.Color.Transparent;
			this.buttonChangeApply.BorderRadius = 7;
			this.buttonChangeApply.BorderThickness = 1;
			this.buttonChangeApply.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeApply.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonChangeApply.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonChangeApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangeApply.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangeApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonChangeApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonChangeApply.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonChangeApply.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonChangeApply.ForeColor = System.Drawing.Color.Black;
			this.buttonChangeApply.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonChangeApply.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonChangeApply.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonChangeApply.Location = new System.Drawing.Point(563, 203);
			this.buttonChangeApply.Name = "buttonChangeApply";
			this.buttonChangeApply.PressedColor = System.Drawing.Color.White;
			this.buttonChangeApply.PressedDepth = 20;
			this.buttonChangeApply.Size = new System.Drawing.Size(175, 40);
			this.buttonChangeApply.TabIndex = 9;
			this.buttonChangeApply.TabStop = false;
			this.buttonChangeApply.Text = "Змінити";
			this.buttonChangeApply.Visible = false;
			this.buttonChangeApply.Click += new System.EventHandler(this.ButtonChangeApply_Click);
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
			this.buttonApply.Location = new System.Drawing.Point(563, 203);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.PressedColor = System.Drawing.Color.White;
			this.buttonApply.PressedDepth = 20;
			this.buttonApply.Size = new System.Drawing.Size(175, 40);
			this.buttonApply.TabIndex = 8;
			this.buttonApply.TabStop = false;
			this.buttonApply.Text = "Застосувати";
			this.buttonApply.Visible = false;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// richTextBoxPosition
			// 
			this.richTextBoxPosition.Animated = true;
			this.richTextBoxPosition.AutoScroll = true;
			this.richTextBoxPosition.BackColor = System.Drawing.Color.Transparent;
			this.richTextBoxPosition.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.richTextBoxPosition.BorderRadius = 10;
			this.richTextBoxPosition.BorderThickness = 0;
			this.richTextBoxPosition.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.richTextBoxPosition.DefaultText = "";
			this.richTextBoxPosition.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.richTextBoxPosition.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.richTextBoxPosition.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.richTextBoxPosition.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.richTextBoxPosition.FillColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxPosition.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPosition.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxPosition.HoverState.BorderColor = System.Drawing.Color.Black;
			this.richTextBoxPosition.Location = new System.Drawing.Point(12, 12);
			this.richTextBoxPosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.richTextBoxPosition.MaxLength = 64;
			this.richTextBoxPosition.Name = "richTextBoxPosition";
			this.richTextBoxPosition.PasswordChar = '\0';
			this.richTextBoxPosition.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.richTextBoxPosition.PlaceholderText = "";
			this.richTextBoxPosition.ReadOnly = true;
			this.richTextBoxPosition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.richTextBoxPosition.SelectedText = "";
			this.richTextBoxPosition.Size = new System.Drawing.Size(724, 40);
			this.richTextBoxPosition.TabIndex = 0;
			this.richTextBoxPosition.TabStop = false;
			this.richTextBoxPosition.Tag = "";
			this.richTextBoxPosition.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// comboBoxDecision
			// 
			this.comboBoxDecision.Animated = true;
			this.comboBoxDecision.BackColor = System.Drawing.Color.Transparent;
			this.comboBoxDecision.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.comboBoxDecision.BorderRadius = 10;
			this.comboBoxDecision.BorderThickness = 2;
			this.comboBoxDecision.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDecision.DataSource = this.interviewStatusBindingSource;
			this.comboBoxDecision.DisplayMember = "status";
			this.comboBoxDecision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBoxDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDecision.FillColor = System.Drawing.Color.LightGray;
			this.comboBoxDecision.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.comboBoxDecision.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.comboBoxDecision.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDecision.ForeColor = System.Drawing.Color.Black;
			this.comboBoxDecision.FormattingEnabled = true;
			this.comboBoxDecision.IntegralHeight = false;
			this.comboBoxDecision.ItemHeight = 30;
			this.comboBoxDecision.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.comboBoxDecision.Location = new System.Drawing.Point(123, 125);
			this.comboBoxDecision.MaxDropDownItems = 15;
			this.comboBoxDecision.MaxLength = 64;
			this.comboBoxDecision.Name = "comboBoxDecision";
			this.comboBoxDecision.Size = new System.Drawing.Size(390, 36);
			this.comboBoxDecision.TabIndex = 3;
			this.comboBoxDecision.Tag = "";
			this.comboBoxDecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.comboBoxDecision.ValueMember = "id";
			this.comboBoxDecision.DropDown += new System.EventHandler(this.ComboBox_DropDown);
			this.comboBoxDecision.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDecision_SelectedIndexChanged);
			this.comboBoxDecision.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
			// 
			// InterviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 265);
			this.Controls.Add(this.panelDate);
			this.Controls.Add(this.comboBoxDecision);
			this.Controls.Add(this.richTextBoxPosition);
			this.Controls.Add(this.buttonChangeApply);
			this.Controls.Add(this.buttonApplication);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.labelDateEvent);
			this.Controls.Add(this.buttonEmployee);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.buttonChangeDate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InterviewForm";
			this.Text = "Співбесіда";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InterviewForm_FormClosed);
			this.Load += new System.EventHandler(this.InterviewForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.interviewStatusBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).EndInit();
			this.panelDate.ResumeLayout(false);
			this.panelDate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelDateEvent;
		private System.Windows.Forms.Label labelStatus;
		private RecruitmentDB recruitmentDBDataSet;
		private System.Windows.Forms.BindingSource interviewStatusBindingSource;
		private RecruitmentDBTableAdapters.Interview_StatusTableAdapter interview_StatusTableAdapter;
		private System.Windows.Forms.Panel panelDate;
		private System.Windows.Forms.Label labelDate;
		private System.Windows.Forms.Label labelMinutes;
		private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
		private System.Windows.Forms.Label labelHours;
		private System.Windows.Forms.NumericUpDown numericUpDownHours;
		private Guna.UI2.WinForms.Guna2GradientButton buttonApplication;
		private Guna.UI2.WinForms.Guna2GradientButton buttonChangeDate;
		private Guna.UI2.WinForms.Guna2GradientButton buttonEmployee;
		private Guna.UI2.WinForms.Guna2GradientButton buttonChangeApply;
		private Guna.UI2.WinForms.Guna2GradientButton buttonApply;
		private Guna.UI2.WinForms.Guna2TextBox richTextBoxPosition;
		private Guna.UI2.WinForms.Guna2ComboBox comboBoxDecision;
		private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerInterview;
	}
}