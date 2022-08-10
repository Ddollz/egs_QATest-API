using System;
using System.Collections.Generic;

namespace egs_QATest_API.Models
{
    public partial class EgsRole
    {
        public EgsRole()
        {
            EgsAccounts = new HashSet<EgsAccount>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<EgsAccount> EgsAccounts { get; set; }
    }
}
