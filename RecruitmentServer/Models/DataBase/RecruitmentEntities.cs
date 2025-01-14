using SharedModels.Models;
using System.Data.Entity;

namespace RecruitmentServer.Models.DataBase
{
	internal partial class RecruitmentEntities : DbContext
	{
		internal RecruitmentEntities()
			: base("name=RecruitmentEntities")
		{
		}

		internal virtual DbSet<Application> Application { get; set; }
		internal virtual DbSet<ApplicationStatus> Application_Status { get; set; }
		internal virtual DbSet<BusinessTripOpportunity> Business_Trip_Opportunity { get; set; }
		internal virtual DbSet<Candidate> Candidate { get; set; }
		internal virtual DbSet<Education> Education { get; set; }
		internal virtual DbSet<EducationDegree> Education_Degree { get; set; }
		internal virtual DbSet<EducationForm> Education_Form { get; set; }
		internal virtual DbSet<EducationDegreePoint> EducationDegree_Point { get; set; }
		internal virtual DbSet<EducationDegreeRequirement> EducationDegree_Requirement { get; set; }
		internal virtual DbSet<Employee> Employee { get; set; }
		internal virtual DbSet<FamilyStatus> Family_Status { get; set; }
		internal virtual DbSet<Health> Health { get; set; }
		internal virtual DbSet<Interview> Interview { get; set; }
		internal virtual DbSet<InterviewStatus> Interview_Status { get; set; }
		internal virtual DbSet<Language> Language { get; set; }
		internal virtual DbSet<Point> Point { get; set; }
		internal virtual DbSet<Position> Position { get; set; }
		internal virtual DbSet<Questionnaire> Questionnaire { get; set; }
		internal virtual DbSet<Requirement> Requirement { get; set; }
		internal virtual DbSet<Vacancy> Vacancy { get; set; }
		internal virtual DbSet<ApplicationDbView> View_Application { get; set; }
		internal virtual DbSet<EducationDbView> View_Education { get; set; }
		internal virtual DbSet<InterviewDbView> View_Interview { get; set; }
		internal virtual DbSet<PointDbView> View_Point { get; set; }
		internal virtual DbSet<QuestionnaireDbView> View_Questionnaire { get; set; }
		internal virtual DbSet<RequirementDbView> View_Requirement { get; set; }
		internal virtual DbSet<VacancyDbView> View_Vacancy { get; set; }

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