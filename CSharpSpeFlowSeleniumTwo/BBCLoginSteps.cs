using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace CSharpSpecFlowSelenium
{
    [Binding]
    public class BBCLoginSteps
    {
        // web driver
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {

        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://BBC.co.uk/");
            IWebElement loginButton = driver.FindElement(By.Id("idcta-link"));
            loginButton.Click();
        }

        [Given(@"I have entered a valid username")]
        public void GivenIHaveEnteredAValidUsername()
        {
            IWebElement userNameField = driver.FindElement(By.Id("user-identifier-input"));
            userNameField.SendKeys("edbox52@gmail.com");
        }

        [Given(@"I have entered a invalid password")]
        public void GivenIHaveEnteredAInvalidPassword()
        {
            IWebElement passwordField = driver.FindElement(By.Id("password-input"));
            passwordField.SendKeys("1234566678");
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            IWebElement signInButton = driver.FindElement(By.Id("submit-button"));
            signInButton.Click();
        }

        [Then(@"I should see the appropriate error")]
        public void ThenIShouldSeeTheAppropriateError()
        {
            IWebElement error = driver.FindElement(By.Id("form-message-password"));
            Assert.AreEqual("Sorry, that password isn't valid. Please include a letter.", error.Text);
        }

        [AfterScenario]
        public void cleanUp()
        {
            driver.Close();
        }
    }
}
