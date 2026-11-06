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
            string url = "http://127.0.0.1:3000/index.html";
            _driver.Navigate().GoToUrl(url);
        }
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Fact]
        public void TestGetAllMusicRecords()
        {
            InitializeDriver();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60)); 
            IWebElement MusicRecordTable = wait.Until(driver => driver.FindElement(By.Id("music_record_table")));
            Assert.Contains("Album 1", MusicRecordTable.Text);

            //ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.ClassName("playerId"));
            //Assert.Equal(1, listElements.Count);

            TearDown();
        }
        [Fact]
        public void TestAddMusicRecord()
        {
            InitializeDriver();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));

            IWebElement InputAddRecordTitle = wait.Until(driver => driver.FindElement(By.Id("add_record_title")));
            InputAddRecordTitle.SendKeys("Test Album");
            IWebElement InputAddRecordArtist = wait.Until(driver => driver.FindElement(By.Id("add_record_artist")));
            InputAddRecordArtist.SendKeys("Test Artist");
            IWebElement InputAddRecordDuration = wait.Until(driver => driver.FindElement(By.Id("add_record_duration")));
            InputAddRecordDuration.SendKeys("240");
            IWebElement InputAddRecordYear = wait.Until(driver => driver.FindElement(By.Id("add_record_year")));
            InputAddRecordYear.SendKeys("2023");
            IWebElement addMusicButton = wait.Until(driver => driver.FindElement(By.Id("add_record_button")));
            addMusicButton.Click();

            IWebElement MusicRecordTable = wait.Until(d => d.FindElement(By.Id("music_record_table")));
            Assert.Contains("Test Album", MusicRecordTable.Text);

            TearDown();
        }
        [Fact]
        public void TestDeleteMusicRecord()
        {
            InitializeDriver();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));

            IWebElement MusicRecordTable = wait.Until(driver => driver.FindElement(By.Id("music_record_table")));
            IWebElement deleteButton = wait.Until(driver => driver.FindElement(By.Id("delete_record_button_1")));
            deleteButton.Click();

            Assert.False(MusicRecordTable.Text.Contains("Album 2"));

            TearDown();
        }
    }
}
