using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace xCodedUI.AppControls.WinControls
{
    /// <summary>
    /// Inherits from Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDiv
    /// Implements base methods and properties defined in the IxControl interface
    /// </summary>
    public class xWinPane : WinPane, IxControl
    {
        public xWinPane(UITestControl parent) : base(parent) { }

        public xWinPane(UITestControl parent, string id, string id1, string searchProperty = "ControlType", string searchProperty1 = "DisplayText")
            : base(parent)
        {
            this.SearchProperties.Add(searchProperty, id);
            this.SearchProperties.Add(searchProperty1, id1);
        }

        public void Focus()
        {
            this.WaitForControlReady();
            this.SetFocus();
        }

        public void Click()
        {
            this.WaitForControlReady();
            this.SetFocus();
            Mouse.Click(this);
        }

        public void SendKeys(string text)
        {
            this.WaitForControlReady();
            this.SetFocus();
            Keyboard.SendKeys(this, text);
        }

        public void Tab()
        {
            this.WaitForControlReady();
            Keyboard.SendKeys("{ENTER}");
        }
    }
}
