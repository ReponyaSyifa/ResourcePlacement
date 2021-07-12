using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
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

    }
    public enum Gender
    {
        Pria, Wanita
    }
}
