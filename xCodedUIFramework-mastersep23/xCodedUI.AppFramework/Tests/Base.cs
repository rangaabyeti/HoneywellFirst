using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xCodedUI.AppControls;

namespace xCodedUI.AppFramework.Tests
{
    /// <summary>
    /// Base class for test classes 
    /// </summary>
    [CodedUITest]
    public class Base
    {
        [TestInitialize]
        public void Init()
        {
            BrowserWindow.CurrentBrowser = ConfigurationManager.AppSettings["Browser"];
            Playback.PlaybackSettings.ShouldSearchFailFast = true;
            Playback.PlaybackSettings.MaximumRetryCount = 3;
            Playback.PlaybackError += Playback_PlaybackError;

            if (ConfigurationManager.AppSettings["ClearBrowserAtTestStart"] == "true")
            {
                xBrowser.GetFreshBrowser();                
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            
        }

        // Retry failed action error handler
        private void Playback_PlaybackError(object sender, PlaybackErrorEventArgs e)
        {
            Console.WriteLine("Retrying .... ");
            e.Result = PlaybackErrorOptions.Retry;
            Keyboard.SendKeys("{Enter}");
        }

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
