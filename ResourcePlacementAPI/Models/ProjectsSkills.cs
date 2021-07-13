using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_ProjectSkills")]
    public class ProjectsSkills
    {
        public virtual Skills Skills { get; set; }
        public int SkillsId { get; set; }
        public virtual Projects Projects { get; set; }
        public int ProjectsId { get; set; }
    }
}
