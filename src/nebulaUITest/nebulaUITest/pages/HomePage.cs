using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace nebulaUITest.pages
{
    public class HomePage : BasePage, IPage
    {
        private const string FIELD_EMAIL = "email";
        private const string FIELD_PASSWORD = "password";

        public IWebElement BurgerMenu
        {
            get { return _driver.FindElement(By.CssSelector(".MuiSvgIcon-root"));}
        }

        public IWebElement TextField
        {
            get {  return _driver.FindElement(By.CssSelector(".MuiContainer-root > div"));}
        }

        public IWebElement BurgerMenuGeneralLedgerSetup
        {
            get { return _driver.FindElement(By.LinkText("General Ledger Setup")); }
        }

        public IWebElement DrawerMenu
        {
            get { return _driver.FindElement(By.XPath("//*[@id=\"navigation - drawer\"]/div[3]"));}
        }

        public HomePage(IWebDriver driver): base(driver)
        {           
                    
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://app-nebula-ui-devtest.azurewebsites.net/");
            this.IsLoaded();
        }
       
        public bool IsLoaded()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));

            // You would want some way to specify exactly what piece failed.
            try
            {
                var url = "https://app-nebula-ui-devtest.azurewebsites.net/";
                wait.Until(d => d.Url.StartsWith(url));
                wait.Until(d => TextField.Displayed);
                // wait.Until(d => DrawerMenu.Displayed);
            }
            catch (WebDriverTimeoutException wex)
            {
                return false;
            }

            if(TextField.Text != "This is an app!")
                return false;

            return true;
        }
    }
}
