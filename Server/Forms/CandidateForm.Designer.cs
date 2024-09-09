namespace ServerDB.Forms
{
    partial class CandidateForm
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
			this.buttonMore = new System.Windows.Forms.Button();
			this.labelCity = new System.Windows.Forms.Label();
			this.richTextBoxAdditionalInfo = new System.Windows.Forms.RichTextBox();
			this.labelAdditionalInfoTitle = new System.Windows.Forms.Label();
			this.labelNationality = new System.Windows.Forms.Label();
			this.labelFullName = new System.Windows.Forms.Label();
			this.labelBirthday = new System.Windows.Forms.Label();
			this.richTextBoxContact = new System.Windows.Forms.RichTextBox();
			this.labelContact = new System.Windows.Forms.Label();
			this.panelMore = new System.Windows.Forms.Panel();
			this.labelLanguageHelp = new System.Windows.Forms.Label();
			this.pictureBoxLine = new System.Windows.Forms.PictureBox();
			this.labelLanguageTitle = new System.Windows.Forms.Label();
			this.labelEducationTitle = new System.Windows.Forms.Label();
			this.flpEducations = new System.Windows.Forms.FlowLayoutPanel();
			this.panelEducation = new System.Windows.Forms.Panel();
			this.labelEducationForm = new System.Windows.Forms.Label();
			this.labelEducationDegree = new System.Windows.Forms.Label();
			this.labelDateEnd = new System.Windows.Forms.Label();
			this.labelYearAdmission = new System.Windows.Forms.Label();
			this.labelSpecialty = new System.Windows.Forms.Label();
			this.labelNameInstitution = new System.Windows.Forms.Label();
			this.labelEducationNumber = new System.Windows.Forms.Label();
			this.flpLanguages = new System.Windows.Forms.FlowLayoutPanel();
			this.panelLanguage = new System.Windows.Forms.Panel();
			this.labelLevel = new System.Windows.Forms.Label();
			this.labelLanguageNumber = new System.Windows.Forms.Label();
			this.labelLanguage = new System.Windows.Forms.Label();
			this.richTextBoxChronicDiseases = new System.Windows.Forms.RichTextBox();
			this.labelChronicDiseases = new System.Windows.Forms.Label();
			this.labelSmokerAlcohol = new System.Windows.Forms.Label();
			this.labelHealth = new System.Windows.Forms.Label();
			this.labelFamilyStatus = new System.Windows.Forms.Label();
			this.labelBusinessTrip = new System.Windows.Forms.Label();
			this.labelChildrenAmount = new System.Windows.Forms.Label();
			this.labelDriverLicense = new System.Windows.Forms.Label();
			this.labelReadiness = new System.Windows.Forms.Label();
			this.labelExperience = new System.Windows.Forms.Label();
			this.panelMore.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine)).BeginInit();
			this.flpEducations.SuspendLayout();
			this.panelEducation.SuspendLayout();
			this.flpLanguages.SuspendLayout();
			this.panelLanguage.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonMore
			// 
			this.buttonMore.AutoSize = true;
			this.buttonMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
			this.buttonMore.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMore.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMore.Location = new System.Drawing.Point(531, 377);
			this.buttonMore.Name = "buttonMore";
			this.buttonMore.Size = new System.Drawing.Size(160, 40);
			this.buttonMore.TabIndex = 8;
			this.buttonMore.Text = "Більше";
			this.buttonMore.UseVisualStyleBackColor = false;
			this.buttonMore.Click += new System.EventHandler(this.ButtonMore_Click);
			// 
			// labelCity
			// 
			this.labelCity.AutoEllipsis = true;
			this.labelCity.BackColor = System.Drawing.Color.Transparent;
			this.labelCity.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCity.ForeColor = System.Drawing.Color.Black;
			this.labelCity.Location = new System.Drawing.Point(12, 132);
			this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCity.Name = "labelCity";
			this.labelCity.Size = new System.Drawing.Size(600, 29);
			this.labelCity.TabIndex = 2;
			this.labelCity.Text = "Місце проживання";
			this.labelCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// richTextBoxAdditionalInfo
			// 
			this.richTextBoxAdditionalInfo.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxAdditionalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxAdditionalInfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxAdditionalInfo.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxAdditionalInfo.Location = new System.Drawing.Point(715, 112);
			this.richTextBoxAdditionalInfo.MaxLength = 2048;
			this.richTextBoxAdditionalInfo.Name = "richTextBoxAdditionalInfo";
			this.richTextBoxAdditionalInfo.ReadOnly = true;
			this.richTextBoxAdditionalInfo.Size = new System.Drawing.Size(525, 305);
			this.richTextBoxAdditionalInfo.TabIndex = 7;
			this.richTextBoxAdditionalInfo.TabStop = false;
			this.richTextBoxAdditionalInfo.Text = "";
			// 
			// labelAdditionalInfoTitle
			// 
			this.labelAdditionalInfoTitle.AutoSize = true;
			this.labelAdditionalInfoTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelAdditionalInfoTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAdditionalInfoTitle.ForeColor = System.Drawing.Color.Black;
			this.labelAdditionalInfoTitle.Location = new System.Drawing.Point(710, 72);
			this.labelAdditionalInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAdditionalInfoTitle.Name = "labelAdditionalInfoTitle";
			this.labelAdditionalInfoTitle.Size = new System.Drawing.Size(479, 29);
			this.labelAdditionalInfoTitle.TabIndex = 6;
			this.labelAdditionalInfoTitle.Text = "Додаткова інформація від кандидата:";
			// 
			// labelNationality
			// 
			this.labelNationality.AutoEllipsis = true;
			this.labelNationality.BackColor = System.Drawing.Color.Transparent;
			this.labelNationality.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNationality.ForeColor = System.Drawing.Color.Black;
			this.labelNationality.Location = new System.Drawing.Point(12, 72);
			this.labelNationality.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelNationality.Name = "labelNationality";
			this.labelNationality.Size = new System.Drawing.Size(600, 29);
			this.labelNationality.TabIndex = 1;
			this.labelNationality.Text = "Громадянство";
			this.labelNationality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelFullName
			// 
			this.labelFullName.AutoEllipsis = true;
			this.labelFullName.BackColor = System.Drawing.Color.Transparent;
			this.labelFullName.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFullName.ForeColor = System.Drawing.Color.Black;
			this.labelFullName.Location = new System.Drawing.Point(12, 12);
			this.labelFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFullName.Name = "labelFullName";
			this.labelFullName.Size = new System.Drawing.Size(1240, 40);
			this.labelFullName.TabIndex = 0;
			this.labelFullName.Text = "ПІБ";
			this.labelFullName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelBirthday
			// 
			this.labelBirthday.AutoEllipsis = true;
			this.labelBirthday.BackColor = System.Drawing.Color.Transparent;
			this.labelBirthday.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBirthday.ForeColor = System.Drawing.Color.Black;
			this.labelBirthday.Location = new System.Drawing.Point(12, 192);
			this.labelBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelBirthday.Name = "labelBirthday";
			this.labelBirthday.Size = new System.Drawing.Size(600, 29);
			this.labelBirthday.TabIndex = 3;
			this.labelBirthday.Text = "Дата народження";
			this.labelBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// richTextBoxContact
			// 
			this.richTextBoxContact.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxContact.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxContact.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxContact.Location = new System.Drawing.Point(12, 297);
			this.richTextBoxContact.MaxLength = 2048;
			this.richTextBoxContact.Name = "richTextBoxContact";
			this.richTextBoxContact.ReadOnly = true;
			this.richTextBoxContact.Size = new System.Drawing.Size(500, 120);
			this.richTextBoxContact.TabIndex = 5;
			this.richTextBoxContact.TabStop = false;
			this.richTextBoxContact.Text = "Інформація";
			// 
			// labelContact
			// 
			this.labelContact.AutoSize = true;
			this.labelContact.BackColor = System.Drawing.Color.Transparent;
			this.labelContact.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelContact.ForeColor = System.Drawing.Color.Black;
			this.labelContact.Location = new System.Drawing.Point(12, 252);
			this.labelContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelContact.Name = "labelContact";
			this.labelContact.Size = new System.Drawing.Size(334, 32);
			this.labelContact.TabIndex = 4;
			this.labelContact.Text = "Контактна інформація:";
			// 
			// panelMore
			// 
			this.panelMore.BackColor = System.Drawing.Color.Transparent;
			this.panelMore.Controls.Add(this.labelLanguageHelp);
			this.panelMore.Controls.Add(this.pictureBoxLine);
			this.panelMore.Controls.Add(this.labelLanguageTitle);
			this.panelMore.Controls.Add(this.labelEducationTitle);
			this.panelMore.Controls.Add(this.flpEducations);
			this.panelMore.Controls.Add(this.flpLanguages);
			this.panelMore.Controls.Add(this.richTextBoxChronicDiseases);
			this.panelMore.Controls.Add(this.labelChronicDiseases);
			this.panelMore.Controls.Add(this.labelSmokerAlcohol);
			this.panelMore.Controls.Add(this.labelHealth);
			this.panelMore.Controls.Add(this.labelFamilyStatus);
			this.panelMore.Controls.Add(this.labelBusinessTrip);
			this.panelMore.Controls.Add(this.labelChildrenAmount);
			this.panelMore.Controls.Add(this.labelDriverLicense);
			this.panelMore.Controls.Add(this.labelReadiness);
			this.panelMore.Controls.Add(this.labelExperience);
			this.panelMore.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelMore.Location = new System.Drawing.Point(0, 417);
			this.panelMore.Name = "panelMore";
			this.panelMore.Size = new System.Drawing.Size(1337, 1320);
			this.panelMore.TabIndex = 9;
			this.panelMore.Visible = false;
			// 
			// labelLanguageHelp
			// 
			this.labelLanguageHelp.AutoSize = true;
			this.labelLanguageHelp.BackColor = System.Drawing.Color.Transparent;
			this.labelLanguageHelp.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLanguageHelp.ForeColor = System.Drawing.Color.Black;
			this.labelLanguageHelp.Location = new System.Drawing.Point(615, 773);
			this.labelLanguageHelp.Name = "labelLanguageHelp";
			this.labelLanguageHelp.Size = new System.Drawing.Size(448, 18);
			this.labelLanguageHelp.TabIndex = 50;
			this.labelLanguageHelp.Text = "(рівень знань може приймати значення від 1 до 10)";
			// 
			// pictureBoxLine
			// 
			this.pictureBoxLine.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.pictureBoxLine.BackColor = System.Drawing.Color.Black;
			this.pictureBoxLine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxLine.Location = new System.Drawing.Point(433, 6);
			this.pictureBoxLine.Name = "pictureBoxLine";
			this.pictureBoxLine.Size = new System.Drawing.Size(423, 2);
			this.pictureBoxLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxLine.TabIndex = 49;
			this.pictureBoxLine.TabStop = false;
			// 
			// labelLanguageTitle
			// 
			this.labelLanguageTitle.AutoSize = true;
			this.labelLanguageTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelLanguageTitle.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLanguageTitle.ForeColor = System.Drawing.Color.Black;
			this.labelLanguageTitle.Location = new System.Drawing.Point(565, 379);
			this.labelLanguageTitle.Name = "labelLanguageTitle";
			this.labelLanguageTitle.Size = new System.Drawing.Size(101, 38);
			this.labelLanguageTitle.TabIndex = 10;
			this.labelLanguageTitle.Text = "Мова";
			// 
			// labelEducationTitle
			// 
			this.labelEducationTitle.AutoSize = true;
			this.labelEducationTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelEducationTitle.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEducationTitle.ForeColor = System.Drawing.Color.Black;
			this.labelEducationTitle.Location = new System.Drawing.Point(557, 822);
			this.labelEducationTitle.Name = "labelEducationTitle";
			this.labelEducationTitle.Size = new System.Drawing.Size(122, 38);
			this.labelEducationTitle.TabIndex = 12;
			this.labelEducationTitle.Text = "Освіта";
			// 
			// flpEducations
			// 
			this.flpEducations.AutoScroll = true;
			this.flpEducations.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.flpEducations.Controls.Add(this.panelEducation);
			this.flpEducations.Location = new System.Drawing.Point(20, 860);
			this.flpEducations.Name = "flpEducations";
			this.flpEducations.Size = new System.Drawing.Size(1211, 450);
			this.flpEducations.TabIndex = 13;
			// 
			// panelEducation
			// 
			this.panelEducation.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelEducation.Controls.Add(this.labelEducationForm);
			this.panelEducation.Controls.Add(this.labelEducationDegree);
			this.panelEducation.Controls.Add(this.labelDateEnd);
			this.panelEducation.Controls.Add(this.labelYearAdmission);
			this.panelEducation.Controls.Add(this.labelSpecialty);
			this.panelEducation.Controls.Add(this.labelNameInstitution);
			this.panelEducation.Controls.Add(this.labelEducationNumber);
			this.panelEducation.Location = new System.Drawing.Point(3, 3);
			this.panelEducation.Name = "panelEducation";
			this.panelEducation.Size = new System.Drawing.Size(1188, 246);
			this.panelEducation.TabIndex = 0;
			this.panelEducation.Visible = false;
			// 
			// labelEducationForm
			// 
			this.labelEducationForm.AutoEllipsis = true;
			this.labelEducationForm.BackColor = System.Drawing.Color.Transparent;
			this.labelEducationForm.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEducationForm.ForeColor = System.Drawing.Color.Black;
			this.labelEducationForm.Location = new System.Drawing.Point(750, 164);
			this.labelEducationForm.Name = "labelEducationForm";
			this.labelEducationForm.Size = new System.Drawing.Size(420, 32);
			this.labelEducationForm.TabIndex = 6;
			this.labelEducationForm.Text = "Форма навчання";
			// 
			// labelEducationDegree
			// 
			this.labelEducationDegree.AutoEllipsis = true;
			this.labelEducationDegree.BackColor = System.Drawing.Color.Transparent;
			this.labelEducationDegree.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEducationDegree.ForeColor = System.Drawing.Color.Black;
			this.labelEducationDegree.Location = new System.Drawing.Point(100, 164);
			this.labelEducationDegree.Name = "labelEducationDegree";
			this.labelEducationDegree.Size = new System.Drawing.Size(600, 32);
			this.labelEducationDegree.TabIndex = 3;
			this.labelEducationDegree.Text = "Ступінь освіти";
			// 
			// labelDateEnd
			// 
			this.labelDateEnd.AutoEllipsis = true;
			this.labelDateEnd.BackColor = System.Drawing.Color.Transparent;
			this.labelDateEnd.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateEnd.ForeColor = System.Drawing.Color.Black;
			this.labelDateEnd.Location = new System.Drawing.Point(750, 104);
			this.labelDateEnd.Name = "labelDateEnd";
			this.labelDateEnd.Size = new System.Drawing.Size(420, 32);
			this.labelDateEnd.TabIndex = 5;
			this.labelDateEnd.Text = "Дата закінчення";
			// 
			// labelYearAdmission
			// 
			this.labelYearAdmission.AutoEllipsis = true;
			this.labelYearAdmission.BackColor = System.Drawing.Color.Transparent;
			this.labelYearAdmission.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelYearAdmission.ForeColor = System.Drawing.Color.Black;
			this.labelYearAdmission.Location = new System.Drawing.Point(750, 44);
			this.labelYearAdmission.Name = "labelYearAdmission";
			this.labelYearAdmission.Size = new System.Drawing.Size(420, 32);
			this.labelYearAdmission.TabIndex = 4;
			this.labelYearAdmission.Text = "Рік вступу";
			// 
			// labelSpecialty
			// 
			this.labelSpecialty.AutoEllipsis = true;
			this.labelSpecialty.BackColor = System.Drawing.Color.Transparent;
			this.labelSpecialty.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSpecialty.ForeColor = System.Drawing.Color.Black;
			this.labelSpecialty.Location = new System.Drawing.Point(100, 104);
			this.labelSpecialty.Name = "labelSpecialty";
			this.labelSpecialty.Size = new System.Drawing.Size(600, 32);
			this.labelSpecialty.TabIndex = 2;
			this.labelSpecialty.Text = "Спецальність";
			// 
			// labelNameInstitution
			// 
			this.labelNameInstitution.AutoEllipsis = true;
			this.labelNameInstitution.BackColor = System.Drawing.Color.Transparent;
			this.labelNameInstitution.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNameInstitution.ForeColor = System.Drawing.Color.Black;
			this.labelNameInstitution.Location = new System.Drawing.Point(100, 44);
			this.labelNameInstitution.Name = "labelNameInstitution";
			this.labelNameInstitution.Size = new System.Drawing.Size(600, 32);
			this.labelNameInstitution.TabIndex = 1;
			this.labelNameInstitution.Text = "Назва закладу";
			// 
			// labelEducationNumber
			// 
			this.labelEducationNumber.AutoSize = true;
			this.labelEducationNumber.BackColor = System.Drawing.Color.Transparent;
			this.labelEducationNumber.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEducationNumber.ForeColor = System.Drawing.Color.Black;
			this.labelEducationNumber.Location = new System.Drawing.Point(-2, 96);
			this.labelEducationNumber.Name = "labelEducationNumber";
			this.labelEducationNumber.Size = new System.Drawing.Size(45, 48);
			this.labelEducationNumber.TabIndex = 0;
			this.labelEducationNumber.Text = "1";
			// 
			// flpLanguages
			// 
			this.flpLanguages.AutoScroll = true;
			this.flpLanguages.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.flpLanguages.Controls.Add(this.panelLanguage);
			this.flpLanguages.Location = new System.Drawing.Point(190, 420);
			this.flpLanguages.Name = "flpLanguages";
			this.flpLanguages.Size = new System.Drawing.Size(873, 350);
			this.flpLanguages.TabIndex = 11;
			// 
			// panelLanguage
			// 
			this.panelLanguage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelLanguage.Controls.Add(this.labelLevel);
			this.panelLanguage.Controls.Add(this.labelLanguageNumber);
			this.panelLanguage.Controls.Add(this.labelLanguage);
			this.panelLanguage.Location = new System.Drawing.Point(3, 3);
			this.panelLanguage.Name = "panelLanguage";
			this.panelLanguage.Size = new System.Drawing.Size(850, 125);
			this.panelLanguage.TabIndex = 0;
			this.panelLanguage.Visible = false;
			// 
			// labelLevel
			// 
			this.labelLevel.AutoSize = true;
			this.labelLevel.BackColor = System.Drawing.Color.Transparent;
			this.labelLevel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLevel.ForeColor = System.Drawing.Color.Black;
			this.labelLevel.Location = new System.Drawing.Point(540, 44);
			this.labelLevel.Name = "labelLevel";
			this.labelLevel.Size = new System.Drawing.Size(180, 29);
			this.labelLevel.TabIndex = 2;
			this.labelLevel.Text = "Рівень знань:";
			// 
			// labelLanguageNumber
			// 
			this.labelLanguageNumber.AutoSize = true;
			this.labelLanguageNumber.BackColor = System.Drawing.Color.Transparent;
			this.labelLanguageNumber.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLanguageNumber.ForeColor = System.Drawing.Color.Black;
			this.labelLanguageNumber.Location = new System.Drawing.Point(1, 39);
			this.labelLanguageNumber.Name = "labelLanguageNumber";
			this.labelLanguageNumber.Size = new System.Drawing.Size(40, 42);
			this.labelLanguageNumber.TabIndex = 0;
			this.labelLanguageNumber.Text = "1";
			// 
			// labelLanguage
			// 
			this.labelLanguage.AutoSize = true;
			this.labelLanguage.BackColor = System.Drawing.Color.Transparent;
			this.labelLanguage.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLanguage.ForeColor = System.Drawing.Color.Black;
			this.labelLanguage.Location = new System.Drawing.Point(107, 44);
			this.labelLanguage.Name = "labelLanguage";
			this.labelLanguage.Size = new System.Drawing.Size(87, 29);
			this.labelLanguage.TabIndex = 1;
			this.labelLanguage.Text = "Мова:";
			// 
			// richTextBoxChronicDiseases
			// 
			this.richTextBoxChronicDiseases.BackColor = System.Drawing.SystemColors.ControlLight;
			this.richTextBoxChronicDiseases.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxChronicDiseases.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxChronicDiseases.ForeColor = System.Drawing.Color.Black;
			this.richTextBoxChronicDiseases.Location = new System.Drawing.Point(716, 197);
			this.richTextBoxChronicDiseases.MaxLength = 2048;
			this.richTextBoxChronicDiseases.Name = "richTextBoxChronicDiseases";
			this.richTextBoxChronicDiseases.ReadOnly = true;
			this.richTextBoxChronicDiseases.Size = new System.Drawing.Size(500, 164);
			this.richTextBoxChronicDiseases.TabIndex = 9;
			this.richTextBoxChronicDiseases.TabStop = false;
			this.richTextBoxChronicDiseases.Text = "";
			// 
			// labelChronicDiseases
			// 
			this.labelChronicDiseases.AutoSize = true;
			this.labelChronicDiseases.BackColor = System.Drawing.Color.Transparent;
			this.labelChronicDiseases.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChronicDiseases.ForeColor = System.Drawing.Color.Black;
			this.labelChronicDiseases.Location = new System.Drawing.Point(710, 152);
			this.labelChronicDiseases.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelChronicDiseases.Name = "labelChronicDiseases";
			this.labelChronicDiseases.Size = new System.Drawing.Size(312, 29);
			this.labelChronicDiseases.TabIndex = 8;
			this.labelChronicDiseases.Text = "Хронічні захворювання:";
			// 
			// labelSmokerAlcohol
			// 
			this.labelSmokerAlcohol.AutoEllipsis = true;
			this.labelSmokerAlcohol.BackColor = System.Drawing.Color.Transparent;
			this.labelSmokerAlcohol.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSmokerAlcohol.ForeColor = System.Drawing.Color.Black;
			this.labelSmokerAlcohol.Location = new System.Drawing.Point(710, 92);
			this.labelSmokerAlcohol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSmokerAlcohol.Name = "labelSmokerAlcohol";
			this.labelSmokerAlcohol.Size = new System.Drawing.Size(530, 29);
			this.labelSmokerAlcohol.TabIndex = 7;
			this.labelSmokerAlcohol.Text = "Куріння та алкоголь";
			this.labelSmokerAlcohol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelHealth
			// 
			this.labelHealth.AutoEllipsis = true;
			this.labelHealth.AutoSize = true;
			this.labelHealth.BackColor = System.Drawing.Color.Transparent;
			this.labelHealth.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHealth.ForeColor = System.Drawing.Color.Black;
			this.labelHealth.Location = new System.Drawing.Point(709, 27);
			this.labelHealth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHealth.Name = "labelHealth";
			this.labelHealth.Size = new System.Drawing.Size(147, 35);
			this.labelHealth.TabIndex = 6;
			this.labelHealth.Text = "Здоров’я";
			this.labelHealth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelFamilyStatus
			// 
			this.labelFamilyStatus.AutoEllipsis = true;
			this.labelFamilyStatus.BackColor = System.Drawing.Color.Transparent;
			this.labelFamilyStatus.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFamilyStatus.ForeColor = System.Drawing.Color.Black;
			this.labelFamilyStatus.Location = new System.Drawing.Point(12, 272);
			this.labelFamilyStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFamilyStatus.Name = "labelFamilyStatus";
			this.labelFamilyStatus.Size = new System.Drawing.Size(600, 29);
			this.labelFamilyStatus.TabIndex = 4;
			this.labelFamilyStatus.Text = "Сімейний стан";
			this.labelFamilyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBusinessTrip
			// 
			this.labelBusinessTrip.AutoEllipsis = true;
			this.labelBusinessTrip.BackColor = System.Drawing.Color.Transparent;
			this.labelBusinessTrip.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBusinessTrip.ForeColor = System.Drawing.Color.Black;
			this.labelBusinessTrip.Location = new System.Drawing.Point(12, 92);
			this.labelBusinessTrip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelBusinessTrip.Name = "labelBusinessTrip";
			this.labelBusinessTrip.Size = new System.Drawing.Size(600, 29);
			this.labelBusinessTrip.TabIndex = 1;
			this.labelBusinessTrip.Text = "Можливість відряджень";
			this.labelBusinessTrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelChildrenAmount
			// 
			this.labelChildrenAmount.AutoEllipsis = true;
			this.labelChildrenAmount.BackColor = System.Drawing.Color.Transparent;
			this.labelChildrenAmount.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChildrenAmount.ForeColor = System.Drawing.Color.Black;
			this.labelChildrenAmount.Location = new System.Drawing.Point(12, 332);
			this.labelChildrenAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelChildrenAmount.Name = "labelChildrenAmount";
			this.labelChildrenAmount.Size = new System.Drawing.Size(600, 29);
			this.labelChildrenAmount.TabIndex = 5;
			this.labelChildrenAmount.Text = "Кількість дітей";
			this.labelChildrenAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDriverLicense
			// 
			this.labelDriverLicense.AutoEllipsis = true;
			this.labelDriverLicense.BackColor = System.Drawing.Color.Transparent;
			this.labelDriverLicense.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDriverLicense.ForeColor = System.Drawing.Color.Black;
			this.labelDriverLicense.Location = new System.Drawing.Point(12, 152);
			this.labelDriverLicense.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDriverLicense.Name = "labelDriverLicense";
			this.labelDriverLicense.Size = new System.Drawing.Size(600, 29);
			this.labelDriverLicense.TabIndex = 2;
			this.labelDriverLicense.Text = "Посвідчення водія";
			this.labelDriverLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReadiness
			// 
			this.labelReadiness.AutoEllipsis = true;
			this.labelReadiness.BackColor = System.Drawing.Color.Transparent;
			this.labelReadiness.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelReadiness.ForeColor = System.Drawing.Color.Black;
			this.labelReadiness.Location = new System.Drawing.Point(12, 212);
			this.labelReadiness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelReadiness.Name = "labelReadiness";
			this.labelReadiness.Size = new System.Drawing.Size(600, 29);
			this.labelReadiness.TabIndex = 3;
			this.labelReadiness.Text = "Готовність до роботи";
			this.labelReadiness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelExperience
			// 
			this.labelExperience.AutoEllipsis = true;
			this.labelExperience.BackColor = System.Drawing.Color.Transparent;
			this.labelExperience.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExperience.ForeColor = System.Drawing.Color.Black;
			this.labelExperience.Location = new System.Drawing.Point(12, 32);
			this.labelExperience.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelExperience.Name = "labelExperience";
			this.labelExperience.Size = new System.Drawing.Size(600, 29);
			this.labelExperience.TabIndex = 0;
			this.labelExperience.Text = "Досвід роботи";
			this.labelExperience.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CandidateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1354, 501);
			this.Controls.Add(this.panelMore);
			this.Controls.Add(this.richTextBoxContact);
			this.Controls.Add(this.labelContact);
			this.Controls.Add(this.labelBirthday);
			this.Controls.Add(this.labelFullName);
			this.Controls.Add(this.buttonMore);
			this.Controls.Add(this.labelCity);
			this.Controls.Add(this.richTextBoxAdditionalInfo);
			this.Controls.Add(this.labelAdditionalInfoTitle);
			this.Controls.Add(this.labelNationality);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CandidateForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Кандидат";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CandidateForm_FormClosed);
			this.panelMore.ResumeLayout(false);
			this.panelMore.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine)).EndInit();
			this.flpEducations.ResumeLayout(false);
			this.panelEducation.ResumeLayout(false);
			this.panelEducation.PerformLayout();
			this.flpLanguages.ResumeLayout(false);
			this.panelLanguage.ResumeLayout(false);
			this.panelLanguage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonMore;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.RichTextBox richTextBoxAdditionalInfo;
        private System.Windows.Forms.Label labelAdditionalInfoTitle;
        private System.Windows.Forms.Label labelNationality;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.RichTextBox richTextBoxContact;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Panel panelMore;
        private System.Windows.Forms.Label labelExperience;
        private System.Windows.Forms.Label labelReadiness;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.Label labelChildrenAmount;
        private System.Windows.Forms.Label labelBusinessTrip;
        private System.Windows.Forms.Label labelFamilyStatus;
        private System.Windows.Forms.Label labelHealth;
        private System.Windows.Forms.Label labelSmokerAlcohol;
        private System.Windows.Forms.RichTextBox richTextBoxChronicDiseases;
        private System.Windows.Forms.Label labelChronicDiseases;
        private System.Windows.Forms.FlowLayoutPanel flpLanguages;
        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelLanguageNumber;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelLanguageTitle;
        private System.Windows.Forms.Label labelEducationTitle;
        private System.Windows.Forms.FlowLayoutPanel flpEducations;
        private System.Windows.Forms.Panel panelEducation;
        private System.Windows.Forms.Label labelEducationForm;
        private System.Windows.Forms.Label labelEducationDegree;
        private System.Windows.Forms.Label labelDateEnd;
        private System.Windows.Forms.Label labelYearAdmission;
        private System.Windows.Forms.Label labelSpecialty;
        private System.Windows.Forms.Label labelNameInstitution;
        private System.Windows.Forms.Label labelEducationNumber;
        private System.Windows.Forms.PictureBox pictureBoxLine;
        private System.Windows.Forms.Label labelLanguageHelp;
    }
}