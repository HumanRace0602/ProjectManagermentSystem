using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLib.Account;
using NHibernate.Cfg;
using NHibernate;
using DataModels.Object;
using BusinessLogicLib.NHibernate;
using BusinessLogicLib;

namespace ProjectManagermentSystemTest
{
    /// <summary>
    /// LoginTest 的摘要说明
    /// </summary>
    [TestClass]
    public class LoginTest
    {
        public LoginTest()
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
        public void IsUserRegisteredTest()
        {
            //
            // TODO: 在此处添加测试逻辑
            //
            bool userRegister = Account.IsUserRegistered("zhangsan");

            Assert.AreEqual(false, userRegister);

        }
        [TestMethod]
        public void DatabaseConnTest()
        {
            //UserLogin userLogin = new UserLogin();
            //bool userRegister = userLogin.IsUserRegistered("zhangsan");

            //Assert.AreEqual(false, userRegister);
            Configuration cfg = new Configuration();
            cfg.AddAssembly("DataModels");
            ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            ITransaction tx = session.BeginTransaction();

            User loginTest = new User();
            loginTest = session.Get<User>(1);

            tx.Commit();
            session.Close();
            factory.Close();
            Assert.AreEqual(loginTest.password, "hz2006");
        }
        [TestMethod]
        public void IsUserValidatedTest()
        {
            bool validation =  Account.IsUserValidated("zhang", "123");

            Assert.AreEqual(false,validation);
        }
        [TestMethod]
        public void UserRegisterTest()
        {         
            Assert.AreEqual(false,Account.IsUserRegistered("huang"));
        }
        [TestMethod]
        public void AddUserTest()
        {
            User newUser = new User();
            string username = "huang";
            string password = "234";
            if(!Account.IsUserRegistered(username))
            {
                newUser.username = username;
                newUser.password = password;
                //Account.AddNewUser(newUser);
            }

            bool isRegister = Account.IsUserRegistered("huang");
            Assert.AreEqual(false,isRegister);
        }
    }
}
