using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_Skills")]
    public class Skills
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        [JsonIgnore]
        public virtual ICollection<ParticipantsSkills> ParticipantsSkills { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectsSkills> ProjectsSkills { get; set; }
    }
}
