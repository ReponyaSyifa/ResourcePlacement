using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.ViewModel
{
    public class RegisterVM
    {
        // register untuk Trainer Dan ADD2
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //register untuk User
        public string CompanyName { get; set; }
        public string PicName { get; set; }

        // wajib ada di Trainer ADD2 dan User
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
