using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestRunHistory
    {
        public int TestRunHistoryId { get; set; }
        public int TestRunId { get; set; }
        public DateTime TestRunHistoryDate { get; set; }
        public string TestRunUpdatedContents { get; set; } = null!;

        public virtual EgsTestRun TestRun { get; set; } = null!;
    }
}
