using Domain;

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<archivedproject> archivedprojects { get; set; }
        public virtual DbSet<candidatefolder> candidatefolders { get; set; }
        public virtual DbSet<contract> contracts { get; set; }
        public virtual DbSet<dayoff> dayoffs { get; set; }
        public virtual DbSet<inbox> inboxes { get; set; }
        public virtual DbSet<jobrequest> jobrequests { get; set; }
        public virtual DbSet<Mandate> mandates { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<organizationalchart> organizationalcharts { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<projectskill> projectskills { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<resourceskill> resourceskills { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<test> tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<archivedproject>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<archivedproject>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<archivedproject>()
                .Property(e => e.projectName)
                .IsUnicode(false);

            modelBuilder.Entity<archivedproject>()
                .Property(e => e.projectType)
                .IsUnicode(false);

            modelBuilder.Entity<candidatefolder>()
                .Property(e => e.Motivation_Letter)
                .IsUnicode(false);

            modelBuilder.Entity<candidatefolder>()
                .Property(e => e.Passport)
                .IsUnicode(false);

            modelBuilder.Entity<candidatefolder>()
                .Property(e => e.Section_3)
                .IsUnicode(false);

            modelBuilder.Entity<candidatefolder>()
                .Property(e => e.medical_folder)
                .IsUnicode(false);

            modelBuilder.Entity<dayoff>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<dayoff>()
                .Property(e => e.stateType)
                .IsUnicode(false);

            modelBuilder.Entity<dayoff>()
                .Property(e => e.typeDayOff)
                .IsUnicode(false);

            modelBuilder.Entity<dayoff>()
                .HasMany(e => e.people)
                .WithMany(e => e.dayoffs)
                .Map(m => m.ToTable("person_dayoff", "map").MapLeftKey("dayoff").MapRightKey("Resources_id"));

            modelBuilder.Entity<inbox>()
                .HasMany(e => e.messages)
                .WithOptional(e => e.inbox)
                .HasForeignKey(e => e.inBox_id);

            modelBuilder.Entity<inbox>()
                .HasMany(e => e.people)
                .WithOptional(e => e.inbox)
                .HasForeignKey(e => e.inBox_id);

            modelBuilder.Entity<jobrequest>()
                .Property(e => e.Cv)
                .IsUnicode(false);

            modelBuilder.Entity<jobrequest>()
                .Property(e => e.speciality)
                .IsUnicode(false);

            modelBuilder.Entity<jobrequest>()
                .Property(e => e.stateType)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e._object)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.receiver)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.sender)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.accountManager)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.clientName)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.directionalLevel)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.nameAssignmentManagerClient)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.programName)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.projectName)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .Property(e => e.projectResponsible)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalchart>()
                .HasMany(e => e.projects)
                .WithOptional(e => e.organizationalchart)
                .HasForeignKey(e => e.organizationalChart_id);

            modelBuilder.Entity<organizationalchart>()
                .HasMany(e => e.people)
                .WithMany(e => e.organizationalcharts)
                .Map(m => m.ToTable("organizationalchart_person").MapLeftKey("organizationalCharts_id").MapRightKey("resources_id"));

            modelBuilder.Entity<person>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.roleT)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.candidateState)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.clientCategory)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.clientType)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.nameSociety)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.availability)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.businessSector)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.jobType)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.seniority)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.workProfil)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.candidatefolders)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.Candidate_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.contracts)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.jobrequests)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.candidate_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.mandates)
                .WithRequired(e => e.person)
                .HasForeignKey(e => e.ressourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.mandates1)
                .WithOptional(e => e.person1)
                .HasForeignKey(e => e.gps_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.messages)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.person_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.notes)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.id_Client);

            modelBuilder.Entity<person>()
                .HasMany(e => e.notes1)
                .WithOptional(e => e.person1)
                .HasForeignKey(e => e.id_Resource);

            modelBuilder.Entity<person>()
                .HasMany(e => e.requests)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.tests)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.candidate_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.requests1)
                .WithOptional(e => e.person1)
                .HasForeignKey(e => e.administrator_id);

            modelBuilder.Entity<person>()
                .HasMany(e => e.projects)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.clientId);

            modelBuilder.Entity<person>()
                .HasMany(e => e.requests2)
                .WithOptional(e => e.person2)
                .HasForeignKey(e => e.suggessedResource_id);

            modelBuilder.Entity<project>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.projectName)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.projectType)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.mandates)
                .WithRequired(e => e.project)
                .HasForeignKey(e => e.projetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.people)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.projectskills)
                .WithRequired(e => e.project)
                .HasForeignKey(e => e.idProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.requests)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<request>()
                .Property(e => e.educationScolarity)
                .IsUnicode(false);

            modelBuilder.Entity<request>()
                .Property(e => e.manager)
                .IsUnicode(false);

            modelBuilder.Entity<request>()
                .Property(e => e.requestedProfil)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.NameSkill)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .HasMany(e => e.projectskills)
                .WithRequired(e => e.skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<test>()
                .Property(e => e.Employment_Letter)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.TestFile)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.TestResponseFile)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.TestType)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.result)
                .IsUnicode(false);
        }
    }
}
