using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsEnvironment
    {
        public EgsEnvironment()
        {
            EgsTestRuns = new HashSet<EgsTestRun>();
        }

        public int EnvironmentId { get; set; }
        public string EnvironmentName { get; set; } = null!;

        public virtual ICollection<EgsTestRun> EgsTestRuns { get; set; }
    }
}
