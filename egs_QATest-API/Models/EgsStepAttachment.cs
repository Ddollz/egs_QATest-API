using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsStepAttachment
    {
        public int StepAttachmentId { get; set; }
        public int CaseStepId { get; set; }
        public byte[]? StepAttachments { get; set; }
        public string StepAttachType { get; set; } = null!;

        public virtual EgsStep CaseStep { get; set; } = null!;
    }
}
