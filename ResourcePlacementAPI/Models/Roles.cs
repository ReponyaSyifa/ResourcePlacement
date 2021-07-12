﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_Roles")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        //[JsonIgnore]
        public virtual ICollection<AccountsRoles> AccountsRoles { get; set; }
    }
}
