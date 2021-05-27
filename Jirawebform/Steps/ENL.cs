using Jirawebform.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Jirawebform.Steps
{
    [Binding]
    public class ENL
    {
        private IWebDriver driver;
        private ScenarioContext context;

        public ENL(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"Open Jirawebform application")]
        public void GivenOpenJirawebformApplication()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            // driver.Url = test_url;
           // driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);

        }

        protected static void Jirawebform()
        {
            throw new NotImplementedException();
        }

        [Given(@"Pass the securities first")]
        public void GivenPassTheSecuritiesFirst()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Create the tickets for ENL project")]
        public void WhenCreateTheTicketsForENLProject()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.projectclick)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            driver.FindElement(By.XPath(ENLpage.requesttype)).Click();
            driver.FindElement(By.XPath(ENLpage.requestingorganizn)).Click();
            driver.FindElement(By.XPath(ENLpage.urgentbusiness)).Click();
            driver.FindElement(By.XPath(ENLpage.summary)).SendKeys("This is a demo");
            driver.FindElement(By.XPath(ENLpage.description)).SendKeys("This is a demo");
            driver.FindElement(By.XPath(ENLpage.click)).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);




        }
        
        [Then(@"Close the web Browser")]
        public void ThenCloseTheWebBrowser()
        {
            driver.Close();
        }
    }
}
