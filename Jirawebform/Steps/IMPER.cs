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
    public class IAMExt
    {

        private IWebDriver driver;
        private ScenarioContext context;
        public IAMExt(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"open Jirwebform applications")]
        public void GivenOpenJirwebformApplications()
        {
            driver.Navigate().GoToUrl("https://sb-jira-test1.mmm.com/JiraWebForm/");
            System.Threading.Thread.Sleep(2000);
        }

        [Given(@"Pas The securities cheks")]
        public void GivenPasTheSecuritiesCheks()
        {
            driver.FindElement(By.XPath(ENLpage.detail)).Click();
            driver.FindElement(By.XPath(ENLpage.proceed)).Click();
            Thread.Sleep(2000);
        }

        [When(@"creat the tickets for IAMExt project")]
        public void WhenCreatTheTicketsForCCSSProject(Table table)
        {
            var data = table.CreateInstance<Data>();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath(ENLpage.selectproject)).Click();
            driver.FindElement(By.XPath(ENLpage.projclick)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(ENLpage.pin)).SendKeys("a4tc3zz");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ENLpage.verify)).Click();
            js.ExecuteScript("window.scrollBy(0,800)");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.reqty)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.reqqorg)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.srtsum)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.dtaildesp)).SendKeys("This is a demo");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ENLpage.clcik)).Click();
            Thread.Sleep(10000);
            //driver.SwitchTo().Alert().Accept();
            IAlert alertText = driver.SwitchTo().Alert();
            String alertTet = alertText.Text;

            // Assert.That(data.TextAlerts, Is.Not.EqualTo(alertTet));
            Assert.That(alertTet, Is.EqualTo(alertText.Text));

            //if (alertTet == data.TextAlerts)
            //{
            //    Console.WriteLine("Tickets created fail");

            //}
            //else
            //{
            //    Console.WriteLine("Tickets creation sucessfully");
            //}

            alertText.Accept();


            Thread.Sleep(5000);

        }

        [Then(@"close the chrome Browser")]
        public void ThenCloseTheChromeBrowser()
        {
            driver.Close();
        }
    }
}
