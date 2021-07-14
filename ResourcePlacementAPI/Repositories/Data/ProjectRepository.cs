using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ProjectRepository : GeneralRepository<MyContext, Projects, int>
    {
        private readonly MyContext myContext;
        public ProjectRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int AddProject(AddProjectVM addProject)
        {
            var cekProject = myContext.Projects.FirstOrDefault(p => p.ProjectName == addProject.ProjectName);
            if (cekProject == null)
            {
                Projects project = new Projects();
                CustomerUsers cust = new CustomerUsers();
                project.ProjectName = addProject.ProjectName;
                project.ProjectDesc = addProject.ProjectDesc;
                project.CustomerUserId = addProject.CustomerUsersId;
                myContext.Projects.Add(project);
                myContext.SaveChanges();

                ProjectsSkills projectSkill = new ProjectsSkills();
                for (int i = 0; i < addProject.ListSkill.Length; i++)
                {
                    projectSkill.ProjectsId = project.ProjectId;
                    projectSkill.SkillsId = addProject.ListSkill[i];
                    myContext.ProjectsSkills.Add(projectSkill);
                    myContext.SaveChanges();
                }
                return 1;
            }
            return 2;
        }
    }
}
