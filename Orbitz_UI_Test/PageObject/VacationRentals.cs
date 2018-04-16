using Demo_TestFrameWork.ComponentHelper;
using OpenQA.Selenium;
using Orbitz_UI_Test.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbitz_UI_Test.PageObject
{
    public class VacationRentals : PageBase
    {
        private IWebDriver driver;
        #region IWebElements
        By DestinationTextBox = By.Id("VR-destination"); // Destination Textbox

        By CheckInDateTextBox = By.Id("VR-fromDate"); // Check-in Date

        By CheckOutDateTextBox = By.Id("VR-toDate"); // Check-out Date

        By NumberOfAdultGuestsDDL = By.Id("VR-NumAdult"); // Number of Guests Dropdown List

        By SearchButton = By.Id("VR-searchButtonExt1"); // Search Button

        #endregion IWebElements

        public VacationRentals(IWebDriver _driver) : base(_driver)
        { }

        #region Actions
        public void SearchVacationRentals(string destination, string checkIn, string checkOut, int numberOfGuests)
        {
            TextBoxHelper.TypeInTextBox(DestinationTextBox, destination);
            TextBoxHelper.TypeInTextBox(CheckInDateTextBox, checkIn);
            TextBoxHelper.TypeInTextBox(CheckOutDateTextBox, checkOut);
            DropDownHelper.SelectElementByIndex(NumberOfAdultGuestsDDL, numberOfGuests);
            ButtonHelper.ClickButton(SearchButton);
        }
        #endregion Actions
    }
}
