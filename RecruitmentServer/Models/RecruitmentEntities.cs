using SharedModels.Models;
using System.Data.Entity;

namespace RecruitmentServer.Models
{
	public partial class RecruitmentEntities : DbContext
	{
		public RecruitmentEntities()
			: base("name=RecruitmentEntities")
		{
		}

		public virtual DbSet<Application> Application { get; set; }
		public virtual DbSet<Application_Status> Application_Status { get; set; }
		public virtual DbSet<Business_Trip_Opportunity> Business_Trip_Opportunity { get; set; }
		public virtual DbSet<Candidate> Candidate { get; set; }
		public virtual DbSet<Education> Education { get; set; }
		public virtual DbSet<Education_Degree> Education_Degree { get; set; }
		public virtual DbSet<Education_Form> Education_Form { get; set; }
		public virtual DbSet<EducationDegreePoint> EducationDegree_Point { get; set; }
		public virtual DbSet<EducationDegree_Requirement> EducationDegree_Requirement { get; set; }
		public virtual DbSet<Employee> Employee { get; set; }
		public virtual DbSet<Family_Status> Family_Status { get; set; }
		public virtual DbSet<Health> Health { get; set; }
		public virtual DbSet<Interview> Interview { get; set; }
		public virtual DbSet<Interview_Status> Interview_Status { get; set; }
		public virtual DbSet<Language> Language { get; set; }
		public virtual DbSet<Point> Point { get; set; }
		public virtual DbSet<Position> Position { get; set; }
		public virtual DbSet<Questionnaire> Questionnaire { get; set; }
		public virtual DbSet<Requirement> Requirement { get; set; }
		public virtual DbSet<Vacancy> Vacancy { get; set; }
		public virtual DbSet<View_Application> View_Application { get; set; }
		public virtual DbSet<View_Education> View_Education { get; set; }
		public virtual DbSet<View_Interview> View_Interview { get; set; }
		public virtual DbSet<View_Point> View_Point { get; set; }
		public virtual DbSet<View_Questionnaire> View_Questionnaire { get; set; }
		public virtual DbSet<View_Requirement> View_Requirement { get; set; }
		public virtual DbSet<View_Vacancy> View_Vacancy { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Application>()
				.HasMany(e => e.Interview)
				.WithRequired(e => e.Application)
				.HasForeignKey(e => e.id_application);

			modelBuilder.Entity<Application_Status>()
				.HasMany(e => e.Application)
				.WithRequired(e => e.Application_Status)
				.HasForeignKey(e => e.id_application_status)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Business_Trip_Opportunity>()
				.HasMany(e => e.Questionnaire)
				.WithRequired(e => e.Business_Trip_Opportunity)
				.HasForeignKey(e => e.id_business_trip_opportunity)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Candidate>()
				.HasMany(e => e.Application)
				.WithRequired(e => e.Candidate)
				.HasForeignKey(e => e.id_candidate);

			modelBuilder.Entity<Education_Degree>()
				.HasMany(e => e.Education)
				.WithRequired(e => e.Education_Degree)
				.HasForeignKey(e => e.id_education_degree)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Education_Degree>()
				.HasMany(e => e.EducationDegree_Point)
				.WithRequired(e => e.Education_Degree)
				.HasForeignKey(e => e.IdEducationDegree)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Education_Degree>()
				.HasMany(e => e.EducationDegree_Requirement)
				.WithRequired(e => e.Education_Degree)
				.HasForeignKey(e => e.id_education_degree)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Education_Form>()
				.HasMany(e => e.Education)
				.WithRequired(e => e.Education_Form)
				.HasForeignKey(e => e.id_education_form)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Employee>()
				.Property(e => e.salary)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Family_Status>()
				.HasMany(e => e.Questionnaire)
				.WithRequired(e => e.Family_Status)
				.HasForeignKey(e => e.id_family_status)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Health>()
				.HasMany(e => e.Questionnaire)
				.WithRequired(e => e.Health)
				.HasForeignKey(e => e.id_health);

			modelBuilder.Entity<Interview>()
				.HasMany(e => e.Employee)
				.WithOptional(e => e.Interview)
				.HasForeignKey(e => e.id_interview)
				.WillCascadeOnDelete();

			modelBuilder.Entity<Interview_Status>()
				.HasMany(e => e.Interview)
				.WithRequired(e => e.Interview_Status)
				.HasForeignKey(e => e.id_interview_status)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Point>()
				.HasMany(e => e.Degrees)
				.WithRequired(e => e.Point)
				.HasForeignKey(e => e.IdPoint);

			modelBuilder.Entity<Point>()
				.HasMany(e => e.Vacancy)
				.WithRequired(e => e.Point)
				.HasForeignKey(e => e.id_point);

			modelBuilder.Entity<Position>()
				.HasMany(e => e.Vacancy)
				.WithRequired(e => e.Position)
				.HasForeignKey(e => e.id_position);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Candidate)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.id_questionnaire);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Education)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.id_questionnaire);

			modelBuilder.Entity<Questionnaire>()
				.HasMany(e => e.Language)
				.WithRequired(e => e.Questionnaire)
				.HasForeignKey(e => e.id_questionnaire);

			modelBuilder.Entity<Requirement>()
				.HasMany(e => e.EducationDegree_Requirement)
				.WithRequired(e => e.Requirement)
				.HasForeignKey(e => e.id_requirement);

			modelBuilder.Entity<Requirement>()
				.HasMany(e => e.Vacancy)
				.WithRequired(e => e.Requirement)
				.HasForeignKey(e => e.id_requirement);

			modelBuilder.Entity<Vacancy>()
				.Property(e => e.salary)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Vacancy>()
				.HasMany(e => e.Application)
				.WithRequired(e => e.Vacancy)
				.HasForeignKey(e => e.id_vacancy);

			modelBuilder.Entity<View_Vacancy>()
				.Property(e => e.salary)
				.HasPrecision(19, 4);
		}
	}
}
