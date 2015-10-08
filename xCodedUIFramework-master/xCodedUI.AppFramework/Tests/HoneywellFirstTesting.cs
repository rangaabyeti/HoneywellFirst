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
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Login.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "Sheet1$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Login.xlsx")]
        public void LoginTest()
        {
            //Retriving Data from Excel
            string UserName = TestContext.DataRow["UserName"].ToString();
            string Password = TestContext.DataRow["Password"].ToString();
            
            //create object for environment 
            window = BrowserWindow.Launch(new Uri(_environment));
            window.CloseOnPlaybackCleanup = false;

            //create object for page
            g = new HoneywellFirstLoginLogoff(window);

            //Call Login funtion
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
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder function
                res = w.workorder(name, window);

                //Validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call Click_create Funtion
                w.Click_create();

                //Call verifySuccessMsg
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
        }

        /// <summary>
        /// spring1 Testcase:393 Test Method
        /// </summary>
         [TestMethod]
        public void spring1_TC393()
        {
             try
             {
                //Declare requried Variable
                string res;

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call nav_createWorkorder function
                res = w.nav_createWorkorder(window);

                //Validation
                Assert.AreEqual(res, "New Work Orders");

             }
             finally
             {
                 //post Condtion
                 w.nav_Home();
             }
         }

         /// <summary>
         /// spring1 Testcase:311 Test Method
         /// </summary>
         [TestMethod]
         public void spring1_TC311()
         {
             try
             {
                 //Declare requried Variable
                 string res, errormsg;

                 //create object for environment
                 window = BrowserWindow.Locate("FDAdminDashBoard");
                 window.CloseOnPlaybackCleanup = false;

                 //create object for page
                 w = new WorkOrderPage(window);

                 //Call nav_createWorkorder function
                 res = w.nav_createWorkorder(window);

                 //Validation
                 Assert.AreEqual(res, "New Work Orders");

                 //Call Click_create funtion
                 w.Click_create();

                 //Call verifyErrorMsg function
                 errormsg = w.verifyErrorMsg();

                 //Validation
                 Assert.AreEqual(errormsg, "Required");
             }
             finally
             {
                 //post Condtion
                 w.nav_Home();
             }
         }

         /// <summary>
         /// spring2 Testcase:759 Test Method
         /// </summary>
         [TestMethod]
         public void spring2_TC759()
         {
             try
             {
                 //Declare requried Variable
                 string res1,res2;

                 //create object for environment
                 window = BrowserWindow.Locate("FDAdminDashBoard");
                 window.CloseOnPlaybackCleanup = false;

                 //create object for page
                 w = new WorkOrderPage(window);

                 //Call nav_createWorkorder function
                 res1 = w.nav_createWorkorder(window);

                 //Call Click_backbtn function
                 res2 = w.Click_backbtn();

                 //Validation
                 Assert.AreEqual(res1, "New Work Orders");
                 Assert.AreEqual(res2, "Create New Work Order");
             }
             finally
             {
                 //post Condtion
                 w.nav_Home();
             }
         }

         /// <summary>
         /// spring2 Testcase:313 Test Method
         /// </summary>
         [TestMethod]
         [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TC313.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "TC313$", DataAccessMethod.Sequential), DeploymentItem(@"Data\TC313.xlsx")]
         public void spring2_TC313()
         {
             try
             {
                 //Declare requried Variable
                 string[] res = new string[10];
                 string successMsg;

                 //Retriving Data from Excel
                 string name = TestContext.DataRow["name"].ToString();
                 string serialNo = TestContext.DataRow["serialNo"].ToString();

                 //create object for environment
                 window = BrowserWindow.Locate("FDAdminDashBoard");
                 window.CloseOnPlaybackCleanup = false;

                 //create object for page
                 w = new WorkOrderPage(window);

                 //Call workorder function
                 res = w.workorder(name, window);

                 //Validation
                 Assert.AreEqual(res[0], "New Work Orders");
                 Assert.AreEqual(res[1], name);

                 //Call SelectServiceProvider function
                 w.SelectServiceProvider(window);

                 //Call Click_create function
                 w.Click_create();

                 //Call verifySuccessMsg function
                 successMsg = w.verifySuccessMsg();

                 //Validation
                 Assert.AreEqual(successMsg, "Work Order created successfully");

                 //Call AddItem function
                 w.AddItem(serialNo);

                 //Call click_Add function
                 w.click_Add();
             }
             finally
             {
                 //post Condtion
                 w.nav_Home();
             }
         }

         /// <summary>
         /// spring1 Testcase:300 Test Method
         /// </summary>
         [TestMethod]
         public void spring1_TC300()
         {
             try
             {
                 //Declare requried Variable
                 Boolean a;
                 string res;

                 //create object for environment
                 window = BrowserWindow.Locate("SubmitWorkOrder");
                 window.CloseOnPlaybackCleanup = false;

                 //create object for page
                 w = new WorkOrderPage(window);

                 //Call nav_createWorkorder function
                 res = w.nav_createWorkorder(window);
                 
                 //Validation
                 Assert.AreEqual(res, "New Work Orders");

                 //Call verifyMandatoryFelids function
                 a = w.verifyMandatoryFelids();

                 //Validation
                 Assert.AreEqual(a, true);
             }

             finally
             {
                 //post Condtion
                 w.nav_Home();
             }
         }

         /// <summary>
         /// spring1 Testcase:307 Test Method
         /// </summary>
         [TestMethod]
         public void spring1_TC307()
         {
             try
             {
                 //Declare requried Variable
                 string res, errormsg;

                 //create object for environment
                 window = BrowserWindow.Locate("FDAdminDashBoard");
                 window.CloseOnPlaybackCleanup = false;

                 //create object for page
                 w = new WorkOrderPage(window);

                 //Call nav_createWorkorder function
                 res = w.nav_createWorkorder(window);

                 //Validation
                 Assert.AreEqual(res, "New Work Orders");

                 //Call Click_create function
                 w.Click_create();

                 //Call verifyErrorMsg function
                 errormsg = w.verifyErrorMsg();

                 //Validation
                 Assert.AreEqual(errormsg, "Required");
             }
             
             finally
             {
                 //post Condtion
                 w.nav_Home();
             }
         }

         /// <summary>
         /// spring1 Testcase:312 Test Method
         /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "TC312$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
         public void spring2_TC312()
         {
             try
             {
                 //Declare requried Variable
                 string[] res = new string[10];
                 string successMsg,autoSaveMsg;
                 Boolean verifyStatus;

                 //Retriving Data from Excel
                 string name = TestContext.DataRow["name"].ToString();
                 string serialNo = TestContext.DataRow["serialNo"].ToString();
                 string status = TestContext.DataRow["status"].ToString();

                 //create object for environment
                 window = BrowserWindow.Locate("FDAdminDashBoard");
                 window.CloseOnPlaybackCleanup = false;

                 //create object for page
                 w = new WorkOrderPage(window);

                 //Call workorder function
                 res = w.workorder(name, window);

                 //Validation
                 Assert.AreEqual(res[0], "New Work Orders");
                 Assert.AreEqual(res[1], name);

                 //Call SelectServiceProvider function
                 w.SelectServiceProvider(window);

                 //Call Click_create function
                 w.Click_create();

                 //Call verifySuccessMsg function
                 successMsg = w.verifySuccessMsg();

                 //Validation
                 Assert.AreEqual(successMsg, "Work Order created successfully");

                 //Call AddItem function
                 w.AddItem(serialNo);

                 //Call click_Add function
                 w.click_Add();

                 //Call verifyAutoSave function
                 autoSaveMsg = w.verifyAutoSave();

                 //Validation
                 Assert.AreEqual(autoSaveMsg, "AutoSaved");

                 //Call Click_backbtn function
                 w.Click_backbtn();

                 //Call filterByWorkOrderName function
                 w.filterByWorkOrderName(name);

                 //wait for 10 sec
                 Playback.Wait(10000);

                 //Call verifyworkstatus function
                 verifyStatus = w.verifyworkstatus(status);

                 //Validation
                 Assert.AreEqual(verifyStatus, true);

                 //Call removeFilterByWorkOrderName function
                 w.removeFilterByWorkOrderName();
             }
             finally
             {
                 //post Condtion
                 w.nav_Home();
             }             
         }

        /// <summary>
        /// spring1 Testcase:314 Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "TC314$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC314()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg, autoSaveMsg;
                Boolean verifySerialNo;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder Function
                res = w.workorder(name, window);
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call workorder Function
                w.SelectServiceProvider(window);

                //Call Click_create Function
                w.Click_create();

                //Call verifySuccessMsg Function
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call AddItem Function
                w.AddItem(serialNo);

                //Call click_Add Function
                w.click_Add();

                //Call verifyAutoSave Function
                autoSaveMsg = w.verifyAutoSave();

                //Validation
                Assert.AreEqual(autoSaveMsg, "AutoSaved");

                //Call verifyserialNo Function
                verifySerialNo = w.verifyserialNo(serialNo);

                //Validation
                Assert.AreEqual(verifySerialNo, true);
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
        }

        /// <summary>
        /// spring2 Testcase:315 Test Method
        /// </summary
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "TC315$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC315()
        {
            try
            {
                //Declare requried Variable
                string res, errormsg,productName;

                //Retriving Data from Excel
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call nav_createWorkorder function
                res = w.nav_createWorkorder(window);

                //Call nav_createWorkorder function
                w.AddItem(serialNo);

                //Call nav_createWorkorder function
                productName = w.verifyProductName();

                //Validation
                Assert.AreEqual(productName, "");

                //Call nav_createWorkorder function
                errormsg = w.verifyErrorMsg();

                //Validation
                Assert.AreEqual(errormsg, "Required");
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
        }

        /// <summary>
        /// spring2 Testcase:316 Test Method
        /// </summary
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "TC316$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC316()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg, autoSaveMsg,alertMsg;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder function
                res = w.workorder(name, window);

                //Validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call SelectServiceProvider function
                w.SelectServiceProvider(window);

                //Call Click_create function
                w.Click_create();

                //Call verifySuccessMsg function
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call AddItem function
                w.AddItem(serialNo);

                //Call click_Add function
                w.click_Add();

                //Call verifyAutoSave function
                autoSaveMsg = w.verifyAutoSave();

                //Validation
                Assert.AreEqual(autoSaveMsg, "AutoSaved");

                //Call AddItem function
                w.AddItem(serialNo);

                //Call click_Add function
                w.click_Add();

                //Call verifyAlertMsg function
                alertMsg = w.verifyAlertMsg();

                //Validation
                Assert.AreEqual(alertMsg, "Item already added");
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
        }

        /// <summary>
        /// spring2 Testcase:320 Test Method
        /// </summary
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
            "TC320$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC320()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string expectedMsg = "Item not found. Add new item to Inventory?";
                string successMsg;
                Boolean itemMsg;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder function
                res = w.workorder(name, window);

                //Validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call SelectServiceProvider function
                w.SelectServiceProvider(window);

                //Call Click_create function
                w.Click_create();

                //Call verifySuccessMsg function
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call AddItem function
                w.AddItem(serialNo);

                //Call verifyItemNotFound function
                itemMsg = w.verifyItemNotFound(expectedMsg);

                //Validation
                Assert.AreEqual(itemMsg, true);
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
           
        }

        /// <summary>
        /// spring2 Testcase:309 Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
           "TC309$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC309()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder function
                res = w.workorder(name, window);

                //Validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call SelectServiceProvider function
                w.SelectServiceProvider(window);

                //Call Click_create function
                w.Click_create();

                //Call verifySuccessMsg function
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call AddItem function
                w.AddItem(serialNo);

                //Call click_Add function
                w.click_Add();
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
        }

        /// <summary>
        /// spring3 Testcase:347 Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
           "TC347$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC347()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg;
                string txt = "Are you sure, you want to remove the selected item(s)?";
                Boolean verifyDeleteWin;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder function
                res = w.workorder(name, window);

                //validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call SelectServiceProvider function
                w.SelectServiceProvider(window);

                //Call Click_create function
                w.Click_create();

                //Call verifySuccessMsg function
                successMsg = w.verifySuccessMsg();

                //validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call AddItem function
                w.AddItem(serialNo);

                //Call click_Add function
                w.click_Add();

                //Call deleteItem function
                verifyDeleteWin = w.deleteItem(txt);

                //validation
                Assert.AreEqual(verifyDeleteWin, true);
            }
            
            finally
            {
                //post Condtion
                w.nav_Home();
            }
                        
        }

        /// <summary>
        /// spring3 Testcase:348 Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
           "TC348$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring3_TC348()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg;
                string expectedStatus = "DisableButtonJS";
                Boolean value;

                //Retriving Data from Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call workorder function
                res = w.workorder(name, window);

                //Validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call SelectServiceProvider function
                w.SelectServiceProvider(window);

                //Call Click_create function
                w.Click_create();

                //Call verifySuccessMsg function
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call AddItem function
                w.AddItem(serialNo);

                //Call click_Add function
                w.click_Add();

                //Call verifyDeleteBtn function
                value = w.verifyDeleteBtn(expectedStatus);

                //Validation
                Assert.AreEqual(value,true);
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
        }

        /// <summary>
        /// spring2 Testcase:TC317TC318TC319 Test Method
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'",
           "Sheet1$", DataAccessMethod.Sequential), DeploymentItem(@"Data\Excel.xlsx")]
        public void spring2_TC317TC318TC319()
        {
            try
            {
                //Declare requried Variable
                string[] res = new string[10];
                string successMsg, errorMessage;

                //Retriving Data From Excel
                string name = TestContext.DataRow["name"].ToString();
                string serialNo = TestContext.DataRow["serialNo"].ToString();
                string ExpectedErrorMessage = TestContext.DataRow["ExpectedErrorMessage"].ToString();

                //create object for environment
                window = BrowserWindow.Locate("FDAdminDashBoard");
                window.CloseOnPlaybackCleanup = false;

                //create object for page
                w = new WorkOrderPage(window);

                //Call click_Add function
                res = w.workorder(name, window);

                //Validation
                Assert.AreEqual(res[0], "New Work Orders");
                Assert.AreEqual(res[1], name);

                //Call SelectServiceProvider function
                w.SelectServiceProvider(window);

                //Call Click_create function
                w.Click_create();

                //Call verifySuccessMsg function
                successMsg = w.verifySuccessMsg();

                //Validation
                Assert.AreEqual(successMsg, "Work Order created successfully");

                //Call SearchItem function
                errorMessage = w.SearchItem(serialNo, window);

                //Validation
                Assert.AreEqual(errorMessage, ExpectedErrorMessage);
            }
            finally
            {
                //post Condtion
                w.nav_Home();
            }
           
        }

        /// <summary>
        /// Logoff Test Method
        /// </summary>
        [TestMethod]
        public void LogoffTest()
        {
            //create object for environment
            window = BrowserWindow.Locate("FDAdminDashBoard");
            window.CloseOnPlaybackCleanup = false;

            //create object for page
            g = new HoneywellFirstLoginLogoff(window);

            //Call Logoff Function
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
