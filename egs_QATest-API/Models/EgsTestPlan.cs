using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestPlan
    {
        public EgsTestPlan()
        {
            EgsTestRuns = new HashSet<EgsTestRun>();
        }

        public int TestPlanId { get; set; }
        public string? TestPlanTitle { get; set; }
        public string? TestPlanDesc { get; set; }
        public int TestPlanCaseCount { get; set; }
        public DateTime TestPlanRunTime { get; set; }
        public int CaseId { get; set; }

        public virtual EgsTestCase Case { get; set; } = null!;
        public virtual ICollection<EgsTestRun> EgsTestRuns { get; set; }
    }
}
