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
            Assert.AreEqual(expected: "Exploring Jupiter",
                            actual: planetsPage.getPopUp());

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
            Assert.AreEqual(expected: "Thanks for your feedback matthew",
                            actual: form.getPopUp());

        }

        [TestMethod]
        public void LeviSubtotalTest()
        {
                //arrange

                //act
                HomePage homePage = new HomePage(driver);
                homePage.SetProductQuantity(3, "Levi 501s classic denim");

                //assert
                Assert.AreEqual(expected: 209.97,
                                actual: homePage.GetProductSubtotal("Levi 501s classic denim"));

        }


        [TestMethod]
        public void MultipleProductTotalTest()
        {
            //arrange

            //act
            HomePage homePage = new HomePage(driver);
            homePage.SetProductQuantity(4, "Levi 501s classic denim");
            homePage.SetProductQuantity(5, "Plain crewneck T-shirt (white)");

            //assert
            Assert.AreEqual(expected: 379.91,
                            actual: homePage.GetProductTotal());

        }


        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}