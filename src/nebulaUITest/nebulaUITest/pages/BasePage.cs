using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace nebulaUITest.pages
{
    public abstract class BasePage
    {
        readonly string PageTitle;
        protected readonly IWebDriver _driver;


        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
