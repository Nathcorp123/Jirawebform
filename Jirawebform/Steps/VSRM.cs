using Jirawebform.Pages;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Jirawebform.Steps
{
    [Binding]
    public class VSRM
    {

        private IWebDriver driver;
        private ScenarioContext context;
        public VSRM(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open Jirwebform applications")]
        public void GivenOpenJirwebformApplications()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pas the securities cheks")]
        public void GivenPasTheSecuritiesCheks()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Creat the tickets for CCSS project")]
        public void WhenCreatTheTicketsForCCSSProject()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.projectclickkk)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.reqtypee)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.reqorgn)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.srtsummryy)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.detaildesp)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);
        }
        
        [Then(@"Close the chrme Browser")]
        public void ThenCloseTheChrmeBrowser()
        {
            driver.Close();
            
        }
    }
}
