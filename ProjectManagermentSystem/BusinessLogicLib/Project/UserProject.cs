using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels.Object;
using NHibernate;
using BusinessLogicLib.NHibernate;
using NHibernate.Linq;

namespace BusinessLogicLib
{
    public class UserProject:DataModels.Object.Project
    {
        public List<ProjectRole> roles { get; set; }
        public  string projectStateString { get; set; }

        private static ISession GetNHibernateSession()
        {
            NHibernateHelper NHelper = NHibernateHelper.NHelper;
            ISession session = NHelper.GetSession();
            return session;
        }

        public static List<UserProject> GetUserSetupProjects(string username)
        {
            ISession session = GetNHibernateSession();
            List<UserProject> projects = new List<UserProject>();

            List<ProjectRole> roles = new List<ProjectRole>();

            roles = (from r in session.Query<ProjectRole>()
                     where r.role == "Admin" && r.userName == username
                     select r).ToList<ProjectRole>();
            if (roles.Count == 0)
            {
                return projects;
            }
            var ids = (from r in roles
                       select r.projectId).Distinct();

           

            if (roles.Count > 0)
            {

                foreach (var id in ids)
                {
                    UserProject project = GetProjectById(session, id);
                    projects.Add(project);
                }
            }
            return projects;
        }

        private static UserProject GetProjectById(ISession session, int id)
        {
            List<ProjectRole> projectRoles = new List<ProjectRole>();
            projectRoles = (from pr in session.Query<ProjectRole>()
                            where pr.projectId == id
                            select pr).ToList<ProjectRole>();
            
            UserProject project = new UserProject();
            if (projectRoles.Count == 0)
            {
                return project;
            }
            project = (from p in session.Query<Project>()
                       where p.id == id
                       select new
                       UserProject
                       {
                           id = id,
                           projectName = p.projectName,
                           projectContext = p.projectContext,
                           roles = projectRoles,
                           projectPublishTime = p.projectPublishTime
                       }).First();
            bool state = (from p in session.Query<Project>()
                          where p.id == id
                          select p.projectState).First();
            if (state)
            {
                project.projectStateString = "是";
            }
            else
            {
                project.projectStateString = "否";
            }
            return project;
        }

        public static UserProject GetUserSetupProjectById(int id , string username)
        {
            UserProject userProject = null; 
            List<UserProject> projects = new List<UserProject>();
            projects = GetUserSetupProjects(username);
            if (projects.Count == 0)
            {
                return userProject;
            }
            List<UserProject> myProjects = new List<UserProject>();
            myProjects = (from up in projects
                           where up.id == id
                           select up).ToList();
            if (myProjects.Count != 0)
            {
                userProject = new UserProject();
                userProject = myProjects.First();
            }
            return userProject;
        }

        public static List<ProjectRole> GetUserSetupProjectRolesById(int id, string username)
        {
            UserProject userProject = new UserProject();
            List<ProjectRole> roles = new List<ProjectRole>();
            userProject = UserProject.GetUserSetupProjectById(id, username);
            roles = (from r in userProject.roles
                     select r).ToList<ProjectRole>();
            return roles;
        }


        public static bool IsAllowReadProject(int id, string username)
        {
            UserProject project = new UserProject();
            project = GetProjectById(GetNHibernateSession(), id);
            bool result = false;
            if (project == null)
            {
                return result;
            }
            var roles = from r in project.roles
                        select r;
            foreach (var role in roles)
            {
                if (role.userName == username)
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool IsProjectSetupByUser(int id, string username)
        {
            UserProject myProject = new UserProject();
            myProject = GetUserSetupProjectById(id, username);

            if (myProject == null)
            {
                return false;
            }

            List<string> users = new List<string>();
            users = (from r in myProject.roles
                        where r.projectId == id && r.role == "Admin" && r.userName == username
                        select r.userName).ToList();
            if (users.Count!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddNewProject(UserProject userProject)
        {
            try
            {
                ISession session = GetNHibernateSession();
                Project project = new Project
                {
                    projectName = userProject.projectName,
                    projectContext = userProject.projectContext,
                    projectPublishTime = userProject.projectPublishTime,
                    projectState = userProject.projectState
                };
                session.Save(project);
                int pr_id = (from p in session.Query<Project>()
                             orderby p.id descending
                             select p.id).First();
                foreach (ProjectRole r in userProject.roles)
                {                    
                    ProjectRole role = new ProjectRole
                    {
                        projectId = pr_id,
                        role = r.role,
                        userName = r.userName,
                        state = r.state
                    };
                    session.Save(role);
                }

                return true;
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                //string e = ex.ToString();
                return false;
            }
        }
    }
}
