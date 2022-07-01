using OpenQA.Selenium;

namespace accessHQ_Test
{
    internal class NavBar
    {
        private WebDriver driver;

        public NavBar(WebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickPlanetsForm() 
        {
            driver.FindElement(By.CssSelector("[aria-label=planets]")).Click();
        }

        internal void clickModernForm()
        {
            driver.FindElement(By.CssSelector("[aria-label=forms]")).Click();
        }
    }
}