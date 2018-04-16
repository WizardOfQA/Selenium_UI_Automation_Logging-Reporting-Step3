using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class WindowHelper
    {
        public static string GetPageTitle()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/head/title[1]")));
            return ObjectRepository.Driver.Title;
        }

        // Switch the window 
        public static void SwitchToWindow(int index = 0)
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            if(windows.Count < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index " + index);
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            BrowserHelper.MaxBrowser();
        }

        // close all the child windows and go back to the parent window.
        public static void SwitchToParent()
        {
            var windowsids = ObjectRepository.Driver.WindowHandles;
            for(int i=windowsids.Count-1; i>0; i--)
            {
                ObjectRepository.Driver.SwitchTo().Window(windowsids[i]);
                ObjectRepository.Driver.Close();
            }
            ObjectRepository.Driver.SwitchTo().Window(windowsids[0]);
        }

        // input: iframe id
        public static void SwitchToiFrame(By locator)
        {
            ObjectRepository.Driver.SwitchTo().Frame(GenericHelper.GetElement(locator));
        }

        public static void SwitchToMainFrame()
        {
            ObjectRepository.Driver.SwitchTo().DefaultContent();
        }
    }
}
