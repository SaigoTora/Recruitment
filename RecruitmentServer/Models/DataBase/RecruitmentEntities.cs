using SharedModels.Models;
using System.Data.Entity;

namespace RecruitmentServer.Models.DataBase
{
	public partial class RecruitmentEntities : DbContext
	{
		public RecruitmentEntities()
			: base("name=RecruitmentEntities")
		{
		}

		public virtual DbSet<Application> Application { get; set; }
		public virtual DbSet<ApplicationStatus> Application_Status { get; set; }
		public virtual DbSet<BusinessTripOpportunity> Business_Trip_Opportunity { get; set; }
		public virtual DbSet<Candidate> Candidate { get; set; }
		public virtual DbSet<Education> Education { get; set; }
		public virtual DbSet<EducationDegree> Education_Degree { get; set; }
		public virtual DbSet<EducationForm> Education_Form { get; set; }
		public virtual DbSet<EducationDegreePoint> EducationDegree_Point { get; set; }
		public virtual DbSet<EducationDegreeRequirement> EducationDegree_Requirement { get; set; }
		public virtual DbSet<Employee> Employee { get; set; }
		public virtual DbSet<FamilyStatus> Family_Status { get; set; }
		public virtual DbSet<Health> Health { get; set; }
		public virtual DbSet<Interview> Interview { get; set; }
		public virtual DbSet<InterviewStatus> Interview_Status { get; set; }
		public virtual DbSet<Language> Language { get; set; }
		public virtual DbSet<Point> Point { get; set; }
		public virtual DbSet<Position> Position { get; set; }
		public virtual DbSet<Questionnaire> Questionnaire { get; set; }
		public virtual DbSet<Requirement> Requirement { get; set; }
		public virtual DbSet<Vacancy> Vacancy { get; set; }
		public virtual DbSet<ApplicationDbView> View_Application { get; set; }
		public virtual DbSet<EducationDbView> View_Education { get; set; }
		public virtual DbSet<InterviewDbView> View_Interview { get; set; }
		public virtual DbSet<PointDbView> View_Point { get; set; }
		public virtual DbSet<QuestionnaireDbView> View_Questionnaire { get; set; }
		public virtual DbSet<RequirementDbView> View_Requirement { get; set; }
		public virtual DbSet<VacancyDbView> View_Vacancy { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Application>()
				.HasMany(e => e.Interview)
				.WithRequired(e => e.Application)
				.HasForeignKey(e => e.IdApplication);

			modelBuilder.Entity<ApplicationStatus>()
				.HasMany(e => e.Application)
				.WithRequired(e => e.ApplicationStatus)
				.HasForeignKey(e => e.IdApplicationStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<BusinessTripOpportunity>()
				.HasMany(e => e.Questionnaire)
				.WithRequired(e => e.BusinessTripOpportunity)
				.HasForeignKey(e => e.IdBusinessTripOpportunity)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Candidate>()
				.HasMany(e => e.Application)
				.WithRequired(e => e.Candidate)
				.HasForeignKey(e => e.IdCandidate);

			modelBuilder.Entity<EducationDegree>()
				.HasMany(e => e.Education)
				.WithRequired(e => e.EducationDegree)
				.HasForeignKey(e => e.IdEducationDegree)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EducationDegree>()
				.HasMany(e => e.EducationDegreePoint)
				.WithRequired(e => e.EducationDegree)
				.HasForeignKey(e => e.IdEducationDegree)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EducationDegree>()
				.HasMany(e => e.EducationDegreeRequirement)
				.WithRequired(e => e.EducationDegree)
				.HasForeignKey(e => e.IdEducationDegree)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EducationForm>()
				.HasMany(e => e.Education)
				.WithRequired(e => e.EducationForm)
				.HasForeignKey(e => e.IdEducationForm)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Salary)
				.HasPrecision(19, 4);

			modelBuilder.Entity<FamilyStatus>()
				.HasMany(e => e.Questionnaire)
				.WithRequired(e => e.FamilyStatus)
				.HasForeignKey(e => e.IdFamilyStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Health>()
				.HasMany(e => e.Questionnaire)
				.WithRequired(e => e.Health)
				.HasForeignKey(e => e.IdHealth);

			modelBuilder.Entity<Interview>()
				.HasMany(e => e.Employee)
				.WithOptional(e => e.Interview)
				.HasForeignKey(e => e.IdInterview)
				.WillCascadeOnDelete();

			modelBuilder.Entity<InterviewStatus>()
				.HasMany(e => e.Interview)
				.WithRequired(e => e.InterviewStatus)
				.HasForeignKey(e => e.IdInterviewStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Point>()
				.HasMany(e => e.Degrees)
				.WithRequired(e => e.Point)
				.HasForeignKey(e => e.IdPoint);

			modelBuilder.Entity<Point>()
				.HasMany(e => e.Vacancy)
				.WithRequired(e => e.Point)
				.HasForeignKey(e => e.IdPoint);

			modelBuilder.Entity<Position>()
				.HasMany(e => e.Vacancy)
				.WithRequired(e => e.Position)
				.HasForeignKey(e => e.IdPosition);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Candidate)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.IdQuestionnaire);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Educations)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.IdQuestionnaire);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Languages)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.IdQuestionnaire);

			modelBuilder.Entity<Requirement>()
				.HasMany(e => e.EducationDegreeRequirement)
				.WithRequired(e => e.Requirement)
				.HasForeignKey(e => e.IdRequirement);

			modelBuilder.Entity<Requirement>()
				.HasMany(e => e.Vacancy)
				.WithRequired(e => e.Requirement)
				.HasForeignKey(e => e.IdRequirement);

			modelBuilder.Entity<Vacancy>()
				.Property(e => e.Salary)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Vacancy>()
				.HasMany(e => e.Application)
				.WithRequired(e => e.Vacancy)
				.HasForeignKey(e => e.IdVacancy);

			modelBuilder.Entity<VacancyDbView>()
				.Property(e => e.Salary)
				.HasPrecision(19, 4);
		}
	}
}