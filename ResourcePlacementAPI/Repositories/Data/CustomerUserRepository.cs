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

        public int ChooseParticipant(ChooseParticipantVM chooseParticipant, int participantId)
        {
            if (chooseParticipant.Status == "Approved")
            {
                var participant = myContext.Participants.Find(participantId);
                participant.Status = "On Project";
                myContext.SaveChanges();

                var name = $"{participant.FirstName} {participant.LastName}";
                var project = myContext.Projects.Find(participant.ProjectId);
                var user = myContext.CustomerUsers.Find(project.CustomerUserId);

                var subject = $"HR Info : Employee Status Update";
                var body = $"<h1>Hallo {name} </h1> <br>" +
                            $"<p>Selamat, anda diterima di proyek!!!</p>" +
                            $"<p>          Nama Pegawai = {name}</p>" +
                            $"<p>          Status       = {participant.Status}</p> <br>"+
                            $"<p>          Penempatan   = {user.CompanyName}</p> <br>"+
                            $"<p>          Nama User    = {user.Name}</p> <br>";
                var notification = $"sukses";

                Email.SendEmail(participant.Email, body, subject, notification);
                return 1; //dapat job
            }
            else if (chooseParticipant.Status == "Rejected")
            {
                var participant = myContext.Participants.Find(participantId);
                participant.Status = "Idle";
                myContext.SaveChanges();

                var name = $"{participant.FirstName} {participant.LastName}";

                var subject = $"HR Info : Employee Status Update";
                var body = $"<h1>Hallo {name} </h1> <br>" +
                            $"<p>Maaf, proyek saat ini belum ada yang cocok dengan keahlian anda</p>" +
                            $"<p>          Nama Pegawai = {name}</p>" +
                            $"<p>          Status       = {participant.Status}</p> <br>";
                var notification = $"sukses";

                Email.SendEmail(participant.Email, body, subject, notification);
                return 2; // masih idle
            }
            else
            {
                return 0;// salah input
            }
        }

        // method ini digunakan untuk menampilkan Participant yang dapat dilihat oleh User
        public IEnumerable<Participants> AllChoosedParticipants(int customerUserId)
        {
            List<Participants> participants = new List<Participants>();

            List<Participants> participantsInDatabase = myContext.Participants.ToList();

            foreach (var item in participantsInDatabase)
            {  
                if (item.ProjectId != null)
                {
                    var projects = myContext.Projects.Where(e => e.CustomerUserId == customerUserId).ToList();
                    if (projects == null)
                    {
                        
                    }
                    else
                    {
                        //var customer = myContext.CustomerUsers.FirstOrDefault(e => e.CustomerUserId == customerUserId);
                        foreach (var item2 in projects)
                        {
                            if (item.ProjectId == item2.ProjectId)
                            {
                                participants.Add(item);
                            }
                        }
                    }
                }                
            }

            return participants;
        }
    }
}
