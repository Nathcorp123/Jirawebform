using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Jirawebform.Pages;
using TechTalk.SpecFlow;
using System.Threading;

namespace Jirawebform.Steps
{
    [Binding]
    public class Jirawebform
    {
        private IWebDriver driver;
        private ScenarioContext context;
        

        public Jirawebform(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Jirawebform application should be opened")]
        public void GivenJirawebformApplicationShouldBeOpened()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pass the securities")]
        public void GivenPassTheSecurities()
        {
            driver.FindElement(By.XPath(Homepage.detail)).Click();
            driver.FindElement(By.XPath(Homepage.proceed)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"Create the tickets for AUT")]
        public void WhenCreatetheticketsforAUT()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(Homepage.selectproject)).Click();
            driver.FindElement(By.XPath(Homepage.projectclick)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(Homepage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(Homepage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            driver.FindElement(By.XPath(Homepage.TestType)).Click();
            driver.FindElement(By.XPath(Homepage.TestTypedrpvalue)).Click();
            driver.FindElement(By.XPath(Homepage.smoketest)).Click();
            driver.FindElement(By.XPath(Homepage.smoketestvalue)).Click();
            driver.FindElement(By.XPath(Homepage.issuetype)).Click();
            driver.FindElement(By.XPath(Homepage.issuetypevalue)).Click();
            driver.FindElement(By.XPath(Homepage.businessprocess)).SendKeys("hello");
            driver.FindElement(By.XPath(Homepage.almsetname)).SendKeys("Text");
            driver.FindElement(By.XPath(Homepage.operatingsystem)).Click();
            driver.FindElement(By.XPath(Homepage.owingteam)).Click();
            driver.FindElement(By.XPath(Homepage.owingteamvalue)).Click();
            driver.FindElement(By.XPath(Homepage.description)).SendKeys("This is a demo for AUT project");
            driver.FindElement(By.XPath(Homepage.dataparameter)).SendKeys("This is a demo for AUT project");
            driver.FindElement(By.XPath(Homepage.createissue)).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);
        }
        
        [Then(@"Close the Browser")]
        public void ThenClosetheBrowser()
        {
           
             driver.Close();
        }
    }
}
