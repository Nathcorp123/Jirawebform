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
    public class WEDPH
    {
        private IWebDriver driver;
        private ScenarioContext context;
        public WEDPH(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Jirawebform application should be open")]
        public void GivenJirawebformApplicationShouldBeOpen()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pass the securities steps")]
        public void GivenPassTheSecuritiesSteps()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Create the tickets for WEDPH")]
        public void WhenCreateTheTicketsForWEDPH(Table table)
        {
            var data = table.CreateInstance<Data>();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.wedprjtclick)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.wedissuetype)).Click();
            driver.FindElement(By.XPath(ENLpage.wedcomponets)).Click();
            driver.FindElement(By.XPath(ENLpage.wedpriority)).Click();
            driver.FindElement(By.XPath(ENLpage.wedactivity)).Click();
            driver.FindElement(By.XPath(ENLpage.wedsummary)).SendKeys("Demo test");
            driver.FindElement(By.XPath(ENLpage.weddescriptiom)).SendKeys("Demo test");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            IAlert alertText = driver.SwitchTo().Alert();
            String alertTet = alertText.Text;
            //Assert.That(data.TextAlertswedph, Is.EqualTo(alertTet));
            Assert.That(alertTet, Is.Not.EqualTo(alertText.Text));

            alertText.Accept();
            Thread.Sleep(5000);
        }
        
        [Then(@"Closse the Browser")]
        public void ThenClosseTheBrowser()
        {
            driver.Close();
        }
    }
}
