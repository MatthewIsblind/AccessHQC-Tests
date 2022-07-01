using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace accessHQ_Test
{
    public class HomePage
    {
        private WebDriver driver;

        public HomePage(WebDriver driver)
        {
            this.driver = driver;
        }

        internal void setProductQuantity(int quantity, string productName)
        {
            var tableCells = driver.FindElements(by: By.TagName("td"));
            for (int i = 0; i < tableCells.Count; i++)
            {
                var cell = tableCells.ElementAt(i);

                if (string.Equals(cell.Text, productName, StringComparison.OrdinalIgnoreCase))
                {
                    var inputCell = tableCells.ElementAt(i - 1).FindElement(By.ClassName("qty"));
                    inputCell.SendKeys(Keys.Control + "a" + Keys.Delete);
                    inputCell.SendKeys(quantity.ToString());
                    break;
                }
            }
        }

        internal double getProductSubtotal(string productName)
        {
            var tableCells = driver.FindElements(By.TagName("td"));
            for (int i = 0; i < tableCells.Count; i++)
            {
                var cell = tableCells.ElementAt(i);
                if (string.Equals(cell.Text, productName, StringComparison.OrdinalIgnoreCase))
                {
                    return double.Parse(tableCells.ElementAt(i + 2).Text);
                }
            }
            throw new NoSuchElementException("no such product");
        }
    }
}