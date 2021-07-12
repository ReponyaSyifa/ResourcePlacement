using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
    }
}
