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

        [TestMethod]
        public void ExplorePlanetEarthBaseOnRadiusTest()
        {

            new NavBar(driver).ClickPlanetsForm();

            var planetsPage = new PlanetsPage(driver);
            Planet planet = planetsPage.ExploreWithLambda(p => p.GetRadius() == 6371);
            planet.clickExplore();


            Assert.AreEqual(expected: "Exploring Earth",
                            actual: planetsPage.getPopUp());
        }

        [TestMethod]
        public void ExploreEarthDistanceFromSunTest()
        {

            //arrange
            new NavBar(driver).ClickPlanetsForm();

            //act
            var planetsPage = new PlanetsPage(driver);
            Planet planet = planetsPage.ExploreWithLambda(p => p.getDistanceFromSun() == 778500000);
            planet.clickExplore();


            //assert
            Assert.AreEqual("Exploring Jupiter", planetsPage.getPopUp());

        }

        [TestMethod]
        public void SubmitModernFormTest() 
        {
            new NavBar(driver).clickModernForm();

            var form = new Form(driver);
            form.SetNameField("matthew");
            form.SetEmailField("mail@mail.com");
            form.ClickAgree();
            form.SelectState("SA");

            form.ClickSubmit();
            Assert.AreEqual("Thanks for your feedback matthew", form.getPopUp());

        }


/*        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }*/
    }
}