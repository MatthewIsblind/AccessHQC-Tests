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

        public void clickExplore()
        {
            this.webElement.FindElement(By.TagName("button")).Click();
        }

        public String GetName()
        {

            return this.webElement.FindElement(By.ClassName("headline")).Text;
        }

        public double GetRadius()
        {
            String raidusText = this.webElement.FindElement(By.ClassName("radius")).Text;
            
            raidusText = raidusText.Replace(" km", "");
            raidusText = raidusText.Replace(",", "");

            

            return Double.Parse(raidusText);
        }

        internal long getDistanceFromSun()
        {
            String raidusText = this.webElement.FindElement(By.ClassName("distance")).Text;

            raidusText = raidusText.Replace(" km", "");
            raidusText = raidusText.Replace(",", "");


            return long.Parse(raidusText);
        }
    }
}