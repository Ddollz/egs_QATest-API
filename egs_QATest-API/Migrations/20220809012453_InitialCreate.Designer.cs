﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using egs_QATest_API.Models;

#nullable disable

namespace egs_QATest_API.Migrations
{
    [DbContext(typeof(EgsQAsuiteContext))]
    [Migration("20220809012453_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("egs_QATest_API.Models.EgsAccount", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("User_Email");

                    b.Property<int>("UserIsAdmin")
                        .HasColumnType("int")
                        .HasColumnName("User_isAdmin");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("User_Password");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("User_Role");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int")
                        .HasColumnName("User_Status");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("egsAccount", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsEnvironment", b =>
                {
                    b.Property<int>("EnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Environment_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnvironmentId"), 1L, 1);

                    b.Property<string>("EnvironmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Environment_Name");

                    b.HasKey("EnvironmentId")
                        .HasName("PK_egsEnvirontment");

                    b.ToTable("egsEnvironment", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsMilestone", b =>
                {
                    b.Property<int>("MilestoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Milestone_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MilestoneId"), 1L, 1);

                    b.Property<string>("MilestoneDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Milestone_Desc");

                    b.Property<DateTime>("MilestoneDueDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Milestone_DueDate");

                    b.Property<string>("MilestoneName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Milestone_Name");

                    b.Property<int>("MilstoneActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Milstone_Active")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("MilestoneId");

                    b.ToTable("egsMilestone", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsProject", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Project_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<int>("ProjectAccessType")
                        .HasColumnType("int")
                        .HasColumnName("Project_AccessType");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Project_Code");

                    b.Property<string>("ProjectDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Project_Desc");

                    b.Property<int>("ProjectMemberAccess")
                        .HasColumnType("int")
                        .HasColumnName("Project_MemberAccess");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Project_Name");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("Project_Status");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("egsProject", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Role_Name");

                    b.HasKey("RoleId");

                    b.ToTable("egsRoles", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStep", b =>
                {
                    b.Property<int>("CaseStepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Case_StepID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseStepId"), 1L, 1);

                    b.Property<int>("CaseId")
                        .HasColumnType("int")
                        .HasColumnName("Case_ID");

                    b.Property<string>("StepAction")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Step_Action");

                    b.Property<string>("StepExpectedResult")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Step_ExpectedResult");

                    b.Property<string>("StepInputData")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Step_InputData");

                    b.Property<int>("StepStatus")
                        .HasColumnType("int")
                        .HasColumnName("Step_Status");

                    b.Property<int>("StepType")
                        .HasColumnType("int")
                        .HasColumnName("Step_Type");

                    b.HasKey("CaseStepId");

                    b.HasIndex("CaseId");

                    b.ToTable("egsStep", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepAttachment", b =>
                {
                    b.Property<int>("StepAttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StepAttachment_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StepAttachmentId"), 1L, 1);

                    b.Property<int>("CaseStepId")
                        .HasColumnType("int")
                        .HasColumnName("Case_StepID");

                    b.Property<string>("StepAttachType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Step_AttachType");

                    b.Property<byte[]>("StepAttachments")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Step_Attachments");

                    b.HasKey("StepAttachmentId");

                    b.HasIndex("CaseStepId");

                    b.ToTable("egsStepAttachment", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepStatus", b =>
                {
                    b.Property<int>("CaseStepStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Case_StepStatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseStepStatusId"), 1L, 1);

                    b.Property<int>("CaseStepId")
                        .HasColumnType("int")
                        .HasColumnName("Case_StepID");

                    b.Property<int?>("StepStatusAttachDefect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StepStatus_AttachDefect")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("StepStatusComment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("StepStatus_Comment");

                    b.Property<string>("StepStatusType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("StepStatus_Type");

                    b.HasKey("CaseStepStatusId");

                    b.HasIndex("CaseStepId");

                    b.ToTable("egsStepStatus", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepStatusAttachment", b =>
                {
                    b.Property<int>("StepStatusAttachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StepStatusAttach_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StepStatusAttachId"), 1L, 1);

                    b.Property<int>("CaseStepStatusId")
                        .HasColumnType("int")
                        .HasColumnName("Case_StepStatusID");

                    b.Property<string>("StepStatAttachType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("StepStat_AttachType");

                    b.Property<byte[]>("StepStatAttachment")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("StepStat_Attachment");

                    b.HasKey("StepStatusAttachId");

                    b.HasIndex("CaseStepStatusId");

                    b.ToTable("egsStepStatusAttachment", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsSuite", b =>
                {
                    b.Property<int>("SuiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Suite_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuiteId"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("Project_ID");

                    b.Property<string>("SuiteDesc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Suite_Desc");

                    b.Property<int>("SuiteIsLock")
                        .HasColumnType("int")
                        .HasColumnName("Suite_isLock");

                    b.Property<string>("SuiteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Suite_Name");

                    b.Property<string>("SuitePreCondition")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Suite_PreCondition");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("SuiteId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("egsSuite", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCase", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Case_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseId"), 1L, 1);

                    b.Property<int>("CaseAutoStat")
                        .HasColumnType("int")
                        .HasColumnName("Case_AutoStat");

                    b.Property<int>("CaseBehavior")
                        .HasColumnType("int")
                        .HasColumnName("Case_Behavior");

                    b.Property<string>("CaseDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Case_Desc");

                    b.Property<int>("CaseFlaky")
                        .HasColumnType("int")
                        .HasColumnName("Case_Flaky");

                    b.Property<int>("CaseIsLock")
                        .HasColumnType("int")
                        .HasColumnName("Case_isLock");

                    b.Property<int>("CaseLayer")
                        .HasColumnType("int")
                        .HasColumnName("Case_Layer");

                    b.Property<int?>("CaseMilestone")
                        .HasColumnType("int")
                        .HasColumnName("Case_Milestone");

                    b.Property<string>("CasePostCondition")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Case_PostCondition");

                    b.Property<string>("CasePreCondition")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Case_PreCondition");

                    b.Property<int?>("CasePriority")
                        .HasColumnType("int")
                        .HasColumnName("Case_Priority");

                    b.Property<int>("CaseSeverity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Case_Severity")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("CaseStatus")
                        .HasColumnType("int")
                        .HasColumnName("Case_Status");

                    b.Property<string>("CaseTag")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Case_Tag");

                    b.Property<string>("CaseTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Case_Title");

                    b.Property<int>("CaseType")
                        .HasColumnType("int")
                        .HasColumnName("Case_Type");

                    b.Property<int>("SuiteId")
                        .HasColumnType("int")
                        .HasColumnName("Suite_ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("CaseId")
                        .HasName("PK_egsCase");

                    b.HasIndex("SuiteId");

                    b.HasIndex("UserId");

                    b.ToTable("egsTestCase", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseAttachment", b =>
                {
                    b.Property<int>("CaseAttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CaseAttachment_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseAttachmentId"), 1L, 1);

                    b.Property<string>("CaseAttachType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Case_AttachType");

                    b.Property<byte[]>("CaseAttachments")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Case_Attachments");

                    b.Property<int>("CaseId")
                        .HasColumnType("int")
                        .HasColumnName("Case_ID");

                    b.HasKey("CaseAttachmentId");

                    b.HasIndex("CaseId");

                    b.ToTable("egsTestCaseAttachment", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseComment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Comment_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Comment_Content");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Comment_Date");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_id");

                    b.HasKey("CommentId")
                        .HasName("PK_egsCaseComment");

                    b.HasIndex("UserId");

                    b.ToTable("egsTestCaseComment", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseCommentAttachment", b =>
                {
                    b.Property<int>("CommentAttachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CommentAttach_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentAttachId"), 1L, 1);

                    b.Property<string>("CommentAttachType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Comment_AttachType");

                    b.Property<byte[]>("CommentAttachment")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Comment_Attachment");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int")
                        .HasColumnName("Comment_ID");

                    b.HasKey("CommentAttachId")
                        .HasName("PK_egsCommentAttachment");

                    b.HasIndex("CommentId");

                    b.ToTable("egsTestCaseCommentAttachment", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseParam", b =>
                {
                    b.Property<int>("CaseParamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CaseParam_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseParamId"), 1L, 1);

                    b.Property<int>("CaseId")
                        .HasColumnType("int")
                        .HasColumnName("Case_ID");

                    b.Property<string>("CaseParamTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Case_ParamTitle");

                    b.HasKey("CaseParamId");

                    b.HasIndex("CaseId");

                    b.ToTable("egsTestCaseParam", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestPlan", b =>
                {
                    b.Property<int>("TestPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TestPlan_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestPlanId"), 1L, 1);

                    b.Property<int>("CaseId")
                        .HasColumnType("int")
                        .HasColumnName("Case_ID");

                    b.Property<int>("TestPlanCaseCount")
                        .HasColumnType("int")
                        .HasColumnName("TestPlan_CaseCount");

                    b.Property<string>("TestPlanDesc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("TestPlan_Desc");

                    b.Property<DateTime>("TestPlanRunTime")
                        .HasColumnType("datetime")
                        .HasColumnName("TestPlan_RunTime");

                    b.Property<string>("TestPlanTitle")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TestPlan_Title");

                    b.HasKey("TestPlanId");

                    b.HasIndex("CaseId");

                    b.ToTable("egsTestPlan", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestRun", b =>
                {
                    b.Property<int>("TestRunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TestRun_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestRunId"), 1L, 1);

                    b.Property<int>("TestPlanId")
                        .HasColumnType("int")
                        .HasColumnName("TestPlan_ID");

                    b.Property<int?>("TestRunCompletionRange")
                        .HasColumnType("int")
                        .HasColumnName("TestRun_CompletionRange");

                    b.Property<DateTime>("TestRunDateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("TestRun_DateCreated");

                    b.Property<string>("TestRunDesc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("TestRun_Desc");

                    b.Property<int?>("TestRunEnvironment")
                        .HasColumnType("int")
                        .HasColumnName("TestRun_Environment");

                    b.Property<int?>("TestRunMilestone")
                        .HasColumnType("int")
                        .HasColumnName("TestRun_Milestone");

                    b.Property<string>("TestRunTags")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TestRun_Tags");

                    b.Property<string>("TestRunTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TestRun_Title");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("TestRunId")
                        .HasName("PK_TestRun");

                    b.HasIndex("TestPlanId");

                    b.HasIndex("TestRunEnvironment");

                    b.HasIndex("UserId");

                    b.ToTable("egsTestRun", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestRunHistory", b =>
                {
                    b.Property<int>("TestRunHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TestRunHistory_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestRunHistoryId"), 1L, 1);

                    b.Property<DateTime>("TestRunHistoryDate")
                        .HasColumnType("datetime")
                        .HasColumnName("TestRun_HistoryDate");

                    b.Property<int>("TestRunId")
                        .HasColumnType("int")
                        .HasColumnName("TestRun_ID");

                    b.Property<string>("TestRunUpdatedContents")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("TestRun_UpdatedContents");

                    b.HasKey("TestRunHistoryId");

                    b.HasIndex("TestRunId");

                    b.ToTable("egsTestRunHistory", (string)null);
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsAccount", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsRole", "Role")
                        .WithMany("EgsAccounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_egsAccount_egsAccount");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsProject", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsAccount", "User")
                        .WithMany("EgsProjects")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_egsProject_egsAccount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStep", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestCase", "Case")
                        .WithMany("EgsSteps")
                        .HasForeignKey("CaseId")
                        .IsRequired()
                        .HasConstraintName("FK_egsStep_egsCase");

                    b.Navigation("Case");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepAttachment", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsStep", "CaseStep")
                        .WithMany("EgsStepAttachments")
                        .HasForeignKey("CaseStepId")
                        .IsRequired()
                        .HasConstraintName("FK_egsStepAttachment_egsStep");

                    b.Navigation("CaseStep");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepStatus", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsStep", "CaseStep")
                        .WithMany("EgsStepStatuses")
                        .HasForeignKey("CaseStepId")
                        .IsRequired()
                        .HasConstraintName("FK_egsStepStatus_egsStep");

                    b.Navigation("CaseStep");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepStatusAttachment", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsStepStatus", "CaseStepStatus")
                        .WithMany("EgsStepStatusAttachments")
                        .HasForeignKey("CaseStepStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_egsStepStatusAttachment_egsStepStatus");

                    b.Navigation("CaseStepStatus");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsSuite", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsProject", "Project")
                        .WithMany("EgsSuites")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_egsSuite_egsProject");

                    b.HasOne("egs_QATest_API.Models.EgsAccount", "User")
                        .WithMany("EgsSuites")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_egsSuite_egsAccount");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCase", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsSuite", "Suite")
                        .WithMany("EgsTestCases")
                        .HasForeignKey("SuiteId")
                        .IsRequired()
                        .HasConstraintName("FK_egsCase_egsSuite");

                    b.HasOne("egs_QATest_API.Models.EgsAccount", "User")
                        .WithMany("EgsTestCases")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_egsCase_egsAccount");

                    b.Navigation("Suite");

                    b.Navigation("User");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseAttachment", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestCase", "Case")
                        .WithMany("EgsTestCaseAttachments")
                        .HasForeignKey("CaseId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestCaseAttachment_egsCase");

                    b.Navigation("Case");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseComment", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsAccount", "User")
                        .WithMany("EgsTestCaseComments")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestCaseComment_egsAccount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseCommentAttachment", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestCaseComment", "Comment")
                        .WithMany("EgsTestCaseCommentAttachments")
                        .HasForeignKey("CommentId")
                        .HasConstraintName("FK_egsCommentAttachment_egsCaseComment");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseParam", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestCase", "Case")
                        .WithMany("EgsTestCaseParams")
                        .HasForeignKey("CaseId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestCaseParam_egsCase");

                    b.Navigation("Case");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestPlan", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestCase", "Case")
                        .WithMany("EgsTestPlans")
                        .HasForeignKey("CaseId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestPlan_egsCase");

                    b.Navigation("Case");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestRun", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestPlan", "TestPlan")
                        .WithMany("EgsTestRuns")
                        .HasForeignKey("TestPlanId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestRun_egsTestPlan");

                    b.HasOne("egs_QATest_API.Models.EgsEnvironment", "TestRunEnvironmentNavigation")
                        .WithMany("EgsTestRuns")
                        .HasForeignKey("TestRunEnvironment")
                        .HasConstraintName("FK_egsTestRun_egsEnvironment");

                    b.HasOne("egs_QATest_API.Models.EgsMilestone", "TestRunEnvironment1")
                        .WithMany("EgsTestRuns")
                        .HasForeignKey("TestRunEnvironment")
                        .HasConstraintName("FK_egsTestRun_egsMilestone");

                    b.HasOne("egs_QATest_API.Models.EgsAccount", "User")
                        .WithMany("EgsTestRuns")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestRun_egsAccount");

                    b.Navigation("TestPlan");

                    b.Navigation("TestRunEnvironment1");

                    b.Navigation("TestRunEnvironmentNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestRunHistory", b =>
                {
                    b.HasOne("egs_QATest_API.Models.EgsTestRun", "TestRun")
                        .WithMany("EgsTestRunHistories")
                        .HasForeignKey("TestRunId")
                        .IsRequired()
                        .HasConstraintName("FK_egsTestRunHistory_egsTestRun");

                    b.Navigation("TestRun");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsAccount", b =>
                {
                    b.Navigation("EgsProjects");

                    b.Navigation("EgsSuites");

                    b.Navigation("EgsTestCaseComments");

                    b.Navigation("EgsTestCases");

                    b.Navigation("EgsTestRuns");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsEnvironment", b =>
                {
                    b.Navigation("EgsTestRuns");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsMilestone", b =>
                {
                    b.Navigation("EgsTestRuns");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsProject", b =>
                {
                    b.Navigation("EgsSuites");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsRole", b =>
                {
                    b.Navigation("EgsAccounts");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStep", b =>
                {
                    b.Navigation("EgsStepAttachments");

                    b.Navigation("EgsStepStatuses");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsStepStatus", b =>
                {
                    b.Navigation("EgsStepStatusAttachments");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsSuite", b =>
                {
                    b.Navigation("EgsTestCases");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCase", b =>
                {
                    b.Navigation("EgsSteps");

                    b.Navigation("EgsTestCaseAttachments");

                    b.Navigation("EgsTestCaseParams");

                    b.Navigation("EgsTestPlans");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestCaseComment", b =>
                {
                    b.Navigation("EgsTestCaseCommentAttachments");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestPlan", b =>
                {
                    b.Navigation("EgsTestRuns");
                });

            modelBuilder.Entity("egs_QATest_API.Models.EgsTestRun", b =>
                {
                    b.Navigation("EgsTestRunHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
