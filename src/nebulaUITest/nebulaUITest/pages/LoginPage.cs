using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace nebulaUITest.pages
{
    public class LoginPage : BasePage, IPage
    {
        private const string FIELD_EMAIL = "email";
        private const string FIELD_PASSWORD = "password";
                
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement EmailField
        {
            get { return _driver.FindElement(By.Name(FIELD_EMAIL)); }
        }

        public IWebElement PasswordField
        {
            get { return _driver.FindElement(By.Name(FIELD_PASSWORD)); }
        }

        public IWebElement LoginButton
        {
            get { return _driver.FindElement(By.ClassName("auth0-lock-submit")); }
        }

        public bool IsLoaded()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));

            // You would want some way to specify exactly what piece failed.
            try { 
                var url = "https://id-shadow.sage.com";
                wait.Until(d => d.Url.StartsWith(url));
                wait.Until(d => EmailField.Displayed);
            }
            catch(WebDriverTimeoutException wex)
            {
                return false;
            }

            if (_driver.Title != "Log in to Sage")
            { 
                return false;
            }
            return true;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://app-nebula-ui-devtest.azurewebsites.net/");
            IsLoaded();
        }

        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public void Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickLogin();
        }

    }
}
