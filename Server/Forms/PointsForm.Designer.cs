namespace ServerDB.Forms
{
    partial class PointsForm
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
			this.buttonCreate = new System.Windows.Forms.Button();
			this.NUDAgeUnder18 = new System.Windows.Forms.NumericUpDown();
			this.labelAgeUnder18 = new System.Windows.Forms.Label();
			this.NUDAge18_30 = new System.Windows.Forms.NumericUpDown();
			this.labelAge18_30 = new System.Windows.Forms.Label();
			this.NUDAgeOver50 = new System.Windows.Forms.NumericUpDown();
			this.labelAgeOver50 = new System.Windows.Forms.Label();
			this.NUDAge30_50 = new System.Windows.Forms.NumericUpDown();
			this.labelAge30_50 = new System.Windows.Forms.Label();
			this.NUDExp1_3 = new System.Windows.Forms.NumericUpDown();
			this.labelExp1_3 = new System.Windows.Forms.Label();
			this.NUDExpUnderYear = new System.Windows.Forms.NumericUpDown();
			this.labelExpUnderYear = new System.Windows.Forms.Label();
			this.NUDExpNone = new System.Windows.Forms.NumericUpDown();
			this.labelExpNone = new System.Windows.Forms.Label();
			this.NUDBusinessTripOpportunity = new System.Windows.Forms.NumericUpDown();
			this.labelBusinessTripOpportunity = new System.Windows.Forms.Label();
			this.NUDNoDrinkAlcohol = new System.Windows.Forms.NumericUpDown();
			this.labelNoDrinkAlcohol = new System.Windows.Forms.Label();
			this.NUDNoSmoker = new System.Windows.Forms.NumericUpDown();
			this.labelNoSmoker = new System.Windows.Forms.Label();
			this.NUDDriverLicense = new System.Windows.Forms.NumericUpDown();
			this.labelDriverLicense = new System.Windows.Forms.Label();
			this.NUDNoChronicDiseases = new System.Windows.Forms.NumericUpDown();
			this.labelNoChronicDiseases = new System.Windows.Forms.Label();
			this.NUDDiploma = new System.Windows.Forms.NumericUpDown();
			this.labelDiploma = new System.Windows.Forms.Label();
			this.NUDExpOver3 = new System.Windows.Forms.NumericUpDown();
			this.labelExpOver3 = new System.Windows.Forms.Label();
			this.recruitmentDBDataSet = new ServerDB.RecruitmentDB();
			this.comboBoxDegrees = new System.Windows.Forms.ComboBox();
			this.educationDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.education_DegreeTableAdapter = new ServerDB.RecruitmentDBTableAdapters.Education_DegreeTableAdapter();
			this.NUDDegree = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.NUDAgeUnder18)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDAge18_30)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDAgeOver50)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDAge30_50)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExp1_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExpUnderYear)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExpNone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDBusinessTripOpportunity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDNoDrinkAlcohol)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDNoSmoker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDDriverLicense)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDNoChronicDiseases)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDDiploma)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExpOver3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.educationDegreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDDegree)).BeginInit();
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
			this.buttonCreate.Location = new System.Drawing.Point(1072, 545);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(175, 40);
			this.buttonCreate.TabIndex = 30;
			this.buttonCreate.Text = "Створити";
			this.buttonCreate.UseVisualStyleBackColor = false;
			this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// NUDAgeUnder18
			// 
			this.NUDAgeUnder18.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDAgeUnder18.ForeColor = System.Drawing.Color.Black;
			this.NUDAgeUnder18.Location = new System.Drawing.Point(428, 8);
			this.NUDAgeUnder18.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDAgeUnder18.Name = "NUDAgeUnder18";
			this.NUDAgeUnder18.Size = new System.Drawing.Size(50, 36);
			this.NUDAgeUnder18.TabIndex = 1;
			this.NUDAgeUnder18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelAgeUnder18
			// 
			this.labelAgeUnder18.AutoSize = true;
			this.labelAgeUnder18.BackColor = System.Drawing.Color.Transparent;
			this.labelAgeUnder18.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAgeUnder18.ForeColor = System.Drawing.Color.Black;
			this.labelAgeUnder18.Location = new System.Drawing.Point(12, 12);
			this.labelAgeUnder18.Name = "labelAgeUnder18";
			this.labelAgeUnder18.Size = new System.Drawing.Size(136, 29);
			this.labelAgeUnder18.TabIndex = 0;
			this.labelAgeUnder18.Text = "Вік до 18:";
			// 
			// NUDAge18_30
			// 
			this.NUDAge18_30.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDAge18_30.ForeColor = System.Drawing.Color.Black;
			this.NUDAge18_30.Location = new System.Drawing.Point(428, 68);
			this.NUDAge18_30.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDAge18_30.Name = "NUDAge18_30";
			this.NUDAge18_30.Size = new System.Drawing.Size(50, 36);
			this.NUDAge18_30.TabIndex = 3;
			this.NUDAge18_30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelAge18_30
			// 
			this.labelAge18_30.AutoSize = true;
			this.labelAge18_30.BackColor = System.Drawing.Color.Transparent;
			this.labelAge18_30.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAge18_30.ForeColor = System.Drawing.Color.Black;
			this.labelAge18_30.Location = new System.Drawing.Point(12, 72);
			this.labelAge18_30.Name = "labelAge18_30";
			this.labelAge18_30.Size = new System.Drawing.Size(217, 29);
			this.labelAge18_30.TabIndex = 2;
			this.labelAge18_30.Text = "Вік від 18 до 30:";
			// 
			// NUDAgeOver50
			// 
			this.NUDAgeOver50.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDAgeOver50.ForeColor = System.Drawing.Color.Black;
			this.NUDAgeOver50.Location = new System.Drawing.Point(428, 188);
			this.NUDAgeOver50.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDAgeOver50.Name = "NUDAgeOver50";
			this.NUDAgeOver50.Size = new System.Drawing.Size(50, 36);
			this.NUDAgeOver50.TabIndex = 7;
			this.NUDAgeOver50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelAgeOver50
			// 
			this.labelAgeOver50.AutoSize = true;
			this.labelAgeOver50.BackColor = System.Drawing.Color.Transparent;
			this.labelAgeOver50.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAgeOver50.ForeColor = System.Drawing.Color.Black;
			this.labelAgeOver50.Location = new System.Drawing.Point(12, 192);
			this.labelAgeOver50.Name = "labelAgeOver50";
			this.labelAgeOver50.Size = new System.Drawing.Size(191, 29);
			this.labelAgeOver50.TabIndex = 6;
			this.labelAgeOver50.Text = "Вік більше 50:";
			// 
			// NUDAge30_50
			// 
			this.NUDAge30_50.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDAge30_50.ForeColor = System.Drawing.Color.Black;
			this.NUDAge30_50.Location = new System.Drawing.Point(428, 128);
			this.NUDAge30_50.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDAge30_50.Name = "NUDAge30_50";
			this.NUDAge30_50.Size = new System.Drawing.Size(50, 36);
			this.NUDAge30_50.TabIndex = 5;
			this.NUDAge30_50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelAge30_50
			// 
			this.labelAge30_50.AutoSize = true;
			this.labelAge30_50.BackColor = System.Drawing.Color.Transparent;
			this.labelAge30_50.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAge30_50.ForeColor = System.Drawing.Color.Black;
			this.labelAge30_50.Location = new System.Drawing.Point(12, 132);
			this.labelAge30_50.Name = "labelAge30_50";
			this.labelAge30_50.Size = new System.Drawing.Size(217, 29);
			this.labelAge30_50.TabIndex = 4;
			this.labelAge30_50.Text = "Вік від 30 до 50:";
			// 
			// NUDExp1_3
			// 
			this.NUDExp1_3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDExp1_3.ForeColor = System.Drawing.Color.Black;
			this.NUDExp1_3.Location = new System.Drawing.Point(428, 368);
			this.NUDExp1_3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDExp1_3.Name = "NUDExp1_3";
			this.NUDExp1_3.Size = new System.Drawing.Size(50, 36);
			this.NUDExp1_3.TabIndex = 13;
			this.NUDExp1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelExp1_3
			// 
			this.labelExp1_3.AutoSize = true;
			this.labelExp1_3.BackColor = System.Drawing.Color.Transparent;
			this.labelExp1_3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExp1_3.ForeColor = System.Drawing.Color.Black;
			this.labelExp1_3.Location = new System.Drawing.Point(12, 372);
			this.labelExp1_3.Name = "labelExp1_3";
			this.labelExp1_3.Size = new System.Drawing.Size(399, 29);
			this.labelExp1_3.TabIndex = 12;
			this.labelExp1_3.Text = "Досвід роботи від 1 до 3 років:";
			// 
			// NUDExpUnderYear
			// 
			this.NUDExpUnderYear.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDExpUnderYear.ForeColor = System.Drawing.Color.Black;
			this.NUDExpUnderYear.Location = new System.Drawing.Point(428, 308);
			this.NUDExpUnderYear.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDExpUnderYear.Name = "NUDExpUnderYear";
			this.NUDExpUnderYear.Size = new System.Drawing.Size(50, 36);
			this.NUDExpUnderYear.TabIndex = 11;
			this.NUDExpUnderYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelExpUnderYear
			// 
			this.labelExpUnderYear.AutoSize = true;
			this.labelExpUnderYear.BackColor = System.Drawing.Color.Transparent;
			this.labelExpUnderYear.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExpUnderYear.ForeColor = System.Drawing.Color.Black;
			this.labelExpUnderYear.Location = new System.Drawing.Point(12, 312);
			this.labelExpUnderYear.Name = "labelExpUnderYear";
			this.labelExpUnderYear.Size = new System.Drawing.Size(355, 29);
			this.labelExpUnderYear.TabIndex = 10;
			this.labelExpUnderYear.Text = "Досвід роботи менше року:";
			// 
			// NUDExpNone
			// 
			this.NUDExpNone.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDExpNone.ForeColor = System.Drawing.Color.Black;
			this.NUDExpNone.Location = new System.Drawing.Point(428, 248);
			this.NUDExpNone.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDExpNone.Name = "NUDExpNone";
			this.NUDExpNone.Size = new System.Drawing.Size(50, 36);
			this.NUDExpNone.TabIndex = 9;
			this.NUDExpNone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelExpNone
			// 
			this.labelExpNone.AutoSize = true;
			this.labelExpNone.BackColor = System.Drawing.Color.Transparent;
			this.labelExpNone.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExpNone.ForeColor = System.Drawing.Color.Black;
			this.labelExpNone.Location = new System.Drawing.Point(12, 252);
			this.labelExpNone.Name = "labelExpNone";
			this.labelExpNone.Size = new System.Drawing.Size(295, 29);
			this.labelExpNone.TabIndex = 8;
			this.labelExpNone.Text = "Немає досвіду роботи:";
			// 
			// NUDBusinessTripOpportunity
			// 
			this.NUDBusinessTripOpportunity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDBusinessTripOpportunity.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDBusinessTripOpportunity.ForeColor = System.Drawing.Color.Black;
			this.NUDBusinessTripOpportunity.Location = new System.Drawing.Point(1068, 368);
			this.NUDBusinessTripOpportunity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDBusinessTripOpportunity.Name = "NUDBusinessTripOpportunity";
			this.NUDBusinessTripOpportunity.Size = new System.Drawing.Size(50, 36);
			this.NUDBusinessTripOpportunity.TabIndex = 27;
			this.NUDBusinessTripOpportunity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelBusinessTripOpportunity
			// 
			this.labelBusinessTripOpportunity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBusinessTripOpportunity.AutoSize = true;
			this.labelBusinessTripOpportunity.BackColor = System.Drawing.Color.Transparent;
			this.labelBusinessTripOpportunity.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBusinessTripOpportunity.ForeColor = System.Drawing.Color.Black;
			this.labelBusinessTripOpportunity.Location = new System.Drawing.Point(600, 372);
			this.labelBusinessTripOpportunity.Name = "labelBusinessTripOpportunity";
			this.labelBusinessTripOpportunity.Size = new System.Drawing.Size(338, 29);
			this.labelBusinessTripOpportunity.TabIndex = 26;
			this.labelBusinessTripOpportunity.Text = "Є можливість відряджень:";
			// 
			// NUDNoDrinkAlcohol
			// 
			this.NUDNoDrinkAlcohol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDNoDrinkAlcohol.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDNoDrinkAlcohol.ForeColor = System.Drawing.Color.Black;
			this.NUDNoDrinkAlcohol.Location = new System.Drawing.Point(1068, 308);
			this.NUDNoDrinkAlcohol.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDNoDrinkAlcohol.Name = "NUDNoDrinkAlcohol";
			this.NUDNoDrinkAlcohol.Size = new System.Drawing.Size(50, 36);
			this.NUDNoDrinkAlcohol.TabIndex = 25;
			this.NUDNoDrinkAlcohol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelNoDrinkAlcohol
			// 
			this.labelNoDrinkAlcohol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoDrinkAlcohol.AutoSize = true;
			this.labelNoDrinkAlcohol.BackColor = System.Drawing.Color.Transparent;
			this.labelNoDrinkAlcohol.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoDrinkAlcohol.ForeColor = System.Drawing.Color.Black;
			this.labelNoDrinkAlcohol.Location = new System.Drawing.Point(600, 312);
			this.labelNoDrinkAlcohol.Name = "labelNoDrinkAlcohol";
			this.labelNoDrinkAlcohol.Size = new System.Drawing.Size(274, 29);
			this.labelNoDrinkAlcohol.TabIndex = 24;
			this.labelNoDrinkAlcohol.Text = "Не вживає алкоголь:";
			// 
			// NUDNoSmoker
			// 
			this.NUDNoSmoker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDNoSmoker.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDNoSmoker.ForeColor = System.Drawing.Color.Black;
			this.NUDNoSmoker.Location = new System.Drawing.Point(1068, 248);
			this.NUDNoSmoker.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDNoSmoker.Name = "NUDNoSmoker";
			this.NUDNoSmoker.Size = new System.Drawing.Size(50, 36);
			this.NUDNoSmoker.TabIndex = 23;
			this.NUDNoSmoker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelNoSmoker
			// 
			this.labelNoSmoker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoSmoker.AutoSize = true;
			this.labelNoSmoker.BackColor = System.Drawing.Color.Transparent;
			this.labelNoSmoker.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoSmoker.ForeColor = System.Drawing.Color.Black;
			this.labelNoSmoker.Location = new System.Drawing.Point(600, 252);
			this.labelNoSmoker.Name = "labelNoSmoker";
			this.labelNoSmoker.Size = new System.Drawing.Size(150, 29);
			this.labelNoSmoker.TabIndex = 22;
			this.labelNoSmoker.Text = "Не курець:";
			// 
			// NUDDriverLicense
			// 
			this.NUDDriverLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDDriverLicense.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDDriverLicense.ForeColor = System.Drawing.Color.Black;
			this.NUDDriverLicense.Location = new System.Drawing.Point(1068, 188);
			this.NUDDriverLicense.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDDriverLicense.Name = "NUDDriverLicense";
			this.NUDDriverLicense.Size = new System.Drawing.Size(50, 36);
			this.NUDDriverLicense.TabIndex = 21;
			this.NUDDriverLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelDriverLicense
			// 
			this.labelDriverLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDriverLicense.AutoSize = true;
			this.labelDriverLicense.BackColor = System.Drawing.Color.Transparent;
			this.labelDriverLicense.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDriverLicense.ForeColor = System.Drawing.Color.Black;
			this.labelDriverLicense.Location = new System.Drawing.Point(600, 192);
			this.labelDriverLicense.Name = "labelDriverLicense";
			this.labelDriverLicense.Size = new System.Drawing.Size(375, 29);
			this.labelDriverLicense.TabIndex = 20;
			this.labelDriverLicense.Text = "Наявність посвідчення водія:";
			// 
			// NUDNoChronicDiseases
			// 
			this.NUDNoChronicDiseases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDNoChronicDiseases.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDNoChronicDiseases.ForeColor = System.Drawing.Color.Black;
			this.NUDNoChronicDiseases.Location = new System.Drawing.Point(1068, 128);
			this.NUDNoChronicDiseases.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDNoChronicDiseases.Name = "NUDNoChronicDiseases";
			this.NUDNoChronicDiseases.Size = new System.Drawing.Size(50, 36);
			this.NUDNoChronicDiseases.TabIndex = 19;
			this.NUDNoChronicDiseases.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelNoChronicDiseases
			// 
			this.labelNoChronicDiseases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoChronicDiseases.AutoSize = true;
			this.labelNoChronicDiseases.BackColor = System.Drawing.Color.Transparent;
			this.labelNoChronicDiseases.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoChronicDiseases.ForeColor = System.Drawing.Color.Black;
			this.labelNoChronicDiseases.Location = new System.Drawing.Point(600, 132);
			this.labelNoChronicDiseases.Name = "labelNoChronicDiseases";
			this.labelNoChronicDiseases.Size = new System.Drawing.Size(462, 29);
			this.labelNoChronicDiseases.TabIndex = 18;
			this.labelNoChronicDiseases.Text = "Відсутність хронічних захворювань:";
			// 
			// NUDDiploma
			// 
			this.NUDDiploma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDDiploma.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDDiploma.ForeColor = System.Drawing.Color.Black;
			this.NUDDiploma.Location = new System.Drawing.Point(1068, 68);
			this.NUDDiploma.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDDiploma.Name = "NUDDiploma";
			this.NUDDiploma.Size = new System.Drawing.Size(50, 36);
			this.NUDDiploma.TabIndex = 17;
			this.NUDDiploma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelDiploma
			// 
			this.labelDiploma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDiploma.AutoSize = true;
			this.labelDiploma.BackColor = System.Drawing.Color.Transparent;
			this.labelDiploma.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDiploma.ForeColor = System.Drawing.Color.Black;
			this.labelDiploma.Location = new System.Drawing.Point(600, 72);
			this.labelDiploma.Name = "labelDiploma";
			this.labelDiploma.Size = new System.Drawing.Size(258, 29);
			this.labelDiploma.TabIndex = 16;
			this.labelDiploma.Text = "Наявність диплому:";
			// 
			// NUDExpOver3
			// 
			this.NUDExpOver3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NUDExpOver3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDExpOver3.ForeColor = System.Drawing.Color.Black;
			this.NUDExpOver3.Location = new System.Drawing.Point(1068, 8);
			this.NUDExpOver3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDExpOver3.Name = "NUDExpOver3";
			this.NUDExpOver3.Size = new System.Drawing.Size(50, 36);
			this.NUDExpOver3.TabIndex = 15;
			this.NUDExpOver3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelExpOver3
			// 
			this.labelExpOver3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelExpOver3.AutoSize = true;
			this.labelExpOver3.BackColor = System.Drawing.Color.Transparent;
			this.labelExpOver3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExpOver3.ForeColor = System.Drawing.Color.Black;
			this.labelExpOver3.Location = new System.Drawing.Point(600, 12);
			this.labelExpOver3.Name = "labelExpOver3";
			this.labelExpOver3.Size = new System.Drawing.Size(388, 29);
			this.labelExpOver3.TabIndex = 14;
			this.labelExpOver3.Text = "Досвід роботи більше 3 років:";
			// 
			// recruitmentDBDataSet
			// 
			this.recruitmentDBDataSet.DataSetName = "RecruitmentDBDataSet";
			this.recruitmentDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// comboBoxDegrees
			// 
			this.comboBoxDegrees.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDegrees.DataSource = this.educationDegreeBindingSource;
			this.comboBoxDegrees.DisplayMember = "degree";
			this.comboBoxDegrees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDegrees.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxDegrees.ForeColor = System.Drawing.Color.Black;
			this.comboBoxDegrees.FormattingEnabled = true;
			this.comboBoxDegrees.IntegralHeight = false;
			this.comboBoxDegrees.Location = new System.Drawing.Point(12, 475);
			this.comboBoxDegrees.MaxDropDownItems = 6;
			this.comboBoxDegrees.MaxLength = 64;
			this.comboBoxDegrees.Name = "comboBoxDegrees";
			this.comboBoxDegrees.Size = new System.Drawing.Size(399, 36);
			this.comboBoxDegrees.TabIndex = 28;
			this.comboBoxDegrees.ValueMember = "id";
			this.comboBoxDegrees.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDegrees_SelectedIndexChanged);
			// 
			// educationDegreeBindingSource
			// 
			this.educationDegreeBindingSource.DataMember = "Education_Degree";
			this.educationDegreeBindingSource.DataSource = this.recruitmentDBDataSet;
			// 
			// education_DegreeTableAdapter
			// 
			this.education_DegreeTableAdapter.ClearBeforeFill = true;
			// 
			// NUDDegree
			// 
			this.NUDDegree.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NUDDegree.ForeColor = System.Drawing.Color.Black;
			this.NUDDegree.Location = new System.Drawing.Point(428, 475);
			this.NUDDegree.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NUDDegree.Name = "NUDDegree";
			this.NUDDegree.Size = new System.Drawing.Size(50, 36);
			this.NUDDegree.TabIndex = 29;
			this.NUDDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NUDDegree.ValueChanged += new System.EventHandler(this.NUDDegree_ValueChanged);
			// 
			// PointsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 602);
			this.Controls.Add(this.NUDDegree);
			this.Controls.Add(this.comboBoxDegrees);
			this.Controls.Add(this.NUDBusinessTripOpportunity);
			this.Controls.Add(this.labelBusinessTripOpportunity);
			this.Controls.Add(this.NUDNoDrinkAlcohol);
			this.Controls.Add(this.labelNoDrinkAlcohol);
			this.Controls.Add(this.NUDNoSmoker);
			this.Controls.Add(this.labelNoSmoker);
			this.Controls.Add(this.NUDDriverLicense);
			this.Controls.Add(this.labelDriverLicense);
			this.Controls.Add(this.NUDNoChronicDiseases);
			this.Controls.Add(this.labelNoChronicDiseases);
			this.Controls.Add(this.NUDDiploma);
			this.Controls.Add(this.labelDiploma);
			this.Controls.Add(this.NUDExpOver3);
			this.Controls.Add(this.labelExpOver3);
			this.Controls.Add(this.NUDExp1_3);
			this.Controls.Add(this.labelExp1_3);
			this.Controls.Add(this.NUDExpUnderYear);
			this.Controls.Add(this.labelExpUnderYear);
			this.Controls.Add(this.NUDExpNone);
			this.Controls.Add(this.labelExpNone);
			this.Controls.Add(this.NUDAgeOver50);
			this.Controls.Add(this.labelAgeOver50);
			this.Controls.Add(this.NUDAge30_50);
			this.Controls.Add(this.labelAge30_50);
			this.Controls.Add(this.NUDAge18_30);
			this.Controls.Add(this.labelAge18_30);
			this.Controls.Add(this.NUDAgeUnder18);
			this.Controls.Add(this.labelAgeUnder18);
			this.Controls.Add(this.buttonCreate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PointsForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Бали";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PointsForm_FormClosed);
			this.Load += new System.EventHandler(this.PointsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.NUDAgeUnder18)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDAge18_30)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDAgeOver50)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDAge30_50)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExp1_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExpUnderYear)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExpNone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDBusinessTripOpportunity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDNoDrinkAlcohol)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDNoSmoker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDDriverLicense)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDNoChronicDiseases)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDDiploma)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDExpOver3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.educationDegreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDDegree)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.NumericUpDown NUDAgeUnder18;
        private System.Windows.Forms.Label labelAgeUnder18;
        private System.Windows.Forms.NumericUpDown NUDAge18_30;
        private System.Windows.Forms.Label labelAge18_30;
        private System.Windows.Forms.NumericUpDown NUDAgeOver50;
        private System.Windows.Forms.Label labelAgeOver50;
        private System.Windows.Forms.NumericUpDown NUDAge30_50;
        private System.Windows.Forms.Label labelAge30_50;
        private System.Windows.Forms.NumericUpDown NUDExp1_3;
        private System.Windows.Forms.Label labelExp1_3;
        private System.Windows.Forms.NumericUpDown NUDExpUnderYear;
        private System.Windows.Forms.Label labelExpUnderYear;
        private System.Windows.Forms.NumericUpDown NUDExpNone;
        private System.Windows.Forms.Label labelExpNone;
        private System.Windows.Forms.NumericUpDown NUDBusinessTripOpportunity;
        private System.Windows.Forms.Label labelBusinessTripOpportunity;
        private System.Windows.Forms.NumericUpDown NUDNoDrinkAlcohol;
        private System.Windows.Forms.Label labelNoDrinkAlcohol;
        private System.Windows.Forms.NumericUpDown NUDNoSmoker;
        private System.Windows.Forms.Label labelNoSmoker;
        private System.Windows.Forms.NumericUpDown NUDDriverLicense;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.NumericUpDown NUDNoChronicDiseases;
        private System.Windows.Forms.Label labelNoChronicDiseases;
        private System.Windows.Forms.NumericUpDown NUDDiploma;
        private System.Windows.Forms.Label labelDiploma;
        private System.Windows.Forms.NumericUpDown NUDExpOver3;
        private System.Windows.Forms.Label labelExpOver3;
        private RecruitmentDB recruitmentDBDataSet;
        private System.Windows.Forms.ComboBox comboBoxDegrees;
        private System.Windows.Forms.BindingSource educationDegreeBindingSource;
        private RecruitmentDBTableAdapters.Education_DegreeTableAdapter education_DegreeTableAdapter;
        private System.Windows.Forms.NumericUpDown NUDDegree;
    }
}