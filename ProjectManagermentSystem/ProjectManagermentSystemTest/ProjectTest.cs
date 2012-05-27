using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate;
using DataModels.Object;
using BusinessLogicLib;

namespace ProjectManagermentSystemTest
{
    /// <summary>
    /// ProjectTest 的摘要说明
    /// </summary>
    [TestClass]
    public class ProjectTest
    {
        public ProjectTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DbConnectionTest()
        {
            //
            // TODO: 在此处添加测试逻辑
            //
            Configuration cfg = new Configuration();
            cfg.AddAssembly("DataModels");
            ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            ITransaction tx = session.BeginTransaction();

            Project Project1 = new Project();
            Project1 = session.Get<Project>(7);

            tx.Commit();
            session.Close();
            factory.Close();
            Assert.AreEqual(Project1.projectName,"2");
        }

        [TestMethod]
        public void DbConnectionTest1()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("DataModels");
            ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            ITransaction tx = session.BeginTransaction();

            ProjectRole role = new ProjectRole();
            role = session.Get<ProjectRole>(11);
            tx.Commit();
            session.Close();
            factory.Close();
            Assert.AreEqual("Hill",role.userName);
        }

        [TestMethod]
        public void GetUserSetupProjectByIdTest()
        {
            UserProject project = new UserProject();
            project = UserProject.GetUserSetupProjectById(3,"Hill");
            Assert.AreEqual(project,null);
        }
        [TestMethod]
        public void MySetupProjectTest()
        {
            List<UserProject> myProjects = new List<UserProject>();
            UserProject userProject = new UserProject();
            myProjects = UserProject.GetUserSetupProjects("Hill");
            //Assert.AreEqual((myProjects[0].projectPublishTime).ToString(), "2012/5/16 0:21:33");
            //Assert.AreEqual(myProjects[0].roles[0].role, "Admin");
            bool result = (myProjects.Count == 0);
            Assert.AreEqual(false,result);
        }
        [TestMethod]
        public void IsProjectSetupByUser()
        {
            bool result = UserProject.IsProjectSetupByUser(2, "Hill");
            Assert.AreEqual(false,result);
        }

        [TestMethod]
        public void AddNewProjectTest()
        {
            //ProjectRole role = new ProjectRole{ role="Admin", userName="Hill", projectId=2};
            //List<ProjectRole> roles = new List<ProjectRole>();
            //roles.Add(role);
            //UserProject newProject = new UserProject { projectName = "2", projectContext = "这是第二个项目", projectPublishTime = DateTime.Now, projectState = false, roles=roles};
            //bool newResult = UserProject.AddNewProject(newProject);
            //Assert.AreEqual(true, newResult);
        }
    }
}
