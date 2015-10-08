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
        private xHtmlHyperlink _workOrderNameFilterLink;
        private xHtmlEdit _Filtertxt;
        private xHtmlButton _filterbtn;
        private xHtmlButton _clearbtn;
        private xHtmlTableCell _workOrderName;
        private xHtmlDiv _nameMadatory;
        private xHtmlDiv _SPMadatory;
        private xHtmlDiv _serialNoMadatory;
        private xHtmlDiv _msgAutoSave;
        private xHtmlTableCell _workStatus;
        private xHtmlHyperlink _serialNoLink;
        private xHtmlTableCell _verifySerialNo;
        private xHtmlDiv _verifyAlertText;
        private xHtmlInputButton _Okbtn;
        private xHtmlEdit _productName;
        private xHtmlDiv _ItemNotFoundWin;
        private xHtmlInputButton _canclebtn;
        private xHtmlImage _deletebtn;
        private xHtmlCheckBox _selectItem;
        private xHtmlDiv _deleteWin;
        private xHtmlInputButton _yesbtn;
        private xHtmlInputButton _nobtn;
        
       
       
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
            _workOrderNameFilterLink = new xHtmlHyperlink(b, "14", "TagInstance");
            _Filtertxt = new xHtmlEdit(b, "SINGLELINE","Type");
            _filterbtn = new xHtmlButton(b, "Filter","DisplayText");
            _clearbtn = new xHtmlButton(b, "reset", "Type");           
            _workOrderName = new xHtmlTableCell(b, "1", "TagInstance");
            _nameMadatory = new xHtmlDiv(b, "Name*", "FriendlyName");
            _SPMadatory = new xHtmlDiv(b, "Service Provider*", "FriendlyName");
            _msgAutoSave = new xHtmlDiv(b, "SaveMessage");
            _workStatus = new xHtmlTableCell(b, "6", "TagInstance");
            _serialNoLink = new xHtmlHyperlink(b, "21", "TagInstance");
            _verifySerialNo = new xHtmlTableCell(b, "3", "TagInstance");
            _verifyAlertText = new xHtmlDiv(b, "AlertText");
            _Okbtn = new xHtmlInputButton(b, "Ok", "DisplayText");
            _productName = new xHtmlEdit(b, "ProductName");
            _ItemNotFoundWin = new xHtmlDiv(b, "ItemNotFoundwindow");
            _canclebtn = new xHtmlInputButton(b, "Cancel", "DisplayText");
            _deletebtn = new xHtmlImage(b,"imgTrash");
            _selectItem = new xHtmlCheckBox(b, "16", "TagInstance");
            _deleteWin = new xHtmlDiv(b, "DeleteConfirmationWnd");
            _yesbtn = new xHtmlInputButton(b, "Yes", "DisplayText");
            _nobtn = new xHtmlInputButton(b, "No", "DisplayText");
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
        /// parm BrowerWindow passing window object
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
            
        }

        /// <summary>
        /// This method is to click on Add Button
        /// </summary>
        public void click_Add()
        {
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

        /// <summary>
        /// This method is to verify success message of create work order
        /// </summary>
        public string verifySuccessMsg()
        {
            string res;
            res = _successmsg.GetProperty("FriendlyName").ToString();
            return res;
        }

        /// <summary>
        /// This method is to verify work order page
        /// </summary>
        public string verifyWorkorderPage()
        {
            string res;
            res = _workorderPage.GetProperty("FriendlyName").ToString();
            return res;
        }

        /// <summary>
        /// This method is to verify error message of work order name in create work order.
        /// </summary>
        public string verifyErrorMsg()
        {
            string res;
            res = _errormsgName.GetProperty("FriendlyName").ToString();
            return res;
        }

        /// <summary>
        /// This method is to filter by work order name in work order>>New page 
        /// parm name is name of work order
        /// </summary>
        public void filterByWorkOrderName(string name)
        {
            _workOrderNameFilterLink.Click();
            _Filtertxt.SetProperty("Text", name);
            _filterbtn.Click();
        }

        /// <summary>
        /// This method is to remove filter by work order name in work order>>New page 
        /// </summary>
        public void removeFilterByWorkOrderName()
        {
            _workOrderNameFilterLink.Click();
            _clearbtn.Click();
        }

        /// <summary>
        /// This method is to verify work order name after filtering by work order name in work order>>New page 
        /// parm name is name of work order
        /// </summary>
        public Boolean verifyworkname(string name)
        {
            string res;
            Boolean flag = false;
            res = _workOrderName.GetProperty("InnerText").ToString();
            if (res.Contains(name))
                flag = true;
            return flag;
        }

        /// <summary>
        /// This method is to verify Madatory lable in create work order page
        /// </summary>
        public Boolean verifyMandatoryFelids()
        {
            string[] a = new string[10];
            a[0] = _nameMadatory.GetProperty("FriendlyName").ToString();
            a[1] = _SPMadatory.GetProperty("FriendlyName").ToString();

            //string res;
            Boolean flag = false;

            if (a[0].Contains("Name*") & a[1].Contains("Service Provider*"))
            {
                flag = true;
            }
           
            return flag; 
        }

        /// <summary>
        /// This method is to verify Auto save message after click Add button in create work order page
        /// </summary>
        public string verifyAutoSave()
        {
            string res;
            res =_msgAutoSave.GetProperty("FriendlyName").ToString();
            return res;
        }

        /// <summary>
        /// This method is to verify work order status in work order>>New page 
        /// parm Status is status of work order
        /// </summary>
        public Boolean verifyworkstatus(string status)
        {
            string res;
            Boolean flag = false;
            res = _workStatus.GetProperty("InnerText").ToString();
            if (res.Contains(status))
                flag = true;
            return flag;
        }

        /// <summary>
        /// This method is to filter by serialNo in create work order page 
        /// parm serialNo is Serial No of Item
        /// </summary>
        public void filterWorkItembySerialNo(string serialNo)
        {
            _serialNoLink.Click();
            _Filtertxt.SetProperty("Text", serialNo);
            _filterbtn.Click();
        }

        /// <summary>
        /// This method is to remove filter by serialNo in create work order page 
        /// </summary>
        public void removefilterWorkItembySerialNo()
        {
            _serialNoLink.Click();
            _clearbtn.Click();
        }

        /// <summary>
        /// This method is to verify serial no after filtering by serialNo in create work order page 
        /// parm serialNo is Serial No of Item
        /// </summary>
        public Boolean verifyserialNo(string serialNo)
        {
            string res;
            Boolean flag = false;
            res = _verifySerialNo.GetProperty("InnerText").ToString();
            if (res.Contains(serialNo))
                flag = true;
            return flag;
        }

        /// <summary>
        /// This method is to verify alert message if same item added twice in create work order page 
        /// </summary>
        public string verifyAlertMsg()
        {
            string res;
            res =_verifyAlertText.GetProperty("FriendlyName").ToString();
            _Okbtn.Click();
            return res;
        }

        /// <summary>
        /// This method is to verify product name after click search button of serial no in create work order page 
        /// </summary>
        public string verifyProductName()
        {
            string res;
            res = _productName.GetProperty("Text").ToString();
            return res;
        }

        /// <summary>
        /// This method is to verify alert message when serial no which is not exsiting is searched in create work order page 
        /// parm txt is alert message (Item not found. Add new item to Inventory?)
        /// </summary>
        public Boolean verifyItemNotFound(string Txt)
        {
            string res;
            Boolean flag = false;
            res = _ItemNotFoundWin.GetProperty("InnerText").ToString();
            if (res.Contains(Txt))
            {
                flag = true;
            }
            _canclebtn.Click();
            return flag;
        }

        /// <summary>
        /// This method is to verify Delete button is Disable in create work order page 
        /// parm txt is status of delete button(DisableButtonJS)
        /// </summary>
         public Boolean verifyDeleteBtn(string Txt)
        {
            string res;
            Boolean flag = false;
            res = _deletebtn.GetProperty("Class").ToString();
            if (res.Contains(Txt))
                flag = true;
            return flag;
        }

         /// <summary>
         /// This method is to verify Delete confirmation window on clicking delete button in create work order page 
         /// parm txt is alert message (Are you sure, you want to remove the selected item(s)?)
         /// </summary>
         public Boolean verifyDeleteConfimationWin(string Txt)
         {
             string res;
             Boolean flag = false;
             res = _deleteWin.GetProperty("InnerText").ToString();
             if (res.Contains(Txt))
             {
                 flag = true;
             }
             return flag;
         }

         /// <summary>
         /// This method is to delete item in create work order page 
         /// parm txt is alert message (Are you sure, you want to remove the selected item(s)?)
         /// </summary>
        public Boolean deleteItem(string txt)
         {
             Boolean res;
             _selectItem.Click();
             _deletebtn.Click();
             res = verifyDeleteConfimationWin(txt);
             _yesbtn.Click();
             return res;
         }

    }
}
