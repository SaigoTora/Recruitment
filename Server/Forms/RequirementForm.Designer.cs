namespace ServerDB.Forms
{
    partial class RequirementForm
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
			this.textBoxCity = new System.Windows.Forms.TextBox();
			this.labelCity = new System.Windows.Forms.Label();
			this.numericUpDownAgeMin = new System.Windows.Forms.NumericUpDown();
			this.labelAgeMin = new System.Windows.Forms.Label();
			this.numericUpDownAgeMax = new System.Windows.Forms.NumericUpDown();
			this.labelAgeMax = new System.Windows.Forms.Label();
			this.numericUpDownExpMin = new System.Windows.Forms.NumericUpDown();
			this.labelExpMin = new System.Windows.Forms.Label();
			this.checkBoxDiplomaAll = new System.Windows.Forms.CheckBox();
			this.labelCandidateMustHave = new System.Windows.Forms.Label();
			this.checkBoxNoChronicDiseasesYes = new System.Windows.Forms.CheckBox();
			this.checkBoxNoChronicDiseasesNo = new System.Windows.Forms.CheckBox();
			this.labelNoChronicDiseases = new System.Windows.Forms.Label();
			this.checkBoxDriverLicenseYes = new System.Windows.Forms.CheckBox();
			this.checkBoxDriverLicenseNo = new System.Windows.Forms.CheckBox();
			this.labelDriverLicense = new System.Windows.Forms.Label();
			this.checkBoxBusinessTripYes = new System.Windows.Forms.CheckBox();
			this.checkBoxBusinessTripNo = new System.Windows.Forms.CheckBox();
			this.labelBusinessTrip = new System.Windows.Forms.Label();
			this.checkBoxNoDrinkAlcoholYes = new System.Windows.Forms.CheckBox();
			this.checkBoxNoDrinkAlcoholNo = new System.Windows.Forms.CheckBox();
			this.labelNoDrinkAlcohol = new System.Windows.Forms.Label();
			this.checkBoxNoSmokerYes = new System.Windows.Forms.CheckBox();
			this.checkBoxNoSmokerNo = new System.Windows.Forms.CheckBox();
			this.labelNoSmoker = new System.Windows.Forms.Label();
			this.checkBoxStudentYes = new System.Windows.Forms.CheckBox();
			this.checkBoxStudentNo = new System.Windows.Forms.CheckBox();
			this.labelStudent = new System.Windows.Forms.Label();
			this.checkBoxStudentNull = new System.Windows.Forms.CheckBox();
			this.labelEducationDegree = new System.Windows.Forms.Label();
			this.listBoxDegrees = new System.Windows.Forms.ListBox();
			this.educationDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.recruitmentDBDataSet = new ServerDB.RecruitmentDB();
			this.education_DegreeTableAdapter = new ServerDB.RecruitmentDBTableAdapters.Education_DegreeTableAdapter();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.labelCityInfo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.educationDegreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxCity
			// 
			this.textBoxCity.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCity.ForeColor = System.Drawing.Color.Black;
			this.textBoxCity.Location = new System.Drawing.Point(464, 10);
			this.textBoxCity.MaxLength = 64;
			this.textBoxCity.Name = "textBoxCity";
			this.textBoxCity.Size = new System.Drawing.Size(287, 36);
			this.textBoxCity.TabIndex = 1;
			// 
			// labelCity
			// 
			this.labelCity.AutoSize = true;
			this.labelCity.BackColor = System.Drawing.Color.Transparent;
			this.labelCity.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCity.ForeColor = System.Drawing.Color.Black;
			this.labelCity.Location = new System.Drawing.Point(12, 12);
			this.labelCity.Name = "labelCity";
			this.labelCity.Size = new System.Drawing.Size(446, 32);
			this.labelCity.TabIndex = 0;
			this.labelCity.Text = "Населений пункт проживання:";
			// 
			// numericUpDownAgeMin
			// 
			this.numericUpDownAgeMin.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownAgeMin.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownAgeMin.Location = new System.Drawing.Point(265, 70);
			this.numericUpDownAgeMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.numericUpDownAgeMin.Minimum = new decimal(new int[] {
            14,
            0,
            0,
            0});
			this.numericUpDownAgeMin.Name = "numericUpDownAgeMin";
			this.numericUpDownAgeMin.Size = new System.Drawing.Size(50, 36);
			this.numericUpDownAgeMin.TabIndex = 4;
			this.numericUpDownAgeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownAgeMin.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
			// 
			// labelAgeMin
			// 
			this.labelAgeMin.AutoSize = true;
			this.labelAgeMin.BackColor = System.Drawing.Color.Transparent;
			this.labelAgeMin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAgeMin.ForeColor = System.Drawing.Color.Black;
			this.labelAgeMin.Location = new System.Drawing.Point(12, 72);
			this.labelAgeMin.Name = "labelAgeMin";
			this.labelAgeMin.Size = new System.Drawing.Size(247, 32);
			this.labelAgeMin.TabIndex = 3;
			this.labelAgeMin.Text = "Мінімальний вік:";
			// 
			// numericUpDownAgeMax
			// 
			this.numericUpDownAgeMax.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownAgeMax.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownAgeMax.Location = new System.Drawing.Point(297, 130);
			this.numericUpDownAgeMax.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.numericUpDownAgeMax.Minimum = new decimal(new int[] {
            14,
            0,
            0,
            0});
			this.numericUpDownAgeMax.Name = "numericUpDownAgeMax";
			this.numericUpDownAgeMax.Size = new System.Drawing.Size(50, 36);
			this.numericUpDownAgeMax.TabIndex = 6;
			this.numericUpDownAgeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownAgeMax.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
			// 
			// labelAgeMax
			// 
			this.labelAgeMax.AutoSize = true;
			this.labelAgeMax.BackColor = System.Drawing.Color.Transparent;
			this.labelAgeMax.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAgeMax.ForeColor = System.Drawing.Color.Black;
			this.labelAgeMax.Location = new System.Drawing.Point(12, 132);
			this.labelAgeMax.Name = "labelAgeMax";
			this.labelAgeMax.Size = new System.Drawing.Size(279, 32);
			this.labelAgeMax.TabIndex = 5;
			this.labelAgeMax.Text = "Максимальний вік:";
			// 
			// numericUpDownExpMin
			// 
			this.numericUpDownExpMin.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownExpMin.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownExpMin.Location = new System.Drawing.Point(574, 190);
			this.numericUpDownExpMin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numericUpDownExpMin.Name = "numericUpDownExpMin";
			this.numericUpDownExpMin.Size = new System.Drawing.Size(75, 36);
			this.numericUpDownExpMin.TabIndex = 8;
			this.numericUpDownExpMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelExpMin
			// 
			this.labelExpMin.AutoSize = true;
			this.labelExpMin.BackColor = System.Drawing.Color.Transparent;
			this.labelExpMin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExpMin.ForeColor = System.Drawing.Color.Black;
			this.labelExpMin.Location = new System.Drawing.Point(12, 192);
			this.labelExpMin.Name = "labelExpMin";
			this.labelExpMin.Size = new System.Drawing.Size(556, 32);
			this.labelExpMin.TabIndex = 7;
			this.labelExpMin.Text = "Мінімальний досвід роботи(в місяцях):";
			// 
			// checkBoxDiplomaAll
			// 
			this.checkBoxDiplomaAll.AutoSize = true;
			this.checkBoxDiplomaAll.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxDiplomaAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxDiplomaAll.Checked = true;
			this.checkBoxDiplomaAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDiplomaAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDiplomaAll.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxDiplomaAll.ForeColor = System.Drawing.Color.Black;
			this.checkBoxDiplomaAll.Location = new System.Drawing.Point(760, 250);
			this.checkBoxDiplomaAll.Name = "checkBoxDiplomaAll";
			this.checkBoxDiplomaAll.Size = new System.Drawing.Size(166, 29);
			this.checkBoxDiplomaAll.TabIndex = 12;
			this.checkBoxDiplomaAll.Text = "Вибрати всі:";
			this.checkBoxDiplomaAll.UseVisualStyleBackColor = false;
			this.checkBoxDiplomaAll.CheckedChanged += new System.EventHandler(this.CheckBoxDiplomaAll_CheckedChanged);
			// 
			// labelCandidateMustHave
			// 
			this.labelCandidateMustHave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelCandidateMustHave.AutoSize = true;
			this.labelCandidateMustHave.BackColor = System.Drawing.Color.Transparent;
			this.labelCandidateMustHave.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCandidateMustHave.ForeColor = System.Drawing.Color.Black;
			this.labelCandidateMustHave.Location = new System.Drawing.Point(12, 340);
			this.labelCandidateMustHave.Name = "labelCandidateMustHave";
			this.labelCandidateMustHave.Size = new System.Drawing.Size(304, 35);
			this.labelCandidateMustHave.TabIndex = 13;
			this.labelCandidateMustHave.Text = "Кандидат повинен:";
			// 
			// checkBoxNoChronicDiseasesYes
			// 
			this.checkBoxNoChronicDiseasesYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNoChronicDiseasesYes.AutoSize = true;
			this.checkBoxNoChronicDiseasesYes.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxNoChronicDiseasesYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNoChronicDiseasesYes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxNoChronicDiseasesYes.ForeColor = System.Drawing.Color.Black;
			this.checkBoxNoChronicDiseasesYes.Location = new System.Drawing.Point(601, 404);
			this.checkBoxNoChronicDiseasesYes.Name = "checkBoxNoChronicDiseasesYes";
			this.checkBoxNoChronicDiseasesYes.Size = new System.Drawing.Size(69, 29);
			this.checkBoxNoChronicDiseasesYes.TabIndex = 16;
			this.checkBoxNoChronicDiseasesYes.Text = "Так";
			this.checkBoxNoChronicDiseasesYes.UseVisualStyleBackColor = false;
			this.checkBoxNoChronicDiseasesYes.CheckedChanged += new System.EventHandler(this.CheckBoxNoChronicDiseases_CheckedChanged);
			// 
			// checkBoxNoChronicDiseasesNo
			// 
			this.checkBoxNoChronicDiseasesNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNoChronicDiseasesNo.AutoSize = true;
			this.checkBoxNoChronicDiseasesNo.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxNoChronicDiseasesNo.Checked = true;
			this.checkBoxNoChronicDiseasesNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxNoChronicDiseasesNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNoChronicDiseasesNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxNoChronicDiseasesNo.ForeColor = System.Drawing.Color.Black;
			this.checkBoxNoChronicDiseasesNo.Location = new System.Drawing.Point(501, 404);
			this.checkBoxNoChronicDiseasesNo.Name = "checkBoxNoChronicDiseasesNo";
			this.checkBoxNoChronicDiseasesNo.Size = new System.Drawing.Size(53, 29);
			this.checkBoxNoChronicDiseasesNo.TabIndex = 15;
			this.checkBoxNoChronicDiseasesNo.Text = "Ні";
			this.checkBoxNoChronicDiseasesNo.UseVisualStyleBackColor = false;
			this.checkBoxNoChronicDiseasesNo.CheckedChanged += new System.EventHandler(this.CheckBoxNoChronicDiseases_CheckedChanged);
			// 
			// labelNoChronicDiseases
			// 
			this.labelNoChronicDiseases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelNoChronicDiseases.AutoSize = true;
			this.labelNoChronicDiseases.BackColor = System.Drawing.Color.Transparent;
			this.labelNoChronicDiseases.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoChronicDiseases.ForeColor = System.Drawing.Color.Black;
			this.labelNoChronicDiseases.Location = new System.Drawing.Point(12, 400);
			this.labelNoChronicDiseases.Name = "labelNoChronicDiseases";
			this.labelNoChronicDiseases.Size = new System.Drawing.Size(479, 32);
			this.labelNoChronicDiseases.TabIndex = 14;
			this.labelNoChronicDiseases.Text = "НЕ мати хронічних захворювань:";
			// 
			// checkBoxDriverLicenseYes
			// 
			this.checkBoxDriverLicenseYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxDriverLicenseYes.AutoSize = true;
			this.checkBoxDriverLicenseYes.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxDriverLicenseYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDriverLicenseYes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxDriverLicenseYes.ForeColor = System.Drawing.Color.Black;
			this.checkBoxDriverLicenseYes.Location = new System.Drawing.Point(601, 464);
			this.checkBoxDriverLicenseYes.Name = "checkBoxDriverLicenseYes";
			this.checkBoxDriverLicenseYes.Size = new System.Drawing.Size(69, 29);
			this.checkBoxDriverLicenseYes.TabIndex = 19;
			this.checkBoxDriverLicenseYes.Text = "Так";
			this.checkBoxDriverLicenseYes.UseVisualStyleBackColor = false;
			this.checkBoxDriverLicenseYes.CheckedChanged += new System.EventHandler(this.CheckBoxDriverLicense_CheckedChanged);
			// 
			// checkBoxDriverLicenseNo
			// 
			this.checkBoxDriverLicenseNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxDriverLicenseNo.AutoSize = true;
			this.checkBoxDriverLicenseNo.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxDriverLicenseNo.Checked = true;
			this.checkBoxDriverLicenseNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDriverLicenseNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDriverLicenseNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxDriverLicenseNo.ForeColor = System.Drawing.Color.Black;
			this.checkBoxDriverLicenseNo.Location = new System.Drawing.Point(501, 464);
			this.checkBoxDriverLicenseNo.Name = "checkBoxDriverLicenseNo";
			this.checkBoxDriverLicenseNo.Size = new System.Drawing.Size(53, 29);
			this.checkBoxDriverLicenseNo.TabIndex = 18;
			this.checkBoxDriverLicenseNo.Text = "Ні";
			this.checkBoxDriverLicenseNo.UseVisualStyleBackColor = false;
			this.checkBoxDriverLicenseNo.CheckedChanged += new System.EventHandler(this.CheckBoxDriverLicense_CheckedChanged);
			// 
			// labelDriverLicense
			// 
			this.labelDriverLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelDriverLicense.AutoSize = true;
			this.labelDriverLicense.BackColor = System.Drawing.Color.Transparent;
			this.labelDriverLicense.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDriverLicense.ForeColor = System.Drawing.Color.Black;
			this.labelDriverLicense.Location = new System.Drawing.Point(12, 460);
			this.labelDriverLicense.Name = "labelDriverLicense";
			this.labelDriverLicense.Size = new System.Drawing.Size(356, 32);
			this.labelDriverLicense.TabIndex = 17;
			this.labelDriverLicense.Text = "Мати посвідчення водія:";
			// 
			// checkBoxBusinessTripYes
			// 
			this.checkBoxBusinessTripYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxBusinessTripYes.AutoSize = true;
			this.checkBoxBusinessTripYes.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxBusinessTripYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxBusinessTripYes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxBusinessTripYes.ForeColor = System.Drawing.Color.Black;
			this.checkBoxBusinessTripYes.Location = new System.Drawing.Point(601, 644);
			this.checkBoxBusinessTripYes.Name = "checkBoxBusinessTripYes";
			this.checkBoxBusinessTripYes.Size = new System.Drawing.Size(69, 29);
			this.checkBoxBusinessTripYes.TabIndex = 28;
			this.checkBoxBusinessTripYes.Text = "Так";
			this.checkBoxBusinessTripYes.UseVisualStyleBackColor = false;
			this.checkBoxBusinessTripYes.CheckedChanged += new System.EventHandler(this.CheckBoxBusinessTrip_CheckedChanged);
			// 
			// checkBoxBusinessTripNo
			// 
			this.checkBoxBusinessTripNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxBusinessTripNo.AutoSize = true;
			this.checkBoxBusinessTripNo.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxBusinessTripNo.Checked = true;
			this.checkBoxBusinessTripNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxBusinessTripNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxBusinessTripNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxBusinessTripNo.ForeColor = System.Drawing.Color.Black;
			this.checkBoxBusinessTripNo.Location = new System.Drawing.Point(501, 644);
			this.checkBoxBusinessTripNo.Name = "checkBoxBusinessTripNo";
			this.checkBoxBusinessTripNo.Size = new System.Drawing.Size(53, 29);
			this.checkBoxBusinessTripNo.TabIndex = 27;
			this.checkBoxBusinessTripNo.Text = "Ні";
			this.checkBoxBusinessTripNo.UseVisualStyleBackColor = false;
			this.checkBoxBusinessTripNo.CheckedChanged += new System.EventHandler(this.CheckBoxBusinessTrip_CheckedChanged);
			// 
			// labelBusinessTrip
			// 
			this.labelBusinessTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelBusinessTrip.AutoSize = true;
			this.labelBusinessTrip.BackColor = System.Drawing.Color.Transparent;
			this.labelBusinessTrip.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBusinessTrip.ForeColor = System.Drawing.Color.Black;
			this.labelBusinessTrip.Location = new System.Drawing.Point(12, 640);
			this.labelBusinessTrip.Name = "labelBusinessTrip";
			this.labelBusinessTrip.Size = new System.Drawing.Size(431, 32);
			this.labelBusinessTrip.TabIndex = 26;
			this.labelBusinessTrip.Text = "Мати можливість відряджень:";
			// 
			// checkBoxNoDrinkAlcoholYes
			// 
			this.checkBoxNoDrinkAlcoholYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNoDrinkAlcoholYes.AutoSize = true;
			this.checkBoxNoDrinkAlcoholYes.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxNoDrinkAlcoholYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNoDrinkAlcoholYes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxNoDrinkAlcoholYes.ForeColor = System.Drawing.Color.Black;
			this.checkBoxNoDrinkAlcoholYes.Location = new System.Drawing.Point(601, 584);
			this.checkBoxNoDrinkAlcoholYes.Name = "checkBoxNoDrinkAlcoholYes";
			this.checkBoxNoDrinkAlcoholYes.Size = new System.Drawing.Size(69, 29);
			this.checkBoxNoDrinkAlcoholYes.TabIndex = 25;
			this.checkBoxNoDrinkAlcoholYes.Text = "Так";
			this.checkBoxNoDrinkAlcoholYes.UseVisualStyleBackColor = false;
			this.checkBoxNoDrinkAlcoholYes.CheckedChanged += new System.EventHandler(this.CheckBoxNoDrinkAlcohol_CheckedChanged);
			// 
			// checkBoxNoDrinkAlcoholNo
			// 
			this.checkBoxNoDrinkAlcoholNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNoDrinkAlcoholNo.AutoSize = true;
			this.checkBoxNoDrinkAlcoholNo.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxNoDrinkAlcoholNo.Checked = true;
			this.checkBoxNoDrinkAlcoholNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxNoDrinkAlcoholNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNoDrinkAlcoholNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxNoDrinkAlcoholNo.ForeColor = System.Drawing.Color.Black;
			this.checkBoxNoDrinkAlcoholNo.Location = new System.Drawing.Point(501, 584);
			this.checkBoxNoDrinkAlcoholNo.Name = "checkBoxNoDrinkAlcoholNo";
			this.checkBoxNoDrinkAlcoholNo.Size = new System.Drawing.Size(53, 29);
			this.checkBoxNoDrinkAlcoholNo.TabIndex = 24;
			this.checkBoxNoDrinkAlcoholNo.Text = "Ні";
			this.checkBoxNoDrinkAlcoholNo.UseVisualStyleBackColor = false;
			this.checkBoxNoDrinkAlcoholNo.CheckedChanged += new System.EventHandler(this.CheckBoxNoDrinkAlcohol_CheckedChanged);
			// 
			// labelNoDrinkAlcohol
			// 
			this.labelNoDrinkAlcohol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelNoDrinkAlcohol.AutoSize = true;
			this.labelNoDrinkAlcohol.BackColor = System.Drawing.Color.Transparent;
			this.labelNoDrinkAlcohol.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoDrinkAlcohol.ForeColor = System.Drawing.Color.Black;
			this.labelNoDrinkAlcohol.Location = new System.Drawing.Point(12, 580);
			this.labelNoDrinkAlcohol.Name = "labelNoDrinkAlcohol";
			this.labelNoDrinkAlcohol.Size = new System.Drawing.Size(326, 32);
			this.labelNoDrinkAlcohol.TabIndex = 23;
			this.labelNoDrinkAlcohol.Text = "НЕ вживати алкоголь:";
			// 
			// checkBoxNoSmokerYes
			// 
			this.checkBoxNoSmokerYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNoSmokerYes.AutoSize = true;
			this.checkBoxNoSmokerYes.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxNoSmokerYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNoSmokerYes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxNoSmokerYes.ForeColor = System.Drawing.Color.Black;
			this.checkBoxNoSmokerYes.Location = new System.Drawing.Point(601, 524);
			this.checkBoxNoSmokerYes.Name = "checkBoxNoSmokerYes";
			this.checkBoxNoSmokerYes.Size = new System.Drawing.Size(69, 29);
			this.checkBoxNoSmokerYes.TabIndex = 22;
			this.checkBoxNoSmokerYes.Text = "Так";
			this.checkBoxNoSmokerYes.UseVisualStyleBackColor = false;
			this.checkBoxNoSmokerYes.CheckedChanged += new System.EventHandler(this.CheckBoxNoSmoker_CheckedChanged);
			// 
			// checkBoxNoSmokerNo
			// 
			this.checkBoxNoSmokerNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNoSmokerNo.AutoSize = true;
			this.checkBoxNoSmokerNo.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxNoSmokerNo.Checked = true;
			this.checkBoxNoSmokerNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxNoSmokerNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNoSmokerNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxNoSmokerNo.ForeColor = System.Drawing.Color.Black;
			this.checkBoxNoSmokerNo.Location = new System.Drawing.Point(501, 524);
			this.checkBoxNoSmokerNo.Name = "checkBoxNoSmokerNo";
			this.checkBoxNoSmokerNo.Size = new System.Drawing.Size(53, 29);
			this.checkBoxNoSmokerNo.TabIndex = 21;
			this.checkBoxNoSmokerNo.Text = "Ні";
			this.checkBoxNoSmokerNo.UseVisualStyleBackColor = false;
			this.checkBoxNoSmokerNo.CheckedChanged += new System.EventHandler(this.CheckBoxNoSmoker_CheckedChanged);
			// 
			// labelNoSmoker
			// 
			this.labelNoSmoker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelNoSmoker.AutoSize = true;
			this.labelNoSmoker.BackColor = System.Drawing.Color.Transparent;
			this.labelNoSmoker.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoSmoker.ForeColor = System.Drawing.Color.Black;
			this.labelNoSmoker.Location = new System.Drawing.Point(12, 520);
			this.labelNoSmoker.Name = "labelNoSmoker";
			this.labelNoSmoker.Size = new System.Drawing.Size(169, 32);
			this.labelNoSmoker.TabIndex = 20;
			this.labelNoSmoker.Text = "НЕ курити:";
			// 
			// checkBoxStudentYes
			// 
			this.checkBoxStudentYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxStudentYes.AutoSize = true;
			this.checkBoxStudentYes.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxStudentYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxStudentYes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxStudentYes.ForeColor = System.Drawing.Color.Black;
			this.checkBoxStudentYes.Location = new System.Drawing.Point(601, 704);
			this.checkBoxStudentYes.Name = "checkBoxStudentYes";
			this.checkBoxStudentYes.Size = new System.Drawing.Size(69, 29);
			this.checkBoxStudentYes.TabIndex = 31;
			this.checkBoxStudentYes.Text = "Так";
			this.checkBoxStudentYes.UseVisualStyleBackColor = false;
			this.checkBoxStudentYes.CheckedChanged += new System.EventHandler(this.CheckBoxStudent_CheckedChanged);
			// 
			// checkBoxStudentNo
			// 
			this.checkBoxStudentNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxStudentNo.AutoSize = true;
			this.checkBoxStudentNo.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxStudentNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxStudentNo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxStudentNo.ForeColor = System.Drawing.Color.Black;
			this.checkBoxStudentNo.Location = new System.Drawing.Point(501, 704);
			this.checkBoxStudentNo.Name = "checkBoxStudentNo";
			this.checkBoxStudentNo.Size = new System.Drawing.Size(53, 29);
			this.checkBoxStudentNo.TabIndex = 30;
			this.checkBoxStudentNo.Text = "Ні";
			this.checkBoxStudentNo.UseVisualStyleBackColor = false;
			this.checkBoxStudentNo.CheckedChanged += new System.EventHandler(this.CheckBoxStudent_CheckedChanged);
			// 
			// labelStudent
			// 
			this.labelStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelStudent.AutoSize = true;
			this.labelStudent.BackColor = System.Drawing.Color.Transparent;
			this.labelStudent.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStudent.ForeColor = System.Drawing.Color.Black;
			this.labelStudent.Location = new System.Drawing.Point(12, 700);
			this.labelStudent.Name = "labelStudent";
			this.labelStudent.Size = new System.Drawing.Size(242, 32);
			this.labelStudent.TabIndex = 29;
			this.labelStudent.Text = "Бути студентом:";
			// 
			// checkBoxStudentNull
			// 
			this.checkBoxStudentNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxStudentNull.AutoSize = true;
			this.checkBoxStudentNull.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxStudentNull.Checked = true;
			this.checkBoxStudentNull.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxStudentNull.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxStudentNull.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxStudentNull.ForeColor = System.Drawing.Color.Black;
			this.checkBoxStudentNull.Location = new System.Drawing.Point(701, 704);
			this.checkBoxStudentNull.Name = "checkBoxStudentNull";
			this.checkBoxStudentNull.Size = new System.Drawing.Size(128, 29);
			this.checkBoxStudentNull.TabIndex = 32;
			this.checkBoxStudentNull.Text = "Все одно";
			this.checkBoxStudentNull.UseVisualStyleBackColor = false;
			this.checkBoxStudentNull.CheckedChanged += new System.EventHandler(this.CheckBoxStudent_CheckedChanged);
			// 
			// labelEducationDegree
			// 
			this.labelEducationDegree.AutoSize = true;
			this.labelEducationDegree.BackColor = System.Drawing.Color.Transparent;
			this.labelEducationDegree.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEducationDegree.ForeColor = System.Drawing.Color.Black;
			this.labelEducationDegree.Location = new System.Drawing.Point(12, 252);
			this.labelEducationDegree.Name = "labelEducationDegree";
			this.labelEducationDegree.Size = new System.Drawing.Size(409, 32);
			this.labelEducationDegree.TabIndex = 9;
			this.labelEducationDegree.Text = "Мати ступінь/ступені освіти:";
			// 
			// listBoxDegrees
			// 
			this.listBoxDegrees.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listBoxDegrees.DataSource = this.educationDegreeBindingSource;
			this.listBoxDegrees.DisplayMember = "degree";
			this.listBoxDegrees.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxDegrees.FormattingEnabled = true;
			this.listBoxDegrees.HorizontalScrollbar = true;
			this.listBoxDegrees.ItemHeight = 28;
			this.listBoxDegrees.Location = new System.Drawing.Point(427, 250);
			this.listBoxDegrees.Name = "listBoxDegrees";
			this.listBoxDegrees.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBoxDegrees.Size = new System.Drawing.Size(324, 88);
			this.listBoxDegrees.TabIndex = 10;
			this.listBoxDegrees.ValueMember = "id";
			this.listBoxDegrees.SelectedIndexChanged += new System.EventHandler(this.ListBoxDegrees_SelectedIndexChanged);
			// 
			// educationDegreeBindingSource
			// 
			this.educationDegreeBindingSource.DataMember = "Education_Degree";
			this.educationDegreeBindingSource.DataSource = this.recruitmentDBDataSet;
			// 
			// recruitmentDBDataSet
			// 
			this.recruitmentDBDataSet.DataSetName = "RecruitmentDBDataSet";
			this.recruitmentDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// education_DegreeTableAdapter
			// 
			this.education_DegreeTableAdapter.ClearBeforeFill = true;
			// 
			// buttonCreate
			// 
			this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreate.AutoSize = true;
			this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonCreate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCreate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCreate.Location = new System.Drawing.Point(1072, 704);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(175, 40);
			this.buttonCreate.TabIndex = 33;
			this.buttonCreate.Text = "Створити";
			this.buttonCreate.UseVisualStyleBackColor = false;
			this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// labelCityInfo
			// 
			this.labelCityInfo.AutoSize = true;
			this.labelCityInfo.BackColor = System.Drawing.Color.Transparent;
			this.labelCityInfo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCityInfo.ForeColor = System.Drawing.Color.Black;
			this.labelCityInfo.Location = new System.Drawing.Point(757, 28);
			this.labelCityInfo.Name = "labelCityInfo";
			this.labelCityInfo.Size = new System.Drawing.Size(313, 18);
			this.labelCityInfo.TabIndex = 2;
			this.labelCityInfo.Text = "(залиште пустим якщо немає вимог)";
			// 
			// RequirementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 761);
			this.Controls.Add(this.labelCityInfo);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.listBoxDegrees);
			this.Controls.Add(this.labelEducationDegree);
			this.Controls.Add(this.checkBoxStudentNull);
			this.Controls.Add(this.checkBoxStudentYes);
			this.Controls.Add(this.checkBoxStudentNo);
			this.Controls.Add(this.labelStudent);
			this.Controls.Add(this.checkBoxBusinessTripYes);
			this.Controls.Add(this.checkBoxBusinessTripNo);
			this.Controls.Add(this.labelBusinessTrip);
			this.Controls.Add(this.checkBoxNoDrinkAlcoholYes);
			this.Controls.Add(this.checkBoxNoDrinkAlcoholNo);
			this.Controls.Add(this.labelNoDrinkAlcohol);
			this.Controls.Add(this.checkBoxNoSmokerYes);
			this.Controls.Add(this.checkBoxNoSmokerNo);
			this.Controls.Add(this.labelNoSmoker);
			this.Controls.Add(this.checkBoxDriverLicenseYes);
			this.Controls.Add(this.checkBoxDriverLicenseNo);
			this.Controls.Add(this.labelDriverLicense);
			this.Controls.Add(this.checkBoxNoChronicDiseasesYes);
			this.Controls.Add(this.checkBoxNoChronicDiseasesNo);
			this.Controls.Add(this.labelNoChronicDiseases);
			this.Controls.Add(this.labelCandidateMustHave);
			this.Controls.Add(this.checkBoxDiplomaAll);
			this.Controls.Add(this.numericUpDownExpMin);
			this.Controls.Add(this.labelExpMin);
			this.Controls.Add(this.numericUpDownAgeMax);
			this.Controls.Add(this.labelAgeMax);
			this.Controls.Add(this.numericUpDownAgeMin);
			this.Controls.Add(this.labelAgeMin);
			this.Controls.Add(this.textBoxCity);
			this.Controls.Add(this.labelCity);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RequirementForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вимоги";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RequirementForm_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.educationDegreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.NumericUpDown numericUpDownAgeMin;
        private System.Windows.Forms.Label labelAgeMin;
        private System.Windows.Forms.NumericUpDown numericUpDownAgeMax;
        private System.Windows.Forms.Label labelAgeMax;
        private System.Windows.Forms.NumericUpDown numericUpDownExpMin;
        private System.Windows.Forms.Label labelExpMin;
        private System.Windows.Forms.CheckBox checkBoxDiplomaAll;
        private System.Windows.Forms.Label labelCandidateMustHave;
        private System.Windows.Forms.CheckBox checkBoxNoChronicDiseasesYes;
        private System.Windows.Forms.CheckBox checkBoxNoChronicDiseasesNo;
        private System.Windows.Forms.Label labelNoChronicDiseases;
        private System.Windows.Forms.CheckBox checkBoxDriverLicenseYes;
        private System.Windows.Forms.CheckBox checkBoxDriverLicenseNo;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.CheckBox checkBoxBusinessTripYes;
        private System.Windows.Forms.CheckBox checkBoxBusinessTripNo;
        private System.Windows.Forms.Label labelBusinessTrip;
        private System.Windows.Forms.CheckBox checkBoxNoDrinkAlcoholYes;
        private System.Windows.Forms.CheckBox checkBoxNoDrinkAlcoholNo;
        private System.Windows.Forms.Label labelNoDrinkAlcohol;
        private System.Windows.Forms.CheckBox checkBoxNoSmokerYes;
        private System.Windows.Forms.CheckBox checkBoxNoSmokerNo;
        private System.Windows.Forms.Label labelNoSmoker;
        private System.Windows.Forms.CheckBox checkBoxStudentYes;
        private System.Windows.Forms.CheckBox checkBoxStudentNo;
        private System.Windows.Forms.Label labelStudent;
        private System.Windows.Forms.CheckBox checkBoxStudentNull;
        private System.Windows.Forms.Label labelEducationDegree;
        private System.Windows.Forms.ListBox listBoxDegrees;
        private RecruitmentDB recruitmentDBDataSet;
        private System.Windows.Forms.BindingSource educationDegreeBindingSource;
        private RecruitmentDBTableAdapters.Education_DegreeTableAdapter education_DegreeTableAdapter;
        private System.Windows.Forms.Label labelCityInfo;
        private System.Windows.Forms.Button buttonCreate;
    }
}