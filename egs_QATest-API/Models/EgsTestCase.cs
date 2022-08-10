using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestCase
    {
        public EgsTestCase()
        {
            EgsSteps = new HashSet<EgsStep>();
            EgsTestCaseAttachments = new HashSet<EgsTestCaseAttachment>();
            EgsTestCaseParams = new HashSet<EgsTestCaseParam>();
            EgsTestPlans = new HashSet<EgsTestPlan>();
        }

        public int CaseId { get; set; }
        public string CaseTitle { get; set; } = null!;
        public int CaseStatus { get; set; }
        public string CaseDesc { get; set; } = null!;
        public int SuiteId { get; set; }
        public int CaseSeverity { get; set; }
        public int? CasePriority { get; set; }
        public int CaseType { get; set; }
        public int CaseLayer { get; set; }
        public int CaseFlaky { get; set; }
        public int CaseIsLock { get; set; }
        public int UserId { get; set; }
        public int? CaseMilestone { get; set; }
        public int CaseBehavior { get; set; }
        public int CaseAutoStat { get; set; }
        public string? CasePreCondition { get; set; }
        public string? CasePostCondition { get; set; }
        public string? CaseTag { get; set; }

        public virtual EgsSuite Suite { get; set; } = null!;
        public virtual EgsAccount User { get; set; } = null!;
        public virtual ICollection<EgsStep> EgsSteps { get; set; }
        public virtual ICollection<EgsTestCaseAttachment> EgsTestCaseAttachments { get; set; }
        public virtual ICollection<EgsTestCaseParam> EgsTestCaseParams { get; set; }
        public virtual ICollection<EgsTestPlan> EgsTestPlans { get; set; }
    }
}
