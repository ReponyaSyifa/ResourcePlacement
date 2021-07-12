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
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PicName { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual Accounts Accounts { get; set; }
    }
}
