namespace RecruitmentServer.Forms
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
			this.labelSalaryTitle = new System.Windows.Forms.Label();
			this.labelContact = new System.Windows.Forms.Label();
			this.richTextBoxContact = new System.Windows.Forms.RichTextBox();
			this.labelFullName = new System.Windows.Forms.Label();
			this.labelCity = new System.Windows.Forms.Label();
			this.labelBirthday = new System.Windows.Forms.Label();
			this.labelDateEmployment = new System.Windows.Forms.Label();
			this.buttonChangePosition = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonChangeSalary = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonFire = new Guna.UI2.WinForms.Guna2GradientButton();
			this.textBoxPosition = new Guna.UI2.WinForms.Guna2TextBox();
			this.textBoxSalary = new Guna.UI2.WinForms.Guna2TextBox();
			this.SuspendLayout();
			// 
			// labelSalaryTitle
			// 
			this.labelSalaryTitle.AutoSize = true;
			this.labelSalaryTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelSalaryTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSalaryTitle.ForeColor = System.Drawing.Color.Black;
			this.labelSalaryTitle.Location = new System.Drawing.Point(12, 150);
			this.labelSalaryTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSalaryTitle.Name = "labelSalaryTitle";
			this.labelSalaryTitle.Size = new System.Drawing.Size(232, 29);
			this.labelSalaryTitle.TabIndex = 3;
			this.labelSalaryTitle.Text = "Зарплата(в грн.):";
			this.labelSalaryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelContact
			// 
			this.labelContact.AutoSize = true;
			this.labelContact.BackColor = System.Drawing.Color.Transparent;
			this.labelContact.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelContact.ForeColor = System.Drawing.Color.Black;
			this.labelContact.Location = new System.Drawing.Point(12, 280);
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
			this.richTextBoxContact.Location = new System.Drawing.Point(18, 325);
			this.richTextBoxContact.MaxLength = 2048;
			this.richTextBoxContact.Name = "richTextBoxContact";
			this.richTextBoxContact.ReadOnly = true;
			this.richTextBoxContact.Size = new System.Drawing.Size(500, 128);
			this.richTextBoxContact.TabIndex = 10;
			this.richTextBoxContact.TabStop = false;
			this.richTextBoxContact.Text = "Інформація";
			// 
			// labelFullName
			// 
			this.labelFullName.AutoEllipsis = true;
			this.labelFullName.BackColor = System.Drawing.Color.Transparent;
			this.labelFullName.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFullName.ForeColor = System.Drawing.Color.Black;
			this.labelFullName.Location = new System.Drawing.Point(0, 12);
			this.labelFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFullName.Name = "labelFullName";
			this.labelFullName.Size = new System.Drawing.Size(999, 40);
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
			this.labelCity.Location = new System.Drawing.Point(439, 150);
			this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCity.Name = "labelCity";
			this.labelCity.Size = new System.Drawing.Size(550, 35);
			this.labelCity.TabIndex = 6;
			this.labelCity.Text = "Місце проживання";
			this.labelCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelBirthday
			// 
			this.labelBirthday.AutoEllipsis = true;
			this.labelBirthday.BackColor = System.Drawing.Color.Transparent;
			this.labelBirthday.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBirthday.ForeColor = System.Drawing.Color.Black;
			this.labelBirthday.Location = new System.Drawing.Point(439, 200);
			this.labelBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelBirthday.Name = "labelBirthday";
			this.labelBirthday.Size = new System.Drawing.Size(550, 35);
			this.labelBirthday.TabIndex = 7;
			this.labelBirthday.Text = "Дата народження";
			this.labelBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDateEmployment
			// 
			this.labelDateEmployment.AutoEllipsis = true;
			this.labelDateEmployment.BackColor = System.Drawing.Color.Transparent;
			this.labelDateEmployment.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateEmployment.ForeColor = System.Drawing.Color.Black;
			this.labelDateEmployment.Location = new System.Drawing.Point(439, 250);
			this.labelDateEmployment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDateEmployment.Name = "labelDateEmployment";
			this.labelDateEmployment.Size = new System.Drawing.Size(550, 35);
			this.labelDateEmployment.TabIndex = 8;
			this.labelDateEmployment.Text = "Дата працевлаштування";
			this.labelDateEmployment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonChangePosition
			// 
			this.buttonChangePosition.Animated = true;
			this.buttonChangePosition.BackColor = System.Drawing.Color.Transparent;
			this.buttonChangePosition.BorderRadius = 7;
			this.buttonChangePosition.BorderThickness = 1;
			this.buttonChangePosition.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangePosition.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonChangePosition.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonChangePosition.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangePosition.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangePosition.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonChangePosition.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonChangePosition.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonChangePosition.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChangePosition.ForeColor = System.Drawing.Color.Black;
			this.buttonChangePosition.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonChangePosition.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonChangePosition.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonChangePosition.Location = new System.Drawing.Point(12, 118);
			this.buttonChangePosition.Name = "buttonChangePosition";
			this.buttonChangePosition.PressedColor = System.Drawing.Color.White;
			this.buttonChangePosition.PressedDepth = 20;
			this.buttonChangePosition.Size = new System.Drawing.Size(85, 25);
			this.buttonChangePosition.TabIndex = 2;
			this.buttonChangePosition.TabStop = false;
			this.buttonChangePosition.Text = "Змінити";
			this.buttonChangePosition.Visible = false;
			this.buttonChangePosition.Click += new System.EventHandler(this.ButtonChangePosition_Click);
			// 
			// buttonChangeSalary
			// 
			this.buttonChangeSalary.Animated = true;
			this.buttonChangeSalary.BackColor = System.Drawing.Color.Transparent;
			this.buttonChangeSalary.BorderRadius = 7;
			this.buttonChangeSalary.BorderThickness = 1;
			this.buttonChangeSalary.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeSalary.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonChangeSalary.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonChangeSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangeSalary.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonChangeSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonChangeSalary.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonChangeSalary.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonChangeSalary.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChangeSalary.ForeColor = System.Drawing.Color.Black;
			this.buttonChangeSalary.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonChangeSalary.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonChangeSalary.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonChangeSalary.Location = new System.Drawing.Point(12, 182);
			this.buttonChangeSalary.Name = "buttonChangeSalary";
			this.buttonChangeSalary.PressedColor = System.Drawing.Color.White;
			this.buttonChangeSalary.PressedDepth = 20;
			this.buttonChangeSalary.Size = new System.Drawing.Size(85, 25);
			this.buttonChangeSalary.TabIndex = 5;
			this.buttonChangeSalary.TabStop = false;
			this.buttonChangeSalary.Text = "Змінити";
			this.buttonChangeSalary.Visible = false;
			this.buttonChangeSalary.Click += new System.EventHandler(this.ButtonChangeSalary_Click);
			// 
			// buttonFire
			// 
			this.buttonFire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFire.Animated = true;
			this.buttonFire.BackColor = System.Drawing.Color.Transparent;
			this.buttonFire.BorderRadius = 7;
			this.buttonFire.BorderThickness = 1;
			this.buttonFire.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonFire.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonFire.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonFire.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonFire.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonFire.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonFire.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
			this.buttonFire.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonFire.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonFire.ForeColor = System.Drawing.Color.Black;
			this.buttonFire.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonFire.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
			this.buttonFire.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			this.buttonFire.Location = new System.Drawing.Point(788, 418);
			this.buttonFire.Name = "buttonFire";
			this.buttonFire.PressedColor = System.Drawing.Color.White;
			this.buttonFire.PressedDepth = 20;
			this.buttonFire.Size = new System.Drawing.Size(200, 35);
			this.buttonFire.TabIndex = 11;
			this.buttonFire.TabStop = false;
			this.buttonFire.Text = "Звільнити";
			this.buttonFire.Click += new System.EventHandler(this.ButtonFire_Click);
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.Animated = true;
			this.textBoxPosition.AutoScroll = true;
			this.textBoxPosition.BackColor = System.Drawing.Color.Transparent;
			this.textBoxPosition.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxPosition.BorderRadius = 10;
			this.textBoxPosition.BorderThickness = 2;
			this.textBoxPosition.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxPosition.DefaultText = "";
			this.textBoxPosition.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxPosition.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxPosition.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPosition.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxPosition.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPosition.ForeColor = System.Drawing.Color.Black;
			this.textBoxPosition.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxPosition.Location = new System.Drawing.Point(12, 72);
			this.textBoxPosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxPosition.MaxLength = 64;
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.PasswordChar = '\0';
			this.textBoxPosition.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxPosition.PlaceholderText = "";
			this.textBoxPosition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPosition.SelectedText = "";
			this.textBoxPosition.Size = new System.Drawing.Size(974, 40);
			this.textBoxPosition.TabIndex = 1;
			this.textBoxPosition.Tag = "";
			this.textBoxPosition.TextOffset = new System.Drawing.Point(3, 0);
			this.textBoxPosition.TextChanged += new System.EventHandler(this.TextBoxPosition_TextChanged);
			// 
			// textBoxSalary
			// 
			this.textBoxSalary.Animated = true;
			this.textBoxSalary.AutoScroll = true;
			this.textBoxSalary.BackColor = System.Drawing.Color.Transparent;
			this.textBoxSalary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxSalary.BorderRadius = 10;
			this.textBoxSalary.BorderThickness = 2;
			this.textBoxSalary.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxSalary.DefaultText = "";
			this.textBoxSalary.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxSalary.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxSalary.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSalary.ForeColor = System.Drawing.Color.Black;
			this.textBoxSalary.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxSalary.Location = new System.Drawing.Point(251, 145);
			this.textBoxSalary.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxSalary.MaxLength = 18;
			this.textBoxSalary.Name = "textBoxSalary";
			this.textBoxSalary.PasswordChar = '\0';
			this.textBoxSalary.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxSalary.PlaceholderText = "";
			this.textBoxSalary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxSalary.SelectedText = "";
			this.textBoxSalary.Size = new System.Drawing.Size(150, 40);
			this.textBoxSalary.TabIndex = 4;
			this.textBoxSalary.TextOffset = new System.Drawing.Point(3, 0);
			this.textBoxSalary.TextChanged += new System.EventHandler(this.TextBoxSalary_TextChanged);
			this.textBoxSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSalary_KeyPress);
			// 
			// EmployeeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 475);
			this.Controls.Add(this.textBoxSalary);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.buttonFire);
			this.Controls.Add(this.buttonChangeSalary);
			this.Controls.Add(this.buttonChangePosition);
			this.Controls.Add(this.labelDateEmployment);
			this.Controls.Add(this.labelBirthday);
			this.Controls.Add(this.labelCity);
			this.Controls.Add(this.labelFullName);
			this.Controls.Add(this.richTextBoxContact);
			this.Controls.Add(this.labelContact);
			this.Controls.Add(this.labelSalaryTitle);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EmployeeForm";
			this.Text = "Співробітник";
			this.Load += new System.EventHandler(this.EmployeeForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSalaryTitle;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.RichTextBox richTextBoxContact;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelDateEmployment;
		private Guna.UI2.WinForms.Guna2GradientButton buttonChangePosition;
		private Guna.UI2.WinForms.Guna2GradientButton buttonChangeSalary;
		private Guna.UI2.WinForms.Guna2GradientButton buttonFire;
		private Guna.UI2.WinForms.Guna2TextBox textBoxPosition;
		private Guna.UI2.WinForms.Guna2TextBox textBoxSalary;
	}
}