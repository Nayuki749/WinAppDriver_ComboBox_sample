/*
 * This is a sample program that uses WinAppDriver to select items for ComboBox.
 * We are not responsible for defects because of samples to confirm the operation.
 *
 * Nayuki749
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Threading;
using System;
using System.Diagnostics;

namespace WinAppDriver_ComboBox_Test_Sample
{
    [TestClass]
    public class ComboBox_test_class : WindowSession
    {
        [TestMethod]
        public void ComboBoxTestSample()
        {
            //combo box object
            var comboBox = session.FindElementByAccessibilityId("comboBox1");
            //combo box open
            var comboBoxOpen = comboBox.FindElementByName("開く");
            
            comboBox.SendKeys(Keys.Down);
            comboBoxOpen.Click();
            //get items
            var listItems = comboBox.FindElementsByTagName("ListItem");

            Debug.WriteLine($"Combo box items count: {listItems.Count}");

            foreach (var item in listItems)
            {
                Debug.WriteLine(item.Text);
                if (item.Text == "item3")
                {
                    item.Click();
                }
            }
            // Assert Select item
            Assert.AreEqual("item3", comboBox.Text);
        }

        [ClassInitialize]
        public static void ClassInitalize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
