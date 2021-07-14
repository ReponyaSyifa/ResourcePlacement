using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class CustomerUserRepository : GeneralRepository<MyContext, CustomerUsers, int>
    {
        private readonly MyContext myContext;

        public CustomerUserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int ProjectPlotting(ProjectPlottingVM projectPlottingVM, int participantId)
        {
            if (projectPlottingVM.ProjectId != 0)
            {
                var participant = myContext.Participants.Find(participantId);
                participant.ProjectId = projectPlottingVM.ProjectId;
                myContext.SaveChanges();
                return 0;
            }
            else
            {
                var participant = myContext.Participants.Find(participantId);
                var name = $"{participant.FirstName} {participant.LastName}";

                var subject = $"HR Info : Employee Status Update";
                var body = $"<h1>Hallo {name} </h1> <br>" +
                            $"<p>Maaf anda proyek saat ini belum ada yang cocok dengan keahlian anda</p> <br>" +
                            $"<p>          Nama Pegawai = {name}</p> <br>" +
                            $"<p>          Status       = {participant.Status}</p> <br>";
                var notification = $"sukses";

                Email.SendEmail(participant.Email,body,subject,notification);
                return 1;
            }
            
        }
    }
}
