using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xCodedUI.AppControls;
using xCodedUI.AppFramework.Pages;
using xCodedUI.AppFramework.Tests;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace xCodedUI.AppFramework
{
    [CodedUITest]
    public class HoneywellFirstTesting
    {
        private readonly string _environment = ConfigurationManager.AppSettings["Environment"];
        static BrowserWindow window;
        HoneywellFirstLoginLogoff g;
        WorkOrderPage w;

        /// <summary>
        /// Login Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "Sheet1$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Data.xlsx")]
        public void LoginTest()
        {
            string UserName = TestContext.DataRow["UserName"].ToString();
            string Password = TestContext.DataRow["Password"].ToString();
            window = BrowserWindow.Launch(new Uri(_environment));
            window.CloseOnPlaybackCleanup = false;
            g = new HoneywellFirstLoginLogoff(window);
            g.Login(UserName, Password);            
        }

        
        /// <summary>
        /// spring1 Testcase:310 Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TC310.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "Sheet1$", DataAccessMethod.Sequential), DeploymentItem(@"Data\TC310.xlsx")]
        public void spring1_TC310()
        {
            string[] res = new string[10];
            string name = TestContext.DataRow["name"].ToString();
            window = BrowserWindow.Locate("FDAdminDashBoard");
            window.CloseOnPlaybackCleanup = false;
            w = new WorkOrderPage(window);
            res = w.workorder(name);
            w.Click_create();
            Assert.AreEqual(res[0], "Create New Work Order");
            Assert.AreEqual(res[1], "TC010");

            //post Condtion
            window = BrowserWindow.Locate("SubmitWorkOrder");
            window.CloseOnPlaybackCleanup = false;
            w = new WorkOrderPage(window);
            w.nav_Home();

        }

        /// <summary>
        /// spring1 Testcase:393 Test Method
        /// </summary>
         [TestMethod]
        public void spring1_TC393()
        {
            string res;
            window = BrowserWindow.Locate("FDAdminDashBoard");
            window.CloseOnPlaybackCleanup = false;
            w = new WorkOrderPage(window);
            res= w.nav_createWorkorder();
            Assert.AreEqual(res, "Create New Work Order");

            //post Condtion
            window = BrowserWindow.Locate("SubmitWorkOrder");
            window.CloseOnPlaybackCleanup = false;
            w = new WorkOrderPage(window);
            w.nav_Home();
        }

         /// <summary>
         /// spring1 Testcase:311 Test Method
         /// </summary>
         [TestMethod]
         public void spring1_TC311()
         {
             string res;
             window = BrowserWindow.Locate("FDAdminDashBoard");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             res = w.nav_createWorkorder();
             w.Click_create();
             Assert.AreEqual(res, "Create New Work Order");

             //post Condtion
             window = BrowserWindow.Locate("SubmitWorkOrder");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             w.nav_Home();
         }

         /// <summary>
         /// spring2 Testcase:759 Test Method
         /// </summary>
         [TestMethod]
         public void spring2_TC759()
         {
             string res1,res2;
             window = BrowserWindow.Locate("FDAdminDashBoard");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             res1 = w.nav_createWorkorder();
             res2 = w.Click_backbtn();
             Assert.AreEqual(res1, "Create New Work Order");
             Assert.AreEqual(res2, "Create New Work Order");

             //post Condtion
             window = BrowserWindow.Locate("Work Order");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             w.nav_Home();
         }
         /// <summary>
         /// spring2 Testcase:313 Test Method
         /// </summary>
         [TestMethod]
         [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TC313.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "Sheet1$", DataAccessMethod.Sequential), DeploymentItem(@"Data\TC313.xlsx")]
         public void spring2_TC313()
         {
             string[] res = new string[10];
             string name = TestContext.DataRow["name"].ToString();
             string serialNo = TestContext.DataRow["serialNo"].ToString();
             window = BrowserWindow.Locate("FDAdminDashBoard");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             res = w.workorder(name);
             Assert.AreEqual(res[0], "Create New Work Order");
             Assert.AreEqual(res[1], "testcase000");
             w.SelectServiceProvider(window);
             w.Click_create();
             w.AddItem(serialNo);

             //post Condtion
             window = BrowserWindow.Locate("SubmitWorkOrder");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             w.nav_Home();
         }

         /// <summary>
         /// spring2 Testcase:313 Test Method
         /// </summary>
         [TestMethod]
         [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TC317TC318TC319.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "Sheet1$", DataAccessMethod.Sequential), DeploymentItem(@"Data\TC317TC318TC319.xlsx")]
         public void spring2_TC317TC318TC319()
         {
             string[] res = new string[10];
             string errorMessage;
             string name = TestContext.DataRow["name"].ToString();
             string serialNo1 = TestContext.DataRow["serialNo1"].ToString();
             string serialNo2 = TestContext.DataRow["serialNo2"].ToString();
             string serialNo3 = TestContext.DataRow["serialNo3"].ToString();
             window = BrowserWindow.Locate("FDAdminDashBoard");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             res = w.workorder(name);
             Assert.AreEqual(res[0], "Create New Work Order");
             Assert.AreEqual(res[1], "TC111");
             w.SelectServiceProvider(window);
             w.Click_create();
             errorMessage = w.SearchItem(serialNo1, window);
             Assert.AreEqual(errorMessage, " Please enter numbers (0..9) and letters (a...z)");

             errorMessage = w.SearchItem(serialNo2, window);
             Assert.AreEqual(errorMessage, " Please enter numbers (0..9) and letters (a...z)");

             errorMessage = w.SearchItem(serialNo3, window);
             Assert.AreEqual(errorMessage, " Please enter numbers (0..9) and letters (a...z)");

             //post Condtion
             window = BrowserWindow.Locate("SubmitWorkOrder");
             window.CloseOnPlaybackCleanup = false;
             w = new WorkOrderPage(window);
             w.nav_Home();
         }

        /// <summary>
        /// Logoff Test Method
        /// </summary>
        [TestMethod]
        public void LogoffTest()
        {
            window = BrowserWindow.Locate("FDAdminDashBoard");
            window.CloseOnPlaybackCleanup = false;
            g = new HoneywellFirstLoginLogoff(window);
            g.Logoff();            
        }
        
        

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        
        //public void MyTestInitialize()
        //{
        //    string UserName = TestContext.DataRow["UserName"].ToString();
        //    string Password = TestContext.DataRow["Password"].ToString();
        //    _browser = new xBrowser(_environment);
        //    g = new HoneywellFirstLoginLogoff(_browser);
        //    g.Login(UserName, Password);
        //}

        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //    g.Logoff();
        //}

        #endregion

        public bool ture { get; set; }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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
        private TestContext testContextInstance;
    }
}
