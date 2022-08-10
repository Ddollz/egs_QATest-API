using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsSuite
    {
        public EgsSuite()
        {
            EgsTestCases = new HashSet<EgsTestCase>();
        }

        public int SuiteId { get; set; }
        public string SuiteName { get; set; } = null!;
        public string? SuiteDesc { get; set; }
        public string? SuitePreCondition { get; set; }
        public int SuiteIsLock { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual EgsProject Project { get; set; } = null!;
        public virtual EgsAccount User { get; set; } = null!;
        public virtual ICollection<EgsTestCase> EgsTestCases { get; set; }
    }
}
