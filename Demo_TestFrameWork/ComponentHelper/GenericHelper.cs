using Demo_TestFrameWork.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
            {
                return ObjectRepository.Driver.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException("Element Not Found: " + locator.ToString());
            }
        }

        public static void TakeScreenShot(string fileName = "Screenshot")
        {
            // if there is no storage folder, create
            Directory.CreateDirectory(ObjectRepository.Config.GetScreenshotStorage());

            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            fileName = fileName + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".jpeg";
            screen.SaveAsFile(ObjectRepository.Config.GetScreenshotStorage() + "\\" +
                                                        fileName, ScreenshotImageFormat.Jpeg);
        }
        public static string TakeScreenShotForReport(string filename = "Screenshot")
        {            
            string directory = ObjectRepository.Config.GetScreenshotStorage();
            Directory.CreateDirectory(directory);
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();

            filename = filename + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpeg";
            string destination = directory + filename;
            screen.SaveAsFile(destination, ScreenshotImageFormat.Jpeg);

            return destination;
        }
    }
}
