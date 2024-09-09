namespace ServerDB.Forms
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
			this.buttonApplication = new System.Windows.Forms.Button();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelAssignment = new System.Windows.Forms.Panel();
			this.labelScores = new System.Windows.Forms.Label();
			this.labelVacancy = new System.Windows.Forms.Label();
			this.buttonVacancy = new System.Windows.Forms.Button();
			this.buttonCandidate = new System.Windows.Forms.Button();
			this.labelCandidate = new System.Windows.Forms.Label();
			this.labelEmpty = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.flpMain.SuspendLayout();
			this.panelAssignment.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonApplication
			// 
			this.buttonApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonApplication.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApplication.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonApplication.Location = new System.Drawing.Point(948, 70);
			this.buttonApplication.Name = "buttonApplication";
			this.buttonApplication.Size = new System.Drawing.Size(175, 35);
			this.buttonApplication.TabIndex = 2;
			this.buttonApplication.Text = "Заявка";
			this.buttonApplication.UseVisualStyleBackColor = false;
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
			// 
			// panelAssignment
			// 
			this.panelAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelAssignment.AutoSize = true;
			this.panelAssignment.BackColor = System.Drawing.Color.White;
			this.panelAssignment.Controls.Add(this.labelScores);
			this.panelAssignment.Controls.Add(this.buttonApplication);
			this.panelAssignment.Controls.Add(this.labelVacancy);
			this.panelAssignment.Controls.Add(this.buttonVacancy);
			this.panelAssignment.Controls.Add(this.buttonCandidate);
			this.panelAssignment.Controls.Add(this.labelCandidate);
			this.panelAssignment.Location = new System.Drawing.Point(0, 3);
			this.panelAssignment.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panelAssignment.Name = "panelAssignment";
			this.panelAssignment.Size = new System.Drawing.Size(1254, 165);
			this.panelAssignment.TabIndex = 0;
			this.panelAssignment.Visible = false;
			// 
			// labelScores
			// 
			this.labelScores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelScores.BackColor = System.Drawing.Color.Transparent;
			this.labelScores.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScores.ForeColor = System.Drawing.Color.Black;
			this.labelScores.Location = new System.Drawing.Point(819, 131);
			this.labelScores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelScores.Name = "labelScores";
			this.labelScores.Size = new System.Drawing.Size(425, 32);
			this.labelScores.TabIndex = 5;
			this.labelScores.Text = "Балів:";
			this.labelScores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelVacancy
			// 
			this.labelVacancy.AutoSize = true;
			this.labelVacancy.BackColor = System.Drawing.Color.Transparent;
			this.labelVacancy.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVacancy.ForeColor = System.Drawing.Color.Black;
			this.labelVacancy.Location = new System.Drawing.Point(550, 12);
			this.labelVacancy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelVacancy.Name = "labelVacancy";
			this.labelVacancy.Size = new System.Drawing.Size(135, 32);
			this.labelVacancy.TabIndex = 2;
			this.labelVacancy.Text = "Вакансія";
			// 
			// buttonVacancy
			// 
			this.buttonVacancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonVacancy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonVacancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonVacancy.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonVacancy.Location = new System.Drawing.Point(556, 70);
			this.buttonVacancy.Name = "buttonVacancy";
			this.buttonVacancy.Size = new System.Drawing.Size(250, 35);
			this.buttonVacancy.TabIndex = 3;
			this.buttonVacancy.Text = "Вакансія";
			this.buttonVacancy.UseVisualStyleBackColor = false;
			// 
			// buttonCandidate
			// 
			this.buttonCandidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonCandidate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCandidate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCandidate.Location = new System.Drawing.Point(18, 70);
			this.buttonCandidate.Name = "buttonCandidate";
			this.buttonCandidate.Size = new System.Drawing.Size(250, 35);
			this.buttonCandidate.TabIndex = 1;
			this.buttonCandidate.Text = "Кандидат";
			this.buttonCandidate.UseVisualStyleBackColor = false;
			// 
			// labelCandidate
			// 
			this.labelCandidate.AutoSize = true;
			this.labelCandidate.BackColor = System.Drawing.Color.Transparent;
			this.labelCandidate.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCandidate.ForeColor = System.Drawing.Color.Black;
			this.labelCandidate.Location = new System.Drawing.Point(12, 12);
			this.labelCandidate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCandidate.Name = "labelCandidate";
			this.labelCandidate.Size = new System.Drawing.Size(158, 32);
			this.labelCandidate.TabIndex = 0;
			this.labelCandidate.Text = "Кандидат:";
			// 
			// labelEmpty
			// 
			this.labelEmpty.AutoSize = true;
			this.labelEmpty.BackColor = System.Drawing.Color.Transparent;
			this.labelEmpty.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEmpty.ForeColor = System.Drawing.Color.Black;
			this.labelEmpty.Location = new System.Drawing.Point(2, 171);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AssignmentForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Призначення";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AssignmentForm_FormClosed);
			this.Load += new System.EventHandler(this.AssignmentForm_Load);
			this.flpMain.ResumeLayout(false);
			this.flpMain.PerformLayout();
			this.panelAssignment.ResumeLayout(false);
			this.panelAssignment.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonApplication;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Panel panelAssignment;
        private System.Windows.Forms.Button buttonCandidate;
        private System.Windows.Forms.Label labelCandidate;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonVacancy;
        private System.Windows.Forms.Label labelVacancy;
        private System.Windows.Forms.Label labelScores;
        private System.Windows.Forms.Label labelEmpty;
    }
}