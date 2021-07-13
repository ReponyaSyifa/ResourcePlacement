using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_T_Projects")]
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public int CustomerUserId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Participants>Participants { get; set; }
        [JsonIgnore]
        public virtual CustomerUsers CustomerUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectsSkills> ProjectsSkills { get; set; }
    }
}
