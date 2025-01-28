using SharedModels.Models;
using System.Data.Entity;

namespace RecruitmentServer.DataBase
{
	public partial class RecruitmentEntities : DbContext
	{
		public RecruitmentEntities()
			: base("name=RecruitmentEntities")
		{
		}

		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Interview> Interviews { get; set; }
		public virtual DbSet<Application> Applications { get; set; }
		public virtual DbSet<Candidate> Candidates { get; set; }
		public virtual DbSet<Education> Educations { get; set; }
		public virtual DbSet<Language> Languages { get; set; }
		public virtual DbSet<Questionnaire> Questionnaires { get; set; }
		public virtual DbSet<Vacancy> Vacancies { get; set; }
		public virtual DbSet<EducationDegreeRequirement> EducationDegreeRequirements
		{ get; set; }
		public virtual DbSet<Requirement> Requirements { get; set; }
		public virtual DbSet<EducationDegreePoint> EducationDegreePoints { get; set; }
		public virtual DbSet<Point> Points { get; set; }
		public virtual DbSet<InterviewStatus> InterviewStatuses { get; set; }
		public virtual DbSet<FamilyStatus> FamilyStatuses { get; set; }
		public virtual DbSet<BusinessTripOpportunity> BusinessTripOpportunities { get; set; }
		public virtual DbSet<Health> Health { get; set; }
		public virtual DbSet<EducationDegree> EducationDegrees { get; set; }
		public virtual DbSet<EducationForm> EducationForms { get; set; }
		public virtual DbSet<Position> Positions { get; set; }
		public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

		public virtual DbSet<PointDbView> PointsDbView { get; set; }
		public virtual DbSet<RequirementDbView> RequirementsDbView { get; set; }
		public virtual DbSet<EducationDbView> EducationsDbView { get; set; }
		public virtual DbSet<QuestionnaireDbView> QuestionnairesDbView { get; set; }
		public virtual DbSet<ApplicationDbView> ApplicationsDbView { get; set; }
		public virtual DbSet<VacancyDbView> VacanciesDbView { get; set; }
		public virtual DbSet<InterviewDbView> InterviewsDbView { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Application>()
				.HasMany(e => e.Interviews)
				.WithRequired(e => e.Application)
				.HasForeignKey(e => e.ApplicationId);

			modelBuilder.Entity<ApplicationStatus>()
				.HasMany(e => e.Applications)
				.WithRequired(e => e.ApplicationStatus)
				.HasForeignKey(e => e.ApplicationStatusId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<BusinessTripOpportunity>()
				.HasMany(e => e.Questionnaires)
				.WithRequired(e => e.BusinessTripOpportunity)
				.HasForeignKey(e => e.BusinessTripOpportunityId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Candidate>()
				.HasMany(e => e.Applications)
				.WithRequired(e => e.Candidate)
				.HasForeignKey(e => e.CandidateId);

			modelBuilder.Entity<EducationDegree>()
				.HasMany(e => e.Educations)
				.WithRequired(e => e.EducationDegree)
				.HasForeignKey(e => e.EducationDegreeId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EducationDegree>()
				.HasMany(e => e.EducationDegreePoints)
				.WithRequired(e => e.EducationDegree)
				.HasForeignKey(e => e.EducationDegreeId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EducationDegree>()
				.HasMany(e => e.EducationDegreeRequirements)
				.WithRequired(e => e.EducationDegree)
				.HasForeignKey(e => e.EducationDegreeId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EducationForm>()
				.HasMany(e => e.Educations)
				.WithRequired(e => e.EducationForm)
				.HasForeignKey(e => e.EducationFormId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Salary)
				.HasPrecision(19, 4);

			modelBuilder.Entity<FamilyStatus>()
				.HasMany(e => e.Questionnaires)
				.WithRequired(e => e.FamilyStatus)
				.HasForeignKey(e => e.FamilyStatusId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Health>()
				.HasMany(e => e.Questionnaires)
				.WithRequired(e => e.Health)
				.HasForeignKey(e => e.HealthId);

			modelBuilder.Entity<Interview>()
				.HasMany(e => e.Employees)
				.WithOptional(e => e.Interview)
				.HasForeignKey(e => e.InterviewId)
				.WillCascadeOnDelete();

			modelBuilder.Entity<InterviewStatus>()
				.HasMany(e => e.Interviews)
				.WithRequired(e => e.InterviewStatus)
				.HasForeignKey(e => e.InterviewStatusId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Point>()
				.HasMany(e => e.Degrees)
				.WithRequired(e => e.Point)
				.HasForeignKey(e => e.PointId);

			modelBuilder.Entity<Point>()
				.HasMany(e => e.Vacancies)
				.WithRequired(e => e.Point)
				.HasForeignKey(e => e.PointId);

			modelBuilder.Entity<Position>()
				.HasMany(e => e.Vacancies)
				.WithRequired(e => e.Position)
				.HasForeignKey(e => e.PositionId);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Candidates)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.QuestionnaireId);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Educations)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.QuestionnaireId);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Languages)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.QuestionnaireId);

			modelBuilder.Entity<Requirement>()
				.HasMany(e => e.EducationDegreeRequirements)
				.WithRequired(e => e.Requirement)
				.HasForeignKey(e => e.RequirementId);

			modelBuilder.Entity<Requirement>()
				.HasMany(e => e.Vacancies)
				.WithRequired(e => e.Requirement)
				.HasForeignKey(e => e.RequirementId);

			modelBuilder.Entity<Vacancy>()
				.Property(e => e.Salary)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Vacancy>()
				.HasMany(e => e.Applications)
				.WithRequired(e => e.Vacancy)
				.HasForeignKey(e => e.VacancyId);

			modelBuilder.Entity<VacancyDbView>()
				.Property(e => e.Salary)
				.HasPrecision(19, 4);
		}
	}
}