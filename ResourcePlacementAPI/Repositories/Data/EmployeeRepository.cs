using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employees, int>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int RegisterRepo(RegisterVM registerVM)
        {

            var hashPass = HashingPassword.HashPassword(registerVM.Password);
            var cekemail = myContext.Accounts.FirstOrDefault(e => e.Email == registerVM.Email);
            if (cekemail == null) // gak ada yang sama
            {
                if (registerVM.PicName != null && registerVM.CompanyName != null)
                {
                    CustomerUsers customer = new CustomerUsers
                    {
                        Email = registerVM.Email,
                        CompanyName = registerVM.CompanyName,
                        PicName = registerVM.PicName
                    };
                    myContext.CustomerUsers.Add(customer);
                    myContext.SaveChanges();

                    // input untuk employee
                    Employees employee = new Employees
                    {
                        NIK = "",
                        FirstName = "",
                        LastName = "",
                        Email = ""
                    };
                    myContext.Employees.Add(employee);
                    myContext.SaveChanges();

                    Accounts accounts = new Accounts
                    {
                        EmployeeId = employee.EmployeeId,
                        CustomerUserId = customer.CustomerUserId,
                        Email = registerVM.Email,
                        Password = hashPass
                    };
                    myContext.Accounts.Add(accounts);
                    myContext.SaveChanges();

                    AccountsRoles accountsRoles = new AccountsRoles
                    {
                        AccountId = accounts.AccountId,
                        RolesId = registerVM.RoleId
                    };
                    myContext.AccountsRoles.Add(accountsRoles);
                    myContext.SaveChanges();

                    myContext.SaveChanges();
                    return 1;
                }
                else if (registerVM.NIK != null && registerVM.FirstName != null && registerVM.LastName != null)
                {
                    // input untuk employee
                    Employees employee = new Employees
                    {
                        NIK = registerVM.NIK,
                        FirstName = registerVM.FirstName,
                        LastName = registerVM.LastName,
                        Email = registerVM.Email
                    };
                    myContext.Employees.Add(employee);
                    myContext.SaveChanges();

                    CustomerUsers customer = new CustomerUsers
                    {
                        Email = "",
                        CompanyName = "",
                        PicName = ""
                    };
                    myContext.CustomerUsers.Add(customer);
                    myContext.SaveChanges();

                    Accounts accounts = new Accounts
                    {
                        EmployeeId = employee.EmployeeId,
                        CustomerUserId = customer.CustomerUserId,
                        Email = registerVM.Email,
                        Password = hashPass
                    };
                    myContext.Accounts.Add(accounts);
                    myContext.SaveChanges();

                    AccountsRoles accountsRoles = new AccountsRoles
                    {
                        AccountId = accounts.AccountId,
                        RolesId = registerVM.RoleId
                    };
                    myContext.AccountsRoles.Add(accountsRoles);
                    myContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else //ada yang sama
            {
                return 3;
            }
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
                            $"<p>Maaf, proyek saat ini belum ada yang cocok dengan keahlian anda</p>" +
                            $"<p>          Nama Pegawai = {name}</p>" +
                            $"<p>          Status       = {participant.Status}</p> <br>";
                var notification = $"sukses";

                Email.SendEmail(participant.Email, body, subject, notification);
                return 1;
            }

        }
    }
}
