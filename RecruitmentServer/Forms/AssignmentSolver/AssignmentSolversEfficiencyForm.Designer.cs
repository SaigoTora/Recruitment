namespace RecruitmentServer.Forms.AssignmentSolver
{
	partial class AssignmentSolversEfficiencyForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignmentSolversEfficiencyForm));
			this.buttonStart = new Guna.UI2.WinForms.Guna2GradientButton();
			this.labelCandidateCount = new System.Windows.Forms.Label();
			this.NUDCandidateCount = new System.Windows.Forms.NumericUpDown();
			this.NUDVacancyCount = new System.Windows.Forms.NumericUpDown();
			this.labelVacancyCount = new System.Windows.Forms.Label();
			this.NUDMaxPoints = new System.Windows.Forms.NumericUpDown();
			this.labelMaxPoints = new System.Windows.Forms.Label();
			this.groupBoxAllSubmitted = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelAllSubmittedYes = new System.Windows.Forms.Label();
			this.labelAllSubmittedNo = new System.Windows.Forms.Label();
			this.radioButtonAllSubmittedYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonAllSubmittedNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.labelAllSubmitted = new System.Windows.Forms.Label();
			this.groupBoxFindMax = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelFindMaxYes = new System.Windows.Forms.Label();
			this.labelFindMaxNo = new System.Windows.Forms.Label();
			this.radioButtonFindMaxYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonFindMaxNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.labelFindMax = new System.Windows.Forms.Label();
			this.labelHungarianResult = new System.Windows.Forms.Label();
			this.labelResults = new System.Windows.Forms.Label();
			this.labelAuctionResult = new System.Windows.Forms.Label();
			this.labelHungarianTime = new System.Windows.Forms.Label();
			this.labelHungarianMemory = new System.Windows.Forms.Label();
			this.labelAuctionMemory = new System.Windows.Forms.Label();
			this.labelAuctionTime = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.NUDCandidateCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDVacancyCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDMaxPoints)).BeginInit();
			this.groupBoxAllSubmitted.SuspendLayout();
			this.groupBoxFindMax.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Animated = true;
			this.buttonStart.BackColor = System.Drawing.Color.Transparent;
			this.buttonStart.BorderRadius = 7;
			this.buttonStart.BorderThickness = 1;
			this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonStart.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonStart.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonStart.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonStart.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonStart.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonStart.ForeColor = System.Drawing.Color.Black;
			this.buttonStart.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonStart.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonStart.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonStart.Location = new System.Drawing.Point(1023, 538);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.PressedColor = System.Drawing.Color.White;
			this.buttonStart.PressedDepth = 20;
			this.buttonStart.Size = new System.Drawing.Size(175, 40);
			this.buttonStart.TabIndex = 17;
			this.buttonStart.TabStop = false;
			this.buttonStart.Text = "Запуск";
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// labelCandidateCount
			// 
			this.labelCandidateCount.AutoSize = true;
			this.labelCandidateCount.BackColor = System.Drawing.Color.Transparent;
			this.labelCandidateCount.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelCandidateCount.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCandidateCount.ForeColor = System.Drawing.Color.Black;
			this.labelCandidateCount.Location = new System.Drawing.Point(12, 85);
			this.labelCandidateCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCandidateCount.Name = "labelCandidateCount";
			this.labelCandidateCount.Size = new System.Drawing.Size(311, 32);
			this.labelCandidateCount.TabIndex = 2;
			this.labelCandidateCount.Text = "Кількість кандидатів:";
			this.labelCandidateCount.Click += new System.EventHandler(this.LabelCandidateCount_Click);
			// 
			// NUDCandidateCount
			// 
			this.NUDCandidateCount.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDCandidateCount.ForeColor = System.Drawing.Color.Black;
			this.NUDCandidateCount.Location = new System.Drawing.Point(328, 83);
			this.NUDCandidateCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.NUDCandidateCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NUDCandidateCount.Name = "NUDCandidateCount";
			this.NUDCandidateCount.Size = new System.Drawing.Size(110, 36);
			this.NUDCandidateCount.TabIndex = 3;
			this.NUDCandidateCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NUDCandidateCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDCandidateCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUD_KeyDown);
			// 
			// NUDVacancyCount
			// 
			this.NUDVacancyCount.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDVacancyCount.ForeColor = System.Drawing.Color.Black;
			this.NUDVacancyCount.Location = new System.Drawing.Point(328, 23);
			this.NUDVacancyCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.NUDVacancyCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NUDVacancyCount.Name = "NUDVacancyCount";
			this.NUDVacancyCount.Size = new System.Drawing.Size(110, 36);
			this.NUDVacancyCount.TabIndex = 1;
			this.NUDVacancyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NUDVacancyCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDVacancyCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUD_KeyDown);
			// 
			// labelVacancyCount
			// 
			this.labelVacancyCount.AutoSize = true;
			this.labelVacancyCount.BackColor = System.Drawing.Color.Transparent;
			this.labelVacancyCount.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelVacancyCount.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVacancyCount.ForeColor = System.Drawing.Color.Black;
			this.labelVacancyCount.Location = new System.Drawing.Point(12, 25);
			this.labelVacancyCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelVacancyCount.Name = "labelVacancyCount";
			this.labelVacancyCount.Size = new System.Drawing.Size(278, 32);
			this.labelVacancyCount.TabIndex = 0;
			this.labelVacancyCount.Text = "Кількість вакансій:";
			this.labelVacancyCount.Click += new System.EventHandler(this.LabelVacancyCount_Click);
			// 
			// NUDMaxPoints
			// 
			this.NUDMaxPoints.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDMaxPoints.ForeColor = System.Drawing.Color.Black;
			this.NUDMaxPoints.Location = new System.Drawing.Point(328, 143);
			this.NUDMaxPoints.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.NUDMaxPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NUDMaxPoints.Name = "NUDMaxPoints";
			this.NUDMaxPoints.Size = new System.Drawing.Size(110, 36);
			this.NUDMaxPoints.TabIndex = 5;
			this.NUDMaxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NUDMaxPoints.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.NUDMaxPoints.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUD_KeyDown);
			// 
			// labelMaxPoints
			// 
			this.labelMaxPoints.AutoSize = true;
			this.labelMaxPoints.BackColor = System.Drawing.Color.Transparent;
			this.labelMaxPoints.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelMaxPoints.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMaxPoints.ForeColor = System.Drawing.Color.Black;
			this.labelMaxPoints.Location = new System.Drawing.Point(12, 145);
			this.labelMaxPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelMaxPoints.Name = "labelMaxPoints";
			this.labelMaxPoints.Size = new System.Drawing.Size(279, 32);
			this.labelMaxPoints.TabIndex = 4;
			this.labelMaxPoints.Text = "Макс. кільк. балів:";
			this.labelMaxPoints.Click += new System.EventHandler(this.LabelMaxPoints_Click);
			// 
			// groupBoxAllSubmitted
			// 
			this.groupBoxAllSubmitted.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxAllSubmitted.Controls.Add(this.labelAllSubmittedYes);
			this.groupBoxAllSubmitted.Controls.Add(this.labelAllSubmittedNo);
			this.groupBoxAllSubmitted.Controls.Add(this.radioButtonAllSubmittedYes);
			this.groupBoxAllSubmitted.Controls.Add(this.radioButtonAllSubmittedNo);
			this.groupBoxAllSubmitted.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxAllSubmitted.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxAllSubmitted.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxAllSubmitted.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxAllSubmitted.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxAllSubmitted.Location = new System.Drawing.Point(990, 25);
			this.groupBoxAllSubmitted.Name = "groupBoxAllSubmitted";
			this.groupBoxAllSubmitted.Size = new System.Drawing.Size(180, 33);
			this.groupBoxAllSubmitted.TabIndex = 7;
			this.groupBoxAllSubmitted.Tag = "needToMoveParentDown";
			this.groupBoxAllSubmitted.Text = "guna2GroupBox1";
			// 
			// labelAllSubmittedYes
			// 
			this.labelAllSubmittedYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAllSubmittedYes.AutoSize = true;
			this.labelAllSubmittedYes.BackColor = System.Drawing.Color.Transparent;
			this.labelAllSubmittedYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelAllSubmittedYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelAllSubmittedYes.ForeColor = System.Drawing.Color.Black;
			this.labelAllSubmittedYes.Location = new System.Drawing.Point(100, 4);
			this.labelAllSubmittedYes.Name = "labelAllSubmittedYes";
			this.labelAllSubmittedYes.Size = new System.Drawing.Size(50, 25);
			this.labelAllSubmittedYes.TabIndex = 2;
			this.labelAllSubmittedYes.Tag = "fixedPosition";
			this.labelAllSubmittedYes.Text = "Так";
			this.labelAllSubmittedYes.Click += new System.EventHandler(this.LabelAllSubmittedYes_Click);
			// 
			// labelAllSubmittedNo
			// 
			this.labelAllSubmittedNo.AutoSize = true;
			this.labelAllSubmittedNo.BackColor = System.Drawing.Color.Transparent;
			this.labelAllSubmittedNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelAllSubmittedNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelAllSubmittedNo.ForeColor = System.Drawing.Color.Black;
			this.labelAllSubmittedNo.Location = new System.Drawing.Point(4, 4);
			this.labelAllSubmittedNo.Name = "labelAllSubmittedNo";
			this.labelAllSubmittedNo.Size = new System.Drawing.Size(34, 25);
			this.labelAllSubmittedNo.TabIndex = 0;
			this.labelAllSubmittedNo.Tag = "fixedPosition";
			this.labelAllSubmittedNo.Text = "Ні";
			this.labelAllSubmittedNo.Click += new System.EventHandler(this.LabelAllSubmittedNo_Click);
			// 
			// radioButtonAllSubmittedYes
			// 
			this.radioButtonAllSubmittedYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAllSubmittedYes.Animated = true;
			this.radioButtonAllSubmittedYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonAllSubmittedYes.Checked = true;
			this.radioButtonAllSubmittedYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonAllSubmittedYes.CheckedState.BorderThickness = 2;
			this.radioButtonAllSubmittedYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonAllSubmittedYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonAllSubmittedYes.CheckedState.InnerOffset = 1;
			this.radioButtonAllSubmittedYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonAllSubmittedYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonAllSubmittedYes.Name = "radioButtonAllSubmittedYes";
			this.radioButtonAllSubmittedYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonAllSubmittedYes.ShadowDecoration.Depth = 40;
			this.radioButtonAllSubmittedYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonAllSubmittedYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonAllSubmittedYes.TabIndex = 3;
			this.radioButtonAllSubmittedYes.Tag = "fixedPosition";
			this.radioButtonAllSubmittedYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonAllSubmittedYes.UncheckedState.BorderThickness = 2;
			this.radioButtonAllSubmittedYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonAllSubmittedYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonAllSubmittedNo
			// 
			this.radioButtonAllSubmittedNo.Animated = true;
			this.radioButtonAllSubmittedNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonAllSubmittedNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonAllSubmittedNo.CheckedState.BorderThickness = 2;
			this.radioButtonAllSubmittedNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonAllSubmittedNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonAllSubmittedNo.CheckedState.InnerOffset = 1;
			this.radioButtonAllSubmittedNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonAllSubmittedNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonAllSubmittedNo.Name = "radioButtonAllSubmittedNo";
			this.radioButtonAllSubmittedNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonAllSubmittedNo.ShadowDecoration.Depth = 40;
			this.radioButtonAllSubmittedNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonAllSubmittedNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonAllSubmittedNo.TabIndex = 1;
			this.radioButtonAllSubmittedNo.Tag = "fixedPosition";
			this.radioButtonAllSubmittedNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonAllSubmittedNo.UncheckedState.BorderThickness = 2;
			this.radioButtonAllSubmittedNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonAllSubmittedNo.UncheckedState.InnerOffset = 1;
			// 
			// labelAllSubmitted
			// 
			this.labelAllSubmitted.AutoSize = true;
			this.labelAllSubmitted.BackColor = System.Drawing.Color.Transparent;
			this.labelAllSubmitted.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAllSubmitted.ForeColor = System.Drawing.Color.Black;
			this.labelAllSubmitted.Location = new System.Drawing.Point(525, 25);
			this.labelAllSubmitted.Name = "labelAllSubmitted";
			this.labelAllSubmitted.Size = new System.Drawing.Size(437, 32);
			this.labelAllSubmitted.TabIndex = 6;
			this.labelAllSubmitted.Text = "Всі кандидати подали заявки:";
			// 
			// groupBoxFindMax
			// 
			this.groupBoxFindMax.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxFindMax.Controls.Add(this.labelFindMaxYes);
			this.groupBoxFindMax.Controls.Add(this.labelFindMaxNo);
			this.groupBoxFindMax.Controls.Add(this.radioButtonFindMaxYes);
			this.groupBoxFindMax.Controls.Add(this.radioButtonFindMaxNo);
			this.groupBoxFindMax.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxFindMax.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxFindMax.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxFindMax.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxFindMax.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxFindMax.Location = new System.Drawing.Point(990, 85);
			this.groupBoxFindMax.Name = "groupBoxFindMax";
			this.groupBoxFindMax.Size = new System.Drawing.Size(180, 33);
			this.groupBoxFindMax.TabIndex = 9;
			this.groupBoxFindMax.Tag = "needToMoveParentDown";
			this.groupBoxFindMax.Text = "guna2GroupBox1";
			// 
			// labelFindMaxYes
			// 
			this.labelFindMaxYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFindMaxYes.AutoSize = true;
			this.labelFindMaxYes.BackColor = System.Drawing.Color.Transparent;
			this.labelFindMaxYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelFindMaxYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelFindMaxYes.ForeColor = System.Drawing.Color.Black;
			this.labelFindMaxYes.Location = new System.Drawing.Point(100, 4);
			this.labelFindMaxYes.Name = "labelFindMaxYes";
			this.labelFindMaxYes.Size = new System.Drawing.Size(50, 25);
			this.labelFindMaxYes.TabIndex = 2;
			this.labelFindMaxYes.Tag = "fixedPosition";
			this.labelFindMaxYes.Text = "Так";
			this.labelFindMaxYes.Click += new System.EventHandler(this.LabelFindMaxYes_Click);
			// 
			// labelFindMaxNo
			// 
			this.labelFindMaxNo.AutoSize = true;
			this.labelFindMaxNo.BackColor = System.Drawing.Color.Transparent;
			this.labelFindMaxNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelFindMaxNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelFindMaxNo.ForeColor = System.Drawing.Color.Black;
			this.labelFindMaxNo.Location = new System.Drawing.Point(4, 4);
			this.labelFindMaxNo.Name = "labelFindMaxNo";
			this.labelFindMaxNo.Size = new System.Drawing.Size(34, 25);
			this.labelFindMaxNo.TabIndex = 0;
			this.labelFindMaxNo.Tag = "fixedPosition";
			this.labelFindMaxNo.Text = "Ні";
			this.labelFindMaxNo.Click += new System.EventHandler(this.LabelFindMaxNo_Click);
			// 
			// radioButtonFindMaxYes
			// 
			this.radioButtonFindMaxYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonFindMaxYes.Animated = true;
			this.radioButtonFindMaxYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonFindMaxYes.Checked = true;
			this.radioButtonFindMaxYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonFindMaxYes.CheckedState.BorderThickness = 2;
			this.radioButtonFindMaxYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonFindMaxYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonFindMaxYes.CheckedState.InnerOffset = 1;
			this.radioButtonFindMaxYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonFindMaxYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonFindMaxYes.Name = "radioButtonFindMaxYes";
			this.radioButtonFindMaxYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonFindMaxYes.ShadowDecoration.Depth = 40;
			this.radioButtonFindMaxYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonFindMaxYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonFindMaxYes.TabIndex = 3;
			this.radioButtonFindMaxYes.Tag = "fixedPosition";
			this.radioButtonFindMaxYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonFindMaxYes.UncheckedState.BorderThickness = 2;
			this.radioButtonFindMaxYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonFindMaxYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonFindMaxNo
			// 
			this.radioButtonFindMaxNo.Animated = true;
			this.radioButtonFindMaxNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonFindMaxNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonFindMaxNo.CheckedState.BorderThickness = 2;
			this.radioButtonFindMaxNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonFindMaxNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonFindMaxNo.CheckedState.InnerOffset = 1;
			this.radioButtonFindMaxNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonFindMaxNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonFindMaxNo.Name = "radioButtonFindMaxNo";
			this.radioButtonFindMaxNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonFindMaxNo.ShadowDecoration.Depth = 40;
			this.radioButtonFindMaxNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonFindMaxNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonFindMaxNo.TabIndex = 1;
			this.radioButtonFindMaxNo.Tag = "fixedPosition";
			this.radioButtonFindMaxNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonFindMaxNo.UncheckedState.BorderThickness = 2;
			this.radioButtonFindMaxNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonFindMaxNo.UncheckedState.InnerOffset = 1;
			// 
			// labelFindMax
			// 
			this.labelFindMax.AutoSize = true;
			this.labelFindMax.BackColor = System.Drawing.Color.Transparent;
			this.labelFindMax.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFindMax.ForeColor = System.Drawing.Color.Black;
			this.labelFindMax.Location = new System.Drawing.Point(525, 85);
			this.labelFindMax.Name = "labelFindMax";
			this.labelFindMax.Size = new System.Drawing.Size(451, 32);
			this.labelFindMax.TabIndex = 8;
			this.labelFindMax.Text = "Пошук макс. суми призначень:";
			// 
			// labelHungarianResult
			// 
			this.labelHungarianResult.AutoSize = true;
			this.labelHungarianResult.BackColor = System.Drawing.Color.Transparent;
			this.labelHungarianResult.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHungarianResult.ForeColor = System.Drawing.Color.Black;
			this.labelHungarianResult.Location = new System.Drawing.Point(12, 335);
			this.labelHungarianResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHungarianResult.Name = "labelHungarianResult";
			this.labelHungarianResult.Size = new System.Drawing.Size(306, 32);
			this.labelHungarianResult.TabIndex = 11;
			this.labelHungarianResult.Text = "Угорський алгоритм:";
			// 
			// labelResults
			// 
			this.labelResults.AutoSize = true;
			this.labelResults.BackColor = System.Drawing.Color.Transparent;
			this.labelResults.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelResults.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelResults.ForeColor = System.Drawing.Color.Black;
			this.labelResults.Location = new System.Drawing.Point(335, 265);
			this.labelResults.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelResults.Name = "labelResults";
			this.labelResults.Size = new System.Drawing.Size(203, 35);
			this.labelResults.TabIndex = 10;
			this.labelResults.Text = "Результати";
			// 
			// labelAuctionResult
			// 
			this.labelAuctionResult.AutoSize = true;
			this.labelAuctionResult.BackColor = System.Drawing.Color.Transparent;
			this.labelAuctionResult.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAuctionResult.ForeColor = System.Drawing.Color.Black;
			this.labelAuctionResult.Location = new System.Drawing.Point(575, 335);
			this.labelAuctionResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAuctionResult.Name = "labelAuctionResult";
			this.labelAuctionResult.Size = new System.Drawing.Size(287, 32);
			this.labelAuctionResult.TabIndex = 14;
			this.labelAuctionResult.Text = "Алгоритм аукціону:";
			// 
			// labelHungarianTime
			// 
			this.labelHungarianTime.AutoSize = true;
			this.labelHungarianTime.BackColor = System.Drawing.Color.Transparent;
			this.labelHungarianTime.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHungarianTime.ForeColor = System.Drawing.Color.Black;
			this.labelHungarianTime.Location = new System.Drawing.Point(13, 395);
			this.labelHungarianTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHungarianTime.Name = "labelHungarianTime";
			this.labelHungarianTime.Size = new System.Drawing.Size(183, 25);
			this.labelHungarianTime.TabIndex = 12;
			this.labelHungarianTime.Text = "Час виконання:";
			// 
			// labelHungarianMemory
			// 
			this.labelHungarianMemory.AutoSize = true;
			this.labelHungarianMemory.BackColor = System.Drawing.Color.Transparent;
			this.labelHungarianMemory.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHungarianMemory.ForeColor = System.Drawing.Color.Black;
			this.labelHungarianMemory.Location = new System.Drawing.Point(13, 430);
			this.labelHungarianMemory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHungarianMemory.Name = "labelHungarianMemory";
			this.labelHungarianMemory.Size = new System.Drawing.Size(243, 25);
			this.labelHungarianMemory.TabIndex = 13;
			this.labelHungarianMemory.Text = "Використано пам\'яті:";
			// 
			// labelAuctionMemory
			// 
			this.labelAuctionMemory.AutoSize = true;
			this.labelAuctionMemory.BackColor = System.Drawing.Color.Transparent;
			this.labelAuctionMemory.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAuctionMemory.ForeColor = System.Drawing.Color.Black;
			this.labelAuctionMemory.Location = new System.Drawing.Point(575, 430);
			this.labelAuctionMemory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAuctionMemory.Name = "labelAuctionMemory";
			this.labelAuctionMemory.Size = new System.Drawing.Size(243, 25);
			this.labelAuctionMemory.TabIndex = 16;
			this.labelAuctionMemory.Text = "Використано пам\'яті:";
			// 
			// labelAuctionTime
			// 
			this.labelAuctionTime.AutoSize = true;
			this.labelAuctionTime.BackColor = System.Drawing.Color.Transparent;
			this.labelAuctionTime.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAuctionTime.ForeColor = System.Drawing.Color.Black;
			this.labelAuctionTime.Location = new System.Drawing.Point(575, 395);
			this.labelAuctionTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAuctionTime.Name = "labelAuctionTime";
			this.labelAuctionTime.Size = new System.Drawing.Size(183, 25);
			this.labelAuctionTime.TabIndex = 15;
			this.labelAuctionTime.Text = "Час виконання:";
			// 
			// AssignmentSolversEfficiencyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1215, 600);
			this.Controls.Add(this.labelAuctionMemory);
			this.Controls.Add(this.labelAuctionTime);
			this.Controls.Add(this.labelHungarianMemory);
			this.Controls.Add(this.labelHungarianTime);
			this.Controls.Add(this.labelAuctionResult);
			this.Controls.Add(this.labelResults);
			this.Controls.Add(this.labelHungarianResult);
			this.Controls.Add(this.groupBoxFindMax);
			this.Controls.Add(this.labelFindMax);
			this.Controls.Add(this.groupBoxAllSubmitted);
			this.Controls.Add(this.labelAllSubmitted);
			this.Controls.Add(this.NUDMaxPoints);
			this.Controls.Add(this.labelMaxPoints);
			this.Controls.Add(this.NUDVacancyCount);
			this.Controls.Add(this.labelVacancyCount);
			this.Controls.Add(this.NUDCandidateCount);
			this.Controls.Add(this.labelCandidateCount);
			this.Controls.Add(this.buttonStart);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AssignmentSolversEfficiencyForm";
			this.Text = "AssignmentSolversEfficiencyForm";
			this.Load += new System.EventHandler(this.AssignmentSolversEfficiencyForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.NUDCandidateCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDVacancyCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDMaxPoints)).EndInit();
			this.groupBoxAllSubmitted.ResumeLayout(false);
			this.groupBoxAllSubmitted.PerformLayout();
			this.groupBoxFindMax.ResumeLayout(false);
			this.groupBoxFindMax.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Guna.UI2.WinForms.Guna2GradientButton buttonStart;
		private System.Windows.Forms.Label labelCandidateCount;
		private System.Windows.Forms.NumericUpDown NUDCandidateCount;
		private System.Windows.Forms.NumericUpDown NUDVacancyCount;
		private System.Windows.Forms.Label labelVacancyCount;
		private System.Windows.Forms.NumericUpDown NUDMaxPoints;
		private System.Windows.Forms.Label labelMaxPoints;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxAllSubmitted;
		private System.Windows.Forms.Label labelAllSubmittedYes;
		private System.Windows.Forms.Label labelAllSubmittedNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonAllSubmittedYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonAllSubmittedNo;
		private System.Windows.Forms.Label labelAllSubmitted;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxFindMax;
		private System.Windows.Forms.Label labelFindMaxYes;
		private System.Windows.Forms.Label labelFindMaxNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonFindMaxYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonFindMaxNo;
		private System.Windows.Forms.Label labelFindMax;
		private System.Windows.Forms.Label labelHungarianResult;
		private System.Windows.Forms.Label labelResults;
		private System.Windows.Forms.Label labelAuctionResult;
		private System.Windows.Forms.Label labelHungarianTime;
		private System.Windows.Forms.Label labelHungarianMemory;
		private System.Windows.Forms.Label labelAuctionMemory;
		private System.Windows.Forms.Label labelAuctionTime;
	}
}