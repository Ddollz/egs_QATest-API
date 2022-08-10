using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestCaseCommentAttachment
    {
        public int CommentAttachId { get; set; }
        public int? CommentId { get; set; }
        public byte[]? CommentAttachment { get; set; }
        public string CommentAttachType { get; set; } = null!;

        public virtual EgsTestCaseComment? Comment { get; set; }
    }
}
