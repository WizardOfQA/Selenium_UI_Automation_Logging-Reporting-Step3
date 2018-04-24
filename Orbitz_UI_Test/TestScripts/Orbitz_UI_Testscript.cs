
using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Orbitz_UI_Test.PageObject;
using Orbitz_UI_Test.BaseClass;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;

namespace Orbitz_UI_Test.TestScripts
{
    [TestClass]
    public class Orbitz_UI_Testscript
    {
        public TestContext TestContext { get; set; }
        private static LogHelper log = new LogHelper();

        [TestCategory("POM")]
        [TestMethod]
        public void User_Can_Search_Vacation_Rental()
        {
            log.Info("Starting Test: " + TestContext.TestName);
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest(TestContext.TestName);            
            Home hp = new Home(ObjectRepository.Driver);                        
            VacationRentals vr = hp.NavigateToVacationRentals();
            log.Info("Navigated To Vacation Rentals Page");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Vacation Rentals Page");
            vr.SearchVacationRentals("Central Park, New York, New York", "09/19/2018", "09/23/2018", 2);
            log.Info("Filled Out And Sumbmitted For Searching Vacation Rentals");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Filled Out And Sumbmitted For Searching Vacation Rentals");

            log.Info("Verifying the Expected & Actual");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Verifying the Expected & Actual");
            Assert.AreEqual("Central Park Hotel Search Results | Orbitz", WindowHelper.GetPageTitle());
        }

        [TestCategory("POM")]
        [TestMethod]
        public void User_Can_Search_Rental_Car_With_Advanced_Options()
        {
            log.Info("Starting Test: " + TestContext.TestName);
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest(TestContext.TestName);
            Home hp = new Home(ObjectRepository.Driver);
            Cars cars = hp.NavigateToCars();
            log.Info("Navigated To Cars Page");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Cars Page");
                
            cars.SearchForRentalCarWithAdvancedOptions("LAX", "07/06/2018", 28, "07/09/2018", 12);
            log.Info("Default Fields Have Been Filled Out");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Default Fields Have Been Filled Out");

            CheckBoxHelper.CheckOnCheckBox(cars.InfantSeatChbx);
            CheckBoxHelper.CheckOnCheckBox(cars.ToddlerSeatChbx);
            CheckBoxHelper.CheckOnCheckBox(cars.NavigationSystemChbx);
            log.Info("Advanced Options Are Selected");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Advanced Options Are Selected");

            ButtonHelper.ClickButton(cars.SearchCarBtn);
            log.Info("Options Are Submitted");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Options Are Submitted");

            log.Info("Verifying the Expected Phrase are displayed");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Verifying the Expected Phrase are displayed");
            Assert.IsTrue(GenericHelper.IsElementPresent(By.XPath("//span[@title='Los Angeles, CA (LAX-Los Angeles Intl.)']")));
        }

        [TestCategory("POM")]
        [TestMethod]
        public void Test_To_Be_Failed()
        {
            log.Info("Starting Test: " + TestContext.TestName);
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest(TestContext.TestName);
            Home hp = new Home(ObjectRepository.Driver);
            VacationRentals vr = hp.NavigateToVacationRentals();
            log.Info("Navigated To Vacation Rentals Page");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Vacation Rentals Page");

            log.Info("We are intensionally making the test fail here");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "We are intensionally making the test fail here");
            Assert.IsTrue(false);
        }

        
        [TestCleanup]
        public void TestCleanup()
        {        
            if (TestContext.CurrentTestOutcome.ToString().Equals("Passed"))
            {
                BaseClass.BaseClass.test.Log(LogStatus.Pass, "Test completed and passed");                
            }
            else if (TestContext.CurrentTestOutcome.ToString().Equals("Failed"))
            {
                string path = GenericHelper.TakeScreenShotForReport();
                string imagePath = BaseClass.BaseClass.test.AddScreenCapture(path);
                BaseClass.BaseClass.test.Log(LogStatus.Fail, "Test Failed in " + TestContext.TestName , imagePath);
            }
        }    
    }
}
