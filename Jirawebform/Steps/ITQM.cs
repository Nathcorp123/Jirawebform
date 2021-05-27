using Jirawebform.Pages;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Jirawebform.Steps
{
    [Binding]
    public class ITQM
    {
        private IWebDriver driver;
       // private ScenarioContext context;
        private string upload;
        public ITQM(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"oPen Jirwebform application")]
        public void GivenOPenJirwebformApplication()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);

        }
        
        [Given(@"Pass The securitis cheks")]
        public void GivenPassTheSecuritisCheks()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Creat the tickets for ITQM project")]
        public void WhenCreatTheTicketsForITQMProject()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.prjctclick)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.issuetypee)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.summmary)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.namegoreport)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.contactmae)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.des)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.typeofrror)).Click();
            Thread.Sleep(5000);
            upload = @"C:\Users\manish.verma\Downloads\certificate.pdf";
            driver.FindElement(By.XPath(ENLpage.idd)).SendKeys(upload);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);




        }
        
        [Then(@"Close the chrome Brosers")]
        public void ThenCloseTheChromeBrosers()
        {
            driver.Close();
        }
    }
}
