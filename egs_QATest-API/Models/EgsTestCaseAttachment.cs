using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestCaseAttachment
    {
        public int CaseAttachmentId { get; set; }
        public int CaseId { get; set; }
        public byte[]? CaseAttachments { get; set; }
        public string CaseAttachType { get; set; } = null!;

        public virtual EgsTestCase Case { get; set; } = null!;
    }
}
