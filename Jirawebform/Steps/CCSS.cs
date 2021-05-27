using Jirawebform.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Jirawebform.Steps
{
    [Binding]
    public class CCSS
    {
        private IWebDriver driver;
        private ScenarioContext context;
        public CCSS(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Open Jirawebform applications")]
        public void GivenOpenJirawebformApplications()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            //driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pass the securities cheks")]
        public void GivenPassTheSecuritiesCheks()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);

        }
        
        [When(@"Create the tickets for CCSS project")]
        public void WhenCreateTheTicketsForCCSSProject()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.projectclickk)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.reqtype)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.reqorg)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.srtsummry)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.detaildes)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);

        }
        
        [Then(@"Close the chrome Browser")]
        public void ThenCloseTheChromeBrowser()
        {
            driver.Close();
        }
    }
}
