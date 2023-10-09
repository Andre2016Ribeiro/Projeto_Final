
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace crosswebbrowsers
{
    [TestClass]
    public class Crosswebbrowserstest
    {   String test_url = "https://lambdatest.github.io/sample-todo-app/";
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