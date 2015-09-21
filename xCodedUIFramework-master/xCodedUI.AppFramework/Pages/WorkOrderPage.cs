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
        private xHtmlDiv _select;
        private xHtmlHyperlink _HomeTab;
        private xHtmlInputButton _createbtn;
        private xHtmlImage _backbtn;
        private xWinPane _SelectService;
        private xHtmlEdit _serialNo;
        private xHtmlImage _serchIcon;
        private xHtmlInputButton _Addbtn;
        
       
       
        public WorkOrderPage(BrowserWindow b)
        {
            b.CloseOnPlaybackCleanup = false;
            _browser = b;
            _workorderTab = new xHtmlHyperlink(b, "Work Orders", "InnerText");
            _newWorkorder = new xHtmlImage(b, "btnSubmitNewWO");
            _name = new xHtmlEdit(b, "WorkOrderName");
            _select = new xHtmlDiv(b, "Pane", "ControlType");
            _HomeTab = new xHtmlHyperlink(b, "Home", "InnerText");
            _createbtn = new xHtmlInputButton(b, "btnCreate");
            _backbtn = new xHtmlImage(b, "btnBack");
            _SelectService = new xWinPane(b, "Pane", "k-icon k-i-arrow-s", "ControlType", "Class");
            _serialNo = new xHtmlEdit(b, "SerialNo");
            _serchIcon = new xHtmlImage(b, "btnGo");
            _Addbtn = new xHtmlInputButton(b, "btnAdd");
            

        }

        /// <summary>
        /// This method is a work order to Honeywell First
        /// </summary>
        public string[] workorder(string name)
        {
            string[] a = new string[10];
            //_workorderTab.Click();
            //a[0]=_newWorkorder.GetProperty("FriendlyName").ToString();
            //_newWorkorder.Click();
            a[0] = nav_createWorkorder();
            _name.SendKeys(name);
            a[1] = _name.GetProperty("Text").ToString();
            return a;   
        }

        public string nav_createWorkorder()
        {
            string a;
            _workorderTab.Click();
            a =_newWorkorder.GetProperty("Alt").ToString();
            _newWorkorder.Click();
            return a;
        }

        public void nav_Home()
        {
            _HomeTab.Click();
        }
        public void Click_create()
        {
            _createbtn.Click();
        }

        public string Click_backbtn()
        {
            string a;
            _backbtn.Click();
            a = _newWorkorder.GetProperty("FriendlyName").ToString();
            return a;

        }

        public void SelectServiceProvider(BrowserWindow window)
        {
            UITestControl selectServices = new UITestControl(window);
            selectServices.TechnologyName = "Web";
            selectServices.SearchProperties.Add("ControlType", "Pane", "Class", "k-icon k-i-arrow-s");
            Mouse.Click(selectServices);

            UITestControl ServicesItem = new UITestControl(window);
            ServicesItem.TechnologyName = "Web";
            ServicesItem.SearchProperties.Add("TagName", "LI", "InnerText", "Minerva");
            Mouse.Click(ServicesItem);

        }

        public void AddItem(string serialNo)
        {
            _serialNo.SendKeys(serialNo);
            _serchIcon.Click();
            _Addbtn.Click();  
        }

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

    }
}
