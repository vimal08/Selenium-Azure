using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using nebulaUITest.pages;

namespace nebulaUITest.tests
{
    public class LoginTest
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        public LoginTest()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Dispose();
        }

        [Fact]
        public void LoadApplicationPage()
        {            
            // Arrange
                
            // Act
            _loginPage.GoTo();
                
            // Assert
            Assert.True(_loginPage.IsLoaded(), "Could not verify Page is visible");
            
            _driver.Close();
            
        }

        [Fact]
        public void VerifyLogin()
        {
            
                // Arrange
                // Act
                _loginPage.GoTo();
                _loginPage.Login("buildman@sage.com", "Sage123!");

                _homePage.IsLoaded();
                // homePage.WaitForPageLoad();
                // Assert

                Assert.True(_homePage.IsLoaded());

        }
    }
}
