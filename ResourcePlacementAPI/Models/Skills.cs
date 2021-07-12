﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    public class Skills
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
    }
}