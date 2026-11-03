using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DRMusicUITest
{
    public class TestAPIMusic
    {
        private static readonly string DriverDirectory = "C:\\WebDriver\\win64";

        private static IWebDriver _driver;
        public static void InitializeDriver()
        {
            _driver = new FirefoxDriver(DriverDirectory);
            string url = "C:\\Users\\emil\\Documents\\GitHub\\PairProgObliOpg-- - Frontend\\frontend";
            _driver.Navigate().GoToUrl(url);
        }
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [Fact]
        public void TestGetAllSongs()
        {
            InitializeDriver();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60)); 
            IWebElement MusicRecordTable = wait.Until(driver => driver.FindElement(By.Id("music-record-table")));
            Assert.Contains("Album1", MusicRecordTable.Text);

            //ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.ClassName("playerId"));
            //Assert.Equal(1, listElements.Count);

            TearDown();
        }
    }
}
