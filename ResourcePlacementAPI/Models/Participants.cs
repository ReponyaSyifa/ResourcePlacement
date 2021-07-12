using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    [Table("tb_M_Participants")]
    public class Participants
    {
        [Key]
        public int ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public virtual Projects Projects { get; set; }
        public int ProjectsId { get; set; }
        public virtual ICollection<ParticipantsSkills> ParticipantsSkills { get; set; }

    }
    public enum Gender
    {
        Pria, Wanita
    }
}
