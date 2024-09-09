namespace ServerDB.Forms
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
			this.buttonCreate = new System.Windows.Forms.Button();
			this.richTextBoxPosition = new System.Windows.Forms.RichTextBox();
			this.buttonRequirement = new System.Windows.Forms.Button();
			this.labelApplicationCount = new System.Windows.Forms.Label();
			this.labelDatePublication = new System.Windows.Forms.Label();
			this.labelRelevance = new System.Windows.Forms.Label();
			this.richTextBoxAdditionalInfo = new System.Windows.Forms.RichTextBox();
			this.richTextBoxPositionDescription = new System.Windows.Forms.RichTextBox();
			this.labelAdditionalInfoTitle = new System.Windows.Forms.Label();
			this.labelPositionDescriptionTitle = new System.Windows.Forms.Label();
			this.richTextBoxSalary = new System.Windows.Forms.RichTextBox();
			this.labelSalaryTitle = new System.Windows.Forms.Label();
			this.buttonPoints = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.labelPosition = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCreate
			// 
			this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreate.AutoSize = true;
			this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonCreate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCreate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCreate.Location = new System.Drawing.Point(1072, 570);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(175, 40);
			this.buttonCreate.TabIndex = 14;
			this.buttonCreate.Text = "Створити";
			this.buttonCreate.UseVisualStyleBackColor = false;
			this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// richTextBoxPosition
			// 
			this.richTextBoxPosition.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxPosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPosition.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPosition.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxPosition.Location = new System.Drawing.Point(142, 12);
			this.richTextBoxPosition.MaxLength = 64;
			this.richTextBoxPosition.Multiline = false;
			this.richTextBoxPosition.Name = "richTextBoxPosition";
			this.richTextBoxPosition.ReadOnly = true;
			this.richTextBoxPosition.Size = new System.Drawing.Size(942, 40);
			this.richTextBoxPosition.TabIndex = 1;
			this.richTextBoxPosition.TabStop = false;
			this.richTextBoxPosition.Text = "";
			// 
			// buttonRequirement
			// 
			this.buttonRequirement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRequirement.AutoSize = true;
			this.buttonRequirement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonRequirement.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRequirement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRequirement.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonRequirement.Location = new System.Drawing.Point(17, 570);
			this.buttonRequirement.Name = "buttonRequirement";
			this.buttonRequirement.Size = new System.Drawing.Size(175, 40);
			this.buttonRequirement.TabIndex = 11;
			this.buttonRequirement.Text = "Вимоги";
			this.buttonRequirement.UseVisualStyleBackColor = false;
			// 
			// labelApplicationCount
			// 
			this.labelApplicationCount.AutoSize = true;
			this.labelApplicationCount.BackColor = System.Drawing.Color.Transparent;
			this.labelApplicationCount.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelApplicationCount.ForeColor = System.Drawing.Color.Black;
			this.labelApplicationCount.Location = new System.Drawing.Point(12, 132);
			this.labelApplicationCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelApplicationCount.Name = "labelApplicationCount";
			this.labelApplicationCount.Size = new System.Drawing.Size(216, 29);
			this.labelApplicationCount.TabIndex = 4;
			this.labelApplicationCount.Text = "Кількість заявок";
			// 
			// labelDatePublication
			// 
			this.labelDatePublication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatePublication.BackColor = System.Drawing.Color.Transparent;
			this.labelDatePublication.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDatePublication.ForeColor = System.Drawing.Color.Black;
			this.labelDatePublication.Location = new System.Drawing.Point(752, 132);
			this.labelDatePublication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDatePublication.Name = "labelDatePublication";
			this.labelDatePublication.Size = new System.Drawing.Size(501, 25);
			this.labelDatePublication.TabIndex = 6;
			this.labelDatePublication.Text = "Дата публікації:";
			this.labelDatePublication.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelRelevance
			// 
			this.labelRelevance.AutoSize = true;
			this.labelRelevance.BackColor = System.Drawing.Color.Transparent;
			this.labelRelevance.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRelevance.ForeColor = System.Drawing.Color.Black;
			this.labelRelevance.Location = new System.Drawing.Point(12, 192);
			this.labelRelevance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelRelevance.Name = "labelRelevance";
			this.labelRelevance.Size = new System.Drawing.Size(172, 29);
			this.labelRelevance.TabIndex = 5;
			this.labelRelevance.Text = "Актуальність";
			// 
			// richTextBoxAdditionalInfo
			// 
			this.richTextBoxAdditionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxAdditionalInfo.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxAdditionalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxAdditionalInfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxAdditionalInfo.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxAdditionalInfo.Location = new System.Drawing.Point(727, 340);
			this.richTextBoxAdditionalInfo.MaxLength = 2048;
			this.richTextBoxAdditionalInfo.Name = "richTextBoxAdditionalInfo";
			this.richTextBoxAdditionalInfo.ReadOnly = true;
			this.richTextBoxAdditionalInfo.Size = new System.Drawing.Size(525, 175);
			this.richTextBoxAdditionalInfo.TabIndex = 10;
			this.richTextBoxAdditionalInfo.TabStop = false;
			this.richTextBoxAdditionalInfo.Text = "";
			// 
			// richTextBoxPositionDescription
			// 
			this.richTextBoxPositionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.richTextBoxPositionDescription.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxPositionDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPositionDescription.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPositionDescription.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxPositionDescription.Location = new System.Drawing.Point(12, 340);
			this.richTextBoxPositionDescription.MaxLength = 2048;
			this.richTextBoxPositionDescription.Name = "richTextBoxPositionDescription";
			this.richTextBoxPositionDescription.ReadOnly = true;
			this.richTextBoxPositionDescription.Size = new System.Drawing.Size(500, 175);
			this.richTextBoxPositionDescription.TabIndex = 8;
			this.richTextBoxPositionDescription.TabStop = false;
			this.richTextBoxPositionDescription.Text = "";
			// 
			// labelAdditionalInfoTitle
			// 
			this.labelAdditionalInfoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAdditionalInfoTitle.AutoSize = true;
			this.labelAdditionalInfoTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelAdditionalInfoTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAdditionalInfoTitle.ForeColor = System.Drawing.Color.Black;
			this.labelAdditionalInfoTitle.Location = new System.Drawing.Point(721, 300);
			this.labelAdditionalInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAdditionalInfoTitle.Name = "labelAdditionalInfoTitle";
			this.labelAdditionalInfoTitle.Size = new System.Drawing.Size(532, 32);
			this.labelAdditionalInfoTitle.TabIndex = 9;
			this.labelAdditionalInfoTitle.Text = "Додаткова інформація про вакансію:";
			// 
			// labelPositionDescriptionTitle
			// 
			this.labelPositionDescriptionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelPositionDescriptionTitle.AutoSize = true;
			this.labelPositionDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelPositionDescriptionTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPositionDescriptionTitle.ForeColor = System.Drawing.Color.Black;
			this.labelPositionDescriptionTitle.Location = new System.Drawing.Point(12, 300);
			this.labelPositionDescriptionTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPositionDescriptionTitle.Name = "labelPositionDescriptionTitle";
			this.labelPositionDescriptionTitle.Size = new System.Drawing.Size(202, 32);
			this.labelPositionDescriptionTitle.TabIndex = 7;
			this.labelPositionDescriptionTitle.Text = "Опис посади:";
			// 
			// richTextBoxSalary
			// 
			this.richTextBoxSalary.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSalary.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxSalary.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxSalary.Location = new System.Drawing.Point(249, 72);
			this.richTextBoxSalary.MaxLength = 64;
			this.richTextBoxSalary.Multiline = false;
			this.richTextBoxSalary.Name = "richTextBoxSalary";
			this.richTextBoxSalary.ReadOnly = true;
			this.richTextBoxSalary.Size = new System.Drawing.Size(835, 40);
			this.richTextBoxSalary.TabIndex = 3;
			this.richTextBoxSalary.TabStop = false;
			this.richTextBoxSalary.Text = "";
			// 
			// labelSalaryTitle
			// 
			this.labelSalaryTitle.AutoSize = true;
			this.labelSalaryTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelSalaryTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSalaryTitle.ForeColor = System.Drawing.Color.Black;
			this.labelSalaryTitle.Location = new System.Drawing.Point(12, 72);
			this.labelSalaryTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalaryTitle.Name = "labelSalaryTitle";
			this.labelSalaryTitle.Size = new System.Drawing.Size(232, 29);
			this.labelSalaryTitle.TabIndex = 2;
			this.labelSalaryTitle.Text = "Зарплата(в грн.):";
			// 
			// buttonPoints
			// 
			this.buttonPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPoints.AutoSize = true;
			this.buttonPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonPoints.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPoints.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPoints.Location = new System.Drawing.Point(250, 570);
			this.buttonPoints.Name = "buttonPoints";
			this.buttonPoints.Size = new System.Drawing.Size(175, 40);
			this.buttonPoints.TabIndex = 12;
			this.buttonPoints.Text = "Бали";
			this.buttonPoints.UseVisualStyleBackColor = false;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.AutoSize = true;
			this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(29)))), ((int)(((byte)(52)))));
			this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDelete.Location = new System.Drawing.Point(1072, 570);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(175, 40);
			this.buttonDelete.TabIndex = 13;
			this.buttonDelete.Text = "Видалити";
			this.buttonDelete.UseVisualStyleBackColor = false;
			this.buttonDelete.Visible = false;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.BackColor = System.Drawing.Color.Transparent;
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPosition.ForeColor = System.Drawing.Color.Black;
			this.labelPosition.Location = new System.Drawing.Point(12, 12);
			this.labelPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(125, 32);
			this.labelPosition.TabIndex = 0;
			this.labelPosition.Text = "Посада:";
			// 
			// VacancyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 627);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonPoints);
			this.Controls.Add(this.richTextBoxPosition);
			this.Controls.Add(this.buttonRequirement);
			this.Controls.Add(this.labelApplicationCount);
			this.Controls.Add(this.labelDatePublication);
			this.Controls.Add(this.labelRelevance);
			this.Controls.Add(this.richTextBoxAdditionalInfo);
			this.Controls.Add(this.richTextBoxPositionDescription);
			this.Controls.Add(this.labelAdditionalInfoTitle);
			this.Controls.Add(this.labelPositionDescriptionTitle);
			this.Controls.Add(this.richTextBoxSalary);
			this.Controls.Add(this.labelSalaryTitle);
			this.Controls.Add(this.buttonCreate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VacancyForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вакансія";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VacancyForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.RichTextBox richTextBoxPosition;
        private System.Windows.Forms.Button buttonRequirement;
        private System.Windows.Forms.Label labelApplicationCount;
        private System.Windows.Forms.Label labelDatePublication;
        private System.Windows.Forms.Label labelRelevance;
        private System.Windows.Forms.RichTextBox richTextBoxAdditionalInfo;
        private System.Windows.Forms.RichTextBox richTextBoxPositionDescription;
        private System.Windows.Forms.Label labelAdditionalInfoTitle;
        private System.Windows.Forms.Label labelPositionDescriptionTitle;
        private System.Windows.Forms.RichTextBox richTextBoxSalary;
        private System.Windows.Forms.Label labelSalaryTitle;
        private System.Windows.Forms.Button buttonPoints;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelPosition;
    }
}