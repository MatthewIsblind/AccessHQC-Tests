using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace accessHQ_Test
{
    internal class PlanetsPage
    {
        private WebDriver driver;

        public PlanetsPage(WebDriver driver)
        {
            this.driver = driver;
        }

        internal Planet ExploreWithLambda(Predicate<Planet> testLogic)
        {
            foreach (WebElement planetElement in driver.FindElements(By.ClassName("planet")))
            {
                var planet = new Planet(planetElement);
                if (testLogic.Invoke(planet))
                {
                    return planet;
                }

            }

            throw new NotImplementedException("no such planent");
        }

        internal object getPopUp()
        {
            var messageIdentifier = By.ClassName("popup-message");
            var popup = driver.FindElement(messageIdentifier);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until( d => d.FindElement(messageIdentifier).Displayed);
            return popup.Text;
        }
    }
}