using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xCodedUI.AppControls;
using xCodedUI.AppControls.WebControls;
using Microsoft.VisualStudio.TestTools.UITesting;
using xCodedUI.AppControls.WinControls;

namespace xCodedUI.AppFramework.Pages
{
    /// <summary>
    /// Represent's the workoder page of the Honeywell First Application
    /// </summary>
    public class WorkOrderPage
    {
        private BrowserWindow _browser;
        private xHtmlHyperlink _workorderTab;
        private xHtmlImage _newWorkorder;
        private xHtmlEdit _name;
        private xHtmlSpan _selectService;
        private xHtmlHyperlink _HomeTab;
        private xHtmlInputButton _createbtn;
        private xHtmlImage _backbtn;
        private xHtmlEdit _serialNo;
        private xHtmlImage _serchIcon;
        private xHtmlInputButton _Addbtn;
        private xHtmlDiv _successmsg;
        private xHtmlDiv _workorderPage;
        private xHtmlSpan _errormsgName;
        
       
       
        public WorkOrderPage(BrowserWindow b)
        {
            b.CloseOnPlaybackCleanup = false;
            _browser = b;
            _workorderTab = new xHtmlHyperlink(b, "Work Orders", "InnerText");
            _workorderPage = new xHtmlDiv(b, "New Work Orders ", "InnerText");
            _newWorkorder = new xHtmlImage(b, "btnSubmitNewWO");
            _name = new xHtmlEdit(b, "WorkOrderName");
            _selectService = new xHtmlSpan(b, "k-icon k-i-arrow-s", "Class");
            _HomeTab = new xHtmlHyperlink(b, "Home", "InnerText");
            _createbtn = new xHtmlInputButton(b, "btnCreate");
            _backbtn = new xHtmlImage(b, "btnBack");
            _serialNo = new xHtmlEdit(b, "SerialNo");
            _serchIcon = new xHtmlImage(b, "btnGo");
            _Addbtn = new xHtmlInputButton(b, "btnAdd");
            _successmsg = new xHtmlDiv(b, "success", "Class");
            _errormsgName = new xHtmlSpan(b, "WorkOrderName_validationMessage");
        }

        /// <summary>
        /// This method is a Navigate to Home 
        /// </summary>
        public void nav_Home()
        {
            _HomeTab.Click();
        }
        /// <summary>
        /// This method is a Navigate to Create new work order 
        /// </summary>
        public string nav_createWorkorder(BrowserWindow window)
        {
            string pageName;
            
            _workorderTab.Click();
            pageName = verifyWorkorderPage();
            _newWorkorder.Click();
            
            return pageName;
        }

        /// <summary>
        /// This method is a Navigate to Create new work order and Enter Workorder Name
        /// parm name is name of work order
        /// </summary>
        public string[] workorder(string name, BrowserWindow window)
        {
            string[] a = new string[10];
            a[0] = nav_createWorkorder(window);
            _name.SendKeys(name);
            a[1] = _name.GetProperty("Text").ToString();
            return a;   
        }


        /// <summary>
        /// This method is to click on create in create new Work order
        /// </summary>
        public void Click_create()
        {
            _createbtn.Click();
        }

        /// <summary>
        /// This method is to click on back arrow link in create new Work order
        /// </summary>
        public string Click_backbtn()
        {
            string a;
            _backbtn.Click();
            a = _newWorkorder.GetProperty("FriendlyName").ToString();
            return a;

        }

        /// <summary>
        /// This method is to Select Service provider in create new work order
        /// parm BrowerWindow passing window object
        /// </summary>
        public void SelectServiceProvider(BrowserWindow window)
        {
            _selectService.Click();

            UITestControl ServicesItem = new UITestControl(window);
            ServicesItem.TechnologyName = "Web";
            ServicesItem.SearchProperties.Add("TagName", "LI", "InnerText", "Minerva");
            Mouse.Click(ServicesItem);

        }

        /// <summary>
        /// This method is to Add item in create new work order
        /// </summary>
        public void AddItem(string serialNo)
        {
           
            _serialNo.SendKeys(serialNo);
            _serchIcon.Click();
            _Addbtn.Click();  
        }

        /// <summary>
        /// This method is to Select Service provider in create new work order
        /// parm BrowerWindow passing window object
        /// </summary>
        public string SearchItem(string serialNo, BrowserWindow window)
        {
            string error;
            _serialNo.SetProperty("Text", serialNo);
            _serchIcon.Click();

            UITestControl errorMessage = new UITestControl(window);
            errorMessage.TechnologyName = "Web";
            errorMessage.SearchProperties.Add("ControlType", "Pane", "Id", "SerialNo_validationMessage");
            error = errorMessage.GetProperty("InnerText").ToString();
            return error;

        }
         
        public string verifySuccessMsg()
        {
            string res;
            res = _successmsg.GetProperty("FriendlyName").ToString();
            return res;
        }
        public string verifyWorkorderPage()
        {
            string res;
            res = _workorderPage.GetProperty("FriendlyName").ToString();
            return res;
        }

        public string verifyErrorMsg()
        {
            string res;
            res = _errormsgName.GetProperty("FriendlyName").ToString();
            return res;
        }
    }
}
