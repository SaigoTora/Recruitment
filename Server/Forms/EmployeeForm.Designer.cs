namespace ServerDB.Forms
{
    partial class EmployeeForm
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
			this.labelSalaryTitle = new System.Windows.Forms.Label();
			this.labelContact = new System.Windows.Forms.Label();
			this.richTextBoxContact = new System.Windows.Forms.RichTextBox();
			this.richTextBoxSalary = new System.Windows.Forms.RichTextBox();
			this.labelFullName = new System.Windows.Forms.Label();
			this.labelCity = new System.Windows.Forms.Label();
			this.labelBirthday = new System.Windows.Forms.Label();
			this.labelDateEmployment = new System.Windows.Forms.Label();
			this.buttonChangeSalary = new System.Windows.Forms.Button();
			this.buttonFire = new System.Windows.Forms.Button();
			this.richTextBoxPosition = new System.Windows.Forms.RichTextBox();
			this.buttonChangePosition = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelSalaryTitle
			// 
			this.labelSalaryTitle.AutoSize = true;
			this.labelSalaryTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelSalaryTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSalaryTitle.ForeColor = System.Drawing.Color.Black;
			this.labelSalaryTitle.Location = new System.Drawing.Point(12, 145);
			this.labelSalaryTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalaryTitle.Name = "labelSalaryTitle";
			this.labelSalaryTitle.Size = new System.Drawing.Size(232, 29);
			this.labelSalaryTitle.TabIndex = 3;
			this.labelSalaryTitle.Text = "Зарплата(в грн.):";
			// 
			// labelContact
			// 
			this.labelContact.AutoSize = true;
			this.labelContact.BackColor = System.Drawing.Color.Transparent;
			this.labelContact.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelContact.ForeColor = System.Drawing.Color.Black;
			this.labelContact.Location = new System.Drawing.Point(12, 284);
			this.labelContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelContact.Name = "labelContact";
			this.labelContact.Size = new System.Drawing.Size(334, 32);
			this.labelContact.TabIndex = 9;
			this.labelContact.Text = "Контактна інформація:";
			// 
			// richTextBoxContact
			// 
			this.richTextBoxContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxContact.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxContact.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxContact.Location = new System.Drawing.Point(18, 329);
			this.richTextBoxContact.MaxLength = 2048;
			this.richTextBoxContact.Name = "richTextBoxContact";
			this.richTextBoxContact.ReadOnly = true;
			this.richTextBoxContact.Size = new System.Drawing.Size(500, 120);
			this.richTextBoxContact.TabIndex = 10;
			this.richTextBoxContact.TabStop = false;
			this.richTextBoxContact.Text = "Інформація";
			// 
			// richTextBoxSalary
			// 
			this.richTextBoxSalary.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSalary.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxSalary.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxSalary.Location = new System.Drawing.Point(249, 145);
			this.richTextBoxSalary.MaxLength = 18;
			this.richTextBoxSalary.Multiline = false;
			this.richTextBoxSalary.Name = "richTextBoxSalary";
			this.richTextBoxSalary.Size = new System.Drawing.Size(375, 40);
			this.richTextBoxSalary.TabIndex = 4;
			this.richTextBoxSalary.Text = "Зарплата";
			this.richTextBoxSalary.TextChanged += new System.EventHandler(this.RichTextBoxSalary_TextChanged);
			// 
			// labelFullName
			// 
			this.labelFullName.AutoEllipsis = true;
			this.labelFullName.BackColor = System.Drawing.Color.Transparent;
			this.labelFullName.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFullName.ForeColor = System.Drawing.Color.Black;
			this.labelFullName.Location = new System.Drawing.Point(142, 10);
			this.labelFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFullName.Name = "labelFullName";
			this.labelFullName.Size = new System.Drawing.Size(900, 40);
			this.labelFullName.TabIndex = 0;
			this.labelFullName.Text = "ПІБ";
			this.labelFullName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelCity
			// 
			this.labelCity.AutoEllipsis = true;
			this.labelCity.BackColor = System.Drawing.Color.Transparent;
			this.labelCity.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCity.ForeColor = System.Drawing.Color.Black;
			this.labelCity.Location = new System.Drawing.Point(673, 130);
			this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCity.Name = "labelCity";
			this.labelCity.Size = new System.Drawing.Size(500, 40);
			this.labelCity.TabIndex = 6;
			this.labelCity.Text = "Місце проживання";
			this.labelCity.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelBirthday
			// 
			this.labelBirthday.AutoEllipsis = true;
			this.labelBirthday.BackColor = System.Drawing.Color.Transparent;
			this.labelBirthday.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBirthday.ForeColor = System.Drawing.Color.Black;
			this.labelBirthday.Location = new System.Drawing.Point(673, 190);
			this.labelBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelBirthday.Name = "labelBirthday";
			this.labelBirthday.Size = new System.Drawing.Size(500, 40);
			this.labelBirthday.TabIndex = 7;
			this.labelBirthday.Text = "Дата народження";
			this.labelBirthday.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelDateEmployment
			// 
			this.labelDateEmployment.AutoEllipsis = true;
			this.labelDateEmployment.BackColor = System.Drawing.Color.Transparent;
			this.labelDateEmployment.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateEmployment.ForeColor = System.Drawing.Color.Black;
			this.labelDateEmployment.Location = new System.Drawing.Point(673, 250);
			this.labelDateEmployment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDateEmployment.Name = "labelDateEmployment";
			this.labelDateEmployment.Size = new System.Drawing.Size(500, 40);
			this.labelDateEmployment.TabIndex = 8;
			this.labelDateEmployment.Text = "Дата працевлаштування";
			this.labelDateEmployment.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// buttonChangeSalary
			// 
			this.buttonChangeSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonChangeSalary.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChangeSalary.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChangeSalary.Location = new System.Drawing.Point(12, 177);
			this.buttonChangeSalary.Name = "buttonChangeSalary";
			this.buttonChangeSalary.Size = new System.Drawing.Size(85, 25);
			this.buttonChangeSalary.TabIndex = 5;
			this.buttonChangeSalary.Text = "Змінити";
			this.buttonChangeSalary.UseVisualStyleBackColor = false;
			this.buttonChangeSalary.Visible = false;
			this.buttonChangeSalary.Click += new System.EventHandler(this.ButtonChangeSalary_Click);
			// 
			// buttonFire
			// 
			this.buttonFire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(29)))), ((int)(((byte)(52)))));
			this.buttonFire.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFire.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonFire.Location = new System.Drawing.Point(967, 409);
			this.buttonFire.Name = "buttonFire";
			this.buttonFire.Size = new System.Drawing.Size(200, 35);
			this.buttonFire.TabIndex = 11;
			this.buttonFire.Text = "Звільнити";
			this.buttonFire.UseVisualStyleBackColor = false;
			this.buttonFire.Click += new System.EventHandler(this.ButtonFire_Click);
			// 
			// richTextBoxPosition
			// 
			this.richTextBoxPosition.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxPosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPosition.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPosition.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxPosition.Location = new System.Drawing.Point(12, 70);
			this.richTextBoxPosition.MaxLength = 64;
			this.richTextBoxPosition.Multiline = false;
			this.richTextBoxPosition.Name = "richTextBoxPosition";
			this.richTextBoxPosition.Size = new System.Drawing.Size(900, 40);
			this.richTextBoxPosition.TabIndex = 1;
			this.richTextBoxPosition.Text = "Посада";
			this.richTextBoxPosition.TextChanged += new System.EventHandler(this.RichTextBoxPosition_TextChanged);
			// 
			// buttonChangePosition
			// 
			this.buttonChangePosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonChangePosition.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChangePosition.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChangePosition.Location = new System.Drawing.Point(12, 116);
			this.buttonChangePosition.Name = "buttonChangePosition";
			this.buttonChangePosition.Size = new System.Drawing.Size(85, 25);
			this.buttonChangePosition.TabIndex = 2;
			this.buttonChangePosition.Text = "Змінити";
			this.buttonChangePosition.UseVisualStyleBackColor = false;
			this.buttonChangePosition.Visible = false;
			this.buttonChangePosition.Click += new System.EventHandler(this.ButtonChangePosition_Click);
			// 
			// EmployeeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 461);
			this.Controls.Add(this.buttonChangePosition);
			this.Controls.Add(this.richTextBoxPosition);
			this.Controls.Add(this.buttonFire);
			this.Controls.Add(this.buttonChangeSalary);
			this.Controls.Add(this.labelDateEmployment);
			this.Controls.Add(this.labelBirthday);
			this.Controls.Add(this.labelCity);
			this.Controls.Add(this.labelFullName);
			this.Controls.Add(this.richTextBoxSalary);
			this.Controls.Add(this.richTextBoxContact);
			this.Controls.Add(this.labelContact);
			this.Controls.Add(this.labelSalaryTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EmployeeForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Співробітник";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSalaryTitle;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.RichTextBox richTextBoxContact;
        private System.Windows.Forms.RichTextBox richTextBoxSalary;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelDateEmployment;
        private System.Windows.Forms.Button buttonChangeSalary;
        private System.Windows.Forms.Button buttonFire;
        private System.Windows.Forms.RichTextBox richTextBoxPosition;
        private System.Windows.Forms.Button buttonChangePosition;
    }
}