namespace RecruitmentClient.Forms
{
    partial class VacancyForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VacancyForm));
			this.labelSalaryTitle = new System.Windows.Forms.Label();
			this.labelPositionDescriptionTitle = new System.Windows.Forms.Label();
			this.labelAdditionalInfoTitle = new System.Windows.Forms.Label();
			this.labelClientAdditionalInfoTitle = new System.Windows.Forms.Label();
			this.labelDatePublication = new System.Windows.Forms.Label();
			this.richTextBoxPositionDescription = new System.Windows.Forms.RichTextBox();
			this.richTextBoxAdditionalInfo = new System.Windows.Forms.RichTextBox();
			this.richTextBoxSalary = new System.Windows.Forms.RichTextBox();
			this.buttonSend = new Guna.UI2.WinForms.Guna2GradientButton();
			this.richTextBoxClientAdditionalInfo = new Guna.UI2.WinForms.Guna2TextBox();
			this.buttonRequirements = new Guna.UI2.WinForms.Guna2GradientButton();
			this.labelPosition = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// labelSalaryTitle
			// 
			this.labelSalaryTitle.AutoSize = true;
			this.labelSalaryTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelSalaryTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSalaryTitle.ForeColor = System.Drawing.Color.Black;
			this.labelSalaryTitle.Location = new System.Drawing.Point(12, 72);
			this.labelSalaryTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalaryTitle.Name = "labelSalaryTitle";
			this.labelSalaryTitle.Size = new System.Drawing.Size(155, 32);
			this.labelSalaryTitle.TabIndex = 2;
			this.labelSalaryTitle.Text = "Зарплата:";
			// 
			// labelPositionDescriptionTitle
			// 
			this.labelPositionDescriptionTitle.AutoSize = true;
			this.labelPositionDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelPositionDescriptionTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPositionDescriptionTitle.ForeColor = System.Drawing.Color.Black;
			this.labelPositionDescriptionTitle.Location = new System.Drawing.Point(12, 152);
			this.labelPositionDescriptionTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPositionDescriptionTitle.Name = "labelPositionDescriptionTitle";
			this.labelPositionDescriptionTitle.Size = new System.Drawing.Size(95, 32);
			this.labelPositionDescriptionTitle.TabIndex = 4;
			this.labelPositionDescriptionTitle.Text = "Опис:";
			// 
			// labelAdditionalInfoTitle
			// 
			this.labelAdditionalInfoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAdditionalInfoTitle.AutoSize = true;
			this.labelAdditionalInfoTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelAdditionalInfoTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAdditionalInfoTitle.ForeColor = System.Drawing.Color.Black;
			this.labelAdditionalInfoTitle.Location = new System.Drawing.Point(675, 152);
			this.labelAdditionalInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAdditionalInfoTitle.Name = "labelAdditionalInfoTitle";
			this.labelAdditionalInfoTitle.Size = new System.Drawing.Size(532, 32);
			this.labelAdditionalInfoTitle.TabIndex = 6;
			this.labelAdditionalInfoTitle.Text = "Додаткова інформація про вакансію:";
			// 
			// labelClientAdditionalInfoTitle
			// 
			this.labelClientAdditionalInfoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelClientAdditionalInfoTitle.AutoSize = true;
			this.labelClientAdditionalInfoTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelClientAdditionalInfoTitle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelClientAdditionalInfoTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelClientAdditionalInfoTitle.ForeColor = System.Drawing.Color.Black;
			this.labelClientAdditionalInfoTitle.Location = new System.Drawing.Point(12, 490);
			this.labelClientAdditionalInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelClientAdditionalInfoTitle.Name = "labelClientAdditionalInfoTitle";
			this.labelClientAdditionalInfoTitle.Size = new System.Drawing.Size(419, 32);
			this.labelClientAdditionalInfoTitle.TabIndex = 8;
			this.labelClientAdditionalInfoTitle.Text = "Ваша додаткова інформація:";
			this.labelClientAdditionalInfoTitle.Click += new System.EventHandler(this.LabelClientAdditionalInfoTitle_Click);
			// 
			// labelDatePublication
			// 
			this.labelDatePublication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatePublication.BackColor = System.Drawing.Color.Transparent;
			this.labelDatePublication.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDatePublication.ForeColor = System.Drawing.Color.Black;
			this.labelDatePublication.Location = new System.Drawing.Point(898, 12);
			this.labelDatePublication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDatePublication.Name = "labelDatePublication";
			this.labelDatePublication.Size = new System.Drawing.Size(355, 25);
			this.labelDatePublication.TabIndex = 1;
			this.labelDatePublication.Text = "Дата публікації:";
			this.labelDatePublication.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// richTextBoxPositionDescription
			// 
			this.richTextBoxPositionDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPositionDescription.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPositionDescription.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxPositionDescription.Location = new System.Drawing.Point(18, 192);
			this.richTextBoxPositionDescription.MaxLength = 2048;
			this.richTextBoxPositionDescription.Name = "richTextBoxPositionDescription";
			this.richTextBoxPositionDescription.ReadOnly = true;
			this.richTextBoxPositionDescription.Size = new System.Drawing.Size(550, 275);
			this.richTextBoxPositionDescription.TabIndex = 5;
			this.richTextBoxPositionDescription.TabStop = false;
			this.richTextBoxPositionDescription.Text = "Опис";
			// 
			// richTextBoxAdditionalInfo
			// 
			this.richTextBoxAdditionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxAdditionalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxAdditionalInfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxAdditionalInfo.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxAdditionalInfo.Location = new System.Drawing.Point(681, 192);
			this.richTextBoxAdditionalInfo.MaxLength = 2048;
			this.richTextBoxAdditionalInfo.Name = "richTextBoxAdditionalInfo";
			this.richTextBoxAdditionalInfo.ReadOnly = true;
			this.richTextBoxAdditionalInfo.Size = new System.Drawing.Size(550, 275);
			this.richTextBoxAdditionalInfo.TabIndex = 7;
			this.richTextBoxAdditionalInfo.TabStop = false;
			this.richTextBoxAdditionalInfo.Text = "Додаткова інформація про вакансію";
			// 
			// richTextBoxSalary
			// 
			this.richTextBoxSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSalary.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxSalary.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxSalary.Location = new System.Drawing.Point(172, 72);
			this.richTextBoxSalary.MaxLength = 64;
			this.richTextBoxSalary.Multiline = false;
			this.richTextBoxSalary.Name = "richTextBoxSalary";
			this.richTextBoxSalary.ReadOnly = true;
			this.richTextBoxSalary.Size = new System.Drawing.Size(835, 40);
			this.richTextBoxSalary.TabIndex = 3;
			this.richTextBoxSalary.TabStop = false;
			this.richTextBoxSalary.Text = "Зарплата";
			// 
			// buttonSend
			// 
			this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSend.Animated = true;
			this.buttonSend.BackColor = System.Drawing.Color.Transparent;
			this.buttonSend.BorderRadius = 7;
			this.buttonSend.BorderThickness = 1;
			this.buttonSend.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonSend.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonSend.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonSend.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonSend.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonSend.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonSend.ForeColor = System.Drawing.Color.Black;
			this.buttonSend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonSend.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonSend.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonSend.Location = new System.Drawing.Point(1077, 693);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.PressedColor = System.Drawing.Color.White;
			this.buttonSend.PressedDepth = 20;
			this.buttonSend.Size = new System.Drawing.Size(175, 40);
			this.buttonSend.TabIndex = 11;
			this.buttonSend.TabStop = false;
			this.buttonSend.Text = "Відправити";
			this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
			// 
			// richTextBoxClientAdditionalInfo
			// 
			this.richTextBoxClientAdditionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.richTextBoxClientAdditionalInfo.Animated = true;
			this.richTextBoxClientAdditionalInfo.BackColor = System.Drawing.Color.Transparent;
			this.richTextBoxClientAdditionalInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.richTextBoxClientAdditionalInfo.BorderRadius = 12;
			this.richTextBoxClientAdditionalInfo.BorderThickness = 2;
			this.richTextBoxClientAdditionalInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.richTextBoxClientAdditionalInfo.DefaultText = "";
			this.richTextBoxClientAdditionalInfo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.richTextBoxClientAdditionalInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.richTextBoxClientAdditionalInfo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.richTextBoxClientAdditionalInfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxClientAdditionalInfo.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxClientAdditionalInfo.HoverState.BorderColor = System.Drawing.Color.Black;
			this.richTextBoxClientAdditionalInfo.Location = new System.Drawing.Point(18, 533);
			this.richTextBoxClientAdditionalInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.richTextBoxClientAdditionalInfo.MaxLength = 2048;
			this.richTextBoxClientAdditionalInfo.Multiline = true;
			this.richTextBoxClientAdditionalInfo.Name = "richTextBoxClientAdditionalInfo";
			this.richTextBoxClientAdditionalInfo.PasswordChar = '\0';
			this.richTextBoxClientAdditionalInfo.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.richTextBoxClientAdditionalInfo.PlaceholderText = "За потреби вкажіть додаткову інформацію";
			this.richTextBoxClientAdditionalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.richTextBoxClientAdditionalInfo.SelectedText = "";
			this.richTextBoxClientAdditionalInfo.Size = new System.Drawing.Size(700, 200);
			this.richTextBoxClientAdditionalInfo.TabIndex = 9;
			this.richTextBoxClientAdditionalInfo.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// buttonRequirements
			// 
			this.buttonRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRequirements.Animated = true;
			this.buttonRequirements.BackColor = System.Drawing.Color.Transparent;
			this.buttonRequirements.BorderRadius = 7;
			this.buttonRequirements.BorderThickness = 1;
			this.buttonRequirements.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRequirements.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonRequirements.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonRequirements.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonRequirements.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonRequirements.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonRequirements.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonRequirements.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonRequirements.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonRequirements.ForeColor = System.Drawing.Color.Black;
			this.buttonRequirements.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonRequirements.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonRequirements.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonRequirements.Location = new System.Drawing.Point(877, 693);
			this.buttonRequirements.Name = "buttonRequirements";
			this.buttonRequirements.PressedColor = System.Drawing.Color.White;
			this.buttonRequirements.PressedDepth = 20;
			this.buttonRequirements.Size = new System.Drawing.Size(175, 40);
			this.buttonRequirements.TabIndex = 10;
			this.buttonRequirements.TabStop = false;
			this.buttonRequirements.Text = "Вимоги";
			this.buttonRequirements.Visible = false;
			this.buttonRequirements.Click += new System.EventHandler(this.ButtonRequirements_Click);
			// 
			// labelPosition
			// 
			this.labelPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPosition.ForeColor = System.Drawing.Color.Black;
			this.labelPosition.Location = new System.Drawing.Point(12, 12);
			this.labelPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPosition.MaxLength = 2048;
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.ReadOnly = true;
			this.labelPosition.Size = new System.Drawing.Size(835, 40);
			this.labelPosition.TabIndex = 0;
			this.labelPosition.TabStop = false;
			this.labelPosition.Text = "Посада";
			// 
			// VacancyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 755);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.buttonRequirements);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.richTextBoxSalary);
			this.Controls.Add(this.richTextBoxAdditionalInfo);
			this.Controls.Add(this.richTextBoxPositionDescription);
			this.Controls.Add(this.labelDatePublication);
			this.Controls.Add(this.labelClientAdditionalInfoTitle);
			this.Controls.Add(this.labelAdditionalInfoTitle);
			this.Controls.Add(this.labelPositionDescriptionTitle);
			this.Controls.Add(this.labelSalaryTitle);
			this.Controls.Add(this.richTextBoxClientAdditionalInfo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "VacancyForm";
			this.Text = "Вакансія";
			this.Load += new System.EventHandler(this.VacancyForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSalaryTitle;
        private System.Windows.Forms.Label labelPositionDescriptionTitle;
        private System.Windows.Forms.Label labelAdditionalInfoTitle;
        private System.Windows.Forms.Label labelClientAdditionalInfoTitle;
        private System.Windows.Forms.Label labelDatePublication;
        private System.Windows.Forms.RichTextBox richTextBoxPositionDescription;
        private System.Windows.Forms.RichTextBox richTextBoxAdditionalInfo;
        private System.Windows.Forms.RichTextBox richTextBoxSalary;
		private Guna.UI2.WinForms.Guna2GradientButton buttonSend;
		private Guna.UI2.WinForms.Guna2TextBox richTextBoxClientAdditionalInfo;
		private Guna.UI2.WinForms.Guna2GradientButton buttonRequirements;
		private System.Windows.Forms.RichTextBox labelPosition;
	}
}