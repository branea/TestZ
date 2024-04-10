using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TechTalk.SpecFlow;
using Test_Framework.PageObjects;

namespace Test_Framework.Steps
{
    [Binding, Scope(Feature = "LogIn"), Scope(Feature = "CheckoutPage")]
    public class LogInStepDefinitions : BasePage
    {
        private readonly Navigator _navigator;
        private LogInPage _logInPage;
        private ProductsPage _productsPage;
        private CartPage _cartPage;
        private CheckoutPage _checkoutPage;
        private IEnumerable<string> tags;

        public LogInStepDefinitions(Navigator navigator, IWebDriver webDriver) : base(webDriver)
        {
            _navigator = navigator;
            _productsPage = new ProductsPage(webDriver);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _logInPage = _navigator.GoTo<LogInPage>(new Uri(Configuration.ApplicationUrl));
        }

        [Given(@"I fill the credentials")]
        [When(@"I fill the credentials")]
        [Then(@"I fill the credentials")]
        public void WhenIFillTheCredentials()
        {
            var username = "";
            tags = ScenarioContext.Current.ScenarioInfo.Tags.AsQueryable();


            if (tags.Where(tag => tag.Equals("Locked")).Any())
            {
                username = Configuration.LockedUserName;
            }
            else if (tags.Where(tag => tag.Equals("Standard")).Any())
            {
                username = Configuration.StandardUserName;
            }
            else if (tags.Where(tag => tag.Equals("Performance")).Any())
            {
                username = Configuration.PerformanceUserName;
            }
            else if (tags.Where(tag => tag.Equals("Error")).Any())
            {
                username = Configuration.ErrorUserName;
            }
            else if (tags.Where(tag => tag.Equals("Problem")).Any())
            {
                username = Configuration.ProblemUserName;
            }
            else if (tags.Where(tag => tag.Equals("UsernameEmpty")).Any())
            {
                username = "";
            }

            _logInPage.FillTheUsername(username);
            _logInPage.FillThePassword(Configuration.Password);

        }

        [Given(@"Click the login button")]
        [When(@"Click the login button")]
        [Then(@"Click the login button")]
        public void WhenClickTheLoginButton()
        {
            _logInPage.ClickOnLogInButton();

            if(tags.Where(tag => tag.Equals("Locked")).Any() || tags.Where(tag => tag.Equals("UsernameEmpty")).Any())
            {
            }
            else
            {
                _productsPage.ResetTheAppState();
            }
        }

        [Then(@"I am redirected to the products page")]
        public void ThenIAmRedirectedToTheProductsPage()
        {
            Assert.True(_productsPage.ProductsTitleIsDisplayed());
        }

        [Then(@"I can see the error message ""([^""]*)""")]
        public void ThenICanSeeTheErrorMessage(string p0)
        {
            Assert.True(_logInPage.LockedUserMessageIsDisplayed(p0));
        }

        [When(@"I add a '([^']*)' to card")]
        public void WhenIAddAToCard(string p0)
        {
            _productsPage.AddProductToCart(p0);
        }


        [When(@"I do the checkout")]
        public void WhenIDoTheCheckout()
        {
            _cartPage = _productsPage.GoToCart();
            _checkoutPage = _cartPage.ClickOnCheckout();
        }

        [When(@"I fill in all the Checkout Information fields")]
        public void WhenIFillInAllTheCheckoutInformationFields()
        {

            _checkoutPage.FillFirstName("TestFN");

            if (tags.Where(tag => tag.Equals("EmptyCheckoutLastName")).Any())
            {
                _checkoutPage.FillLastName("");
            }
            else
            {
                _checkoutPage.FillLastName("TestLN");
            }

            _checkoutPage.FillPostalCode("765433");
            _checkoutPage.ClickOnContinueButton();
        }

        [Then(@"I can see the error message ""([^""]*)"" popped for missing value for Last Name field")]
        public void ThenICanSeeTheErrorMessagePoppedForMissingValueForLastNameField(string p0)
        {
            _checkoutPage.LastNameIsRequiredMessageIsDisplayed(p0);
        }

        [Then(@"I can see that there is a delay for loading the page")]
        public void ThenICanSeeThatThereIsADelayForLoadingThePage()
        {
            Assert.True(_productsPage.ProductsTitleIsDisplayed());
        }

        [Then(@"I can see the ""([^""]*)"" message")]
        public void ThenICanSeeTheMessage(string p0)
        {
            Assert.True(_logInPage.EmptyUsernameMessageIsDisplayed(p0));
        }

    }
}
