using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId{ get; set; }
        public string NIK { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
