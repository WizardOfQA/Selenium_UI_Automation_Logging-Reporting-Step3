using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Configuration;
using Demo_TestFrameWork.CustomException;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using System;
using System.IO;

namespace Orbitz_UI_Test.BaseClass
{
    [TestClass]
    public class BaseClass
    {
        public static ExtentReports report;
        public static ExtentTest test;
        public TestContext _textContext { get; set; }
        private static IWebDriver GetFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tx)
        {
            
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFireFoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound("Driver Not Found: {0}" +
                        ObjectRepository.Config.GetBrowser().ToString());
            }
            Directory.CreateDirectory(ObjectRepository.Config.GetReportStorage());
            report = new ExtentReports(ObjectRepository.Config.GetReportStorage() +
                                        DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".html");

            test = report.StartTest("Initial Navigation to Home Page");
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeout());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementTimeout());
         
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSite());
            test.Log(LogStatus.Info, "Arrived in Home Page.");
            report.AddTestRunnerOutput("Arrived in Home Page.");
            BrowserHelper.MaxBrowser();
            test.Log(LogStatus.Info, "Browser Maximized");
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {              
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
                report.EndTest(test);
                report.Flush();
            }
        }
    }
}
