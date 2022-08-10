using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsStep
    {
        public EgsStep()
        {
            EgsStepAttachments = new HashSet<EgsStepAttachment>();
            EgsStepStatuses = new HashSet<EgsStepStatus>();
        }

        public int CaseStepId { get; set; }
        public int StepType { get; set; }
        public int CaseId { get; set; }
        public string StepAction { get; set; } = null!;
        public string StepInputData { get; set; } = null!;
        public string? StepExpectedResult { get; set; }
        public int StepStatus { get; set; }

        public virtual EgsTestCase Case { get; set; } = null!;
        public virtual ICollection<EgsStepAttachment> EgsStepAttachments { get; set; }
        public virtual ICollection<EgsStepStatus> EgsStepStatuses { get; set; }
    }
}
