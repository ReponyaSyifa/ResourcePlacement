using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_T_Accounts")]
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerUserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Employees Employees { get; set; }
        [JsonIgnore]
        public virtual CustomerUsers CustomerUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountsRoles> AccountsRoles { get; set; }
    }
}
