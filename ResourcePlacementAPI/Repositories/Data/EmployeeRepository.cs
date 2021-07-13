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
    }
}
