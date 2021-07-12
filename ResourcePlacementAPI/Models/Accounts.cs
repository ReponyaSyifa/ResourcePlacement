using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_Accounts")]
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<AccountsRoles> AccountsRoles { get; set; }
    }
}
