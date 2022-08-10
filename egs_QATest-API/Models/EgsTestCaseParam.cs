using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsTestCaseParam
    {
        public int CaseParamId { get; set; }
        public int CaseId { get; set; }
        public string CaseParamTitle { get; set; } = null!;

        public virtual EgsTestCase Case { get; set; } = null!;
    }
}
