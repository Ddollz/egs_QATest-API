using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsMilestone
    {
        public EgsMilestone()
        {
            EgsTestRuns = new HashSet<EgsTestRun>();
        }

        public int MilestoneId { get; set; }
        public string MilestoneName { get; set; } = null!;
        public string MilestoneDesc { get; set; } = null!;
        public int MilstoneActive { get; set; }
        public DateTime MilestoneDueDate { get; set; }

        public virtual ICollection<EgsTestRun> EgsTestRuns { get; set; }
    }
}
