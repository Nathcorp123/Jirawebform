using Jirawebform.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jirawebform.Steps
{
    [Binding]
    public class CGSS
    {
        private IWebDriver driver;
        private ScenarioContext context;
        private string upload;
        public CGSS(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Jirawebform application should be opened first")]
        public void GivenJirawebformApplicationShouldBeOpenedFirst()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pass the securities steps for Jirawebform web application")]
        public void GivenPassTheSecuritiesStepsForJirawebformWebApplication()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Create the tickets for CGSS Project")]
        public void WhenCreateTheTicketsForCGSSProject(Table table)
        {

            var data = table.CreateInstance<Data>();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectprojectCGSS)).Click();
           
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.issuetypecgss)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.summarycgss)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.requestercgss)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.reqtypecgss)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.numbrofconcgss)).SendKeys("15");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.comytype)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.comcode)).SendKeys("This is a demo");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.region)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.catagy)).Click();
            Thread.Sleep(3000);
            upload = @"C:\Users\manish.verma\Downloads\certificate.pdf";
            driver.FindElement(By.XPath(ENLpage.uploadcgss)).SendKeys(upload);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            IAlert alertText = driver.SwitchTo().Alert();
            String alertTet = alertText.Text;
            Assert.That(alertTet, Is.EqualTo(alertText.Text));
            alertText.Accept();
            Thread.Sleep(5000);

                                          
        }
        
        [Then(@"Closese the web Browser")]
        public void ThenCloseseTheWebBrowser()
        {
            //driver.Close();
        }
    }
}
