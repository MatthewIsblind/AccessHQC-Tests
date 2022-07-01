using OpenQA.Selenium;

namespace accessHQ_Test
{
    internal class Planet
    {
        private WebElement webElement;

        public Planet(WebElement planetElement)
        {
            this.webElement = planetElement;
        }

        internal void clickExplore()
        {
            this.webElement.FindElement(By.TagName("button")).Click();
        }

        internal String GetName()
        {

            return this.webElement.FindElement(By.ClassName("headline")).Text;
        }

        internal string? GetRadius()
        {
            throw new NotImplementedException();
        }
    }
}