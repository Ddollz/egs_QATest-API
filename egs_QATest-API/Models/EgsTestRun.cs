using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestRun
    {
        public EgsTestRun()
        {
            EgsTestRunHistories = new HashSet<EgsTestRunHistory>();
        }

        public int TestRunId { get; set; }
        public string TestRunTitle { get; set; } = null!;
        public string? TestRunDesc { get; set; }
        public int TestPlanId { get; set; }
        public int? TestRunEnvironment { get; set; }
        public int? TestRunMilestone { get; set; }
        public int UserId { get; set; }
        public string? TestRunTags { get; set; }
        public int? TestRunCompletionRange { get; set; }
        public DateTime TestRunDateCreated { get; set; }

        public virtual EgsTestPlan TestPlan { get; set; } = null!;
        public virtual EgsMilestone? TestRunEnvironment1 { get; set; }
        public virtual EgsEnvironment? TestRunEnvironmentNavigation { get; set; }
        public virtual EgsAccount User { get; set; } = null!;
        public virtual ICollection<EgsTestRunHistory> EgsTestRunHistories { get; set; }
    }
}
