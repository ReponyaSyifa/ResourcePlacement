using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_AccountRoles")]
    public class AccountsRoles
    {
        public virtual Roles Roles { get; set; }
        public int RolesId { get; set; }
        public virtual Accounts Accounts { get; set; }
        public int AccountsId { get; set; }
        
    }
}
