using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPassportSpecflowTesting.libs.pages
{
    class CovidPassport_AddressPage
    {
        public CovidPassport_AddressPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region Properties
        private IWebDriver Driver { get; }

        private string _url = AppConfigReader.AddressUrl;
        private IReadOnlyList<IWebElement> _tableItems => Driver.FindElements(By.XPath("/html/body/div/main/table/tbody"));
        private IWebElement _createNewAddress => Driver.FindElement(By.XPath("/html/body/div/main/p/a"));
        #endregion


        // Currently Methods do not have a way to
        #region Methods
        public void GoToAddressPage() => Driver.Navigate().GoToUrl(_url);
        public void CreateNewAddress() => _createNewAddress.Click();
        public void ItemByPosition_Edit(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[5]/a[1]")).Click();
        public void ItemByPosition_Details(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[5]/a[2]")).Click();
        public void ItemByPosition_Delete(int pos) => _tableItems[pos].FindElement(By.XPath($"/html/body/div/main/table/tbody/tr[{pos + 1}]/td[5]/a[3]")).Click();
        #endregion
    }
}
