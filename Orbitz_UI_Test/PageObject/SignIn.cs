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
    public class SignIn : PageBase
    {
        #region IWebElements
        By SignInWithFaceBookBtn = By.Id("e3login-facebook-button"); //Sign in with Facebook
        By LookingForSignInWithGoogleBtn = By.ClassName("googlelink"); //Looking for Sign In with Google?
        By EmailAddressTxtBox = By.Id("signin-loginid"); //Email Address textbox
        By PasswordTxtBox = By.Id("signin-password"); //Password textbox
        By ForgotYourPasswordLnk = By.Id("go-to-forgot-password"); //Forgot your password?
        By SignInBtn = By.Id("submitButton"); //Sign In button
        #endregion IWebElements
        public SignIn(IWebDriver _driver) : base(_driver)
        { }

        #region Action
        public void LogIn(string userName, string password)
        {
            TextBoxHelper.TypeInTextBox(EmailAddressTxtBox, userName);
            TextBoxHelper.TypeInTextBox(PasswordTxtBox, password);
            ButtonHelper.ClickButton(SignInBtn);
        }

        #endregion Action
    }
}
