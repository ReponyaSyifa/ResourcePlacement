using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_CustomerUsers")]
    public class CustomerUsers
    {
        [Key]
        public int CustomerUserId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Projects> Projects { get; set; }
        [JsonIgnore]
        public virtual Accounts Accounts { get; set; }
    }
}
