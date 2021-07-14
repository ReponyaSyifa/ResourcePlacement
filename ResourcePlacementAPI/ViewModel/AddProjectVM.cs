using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.ViewModel
{
    public class AddProjectVM
    {
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public int CustomerUsersId { get; set; }
        public int[] ListSkill { get; set; }
    }
}
