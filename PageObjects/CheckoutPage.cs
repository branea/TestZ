using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement FirstName => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("first-name")));

        private IWebElement LastName => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("last-name")));

        private IWebElement PostalCode => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("postal-code")));
        private IWebElement ContinueButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("continue")));
        private IWebElement CancelButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cancel")));
        private IWebElement FinishButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("finish")));
        private IWebElement SuccessfulOrderMessage => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Thank you for your order!')]")));
        private IWebElement LastNameIsRequiredMessage(string errorMessage) => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[contains(text(), '{errorMessage}')]")));


        public void ClickOnContinueButton()
        {
            ContinueButton.Click();
        }

        public void ClickOnCancelButton()
        {
            _actions.MoveToElement(CancelButton);
            CancelButton.Click();
        }

        public void FillPostalCode(string value)
        {
            PostalCode.SendKeys(value);
        }

        public void FillLastName(string value)
        {
            _actions.MoveToElement(LastName);
            LastName.SendKeys(value);
        }

        public void FillFirstName(string value)
        {
            _actions.MoveToElement(FirstName);
            FirstName.SendKeys(value);
        }

        public bool OrderIsSuccessful()
        {
            return SuccessfulOrderMessage.Displayed;
        }

        public bool LastNameIsRequiredMessageIsDisplayed(string message)
        {
            return LastNameIsRequiredMessage(message).Displayed;
        }

        public void ClickOnFinishButton()
        {
            FinishButton.Click();
        }
    }
}
