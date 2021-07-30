using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections;
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

        public IEnumerable<ShowSkillVM> ShowSkillProjects(int projectId)
        {
            List<ShowSkillVM> showSkillProjects = new List<ShowSkillVM>();
            var projectSkills = myContext.ProjectsSkills.Where(e => e.ProjectsId == projectId).ToList();

            foreach (var item in projectSkills)
            {
                ShowSkillVM showSkillProject = new ShowSkillVM();
                var skill = myContext.Skills.Find(item.SkillsId);
                showSkillProject.SKillName = skill.SkillName;
                showSkillProjects.Add(showSkillProject);
            }
            return showSkillProjects;
        }

        public IEnumerable<ShowDetailProjectVM> ShowDetailProjectVM()
        {
            List<ShowDetailProjectVM> showDetailProjects = new List<ShowDetailProjectVM>();
            var projects = myContext.Projects.ToList();
            //var clients = myContext.CustomerUsers.ToList();

            foreach (var item in projects)
            {
                ShowDetailProjectVM showDetailProject = new ShowDetailProjectVM();
                var client = myContext.CustomerUsers.FirstOrDefault(e => e.CustomerUserId == item.CustomerUserId);
                showDetailProject.ProjectName = item.ProjectName;
                showDetailProject.ProjectDesc = item.ProjectDesc;
                showDetailProject.ProjectPlace = client.CompanyName;
                showDetailProject.ProjectClient = client.Name;
                showDetailProject.ListSKillProject =  ShowSkillProjects(item.ProjectId);
                showDetailProjects.Add(showDetailProject);
            }
            return showDetailProjects;
        }

        public ShowDetailProjectVM ShowDetailProjectVM(int projectId)
        {
            ShowDetailProjectVM showDetailProject = new ShowDetailProjectVM();
            var project = myContext.Projects.Find(projectId);
            var client = myContext.CustomerUsers.FirstOrDefault(e => e.CustomerUserId == project.CustomerUserId);
            showDetailProject.ProjectName = project.ProjectName;
            showDetailProject.ProjectDesc = project.ProjectDesc;
            showDetailProject.ProjectPlace = client.CompanyName;
            showDetailProject.ProjectClient = client.Name;
            showDetailProject.ListSKillProject = ShowSkillProjects(project.ProjectId);
            return showDetailProject;
        }
        
    }
}
