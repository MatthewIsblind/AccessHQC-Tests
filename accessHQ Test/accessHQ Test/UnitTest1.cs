using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace accessHQ_Test
{

    [TestClass]
    public class PlanetPageTestSuite
    {
        private WebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/";
        }

        [TestMethod]
        public void ExplorePlanetEarthTest()
        {
            driver.FindElement(By.CssSelector("[aria-label=planets]")).Click();

            var planetsPage = new PlanetsPage(driver);
            Planet planet = planetsPage.ExploreWithLambda(p => String.Equals("earth" , p.GetName() , StringComparison.OrdinalIgnoreCase));
            planet.clickExplore();


            Assert.AreEqual(expected: "Exploring Earth",
                            actual: planetsPage.getPopUp());
        }




        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}