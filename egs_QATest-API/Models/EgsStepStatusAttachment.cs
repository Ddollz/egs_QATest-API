using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsStepStatusAttachment
    {
        public int StepStatusAttachId { get; set; }
        public int CaseStepStatusId { get; set; }
        public byte[]? StepStatAttachment { get; set; }
        public string StepStatAttachType { get; set; } = null!;

        public virtual EgsStepStatus CaseStepStatus { get; set; } = null!;
    }
}
