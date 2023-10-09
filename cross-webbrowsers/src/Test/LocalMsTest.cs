using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
/* For using Remote Selenium WebDriver */
using OpenQA.Selenium.Remote;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]

namespace MS_Test_Cross_Browser
{
    [TestClass]
    public class UnitTest
    {
        String test_url = "https://lambdatest.github.io/sample-todo-app/";
        String itemName = "Yey, Let's add it to list";

        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.Firefox)]
        public void NavigateToDoApp(BrowserType browserType)
        {
            using (var driver = WebDriverInfra.Create_Browser(browserType))
            {
                driver.Navigate().GoToUrl(test_url);

                driver.Manage().Window.Maximize();

                Assert.AreEqual("Sample page - lambdatest.com", driver.Title);
                // Click on First Check box
                IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
                firstCheckBox.Click();

                // Click on Second Check box
                IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
                secondCheckBox.Click();

                // Enter Item name
                IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
                textfield.SendKeys(itemName);

                // Click on Add button
                IWebElement addButton = driver.FindElement(By.Id("addbutton"));
                addButton.Click();

                // Verified Added Item name
                IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
                String getText = itemtext.Text;
                Assert.IsTrue(itemName.Contains(getText));

                /* Perform wait to check the output */
                //System.Threading.Thread.Sleep(4000);

                Console.WriteLine("LT_ToDo_Test Passed");

                driver.Quit();
            }
        }
    }
}