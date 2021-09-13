using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace nebulaUITest.pages
{
    public class GeneralLedgerSetupPage : BasePage, IPage
    {
        public IWebElement HeaderField
        {
            get { return _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/h4")); }
        }

        public GeneralLedgerSetupPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsLoaded()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));

            // You would want some way to specify exactly what piece failed.
            try
            {
                var url = "https://app-nebula-ui-devtest.azurewebsites.net/";
                wait.Until(d => d.Url.EndsWith("generalLedgerSetup"));
                // wait.Until(d => DrawerMenu.Displayed);
            }
            catch (WebDriverTimeoutException wex)
            {
                return false;
            }

            if (HeaderField.Text != "General Ledger Setup")
                return false;

            return true;
        }
    }
}
