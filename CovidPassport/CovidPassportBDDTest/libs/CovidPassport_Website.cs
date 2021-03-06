using OpenQA.Selenium;
using CovidPassportBDDTest.libs.pages;
using CovidPassportBDDTest.libs.driver_config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPassportBDDTest.libs
{
    class CovidPassport_Website<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }
        public CovidPassport_AddressPage AddressPage { get; set; }
        public CovidPassport_LocationPage LocationPage { get; set; }

        public CovidPassport_PassportApprovalPage PassportApprovalPage { get; set; }

        public CovidPassport_PassportPage PassportPage { get; set; }

        public CovidPassport_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10)
        {
            Driver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs).Driver;
            AddressPage = new CovidPassport_AddressPage(Driver);
            PassportApprovalPage = new CovidPassport_PassportApprovalPage(Driver);
            LocationPage = new CovidPassport_LocationPage(Driver);
            PassportPage = new CovidPassport_PassportPage(Driver);
        }

        public void DeleteCookies() => Driver.Manage().Cookies.DeleteAllCookies();
    }
}
