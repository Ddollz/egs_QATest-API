using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsStepStatus
    {
        public EgsStepStatus()
        {
            EgsStepStatusAttachments = new HashSet<EgsStepStatusAttachment>();
        }

        public int CaseStepStatusId { get; set; }
        public int CaseStepId { get; set; }
        public string? StepStatusComment { get; set; }
        public string StepStatusType { get; set; } = null!;
        public int? StepStatusAttachDefect { get; set; }

        public virtual EgsStep CaseStep { get; set; } = null!;
        public virtual ICollection<EgsStepStatusAttachment> EgsStepStatusAttachments { get; set; }
    }
}
