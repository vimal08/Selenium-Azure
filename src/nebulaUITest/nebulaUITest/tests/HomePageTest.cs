using nebulaUITest.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace nebulaUITest.tests
{
    public class HomePageTest : IDisposable
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private GeneralLedgerSetupPage _generalLedgerSetupPage;

        public HomePageTest()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
            _generalLedgerSetupPage = new GeneralLedgerSetupPage(_driver);

            _loginPage.GoTo();
            _loginPage.Login("buildman@sage.com", "Sage123!");
            _homePage.IsLoaded();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }


        [Fact]
        public void TestBurgerMenu()
        {
            //Arrange
            _homePage.GoTo();
            // Act
            _homePage.BurgerMenu.Click();
            // Assert
            Assert.True(_homePage.BurgerMenu.Displayed);
            
        }

        [Fact]
        public void NavigateToGeneralLedgerSetupScreen()
        {
            
            // Arrange
            _homePage.GoTo();
            // Act
            _homePage.BurgerMenu.Click();             
            _homePage.BurgerMenuGeneralLedgerSetup.Click();
            // Assert
            Assert.True(_generalLedgerSetupPage.IsLoaded());
        }
    }
}
