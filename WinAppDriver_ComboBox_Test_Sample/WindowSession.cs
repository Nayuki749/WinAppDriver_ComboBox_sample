using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Threading;
using System;

namespace WinAppDriver_ComboBox_Test_Sample
{
    public class WindowSession
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = @"YourDirectory\WinAppDriver_ComboBox_sample.exe";

        protected static WindowsDriver<WindowsElement> session;

        public static void Setup(TestContext context)
        {
            if(session == null)
            {
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", AppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                Assert.AreEqual("ComboBoxTestForm" ,session.Title);

                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        public static void TearDown()
        {
            if(session != null)
            {
                session.Close();
                try
                {

                }
                catch
                {
                }

                session.Quit();
                session = null;
            }
        }

    }
}
