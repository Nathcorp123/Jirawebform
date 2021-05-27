using OpenQA.Selenium;
using Jirawebform.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Jirawebform.Steps
{
    [Binding]
    public class PEAK
    {
        private IWebDriver driver;
        private ScenarioContext context;
        private string upload;

        public PEAK(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"open Jirwebform application")]
        public void GivenOpenJirwebformApplication()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pas The securitis cheks")]
        public void GivenPasTheSecuritisCheks()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Creat the tickets for PEAK project")]
        public void WhenCreatTheTicketsForPEAKProject()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.proje)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.issuetype)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.summar)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.desc)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            upload = @"C:\Users\manish.verma\Downloads\certificate.pdf";
            driver.FindElement(By.Id(ENLpage.id)).SendKeys(upload);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);
        }
        
        [Then(@"Close the chrome Broser")]
        public void ThenCloseTheChromeBroser()
        {
            driver.Close();
        }
    }
}
