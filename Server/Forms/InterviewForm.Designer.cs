namespace ServerDB.Forms
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
			this.buttonApply = new System.Windows.Forms.Button();
			this.richTextBoxPosition = new System.Windows.Forms.RichTextBox();
			this.buttonApplication = new System.Windows.Forms.Button();
			this.labelDateEvent = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.comboBoxDecision = new System.Windows.Forms.ComboBox();
			this.interviewStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.recruitmentDBDataSet = new ServerDB.RecruitmentDB();
			this.interview_StatusTableAdapter = new ServerDB.RecruitmentDBTableAdapters.Interview_StatusTableAdapter();
			this.buttonEmployee = new System.Windows.Forms.Button();
			this.buttonChangeDate = new System.Windows.Forms.Button();
			this.panelDate = new System.Windows.Forms.Panel();
			this.labelDate = new System.Windows.Forms.Label();
			this.labelMinutes = new System.Windows.Forms.Label();
			this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			this.labelHours = new System.Windows.Forms.Label();
			this.dateTimePickerInterview = new System.Windows.Forms.DateTimePicker();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.buttonChangeApply = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.interviewStatusBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			this.panelDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.AutoSize = true;
			this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonApply.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonApply.Location = new System.Drawing.Point(672, 192);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(175, 40);
			this.buttonApply.TabIndex = 8;
			this.buttonApply.Text = "Застосувати";
			this.buttonApply.UseVisualStyleBackColor = false;
			this.buttonApply.Visible = false;
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
			// buttonApplication
			// 
			this.buttonApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonApplication.AutoSize = true;
			this.buttonApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonApplication.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApplication.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonApplication.Location = new System.Drawing.Point(12, 192);
			this.buttonApplication.Name = "buttonApplication";
			this.buttonApplication.Size = new System.Drawing.Size(175, 40);
			this.buttonApplication.TabIndex = 5;
			this.buttonApplication.Text = "Заявка";
			this.buttonApplication.UseVisualStyleBackColor = false;
			this.buttonApplication.Click += new System.EventHandler(this.ButtonApplication_Click);
			// 
			// labelDateEvent
			// 
			this.labelDateEvent.BackColor = System.Drawing.Color.Transparent;
			this.labelDateEvent.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateEvent.ForeColor = System.Drawing.Color.Black;
			this.labelDateEvent.Location = new System.Drawing.Point(12, 72);
			this.labelDateEvent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDateEvent.Name = "labelDateEvent";
			this.labelDateEvent.Size = new System.Drawing.Size(835, 32);
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
			// comboBoxDecision
			// 
			this.comboBoxDecision.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDecision.DataSource = this.interviewStatusBindingSource;
			this.comboBoxDecision.DisplayMember = "status";
			this.comboBoxDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDecision.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDecision.ForeColor = System.Drawing.Color.Black;
			this.comboBoxDecision.FormattingEnabled = true;
			this.comboBoxDecision.Location = new System.Drawing.Point(123, 125);
			this.comboBoxDecision.Name = "comboBoxDecision";
			this.comboBoxDecision.Size = new System.Drawing.Size(360, 36);
			this.comboBoxDecision.TabIndex = 3;
			this.comboBoxDecision.ValueMember = "id";
			this.comboBoxDecision.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDecision_SelectedIndexChanged);
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
			// buttonEmployee
			// 
			this.buttonEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonEmployee.AutoSize = true;
			this.buttonEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEmployee.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEmployee.Location = new System.Drawing.Point(245, 192);
			this.buttonEmployee.Name = "buttonEmployee";
			this.buttonEmployee.Size = new System.Drawing.Size(175, 40);
			this.buttonEmployee.TabIndex = 7;
			this.buttonEmployee.Text = "Співробітник";
			this.buttonEmployee.UseVisualStyleBackColor = false;
			this.buttonEmployee.Visible = false;
			this.buttonEmployee.Click += new System.EventHandler(this.ButtonEmployee_Click);
			// 
			// buttonChangeDate
			// 
			this.buttonChangeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonChangeDate.AutoSize = true;
			this.buttonChangeDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonChangeDate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChangeDate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChangeDate.Location = new System.Drawing.Point(245, 192);
			this.buttonChangeDate.Name = "buttonChangeDate";
			this.buttonChangeDate.Size = new System.Drawing.Size(175, 40);
			this.buttonChangeDate.TabIndex = 6;
			this.buttonChangeDate.Text = "Змінити дату";
			this.buttonChangeDate.UseVisualStyleBackColor = false;
			this.buttonChangeDate.Visible = false;
			this.buttonChangeDate.Click += new System.EventHandler(this.ButtonChangeDate_Click);
			// 
			// panelDate
			// 
			this.panelDate.BackColor = System.Drawing.Color.Transparent;
			this.panelDate.Controls.Add(this.labelDate);
			this.panelDate.Controls.Add(this.labelMinutes);
			this.panelDate.Controls.Add(this.numericUpDownMinutes);
			this.panelDate.Controls.Add(this.labelHours);
			this.panelDate.Controls.Add(this.dateTimePickerInterview);
			this.panelDate.Controls.Add(this.numericUpDownHours);
			this.panelDate.Location = new System.Drawing.Point(8, 190);
			this.panelDate.Name = "panelDate";
			this.panelDate.Size = new System.Drawing.Size(358, 148);
			this.panelDate.TabIndex = 4;
			this.panelDate.Visible = false;
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
			this.labelDate.Text = "Дата і час співбесіди:";
			// 
			// labelMinutes
			// 
			this.labelMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMinutes.AutoSize = true;
			this.labelMinutes.BackColor = System.Drawing.Color.Transparent;
			this.labelMinutes.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMinutes.ForeColor = System.Drawing.Color.Black;
			this.labelMinutes.Location = new System.Drawing.Point(181, 109);
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
			this.numericUpDownMinutes.Location = new System.Drawing.Point(126, 96);
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
			// labelHours
			// 
			this.labelHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHours.AutoSize = true;
			this.labelHours.BackColor = System.Drawing.Color.Transparent;
			this.labelHours.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHours.ForeColor = System.Drawing.Color.Black;
			this.labelHours.Location = new System.Drawing.Point(63, 109);
			this.labelHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(50, 23);
			this.labelHours.TabIndex = 3;
			this.labelHours.Text = "год.";
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
			this.dateTimePickerInterview.Location = new System.Drawing.Point(8, 43);
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
			this.numericUpDownHours.Location = new System.Drawing.Point(8, 96);
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
			// buttonChangeApply
			// 
			this.buttonChangeApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeApply.AutoSize = true;
			this.buttonChangeApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonChangeApply.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChangeApply.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChangeApply.Location = new System.Drawing.Point(672, 192);
			this.buttonChangeApply.Name = "buttonChangeApply";
			this.buttonChangeApply.Size = new System.Drawing.Size(175, 40);
			this.buttonChangeApply.TabIndex = 9;
			this.buttonChangeApply.Text = "Змінити";
			this.buttonChangeApply.UseVisualStyleBackColor = false;
			this.buttonChangeApply.Visible = false;
			this.buttonChangeApply.Click += new System.EventHandler(this.ButtonChangeApply_Click);
			// 
			// InterviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 244);
			this.Controls.Add(this.panelDate);
			this.Controls.Add(this.buttonChangeApply);
			this.Controls.Add(this.buttonChangeDate);
			this.Controls.Add(this.buttonEmployee);
			this.Controls.Add(this.comboBoxDecision);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.richTextBoxPosition);
			this.Controls.Add(this.buttonApplication);
			this.Controls.Add(this.labelDateEvent);
			this.Controls.Add(this.buttonApply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InterviewForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Співбесіда";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InterviewForm_FormClosed);
			this.Load += new System.EventHandler(this.ApplicationForm_Load);
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
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.RichTextBox richTextBoxPosition;
        private System.Windows.Forms.Button buttonApplication;
        private System.Windows.Forms.Label labelDateEvent;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxDecision;
        private RecruitmentDB recruitmentDBDataSet;
        private System.Windows.Forms.BindingSource interviewStatusBindingSource;
        private RecruitmentDBTableAdapters.Interview_StatusTableAdapter interview_StatusTableAdapter;
        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Button buttonChangeDate;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.DateTimePicker dateTimePickerInterview;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.Button buttonChangeApply;
    }
}