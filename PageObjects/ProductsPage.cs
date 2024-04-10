using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement ProductsTitle => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Products')]")));
        private IWebElement AddProduct(string product) => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id($"{product}")));
        private IWebElement CartButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("shopping_cart_container")));
        private IWebElement ResetTheApp => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("reset_sidebar_link")));
        private IWebElement BurgerMenu => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("react-burger-menu-btn")));


        public bool ProductsTitleIsDisplayed()
        {
            return ProductsTitle.Displayed;
        }

        public void AddProductToCart(string productName)
        {
            AddProduct(productName).Click();
        }

        public CartPage GoToCart()
        {
            CartButton.Click();

            return new CartPage(_webDriver);
        }
        public void ResetTheAppState()
        {
            BurgerMenu.Click();
            ResetTheApp.Click();
        }
    }
}
