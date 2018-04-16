
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

        [TestCategory("POM")]
        [TestMethod]
        public void User_Can_Search_Vacation_Rental()
        {                        
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest("User_Can_Search_Vacation_Rentla");            
            Home hp = new Home(ObjectRepository.Driver);                        
            VacationRentals vr = hp.NavigateToVacationRentals();
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Vacation Rentals Page");
            vr.SearchVacationRentals("Central Park, New York, New York", "09/19/2018", "09/23/2018", 2);
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Filled Out And Sumbmitted For Searching Vacation Rentals");
            Assert.AreEqual("Central Park Hotel Search Results | Orbitz", WindowHelper.GetPageTitle());
        }

        [TestCategory("POM")]
        [TestMethod]
        public void User_Can_Search_Rental_Car_With_Advanced_Options()
        {
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest("User_Can_Search_Rental_Car_With_Advanced_Options");
            Home hp = new Home(ObjectRepository.Driver);
            Cars cars = hp.NavigateToCars();
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Cars Page");
            cars.SearchForRentalCarWithAdvancedOptions("LAX", "07/06/2018", 28, "07/09/2018", 12);
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Default Fields Have Been Filled Out");
            CheckBoxHelper.CheckOnCheckBox(cars.InfantSeatChbx);
            CheckBoxHelper.CheckOnCheckBox(cars.ToddlerSeatChbx);
            CheckBoxHelper.CheckOnCheckBox(cars.NavigationSystemChbx);
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Advanced Options Are Selected");
            ButtonHelper.ClickButton(cars.SearchCarBtn);
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Options Are Submitted");
            Assert.IsTrue(GenericHelper.IsElementPresent(By.XPath("//span[@title='Los Angeles, CA (LAX-Los Angeles Intl.)']")));
        }

        [TestCategory("POM")]
        [TestMethod]
        public void Test_To_Be_Failed()
        {
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest("Test_To_Be_Failed");
            Home hp = new Home(ObjectRepository.Driver);
            VacationRentals vr = hp.NavigateToVacationRentals();
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Vacation Rentals Page");
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
