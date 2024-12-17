namespace RecruitmentServer.Forms
{
    partial class AssignmentForm
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
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelAssignment = new System.Windows.Forms.Panel();
			this.buttonVacancy = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonCandidate = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonApplication = new Guna.UI2.WinForms.Guna2GradientButton();
			this.labelScores = new System.Windows.Forms.Label();
			this.labelVacancy = new System.Windows.Forms.Label();
			this.labelCandidate = new System.Windows.Forms.Label();
			this.labelEmpty = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.flpMain.SuspendLayout();
			this.panelAssignment.SuspendLayout();
			this.SuspendLayout();
			// 
			// flpMain
			// 
			this.flpMain.AutoScroll = true;
			this.flpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
			this.flpMain.Controls.Add(this.panelAssignment);
			this.flpMain.Controls.Add(this.labelEmpty);
			this.flpMain.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flpMain.Location = new System.Drawing.Point(0, 87);
			this.flpMain.Margin = new System.Windows.Forms.Padding(0);
			this.flpMain.Name = "flpMain";
			this.flpMain.Size = new System.Drawing.Size(1264, 540);
			this.flpMain.TabIndex = 3;
			this.flpMain.Tag = "";
			// 
			// panelAssignment
			// 
			this.panelAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelAssignment.AutoSize = true;
			this.panelAssignment.BackColor = System.Drawing.Color.White;
			this.panelAssignment.Controls.Add(this.buttonVacancy);
			this.panelAssignment.Controls.Add(this.buttonCandidate);
			this.panelAssignment.Controls.Add(this.buttonApplication);
			this.panelAssignment.Controls.Add(this.labelScores);
			this.panelAssignment.Controls.Add(this.labelVacancy);
			this.panelAssignment.Controls.Add(this.labelCandidate);
			this.panelAssignment.Location = new System.Drawing.Point(0, 3);
			this.panelAssignment.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panelAssignment.Name = "panelAssignment";
			this.panelAssignment.Size = new System.Drawing.Size(1254, 168);
			this.panelAssignment.TabIndex = 0;
			this.panelAssignment.Tag = "";
			this.panelAssignment.Visible = false;
			// 
			// buttonVacancy
			// 
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
			this.buttonVacancy.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonVacancy.ForeColor = System.Drawing.Color.Black;
			this.buttonVacancy.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonVacancy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonVacancy.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonVacancy.Location = new System.Drawing.Point(556, 70);
			this.buttonVacancy.Name = "buttonVacancy";
			this.buttonVacancy.PressedColor = System.Drawing.Color.White;
			this.buttonVacancy.PressedDepth = 20;
			this.buttonVacancy.Size = new System.Drawing.Size(300, 35);
			this.buttonVacancy.TabIndex = 3;
			this.buttonVacancy.TabStop = false;
			this.buttonVacancy.Tag = "fixedPosition";
			this.buttonVacancy.Text = "Вакансія";
			// 
			// buttonCandidate
			// 
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
			this.buttonCandidate.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCandidate.ForeColor = System.Drawing.Color.Black;
			this.buttonCandidate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonCandidate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonCandidate.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonCandidate.Location = new System.Drawing.Point(18, 70);
			this.buttonCandidate.Name = "buttonCandidate";
			this.buttonCandidate.PressedColor = System.Drawing.Color.White;
			this.buttonCandidate.PressedDepth = 20;
			this.buttonCandidate.Size = new System.Drawing.Size(300, 35);
			this.buttonCandidate.TabIndex = 1;
			this.buttonCandidate.TabStop = false;
			this.buttonCandidate.Tag = "fixedPosition";
			this.buttonCandidate.Text = "Кандидат";
			// 
			// buttonApplication
			// 
			this.buttonApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
			this.buttonApplication.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonApplication.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonApplication.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold);
			this.buttonApplication.ForeColor = System.Drawing.Color.Black;
			this.buttonApplication.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonApplication.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonApplication.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonApplication.Location = new System.Drawing.Point(1000, 70);
			this.buttonApplication.Name = "buttonApplication";
			this.buttonApplication.PressedColor = System.Drawing.Color.White;
			this.buttonApplication.PressedDepth = 20;
			this.buttonApplication.Size = new System.Drawing.Size(175, 35);
			this.buttonApplication.TabIndex = 2;
			this.buttonApplication.TabStop = false;
			this.buttonApplication.Tag = "fixedPosition";
			this.buttonApplication.Text = "Заявка";
			// 
			// labelScores
			// 
			this.labelScores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelScores.BackColor = System.Drawing.Color.Transparent;
			this.labelScores.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScores.ForeColor = System.Drawing.Color.Black;
			this.labelScores.Location = new System.Drawing.Point(819, 134);
			this.labelScores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelScores.Name = "labelScores";
			this.labelScores.Size = new System.Drawing.Size(425, 32);
			this.labelScores.TabIndex = 5;
			this.labelScores.Tag = "fixedPosition";
			this.labelScores.Text = "Балів:";
			this.labelScores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelVacancy
			// 
			this.labelVacancy.BackColor = System.Drawing.Color.Transparent;
			this.labelVacancy.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVacancy.ForeColor = System.Drawing.Color.Black;
			this.labelVacancy.Location = new System.Drawing.Point(556, 12);
			this.labelVacancy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelVacancy.Name = "labelVacancy";
			this.labelVacancy.Size = new System.Drawing.Size(300, 32);
			this.labelVacancy.TabIndex = 2;
			this.labelVacancy.Tag = "fixedPosition";
			this.labelVacancy.Text = "Вакансія";
			this.labelVacancy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCandidate
			// 
			this.labelCandidate.BackColor = System.Drawing.Color.Transparent;
			this.labelCandidate.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCandidate.ForeColor = System.Drawing.Color.Black;
			this.labelCandidate.Location = new System.Drawing.Point(18, 12);
			this.labelCandidate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCandidate.Name = "labelCandidate";
			this.labelCandidate.Size = new System.Drawing.Size(300, 32);
			this.labelCandidate.TabIndex = 0;
			this.labelCandidate.Tag = "fixedPosition";
			this.labelCandidate.Text = "Кандидат";
			this.labelCandidate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelEmpty
			// 
			this.labelEmpty.AutoSize = true;
			this.labelEmpty.BackColor = System.Drawing.Color.Transparent;
			this.labelEmpty.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEmpty.ForeColor = System.Drawing.Color.Black;
			this.labelEmpty.Location = new System.Drawing.Point(2, 174);
			this.labelEmpty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelEmpty.Name = "labelEmpty";
			this.labelEmpty.Padding = new System.Windows.Forms.Padding(12);
			this.labelEmpty.Size = new System.Drawing.Size(723, 56);
			this.labelEmpty.TabIndex = 1;
			this.labelEmpty.Text = "Поки що немає заявок зі статусом \"В очікуванні\"";
			this.labelEmpty.Visible = false;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.AutoSize = true;
			this.labelTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.ForeColor = System.Drawing.Color.Black;
			this.labelTitle.Location = new System.Drawing.Point(12, 23);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(803, 32);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Рекомендований розподіл кандидатів та вакансій:";
			// 
			// AssignmentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 627);
			this.Controls.Add(this.flpMain);
			this.Controls.Add(this.labelTitle);
			this.Name = "AssignmentForm";
			this.ShowIcon = false;
			this.Text = "Призначення";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AssignmentForm_FormClosed);
			this.Load += new System.EventHandler(this.AssignmentForm_Load);
			this.flpMain.ResumeLayout(false);
			this.flpMain.PerformLayout();
			this.panelAssignment.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Panel panelAssignment;
        private System.Windows.Forms.Label labelCandidate;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVacancy;
        private System.Windows.Forms.Label labelScores;
        private System.Windows.Forms.Label labelEmpty;
		private Guna.UI2.WinForms.Guna2GradientButton buttonCandidate;
		private Guna.UI2.WinForms.Guna2GradientButton buttonVacancy;
		private Guna.UI2.WinForms.Guna2GradientButton buttonApplication;
	}
}