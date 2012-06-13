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
        #region 类的扩展属性
        public List<ProjectRole> roles { get; set; }
        public  string projectStateString { get; set; }
        #endregion
        #region 类的私有方法
        private static ISession GetNHibernateSession()
        {
            NHibernateHelper NHelper = NHibernateHelper.NHelper;
            ISession session = NHelper.GetSession();
            return session;
        }

        private static UserProject getProjectById(ISession session, int id)
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
            project = (from p in session.Query<DataModels.Object.Project>()
                       where p.id == id
                       select new
                       UserProject
                       {
                           projectName = p.projectName,
                           projectContext = p.projectContext,                          
                           projectPublishTime = p.projectPublishTime
                       }).First();
            project.id = id;
            project.roles = projectRoles;
            bool state = (from p in session.Query<DataModels.Object.Project>()
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
        #endregion
        #region 类的公有方法
        public static UserProject GetProjectById(int id)
        {
            ISession session = GetNHibernateSession();
            return getProjectById(session, id);
        }

        public static List<ProjectRole> GetProjectRolesByProjectId(int pr_id)
        {
            UserProject userProject = new UserProject();
            List<ProjectRole> roles = new List<ProjectRole>();
            ISession session = GetNHibernateSession();
            userProject = getProjectById(session,pr_id);
            roles = (from r in userProject.roles
                     select r).ToList<ProjectRole>();
            return roles;
        }


        public static bool IsAllowReadProject(int id, string username)
        {
            UserProject project = new UserProject();
            project = getProjectById(GetNHibernateSession(), id);
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
            List<ProjectRole> roles = new List<ProjectRole>();
            roles = GetProjectRolesByProjectId(id);
            List<string> users = new List<string>();
            users = (from r in roles
                        where r.role == "Admin" && r.userName == username
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
                DataModels.Object.Project project = new DataModels.Object.Project
                {
                    projectName = userProject.projectName,
                    projectContext = userProject.projectContext,
                    projectPublishTime = userProject.projectPublishTime,
                    projectState = userProject.projectState
                };
                session.Save(project);
                int pr_id = (from p in session.Query<DataModels.Object.Project>()
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
            catch
            {
                return false;
            }
        }
        //flag表示权限的选择，true表示是建立的项目，false表示参与但不是建立的项目
        public static List<UserProject> GetProjectsByAuthority(string username, bool flag)
        {
            ISession session = GetNHibernateSession();
            List<UserProject> projects = new List<UserProject>();

            List<ProjectRole> roles = new List<ProjectRole>();
            if (flag)
            {
                roles = (from r in session.Query<ProjectRole>()
                         where r.role == "Admin" && r.userName == username
                         select r).ToList<ProjectRole>();
            }
            else
            {
                roles = (from r in session.Query<ProjectRole>()
                         where r.role != "Admin" && r.userName == username&&r.state=="Yes"
                         select r).ToList<ProjectRole>();
            }
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
                    UserProject project = UserProject.GetProjectById(id);
                    projects.Add(project);
                }
            }
            return projects;
        }

        public static bool IsProjectExecuteByUser(int id, string username)
        {
            List<ProjectRole> roles = new List<ProjectRole>();
            roles = GetProjectRolesByProjectId(id);
            List<string> users = new List<string>();
            users = (from r in roles
                     where r.role == "Execute" && r.userName == username
                     select r.userName).ToList();
            if (users.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsProjectRequestByUser(int id, string username)
        {
            List<ProjectRole> roles = new List<ProjectRole>();
            roles = GetProjectRolesByProjectId(id);
            List<string> users = new List<string>();
            users = (from r in roles
                     where r.role == "Request" && r.userName == username
                     select r.userName).ToList();
            if (users.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool IsJoinByUser(int id, string userName)
        {
            List<ProjectRole> roles = new List<ProjectRole>();
            roles = GetProjectRolesByProjectId(id);
            List<string> users = new List<string>();
            users = (from r in roles
                     where r.role != "Admin" && r.userName == userName && r.state == "Yes"
                     select r.userName).ToList();
            if (users.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Project.Message> GetMessage(string username)
        {
            List<Project.Message> messagesTemp = new List<Project.Message>();
            List<Project.Message> messages = new List<Project.Message>();
            ISession session = GetNHibernateSession();
            messagesTemp = (from m in session.Query<ProjectRole>()
                            where m.userName == username && m.role != "Admin" && m.state == "Unknown"
                            select new Project.Message { Id = m.id, ProjectId=m.projectId, Role = m.role, }).ToList();
            foreach (Project.Message message in messagesTemp)
            {
                DataModels.Object.Project project = (from p in session.Query<DataModels.Object.Project>()
                                                     where p.id == message.ProjectId
                                                     select p).Single();
                message.ProjectName = project.projectName;
                message.ProjectDescription = project.projectContext;
                string owner = (from r in session.Query<ProjectRole>()
                                where r.projectId == message.ProjectId && r.role == "Admin"
                                select r.userName).First();
                message.ProjectOwner = owner;
                messages.Add(message);

            }

            return messages;
        }

        public static bool AcceptProject(int projectId, string userName, string roleType)
        {
            try
            {
                ISession session = GetNHibernateSession();
                ProjectRole role = (from r in session.Query<ProjectRole>()
                                   where r.projectId==projectId&&r.userName==userName&& r.role==roleType
                                   select r).Single();
                role.state="Yes";
                //session.Update(role);
                session.SaveOrUpdate(role);
                session.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AcceptProject(int id)
        {
            try
            {
                ISession session = GetNHibernateSession();
                ProjectRole role = (from r in session.Query<ProjectRole>()
                                    where r.id==id
                                    select r).Single();
                role.state = "Yes";
                //session.Update(role);
                session.SaveOrUpdate(role);
                session.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        public static bool DenyProject(int id)
        {
            try
            {
                ISession session = GetNHibernateSession();
                ProjectRole role = (from r in session.Query<ProjectRole>()
                                    where r.id == id
                                    select r).Single();
                role.state = "No";
                //session.Update(role);
                session.SaveOrUpdate(role);
                session.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
