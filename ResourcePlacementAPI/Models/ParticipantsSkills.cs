using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_ParticipantSkills")]
    public class ParticipantsSkills
    {
        [JsonIgnore]
        public virtual Skills Skills { get; set; }
        public int SkillsId { get; set; }
        [JsonIgnore]
        public virtual Participants Participants { get; set; }
        public int ParticipantsId { get; set; }
    }
}
