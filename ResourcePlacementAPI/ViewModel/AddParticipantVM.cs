using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.ViewModel
{
    public enum Gender
    {
        Pria, Wanita
    }
    public class AddParticipantVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public int ProjectsId { get; set; }
    }
}
