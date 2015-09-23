using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xCodedUI.AppControls;
using xCodedUI.AppControls.WebControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace xCodedUI.AppFramework.Pages
{
    /// <summary>
    /// Represent's the login page of the Honeywell First Application
    /// </summary>
    public class HoneywellFirstLoginLogoff
    {
        private BrowserWindow _browser;
        private xHtmlEdit _usernameBox;
        private xHtmlEdit _passwordBox;
        private xHtmlButton _loginBtn;
        private xHtmlHyperlink _profileBtn;
        private xHtmlHyperlink _logoffBtn;

        public HoneywellFirstLoginLogoff(BrowserWindow window)
        {
            _browser = window;
            _usernameBox = new xHtmlEdit(_browser, "UserName");
            _passwordBox = new xHtmlEdit(_browser, "Password");
            _loginBtn = new xHtmlButton(_browser, "submit", "Type");

            _profileBtn = new xHtmlHyperlink(_browser, "newyork_admin ", "FriendlyName");
            _logoffBtn = new xHtmlHyperlink(_browser, "Logoff", "FriendlyName");
        }

        /// <summary>
        /// This method is a login to Honeywell First
        /// Optional parameter would be used if the desire was to get login credentials string from data source for data driven testing
        /// </summary>
        /// <param name="text">username Text</param>
        /// <param name="text">password Text</param>
        public void Login(string username, string password)
        {
            _usernameBox.SendKeys(username);
            _passwordBox.SendKeys(password);
            _loginBtn.Click();
        }

        /// <summary>
        /// This method is a logout to Honeywell First
        /// </summary>
        public void Logoff()
        {
            _profileBtn.Click();
            _logoffBtn.Click();
        }

    }
}
