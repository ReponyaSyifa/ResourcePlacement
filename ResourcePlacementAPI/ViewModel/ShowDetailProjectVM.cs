using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.ViewModel
{
    public class ShowDetailProjectVM
    {
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string ProjectPlace { get; set; }
        public string ProjectClient { get; set; }
        public IEnumerable<ShowSkillVM> ListSKillProject { get; set; }
    }
}
