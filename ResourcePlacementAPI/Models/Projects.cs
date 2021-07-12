using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_Projects")]
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }

        public virtual ICollection<Participants>Participants { get; set; }
        public virtual CustomerUsers CustomerUsers { get; set; }
        public int CustomerUsersId { get; set; }

        public virtual ICollection<ProjectsSkills> ProjectsSkills { get; set; }
    }
}
