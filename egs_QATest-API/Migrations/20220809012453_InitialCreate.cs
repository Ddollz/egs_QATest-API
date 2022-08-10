using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace egs_QATest_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "egsEnvironment",
                columns: table => new
                {
                    Environment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Environment_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsEnvirontment", x => x.Environment_ID);
                });

            migrationBuilder.CreateTable(
                name: "egsMilestone",
                columns: table => new
                {
                    Milestone_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Milestone_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Milestone_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Milstone_Active = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Milestone_DueDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsMilestone", x => x.Milestone_ID);
                });

            migrationBuilder.CreateTable(
                name: "egsRoles",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsRoles", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "egsAccount",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User_Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_isAdmin = table.Column<int>(type: "int", nullable: false),
                    User_Status = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsAccount", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_egsAccount_egsAccount",
                        column: x => x.Role_ID,
                        principalTable: "egsRoles",
                        principalColumn: "Role_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsProject",
                columns: table => new
                {
                    Project_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Project_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Project_Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Project_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Project_AccessType = table.Column<int>(type: "int", nullable: false),
                    Project_MemberAccess = table.Column<int>(type: "int", nullable: false),
                    Project_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsProject", x => x.Project_ID);
                    table.ForeignKey(
                        name: "FK_egsProject_egsAccount",
                        column: x => x.User_ID,
                        principalTable: "egsAccount",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestCaseComment",
                columns: table => new
                {
                    Comment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comment_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsCaseComment", x => x.Comment_ID);
                    table.ForeignKey(
                        name: "FK_egsTestCaseComment_egsAccount",
                        column: x => x.User_id,
                        principalTable: "egsAccount",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsSuite",
                columns: table => new
                {
                    Suite_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suite_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Suite_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Suite_PreCondition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Suite_isLock = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Project_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsSuite", x => x.Suite_ID);
                    table.ForeignKey(
                        name: "FK_egsSuite_egsAccount",
                        column: x => x.User_ID,
                        principalTable: "egsAccount",
                        principalColumn: "User_ID");
                    table.ForeignKey(
                        name: "FK_egsSuite_egsProject",
                        column: x => x.Project_ID,
                        principalTable: "egsProject",
                        principalColumn: "Project_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestCaseCommentAttachment",
                columns: table => new
                {
                    CommentAttach_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_ID = table.Column<int>(type: "int", nullable: true),
                    Comment_Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Comment_AttachType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsCommentAttachment", x => x.CommentAttach_ID);
                    table.ForeignKey(
                        name: "FK_egsCommentAttachment_egsCaseComment",
                        column: x => x.Comment_ID,
                        principalTable: "egsTestCaseComment",
                        principalColumn: "Comment_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestCase",
                columns: table => new
                {
                    Case_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Case_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Case_Status = table.Column<int>(type: "int", nullable: false),
                    Case_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Suite_ID = table.Column<int>(type: "int", nullable: false),
                    Case_Severity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Case_Priority = table.Column<int>(type: "int", nullable: true),
                    Case_Type = table.Column<int>(type: "int", nullable: false),
                    Case_Layer = table.Column<int>(type: "int", nullable: false),
                    Case_Flaky = table.Column<int>(type: "int", nullable: false),
                    Case_isLock = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Case_Milestone = table.Column<int>(type: "int", nullable: true),
                    Case_Behavior = table.Column<int>(type: "int", nullable: false),
                    Case_AutoStat = table.Column<int>(type: "int", nullable: false),
                    Case_PreCondition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Case_PostCondition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Case_Tag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsCase", x => x.Case_ID);
                    table.ForeignKey(
                        name: "FK_egsCase_egsAccount",
                        column: x => x.User_ID,
                        principalTable: "egsAccount",
                        principalColumn: "User_ID");
                    table.ForeignKey(
                        name: "FK_egsCase_egsSuite",
                        column: x => x.Suite_ID,
                        principalTable: "egsSuite",
                        principalColumn: "Suite_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsStep",
                columns: table => new
                {
                    Case_StepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step_Type = table.Column<int>(type: "int", nullable: false),
                    Case_ID = table.Column<int>(type: "int", nullable: false),
                    Step_Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Step_InputData = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Step_ExpectedResult = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Step_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsStep", x => x.Case_StepID);
                    table.ForeignKey(
                        name: "FK_egsStep_egsCase",
                        column: x => x.Case_ID,
                        principalTable: "egsTestCase",
                        principalColumn: "Case_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestCaseAttachment",
                columns: table => new
                {
                    CaseAttachment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Case_ID = table.Column<int>(type: "int", nullable: false),
                    Case_Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Case_AttachType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsTestCaseAttachment", x => x.CaseAttachment_ID);
                    table.ForeignKey(
                        name: "FK_egsTestCaseAttachment_egsCase",
                        column: x => x.Case_ID,
                        principalTable: "egsTestCase",
                        principalColumn: "Case_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestCaseParam",
                columns: table => new
                {
                    CaseParam_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Case_ID = table.Column<int>(type: "int", nullable: false),
                    Case_ParamTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsTestCaseParam", x => x.CaseParam_ID);
                    table.ForeignKey(
                        name: "FK_egsTestCaseParam_egsCase",
                        column: x => x.Case_ID,
                        principalTable: "egsTestCase",
                        principalColumn: "Case_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestPlan",
                columns: table => new
                {
                    TestPlan_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPlan_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TestPlan_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TestPlan_CaseCount = table.Column<int>(type: "int", nullable: false),
                    TestPlan_RunTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Case_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsTestPlan", x => x.TestPlan_ID);
                    table.ForeignKey(
                        name: "FK_egsTestPlan_egsCase",
                        column: x => x.Case_ID,
                        principalTable: "egsTestCase",
                        principalColumn: "Case_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsStepAttachment",
                columns: table => new
                {
                    StepAttachment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Case_StepID = table.Column<int>(type: "int", nullable: false),
                    Step_Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Step_AttachType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsStepAttachment", x => x.StepAttachment_ID);
                    table.ForeignKey(
                        name: "FK_egsStepAttachment_egsStep",
                        column: x => x.Case_StepID,
                        principalTable: "egsStep",
                        principalColumn: "Case_StepID");
                });

            migrationBuilder.CreateTable(
                name: "egsStepStatus",
                columns: table => new
                {
                    Case_StepStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Case_StepID = table.Column<int>(type: "int", nullable: false),
                    StepStatus_Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StepStatus_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StepStatus_AttachDefect = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsStepStatus", x => x.Case_StepStatusID);
                    table.ForeignKey(
                        name: "FK_egsStepStatus_egsStep",
                        column: x => x.Case_StepID,
                        principalTable: "egsStep",
                        principalColumn: "Case_StepID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestRun",
                columns: table => new
                {
                    TestRun_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestRun_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TestRun_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TestPlan_ID = table.Column<int>(type: "int", nullable: false),
                    TestRun_Environment = table.Column<int>(type: "int", nullable: true),
                    TestRun_Milestone = table.Column<int>(type: "int", nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    TestRun_Tags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TestRun_CompletionRange = table.Column<int>(type: "int", nullable: true),
                    TestRun_DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRun", x => x.TestRun_ID);
                    table.ForeignKey(
                        name: "FK_egsTestRun_egsAccount",
                        column: x => x.User_ID,
                        principalTable: "egsAccount",
                        principalColumn: "User_ID");
                    table.ForeignKey(
                        name: "FK_egsTestRun_egsEnvironment",
                        column: x => x.TestRun_Environment,
                        principalTable: "egsEnvironment",
                        principalColumn: "Environment_ID");
                    table.ForeignKey(
                        name: "FK_egsTestRun_egsMilestone",
                        column: x => x.TestRun_Environment,
                        principalTable: "egsMilestone",
                        principalColumn: "Milestone_ID");
                    table.ForeignKey(
                        name: "FK_egsTestRun_egsTestPlan",
                        column: x => x.TestPlan_ID,
                        principalTable: "egsTestPlan",
                        principalColumn: "TestPlan_ID");
                });

            migrationBuilder.CreateTable(
                name: "egsStepStatusAttachment",
                columns: table => new
                {
                    StepStatusAttach_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Case_StepStatusID = table.Column<int>(type: "int", nullable: false),
                    StepStat_Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StepStat_AttachType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsStepStatusAttachment", x => x.StepStatusAttach_ID);
                    table.ForeignKey(
                        name: "FK_egsStepStatusAttachment_egsStepStatus",
                        column: x => x.Case_StepStatusID,
                        principalTable: "egsStepStatus",
                        principalColumn: "Case_StepStatusID");
                });

            migrationBuilder.CreateTable(
                name: "egsTestRunHistory",
                columns: table => new
                {
                    TestRunHistory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestRun_ID = table.Column<int>(type: "int", nullable: false),
                    TestRun_HistoryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TestRun_UpdatedContents = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egsTestRunHistory", x => x.TestRunHistory_ID);
                    table.ForeignKey(
                        name: "FK_egsTestRunHistory_egsTestRun",
                        column: x => x.TestRun_ID,
                        principalTable: "egsTestRun",
                        principalColumn: "TestRun_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_egsAccount_Role_ID",
                table: "egsAccount",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsProject_User_ID",
                table: "egsProject",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsStep_Case_ID",
                table: "egsStep",
                column: "Case_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsStepAttachment_Case_StepID",
                table: "egsStepAttachment",
                column: "Case_StepID");

            migrationBuilder.CreateIndex(
                name: "IX_egsStepStatus_Case_StepID",
                table: "egsStepStatus",
                column: "Case_StepID");

            migrationBuilder.CreateIndex(
                name: "IX_egsStepStatusAttachment_Case_StepStatusID",
                table: "egsStepStatusAttachment",
                column: "Case_StepStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_egsSuite_Project_ID",
                table: "egsSuite",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsSuite_User_ID",
                table: "egsSuite",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestCase_Suite_ID",
                table: "egsTestCase",
                column: "Suite_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestCase_User_ID",
                table: "egsTestCase",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestCaseAttachment_Case_ID",
                table: "egsTestCaseAttachment",
                column: "Case_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestCaseComment_User_id",
                table: "egsTestCaseComment",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestCaseCommentAttachment_Comment_ID",
                table: "egsTestCaseCommentAttachment",
                column: "Comment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestCaseParam_Case_ID",
                table: "egsTestCaseParam",
                column: "Case_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestPlan_Case_ID",
                table: "egsTestPlan",
                column: "Case_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestRun_TestPlan_ID",
                table: "egsTestRun",
                column: "TestPlan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestRun_TestRun_Environment",
                table: "egsTestRun",
                column: "TestRun_Environment");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestRun_User_ID",
                table: "egsTestRun",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_egsTestRunHistory_TestRun_ID",
                table: "egsTestRunHistory",
                column: "TestRun_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "egsStepAttachment");

            migrationBuilder.DropTable(
                name: "egsStepStatusAttachment");

            migrationBuilder.DropTable(
                name: "egsTestCaseAttachment");

            migrationBuilder.DropTable(
                name: "egsTestCaseCommentAttachment");

            migrationBuilder.DropTable(
                name: "egsTestCaseParam");

            migrationBuilder.DropTable(
                name: "egsTestRunHistory");

            migrationBuilder.DropTable(
                name: "egsStepStatus");

            migrationBuilder.DropTable(
                name: "egsTestCaseComment");

            migrationBuilder.DropTable(
                name: "egsTestRun");

            migrationBuilder.DropTable(
                name: "egsStep");

            migrationBuilder.DropTable(
                name: "egsEnvironment");

            migrationBuilder.DropTable(
                name: "egsMilestone");

            migrationBuilder.DropTable(
                name: "egsTestPlan");

            migrationBuilder.DropTable(
                name: "egsTestCase");

            migrationBuilder.DropTable(
                name: "egsSuite");

            migrationBuilder.DropTable(
                name: "egsProject");

            migrationBuilder.DropTable(
                name: "egsAccount");

            migrationBuilder.DropTable(
                name: "egsRoles");
        }
    }
}
