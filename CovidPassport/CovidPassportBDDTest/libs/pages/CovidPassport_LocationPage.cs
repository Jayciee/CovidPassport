using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CovidPassportBDDTest.libs.pages
{
    public class CovidPassport_LocationPage
    {
        public CovidPassport_LocationPage(IWebDriver driver)
        {
            Driver = driver;
        }
        #region Properties
        public IWebDriver Driver { get; }
        public string _url = AppConfigReader.LocationUrl;
        private IWebElement _addCentre => Driver.FindElement(By.XPath("/html/body/div/main/p/a"));
        private IWebElement _homeBtn => Driver.FindElement(By.XPath("/html/body/header/nav/div/a[2]"));
        private IWebElement _healthCentreTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]"));
        private IWebElement _usersTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]"));
        private IWebElement _locationList => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody"));
        private IWebElement _privacyTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/a[3]"));
        #endregion
        #region Methods
        public void HoverHealthOption()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_healthCentreTab).Build().Perform();
        }
        public void HoverUserOption()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_usersTab).Build().Perform();
        }
        public void VisitLocationPage() => Driver.Navigate().GoToUrl(_url);
        public string ReturnUrl() => Driver.Url.ToString();
        public void ClickAddCentre() => _addCentre.Click();
        public void ClickHome() => _homeBtn.Click();
        public void ClickPrivacy() => _privacyTab.Click();
        public void ClickHealthCentreOption(int option) => Driver.FindElement(By.XPath($"/html/body/header/nav/div/div[1]/div/a[{option}]")).Click();
        public void ClickUsersOption(int option) => _usersTab.FindElement(By.XPath($"/html/body/header/nav/div/div[2]/div/a[{option}]")).Click();
        public void FindLocation(int row, int data) => _locationList.FindElement(By.XPath($"//tr[{row}]/td[{data}]"));
        public void ClickLocationOption(int row,int option) => _locationList.FindElement(By.XPath($"//tr[{row}]/td[3]/a[{option}]")).Click();
        #endregion
    }
}
