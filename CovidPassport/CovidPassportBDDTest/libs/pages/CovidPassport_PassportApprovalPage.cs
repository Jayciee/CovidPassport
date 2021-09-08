using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPassportBDDTest.libs.pages
{
    public class CovidPassport_PassportApprovalPage
    {
        public CovidPassport_PassportApprovalPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        #region Properties
        private string _url => AppConfigReader.ApprovalUrl;
        #endregion

        #region Methods

        #endregion 
    }
}
