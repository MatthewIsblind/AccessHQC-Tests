using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace accessHQ_Test
{
    internal class Form
    {
        private WebDriver driver;

        public Form(WebDriver driver)
        {
            this.driver = driver;
        }

        public void SetNameField(string name)
        {
            driver.FindElement(By.Id("name")).SendKeys(name);
        }

        public void SetEmailField(string email)
        {
            driver.FindElement(By.Id("email")).SendKeys(email);
        }

        public void ClickAgree()
        {
            var checkbox = driver.FindElement(By.Id("agree"));
            Actions action = new Actions(driver);
            action.MoveToElement(checkbox).Click().Build().Perform();
        }

        public void ClickSubmit()
        {
            foreach (WebElement currentElement in driver.FindElements(By.TagName("button")))
            {
                if (String.Equals(currentElement.Text, "submit", StringComparison.OrdinalIgnoreCase))
                {
                    currentElement.Click();
                    break;
                }
            }
        }

        public string getPopUp()
        {

            var popup = driver.FindElement(By.ClassName("popup-message"));
           
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(d => d.FindElement(By.ClassName("popup-message")).Displayed);
            
            return popup.Text;

        }

        internal void SelectState(string state)
        {
            driver.FindElement(By.ClassName("v-select__selections")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.FindElement(By.CssSelector("[role=option]")).Displayed);
            foreach (WebElement givenState in driver.FindElements(By.CssSelector("[role=option]")))
            {
                if (String.Equals( givenState.Text , state, StringComparison.OrdinalIgnoreCase))
                {
                    givenState.Click();
                    break;
                }
            }
        }
    }
}