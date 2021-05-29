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
    public class VQDT
    {
        private IWebDriver driver;
        private ScenarioContext context;
        private string upload;
        public VQDT(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Jirawebform application should be opene")]
        public void GivenJirawebformApplicationShouldBeOpene()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"Pass the securities steps for Jirawebform")]
        public void GivenPassTheSecuritiesStepsForJirawebform()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }

        [When(@"Create the tickets for VQDT Project")]
        public void WhenCreateTheTicketsForVQDTProject(Table table)
        {
            var data = table.CreateInstance<Data>();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.vqdt)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.vqdtissuetype)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.vqdtsummary)).SendKeys("THis is a demo");
            driver.FindElement(By.XPath(ENLpage.vqdtdescriptn)).SendKeys("THis is a demo");
            upload = @"C:\Users\manish.verma\Downloads\certificate.pdf";
            driver.FindElement(By.XPath(ENLpage.vqdtupload)).SendKeys(upload);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            IAlert alertText = driver.SwitchTo().Alert();
            String alertTet = alertText.Text;
            Assert.That(alertTet, Is.EqualTo(alertText.Text));
           // Assert.That(alertTet, Is.Not.EqualTo(alertText.Text));

            alertText.Accept();
            Thread.Sleep(5000);
        }


        [Then(@"Closese the Browser")]
        public void ClosesetheBrowser()
        {
            driver.Close();
        }


    }
}

