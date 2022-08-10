using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsProject
    {
        public EgsProject()
        {
            EgsSuites = new HashSet<EgsSuite>();
        }

        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectCode { get; set; } = null!;
        public string ProjectDesc { get; set; } = null!;
        public int ProjectAccessType { get; set; }
        public int ProjectMemberAccess { get; set; }
        public int ProjectStatus { get; set; }

        public virtual EgsAccount User { get; set; } = null!;
        public virtual ICollection<EgsSuite> EgsSuites { get; set; }
    }
}
