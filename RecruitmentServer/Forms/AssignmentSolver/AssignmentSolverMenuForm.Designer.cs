namespace RecruitmentServer.Forms.AssignmentSolver
{
	partial class AssignmentSolverMenuForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignmentSolverMenuForm));
			this.labelTitle = new System.Windows.Forms.Label();
			this.buttonHungarianSolver = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonAuctionSolver = new Guna.UI2.WinForms.Guna2GradientButton();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.ForeColor = System.Drawing.Color.Black;
			this.labelTitle.Location = new System.Drawing.Point(11, 9);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(778, 42);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Виберіть метод вирішення задачі про призначення:";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// buttonHungarianSolver
			// 
			this.buttonHungarianSolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonHungarianSolver.Animated = true;
			this.buttonHungarianSolver.BackColor = System.Drawing.Color.Transparent;
			this.buttonHungarianSolver.BorderRadius = 7;
			this.buttonHungarianSolver.BorderThickness = 1;
			this.buttonHungarianSolver.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonHungarianSolver.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonHungarianSolver.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonHungarianSolver.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonHungarianSolver.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonHungarianSolver.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonHungarianSolver.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonHungarianSolver.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonHungarianSolver.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonHungarianSolver.ForeColor = System.Drawing.Color.Black;
			this.buttonHungarianSolver.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonHungarianSolver.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonHungarianSolver.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonHungarianSolver.Location = new System.Drawing.Point(102, 82);
			this.buttonHungarianSolver.Name = "buttonHungarianSolver";
			this.buttonHungarianSolver.PressedColor = System.Drawing.Color.White;
			this.buttonHungarianSolver.PressedDepth = 20;
			this.buttonHungarianSolver.Size = new System.Drawing.Size(250, 40);
			this.buttonHungarianSolver.TabIndex = 1;
			this.buttonHungarianSolver.TabStop = false;
			this.buttonHungarianSolver.Text = "Угорський алгоритм";
			this.buttonHungarianSolver.Click += new System.EventHandler(this.ButtonHungarianSolver_Click);
			// 
			// buttonAuctionSolver
			// 
			this.buttonAuctionSolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAuctionSolver.Animated = true;
			this.buttonAuctionSolver.BackColor = System.Drawing.Color.Transparent;
			this.buttonAuctionSolver.BorderRadius = 7;
			this.buttonAuctionSolver.BorderThickness = 1;
			this.buttonAuctionSolver.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAuctionSolver.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonAuctionSolver.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonAuctionSolver.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonAuctionSolver.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonAuctionSolver.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonAuctionSolver.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
			this.buttonAuctionSolver.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(60)))));
			this.buttonAuctionSolver.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonAuctionSolver.ForeColor = System.Drawing.Color.Black;
			this.buttonAuctionSolver.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonAuctionSolver.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(80)))));
			this.buttonAuctionSolver.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(100)))));
			this.buttonAuctionSolver.Location = new System.Drawing.Point(448, 82);
			this.buttonAuctionSolver.Name = "buttonAuctionSolver";
			this.buttonAuctionSolver.PressedColor = System.Drawing.Color.White;
			this.buttonAuctionSolver.PressedDepth = 20;
			this.buttonAuctionSolver.Size = new System.Drawing.Size(250, 40);
			this.buttonAuctionSolver.TabIndex = 2;
			this.buttonAuctionSolver.TabStop = false;
			this.buttonAuctionSolver.Text = "Алгоритм аукціону";
			this.buttonAuctionSolver.Click += new System.EventHandler(this.ButtonAuctionSolver_Click);
			// 
			// AssignmentSolverMenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonAuctionSolver);
			this.Controls.Add(this.buttonHungarianSolver);
			this.Controls.Add(this.labelTitle);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AssignmentSolverMenuForm";
			this.Text = "AssignmentSolverMenu";
			this.Load += new System.EventHandler(this.AssignmentSolverMenu_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private Guna.UI2.WinForms.Guna2GradientButton buttonHungarianSolver;
		private Guna.UI2.WinForms.Guna2GradientButton buttonAuctionSolver;
	}
}