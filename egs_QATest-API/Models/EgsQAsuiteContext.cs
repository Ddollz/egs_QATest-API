using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace egs_QATest_API.Models
{
    public partial class EgsQAsuiteContext : DbContext
    {
        public EgsQAsuiteContext()
        {
        }

        public EgsQAsuiteContext(DbContextOptions<EgsQAsuiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EgsAccount> EgsAccounts { get; set; } = null!;
        public virtual DbSet<EgsEnvironment> EgsEnvironments { get; set; } = null!;
        public virtual DbSet<EgsMilestone> EgsMilestones { get; set; } = null!;
        public virtual DbSet<EgsProject> EgsProjects { get; set; } = null!;
        public virtual DbSet<EgsRole> EgsRoles { get; set; } = null!;
        public virtual DbSet<EgsStep> EgsSteps { get; set; } = null!;
        public virtual DbSet<EgsStepAttachment> EgsStepAttachments { get; set; } = null!;
        public virtual DbSet<EgsStepStatus> EgsStepStatuses { get; set; } = null!;
        public virtual DbSet<EgsStepStatusAttachment> EgsStepStatusAttachments { get; set; } = null!;
        public virtual DbSet<EgsSuite> EgsSuites { get; set; } = null!;
        public virtual DbSet<EgsTestCase> EgsTestCases { get; set; } = null!;
        public virtual DbSet<EgsTestCaseAttachment> EgsTestCaseAttachments { get; set; } = null!;
        public virtual DbSet<EgsTestCaseComment> EgsTestCaseComments { get; set; } = null!;
        public virtual DbSet<EgsTestCaseCommentAttachment> EgsTestCaseCommentAttachments { get; set; } = null!;
        public virtual DbSet<EgsTestCaseParam> EgsTestCaseParams { get; set; } = null!;
        public virtual DbSet<EgsTestPlan> EgsTestPlans { get; set; } = null!;
        public virtual DbSet<EgsTestRun> EgsTestRuns { get; set; } = null!;
        public virtual DbSet<EgsTestRunHistory> EgsTestRunHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WORKSTATION-181\\SQLEXPRESS;Database=EgsQAsuite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EgsAccount>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("egsAccount");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserIsAdmin).HasColumnName("User_isAdmin");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(10)
                    .HasColumnName("User_Role");

                entity.Property(e => e.UserStatus).HasColumnName("User_Status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EgsAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsAccount_egsAccount");
            });

            modelBuilder.Entity<EgsEnvironment>(entity =>
            {
                entity.HasKey(e => e.EnvironmentId)
                    .HasName("PK_egsEnvirontment");

                entity.ToTable("egsEnvironment");

                entity.Property(e => e.EnvironmentId).HasColumnName("Environment_ID");

                entity.Property(e => e.EnvironmentName)
                    .HasMaxLength(100)
                    .HasColumnName("Environment_Name");
            });

            modelBuilder.Entity<EgsMilestone>(entity =>
            {
                entity.HasKey(e => e.MilestoneId);

                entity.ToTable("egsMilestone");

                entity.Property(e => e.MilestoneId).HasColumnName("Milestone_ID");

                entity.Property(e => e.MilestoneDesc)
                    .HasMaxLength(500)
                    .HasColumnName("Milestone_Desc");

                entity.Property(e => e.MilestoneDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Milestone_DueDate");

                entity.Property(e => e.MilestoneName)
                    .HasMaxLength(100)
                    .HasColumnName("Milestone_Name");

                entity.Property(e => e.MilstoneActive)
                    .HasColumnName("Milstone_Active")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EgsProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("egsProject");

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.ProjectAccessType).HasColumnName("Project_AccessType");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(50)
                    .HasColumnName("Project_Code");

                entity.Property(e => e.ProjectDesc)
                    .HasMaxLength(500)
                    .HasColumnName("Project_Desc");

                entity.Property(e => e.ProjectMemberAccess).HasColumnName("Project_MemberAccess");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("Project_Name");

                entity.Property(e => e.ProjectStatus).HasColumnName("Project_Status");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EgsProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsProject_egsAccount");
            });

            modelBuilder.Entity<EgsRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("egsRoles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<EgsStep>(entity =>
            {
                entity.HasKey(e => e.CaseStepId);

                entity.ToTable("egsStep");

                entity.Property(e => e.CaseStepId).HasColumnName("Case_StepID");

                entity.Property(e => e.CaseId).HasColumnName("Case_ID");

                entity.Property(e => e.StepAction)
                    .HasMaxLength(500)
                    .HasColumnName("Step_Action");

                entity.Property(e => e.StepExpectedResult)
                    .HasMaxLength(500)
                    .HasColumnName("Step_ExpectedResult");

                entity.Property(e => e.StepInputData)
                    .HasMaxLength(500)
                    .HasColumnName("Step_InputData");

                entity.Property(e => e.StepStatus).HasColumnName("Step_Status");

                entity.Property(e => e.StepType).HasColumnName("Step_Type");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.EgsSteps)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsStep_egsCase");
            });

            modelBuilder.Entity<EgsStepAttachment>(entity =>
            {
                entity.HasKey(e => e.StepAttachmentId);

                entity.ToTable("egsStepAttachment");

                entity.Property(e => e.StepAttachmentId).HasColumnName("StepAttachment_ID");

                entity.Property(e => e.CaseStepId).HasColumnName("Case_StepID");

                entity.Property(e => e.StepAttachType)
                    .HasMaxLength(50)
                    .HasColumnName("Step_AttachType");

                entity.Property(e => e.StepAttachments).HasColumnName("Step_Attachments");

                entity.HasOne(d => d.CaseStep)
                    .WithMany(p => p.EgsStepAttachments)
                    .HasForeignKey(d => d.CaseStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsStepAttachment_egsStep");
            });

            modelBuilder.Entity<EgsStepStatus>(entity =>
            {
                entity.HasKey(e => e.CaseStepStatusId);

                entity.ToTable("egsStepStatus");

                entity.Property(e => e.CaseStepStatusId).HasColumnName("Case_StepStatusID");

                entity.Property(e => e.CaseStepId).HasColumnName("Case_StepID");

                entity.Property(e => e.StepStatusAttachDefect)
                    .HasColumnName("StepStatus_AttachDefect")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StepStatusComment)
                    .HasMaxLength(500)
                    .HasColumnName("StepStatus_Comment");

                entity.Property(e => e.StepStatusType)
                    .HasMaxLength(20)
                    .HasColumnName("StepStatus_Type");

                entity.HasOne(d => d.CaseStep)
                    .WithMany(p => p.EgsStepStatuses)
                    .HasForeignKey(d => d.CaseStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsStepStatus_egsStep");
            });

            modelBuilder.Entity<EgsStepStatusAttachment>(entity =>
            {
                entity.HasKey(e => e.StepStatusAttachId);

                entity.ToTable("egsStepStatusAttachment");

                entity.Property(e => e.StepStatusAttachId).HasColumnName("StepStatusAttach_ID");

                entity.Property(e => e.CaseStepStatusId).HasColumnName("Case_StepStatusID");

                entity.Property(e => e.StepStatAttachType)
                    .HasMaxLength(100)
                    .HasColumnName("StepStat_AttachType");

                entity.Property(e => e.StepStatAttachment).HasColumnName("StepStat_Attachment");

                entity.HasOne(d => d.CaseStepStatus)
                    .WithMany(p => p.EgsStepStatusAttachments)
                    .HasForeignKey(d => d.CaseStepStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsStepStatusAttachment_egsStepStatus");
            });

            modelBuilder.Entity<EgsSuite>(entity =>
            {
                entity.HasKey(e => e.SuiteId);

                entity.ToTable("egsSuite");

                entity.Property(e => e.SuiteId).HasColumnName("Suite_ID");

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.SuiteDesc)
                    .HasMaxLength(500)
                    .HasColumnName("Suite_Desc");

                entity.Property(e => e.SuiteIsLock).HasColumnName("Suite_isLock");

                entity.Property(e => e.SuiteName)
                    .HasMaxLength(100)
                    .HasColumnName("Suite_Name");

                entity.Property(e => e.SuitePreCondition)
                    .HasMaxLength(500)
                    .HasColumnName("Suite_PreCondition");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EgsSuites)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsSuite_egsProject");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EgsSuites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsSuite_egsAccount");
            });

            modelBuilder.Entity<EgsTestCase>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("PK_egsCase");

                entity.ToTable("egsTestCase");

                entity.Property(e => e.CaseId).HasColumnName("Case_ID");

                entity.Property(e => e.CaseAutoStat).HasColumnName("Case_AutoStat");

                entity.Property(e => e.CaseBehavior).HasColumnName("Case_Behavior");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(500)
                    .HasColumnName("Case_Desc");

                entity.Property(e => e.CaseFlaky).HasColumnName("Case_Flaky");

                entity.Property(e => e.CaseIsLock).HasColumnName("Case_isLock");

                entity.Property(e => e.CaseLayer).HasColumnName("Case_Layer");

                entity.Property(e => e.CaseMilestone).HasColumnName("Case_Milestone");

                entity.Property(e => e.CasePostCondition)
                    .HasMaxLength(100)
                    .HasColumnName("Case_PostCondition");

                entity.Property(e => e.CasePreCondition)
                    .HasMaxLength(100)
                    .HasColumnName("Case_PreCondition");

                entity.Property(e => e.CasePriority).HasColumnName("Case_Priority");

                entity.Property(e => e.CaseSeverity)
                    .HasColumnName("Case_Severity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CaseStatus).HasColumnName("Case_Status");

                entity.Property(e => e.CaseTag)
                    .HasMaxLength(20)
                    .HasColumnName("Case_Tag");

                entity.Property(e => e.CaseTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Title");

                entity.Property(e => e.CaseType).HasColumnName("Case_Type");

                entity.Property(e => e.SuiteId).HasColumnName("Suite_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Suite)
                    .WithMany(p => p.EgsTestCases)
                    .HasForeignKey(d => d.SuiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsCase_egsSuite");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EgsTestCases)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsCase_egsAccount");
            });

            modelBuilder.Entity<EgsTestCaseAttachment>(entity =>
            {
                entity.HasKey(e => e.CaseAttachmentId);

                entity.ToTable("egsTestCaseAttachment");

                entity.Property(e => e.CaseAttachmentId).HasColumnName("CaseAttachment_ID");

                entity.Property(e => e.CaseAttachType)
                    .HasMaxLength(100)
                    .HasColumnName("Case_AttachType");

                entity.Property(e => e.CaseAttachments).HasColumnName("Case_Attachments");

                entity.Property(e => e.CaseId).HasColumnName("Case_ID");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.EgsTestCaseAttachments)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestCaseAttachment_egsCase");
            });

            modelBuilder.Entity<EgsTestCaseComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_egsCaseComment");

                entity.ToTable("egsTestCaseComment");

                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.Property(e => e.CommentContent)
                    .HasMaxLength(500)
                    .HasColumnName("Comment_Content");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Comment_Date");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EgsTestCaseComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestCaseComment_egsAccount");
            });

            modelBuilder.Entity<EgsTestCaseCommentAttachment>(entity =>
            {
                entity.HasKey(e => e.CommentAttachId)
                    .HasName("PK_egsCommentAttachment");

                entity.ToTable("egsTestCaseCommentAttachment");

                entity.Property(e => e.CommentAttachId).HasColumnName("CommentAttach_ID");

                entity.Property(e => e.CommentAttachType)
                    .HasMaxLength(100)
                    .HasColumnName("Comment_AttachType");

                entity.Property(e => e.CommentAttachment).HasColumnName("Comment_Attachment");

                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.EgsTestCaseCommentAttachments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_egsCommentAttachment_egsCaseComment");
            });

            modelBuilder.Entity<EgsTestCaseParam>(entity =>
            {
                entity.HasKey(e => e.CaseParamId);

                entity.ToTable("egsTestCaseParam");

                entity.Property(e => e.CaseParamId).HasColumnName("CaseParam_ID");

                entity.Property(e => e.CaseId).HasColumnName("Case_ID");

                entity.Property(e => e.CaseParamTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Case_ParamTitle");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.EgsTestCaseParams)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestCaseParam_egsCase");
            });

            modelBuilder.Entity<EgsTestPlan>(entity =>
            {
                entity.HasKey(e => e.TestPlanId);

                entity.ToTable("egsTestPlan");

                entity.Property(e => e.TestPlanId).HasColumnName("TestPlan_ID");

                entity.Property(e => e.CaseId).HasColumnName("Case_ID");

                entity.Property(e => e.TestPlanCaseCount).HasColumnName("TestPlan_CaseCount");

                entity.Property(e => e.TestPlanDesc)
                    .HasMaxLength(500)
                    .HasColumnName("TestPlan_Desc");

                entity.Property(e => e.TestPlanRunTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TestPlan_RunTime");

                entity.Property(e => e.TestPlanTitle)
                    .HasMaxLength(100)
                    .HasColumnName("TestPlan_Title");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.EgsTestPlans)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestPlan_egsCase");
            });

            modelBuilder.Entity<EgsTestRun>(entity =>
            {
                entity.HasKey(e => e.TestRunId)
                    .HasName("PK_TestRun");

                entity.ToTable("egsTestRun");

                entity.Property(e => e.TestRunId).HasColumnName("TestRun_ID");

                entity.Property(e => e.TestPlanId).HasColumnName("TestPlan_ID");

                entity.Property(e => e.TestRunCompletionRange).HasColumnName("TestRun_CompletionRange");

                entity.Property(e => e.TestRunDateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("TestRun_DateCreated");

                entity.Property(e => e.TestRunDesc)
                    .HasMaxLength(500)
                    .HasColumnName("TestRun_Desc");

                entity.Property(e => e.TestRunEnvironment).HasColumnName("TestRun_Environment");

                entity.Property(e => e.TestRunMilestone).HasColumnName("TestRun_Milestone");

                entity.Property(e => e.TestRunTags)
                    .HasMaxLength(100)
                    .HasColumnName("TestRun_Tags");

                entity.Property(e => e.TestRunTitle)
                    .HasMaxLength(100)
                    .HasColumnName("TestRun_Title");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.TestPlan)
                    .WithMany(p => p.EgsTestRuns)
                    .HasForeignKey(d => d.TestPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestRun_egsTestPlan");

                entity.HasOne(d => d.TestRunEnvironmentNavigation)
                    .WithMany(p => p.EgsTestRuns)
                    .HasForeignKey(d => d.TestRunEnvironment)
                    .HasConstraintName("FK_egsTestRun_egsEnvironment");

                entity.HasOne(d => d.TestRunEnvironment1)
                    .WithMany(p => p.EgsTestRuns)
                    .HasForeignKey(d => d.TestRunEnvironment)
                    .HasConstraintName("FK_egsTestRun_egsMilestone");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EgsTestRuns)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestRun_egsAccount");
            });

            modelBuilder.Entity<EgsTestRunHistory>(entity =>
            {
                entity.HasKey(e => e.TestRunHistoryId);

                entity.ToTable("egsTestRunHistory");

                entity.Property(e => e.TestRunHistoryId).HasColumnName("TestRunHistory_ID");

                entity.Property(e => e.TestRunHistoryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TestRun_HistoryDate");

                entity.Property(e => e.TestRunId).HasColumnName("TestRun_ID");

                entity.Property(e => e.TestRunUpdatedContents)
                    .HasMaxLength(500)
                    .HasColumnName("TestRun_UpdatedContents");

                entity.HasOne(d => d.TestRun)
                    .WithMany(p => p.EgsTestRunHistories)
                    .HasForeignKey(d => d.TestRunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_egsTestRunHistory_egsTestRun");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
