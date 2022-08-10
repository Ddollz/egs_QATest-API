using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestCaseComment
    {
        public EgsTestCaseComment()
        {
            EgsTestCaseCommentAttachments = new HashSet<EgsTestCaseCommentAttachment>();
        }

        public int CommentId { get; set; }
        public string CommentContent { get; set; } = null!;
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }

        public virtual EgsAccount User { get; set; } = null!;
        public virtual ICollection<EgsTestCaseCommentAttachment> EgsTestCaseCommentAttachments { get; set; }
    }
}
