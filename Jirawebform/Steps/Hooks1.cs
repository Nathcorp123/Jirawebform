using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Jiraweform.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace Jirawebform.Steps
{
    [Binding]
    public class Hooks1
    {
        private static ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private readonly IObjectContainer iob;
        // private ScenarioContext scenarioContext;
        static int rowCount = 3;
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\manish.verma\source\repos\jirawebform\Jirawebform\HTMLReport");
            _extentHtmlReporter.Config.ReportName = "testreport.html";
            _extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                {
                    _feature = _extentReports.CreateTest<Scenario>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
                }

            }
        }
        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }

        }
        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    /*  if (_scenarioContext.TestError != null)
                      {
                          _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                      }
                      else
                      {
                          _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                      }*/
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    /*   if (_scenarioContext.TestError != null)
                       {
                           _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                       }
                       else
                       {
                           _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                       }
   */
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    /* if (_scenarioContext.TestError != null)
                     {
                         _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message+ "\n" + _scenarioContext.TestError.StackTrace);
                     }
                     else
                     {
                         _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                     }
 */
                    CreateNode<Then>();
                    break;
                default:
                    /*if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }*/
                    CreateNode<And>();

                    break;
            }

        }

        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                string name = @"C:\Users\manish.verma\source\repos\jirawebform\Jirawebform" + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
                //GenericHelper.TakeScreenShot(name);
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace)
                    .AddScreenCaptureFromPath(name);
            }
            else
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }
        [BeforeScenario("Tag2")]
        public static void BeforeScenarioContextInjection(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }


        public Hooks1(IObjectContainer iob)
        {
            this.iob = iob;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            iob.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = iob.Resolve<IWebDriver>();
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            if (scenarioName.Equals("Open Jirawebform application and Create Tickets for AUT"))
            {
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for ENL project"))
            {
                rowCount = 4;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for CCSS project"))
            {
                rowCount = 5;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for VSRM project"))
            {
                rowCount = 6;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for IAMext project"))
            {
                rowCount = 7;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for PEAK project"))
            {
                rowCount = 8;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for ITQM project"))
            {
                rowCount = 9;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for WEDPH"))
            {
                rowCount = 10;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for VQDT"))
            {
                rowCount = 11;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }
            else if (scenarioName.Equals("Open Jirawebform application and Create Tickets for CGSS"))
            {
                rowCount = 12;
                if (ScenarioContext.Current.TestError == null)
                {
                    string msg = "Data Validated Successfully";
                    var res = "PASS";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    string msg = ScenarioContext.Current.TestError.Message;
                    var res = "FAIL";

                    WriteDataToExcel.ExcelCode(res, msg, rowCount);

                }
            }

            if
                (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
        }
    }



