namespace ServerDB.Forms
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
			this.buttonApply = new System.Windows.Forms.Button();
			this.richTextBoxPosition = new System.Windows.Forms.RichTextBox();
			this.buttonVacancy = new System.Windows.Forms.Button();
			this.labelDatePublication = new System.Windows.Forms.Label();
			this.richTextBoxAdditionalInfo = new System.Windows.Forms.RichTextBox();
			this.labelAdditionalInfoTitle = new System.Windows.Forms.Label();
			this.labelScores = new System.Windows.Forms.Label();
			this.buttonCandidate = new System.Windows.Forms.Button();
			this.comboBoxDecision = new System.Windows.Forms.ComboBox();
			this.applicationStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.recruitmentDBDataSet = new ServerDB.RecruitmentDB();
			this.application_StatusTableAdapter = new ServerDB.RecruitmentDBTableAdapters.Application_StatusTableAdapter();
			this.buttonReasonRejection = new System.Windows.Forms.Button();
			this.labelStatus = new System.Windows.Forms.Label();
			this.richTextBoxReason = new System.Windows.Forms.RichTextBox();
			this.labelReason = new System.Windows.Forms.Label();
			this.labelDate = new System.Windows.Forms.Label();
			this.dateTimePickerInterview = new System.Windows.Forms.DateTimePicker();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.labelHours = new System.Windows.Forms.Label();
			this.labelMinutes = new System.Windows.Forms.Label();
			this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			this.panelInterview = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.applicationStatusBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
			this.panelInterview.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonApply
			// 
			this.buttonApply.AutoSize = true;
			this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonApply.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonApply.Location = new System.Drawing.Point(1072, 400);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(175, 40);
			this.buttonApply.TabIndex = 13;
			this.buttonApply.Text = "Застосувати";
			this.buttonApply.UseVisualStyleBackColor = false;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// richTextBoxPosition
			// 
			this.richTextBoxPosition.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxPosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPosition.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPosition.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxPosition.Location = new System.Drawing.Point(12, 12);
			this.richTextBoxPosition.MaxLength = 64;
			this.richTextBoxPosition.Multiline = false;
			this.richTextBoxPosition.Name = "richTextBoxPosition";
			this.richTextBoxPosition.ReadOnly = true;
			this.richTextBoxPosition.Size = new System.Drawing.Size(835, 40);
			this.richTextBoxPosition.TabIndex = 0;
			this.richTextBoxPosition.TabStop = false;
			this.richTextBoxPosition.Text = "";
			// 
			// buttonVacancy
			// 
			this.buttonVacancy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonVacancy.AutoSize = true;
			this.buttonVacancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonVacancy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonVacancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonVacancy.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonVacancy.Location = new System.Drawing.Point(17, 400);
			this.buttonVacancy.Name = "buttonVacancy";
			this.buttonVacancy.Size = new System.Drawing.Size(175, 40);
			this.buttonVacancy.TabIndex = 8;
			this.buttonVacancy.Text = "Вакансія";
			this.buttonVacancy.UseVisualStyleBackColor = false;
			this.buttonVacancy.Click += new System.EventHandler(this.ButtonVacancy_Click);
			// 
			// labelDatePublication
			// 
			this.labelDatePublication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatePublication.BackColor = System.Drawing.Color.Transparent;
			this.labelDatePublication.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDatePublication.ForeColor = System.Drawing.Color.Black;
			this.labelDatePublication.Location = new System.Drawing.Point(722, 79);
			this.labelDatePublication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDatePublication.Name = "labelDatePublication";
			this.labelDatePublication.Size = new System.Drawing.Size(536, 25);
			this.labelDatePublication.TabIndex = 4;
			this.labelDatePublication.Text = "Дата і час подачі";
			this.labelDatePublication.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// richTextBoxAdditionalInfo
			// 
			this.richTextBoxAdditionalInfo.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxAdditionalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxAdditionalInfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxAdditionalInfo.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxAdditionalInfo.Location = new System.Drawing.Point(12, 172);
			this.richTextBoxAdditionalInfo.MaxLength = 2048;
			this.richTextBoxAdditionalInfo.Name = "richTextBoxAdditionalInfo";
			this.richTextBoxAdditionalInfo.ReadOnly = true;
			this.richTextBoxAdditionalInfo.Size = new System.Drawing.Size(525, 175);
			this.richTextBoxAdditionalInfo.TabIndex = 3;
			this.richTextBoxAdditionalInfo.TabStop = false;
			this.richTextBoxAdditionalInfo.Text = "";
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
			// buttonCandidate
			// 
			this.buttonCandidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCandidate.AutoSize = true;
			this.buttonCandidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonCandidate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCandidate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCandidate.Location = new System.Drawing.Point(250, 400);
			this.buttonCandidate.Name = "buttonCandidate";
			this.buttonCandidate.Size = new System.Drawing.Size(175, 40);
			this.buttonCandidate.TabIndex = 9;
			this.buttonCandidate.Text = "Кандидат";
			this.buttonCandidate.UseVisualStyleBackColor = false;
			this.buttonCandidate.Click += new System.EventHandler(this.ButtonCandidate_Click);
			// 
			// comboBoxDecision
			// 
			this.comboBoxDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDecision.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDecision.DataSource = this.applicationStatusBindingSource;
			this.comboBoxDecision.DisplayMember = "status";
			this.comboBoxDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDecision.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDecision.ForeColor = System.Drawing.Color.Black;
			this.comboBoxDecision.FormattingEnabled = true;
			this.comboBoxDecision.Location = new System.Drawing.Point(722, 404);
			this.comboBoxDecision.Name = "comboBoxDecision";
			this.comboBoxDecision.Size = new System.Drawing.Size(250, 36);
			this.comboBoxDecision.TabIndex = 11;
			this.comboBoxDecision.ValueMember = "id";
			this.comboBoxDecision.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDecision_SelectedIndexChanged);
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
			// buttonReasonRejection
			// 
			this.buttonReasonRejection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReasonRejection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(29)))), ((int)(((byte)(52)))));
			this.buttonReasonRejection.Cursor = System.Windows.Forms.Cursors.Help;
			this.buttonReasonRejection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonReasonRejection.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonReasonRejection.Location = new System.Drawing.Point(1017, 400);
			this.buttonReasonRejection.Name = "buttonReasonRejection";
			this.buttonReasonRejection.Size = new System.Drawing.Size(230, 40);
			this.buttonReasonRejection.TabIndex = 12;
			this.buttonReasonRejection.Text = "Причина відмови";
			this.buttonReasonRejection.UseVisualStyleBackColor = false;
			this.buttonReasonRejection.Visible = false;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoSize = true;
			this.labelStatus.BackColor = System.Drawing.Color.Transparent;
			this.labelStatus.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.ForeColor = System.Drawing.Color.Black;
			this.labelStatus.Location = new System.Drawing.Point(611, 411);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(106, 29);
			this.labelStatus.TabIndex = 10;
			this.labelStatus.Text = "Статус:";
			// 
			// richTextBoxReason
			// 
			this.richTextBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxReason.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxReason.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxReason.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxReason.Location = new System.Drawing.Point(722, 172);
			this.richTextBoxReason.MaxLength = 2048;
			this.richTextBoxReason.Name = "richTextBoxReason";
			this.richTextBoxReason.Size = new System.Drawing.Size(525, 175);
			this.richTextBoxReason.TabIndex = 7;
			this.richTextBoxReason.Text = "";
			this.richTextBoxReason.Visible = false;
			// 
			// labelReason
			// 
			this.labelReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReason.AutoSize = true;
			this.labelReason.BackColor = System.Drawing.Color.Transparent;
			this.labelReason.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelReason.ForeColor = System.Drawing.Color.Black;
			this.labelReason.Location = new System.Drawing.Point(716, 132);
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
			this.labelDate.Text = "Дата і час співбесіди:";
			// 
			// dateTimePickerInterview
			// 
			this.dateTimePickerInterview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePickerInterview.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.dateTimePickerInterview.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
			this.dateTimePickerInterview.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.dateTimePickerInterview.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dateTimePickerInterview.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerInterview.Location = new System.Drawing.Point(7, 51);
			this.dateTimePickerInterview.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerInterview.Name = "dateTimePickerInterview";
			this.dateTimePickerInterview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dateTimePickerInterview.Size = new System.Drawing.Size(300, 36);
			this.dateTimePickerInterview.TabIndex = 1;
			this.dateTimePickerInterview.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
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
			this.numericUpDownHours.Size = new System.Drawing.Size(50, 36);
			this.numericUpDownHours.TabIndex = 2;
			this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelHours
			// 
			this.labelHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHours.AutoSize = true;
			this.labelHours.BackColor = System.Drawing.Color.Transparent;
			this.labelHours.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHours.ForeColor = System.Drawing.Color.Black;
			this.labelHours.Location = new System.Drawing.Point(62, 117);
			this.labelHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(50, 23);
			this.labelHours.TabIndex = 3;
			this.labelHours.Text = "год.";
			// 
			// labelMinutes
			// 
			this.labelMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMinutes.AutoSize = true;
			this.labelMinutes.BackColor = System.Drawing.Color.Transparent;
			this.labelMinutes.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMinutes.ForeColor = System.Drawing.Color.Black;
			this.labelMinutes.Location = new System.Drawing.Point(180, 117);
			this.labelMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelMinutes.Name = "labelMinutes";
			this.labelMinutes.Size = new System.Drawing.Size(39, 23);
			this.labelMinutes.TabIndex = 5;
			this.labelMinutes.Text = "хв.";
			// 
			// numericUpDownMinutes
			// 
			this.numericUpDownMinutes.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownMinutes.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownMinutes.Location = new System.Drawing.Point(125, 104);
			this.numericUpDownMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numericUpDownMinutes.Name = "numericUpDownMinutes";
			this.numericUpDownMinutes.Size = new System.Drawing.Size(50, 36);
			this.numericUpDownMinutes.TabIndex = 4;
			this.numericUpDownMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// panelInterview
			// 
			this.panelInterview.BackColor = System.Drawing.Color.Transparent;
			this.panelInterview.Controls.Add(this.labelDate);
			this.panelInterview.Controls.Add(this.labelMinutes);
			this.panelInterview.Controls.Add(this.labelHours);
			this.panelInterview.Controls.Add(this.numericUpDownHours);
			this.panelInterview.Controls.Add(this.dateTimePickerInterview);
			this.panelInterview.Controls.Add(this.numericUpDownMinutes);
			this.panelInterview.Location = new System.Drawing.Point(715, 121);
			this.panelInterview.Name = "panelInterview";
			this.panelInterview.Size = new System.Drawing.Size(532, 226);
			this.panelInterview.TabIndex = 5;
			this.panelInterview.Visible = false;
			// 
			// ApplicationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 481);
			this.Controls.Add(this.panelInterview);
			this.Controls.Add(this.richTextBoxReason);
			this.Controls.Add(this.labelReason);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonReasonRejection);
			this.Controls.Add(this.comboBoxDecision);
			this.Controls.Add(this.buttonCandidate);
			this.Controls.Add(this.richTextBoxPosition);
			this.Controls.Add(this.buttonVacancy);
			this.Controls.Add(this.labelDatePublication);
			this.Controls.Add(this.richTextBoxAdditionalInfo);
			this.Controls.Add(this.labelAdditionalInfoTitle);
			this.Controls.Add(this.labelScores);
			this.Controls.Add(this.buttonApply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ApplicationForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Заявка";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplicationForm_FormClosed);
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
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.RichTextBox richTextBoxPosition;
        private System.Windows.Forms.Button buttonVacancy;
        private System.Windows.Forms.Label labelDatePublication;
        private System.Windows.Forms.RichTextBox richTextBoxAdditionalInfo;
        private System.Windows.Forms.Label labelAdditionalInfoTitle;
        private System.Windows.Forms.Label labelScores;
        private System.Windows.Forms.Button buttonCandidate;
        private System.Windows.Forms.ComboBox comboBoxDecision;
        private RecruitmentDB recruitmentDBDataSet;
        private System.Windows.Forms.BindingSource applicationStatusBindingSource;
        private RecruitmentDBTableAdapters.Application_StatusTableAdapter application_StatusTableAdapter;
        private System.Windows.Forms.Button buttonReasonRejection;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.RichTextBox richTextBoxReason;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerInterview;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.Panel panelInterview;
    }
}