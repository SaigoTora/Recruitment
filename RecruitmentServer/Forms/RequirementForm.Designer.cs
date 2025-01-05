namespace RecruitmentServer.Forms
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequirementForm));
			this.labelCity = new System.Windows.Forms.Label();
			this.numericUpDownAgeMin = new System.Windows.Forms.NumericUpDown();
			this.labelAge = new System.Windows.Forms.Label();
			this.numericUpDownAgeMax = new System.Windows.Forms.NumericUpDown();
			this.labelAgeMax = new System.Windows.Forms.Label();
			this.numericUpDownExpMin = new System.Windows.Forms.NumericUpDown();
			this.labelExpMin = new System.Windows.Forms.Label();
			this.labelCandidateMustHave = new System.Windows.Forms.Label();
			this.labelNoChronicDiseases = new System.Windows.Forms.Label();
			this.labelDriverLicense = new System.Windows.Forms.Label();
			this.labelBusinessTrip = new System.Windows.Forms.Label();
			this.labelNoDrinkAlcohol = new System.Windows.Forms.Label();
			this.labelNoSmoker = new System.Windows.Forms.Label();
			this.labelStudent = new System.Windows.Forms.Label();
			this.labelEducationDegree = new System.Windows.Forms.Label();
			this.listBoxDegrees = new System.Windows.Forms.ListBox();
			this.educationDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.recruitmentDBDataSet = new RecruitmentServer.RecruitmentDB();
			this.education_DegreeTableAdapter = new RecruitmentServer.RecruitmentDBTableAdapters.Education_DegreeTableAdapter();
			this.labelCityInfo = new System.Windows.Forms.Label();
			this.buttonCreate = new Guna.UI2.WinForms.Guna2GradientButton();
			this.textBoxCity = new Guna.UI2.WinForms.Guna2TextBox();
			this.checkBoxDiplomaAll = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			this.labelDiplomaAll = new System.Windows.Forms.Label();
			this.groupBoxNoChronicDiseases = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelNoChronicDiseasesYes = new System.Windows.Forms.Label();
			this.labelNoChronicDiseasesNo = new System.Windows.Forms.Label();
			this.radioButtonNoChronicDiseasesYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonNoChronicDiseasesNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.groupBoxDriverLicense = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelDriverLicenseYes = new System.Windows.Forms.Label();
			this.labelDriverLicenseNo = new System.Windows.Forms.Label();
			this.radioButtonDriverLicenseYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonDriverLicenseNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.groupBoxNoSmoker = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelNoSmokerYes = new System.Windows.Forms.Label();
			this.labelNoSmokerNo = new System.Windows.Forms.Label();
			this.radioButtonNoSmokerYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonNoSmokerNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.groupBoxNoDrinkAlcohol = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelNoDrinkAlcoholYes = new System.Windows.Forms.Label();
			this.labelNoDrinkAlcoholNo = new System.Windows.Forms.Label();
			this.radioButtonNoDrinkAlcoholYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonNoDrinkAlcoholNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.groupBoxBusinessTrip = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelBusinessTripYes = new System.Windows.Forms.Label();
			this.labelBusinessTripNo = new System.Windows.Forms.Label();
			this.radioButtonBusinessTripYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonBusinessTripNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonStudentNull = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.labelStudentNull = new System.Windows.Forms.Label();
			this.groupBoxStudent = new Guna.UI2.WinForms.Guna2GroupBox();
			this.labelStudentYes = new System.Windows.Forms.Label();
			this.labelStudentNo = new System.Windows.Forms.Label();
			this.radioButtonStudentYes = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.radioButtonStudentNo = new Guna.UI2.WinForms.Guna2CustomRadioButton();
			this.labelAgeMin = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.educationDegreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).BeginInit();
			this.groupBoxNoChronicDiseases.SuspendLayout();
			this.groupBoxDriverLicense.SuspendLayout();
			this.groupBoxNoSmoker.SuspendLayout();
			this.groupBoxNoDrinkAlcohol.SuspendLayout();
			this.groupBoxBusinessTrip.SuspendLayout();
			this.groupBoxStudent.SuspendLayout();
			this.SuspendLayout();
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
			this.numericUpDownAgeMin.Location = new System.Drawing.Point(170, 70);
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
			this.numericUpDownAgeMin.Size = new System.Drawing.Size(60, 36);
			this.numericUpDownAgeMin.TabIndex = 5;
			this.numericUpDownAgeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownAgeMin.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
			// 
			// labelAge
			// 
			this.labelAge.AutoSize = true;
			this.labelAge.BackColor = System.Drawing.Color.Transparent;
			this.labelAge.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAge.ForeColor = System.Drawing.Color.Black;
			this.labelAge.Location = new System.Drawing.Point(12, 72);
			this.labelAge.Name = "labelAge";
			this.labelAge.Size = new System.Drawing.Size(68, 32);
			this.labelAge.TabIndex = 3;
			this.labelAge.Text = "Вік:";
			// 
			// numericUpDownAgeMax
			// 
			this.numericUpDownAgeMax.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownAgeMax.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownAgeMax.Location = new System.Drawing.Point(303, 70);
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
			this.numericUpDownAgeMax.Size = new System.Drawing.Size(60, 36);
			this.numericUpDownAgeMax.TabIndex = 7;
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
			this.labelAgeMax.Location = new System.Drawing.Point(250, 72);
			this.labelAgeMax.Name = "labelAgeMax";
			this.labelAgeMax.Size = new System.Drawing.Size(47, 32);
			this.labelAgeMax.TabIndex = 6;
			this.labelAgeMax.Text = "до";
			// 
			// numericUpDownExpMin
			// 
			this.numericUpDownExpMin.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownExpMin.ForeColor = System.Drawing.Color.Black;
			this.numericUpDownExpMin.Location = new System.Drawing.Point(574, 130);
			this.numericUpDownExpMin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numericUpDownExpMin.Name = "numericUpDownExpMin";
			this.numericUpDownExpMin.Size = new System.Drawing.Size(90, 36);
			this.numericUpDownExpMin.TabIndex = 9;
			this.numericUpDownExpMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelExpMin
			// 
			this.labelExpMin.AutoSize = true;
			this.labelExpMin.BackColor = System.Drawing.Color.Transparent;
			this.labelExpMin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExpMin.ForeColor = System.Drawing.Color.Black;
			this.labelExpMin.Location = new System.Drawing.Point(12, 132);
			this.labelExpMin.Name = "labelExpMin";
			this.labelExpMin.Size = new System.Drawing.Size(556, 32);
			this.labelExpMin.TabIndex = 8;
			this.labelExpMin.Text = "Мінімальний досвід роботи(в місяцях):";
			// 
			// labelCandidateMustHave
			// 
			this.labelCandidateMustHave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelCandidateMustHave.AutoSize = true;
			this.labelCandidateMustHave.BackColor = System.Drawing.Color.Transparent;
			this.labelCandidateMustHave.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCandidateMustHave.ForeColor = System.Drawing.Color.Black;
			this.labelCandidateMustHave.Location = new System.Drawing.Point(12, 280);
			this.labelCandidateMustHave.Name = "labelCandidateMustHave";
			this.labelCandidateMustHave.Size = new System.Drawing.Size(304, 35);
			this.labelCandidateMustHave.TabIndex = 14;
			this.labelCandidateMustHave.Text = "Кандидат повинен:";
			// 
			// labelNoChronicDiseases
			// 
			this.labelNoChronicDiseases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelNoChronicDiseases.AutoSize = true;
			this.labelNoChronicDiseases.BackColor = System.Drawing.Color.Transparent;
			this.labelNoChronicDiseases.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoChronicDiseases.ForeColor = System.Drawing.Color.Black;
			this.labelNoChronicDiseases.Location = new System.Drawing.Point(12, 580);
			this.labelNoChronicDiseases.Name = "labelNoChronicDiseases";
			this.labelNoChronicDiseases.Size = new System.Drawing.Size(479, 32);
			this.labelNoChronicDiseases.TabIndex = 23;
			this.labelNoChronicDiseases.Text = "НЕ мати хронічних захворювань:";
			// 
			// labelDriverLicense
			// 
			this.labelDriverLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelDriverLicense.AutoSize = true;
			this.labelDriverLicense.BackColor = System.Drawing.Color.Transparent;
			this.labelDriverLicense.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDriverLicense.ForeColor = System.Drawing.Color.Black;
			this.labelDriverLicense.Location = new System.Drawing.Point(12, 400);
			this.labelDriverLicense.Name = "labelDriverLicense";
			this.labelDriverLicense.Size = new System.Drawing.Size(356, 32);
			this.labelDriverLicense.TabIndex = 17;
			this.labelDriverLicense.Text = "Мати посвідчення водія:";
			// 
			// labelBusinessTrip
			// 
			this.labelBusinessTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelBusinessTrip.AutoSize = true;
			this.labelBusinessTrip.BackColor = System.Drawing.Color.Transparent;
			this.labelBusinessTrip.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBusinessTrip.ForeColor = System.Drawing.Color.Black;
			this.labelBusinessTrip.Location = new System.Drawing.Point(12, 340);
			this.labelBusinessTrip.Name = "labelBusinessTrip";
			this.labelBusinessTrip.Size = new System.Drawing.Size(431, 32);
			this.labelBusinessTrip.TabIndex = 15;
			this.labelBusinessTrip.Text = "Мати можливість відряджень:";
			// 
			// labelNoDrinkAlcohol
			// 
			this.labelNoDrinkAlcohol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelNoDrinkAlcohol.AutoSize = true;
			this.labelNoDrinkAlcohol.BackColor = System.Drawing.Color.Transparent;
			this.labelNoDrinkAlcohol.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoDrinkAlcohol.ForeColor = System.Drawing.Color.Black;
			this.labelNoDrinkAlcohol.Location = new System.Drawing.Point(12, 520);
			this.labelNoDrinkAlcohol.Name = "labelNoDrinkAlcohol";
			this.labelNoDrinkAlcohol.Size = new System.Drawing.Size(326, 32);
			this.labelNoDrinkAlcohol.TabIndex = 21;
			this.labelNoDrinkAlcohol.Text = "НЕ вживати алкоголь:";
			// 
			// labelNoSmoker
			// 
			this.labelNoSmoker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelNoSmoker.AutoSize = true;
			this.labelNoSmoker.BackColor = System.Drawing.Color.Transparent;
			this.labelNoSmoker.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoSmoker.ForeColor = System.Drawing.Color.Black;
			this.labelNoSmoker.Location = new System.Drawing.Point(12, 460);
			this.labelNoSmoker.Name = "labelNoSmoker";
			this.labelNoSmoker.Size = new System.Drawing.Size(169, 32);
			this.labelNoSmoker.TabIndex = 19;
			this.labelNoSmoker.Text = "НЕ курити:";
			// 
			// labelStudent
			// 
			this.labelStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelStudent.AutoSize = true;
			this.labelStudent.BackColor = System.Drawing.Color.Transparent;
			this.labelStudent.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStudent.ForeColor = System.Drawing.Color.Black;
			this.labelStudent.Location = new System.Drawing.Point(12, 640);
			this.labelStudent.Name = "labelStudent";
			this.labelStudent.Size = new System.Drawing.Size(242, 32);
			this.labelStudent.TabIndex = 25;
			this.labelStudent.Text = "Бути студентом:";
			// 
			// labelEducationDegree
			// 
			this.labelEducationDegree.AutoSize = true;
			this.labelEducationDegree.BackColor = System.Drawing.Color.Transparent;
			this.labelEducationDegree.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEducationDegree.ForeColor = System.Drawing.Color.Black;
			this.labelEducationDegree.Location = new System.Drawing.Point(12, 192);
			this.labelEducationDegree.Name = "labelEducationDegree";
			this.labelEducationDegree.Size = new System.Drawing.Size(409, 32);
			this.labelEducationDegree.TabIndex = 10;
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
			this.listBoxDegrees.Location = new System.Drawing.Point(427, 190);
			this.listBoxDegrees.Name = "listBoxDegrees";
			this.listBoxDegrees.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBoxDegrees.Size = new System.Drawing.Size(324, 88);
			this.listBoxDegrees.TabIndex = 11;
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
			// labelCityInfo
			// 
			this.labelCityInfo.AutoSize = true;
			this.labelCityInfo.BackColor = System.Drawing.Color.Transparent;
			this.labelCityInfo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCityInfo.ForeColor = System.Drawing.Color.Black;
			this.labelCityInfo.Location = new System.Drawing.Point(770, 28);
			this.labelCityInfo.Name = "labelCityInfo";
			this.labelCityInfo.Size = new System.Drawing.Size(313, 18);
			this.labelCityInfo.TabIndex = 2;
			this.labelCityInfo.Text = "(залиште пустим якщо немає вимог)";
			// 
			// buttonCreate
			// 
			this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreate.Animated = true;
			this.buttonCreate.BackColor = System.Drawing.Color.Transparent;
			this.buttonCreate.BorderRadius = 7;
			this.buttonCreate.BorderThickness = 1;
			this.buttonCreate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCreate.DisabledState.BorderColor = System.Drawing.Color.Black;
			this.buttonCreate.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
			this.buttonCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCreate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.buttonCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(95)))));
			this.buttonCreate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
			this.buttonCreate.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.buttonCreate.ForeColor = System.Drawing.Color.Black;
			this.buttonCreate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonCreate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(243)))), ((int)(((byte)(103)))));
			this.buttonCreate.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(185)))), ((int)(((byte)(92)))));
			this.buttonCreate.Location = new System.Drawing.Point(963, 633);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.PressedColor = System.Drawing.Color.White;
			this.buttonCreate.PressedDepth = 20;
			this.buttonCreate.Size = new System.Drawing.Size(175, 40);
			this.buttonCreate.TabIndex = 27;
			this.buttonCreate.TabStop = false;
			this.buttonCreate.Text = "Створити";
			this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// textBoxCity
			// 
			this.textBoxCity.Animated = true;
			this.textBoxCity.AutoScroll = true;
			this.textBoxCity.BackColor = System.Drawing.Color.Transparent;
			this.textBoxCity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.textBoxCity.BorderRadius = 10;
			this.textBoxCity.BorderThickness = 2;
			this.textBoxCity.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxCity.DefaultText = "";
			this.textBoxCity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxCity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxCity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxCity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxCity.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCity.ForeColor = System.Drawing.Color.Black;
			this.textBoxCity.HoverState.BorderColor = System.Drawing.Color.Black;
			this.textBoxCity.Location = new System.Drawing.Point(464, 10);
			this.textBoxCity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.textBoxCity.MaxLength = 64;
			this.textBoxCity.Name = "textBoxCity";
			this.textBoxCity.PasswordChar = '\0';
			this.textBoxCity.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxCity.PlaceholderText = "";
			this.textBoxCity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxCity.SelectedText = "";
			this.textBoxCity.Size = new System.Drawing.Size(300, 36);
			this.textBoxCity.TabIndex = 1;
			this.textBoxCity.Tag = "";
			this.textBoxCity.TextOffset = new System.Drawing.Point(3, 0);
			// 
			// checkBoxDiplomaAll
			// 
			this.checkBoxDiplomaAll.Animated = true;
			this.checkBoxDiplomaAll.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxDiplomaAll.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.checkBoxDiplomaAll.CheckedState.BorderRadius = 2;
			this.checkBoxDiplomaAll.CheckedState.BorderThickness = 1;
			this.checkBoxDiplomaAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.checkBoxDiplomaAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDiplomaAll.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxDiplomaAll.ForeColor = System.Drawing.Color.Transparent;
			this.checkBoxDiplomaAll.Location = new System.Drawing.Point(913, 195);
			this.checkBoxDiplomaAll.Name = "checkBoxDiplomaAll";
			this.checkBoxDiplomaAll.ShadowDecoration.BorderRadius = 2;
			this.checkBoxDiplomaAll.ShadowDecoration.Depth = 150;
			this.checkBoxDiplomaAll.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
			this.checkBoxDiplomaAll.Size = new System.Drawing.Size(17, 17);
			this.checkBoxDiplomaAll.TabIndex = 13;
			this.checkBoxDiplomaAll.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.checkBoxDiplomaAll.UncheckedState.BorderRadius = 2;
			this.checkBoxDiplomaAll.UncheckedState.BorderThickness = 1;
			this.checkBoxDiplomaAll.UncheckedState.FillColor = System.Drawing.Color.Silver;
			this.checkBoxDiplomaAll.UseTransparentBackground = true;
			this.checkBoxDiplomaAll.CheckedChanged += new System.EventHandler(this.CheckBoxDiplomaAll_CheckedChanged);
			// 
			// labelDiplomaAll
			// 
			this.labelDiplomaAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDiplomaAll.AutoSize = true;
			this.labelDiplomaAll.BackColor = System.Drawing.Color.Transparent;
			this.labelDiplomaAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelDiplomaAll.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDiplomaAll.ForeColor = System.Drawing.Color.Black;
			this.labelDiplomaAll.Location = new System.Drawing.Point(760, 190);
			this.labelDiplomaAll.Name = "labelDiplomaAll";
			this.labelDiplomaAll.Size = new System.Drawing.Size(147, 25);
			this.labelDiplomaAll.TabIndex = 12;
			this.labelDiplomaAll.Text = "Вибрати всі:";
			this.labelDiplomaAll.Click += new System.EventHandler(this.LabelDiplomaAll_Click);
			// 
			// groupBoxNoChronicDiseases
			// 
			this.groupBoxNoChronicDiseases.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxNoChronicDiseases.Controls.Add(this.labelNoChronicDiseasesYes);
			this.groupBoxNoChronicDiseases.Controls.Add(this.labelNoChronicDiseasesNo);
			this.groupBoxNoChronicDiseases.Controls.Add(this.radioButtonNoChronicDiseasesYes);
			this.groupBoxNoChronicDiseases.Controls.Add(this.radioButtonNoChronicDiseasesNo);
			this.groupBoxNoChronicDiseases.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxNoChronicDiseases.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxNoChronicDiseases.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxNoChronicDiseases.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxNoChronicDiseases.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxNoChronicDiseases.Location = new System.Drawing.Point(500, 580);
			this.groupBoxNoChronicDiseases.Name = "groupBoxNoChronicDiseases";
			this.groupBoxNoChronicDiseases.Size = new System.Drawing.Size(180, 33);
			this.groupBoxNoChronicDiseases.TabIndex = 24;
			this.groupBoxNoChronicDiseases.Tag = "needToMoveParentDown";
			// 
			// labelNoChronicDiseasesYes
			// 
			this.labelNoChronicDiseasesYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoChronicDiseasesYes.AutoSize = true;
			this.labelNoChronicDiseasesYes.BackColor = System.Drawing.Color.Transparent;
			this.labelNoChronicDiseasesYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNoChronicDiseasesYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelNoChronicDiseasesYes.ForeColor = System.Drawing.Color.Black;
			this.labelNoChronicDiseasesYes.Location = new System.Drawing.Point(100, 4);
			this.labelNoChronicDiseasesYes.Name = "labelNoChronicDiseasesYes";
			this.labelNoChronicDiseasesYes.Size = new System.Drawing.Size(50, 25);
			this.labelNoChronicDiseasesYes.TabIndex = 2;
			this.labelNoChronicDiseasesYes.Tag = "fixedPosition";
			this.labelNoChronicDiseasesYes.Text = "Так";
			this.labelNoChronicDiseasesYes.Click += new System.EventHandler(this.LabelNoChronicDiseasesYes_Click);
			// 
			// labelNoChronicDiseasesNo
			// 
			this.labelNoChronicDiseasesNo.AutoSize = true;
			this.labelNoChronicDiseasesNo.BackColor = System.Drawing.Color.Transparent;
			this.labelNoChronicDiseasesNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNoChronicDiseasesNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelNoChronicDiseasesNo.ForeColor = System.Drawing.Color.Black;
			this.labelNoChronicDiseasesNo.Location = new System.Drawing.Point(4, 4);
			this.labelNoChronicDiseasesNo.Name = "labelNoChronicDiseasesNo";
			this.labelNoChronicDiseasesNo.Size = new System.Drawing.Size(34, 25);
			this.labelNoChronicDiseasesNo.TabIndex = 0;
			this.labelNoChronicDiseasesNo.Tag = "fixedPosition";
			this.labelNoChronicDiseasesNo.Text = "Ні";
			this.labelNoChronicDiseasesNo.Click += new System.EventHandler(this.LabelNoChronicDiseasesNo_Click);
			// 
			// radioButtonNoChronicDiseasesYes
			// 
			this.radioButtonNoChronicDiseasesYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonNoChronicDiseasesYes.Animated = true;
			this.radioButtonNoChronicDiseasesYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonNoChronicDiseasesYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoChronicDiseasesYes.CheckedState.BorderThickness = 2;
			this.radioButtonNoChronicDiseasesYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoChronicDiseasesYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonNoChronicDiseasesYes.CheckedState.InnerOffset = 1;
			this.radioButtonNoChronicDiseasesYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNoChronicDiseasesYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonNoChronicDiseasesYes.Name = "radioButtonNoChronicDiseasesYes";
			this.radioButtonNoChronicDiseasesYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonNoChronicDiseasesYes.ShadowDecoration.Depth = 40;
			this.radioButtonNoChronicDiseasesYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonNoChronicDiseasesYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonNoChronicDiseasesYes.TabIndex = 3;
			this.radioButtonNoChronicDiseasesYes.Tag = "fixedPosition";
			this.radioButtonNoChronicDiseasesYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoChronicDiseasesYes.UncheckedState.BorderThickness = 2;
			this.radioButtonNoChronicDiseasesYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoChronicDiseasesYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonNoChronicDiseasesNo
			// 
			this.radioButtonNoChronicDiseasesNo.Animated = true;
			this.radioButtonNoChronicDiseasesNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonNoChronicDiseasesNo.Checked = true;
			this.radioButtonNoChronicDiseasesNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoChronicDiseasesNo.CheckedState.BorderThickness = 2;
			this.radioButtonNoChronicDiseasesNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoChronicDiseasesNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonNoChronicDiseasesNo.CheckedState.InnerOffset = 1;
			this.radioButtonNoChronicDiseasesNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNoChronicDiseasesNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonNoChronicDiseasesNo.Name = "radioButtonNoChronicDiseasesNo";
			this.radioButtonNoChronicDiseasesNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonNoChronicDiseasesNo.ShadowDecoration.Depth = 40;
			this.radioButtonNoChronicDiseasesNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonNoChronicDiseasesNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonNoChronicDiseasesNo.TabIndex = 1;
			this.radioButtonNoChronicDiseasesNo.Tag = "fixedPosition";
			this.radioButtonNoChronicDiseasesNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoChronicDiseasesNo.UncheckedState.BorderThickness = 2;
			this.radioButtonNoChronicDiseasesNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoChronicDiseasesNo.UncheckedState.InnerOffset = 1;
			// 
			// groupBoxDriverLicense
			// 
			this.groupBoxDriverLicense.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxDriverLicense.Controls.Add(this.labelDriverLicenseYes);
			this.groupBoxDriverLicense.Controls.Add(this.labelDriverLicenseNo);
			this.groupBoxDriverLicense.Controls.Add(this.radioButtonDriverLicenseYes);
			this.groupBoxDriverLicense.Controls.Add(this.radioButtonDriverLicenseNo);
			this.groupBoxDriverLicense.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxDriverLicense.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxDriverLicense.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxDriverLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxDriverLicense.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxDriverLicense.Location = new System.Drawing.Point(500, 400);
			this.groupBoxDriverLicense.Name = "groupBoxDriverLicense";
			this.groupBoxDriverLicense.Size = new System.Drawing.Size(180, 33);
			this.groupBoxDriverLicense.TabIndex = 18;
			this.groupBoxDriverLicense.Tag = "needToMoveParentDown";
			// 
			// labelDriverLicenseYes
			// 
			this.labelDriverLicenseYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDriverLicenseYes.AutoSize = true;
			this.labelDriverLicenseYes.BackColor = System.Drawing.Color.Transparent;
			this.labelDriverLicenseYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelDriverLicenseYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelDriverLicenseYes.ForeColor = System.Drawing.Color.Black;
			this.labelDriverLicenseYes.Location = new System.Drawing.Point(100, 4);
			this.labelDriverLicenseYes.Name = "labelDriverLicenseYes";
			this.labelDriverLicenseYes.Size = new System.Drawing.Size(50, 25);
			this.labelDriverLicenseYes.TabIndex = 2;
			this.labelDriverLicenseYes.Tag = "fixedPosition";
			this.labelDriverLicenseYes.Text = "Так";
			this.labelDriverLicenseYes.Click += new System.EventHandler(this.LabelDriverLicenseYes_Click);
			// 
			// labelDriverLicenseNo
			// 
			this.labelDriverLicenseNo.AutoSize = true;
			this.labelDriverLicenseNo.BackColor = System.Drawing.Color.Transparent;
			this.labelDriverLicenseNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelDriverLicenseNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelDriverLicenseNo.ForeColor = System.Drawing.Color.Black;
			this.labelDriverLicenseNo.Location = new System.Drawing.Point(4, 4);
			this.labelDriverLicenseNo.Name = "labelDriverLicenseNo";
			this.labelDriverLicenseNo.Size = new System.Drawing.Size(34, 25);
			this.labelDriverLicenseNo.TabIndex = 0;
			this.labelDriverLicenseNo.Tag = "fixedPosition";
			this.labelDriverLicenseNo.Text = "Ні";
			this.labelDriverLicenseNo.Click += new System.EventHandler(this.LabelDriverLicenseNo_Click);
			// 
			// radioButtonDriverLicenseYes
			// 
			this.radioButtonDriverLicenseYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonDriverLicenseYes.Animated = true;
			this.radioButtonDriverLicenseYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonDriverLicenseYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonDriverLicenseYes.CheckedState.BorderThickness = 2;
			this.radioButtonDriverLicenseYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonDriverLicenseYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonDriverLicenseYes.CheckedState.InnerOffset = 1;
			this.radioButtonDriverLicenseYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonDriverLicenseYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonDriverLicenseYes.Name = "radioButtonDriverLicenseYes";
			this.radioButtonDriverLicenseYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonDriverLicenseYes.ShadowDecoration.Depth = 40;
			this.radioButtonDriverLicenseYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonDriverLicenseYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonDriverLicenseYes.TabIndex = 3;
			this.radioButtonDriverLicenseYes.Tag = "fixedPosition";
			this.radioButtonDriverLicenseYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonDriverLicenseYes.UncheckedState.BorderThickness = 2;
			this.radioButtonDriverLicenseYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonDriverLicenseYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonDriverLicenseNo
			// 
			this.radioButtonDriverLicenseNo.Animated = true;
			this.radioButtonDriverLicenseNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonDriverLicenseNo.Checked = true;
			this.radioButtonDriverLicenseNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonDriverLicenseNo.CheckedState.BorderThickness = 2;
			this.radioButtonDriverLicenseNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonDriverLicenseNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonDriverLicenseNo.CheckedState.InnerOffset = 1;
			this.radioButtonDriverLicenseNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonDriverLicenseNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonDriverLicenseNo.Name = "radioButtonDriverLicenseNo";
			this.radioButtonDriverLicenseNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonDriverLicenseNo.ShadowDecoration.Depth = 40;
			this.radioButtonDriverLicenseNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonDriverLicenseNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonDriverLicenseNo.TabIndex = 1;
			this.radioButtonDriverLicenseNo.Tag = "fixedPosition";
			this.radioButtonDriverLicenseNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonDriverLicenseNo.UncheckedState.BorderThickness = 2;
			this.radioButtonDriverLicenseNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonDriverLicenseNo.UncheckedState.InnerOffset = 1;
			// 
			// groupBoxNoSmoker
			// 
			this.groupBoxNoSmoker.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxNoSmoker.Controls.Add(this.labelNoSmokerYes);
			this.groupBoxNoSmoker.Controls.Add(this.labelNoSmokerNo);
			this.groupBoxNoSmoker.Controls.Add(this.radioButtonNoSmokerYes);
			this.groupBoxNoSmoker.Controls.Add(this.radioButtonNoSmokerNo);
			this.groupBoxNoSmoker.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxNoSmoker.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxNoSmoker.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxNoSmoker.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxNoSmoker.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxNoSmoker.Location = new System.Drawing.Point(500, 460);
			this.groupBoxNoSmoker.Name = "groupBoxNoSmoker";
			this.groupBoxNoSmoker.Size = new System.Drawing.Size(180, 33);
			this.groupBoxNoSmoker.TabIndex = 20;
			this.groupBoxNoSmoker.Tag = "needToMoveParentDown";
			// 
			// labelNoSmokerYes
			// 
			this.labelNoSmokerYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoSmokerYes.AutoSize = true;
			this.labelNoSmokerYes.BackColor = System.Drawing.Color.Transparent;
			this.labelNoSmokerYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNoSmokerYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelNoSmokerYes.ForeColor = System.Drawing.Color.Black;
			this.labelNoSmokerYes.Location = new System.Drawing.Point(100, 4);
			this.labelNoSmokerYes.Name = "labelNoSmokerYes";
			this.labelNoSmokerYes.Size = new System.Drawing.Size(50, 25);
			this.labelNoSmokerYes.TabIndex = 2;
			this.labelNoSmokerYes.Tag = "fixedPosition";
			this.labelNoSmokerYes.Text = "Так";
			this.labelNoSmokerYes.Click += new System.EventHandler(this.LabelNoSmokerYes_Click);
			// 
			// labelNoSmokerNo
			// 
			this.labelNoSmokerNo.AutoSize = true;
			this.labelNoSmokerNo.BackColor = System.Drawing.Color.Transparent;
			this.labelNoSmokerNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNoSmokerNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelNoSmokerNo.ForeColor = System.Drawing.Color.Black;
			this.labelNoSmokerNo.Location = new System.Drawing.Point(4, 4);
			this.labelNoSmokerNo.Name = "labelNoSmokerNo";
			this.labelNoSmokerNo.Size = new System.Drawing.Size(34, 25);
			this.labelNoSmokerNo.TabIndex = 0;
			this.labelNoSmokerNo.Tag = "fixedPosition";
			this.labelNoSmokerNo.Text = "Ні";
			this.labelNoSmokerNo.Click += new System.EventHandler(this.LabelNoSmokerNo_Click);
			// 
			// radioButtonNoSmokerYes
			// 
			this.radioButtonNoSmokerYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonNoSmokerYes.Animated = true;
			this.radioButtonNoSmokerYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonNoSmokerYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoSmokerYes.CheckedState.BorderThickness = 2;
			this.radioButtonNoSmokerYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoSmokerYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonNoSmokerYes.CheckedState.InnerOffset = 1;
			this.radioButtonNoSmokerYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNoSmokerYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonNoSmokerYes.Name = "radioButtonNoSmokerYes";
			this.radioButtonNoSmokerYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonNoSmokerYes.ShadowDecoration.Depth = 40;
			this.radioButtonNoSmokerYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonNoSmokerYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonNoSmokerYes.TabIndex = 3;
			this.radioButtonNoSmokerYes.Tag = "fixedPosition";
			this.radioButtonNoSmokerYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoSmokerYes.UncheckedState.BorderThickness = 2;
			this.radioButtonNoSmokerYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoSmokerYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonNoSmokerNo
			// 
			this.radioButtonNoSmokerNo.Animated = true;
			this.radioButtonNoSmokerNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonNoSmokerNo.Checked = true;
			this.radioButtonNoSmokerNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoSmokerNo.CheckedState.BorderThickness = 2;
			this.radioButtonNoSmokerNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoSmokerNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonNoSmokerNo.CheckedState.InnerOffset = 1;
			this.radioButtonNoSmokerNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNoSmokerNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonNoSmokerNo.Name = "radioButtonNoSmokerNo";
			this.radioButtonNoSmokerNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonNoSmokerNo.ShadowDecoration.Depth = 40;
			this.radioButtonNoSmokerNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonNoSmokerNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonNoSmokerNo.TabIndex = 1;
			this.radioButtonNoSmokerNo.Tag = "fixedPosition";
			this.radioButtonNoSmokerNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoSmokerNo.UncheckedState.BorderThickness = 2;
			this.radioButtonNoSmokerNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoSmokerNo.UncheckedState.InnerOffset = 1;
			// 
			// groupBoxNoDrinkAlcohol
			// 
			this.groupBoxNoDrinkAlcohol.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxNoDrinkAlcohol.Controls.Add(this.labelNoDrinkAlcoholYes);
			this.groupBoxNoDrinkAlcohol.Controls.Add(this.labelNoDrinkAlcoholNo);
			this.groupBoxNoDrinkAlcohol.Controls.Add(this.radioButtonNoDrinkAlcoholYes);
			this.groupBoxNoDrinkAlcohol.Controls.Add(this.radioButtonNoDrinkAlcoholNo);
			this.groupBoxNoDrinkAlcohol.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxNoDrinkAlcohol.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxNoDrinkAlcohol.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxNoDrinkAlcohol.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxNoDrinkAlcohol.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxNoDrinkAlcohol.Location = new System.Drawing.Point(500, 520);
			this.groupBoxNoDrinkAlcohol.Name = "groupBoxNoDrinkAlcohol";
			this.groupBoxNoDrinkAlcohol.Size = new System.Drawing.Size(180, 33);
			this.groupBoxNoDrinkAlcohol.TabIndex = 22;
			this.groupBoxNoDrinkAlcohol.Tag = "needToMoveParentDown";
			// 
			// labelNoDrinkAlcoholYes
			// 
			this.labelNoDrinkAlcoholYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoDrinkAlcoholYes.AutoSize = true;
			this.labelNoDrinkAlcoholYes.BackColor = System.Drawing.Color.Transparent;
			this.labelNoDrinkAlcoholYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNoDrinkAlcoholYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelNoDrinkAlcoholYes.ForeColor = System.Drawing.Color.Black;
			this.labelNoDrinkAlcoholYes.Location = new System.Drawing.Point(100, 4);
			this.labelNoDrinkAlcoholYes.Name = "labelNoDrinkAlcoholYes";
			this.labelNoDrinkAlcoholYes.Size = new System.Drawing.Size(50, 25);
			this.labelNoDrinkAlcoholYes.TabIndex = 2;
			this.labelNoDrinkAlcoholYes.Tag = "fixedPosition";
			this.labelNoDrinkAlcoholYes.Text = "Так";
			this.labelNoDrinkAlcoholYes.Click += new System.EventHandler(this.LabelNoDrinkAlcoholYes_Click);
			// 
			// labelNoDrinkAlcoholNo
			// 
			this.labelNoDrinkAlcoholNo.AutoSize = true;
			this.labelNoDrinkAlcoholNo.BackColor = System.Drawing.Color.Transparent;
			this.labelNoDrinkAlcoholNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNoDrinkAlcoholNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelNoDrinkAlcoholNo.ForeColor = System.Drawing.Color.Black;
			this.labelNoDrinkAlcoholNo.Location = new System.Drawing.Point(4, 4);
			this.labelNoDrinkAlcoholNo.Name = "labelNoDrinkAlcoholNo";
			this.labelNoDrinkAlcoholNo.Size = new System.Drawing.Size(34, 25);
			this.labelNoDrinkAlcoholNo.TabIndex = 0;
			this.labelNoDrinkAlcoholNo.Tag = "fixedPosition";
			this.labelNoDrinkAlcoholNo.Text = "Ні";
			this.labelNoDrinkAlcoholNo.Click += new System.EventHandler(this.LabelNoDrinkAlcoholNo_Click);
			// 
			// radioButtonNoDrinkAlcoholYes
			// 
			this.radioButtonNoDrinkAlcoholYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonNoDrinkAlcoholYes.Animated = true;
			this.radioButtonNoDrinkAlcoholYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonNoDrinkAlcoholYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoDrinkAlcoholYes.CheckedState.BorderThickness = 2;
			this.radioButtonNoDrinkAlcoholYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoDrinkAlcoholYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonNoDrinkAlcoholYes.CheckedState.InnerOffset = 1;
			this.radioButtonNoDrinkAlcoholYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNoDrinkAlcoholYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonNoDrinkAlcoholYes.Name = "radioButtonNoDrinkAlcoholYes";
			this.radioButtonNoDrinkAlcoholYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonNoDrinkAlcoholYes.ShadowDecoration.Depth = 40;
			this.radioButtonNoDrinkAlcoholYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonNoDrinkAlcoholYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonNoDrinkAlcoholYes.TabIndex = 3;
			this.radioButtonNoDrinkAlcoholYes.Tag = "fixedPosition";
			this.radioButtonNoDrinkAlcoholYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoDrinkAlcoholYes.UncheckedState.BorderThickness = 2;
			this.radioButtonNoDrinkAlcoholYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoDrinkAlcoholYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonNoDrinkAlcoholNo
			// 
			this.radioButtonNoDrinkAlcoholNo.Animated = true;
			this.radioButtonNoDrinkAlcoholNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonNoDrinkAlcoholNo.Checked = true;
			this.radioButtonNoDrinkAlcoholNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoDrinkAlcoholNo.CheckedState.BorderThickness = 2;
			this.radioButtonNoDrinkAlcoholNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoDrinkAlcoholNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonNoDrinkAlcoholNo.CheckedState.InnerOffset = 1;
			this.radioButtonNoDrinkAlcoholNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNoDrinkAlcoholNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonNoDrinkAlcoholNo.Name = "radioButtonNoDrinkAlcoholNo";
			this.radioButtonNoDrinkAlcoholNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonNoDrinkAlcoholNo.ShadowDecoration.Depth = 40;
			this.radioButtonNoDrinkAlcoholNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonNoDrinkAlcoholNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonNoDrinkAlcoholNo.TabIndex = 1;
			this.radioButtonNoDrinkAlcoholNo.Tag = "fixedPosition";
			this.radioButtonNoDrinkAlcoholNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonNoDrinkAlcoholNo.UncheckedState.BorderThickness = 2;
			this.radioButtonNoDrinkAlcoholNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonNoDrinkAlcoholNo.UncheckedState.InnerOffset = 1;
			// 
			// groupBoxBusinessTrip
			// 
			this.groupBoxBusinessTrip.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxBusinessTrip.Controls.Add(this.labelBusinessTripYes);
			this.groupBoxBusinessTrip.Controls.Add(this.labelBusinessTripNo);
			this.groupBoxBusinessTrip.Controls.Add(this.radioButtonBusinessTripYes);
			this.groupBoxBusinessTrip.Controls.Add(this.radioButtonBusinessTripNo);
			this.groupBoxBusinessTrip.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxBusinessTrip.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxBusinessTrip.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxBusinessTrip.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxBusinessTrip.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxBusinessTrip.Location = new System.Drawing.Point(500, 340);
			this.groupBoxBusinessTrip.Name = "groupBoxBusinessTrip";
			this.groupBoxBusinessTrip.Size = new System.Drawing.Size(180, 33);
			this.groupBoxBusinessTrip.TabIndex = 16;
			this.groupBoxBusinessTrip.Tag = "needToMoveParentDown";
			// 
			// labelBusinessTripYes
			// 
			this.labelBusinessTripYes.AutoSize = true;
			this.labelBusinessTripYes.BackColor = System.Drawing.Color.Transparent;
			this.labelBusinessTripYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelBusinessTripYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelBusinessTripYes.ForeColor = System.Drawing.Color.Black;
			this.labelBusinessTripYes.Location = new System.Drawing.Point(100, 4);
			this.labelBusinessTripYes.Name = "labelBusinessTripYes";
			this.labelBusinessTripYes.Size = new System.Drawing.Size(50, 25);
			this.labelBusinessTripYes.TabIndex = 2;
			this.labelBusinessTripYes.Tag = "fixedPosition";
			this.labelBusinessTripYes.Text = "Так";
			this.labelBusinessTripYes.Click += new System.EventHandler(this.LabelBusinessTripYes_Click);
			// 
			// labelBusinessTripNo
			// 
			this.labelBusinessTripNo.AutoSize = true;
			this.labelBusinessTripNo.BackColor = System.Drawing.Color.Transparent;
			this.labelBusinessTripNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelBusinessTripNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelBusinessTripNo.ForeColor = System.Drawing.Color.Black;
			this.labelBusinessTripNo.Location = new System.Drawing.Point(4, 4);
			this.labelBusinessTripNo.Name = "labelBusinessTripNo";
			this.labelBusinessTripNo.Size = new System.Drawing.Size(34, 25);
			this.labelBusinessTripNo.TabIndex = 0;
			this.labelBusinessTripNo.Tag = "fixedPosition";
			this.labelBusinessTripNo.Text = "Ні";
			this.labelBusinessTripNo.Click += new System.EventHandler(this.LabelBusinessTripNo_Click);
			// 
			// radioButtonBusinessTripYes
			// 
			this.radioButtonBusinessTripYes.Animated = true;
			this.radioButtonBusinessTripYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonBusinessTripYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonBusinessTripYes.CheckedState.BorderThickness = 2;
			this.radioButtonBusinessTripYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonBusinessTripYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonBusinessTripYes.CheckedState.InnerOffset = 1;
			this.radioButtonBusinessTripYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonBusinessTripYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonBusinessTripYes.Name = "radioButtonBusinessTripYes";
			this.radioButtonBusinessTripYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonBusinessTripYes.ShadowDecoration.Depth = 40;
			this.radioButtonBusinessTripYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonBusinessTripYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonBusinessTripYes.TabIndex = 3;
			this.radioButtonBusinessTripYes.Tag = "fixedPosition";
			this.radioButtonBusinessTripYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonBusinessTripYes.UncheckedState.BorderThickness = 2;
			this.radioButtonBusinessTripYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonBusinessTripYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonBusinessTripNo
			// 
			this.radioButtonBusinessTripNo.Animated = true;
			this.radioButtonBusinessTripNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonBusinessTripNo.Checked = true;
			this.radioButtonBusinessTripNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonBusinessTripNo.CheckedState.BorderThickness = 2;
			this.radioButtonBusinessTripNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonBusinessTripNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonBusinessTripNo.CheckedState.InnerOffset = 1;
			this.radioButtonBusinessTripNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonBusinessTripNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonBusinessTripNo.Name = "radioButtonBusinessTripNo";
			this.radioButtonBusinessTripNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonBusinessTripNo.ShadowDecoration.Depth = 40;
			this.radioButtonBusinessTripNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonBusinessTripNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonBusinessTripNo.TabIndex = 1;
			this.radioButtonBusinessTripNo.Tag = "fixedPosition";
			this.radioButtonBusinessTripNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonBusinessTripNo.UncheckedState.BorderThickness = 2;
			this.radioButtonBusinessTripNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonBusinessTripNo.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonStudentNull
			// 
			this.radioButtonStudentNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonStudentNull.Animated = true;
			this.radioButtonStudentNull.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentNull.Checked = true;
			this.radioButtonStudentNull.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonStudentNull.CheckedState.BorderThickness = 2;
			this.radioButtonStudentNull.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentNull.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonStudentNull.CheckedState.InnerOffset = 1;
			this.radioButtonStudentNull.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonStudentNull.Location = new System.Drawing.Point(327, 6);
			this.radioButtonStudentNull.Name = "radioButtonStudentNull";
			this.radioButtonStudentNull.ShadowDecoration.BorderRadius = 10;
			this.radioButtonStudentNull.ShadowDecoration.Depth = 40;
			this.radioButtonStudentNull.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonStudentNull.Size = new System.Drawing.Size(21, 21);
			this.radioButtonStudentNull.TabIndex = 5;
			this.radioButtonStudentNull.Tag = "fixedPosition";
			this.radioButtonStudentNull.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonStudentNull.UncheckedState.BorderThickness = 2;
			this.radioButtonStudentNull.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentNull.UncheckedState.InnerOffset = 1;
			// 
			// labelStudentNull
			// 
			this.labelStudentNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStudentNull.AutoSize = true;
			this.labelStudentNull.BackColor = System.Drawing.Color.Transparent;
			this.labelStudentNull.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelStudentNull.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelStudentNull.ForeColor = System.Drawing.Color.Black;
			this.labelStudentNull.Location = new System.Drawing.Point(212, 4);
			this.labelStudentNull.Name = "labelStudentNull";
			this.labelStudentNull.Size = new System.Drawing.Size(109, 25);
			this.labelStudentNull.TabIndex = 4;
			this.labelStudentNull.Tag = "fixedPosition";
			this.labelStudentNull.Text = "Все одно";
			this.labelStudentNull.Click += new System.EventHandler(this.LabelStudentNull_Click);
			// 
			// groupBoxStudent
			// 
			this.groupBoxStudent.BorderColor = System.Drawing.Color.Transparent;
			this.groupBoxStudent.Controls.Add(this.radioButtonStudentNull);
			this.groupBoxStudent.Controls.Add(this.labelStudentYes);
			this.groupBoxStudent.Controls.Add(this.labelStudentNo);
			this.groupBoxStudent.Controls.Add(this.labelStudentNull);
			this.groupBoxStudent.Controls.Add(this.radioButtonStudentYes);
			this.groupBoxStudent.Controls.Add(this.radioButtonStudentNo);
			this.groupBoxStudent.CustomBorderColor = System.Drawing.Color.Transparent;
			this.groupBoxStudent.CustomBorderThickness = new System.Windows.Forms.Padding(0);
			this.groupBoxStudent.FillColor = System.Drawing.Color.Transparent;
			this.groupBoxStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupBoxStudent.ForeColor = System.Drawing.Color.Transparent;
			this.groupBoxStudent.Location = new System.Drawing.Point(500, 640);
			this.groupBoxStudent.Name = "groupBoxStudent";
			this.groupBoxStudent.Size = new System.Drawing.Size(350, 33);
			this.groupBoxStudent.TabIndex = 26;
			this.groupBoxStudent.Tag = "needToMoveParentDown";
			this.groupBoxStudent.Text = "guna2GroupBox6";
			// 
			// labelStudentYes
			// 
			this.labelStudentYes.AutoSize = true;
			this.labelStudentYes.BackColor = System.Drawing.Color.Transparent;
			this.labelStudentYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelStudentYes.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelStudentYes.ForeColor = System.Drawing.Color.Black;
			this.labelStudentYes.Location = new System.Drawing.Point(100, 4);
			this.labelStudentYes.Name = "labelStudentYes";
			this.labelStudentYes.Size = new System.Drawing.Size(50, 25);
			this.labelStudentYes.TabIndex = 2;
			this.labelStudentYes.Tag = "fixedPosition";
			this.labelStudentYes.Text = "Так";
			this.labelStudentYes.Click += new System.EventHandler(this.LabelStudentYes_Click);
			// 
			// labelStudentNo
			// 
			this.labelStudentNo.AutoSize = true;
			this.labelStudentNo.BackColor = System.Drawing.Color.Transparent;
			this.labelStudentNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelStudentNo.Font = new System.Drawing.Font("Verdana", 15.75F);
			this.labelStudentNo.ForeColor = System.Drawing.Color.Black;
			this.labelStudentNo.Location = new System.Drawing.Point(4, 4);
			this.labelStudentNo.Name = "labelStudentNo";
			this.labelStudentNo.Size = new System.Drawing.Size(34, 25);
			this.labelStudentNo.TabIndex = 0;
			this.labelStudentNo.Tag = "fixedPosition";
			this.labelStudentNo.Text = "Ні";
			this.labelStudentNo.Click += new System.EventHandler(this.LabelStudentNo_Click);
			// 
			// radioButtonStudentYes
			// 
			this.radioButtonStudentYes.Animated = true;
			this.radioButtonStudentYes.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentYes.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonStudentYes.CheckedState.BorderThickness = 2;
			this.radioButtonStudentYes.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentYes.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonStudentYes.CheckedState.InnerOffset = 1;
			this.radioButtonStudentYes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonStudentYes.Location = new System.Drawing.Point(156, 6);
			this.radioButtonStudentYes.Name = "radioButtonStudentYes";
			this.radioButtonStudentYes.ShadowDecoration.BorderRadius = 10;
			this.radioButtonStudentYes.ShadowDecoration.Depth = 40;
			this.radioButtonStudentYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonStudentYes.Size = new System.Drawing.Size(21, 21);
			this.radioButtonStudentYes.TabIndex = 3;
			this.radioButtonStudentYes.Tag = "fixedPosition";
			this.radioButtonStudentYes.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonStudentYes.UncheckedState.BorderThickness = 2;
			this.radioButtonStudentYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentYes.UncheckedState.InnerOffset = 1;
			// 
			// radioButtonStudentNo
			// 
			this.radioButtonStudentNo.Animated = true;
			this.radioButtonStudentNo.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentNo.CheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonStudentNo.CheckedState.BorderThickness = 2;
			this.radioButtonStudentNo.CheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentNo.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.radioButtonStudentNo.CheckedState.InnerOffset = 1;
			this.radioButtonStudentNo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonStudentNo.Location = new System.Drawing.Point(44, 6);
			this.radioButtonStudentNo.Name = "radioButtonStudentNo";
			this.radioButtonStudentNo.ShadowDecoration.BorderRadius = 10;
			this.radioButtonStudentNo.ShadowDecoration.Depth = 40;
			this.radioButtonStudentNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
			this.radioButtonStudentNo.Size = new System.Drawing.Size(21, 21);
			this.radioButtonStudentNo.TabIndex = 1;
			this.radioButtonStudentNo.Tag = "fixedPosition";
			this.radioButtonStudentNo.UncheckedState.BorderColor = System.Drawing.Color.Black;
			this.radioButtonStudentNo.UncheckedState.BorderThickness = 2;
			this.radioButtonStudentNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.radioButtonStudentNo.UncheckedState.InnerOffset = 1;
			// 
			// labelAgeMin
			// 
			this.labelAgeMin.AutoSize = true;
			this.labelAgeMin.BackColor = System.Drawing.Color.Transparent;
			this.labelAgeMin.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAgeMin.ForeColor = System.Drawing.Color.Black;
			this.labelAgeMin.Location = new System.Drawing.Point(110, 72);
			this.labelAgeMin.Name = "labelAgeMin";
			this.labelAgeMin.Size = new System.Drawing.Size(54, 32);
			this.labelAgeMin.TabIndex = 4;
			this.labelAgeMin.Text = "від";
			// 
			// RequirementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1150, 695);
			this.Controls.Add(this.labelAgeMin);
			this.Controls.Add(this.groupBoxStudent);
			this.Controls.Add(this.groupBoxBusinessTrip);
			this.Controls.Add(this.groupBoxNoDrinkAlcohol);
			this.Controls.Add(this.groupBoxNoSmoker);
			this.Controls.Add(this.groupBoxDriverLicense);
			this.Controls.Add(this.groupBoxNoChronicDiseases);
			this.Controls.Add(this.checkBoxDiplomaAll);
			this.Controls.Add(this.labelDiplomaAll);
			this.Controls.Add(this.textBoxCity);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.labelCityInfo);
			this.Controls.Add(this.listBoxDegrees);
			this.Controls.Add(this.labelEducationDegree);
			this.Controls.Add(this.labelStudent);
			this.Controls.Add(this.labelBusinessTrip);
			this.Controls.Add(this.labelNoDrinkAlcohol);
			this.Controls.Add(this.labelNoSmoker);
			this.Controls.Add(this.labelDriverLicense);
			this.Controls.Add(this.labelNoChronicDiseases);
			this.Controls.Add(this.labelCandidateMustHave);
			this.Controls.Add(this.numericUpDownExpMin);
			this.Controls.Add(this.labelExpMin);
			this.Controls.Add(this.numericUpDownAgeMax);
			this.Controls.Add(this.labelAgeMax);
			this.Controls.Add(this.numericUpDownAgeMin);
			this.Controls.Add(this.labelAge);
			this.Controls.Add(this.labelCity);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RequirementForm";
			this.Text = "Вимоги";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RequirementForm_FormClosed);
			this.Load += new System.EventHandler(this.RequirementForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgeMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.educationDegreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.recruitmentDBDataSet)).EndInit();
			this.groupBoxNoChronicDiseases.ResumeLayout(false);
			this.groupBoxNoChronicDiseases.PerformLayout();
			this.groupBoxDriverLicense.ResumeLayout(false);
			this.groupBoxDriverLicense.PerformLayout();
			this.groupBoxNoSmoker.ResumeLayout(false);
			this.groupBoxNoSmoker.PerformLayout();
			this.groupBoxNoDrinkAlcohol.ResumeLayout(false);
			this.groupBoxNoDrinkAlcohol.PerformLayout();
			this.groupBoxBusinessTrip.ResumeLayout(false);
			this.groupBoxBusinessTrip.PerformLayout();
			this.groupBoxStudent.ResumeLayout(false);
			this.groupBoxStudent.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.NumericUpDown numericUpDownAgeMin;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.NumericUpDown numericUpDownAgeMax;
        private System.Windows.Forms.Label labelAgeMax;
        private System.Windows.Forms.NumericUpDown numericUpDownExpMin;
        private System.Windows.Forms.Label labelExpMin;
        private System.Windows.Forms.Label labelCandidateMustHave;
        private System.Windows.Forms.Label labelNoChronicDiseases;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.Label labelBusinessTrip;
        private System.Windows.Forms.Label labelNoDrinkAlcohol;
        private System.Windows.Forms.Label labelNoSmoker;
        private System.Windows.Forms.Label labelStudent;
        private System.Windows.Forms.Label labelEducationDegree;
        private System.Windows.Forms.ListBox listBoxDegrees;
        private RecruitmentDB recruitmentDBDataSet;
        private System.Windows.Forms.BindingSource educationDegreeBindingSource;
        private RecruitmentDBTableAdapters.Education_DegreeTableAdapter education_DegreeTableAdapter;
        private System.Windows.Forms.Label labelCityInfo;
		private Guna.UI2.WinForms.Guna2GradientButton buttonCreate;
		private Guna.UI2.WinForms.Guna2TextBox textBoxCity;
		private Guna.UI2.WinForms.Guna2CustomCheckBox checkBoxDiplomaAll;
		private System.Windows.Forms.Label labelDiplomaAll;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxNoChronicDiseases;
		private System.Windows.Forms.Label labelNoChronicDiseasesYes;
		private System.Windows.Forms.Label labelNoChronicDiseasesNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonNoChronicDiseasesYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonNoChronicDiseasesNo;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxDriverLicense;
		private System.Windows.Forms.Label labelDriverLicenseYes;
		private System.Windows.Forms.Label labelDriverLicenseNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonDriverLicenseYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonDriverLicenseNo;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxNoSmoker;
		private System.Windows.Forms.Label labelNoSmokerYes;
		private System.Windows.Forms.Label labelNoSmokerNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonNoSmokerYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonNoSmokerNo;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxNoDrinkAlcohol;
		private System.Windows.Forms.Label labelNoDrinkAlcoholYes;
		private System.Windows.Forms.Label labelNoDrinkAlcoholNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonNoDrinkAlcoholYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonNoDrinkAlcoholNo;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxBusinessTrip;
		private System.Windows.Forms.Label labelBusinessTripYes;
		private System.Windows.Forms.Label labelBusinessTripNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonBusinessTripYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonBusinessTripNo;
		private Guna.UI2.WinForms.Guna2GroupBox groupBoxStudent;
		private System.Windows.Forms.Label labelStudentNull;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonStudentNull;
		private System.Windows.Forms.Label labelStudentYes;
		private System.Windows.Forms.Label labelStudentNo;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonStudentYes;
		private Guna.UI2.WinForms.Guna2CustomRadioButton radioButtonStudentNo;
		private System.Windows.Forms.Label labelAgeMin;
	}
}