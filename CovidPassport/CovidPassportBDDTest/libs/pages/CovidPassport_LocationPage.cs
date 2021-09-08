using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
        private IWebElement _edit => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[3]/a[1]"));
        private IWebElement _details => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[3]/a[2]"));
        private IWebElement _delete => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[3]/a[3]"));
        private IWebElement _homeBtn => Driver.FindElement(By.XPath("/html/body/header/nav/div/a[2]"));
        private IWebElement _healthCentreTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/div/"));
        private IWebElement _usersTab => Driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/div/"));
        private IWebElement _locationList => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/"));

        #endregion
        #region Methods
        public void VisitLocationPage() => Driver.Navigate().GoToUrl(_url);
        public void ClickAddCentre() => _addCentre.Click();
        public void ClickEdit() => _edit.Click();
        public void ClickDetails() => _details.Click();
        public void ClickDelete() => _delete.Click();
        public void ClickHome() => _homeBtn.Click();
        public void ClickHealthCentreOption(int option) => _healthCentreTab.FindElement(By.XPath($"a[{option}]")).Click();
        public void ClickUsersOption(int option) => _usersTab.FindElement(By.XPath($"a[{option}]")).Click();
        public void FindHealthCentre(int row, int data) => _locationList.FindElement(By.XPath($"tr[{row}]/td[{data}]"));
        #endregion
    }
}
